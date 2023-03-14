namespace WF
{
    public partial class PictureResize : Form
    {
        public delegate void PictureSizeChanged(Point newSize);

        public static event PictureSizeChanged? OnPictureSizeChanged;

        public PictureResize(Point size)
        {
            InitializeComponent();

            _size = size;

            UpdateInfo(size, EventArgs.Empty);

            MainForm.OnMainViewResize += UpdateInfo;
        }

        private void ButtonResize_Click(object sender, EventArgs e)
        {
            if (!IsValidInput()) return;

            _size = new Point(
                    (int)_inputWidth.Value,
                    (int)_inputHeight.Value);

            OnPictureSizeChanged?.Invoke(_size);
        }

        private Point _size;

        private void UpdateInfo(object newSize, EventArgs e)
        {
            _size = (Point)newSize;

            _outputPictureSize.Text = $"{_size.X} x {_size.Y} (px)";

            _inputWidth.Maximum = _size.X * 100;
            _inputHeight.Maximum = _size.Y * 100;

            _inputWidth.Value = _size.X;
            _inputHeight.Value = _size.Y;
        }

        private bool IsValidInput()
        {
            try
            {
                _status.Text = "Invalid value: Coefficient X";
                Convert.ToDouble(_inputKX.Text);
                _status.Text = "Invalid value: Coefficient Y";
                Convert.ToDouble(_inputKY.Text);
                _status.Text = "Invalid value: Width";
                Convert.ToDouble(_inputWidth.Text);
                _status.Text = "Invalid value: Height";
                Convert.ToDouble(_inputHeight.Text);

                _status.Text = "...";

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Input_ValueChanged(object sender, EventArgs e)
        {
            float value;

            if (sender.GetType() == typeof(NumericUpDown))
            {
                value = (float)((NumericUpDown)sender).Value;

                if (((NumericUpDown)sender).Name == "_inputWidth")
                {
                    _inputKX.Text = $"{value / _size.X}";
                }
                else
                {
                    _inputKY.Text = $"{value / _size.Y}";
                }
            }
            else
            {
                if (!IsValidInput()) return;

                value = Convert.ToSingle(((TextBox)sender).Text);

                if (((TextBox)sender).Name == "_inputKX")
                {
                    if ((decimal)(_size.X * value) > _inputWidth.Maximum)
                    {
                        _inputWidth.Value = _inputWidth.Maximum;
                        ((TextBox)sender).Text = $"{_inputWidth.Maximum / _size.X}";
                        return;
                    }

                    _inputWidth.Value = (decimal)(_size.X * value);
                }
                else
                {
                    if ((decimal)(_size.Y * value) > _inputHeight.Maximum)
                    {
                        _inputHeight.Value = _inputHeight.Maximum;
                        ((TextBox)sender).Text = $"{_inputHeight.Maximum / _size.Y}";
                        return;
                    }

                    _inputHeight.Value = (decimal)(_size.Y * value);
                }
            }
        }
    }
}
