using System.Numerics;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private const float R = 0.01f;

    private GraphicUnit.GraphicsExtensions _ge = new GraphicUnit.GraphicsExtensions();

    private void MainForm_Resize(object sender, EventArgs e)
    {

    }

    private Vector3 CenterPoint
    {
        get
        {
            return new Vector3(
                mainView.Image.Width / 2f,
                mainView.Image.Height / 2f,
                0);
        }
    }
        
}
