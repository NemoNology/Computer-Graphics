namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        _baseImageHistBuffer = new List<(int x, int y)>[byte.MaxValue + 1];

        for (int i = 0; i < _baseImageHistBuffer.Length; i++)
        {
            _baseImageHistBuffer[i] = new List<(int x, int y)>();
        }
    }

    private List<(int x, int y)>[] _baseImageHistBuffer;
    private uint[] _modifiedImageHistBuffer;

    private ChangingHistogramForm _changingHistogramForm;

    private void ImageLoad_Click(object sender, EventArgs e)
    {
        if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputBaseImage.Image = new Bitmap(inputOpenFileDialog.FileName);
                outputModifiedImage.Image = outputBaseImage.Image;
                FillColorValueBuffer();
                FillHists();
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

    private void FillColorValueBuffer()
    {
        if (outputBaseImage.Image == null)
        {
            return;
        }

        var bmp = (Bitmap)outputBaseImage.Image;
        byte color;

        _modifiedImageHistBuffer = new uint[byte.MaxValue + 1];

        for (int i = 0; i < _baseImageHistBuffer.Length; i++)
        {
            _baseImageHistBuffer[i].Clear();
        }

        // R
        if (inputIsR.Checked)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    color = bmp.GetPixel(x, y).R;

                    _baseImageHistBuffer[color].Add((x, y));
                    _modifiedImageHistBuffer[color]++;
                }
            }
        }
        // G
        else if (inputIsG.Checked)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    color = bmp.GetPixel(x, y).G;

                    _baseImageHistBuffer[color].Add((x, y));
                    _modifiedImageHistBuffer[color]++;
                }
            }
        }
        // B
        else
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    color = bmp.GetPixel(x, y).B;

                    _baseImageHistBuffer[color].Add((x, y));
                    _modifiedImageHistBuffer[color]++;
                }
            }
        }
    }

    private void FillHists()
    {
        if (outputBaseImage.Image == null)
        {
            return;
        }

        Bitmap bmp = new Bitmap(outputBaseHist.Width, outputBaseHist.Height);

        Color color = inputIsR.Checked ? Color.Red :
            (inputIsG.Checked ? Color.Green : Color.Blue);
        var h = bmp.Height - 1;
        var max = _modifiedImageHistBuffer.Max() * 1f / h;

        for (int i = 0; i < _modifiedImageHistBuffer.Length; i++)
        {
            DrawVertical(ref bmp, i,
                h - (int)(_modifiedImageHistBuffer[i] / max), color);
        }

        outputBaseHist.Image = bmp;
        outputModifiedHist.Image = bmp;
    }

    private void DrawVertical(ref Bitmap bmp, int x, int y, Color color)
    {
        for (int i = y; i < bmp.Height; i++)
        {
            bmp.SetPixel(x, y, color);
            y++;
        }
    }

    private void InputChannel_CheckedChanged(object sender, EventArgs e)
    {
        FillColorValueBuffer();
        FillHists();
    }

    private void ApplyHistToImage(uint[] newColorValues)
    {
        uint newSize = 0;
        uint oldSize = 0;

        outputModifiedImage.Image = (Bitmap)outputBaseImage.Image;

        Bitmap bmp = (Bitmap)outputModifiedImage.Image;
        List<(int x, int y)>[] baseImageHistBuffer = _baseImageHistBuffer;

        bool isR = inputIsR.Checked;
        bool isG = inputIsG.Checked;

        ////////////////////////////////////////////////////
        // Recalculate color values for new color values

        foreach (var colorValue in newColorValues)
        {
            newSize += colorValue;
        }

        foreach (var colorValue in _modifiedImageHistBuffer)
        {
            oldSize += colorValue;
        }

        var k = oldSize * 1f / newSize;

        for (int i = 0; i < newColorValues.Length; i++)
        {
            newColorValues[i] = (uint)(newColorValues[i] * k);
        }

        Random rnd = new Random(DateTime.Now.Millisecond);

        int max0;
        int max;

        while (newColorValues.Where(x => x > 0).Count() > 0 &&
            baseImageHistBuffer.Where(x => x.Count() > 0).Count() > 0)
        {
            ////////////////////////////////////////////////////
            // Finding most colorful value

            max0 = byte.MaxValue;
            max = byte.MaxValue;

            while (max >= 0 && newColorValues[max] == 0)
            {
                max--;
            }

            while (max0 >= 0 && baseImageHistBuffer[max0].Count == 0)
            {
                max0--;
            }

            ////////////////////////////////////////////////////
            // Start repaint pixels by new histogram values

            while (max >= 0 && max0 >= 0)
            {
                // Find point where color value >= max color value in new color values

                int randomCount = rnd.Next(baseImageHistBuffer[max0].Count + 1);

                while (randomCount > 0 && max >= 0)
                {
                    var pointBuffer = baseImageHistBuffer[max0][rnd.Next(baseImageHistBuffer[max0].Count)];

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
                    baseImageHistBuffer[max0].RemoveAt(0);

                    // If there is no more points with current color value => going to less color value
                    while (max >= 0 && newColorValues[max] == 0)
                    {
                        max--;
                    }

                    randomCount--;
                }

                // If there is no more points with current color value => going to less color value
                while (max >= 0 && newColorValues[max] == 0)
                {
                    max--;
                }

                while (max0 >= 0 && baseImageHistBuffer[max0].Count == 0)
                {
                    max0--;
                }
            }
        }

        ////////////////////////////////////////////////////
        // Update image and modified image histogram

        outputModifiedImage.Image = bmp;

        RedrawModifiedHistogram();
    }

    private void RedrawModifiedHistogram()
    {
        var bmp = (Bitmap)outputModifiedImage.Image.Clone();
        byte color;

        _modifiedImageHistBuffer = new uint[byte.MaxValue + 1];

        if (inputIsR.Checked)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    color = bmp.GetPixel(j, i).R;

                    _modifiedImageHistBuffer[color]++;
                }
            }
        }
        else if (inputIsG.Checked)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    color = bmp.GetPixel(j, i).G;

                    _modifiedImageHistBuffer[color]++;
                }
            }
        }
        else
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    color = bmp.GetPixel(j, i).B;

                    _modifiedImageHistBuffer[color]++;
                }
            }
        }

        //////////////////////////////////////////////////////////////////
        // Redraw hist

        bmp = new Bitmap(outputBaseHist.Width, outputBaseHist.Height);

        Color paintColor = inputIsR.Checked ? Color.Red :
            (inputIsG.Checked ? Color.Green : Color.Blue);
        var h = bmp.Height - 1;
        var max = _modifiedImageHistBuffer.Max() * 1f / h;

        for (int i = 0; i < _modifiedImageHistBuffer.Length; i++)
        {
            DrawVertical(ref bmp, i,
                h - (int)(_modifiedImageHistBuffer[i] / max), paintColor);
        }

        outputModifiedHist.Image = bmp;
    }

    private void OutputModifiedHist_Click(object sender, EventArgs e)
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
            (uint[])_modifiedImageHistBuffer.Clone(),
            color,
            (Bitmap)outputModifiedHist.Image.Clone()
            );

        _changingHistogramForm.OnHistogramChanged += ApplyHistToImage;

        _changingHistogramForm.Show();
    }



}

struct MyPoint
{
    public byte Value { get; set; }

    public int X { get; set; }
    public int Y { get; set; }

    public MyPoint()
    {
        Value = 0;
        X = 0;
        Y = 0;
    }

    public MyPoint(byte value, int x, int y)
    {
        Value = value;
        X = x;
        Y = y;
    }
}
