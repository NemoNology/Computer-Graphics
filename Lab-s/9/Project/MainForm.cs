using System.Numerics;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        mainView.Image = new Bitmap(mainView.Width, mainView.Height);

        _screenCenter = new Point3D(
            mainView.Image.Width / 2f,
            mainView.Image.Height * 0.8f,
            0);

        // _particleSystem = new ParticleSystem(
        //     FireSprite, new Vector3(0, 0, 100),
        //     new Vector3(15, 15, 15), 
        //     new Vector3(-3, -3, -3));

        _floor = new Floor3D(
            new Point3D(
                0,
                -_screenCenter.Y * 0.2f,
                mainView.Width / 2f),
            mainView.Width
            );

        DrawFloor();
    }

    private const float R = 1 / 200f;
    private ParticleSystem _particleSystem;
    private Floor3D _floor;
    private Graphics _g;

    private Square3D _square;

    private Point3D _screenCenter;

    private Image FireSprite = Bitmap.FromFile($"{Application.StartupPath}\\Data\\Sprites\\FireSprite.png");

    private void MainForm_Resize(object sender, EventArgs e)
    {
        mainView.Image = new Bitmap(mainView.Width, mainView.Height);

        _screenCenter = new Point3D(
            mainView.Image.Width / 2f,
            mainView.Image.Height * 0.8f,
            0);

        // TODO: Particle System initialization & Floor Drawing

        //_particleSystem = new ParticleSystem(
        //    FireSprite, new Vector3(0, 0, 100),
        //    new Vector3(15, 15, 15), 
        //    new Vector3(-3, -3, -3));

        _floor = new Floor3D(
            new Point3D(
                0,
                -_screenCenter.Y * 0.2f,
                mainView.Width / 2f),
            mainView.Width);

        DrawFloor();
    }

    private void DrawSquare()
    {
        MainViewClear();

        var square = new Square3D(new Point3D(-50, -50, 100), 100);

        foreach (var edge in square.GetEdgesInCentralProjection(R))
        {
            _g.DrawLine(new Pen(Color.Gray),
                _screenCenter.X + edge.point1.X, _screenCenter.Y - edge.point1.Y,
                _screenCenter.X + edge.point2.X, _screenCenter.Y - edge.point2.Y);
        }

        square.RotateAt(square.CenterPoint, 45);

        _g.DrawEllipse(new Pen(Color.Magenta),
            square.CenterPoint.GetCentralProjection(R).X,
            square.CenterPoint.GetCentralProjection(R).Y,
            2, 2);

        foreach (var edge in square.GetEdgesInCentralProjection(R))
        {
            _g.DrawLine(new Pen(Color.Black),
                _screenCenter.X + edge.point1.X, _screenCenter.Y - edge.point1.Y,
                _screenCenter.X + edge.point2.X, _screenCenter.Y - edge.point2.Y);
        }

        mainView.Image = (Bitmap)mainView.Image;
    }

    private void DrawFloor()
    {
        if (_floor == null)
        {
            return;
        }

        MainViewClear();

        foreach (var edge in _floor.Grid)
        {
            // TODO: if floor cells amount = 4: method TransformVector return infinity

            var p1 = edge.point1.GetCentralProjection(R);
            var p2 = edge.point2.GetCentralProjection(R);

            var centerX = _screenCenter.X;
            var centerY = _screenCenter.Y;

            if (centerX + p1.X > float.MaxValue ||
                centerX + p2.X > float.MaxValue ||
                centerY - p1.Y < float.MinValue ||
                centerY - p2.Y < float.MinValue)
            {
                continue;
            }

            _g.DrawLine(new Pen(Color.Black),
                    centerX + p1.X, centerY - p1.Y,
                    centerX + p2.X, centerY - p2.Y);
        }

        mainView.Image = (Bitmap)mainView.Image;
    }

    private void Translate(float Dx = 0, float Dy = 0, float Dz = 0)
    {
        _floor.Translate(Dx, Dy, Dz);
    }

    private void RotateAt(float angleDegree, int rotationAxis)
    {
        var floorCenterPoint = _floor.CenterPoint;

        _floor.RotateAt(floorCenterPoint, angleDegree, rotationAxis);
    }

    private void MainViewClear()
    {
        mainView.Image = new Bitmap(mainView.Image.Width, mainView.Image.Height);
        _g = Graphics.FromImage(mainView.Image);
    }

    private void MainView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        if (e.Shift)
        {
            if (e.KeyCode == Keys.A)
            {
                Translate(100);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.D)
            {
                Translate(-100);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.W)
            {
                Translate(0, 0, -100);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.S)
            {
                Translate(0, 0, 100);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.Q)
            {
                Translate(0, 100);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.E)
            {
                Translate(0, -100);
                DrawFloor();
            }
        }
        else
        {
            if (e.KeyCode == Keys.A)
            {
                Translate(5);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.D)
            {
                Translate(-5);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.W)
            {
                Translate(0, 0, -5);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.S)
            {
                Translate(0, 0, 5);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.Q)
            {
                Translate(0, 5);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.E)
            {
                Translate(0, -5);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.I)
            {
                RotateAt(5, 0);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.K)
            {
                RotateAt(-5, 0);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.J)
            {
                RotateAt(5, 1);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.L)
            {
                RotateAt(-5, 1);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.U)
            {
                RotateAt(5, 2);
                DrawFloor();
            }
            else if (e.KeyCode == Keys.O)
            {
                RotateAt(-5, 2);
                DrawFloor();
            }
        }

    }
}
