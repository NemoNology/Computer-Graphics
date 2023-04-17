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

        _floor = new Floor3D(
            new Point3D(
                0,
                -_screenCenter.Y * 0.2f,
                mainView.Width / 2f),
            mainView.Width);

        _particleSystem = new ParticleSystem(
            FireSprite, _floor.CenterPoint,
            new Point3D(15f, 15f, 15f),
            new Point3D(-5, -5, -5));

        //DrawFloor();

        _g = Graphics.FromImage(mainView.Image);

        DrawFire().Start();
    }

    private const float R = 1 / 100f;
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

        _floor = new Floor3D(
            new Point3D(
                0,
                -_screenCenter.Y * 0.2f,
                mainView.Width / 2f),
            mainView.Width);

        _particleSystem = new ParticleSystem(
            FireSprite, _floor.CenterPoint,
            new Point3D(15, 15, 15),
            new Point3D(-3, -3, -3));

        DrawFloor();
    }

    private void DrawFloor()
    {
        if (_floor == null)
        {
            return;
        }

        MainViewClear();

        var centerX = _screenCenter.X;
        var centerY = _screenCenter.Y;

        foreach (var polygon in _floor.GetPolygonPointsInCentralProjection(R))
        {
            for (int i = 0; i < polygon.Length; i++)
            {
                var p = polygon[i];

                if (centerX + p.X > float.MaxValue)
                {
                    continue;
                }

                polygon[i].X += centerX;

                if (centerY - p.Y < float.MinValue)
                {
                    continue;
                }

                polygon[i].Y = centerY - p.Y;
            }

            _g.FillPolygon(PenWithRandomColor.Brush, polygon);
        }

        mainView.Image = (Bitmap)mainView.Image;
    }

    private Task DrawFire()
    {
        return new Task(() =>
        {
            var floorCenterPointFInCentralProjection = _floor.CenterPoint.PointFInCentralProjection(R);
            floorCenterPointFInCentralProjection.X += _screenCenter.X;
            floorCenterPointFInCentralProjection.Y = _screenCenter.Y - floorCenterPointFInCentralProjection.Y;

            while (true)
            {
                //DrawFloor();

                for (int i = 0; i < _particleSystem.ParticlesAmount; i++)
                {
                    var particle = _particleSystem.Particles[i];

                    _g.DrawImage(particle.Sprite,
                        floorCenterPointFInCentralProjection);
                }

                mainView.Image = (Bitmap)mainView.Image;
                _g = Graphics.FromImage(mainView.Image);

                _particleSystem.MoveAll();

                Task.Delay(300).Wait();
            }
        });
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

    private Pen PenWithRandomColor => new Pen(RandomColor);

    private Color RandomColor
    {
        get
        {
            return Color.FromArgb(
                new Random().Next(byte.MaxValue + 1),
                new Random().Next(byte.MaxValue + 1),
                new Random().Next(byte.MaxValue + 1)
                );
        }
    }
}
