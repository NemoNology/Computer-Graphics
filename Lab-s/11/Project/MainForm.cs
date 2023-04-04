using System.Windows.Forms;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private Bitmap _baseImage;

    private MyPoint[] _baseImageHistBuffer;
    private uint[] _modifiedImageHistBuffer = new uint[byte.MaxValue + 1];

    private void ImageLoad_Click(object sender, EventArgs e)
    {
        if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputBaseImage.Image = new Bitmap(inputOpenFileDialog.FileName);
                outputModifiedImage.Image = outputBaseImage.Image;
                //FillARG();
            }
            catch
            {
                MessageBox.Show("Incorrect file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ImageSave_Click(object sender, EventArgs e)
    {
        if (outputModifiedImage.Image == null)
        {
            return;
        }

        if (inputSaveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputModifiedImage.Image.Save(inputSaveFileDialog.FileName);
            }
            catch
            {
                MessageBox.Show(
                    "Invalid input",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}

struct MyPoint
{
    public byte Value { get; set; }

    public uint X { get; set; }
    public uint Y { get; set; }
}
