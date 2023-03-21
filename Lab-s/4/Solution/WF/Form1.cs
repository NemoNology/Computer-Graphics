using System.Numerics;

namespace WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _mainView.Image = new Bitmap(_mainView.Width, _mainView.Height);

            _g = Graphics.FromImage(_mainView.Image);

            inputCx.Minimum = inputCy.Minimum = -1000;
        }

        private Cube _cube = new Cube(new Vector3(0, 0, 20), 10);

        private Graphics _g;
        private Pen _pen = new Pen(Color.Black);

        private void DrawCube()
        {
            MainViewClear();

            foreach (var item in _cube.Edges)
            {
                var p1 = item.Item1;
                var p2 = item.Item2;

                _g.DrawLine(_pen,
                    ScreenCenterX + p1.X, ScreenCenterY - p1.Y,
                    ScreenCenterX + p2.X, ScreenCenterY - p2.Y);

            }

            _mainView.Image = (Bitmap)_mainView.Image;
        }

        private float ScreenCenterX => _mainView.Image.Width / 2f;
        private float ScreenCenterY => _mainView.Image.Height / 2f;


        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            DrawCube();
        }



        private void MainView_SizeChanged(object sender, EventArgs e)
        {
            _mainView.Image = new Bitmap(_mainView.Width, _mainView.Height);
            _g = Graphics.FromImage(_mainView.Image);
        }

        private void MainViewClear()
        {
            _mainView.Image = new Bitmap(_mainView.Image.Width, _mainView.Image.Height);
            _g = Graphics.FromImage(_mainView.Image);
        }

        private void CubeInputs_ValueChanged(object sender, EventArgs e)
        {
            if (inputCubeSize.Value > ushort.MaxValue)
            {
                inputCubeSize.Value = ushort.MaxValue;
            }

            _cube = new Cube(new Vector3(
                (float)inputCx.Value,
                (float)inputCy.Value,
                (float)inputCz.Value
                ),
                (ushort)inputCubeSize.Value);
        }
    }
}