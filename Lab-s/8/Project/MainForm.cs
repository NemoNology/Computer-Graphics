using System.Net;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private uint[] _r = new uint[byte.MaxValue + 1];
    private uint[] _g = new uint[byte.MaxValue + 1];
    private uint[] _b = new uint[byte.MaxValue + 1];

    private Graphics _gr;

    private void FillHists()
    {
        var kR = (float)(inputHistRScale.Value * 2);
        var kG = (float)(inputHistGScale.Value * 2);
        var kB = (float)(inputHistBScale.Value * 2);

        outputHistR.Image = new Bitmap(260, 202);
        outputHistG.Image = new Bitmap(260, 202);
        outputHistB.Image = new Bitmap(260, 202);

        //DrawHistsAxis();

        // R
        _gr = Graphics.FromImage(outputHistR.Image);
        var h = outputHistR.Image.Height - 2;
        var bmp = (Bitmap)outputHistR.Image;
        var max = _r.Max();

        for (int i = 0; i < _r.Length; i++)
        {
            DrawVertical(ref bmp, i + 2,
                h, (int)(_r[i] * kR / max),
                Color.Red);
        }

        // G
        _gr = Graphics.FromImage(outputHistG.Image);
        h = outputHistG.Image.Height - 2;
        bmp = (Bitmap)outputHistG.Image;
        max = _g.Max();

        for (int i = 0; i < _g.Length; i++)
        {
            DrawVertical(ref bmp,
                i + 2, h,
                (int)(_g[i] * kG / max),
                Color.Green);
        }

        // B
        _gr = Graphics.FromImage(outputHistB.Image);
        h = outputHistB.Image.Height - 2;
        bmp = (Bitmap)outputHistB.Image;
        max = _b.Max();

        for (int i = 0; i < _b.Length; i++)
        {
            DrawVertical(ref bmp, i + 2,
                h, (int)(_b[i] * kB / max),
                Color.Blue);
        }
    }

    private void ImageLoad_Click(object sender, EventArgs e)
    {
        if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputMainView.Image = new Bitmap(inputOpenFileDialog.FileName);
                FillARG();
            }
            catch (Exception exc)
            {
                //MessageBox.Show("Incorrect file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"{exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void FillARG()
    {
        var bmp = (Bitmap)outputMainView.Image;

        _r = new uint[byte.MaxValue + 1];
        _g = new uint[byte.MaxValue + 1];
        _b = new uint[byte.MaxValue + 1];

        for (int i = 0; i < bmp.Height; i++)
        {
            for (int j = 0; j < bmp.Width; j++)
            {
                var color = bmp.GetPixel(j, i);

                _r[color.R]++;
                _g[color.G]++;
                _b[color.B]++;
            }
        }

        outputMaxR.Text = _r.Max().ToString();
        outputMaxG.Text = _g.Max().ToString();
        outputMaxB.Text = _b.Max().ToString();

        FillHists();
    }

    private void DrawHistsAxis()
    {
        // R
        _gr = Graphics.FromImage(outputHistR.Image);
        _gr.DrawLine(new Pen(Color.Black),
            new Point(1, 1),
            new Point(1, outputHistR.Image.Height - 2)
            );
        _gr.DrawLine(new Pen(Color.Black),
            new Point(1, outputHistR.Image.Height - 1),
            new Point(outputHistR.Image.Width - 1,
            outputHistR.Image.Height - 1)
            );

        // G
        _gr = Graphics.FromImage(outputHistG.Image);
        _gr.DrawLine(new Pen(Color.White),
            new Point(1, 1),
            new Point(1, outputHistG.Image.Height - 2)
            );
        _gr.DrawLine(new Pen(Color.White),
            new Point(1, outputHistG.Image.Height - 1),
            new Point(outputHistG.Image.Width - 1,
            outputHistG.Image.Height - 1)
            );

        // B
        _gr = Graphics.FromImage(outputHistB.Image);
        _gr.DrawLine(new Pen(Color.White),
            new Point(1, 1),
            new Point(1, outputHistB.Image.Height - 2)
            );
        _gr.DrawLine(new Pen(Color.White),
            new Point(1, outputHistB.Image.Height - 1),
            new Point(outputHistB.Image.Width - 1,
            outputHistB.Image.Height - 1)
            );
    }

    private void DrawVertical(ref Bitmap bmp, int x, int y, int height, Color color)
    {
        while (y - height < 0)
        {
            height--;
        }

        for (int i = 0; i < height; i++)
        {
            bmp.SetPixel(x, y, color);
            y--;
        }
    }

    private void Scale_Changed(object sender, EventArgs e)
    {
        if (outputMainView.Image == null)
        {
            return;
        }

        FillHists();
    }
}