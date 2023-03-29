namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        inputColorMode.SelectedIndex = 0;

        _m = new float[_n, _n];
    }

    private uint[] _r = new uint[byte.MaxValue + 1];
    private uint[] _g = new uint[byte.MaxValue + 1];
    private uint[] _b = new uint[byte.MaxValue + 1];

    private Image _baseImage;
    private Image _modifiedImage;

    private int _n;
    private float _k = 1;
    private float[,] _m;


    private void ImageLoad_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputBaseImage.Image = new Bitmap(openFileDialog.FileName);
                outputModifiedImage.Image = outputBaseImage.Image;

                // saving
                _baseImage = outputBaseImage.Image;
                _modifiedImage = outputModifiedImage.Image;

                UpdateImages();
            }
            catch
            {
                MessageBox.Show("Incorrect file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void ImageSave_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputModifiedImage.Image.Save(saveFileDialog.FileName);
            }
            catch
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void UpdateImages()
    {
        if (inputColorMode.SelectedIndex == 0)
        {
            outputBaseImage.Image = _baseImage;
            outputModifiedImage.Image = _modifiedImage;
            return;
        }

        Bitmap bmpB = (Bitmap)_baseImage.Clone();
        Bitmap bmpM = (Bitmap)_modifiedImage.Clone();

        // R
        if (inputColorMode.SelectedIndex == 1)
        {
            // base
            Thread thB = new Thread(() =>
            {
                for (int i = 0; i < bmpB.Height; i++)
                {
                    for (int j = 0; j < bmpB.Width; j++)
                    {
                        var c = bmpB.GetPixel(j, i);
                        var cr = 255 - c.R;

                        bmpB.SetPixel(j, i,
                            Color.FromArgb(cr, cr, cr));
                    }
                }
            });

            thB.Start();

            // mod
            Thread thM = new Thread(() =>
            {
                for (int i = 0; i < bmpM.Height; i++)
                {
                    for (int j = 0; j < bmpM.Width; j++)
                    {
                        var c = bmpM.GetPixel(j, i);
                        var cr = 255 - c.R;

                        bmpM.SetPixel(j, i,
                            Color.FromArgb(cr, cr, cr));
                    }
                }
            });

            thM.Start();

            thB.Join();
            thM.Join();
        }
        // G
        else if (inputColorMode.SelectedIndex == 2)
        {
            // base
            Thread thB = new Thread(() =>
            {
                for (int i = 0; i < bmpB.Height; i++)
                {
                    for (int j = 0; j < bmpB.Width; j++)
                    {
                        var c = bmpB.GetPixel(j, i);
                        var cg = 255 - c.G;

                        bmpB.SetPixel(j, i,
                            Color.FromArgb(cg, cg, cg));
                    }
                }
            });

            thB.Start();

            // mod
            Thread thM = new Thread(() =>
            {
                for (int i = 0; i < bmpM.Height; i++)
                {
                    for (int j = 0; j < bmpM.Width; j++)
                    {
                        var c = bmpM.GetPixel(j, i);
                        var cg = 255 - c.G;

                        bmpM.SetPixel(j, i,
                            Color.FromArgb(cg, cg, cg));
                    }
                }
            });

            thM.Start();

            thB.Join();
            thM.Join();
        }
        // B
        else if (inputColorMode.SelectedIndex == 3)
        {
            // base
            Thread thB = new Thread(() =>
            {
                for (int i = 0; i < bmpB.Height; i++)
                {
                    for (int j = 0; j < bmpB.Width; j++)
                    {
                        var c = bmpB.GetPixel(j, i);
                        var cb = 255 - c.B;

                        bmpB.SetPixel(j, i,
                            Color.FromArgb(cb, cb, cb));
                    }
                }
            });

            thB.Start();

            // mod
            Thread thM = new Thread(() =>
            {
                for (int i = 0; i < bmpM.Height; i++)
                {
                    for (int j = 0; j < bmpM.Width; j++)
                    {
                        var c = bmpM.GetPixel(j, i);
                        var cb = 255 - c.B;

                        bmpM.SetPixel(j, i,
                            Color.FromArgb(cb, cb, cb));
                    }
                }
            });

            thM.Start();

            thB.Join();
            thM.Join();
        }

        outputBaseImage.Image = bmpB;
        outputModifiedImage.Image = bmpM;
    }

    private void InputColorModeSelectIndex_Changed(object sender, EventArgs e)
    {
        UpdateImages();
    }

    private void MatrixToGrid()
    {
        inputMatrix.RowCount = _n;
        inputMatrix.ColumnCount = _n;

        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _n; j++)
            {
                inputMatrix.Rows[i].Cells[j].Value = _m[i, j];
            }
        }
    }

    private void InputNValue_Changed(object sender, EventArgs e)
    {
        _m = new float[_n, _n];
        MatrixToGrid();
    }

    private void ApplyFilter_Click(object sender, EventArgs e)
    {
        if (!IsValidInput)
        {
            return;
        }
    }

    private void ReplaceBaseImageByModified_Click(object sender, EventArgs e)
    {
        _baseImage = _modifiedImage;
        outputBaseImage.Image = _baseImage;
        outputModifiedImage.Image = _baseImage;

        UpdateImages();
    }

    private bool IsValidInput
    {
        get
        {
            if (!float.TryParse(inputK.Text, out _k))
            {
                MessageBox.Show("Invalid K value");
                return false;
            }

            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    if (!float.TryParse(inputMatrix.Rows[i].Cells[j].Value as string, out _))
                    {
                        MessageBox.Show($"Invalid Matrix input at row {i}, column {j}");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
