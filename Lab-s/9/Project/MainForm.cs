using System.Numerics;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        mainView.Image = new Bitmap(mainView.Width, mainView.Height);

        // _particleSystem = new ParticleSystem(
        //     FireSprite, CenterPoint,
        //     new Vector3(15, 15, 15), 
        //     new Vector3(-3, -3, -3));
        // _floor = new Floor3D(CenterPoint, 200, 10);

        var test01 = Vector3.Zero;
        var test02 = new Vector3(0, 0, 50);

        _g = Graphics.FromImage(mainView.Image);

        test01 = _ge.TransformVector(test01, R);
        test02 = _ge.TransformVector(test02, R);

        _g.DrawLine(
            new Pen(Color.Black), 
            test01.X + CenterPoint.X, test01.Y + CenterPoint.Y, 
            test02.X + CenterPoint.X, test02.Y + CenterPoint.Y);
        
    }

    private const float R = 0.01f;
    private ParticleSystem _particleSystem;
    private Floor3D _floor;
    private Graphics _g;

    private Image FireSprite = Bitmap.FromFile($"{Application.StartupPath}\\Data\\Sprites\\FireSprite.png"); 

    private GraphicUnit.GraphicsExtensions _ge = new GraphicUnit.GraphicsExtensions();

    private void MainForm_Resize(object sender, EventArgs e)
    {
        mainView.Image = new Bitmap(mainView.Width, mainView.Height);

        _particleSystem = new ParticleSystem(
            FireSprite, CenterPoint,
            new Vector3(15, 15, 15), 
            new Vector3(-3, -3, -3));
        _floor = new Floor3D(CenterPoint, 200, 10);

        var test01 = CenterPoint;
        var test02 = new Vector3(CenterPoint.X, 0, 50);

        _g = Graphics.FromImage(mainView.Image);

        test01 = _ge.TransformVector(test01, R);
        test02 = _ge.TransformVector(test02, R);

        _g.DrawLine(
            new Pen(Color.Black), 
            test01.X, test01.Y, 
            test02.X, test02.Y);
    }

    private Vector3 CenterPoint
    {
        get
        {
            return new Vector3(
                mainView.Image.Width / 2f,
                mainView.Image.Height * 0.8f,
                0);
        }
    }


}
