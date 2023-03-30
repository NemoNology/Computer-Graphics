using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

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
        if (!IsValidInput || _baseImage == null)
        {
            return;
        }

        bool zero = inputFillEmptyPixelsWithZero.Checked;

        Bitmap bi = (Bitmap)_baseImage.Clone();
        Bitmap mi = (Bitmap)_baseImage.Clone();
        int hn = _n / 2;
        int endN = _n % 2 == 0 ? hn : hn + 1;
        int cell;

        var _submatrix = new List<byte>(_n * _n);

        byte colorPart;

        // R
        if (inputCalculateR.Checked)
        {
            float[,] newValues = new float[bi.Height, bi.Width];

            // Inside picture
            for (int i = 0; i < bi.Height; i++)
            {
                for (int j = 0; j < bi.Width; j++)
                {
                    _submatrix.Clear();

                    // Getting submatrix from picture
                    for (int l = i - hn; l < i + endN; l++)
                    {
                        for (int t = j - hn; t < j + endN; t++)
                        {
                            if (l < 0 || l >= bi.Height ||
                                t < 0 || t >= bi.Width)
                            {
                                colorPart = (byte)(zero ? 0 : 255);
                            }
                            else
                            {
                                colorPart = bi.GetPixel(t, l).R;
                            }

                            _submatrix.Add(colorPart);
                        }
                    }

                    // After getting submatrix => Let's get new pixel color
                    float newColorValue = 0;

                    cell = 0;

                    // 1) Calculate new color value
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            newColorValue += _submatrix[cell] * _m[l, t];
                            cell++;
                        }
                    }

                    // 2) Apply coefficient
                    newColorValue *= _k;

                    // 3) Correct new color value
                    if (newColorValue < 0)
                    {
                        newColorValue = 0;
                    }
                    else if (newColorValue > 255)
                    {
                        newColorValue = 255;
                    }

                    // 4) Save new color value
                    newValues[i, j] = newColorValue;
                }
            }

            // Rewrite modified image
            for (int i = 0; i < bi.Height; i++)
            {
                for (int j = 0; j < bi.Width; j++)
                {
                    var c = mi.GetPixel(j, i);
                    mi.SetPixel(j, i, Color.FromArgb((byte)newValues[i, j], c.G, c.B));
                }
            }
        }

        // G
        if (inputCalculateG.Checked)
        {
            float[,] newValues = new float[bi.Height, bi.Width];

            // Inside picture
            for (int i = 0; i < _baseImage.Height; i++)
            {
                for (int j = 0; j < _baseImage.Width; j++)
                {
                    _submatrix.Clear();

                    // Getting submatrix from picture
                    for (int l = i - hn; l < i + endN; l++)
                    {
                        for (int t = j - hn; t < j + endN; t++)
                        {
                            if (l < 0 || l >= _baseImage.Height ||
                                t < 0 || t >= _baseImage.Width)
                            {
                                colorPart = (byte)(zero ? 0 : 255);
                            }
                            else
                            {
                                colorPart = bi.GetPixel(t, l).G;
                            }

                            _submatrix.Add(colorPart);
                        }
                    }

                    // After getting submatrix => Let's get new pixel color
                    float newColorValue = 0;

                    cell = 0;

                    // 1) Calculate new color value
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            newColorValue += _submatrix[cell] * _m[l, t];
                            cell++;
                        }
                    }

                    // 2) Apply coefficient
                    newColorValue *= _k;

                    // 3) Correct new color value
                    if (newColorValue < 0)
                    {
                        newColorValue = 0;
                    }
                    else if (newColorValue > 255)
                    {
                        newColorValue = 255;
                    }

                    // 4) Save new color value
                    newValues[i, j] = newColorValue;
                }
            }

            // Rewrite modified image
            for (int i = 0; i < bi.Height; i++)
            {
                for (int j = 0; j < bi.Width; j++)
                {
                    var c = mi.GetPixel(j, i);
                    mi.SetPixel(j, i, Color.FromArgb(c.R, (byte)newValues[i, j], c.B));
                }
            }
        }

        // B
        if (inputCalculateB.Checked)
        {
            float[,] newValues = new float[bi.Height, bi.Width];

            // Inside picture
            for (int i = 0; i < _baseImage.Height; i++)
            {
                for (int j = 0; j < _baseImage.Width; j++)
                {
                    _submatrix.Clear();

                    // Getting submatrix from picture
                    for (int l = i - hn; l < i + endN; l++)
                    {
                        for (int t = j - hn; t < j + endN; t++)
                        {
                            if (l < 0 || l >= _baseImage.Height ||
                                t < 0 || t >= _baseImage.Width)
                            {
                                colorPart = (byte)(zero ? 0 : 255);
                            }
                            else
                            {
                                colorPart = bi.GetPixel(t, l).B;
                            }

                            _submatrix.Add(colorPart);
                        }
                    }

                    // After getting submatrix => Let's get new pixel color
                    float newColorValue = 0;

                    cell = 0;

                    // 1) Calculate new color value
                    for (int l = 0; l < _n; l++)
                    {
                        for (int t = 0; t < _n; t++)
                        {
                            newColorValue += _submatrix[cell] * _m[l, t];
                            cell++;
                        }
                    }

                    // 2) Apply coefficient
                    newColorValue *= _k;

                    // 3) Correct new color value
                    if (newColorValue < 0)
                    {
                        newColorValue = 0;
                    }
                    else if (newColorValue > 255)
                    {
                        newColorValue = 255;
                    }

                    // 4) Save new color value
                    newValues[i, j] = newColorValue;
                }
            }

            // Rewrite modified image
            for (int i = 0; i < bi.Height; i++)
            {
                for (int j = 0; j < bi.Width; j++)
                {
                    var c = mi.GetPixel(j, i);
                    mi.SetPixel(j, i, Color.FromArgb(c.R, c.G, (byte)newValues[i, j]));
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
        _filtersPatterns.Add("Идентичность", Pattern_Identity);
        _filtersPatterns.Add("Хребет", Pattern_Ridge);
        _filtersPatterns.Add("Обнаружение границ", Pattern_EdgeDetection);
        _filtersPatterns.Add("Увеличение резкости", Pattern_Sharpen);
        _filtersPatterns.Add("Размытие поля", Pattern_BoxBlur);
        _filtersPatterns.Add("Размытие по Гауссу 3х3", Pattern_GaussianBlur_3x3);
        _filtersPatterns.Add("Размытие по Гауссу 5х5", Pattern_GaussianBlur_5x5);
        _filtersPatterns.Add("Второе размытие по Гауссу 5х5", Pattern_SecondGaussianBlur_5x5);
        _filtersPatterns.Add("Пример", Pattern_Example);
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
