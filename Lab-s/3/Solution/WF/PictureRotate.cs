namespace WF
{
    public partial class PictureRotate : Form
    {
        public PictureRotate()
        {
            InitializeComponent();
        }

        public static event Action<object> OnImageRotate;

        private int _angle = 0;

        private void ButtonRotate_Click(object sender, EventArgs e)
        {
            if (_angle == 0 || Math.Abs(_angle) == 360) return;

            OnImageRotate?.Invoke(_angle);
        }

        private void ButtonRotate100Times_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                OnImageRotate?.Invoke(_angle);
            }
        }

        private void RotateDegree_ValueChanged(object sender, EventArgs e)
        {
            _angle = (int)((NumericUpDown)sender).Value;
        }
    }
}
