using System.Drawing.Imaging;

namespace Project;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        inputColorMode.SelectedIndex = 0;

        _m = new float[_n, _n];
        MatrixToGrid();

        FillPatterns();
    }

    private Image _baseImage;
    private Image _modifiedImage;

    private int _n = 1;
    private float _k = 1;
    private float[,] _m;

    private Dictionary<string, Action> _filtersPatterns = new Dictionary<string, Action>();

    private void ImageLoad_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                outputBaseImage.Image = new Bitmap(openFileDialog.FileName);
                outputModifiedImage.Image = (Image)outputBaseImage.Image.Clone();

                // saving
                _baseImage = outputBaseImage.Image;
                _modifiedImage = outputModifiedImage.Image;

                UpdateImages();
            }
            catch
            {
                MessageBox.Show(
                    "Incorrect file",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
                MessageBox.Show(
                    "Invalid input",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

    private void UpdateImages()
    {
        if (_baseImage == null)
        {
            return;
        }

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

                        bmpB.SetPixel(j, i, Color.FromArgb(cr, cr, cr));
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

                        bmpM.SetPixel(j, i, Color.FromArgb(cr, cr, cr));
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

                        bmpB.SetPixel(j, i, Color.FromArgb(cg, cg, cg));
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

                        bmpM.SetPixel(j, i, Color.FromArgb(cg, cg, cg));
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

                        bmpB.SetPixel(j, i, Color.FromArgb(cb, cb, cb));
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

                        bmpM.SetPixel(j, i, Color.FromArgb(cb, cb, cb));
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
        _n = (int)inputN.Value;
        _m = new float[_n, _n];
        MatrixToGrid();
    }

    private void ApplyFilter_Click(object sender, EventArgs e)
    {
        if (
            !IsValidInput
            || _baseImage == null
            || (!inputCalculateR.Checked && !inputCalculateG.Checked && !inputCalculateB.Checked)
        )
        {
            return;
        }

        bool zero = inputFillEmptyPixelsWithZero.Checked;
        bool ndm = inputGetPixelsFromBaseImage.Checked;

        Bitmap bi = (Bitmap)_baseImage.Clone();
        int hn = _n / 2;
        int endN = _n % 2 == 0 ? hn : hn + 1;
        int cell = 0;

        bool isR = inputCalculateR.Checked;
        bool isG = inputCalculateG.Checked;
        bool isB = inputCalculateB.Checked;

        var submatrixR = new List<byte>(_n * _n);
        var submatrixG = new List<byte>(_n * _n);
        var submatrixB = new List<byte>(_n * _n);

        Color bufferColor = new Color();

        Bitmap bufferBMP = (Bitmap)bi.Clone();

        Color[,] baseImage = new Color[bi.Height, bi.Width];
        Color[,] modImage = new Color[bi.Height, bi.Width];

        // Get filtered picture
        for (int x = 0; x < bi.Width; x++)
        {
            for (int y = 0; y < bi.Height; y++)
            {
                // Getting submatrix from picture
                for (int X = x - hn; X < x + endN; X++)
                {
                    for (int Y = y - hn; Y < y + endN; Y++)
                    {
                        if (X < 0 || X >= bi.Width || Y < 0 || Y >= bi.Height)
                        {
                            bufferColor = zero ? Color.Black : Color.White;
                        }
                        else
                        {
                            bufferColor = ndm ? bi.GetPixel(X, Y) : bufferBMP.GetPixel(X, Y);
                        }

                        if (isR)
                        {
                            submatrixR.Add(bufferColor.R);
                        }

                        if (isG)
                        {
                            submatrixG.Add(bufferColor.G);
                        }

                        if (isB)
                        {
                            submatrixB.Add(bufferColor.B);
                        }
                    }
                }

                // After getting submatrix => Let's get new pixel color
                float newColorValueR = 0;
                float newColorValueG = 0;
                float newColorValueB = 0;

                // 1.1) Calculate new color value
                for (int Y = 0; Y < _n; Y++)
                {
                    for (int X = 0; X < _n; X++)
                    {
                        if (isR)
                        {
                            newColorValueR += submatrixR[cell] * _m[Y, X];
                        }

                        if (isG)
                        {
                            newColorValueG += submatrixG[cell] * _m[Y, X];
                        }

                        if (isB)
                        {
                            newColorValueB += submatrixB[cell] * _m[Y, X];
                        }

                        cell++;
                    }
                }

                // 1.2) Clean sub matrixes & counter 'cell' after use
                if (isR)
                {
                    submatrixR.Clear();
                }

                if (isG)
                {
                    submatrixG.Clear();
                }

                if (isB)
                {
                    submatrixB.Clear();
                }

                cell = 0;

                // 2) Apply coefficient & 3) Correct new value
                if (isR)
                {
                    newColorValueR *= _k;

                    if (newColorValueR < 0)
                    {
                        newColorValueR = 0;
                    }
                    else if (newColorValueR > 255)
                    {
                        newColorValueR = 255;
                    }
                }

                if (isG)
                {
                    newColorValueG *= _k;

                    if (newColorValueG < 0)
                    {
                        newColorValueG = 0;
                    }
                    else if (newColorValueG > 255)
                    {
                        newColorValueG = 255;
                    }
                }

                if (isB)
                {
                    newColorValueB *= _k;

                    if (newColorValueB < 0)
                    {
                        newColorValueB = 0;
                    }
                    else if (newColorValueB > 255)
                    {
                        newColorValueB = 255;
                    }
                }

                // 4.1) Get pixel color from base image
                var c = ndm ? bi.GetPixel(x, y) : bufferBMP.GetPixel(x, y);

                // 4.2) Save value to buffer map
                bufferBMP.SetPixel(
                    x, y,
                    Color.FromArgb(
                        isR ? (byte)newColorValueR : c.R,
                        isG ? (byte)newColorValueG : c.G,
                        isB ? (byte)newColorValueB : c.B
                    )
                );

                baseImage[y, x] = bi.GetPixel(x, y);
                modImage[y, x] = bufferBMP.GetPixel(x, y);
            }
        }

        // 5) Rewrite modified image
        _modifiedImage = bufferBMP;

        var t1 = baseImage;
        var t2 = modImage;

        UpdateImages();    
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
                    var value = inputMatrix.Rows[i].Cells[j].Value;

                    if (value is float)
                    {
                        continue;
                    }

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

    private void FillPatternsChoose()
    {
        foreach (var pattern in _filtersPatterns)
        {
            inputFilterPattern.Items.Add(pattern.Key);
        }

        inputFilterPattern.SelectedIndex = inputFilterPattern.Items.Count - 1;
    }

    private void Pattern_Identity()
    {
        inputN.Value = 3;
        inputK.Text = "1";

        _m = new float[3, 3]
        {
            { 0, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 0 }
        };
    }

    private void Pattern_Ridge()
    {
        inputN.Value = 3;
        inputK.Text = "1";

        _m = new float[3, 3]
        {
            { 0, -1, 0 },
            { -1, 4, -1 },
            { 0, -1, 0 }
        };
    }

    private void Pattern_EdgeDetection()
    {
        inputN.Value = 3;
        inputK.Text = "1";

        _m = new float[3, 3]
        {
            { -1, -1, -1 },
            { -1, 8, -1 },
            { -1, -1, -1 }
        };
    }

    private void Pattern_Sharpen()
    {
        inputN.Value = 3;
        inputK.Text = "1";

        _m = new float[3, 3]
        {
            { 0, -1, 0 },
            { -1, 5, -1 },
            { 0, -1, 0 }
        };
    }

    private void Pattern_BoxBlur()
    {
        inputN.Value = 3;
        inputK.Text = $"{1f / 9}";

        _m = new float[3, 3]
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };
    }

    private void Pattern_GaussianBlur_3x3()
    {
        inputN.Value = 3;
        inputK.Text = $"{1f / 16}";

        _m = new float[3, 3]
        {
            { 1, 2, 1 },
            { 2, 4, 2 },
            { 1, 2, 1 }
        };
    }

    private void Pattern_GaussianBlur_5x5()
    {
        inputN.Value = 5;
        inputK.Text = $"{1f / 256}";

        _m = new float[5, 5]
        {
            { 1, 4, 6, 4, 1 },
            { 4, 16, 24, 16, 4 },
            { 6, 24, 36, 24, 6 },
            { 4, 16, 24, 16, 4 },
            { 1, 4, 6, 4, 1 }
        };
    }

    private void Pattern_SecondGaussianBlur_5x5()
    {
        inputN.Value = 5;
        inputK.Text = "1";

        _m = new float[5, 5]
        {
            { 789 / 1e6f, 6581 / 1e6f, 13347 / 1e6f, 6581 / 1e6f, 789 / 1e6f },
            { 6581 / 1e6f, 54901 / 1e6f, 111356 / 1e6f, 54901 / 1e6f, 6581 / 1e6f },
            { 13347 / 1e6f, 111356 / 1e6f, 225821 / 1e6f, 111356 / 1e6f, 13347 / 1e6f },
            { 6581 / 1e6f, 54901 / 1e6f, 111356 / 1e6f, 54901 / 1e6f, 6581 / 1e6f },
            { 789 / 1e6f, 6581 / 1e6f, 13347 / 1e6f, 6581 / 1e6f, 789 / 1e6f }
        };
    }

    private void Pattern_Example()
    {
        inputN.Value = 3;
        inputK.Text = $"{1f / 6}";

        _m = new float[3, 3]
        {
            { 0.5f, 0.75f, 0.5f },
            { 0.75f, 1, 0.75f },
            { 0.5f, 0.75f, 0.5f }
        };
    }

    private void Pattern_DefinitionIncrease()
    {
        inputN.Value = 3;
        inputK.Text = "1";

        _m = new float[3, 3]
        {
            { -1, -1, -1 },
            { -1, 9, -1 },
            { -1, -1, -1 }
        };
    }

    private void Pattern_Neighborhood()
    {
        inputN.Value = 5;
        inputK.Text = "1";

        _m = new float[5, 5]
        {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 1, 1, 1, 1, 1 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };
    }

    private void FillPatterns()
    {
        _filtersPatterns.Add("Identity", Pattern_Identity);
        _filtersPatterns.Add("Ridge", Pattern_Ridge);
        _filtersPatterns.Add("Edge Detection", Pattern_EdgeDetection);
        _filtersPatterns.Add("Sharpen", Pattern_Sharpen);
        _filtersPatterns.Add("Box Blur", Pattern_BoxBlur);
        _filtersPatterns.Add("Gaussian Blur 3x3", Pattern_GaussianBlur_3x3);
        _filtersPatterns.Add("Gaussian Blur 5x5", Pattern_GaussianBlur_5x5);
        _filtersPatterns.Add("Another Gaussian Blur 5x5", Pattern_SecondGaussianBlur_5x5);
        _filtersPatterns.Add("Example", Pattern_Example);
        _filtersPatterns.Add("Definition Increase", Pattern_DefinitionIncrease);
        _filtersPatterns.Add("Neighborhood", Pattern_Neighborhood);

        _filtersPatterns.Add("Custom", () => { });

        FillPatternsChoose();
    }

    private void InputFilterPatternSelectedIndex_Changed(object sender, EventArgs e)
    {
        try
        {
            _filtersPatterns[inputFilterPattern.Text].Invoke();
            MatrixToGrid();
        }
        catch (Exception exc)
        {
            MessageBox.Show($"{exc.Message}");
        }
    }
}
