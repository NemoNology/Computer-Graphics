using System.Numerics;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);

        _g = Graphics.FromImage(outputMainView.Image);

        _squareCenter = new Point(
            outputMainView.Image.Width / 2,
            outputMainView.Image.Height / 2);

        _square = new Square(_squareCenter, _squareSideLength);

        DrawSquare();

        _lines = new List<Vector4>();
    }

    private Point _squareCenter;
    private float _squareSideLength = 100;
    private Point _firstLinePoint;
    private Square _square;
    private Graphics _g;
    private List<Vector4> _lines;

    private void MainView_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            _firstLinePoint = e.Location;
        }
    }

    private void MainView_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var buff = new Vector4(
                    _firstLinePoint.X,
                    _firstLinePoint.Y,
                    e.X, e.Y);

            _lines.Add(buff);

            DrawLines(true);
        }
    }

    private void MainView_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _squareCenter = e.Location;
            _square = new Square(_squareCenter, _squareSideLength);
            _square.RotateAt(_squareCenter, e.Delta);
            DrawSquare();
        }
    }

    private void MainView_Resized(object sender, EventArgs e)
    {
        outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);

        _squareCenter = new Point(
            outputMainView.Image.Width / 2,
            outputMainView.Image.Height / 2);

        _g = Graphics.FromImage(outputMainView.Image);

        _lines.Clear();

        DrawSquare();
    }

    private void MainView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {

    }

    /// <summary>
    /// Draw all saved pixels on main view
    /// </summary>
    /// <param name="DrawOnlyLastLine"> If true: draw only last line </param>
    private void DrawLines(bool DrawOnlyLastLine = false)
    {
        if (_lines.Count == 0) return;

        Point p1, p2;

        if (DrawOnlyLastLine)
        {
            Vector4 l = _lines.Last();

            p1 = new Point((int)l.X, (int)l.Y);
            p2 = new Point((int)l.Z, (int)l.W);

            if (IsPointInsideSquare(p1) && IsPointInsideSquare(p2))
            {
                _g.DrawLine(new Pen(Color.Blue), p1, p2);
                Redraw(true);
            }

            return;
        }

        foreach (var line in _lines)
        {
            p1 = new Point((int)line.X, (int)line.Y);
            p2 = new Point((int)line.Z, (int)line.W);

            if (IsPointInsideSquare(p1) && IsPointInsideSquare(p2))
            {
                _g.DrawLine(new Pen(Color.Blue), p1, p2);
                Redraw(true);
            }
        }
    }

    private void DrawSquare()
    {
        outputMainView.Image = new Bitmap(outputMainView.Image.Width, outputMainView.Image.Height);
        _g = Graphics.FromImage(outputMainView.Image);

        foreach (var line in _square.Edges)
        {
            var p1 = line.Item1;
            var p2 = line.Item2;

            _g.DrawLine(new Pen(Color.Black),
            p1.X, p1.Y,
            p2.X, p2.Y);
        }

        DrawLines();

        outputMainView.Image = (Bitmap)outputMainView.Image;
    }

    private void Redraw(bool OnlyUpdateImage = false)
    {
        if (OnlyUpdateImage)
        {
            outputMainView.Image = (Bitmap)outputMainView.Image;
            return;
        }

        outputMainView.Image = new Bitmap(outputMainView.Image.Width, outputMainView.Image.Height);

        _g = Graphics.FromImage(outputMainView.Image);

        DrawLines();
        DrawSquare();

        outputMainView.Image = (Bitmap)outputMainView.Image;
    }

    private bool IsPointInsideSquare(Point p)
    {
        return CheckContour(p, 0) &&
        CheckContour(p, 1) &&
        CheckContour(p, 2) &&
        CheckContour(p, 3);
    }

    /// <param name="direction"> 0 - Up <br/> 1 - Left <br/> 2 - Down <br/> 3 - Right <br/> </param>
    /// <returns> False, if can freely walk to the border of picture in chosen direction <br/> True - otherwise </returns>
    private bool CheckContour(Point p, int direction)
    {
        var bmp = (Bitmap)outputMainView.Image;

        Color voidColor = bmp.GetPixel(p.X, p.Y);

        var w = outputMainView.Image.Width;
        var h = outputMainView.Image.Height;

        if (direction == 0)
        {
            int Dy = p.Y;
            int x = p.X;

            while (Dy >= 0)
            {
                Dy--;

                if (bmp.GetPixel(x, Dy) != voidColor)
                {
                    return true;
                }
            }

            return false;
        }
        else if (direction == 1)
        {
            int Dx = p.X;
            int y = p.Y;

            while (Dx >= 0)
            {
                Dx--;

                if (bmp.GetPixel(Dx, y) != voidColor)
                {
                    return true;
                }
            }

            return false;
        }
        else if (direction == 2)
        {
            int Dy = p.Y;
            int x = p.X;

            while (Dy < h)
            {
                Dy++;

                if (bmp.GetPixel(x, Dy) != voidColor)
                {
                    return true;
                }
            }

            return false;
        }
        else if (direction == 3)
        {
            int Dx = 0;
            int y = p.Y;

            while (Dx < w)
            {
                Dx++;

                if (bmp.GetPixel(Dx, y) != voidColor)
                {
                    return true;
                }
            }

            return false;
        }
        else
        {
            return false;
        }
    }
}