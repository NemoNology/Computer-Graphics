namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        _baseImageHistograms =
            new List<List<(int x, int y)>[]>(ChannelsAmount);
        _modifiedImageHistograms = new List<uint[]>(ChannelsAmount);
    }

    private const int ChannelsAmount = 3;

    private List<List<(int x, int y)>[]> _baseImageHistograms;

    private List<uint[]> _modifiedImageHistograms;

    private int _colorChannelIndex = 0;

    private ChangingHistogramForm? _changingHistogramForm;

    private void ImageLoad_Click(object sender, EventArgs e)
    {
        if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputBaseImage.Image = new Bitmap(inputOpenFileDialog.FileName);
                outputModifiedImage.Image = outputBaseImage.Image;

                if (outputBaseImage.Image.Width * outputBaseImage.Image.Height > int.MaxValue)
                {
                    MessageBox.Show("Image is have big-ass resolution", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    outputBaseImage.Image = outputModifiedImage.Image = null;
                    return;
                }

                FillColorValues();
                FillBaseHistogram();
                FillModifiedHistogram();
            }
            catch
            {
                MessageBox.Show("Incorrect file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ImageSave_Click(object sender, EventArgs e)
    {
        if (outputModifiedImage.Image == null)
        {
            return;
        }

        if (inputSaveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputModifiedImage.Image.Save(inputSaveFileDialog.FileName);
            }
            catch
            {
                MessageBox.Show(
                    "Invalid input",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

    private void FillColorValues()
    {
        if (outputBaseImage.Image == null)
        {
            return;
        }

        var bmp = (Bitmap)outputBaseImage.Image;
        Color color;

        // CLear values
        _baseImageHistograms.Clear();
        _modifiedImageHistograms.Clear();

        Parallel.For(0, ChannelsAmount, i =>
        {
            _baseImageHistograms.Add(new List<(int x, int y)>[byte.MaxValue + 1]);
            _modifiedImageHistograms.Add(new uint[byte.MaxValue + 1]);
        });

        Parallel.For(0, ChannelsAmount, i =>
        {
            Parallel.For(0, _baseImageHistograms[i].Length, j =>
            {
                _baseImageHistograms[i][j] = new List<(int x, int y)>();
            });
        });

        // Filling color values
        for (int y = 0; y < bmp.Height; y++)
        {
            for (int x = 0; x < bmp.Height; x++)
            {
                color = bmp.GetPixel(x, y);

                _baseImageHistograms[0][color.R].Add((x, y));
                _baseImageHistograms[1][color.G].Add((x, y));
                _baseImageHistograms[2][color.B].Add((x, y));

                _modifiedImageHistograms[0][color.R]++;
                _modifiedImageHistograms[1][color.G]++;
                _modifiedImageHistograms[2][color.B]++;
            }
        }
    }

    private void FillBaseHistogram()
    {
        if (outputBaseImage.Image == null)
        {
            return;
        }

        Bitmap bmp = new Bitmap(outputBaseHist.Width, outputBaseHist.Height);

        List<(int x, int y)>[] baseImageHistogram =
            (List<(int x, int y)>[])_baseImageHistograms[_colorChannelIndex].Clone();

        Color color = _colorChannelIndex == 0 ? Color.Red :
            (_colorChannelIndex == 1 ? Color.Green : Color.Blue);
        var h = bmp.Height - 1;
        var max = baseImageHistogram
            .AsParallel()
            .MaxBy(x => x.Count())
            ?.Count * 1f / h;


        for (int i = 0; i < baseImageHistogram.Length; i++)
        {
            DrawVertical(ref bmp, i,
                h - (int)(baseImageHistogram[i].Count / max), color);
        }

        outputBaseHist.Image = bmp;
    }

    private void DrawVertical(ref Bitmap bmp, int x, int y, Color color)
    {
        if (y < 0 ||
            y > bmp.Height)
        {
            throw new ArgumentOutOfRangeException(nameof(y));
        }
        if (x < 0 ||
            x > bmp.Width)
        {
            throw new ArgumentOutOfRangeException(nameof(x));
        }

        for (int i = y; i < bmp.Height; i++)
        {
            bmp.SetPixel(x, y, color);
            y++;
        }
    }

    private void InputChannel_CheckedChanged(object sender, EventArgs e)
    {
        _colorChannelIndex = (inputIsR.Checked ? 0
            : (inputIsG.Checked ? 1 : 2));

        FillBaseHistogram();
        FillModifiedHistogram();
    }

    private void ApplyHistogramToImage(uint[] newColorValues)
    {
        uint newSize = 0;
        uint oldSize = 0;

        outputModifiedImage.Image = (Bitmap)outputBaseImage.Image;

        var size = _baseImageHistograms[_colorChannelIndex].Length;

        Bitmap bmp = new Bitmap(outputModifiedImage.Image);

        List<(int x, int y)>[] baseImageHistogramBuffer = 
            new List<(int x, int y)>[_baseImageHistograms[_colorChannelIndex].Length];

        for (int i = 0; i < _baseImageHistograms[_colorChannelIndex].Length; i++)
        {
            baseImageHistogramBuffer[i] = new List<(int x, int y)>();

            for (int j = 0; j < _baseImageHistograms[_colorChannelIndex][i].Count; j++)
            {
                baseImageHistogramBuffer[i].Add(_baseImageHistograms[_colorChannelIndex][i][j]);
            }
        }

        bool isR = inputIsR.Checked;
        bool isG = inputIsG.Checked;

        ////////////////////////////////////////////////////
        // Recalculate color values for new color values

        Parallel.ForEach(newColorValues, colorValue =>
        {
            newSize += colorValue;
        });

        Parallel.ForEach(
            _modifiedImageHistograms[_colorChannelIndex],
            colorValue =>
            {
                oldSize += colorValue;
            });

        var k = oldSize * 1f / newSize;

        Parallel.For(0, newColorValues.Length, i =>
        {
            newColorValues[i] = (uint)(newColorValues[i] * k);
        });

        newColorValues.CopyTo(_modifiedImageHistograms[_colorChannelIndex], 0);

        Random rnd = new Random(DateTime.Now.Millisecond);

        int max0;
        int max;

        ////////////////////////////////////////////////////
        // Finding most colorful value

        max0 = byte.MaxValue;
        max = byte.MaxValue;

        while (max >= 0 && newColorValues[max] == 0)
        {
            max--;
        }

        while (max0 >= 0 && baseImageHistogramBuffer[max0].Count == 0)
        {
            max0--;
        }

        ////////////////////////////////////////////////////
        // Start repaint pixels by new histogram values

        while (max >= 0 && max0 >= 0)
        {
            // Find point where color value >= max color value in new color values

            var randomPointIndex = rnd.Next(baseImageHistogramBuffer[max0].Count);

            var pointBuffer = baseImageHistogramBuffer[max0][randomPointIndex];

            var x = pointBuffer.x;
            var y = pointBuffer.y;

            var color = bmp.GetPixel(pointBuffer.x, pointBuffer.y);

            // Repaint pixel with new color value
            if (isR)
            {
                bmp.SetPixel(x, y,
                    Color.FromArgb(
                        max,
                        color.G,
                        color.B
                        ));
            }
            else if (isG)
            {
                bmp.SetPixel(x, y,
                    Color.FromArgb(
                        color.R,
                        max,
                        color.B
                        ));
            }
            else
            {
                bmp.SetPixel(x, y,
                    Color.FromArgb(
                        color.R,
                        color.G,
                        max
                        ));
            }

            // Decrease points with max color value in new color values amount
            newColorValues[max]--;

            // Remove already repaint point
            baseImageHistogramBuffer[max0].RemoveAt(randomPointIndex);

            // If there is no more points with current color value => going to less color value
            while (max >= 0 && newColorValues[max] == 0)
            {
                max--;
            }

            // If there is no more points with current color value => going to less color value
            while (max >= 0 && newColorValues[max] == 0)
            {
                max--;
            }

            while (max0 >= 0 && baseImageHistogramBuffer[max0].Count == 0)
            {
                max0--;
            }
        }

        ////////////////////////////////////////////////////
        // Update image and modified image histogram

        outputModifiedImage.Image = bmp;

        FillModifiedHistogram();
    }

    private void FillModifiedHistogram()
    {
        if (outputBaseImage.Image == null)
        {
            return;
        }

        uint[] modifiedImageHistogramBuffer =
            (uint[])_modifiedImageHistograms[_colorChannelIndex].Clone();

        Bitmap bmp = new Bitmap(outputBaseHist.Width, outputBaseHist.Height);

        Color paintColor = inputIsR.Checked ? Color.Red :
            (inputIsG.Checked ? Color.Green : Color.Blue);
        var h = bmp.Height - 1;
        var max = _modifiedImageHistograms[_colorChannelIndex].Max() * 1f / h;

        for (int i = 0; i < modifiedImageHistogramBuffer.Length; i++)
        {
            DrawVertical(ref bmp, i,
                h - (int)(modifiedImageHistogramBuffer[i] / max), paintColor);
        }

        outputModifiedHist.Image = bmp;
    }

    private void OutputModifiedHistogram_Click(object sender, EventArgs e)
    {
        if (outputBaseImage.Image == null)
        {
            return;
        }

        if (_changingHistogramForm != null)
        {
            _changingHistogramForm.Close();
        }

        Color color = inputIsR.Checked ? Color.Red :
            (inputIsG.Checked ? Color.Green : Color.Blue);

        _changingHistogramForm = new ChangingHistogramForm(
            (uint[])_modifiedImageHistograms[_colorChannelIndex].Clone(),
            color,
            (Bitmap)outputModifiedHist.Image.Clone()
            );

        _changingHistogramForm.OnHistogramChanged += ApplyHistogramToImage;

        _changingHistogramForm.Show();
    }



}
