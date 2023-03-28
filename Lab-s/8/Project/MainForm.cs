using System.Net;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private uint[] _r = new uint[byte.MaxValue];
    private uint[] _g = new uint[byte.MaxValue];
    private uint[] _b = new uint[byte.MaxValue];

    private Graphics _gr;

    private void FillHists()
    {
        var kR = (float)(inputHistRScale.Value / 100);
        var kG = (float)(inputHistGScale.Value / 100);
        var kB = (float)(inputHistBScale.Value / 100);

        var maxR = _r.Max() * kR;
        var maxG = _g.Max() * kG;
        var maxB = _b.Max() * kB;

        outputHistR.Image = new Bitmap(258, (int)maxR);
        outputHistG.Image = new Bitmap(258, (int)maxG);
        outputHistB.Image = new Bitmap(258, (int)maxB);

        DrawHistsAxis();

        
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
            catch
            {
                MessageBox.Show("Incorrect file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void FillARG()
    {
        var bmp = (Bitmap)outputMainView.Image;

        _r = new uint[byte.MaxValue];
        _g = new uint[byte.MaxValue];
        _b = new uint[byte.MaxValue];

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

        FillHists();
    }

    private void DrawHistsAxis()
    {
        var pen = new Pen(Color.Black);

        // R
        _gr = Graphics.FromImage(outputHistR.Image);
        _gr.DrawLine(pen,
            new Point(1, 1),
            new Point(1, outputHistR.Image.Height - 2)
            );
        _gr.DrawLine(pen,
            new Point(1, outputHistR.Image.Height - 1),
            new Point(outputHistR.Image.Width - 1, 
            outputHistR.Image.Height - 1)
            );

        // G
        _gr = Graphics.FromImage(outputHistG.Image);
        _gr.DrawLine(pen,
            new Point(1, 1),
            new Point(1, outputHistG.Image.Height - 2)
            );
        _gr.DrawLine(pen,
            new Point(1, outputHistG.Image.Height - 1),
            new Point(outputHistG.Image.Width - 1,
            outputHistG.Image.Height - 1)
            );

        // B
        _gr = Graphics.FromImage(outputHistB.Image);
        _gr.DrawLine(pen,
            new Point(1, 1),
            new Point(1, outputHistB.Image.Height - 2)
            );
        _gr.DrawLine(pen,
            new Point(1, outputHistB.Image.Height - 1),
            new Point(outputHistB.Image.Width - 1,
            outputHistB.Image.Height - 1)
            );
    }

    private void DrawVertical(ref Bitmap bmp, int x, int y1, int y2, Color color)
    {
        if (y2 < y1)
        {
            (y1, y2) = (y2, y1);
        }

        for (int i = y1; i >= y2; i--)
        {
            bmp.SetPixel(x, i, color);
        }
    }

}