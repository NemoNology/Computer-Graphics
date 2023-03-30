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

    private byte[,] _r;
    private byte[,] _g;
    private byte[,] _b;

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
        _n = (int)inputN.Value;
        _m = new float[_n, _n];
        MatrixToGrid();
    }

    private void ApplyFilter_Click(object sender, EventArgs e)
    {
        if (!IsValidInput)
        {
            return;
        }

        bool zero = inputFillEmptyPixelsWithZero.Checked;
        bool ndm = inputGetPixelsFromBaseImage.Checked;

        Bitmap bi = (Bitmap)_baseImage.Clone();
        Bitmap mi = (Bitmap)_baseImage.Clone();

        // R
        if (inputCalculateR.Checked)
        {
            _r = new byte[_n, _n];
            byte r;

            // Inside picture
            for (int i = 0; i < _baseImage.Height; i += _n)
            {
                for (int j = 0; j < _baseImage.Width; j += _n)
                {
                    // Getting submatrix from picture
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            if (l + _n < 0 || l + _n >= _baseImage.Height ||
                                t + _n < 0 || t + _n >= _baseImage.Width)
                            {
                                r = (byte)(zero ? 0 : 255);
                            }
                            else
                            {
                                r = bi.GetPixel(t, l).R;
                            }

                            _r[l, t] = r;
                        }
                    }

                    // After getting submatrix => Let's multiply matrixes
                    float[,] X = new float[_n, _n];

                    if (ndm)
                    {
                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                for (int k = 0; k < _n; k++)
                                {
                                    X[l, t] += _r[l, k] * _m[k, l];
                                }

                                X[l, t] *= _k;

                                if (X[l, t] < 0)
                                {
                                    X[l, t] = 0;
                                }
                                else if (X[l, t] > 255)
                                {
                                    X[l, t] = 255;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                X[l, t] = _r[l, t];
                            }
                        }

                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                for (int k = 0; k < _n; k++)
                                {
                                    X[l, t] += X[l, k] * _m[k, l];
                                }

                                X[l, t] *= _k;

                                if (X[l, t] < 0)
                                {
                                    X[l, t] = 0;
                                }
                                else if (X[l, t] > 255)
                                {
                                    X[l, t] = 255;
                                }
                            }
                        }
                    }

                    // Rewrite modified image
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            if (j + t < mi.Width && i + l < mi.Height)
                            {
                                var c = mi.GetPixel(j + t, i + l);

                                mi.SetPixel(j + t, i + l, Color.FromArgb((byte)X[l, t], c.G, c.B));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        // G
        if (inputCalculateG.Checked)
        {
            _g = new byte[_n, _n];
            byte g;

            // Inside picture
            for (int i = 0; i < _baseImage.Height; i += _n)
            {
                for (int j = 0; j < _baseImage.Width; j += _n)
                {
                    // Getting submatrix from picture
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            if (l + _n < 0 || l + _n >= _baseImage.Height ||
                                t + _n < 0 || t + _n >= _baseImage.Width)
                            {
                                g = (byte)(zero ? 0 : 255);
                            }
                            else
                            {
                                g = bi.GetPixel(t, l).G;
                            }

                            _g[l, t] = g;
                        }
                    }

                    // After getting submatrix => Let's multiply matrixes
                    float[,] X = new float[_n, _n];

                    if (ndm)
                    {
                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                for (int k = 0; k < _n; k++)
                                {
                                    X[l, t] += _g[l, k] * _m[k, l];
                                }

                                X[l, t] *= _k;

                                if (X[l, t] < 0)
                                {
                                    X[l, t] = 0;
                                }
                                else if (X[l, t] > 255)
                                {
                                    X[l, t] = 255;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                X[l, t] = _g[l, t];
                            }
                        }

                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                for (int k = 0; k < _n; k++)
                                {
                                    X[l, t] += X[l, k] * _m[k, l];
                                }

                                X[l, t] *= _k;

                                if (X[l, t] < 0)
                                {
                                    X[l, t] = 0;
                                }
                                else if (X[l, t] > 255)
                                {
                                    X[l, t] = 255;
                                }
                            }
                        }
                    }

                    // Rewrite modified image
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            if (j + t < mi.Width && i + l < mi.Height)
                            {
                                var c = mi.GetPixel(j + t, i + l);

                                mi.SetPixel(j + t, i + l, Color.FromArgb(c.R, (byte)X[l, t], c.B));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        // B
        if (inputCalculateR.Checked)
        {
            _b = new byte[_n, _n];
            byte b;

            // Inside picture
            for (int i = 0; i < _baseImage.Height; i += _n)
            {
                for (int j = 0; j < _baseImage.Width; j += _n)
                {
                    // Getting submatrix from picture
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            if (l + _n < 0 || l + _n >= _baseImage.Height ||
                                t + _n < 0 || t + _n >= _baseImage.Width)
                            {
                                b = (byte)(zero ? 0 : 255);
                            }
                            else
                            {
                                b = bi.GetPixel(t, l).B;
                            }

                            _b[l, t] = b;
                        }
                    }

                    // After getting submatrix => Let's multiply matrixes
                    float[,] X = new float[_n, _n];

                    if (ndm)
                    {
                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                for (int k = 0; k < _n; k++)
                                {
                                    X[l, t] += _b[l, k] * _m[k, l];
                                }

                                X[l, t] *= _k;

                                if (X[l, t] < 0)
                                {
                                    X[l, t] = 0;
                                }
                                else if (X[l, t] > 255)
                                {
                                    X[l, t] = 255;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                X[l, t] = _b[l, t];
                            }
                        }

                        for (int l = 0; l < _n; l++)
                        {
                            for (int t = 0; t < _n; t++)
                            {
                                for (int k = 0; k < _n; k++)
                                {
                                    X[l, t] += X[l, k] * _m[k, l];
                                }

                                X[l, t] *= _k;

                                if (X[l, t] < 0)
                                {
                                    X[l, t] = 0;
                                }
                                else if (X[l, t] > 255)
                                {
                                    X[l, t] = 255;
                                }
                            }
                        }
                    }

                    // Rewrite modified image
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            if (j + t < mi.Width && i + l < mi.Height)
                            {
                                var c = mi.GetPixel(j + t, i + l);

                                mi.SetPixel(j + t, i + l, Color.FromArgb(c.R, c.G, (byte)X[l, t]));
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        _modifiedImage = mi;

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

    private void Pattern_Convolution()
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
        _filtersPatterns.Add("Идентичность", Pattern_Identity);
        _filtersPatterns.Add("Хребет", Pattern_Ridge);
        _filtersPatterns.Add("Обнаружение границ", Pattern_EdgeDetection);
        _filtersPatterns.Add("Увеличение резкости", Pattern_Sharpen);
        _filtersPatterns.Add("Размытие поля", Pattern_BoxBlur);
        _filtersPatterns.Add("Размытие по Гауссу 3х3", Pattern_GaussianBlur_3x3);
        _filtersPatterns.Add("Размытие по Гауссу 5х5", Pattern_GaussianBlur_5x5);
        _filtersPatterns.Add("Второе размытие по Гауссу 5х5", Pattern_SecondGaussianBlur_5x5);
        _filtersPatterns.Add("Свёртка", Pattern_Convolution);
        _filtersPatterns.Add("Улучшение чёткости", Pattern_DefinitionIncrease);
        _filtersPatterns.Add("Окрестность", Pattern_Neighborhood);

        _filtersPatterns.Add("Свой", () => { });

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
