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

        _lines = new List<Vector4>();

        DrawSquare();
    }

    private Point _squareCenter;
    private int _squareSideLength = 100;
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
            var newPlace = e.Location;

            _square.Translate(newPlace.X - _squareCenter.X,
            newPlace.Y - _squareCenter.Y);

            _squareCenter = e.Location;
            DrawSquare();
        }
    }

    private void MainView_MouseWheel(object sender, MouseEventArgs e)
    {
        if (e.Delta > 0)
        {
            _squareSideLength += 5;
            _square = new Square(_squareCenter, _squareSideLength);
        }
        else
        {
            if (_squareSideLength - 5 >= 0)
            {
                _squareSideLength -= 5;
                _square = new Square(_squareCenter, _squareSideLength);
            }
        }

        DrawSquare();
    }

    private void MainView_Resized(object sender, EventArgs e)
    {
        outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);

        _g = Graphics.FromImage(outputMainView.Image);

        _lines.Clear();

        DrawSquare();
    }

    /// <summary>
    /// Draw all saved pixels on main view
    /// </summary>
    /// <param name="DrawOnlyLastLine"> If true: draw only last line </param>
    private void DrawLines(bool DrawOnlyLastLine = false)
    {
        if (_lines.Count == 0) return;

        Vector2 p1, p2;

        if (DrawOnlyLastLine)
        {
            Vector4 l = _lines.Last();

            p1 = new Vector2(l.X, l.Y);
            p2 = new Vector2(l.Z, l.W);

            if (CohenSutherlandLineClip(ref p1, ref p2))
            {
                _g.DrawLine(
                    new Pen(Color.Blue),
                    p1.X, p1.Y,
                    p2.X, p2.Y);
            }

            Redraw(true);

            return;
        }

        foreach (var line in _lines)
        {
            p1 = new Vector2(line.X, line.Y);
            p2 = new Vector2(line.Z, line.W);

            if (CohenSutherlandLineClip(ref p1, ref p2))
            {
                _g.DrawLine(
                    new Pen(Color.Blue),
                    p1.X, p1.Y,
                    p2.X, p2.Y);
            }

            Redraw(true);
        }
    }

    private void DrawSquare()
    {
        outputMainView.Image = new Bitmap(outputMainView.Image.Width, outputMainView.Image.Height);
        _g = Graphics.FromImage(outputMainView.Image);

        int w = outputMainView.Image.Width - 1;
        int h = outputMainView.Image.Height - 1;

        foreach (var line in _square.Edges)
        {
            Vector2 p1 = line.Item1;
            Vector2 p2 = line.Item2;

            if (p1.X < 0) p1.X = 0;
            else if (p1.X >= w) p1.X = w;

            if (p1.Y < 0) p1.Y = 0;
            else if (p1.Y >= h) p1.Y = h;

            if (p2.X < 0) p2.X = 0;
            else if (p2.X >= w) p2.X = w;

            if (p2.Y < 0) p2.Y = 0;
            else if (p2.Y >= h) p2.Y = h;

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

        DrawSquare();

        outputMainView.Image = (Bitmap)outputMainView.Image;
    }

    private byte CodePoint(Vector2 point)
    {
        byte res = 0;

        // LEFT - 0001
        if (point.X < _square.A.X)
        {
            res += 1;
        }
        // RIGHT - 0010
        else if (point.X > _square.C.X)
        {
            res += 2;
        }

        // BOTTOM - 0100
        if (point.Y > _square.C.Y)
        {
            res += 4;
        }
        // TOP - 1000
        else if (point.Y < _square.A.Y)
        {
            res += 8;
        }

        return res;
    }

    private bool CohenSutherlandLineClip(ref Vector2 point1, ref Vector2 point2)
    {
        // Calc points places
        var code1 = CodePoint(point1);
        var code2 = CodePoint(point2);

        // Is line or line part visible
        bool accept = false;

        float x = 0, y = 0;
        float x0 = point1.X, y0 = point1.Y;
        float x1 = point2.X, y1 = point2.Y;

        // Our window is square

        while (true)
        {
            // If line already in square
            if (code1 + code2 == 0)
            {
                accept = true;
                break;
            }
            // Line don't cross square
            else if ((code1 & code2) != 0)
            {
                break;
            }
            // Line cross square
            else
            {
                float minX = _square.A.X, maxX = _square.C.X;
                float minY = _square.A.Y, maxY = _square.C.Y;

                // Choosing point, that is not inside square
                var codeOut = code2 > code1 ? code2 : code1;

                // Now find the intersection point;
                // Use formulas:
                //   slope = (y1 - y0) / (x1 - x0)
                //   x = x0 + (1 / slope) * (ym - y0), where ym is Y min or Y max
                //   y = y0 + slope * (xm - x0), where xm is X min or X max
                // No need to worry about divide-by-zero because, in each case, the
                // code bit being tested guarantees the denominator is non-zero

                // Point is above square
                if ((codeOut & 8) != 0)
                {
                    x = x0 + (x1 - x0) * (minY - y0) / (y1 - y0);
                    y = minY;
                }
                // Point is below square
                else if ((codeOut & 4) > 0)
                {
                    x = x0 + (x1 - x0) * (maxY - y0) / (y1 - y0);
                    y = maxY;
                }
                // Point is to the right of square
                else if ((codeOut & 2) > 0)
                {
                    y = y0 + (y1 - y0) * (maxX - x0) / (x1 - x0);
                    x = maxX;
                }
                // Point is to the left of square
                else if ((codeOut & 1) > 0)
                {
                    y = y0 + (y1 - y0) * (minX - x0) / (x1 - x0);
                    x = minX;
                }

                // Now we move outside point to intersection point to clip
                // and get ready for next pass.
                if (codeOut == code1)
                {
                    x0 = x;
                    y0 = y;
                    code1 = CodePoint(new Vector2(x0, y0));
                }
                else
                {
                    x1 = x;
                    y1 = y;
                    code2 = CodePoint(new Vector2(x1, y1));
                }
            }
        }

        point1 = new Vector2(x0, y0);
        point2 = new Vector2(x1, y1);

        return accept;
    }
}