namespace Project
{
    public partial class ChangingHistogramForm : Form
    {
        public event Action<uint[]> OnHistogramChanged;

        public ChangingHistogramForm(uint[] colorValues, Color color, Bitmap histogram)
        {
            InitializeComponent();

            inputHistogram.Image = histogram;
            _colorValues = colorValues;
            _color = color;
        }

        private uint[] _colorValues = new uint[byte.MaxValue + 1];
        private Color _color;

        private void DrawLineDown(ref Bitmap bmp, int x, int y)
        {
            if (y < 0 || x < 0 ||
                y >= bmp.Height || x >= bmp.Width)
            {
                return;
            }

            var voidColor = new Color();

            int upY = y + 1;

            for (int i = y; i >= 0; i--)
            {
                bmp.SetPixel(x, i, voidColor);
            }

            for (int i = y; i < bmp.Height; i++)
            {
                bmp.SetPixel(x, i, _color);
            }
        }

        private void InputHistogram_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var histBuffer = (Bitmap)inputHistogram.Image;
                DrawLineDown(ref histBuffer, e.X, e.Y);
                inputHistogram.Image = histBuffer;
            }
        }

        private void ApplyHistogram_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)inputHistogram.Image;

            byte colorValue;
           
            if (_color.R == byte.MaxValue)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        colorValue = bmp.GetPixel(x, y).R;

                        _colorValues[colorValue]++;
                    }
                }
            }
            else if (_color.G == byte.MaxValue)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        colorValue = bmp.GetPixel(x, y).G;

                        _colorValues[colorValue]++;
                    }
                }
            }
            else
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        colorValue = bmp.GetPixel(x, y).B;

                        _colorValues[colorValue]++;
                    }
                }
            }

            OnHistogramChanged?.Invoke(_colorValues);
        }
    }
}
