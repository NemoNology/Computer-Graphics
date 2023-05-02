using GraphicUnit;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        _waterVoxels.Add(new Cube(new Point3D(), 20));

        OutputView_Clear();
    }

    private List<Cube> _waterVoxels = new List<Cube>();

    private Graphics _graphics;

    private void OutputView_Clear()
    {
        outputView.Image = new Bitmap(outputView.Width, outputView.Height);
        _graphics = Graphics.FromImage(outputView.Image);
    }
}
