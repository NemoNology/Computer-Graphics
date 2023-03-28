namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private byte[] _r = new byte[byte.MaxValue];
    private byte[] _g = new byte[byte.MaxValue];
    private byte[] _b = new byte[byte.MaxValue];

    private void ClearHists()
    {
        outputHistR.Image = new Bitmap(258, (int)(inputHistRScale.Value / 100) * _r.Max());
    }

    private void ImageLoad_Click(object sender, EventArgs e)
    {
        if (inputOpenFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputMainView.Image = new Bitmap(inputOpenFileDialog.FileName);
            }
            catch
            {
                MessageBox.Show("Incorrect file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
