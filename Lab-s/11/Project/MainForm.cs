using System.Windows.Forms;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        // TODO: Subscribing
        // _changingHistogramForm.OnHistogramChanged += 
    }

    private Bitmap _baseImage;

    private byte[,] _baseImageHistBuffer;
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

        _baseImageHistBuffer = new byte[bmp.Height, bmp.Width];
        _modifiedImageHistBuffer = new uint[byte.MaxValue + 1];

        if (inputIsR.Checked)
        {
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    color = bmp.GetPixel(j, i).R;
                    _baseImageHistBuffer[i, j] = color;
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
                    _baseImageHistBuffer[i, j] = color;
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
                    _baseImageHistBuffer[i, j] = color;
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

    private void ApplyHistToImage()
    {

    }

    // TODO: Method that subscribe for ChangingHistogram event

    // TODO: Method that invoke (show) ChangingHistogramForm -
    // when double click on modified histogram


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
