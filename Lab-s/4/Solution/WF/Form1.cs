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

            inputCx.Minimum = inputCy.Minimum = inputCz.Minimum =
                inputRPx.Minimum = inputRPy.Minimum = inputRPz.Minimum = -1000;

            inputRDx.Minimum = inputRDy.Minimum = inputRDz.Minimum = -360;

            CubeInputs_ValueChanged(this, EventArgs.Empty);
        }

        private Cube _cube = new Cube(new Vector3(0, 0, 20), 10);

        private Graphics _g;
        private Pen _pen = new Pen(Color.Black);

        private float _rDx;
        private float _rDy;
        private float _rDz;

        private Point _mousePreviousPosition;

        private void DrawCube()
        {
            MainViewClear();

            var rotationPoint = new Vector3((float)inputRPx.Value, (float)inputRPy.Value, (float)inputRPz.Value);

            _cube.RotateAt(rotationPoint, (int)inputRDx.Value, 0);
            _cube.RotateAt(rotationPoint, (int)inputRDy.Value, 1);
            _cube.RotateAt(rotationPoint, (int)inputRDz.Value, 2);

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

            DrawCube();
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

            DrawCube();
        }

        private void Cube_MouseRotation(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                _rDx = (_mousePreviousPosition.X - e.X) / 2f;
                _rDy = (_mousePreviousPosition.Y - e.Y) / 2f;

                if (_rDx > 180)
                {
                    _rDx -= 360;
                }
                else if (_rDx < -180)
                {
                    _rDx += 360;
                }

                if (_rDy > 180)
                {
                    _rDy -= 360;
                }
                else if (_rDy < -180)
                {
                    _rDy += 360;
                }

                inputRDx.Value = (int)_rDy;
                inputRDy.Value = (int)_rDx;
            }

            if (e.Button == MouseButtons.Right)
            {
                _rDz = (_mousePreviousPosition.X - e.X) / 2f;

                if (_rDz > 180)
                {
                    _rDz -= 360;
                }
                else if (_rDz < -180)
                {
                    _rDz += 360;
                }

                inputRDz.Value = (int)_rDz;
            }
        }

        private void Cube_MouseRotation_Started(object sender, MouseEventArgs e)
        {
            _mousePreviousPosition = e.Location;
        }
    }
}