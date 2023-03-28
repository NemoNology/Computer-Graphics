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

        _fill = new FillLine();

        UpdatePyramid();
    }

    private NGonalPyramid _pyramid;
    private Vector3 _centerPoint;
    private Graphics _g;
    private List<Color> _facesColors;
    private FillLine _fill;

    private float _pyramidHeight = 100;
    private float _pyramidRadius = 40;
    private int _pyramidN = 8;

    private void OutputMainView_MouseDown(object sender, MouseEventArgs e)
    {

    }

    private void DrawPyramid()
    {
        MainViewClear();

        int i = 1;

        Bitmap bmp = (Bitmap)outputMainView.Image;

        if (IsPyramidBaseFaceVisible)
        {
            foreach (var item in _pyramid.BaseEdges)
            {
                var p1 = item.Item1;
                var p2 = item.Item2;

                var pen = new Pen(Color.Black);

                _g.DrawLine(
                    pen,
                    p1.X, p1.Y,
                    p2.X, p2.Y);
            }

            _fill.Fill(ref bmp, new Point(
                (int)_pyramid.PyramidBaseCenterPoint.X,
                (int)_pyramid.PyramidBaseCenterPoint.Y),
                _facesColors[0]);
        }

        foreach (var item in _pyramid.Faces)
        {
            var p1 = item.Item1;
            var p2 = item.Item2;
            var p3 = item.Item3;

            if (IsFaceVisible(p1, p2, p3))
            {
                var pen = new Pen(Color.Black);

                var pf1 = new PointF( p1.X, p1.Y );
                var pf2 = new PointF( p2.X, p2.Y );
                var pf3 = new PointF( p3.X, p3.Y );

                Pen b;

                b = new Pen(_facesColors[i]);

                _g.FillPolygon(
                    b.Brush,
                    new PointF[3]{ pf1, pf2, pf3 });
            }

            i++;
        }

        Redraw();
    }

    private void OutputMainView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.X)
        {
            for (int i = 0; i < _facesColors.Count; i++)
            {
                _facesColors[i] = RandomColor;
            }

            DrawPyramid();
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
        else if (e.KeyCode == Keys.I)
        {
            _pyramidHeight += 5;
            UpdatePyramid();
        }
        else if (e.KeyCode == Keys.K)
        {
            _pyramidHeight -= 5;

            if (_pyramidHeight < 5)
            {
                _pyramidHeight = 5;
            }

            UpdatePyramid();
        }
        else if (e.KeyCode == Keys.L)
        {
            _pyramidRadius += 5;
            UpdatePyramid();
        }
        else if (e.KeyCode == Keys.J)
        {
            _pyramidRadius -= 5;

            if (_pyramidRadius < 5)
            {
                _pyramidRadius = 5;
            }

            UpdatePyramid();
        }
        else if (e.KeyCode == Keys.O)
        {
            _pyramidN += 1;
            UpdatePyramid();
        }
        else if (e.KeyCode == Keys.U)
        {
            _pyramidN -= 1;

            if (_pyramidN < 3)
            {
                _pyramidN = 3;
            }

            UpdatePyramid();
        }

    }

    private void UpdatePyramid()
    {
        _centerPoint = new Vector3(outputMainView.Width / 2f, outputMainView.Height / 2f, 0);
        _pyramid = new NGonalPyramid(_centerPoint, _pyramidHeight, _pyramidRadius, _pyramidN);

        _facesColors = new List<Color>(_pyramidN + 1);

        for (int i = 0; i < _pyramidN + 1; i++)
        {
            _facesColors.Add(RandomColor);
        }

        DrawPyramid();
    }

    private void Form1_Resize(object sender, EventArgs e)
    {
        outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);
        _g = Graphics.FromImage(outputMainView.Image);

        _centerPoint = new Vector3(outputMainView.Width / 2f, outputMainView.Height / 2f, 0);
        _pyramid = new NGonalPyramid(_centerPoint, _pyramidHeight, _pyramidRadius, _pyramidN);

        _facesColors = new List<Color>(_pyramidN + 1);

        for (int i = 0; i < _pyramidN + 1; i++)
        {
            _facesColors.Add(RandomColor);
        }

        DrawPyramid();
    }

    private void Redraw()
    {
        outputMainView.Image = (Bitmap)outputMainView.Image;
    }

    private bool IsFaceVisible(Vector3 point1, Vector3 point2, Vector3 point3)
    {
        Vector3 o = GetNormal(point1, point2, point3);

        return _pyramid.PyramidCenter.Z - o.Z <= 0;
    }

    public bool IsPyramidBaseFaceVisible
    {
        get
        {
            return _pyramid.PyramidCenter.Z - _pyramid.PyramidBaseCenterPoint.Z >= 0;
        }
    }
    
    private void MainViewClear()
    {
        outputMainView.Image = new Bitmap(outputMainView.Image.Width, outputMainView.Image.Height);
        _g = Graphics.FromImage(outputMainView.Image);
    }

    private Color RandomColor
    {
        get
        {
            var r = new Random().Next(byte.MinValue, byte.MaxValue);
            var g = new Random().Next(byte.MinValue, byte.MaxValue);
            var b = new Random().Next(byte.MinValue, byte.MaxValue);

            return Color.FromArgb(byte.MaxValue, r, g, b);
        }
    }

    private Vector2 GetCenterOfFace(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector2 c = new Vector2
        (
            (p2.X + p3.X) / 2,
            (p2.Y + p3.Y) / 2
        );

        Vector2 p = new Vector2(p1.X, p1.Y);

        var d = Vector2.Distance(c, p);



        return new Vector2
        (
            (c.X + p.X) / 2,
            (c.Y + p.Y) / 2
        );
    }

    private Vector3 GetNormal(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 A = p2 - p1;
        Vector3 B = p3 - p1;

        return new Vector3
        (
            A.Y * B.Z - A.Z * B.Y,
            A.Z * B.X - A.X * B.Z,
            A.X * B.Y - A.Y * B.X
        );
    }

}