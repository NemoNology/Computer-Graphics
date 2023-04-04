using System.Windows.Forms;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private Bitmap _baseImage;

    private MyPoint[] _baseImageHistBuffer = new MyPoint[byte.MaxValue + 1];
    private uint[] _modifiedImageHistBuffer = new uint[byte.MaxValue + 1];

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

        _baseImageHistBuffer = new MyPoint[byte.MaxValue + 1];
        _modifiedImageHistBuffer = new uint[byte.MaxValue + 1];

        if (inputIsR.Checked)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    color = bmp.GetPixel(j, i).R;

                    _baseImageHistBuffer[color].Value = color;
                    _baseImageHistBuffer[color].X = (uint)j;
                    _baseImageHistBuffer[color].Y = (uint)i;

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

                    _baseImageHistBuffer[color].Value = color;
                    _baseImageHistBuffer[color].X = (uint)j;
                    _baseImageHistBuffer[color].Y = (uint)i;

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

                    _baseImageHistBuffer[color].Value = color;
                    _baseImageHistBuffer[color].X = (uint)j;
                    _baseImageHistBuffer[color].Y = (uint)i;

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

        Bitmap bmp = (Bitmap)outputModifiedHist.Image;
        MyPoint[] baseImageHistBuffer = _baseImageHistBuffer;

        bool isR = inputIsR.Checked;
        bool isG = inputIsG.Checked;

        foreach (var colorValue in newColorValues)
        {
            newSize += colorValue;
        }

        foreach (var colorValue in _modifiedImageHistBuffer)
        {
            oldSize += colorValue;
        }

        var k = newSize * 1f / oldSize;

        for (int i = 0; i < newColorValues.Length; i++)
        {
            newColorValues[i] = (uint)(newColorValues[i] * k);
        }

        uint max = newColorValues.Max();

        while (max > 0)
        {
            var pointBuffer = baseImageHistBuffer.MaxBy(x => x.Value);

            var color = bmp.GetPixel((int)pointBuffer.X, (int)pointBuffer.Y);

            var indexMax = Array.IndexOf(newColorValues, max);

            if (isR)
            {
                bmp.SetPixel((int)pointBuffer.X, (int)pointBuffer.Y,
                    Color.FromArgb(
                        (int)max, 
                        color.G, 
                        color.B
                        ));
            }
            else if (isG)
            {
                bmp.SetPixel((int)pointBuffer.X, (int)pointBuffer.Y,
                    Color.FromArgb(
                        color.R,
                        (int)max,
                        color.B
                        ));
            }
            else
            {
                bmp.SetPixel((int)pointBuffer.X, (int)pointBuffer.Y,
                    Color.FromArgb(
                        color.R,
                        color.G,
                        (int)max
                        ));
            }

            newColorValues.SetValue(max - 1, indexMax);
            max = newColorValues.Max();

            var pointIndex = Array.IndexOf(_baseImageHistBuffer, pointBuffer);

            pointBuffer.Value--;

            baseImageHistBuffer.SetValue(pointBuffer, pointIndex);
        }

        outputModifiedImage.Image = bmp;

        RedrawModifiedHistogram();
    }

    private void RedrawModifiedHistogram()
    {
        var bmp = (Bitmap)outputBaseImage.Image;
        byte color;

        _modifiedImageHistBuffer = new uint[byte.MaxValue + 1];

        if (inputIsR.Checked)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    color = bmp.GetPixel(j, i).R;

                    _baseImageHistBuffer[color].Value = color;
                    _baseImageHistBuffer[color].X = (uint)j;
                    _baseImageHistBuffer[color].Y = (uint)i;
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

                    _baseImageHistBuffer[color].Value = color;
                    _baseImageHistBuffer[color].X = (uint)j;
                    _baseImageHistBuffer[color].Y = (uint)i;
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

                    _baseImageHistBuffer[color].Value = color;
                    _baseImageHistBuffer[color].X = (uint)j;
                    _baseImageHistBuffer[color].Y = (uint)i;
                }
            }
        }
    }

    private void OutputModifiedHist_DoubleClick(object sender, EventArgs e)
    {
        if (outputBaseImage.Image == null)
        {
            return;
        }

        if (_changingHistogramForm == null || _changingHistogramForm.Disposing)
        {
            Color color = inputIsR.Checked ? Color.Red :
            (inputIsG.Checked ? Color.Green : Color.Blue);

            _changingHistogramForm = new ChangingHistogramForm(
                _modifiedImageHistBuffer, 
                color, 
                (Bitmap)outputModifiedHist.Image
                );

            _changingHistogramForm.OnHistogramChanged += ApplyHistToImage;

            _changingHistogramForm.Show();
        }

        _changingHistogramForm.Focus();
    }

    // TODO: Tests...


}

struct MyPoint
{
    public uint Value { get; set; }

    public uint X { get; set; }
    public uint Y { get; set; }

    public MyPoint()
    {
        Value = 0;
        X = 0;
        Y = 0;
    }

    public MyPoint(uint value, uint x, uint y)
    {
        Value = value;
        X = x;
        Y = y;
    }
}
