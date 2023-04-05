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

            var max = colorValues.Max();

            if (inputHistogram.Height == 0)
            {
                _k = _height = 0;
                return;
            }

            _height = inputHistogram.Height;

            _k = max * 1f / _height;
        }

        private uint[] _colorValues = new uint[byte.MaxValue + 1];
        private int _height;
        private float _k;
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
                if (e.X < 0 || e.X >= inputHistogram.Image.Width)
                {
                    return;
                }

                var histBuffer = (Bitmap)inputHistogram.Image;
                DrawLineDown(ref histBuffer, e.X, e.Y);

                UpdateColorValues(e.X, (uint)((_height - e.Y) * _k));

                inputHistogram.Image = histBuffer;
            }
        }

        private void InputHistogram_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X < 0 || e.X >= inputHistogram.Image.Width)
                {
                    return;
                }

                var histBuffer = (Bitmap)inputHistogram.Image;
                DrawLineDown(ref histBuffer, e.X, e.Y);

                UpdateColorValues(e.X, (uint)((_height - e.Y) * _k));

                inputHistogram.Image = histBuffer;
            }
        }

        private void ApplyHistogram_Click(object sender, EventArgs e)
        {
            OnHistogramChanged?.Invoke(_colorValues);
        }

        private void On_FormClosing(object sender, FormClosingEventArgs e)
        {
            //OnHistogramChanged?.Invoke(_colorValues);
        }

        private void UpdateColorValues(int index, uint newColorValue)
        {
            _colorValues[index] = newColorValue;
        }


    }
}
