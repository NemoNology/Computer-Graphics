namespace WF
{
    public partial class PictureRotate : Form
    {
        public PictureRotate()
        {
            InitializeComponent();
        }

        public static event Action<int> OnImageRotate;

        private int _angle = 1;

        private void ButtonRotate_Click(object sender, EventArgs e)
        {
            if (_angle == 0 || Math.Abs(_angle) == 360) return;

            OnImageRotate?.Invoke(_angle);
        }

        private void RotateDegree_ValueChanged(object sender, EventArgs e)
        {
            _angle = (int)((NumericUpDown)sender).Value;
        }
    }
}
