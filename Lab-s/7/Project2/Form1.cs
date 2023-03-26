using System.Drawing;
using System.Numerics;

namespace Project2;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);
        _g = Graphics.FromImage(outputMainView.Image);

        _centerPoint = new Vector3(outputMainView.Width / 2f, outputMainView.Height / 2f, 0);
        _pyramid = new NGonalPyramid(_centerPoint, _pyramidHeight, _pyramidRadius, _pyramidN);

        _edgesColors = new List<Pen>(_pyramidN * 2);

        for (int i = 0; i < _pyramidN * 2; i++)
        {
            _edgesColors.Add(PenWithRandomColor);
        }

        DrawPyramid();
    }

    private NGonalPyramid _pyramid;
    private Vector3 _centerPoint;
    private Graphics _g;
    private List<Pen> _edgesColors;

    private float _pyramidHeight = 50;
    private float _pyramidRadius = 15;
    private int _pyramidN = 8;

    private void OutputMainView_MouseDown(object sender, MouseEventArgs e)
    {

    }

    private void DrawPyramid()
    {
        MainViewClear();

        int i = 0;

        foreach (var item in _pyramid.Edges)
        {
            var p1 = item.Item1;
            var p2 = item.Item2;

            //if (IsPointVisible(p1) && IsPointVisible(p2))
            if (IsEdgeVisible(p1, p2))
            {
                _g.DrawLine(
                    _edgesColors[i],
                    p1.X, p1.Y,
                    p2.X, p2.Y);
            }

            i++;
        }

        Redraw();
    }

    private void OutputMainView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.X)
        {
            for (int i = 0; i < _edgesColors.Count; i++)
            {
                _edgesColors[i] = PenWithRandomColor;
            }

            DrawPyramid();
        }
        else if (e.Control && e.KeyCode == Keys.N)
        {

        }
        else if (e.KeyCode == Keys.W)
        {
            _pyramid.RotateAt(2, 0);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.S)
        {
            _pyramid.RotateAt(-2, 0);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.A)
        {
            _pyramid.RotateAt(-2, 2);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.D)
        {
            _pyramid.RotateAt(2, 2);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.Q)
        {
            _pyramid.RotateAt(-2, 1);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.E)
        {
            _pyramid.RotateAt(2, 1);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.Up)
        {
            _pyramid.Transform(0, -5, 0);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.Down)
        {
            _pyramid.Transform(0, 5, 0);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.Right)
        {
            _pyramid.Transform(5, 0, 0);
            DrawPyramid();
        }
        else if (e.KeyCode == Keys.Left)
        {
            _pyramid.Transform(-5, 0, 0);
            DrawPyramid();
        }
        else if (e.Control && e.KeyCode == Keys.Z)
        {
            Form1_Resize(this, EventArgs.Empty);
        }
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
        outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);
        _g = Graphics.FromImage(outputMainView.Image);

        _centerPoint = new Vector3(outputMainView.Width / 2f, outputMainView.Height / 2f, 0);
        _pyramid = new NGonalPyramid(_centerPoint, _pyramidHeight, _pyramidRadius, _pyramidN);

        _edgesColors = new List<Pen>(_pyramidN * 2);

        for (int i = 0; i < _pyramidN * 2; i++)
        {
            _edgesColors.Add(PenWithRandomColor);
        }

        DrawPyramid();
    }

    private void Redraw()
    {
        outputMainView.Image = (Bitmap)outputMainView.Image;
    }

    private bool IsPointVisible(Vector3 point)
    {
        return Math.Round(_pyramid.PyramidBaseCenterPoint.Z - point.Z, 4) <= 0;
    }

    private bool IsEdgeVisible(Vector3 point1, Vector3 point2)
    {
        var normal = new Vector3(point1.X - point2.X,
            point1.Y - point2.Y,
            point1.Z - point2.Z);

        var condition1 = _pyramid.IsPointIsInsideByAxis(point1, 0) && _pyramid.IsPointIsInsideByAxis(point1, 1) &&
            _pyramid.IsPointIsInsideByAxis(point2, 0) && _pyramid.IsPointIsInsideByAxis(point2, 1);

        if (!condition1)
        {
            return false;
        }

        return Math.Round(_pyramid.PyramidBaseCenterPoint.Z - point1.Z, 4) <= 0 &&
            Math.Round(_pyramid.PyramidBaseCenterPoint.Z - point2.Z, 4) <= 0;
    }

    private void MainViewClear()
    {
        outputMainView.Image = new Bitmap(outputMainView.Image.Width, outputMainView.Image.Height);
        _g = Graphics.FromImage(outputMainView.Image);
    }

    private Pen PenWithRandomColor
    {
        get
        {
            var r = new Random().Next(byte.MinValue, byte.MaxValue);
            var g = new Random().Next(byte.MinValue, byte.MaxValue);
            var b = new Random().Next(byte.MinValue, byte.MaxValue);

            return new Pen(Color.FromArgb(byte.MaxValue, r, g, b));
        }
    }
}
