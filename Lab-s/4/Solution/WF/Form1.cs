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

            inputKz.Maximum = uint.MaxValue;
            inputCubeSize.Maximum = ushort.MaxValue;
        }

        private uint K = 100;
        private float r => 1f / K;

        private Cube _cube = new Cube(new Vector3(0, 0, 20), 10);

        private Graphics _g;
        private Pen _pen = new Pen(Color.Black);

        private void DrawCube()
        {
            MainViewClear();

            foreach (var item in _cube.Edges)
            {
                var buffer = GraphicsExtensions.Vector3ToVector4(item.Item1);

                var p1 = GraphicsExtensions.Vector4ToVector3(Vector4.Transform(buffer, GraphicsExtensions.PerspectiveMatrix(r)));

                buffer = GraphicsExtensions.Vector3ToVector4(item.Item2);

                var p2 = GraphicsExtensions.Vector4ToVector3(Vector4.Transform(buffer, GraphicsExtensions.PerspectiveMatrix(r)));


                _g.DrawLine(_pen,
                    ScreenCenterX + p1.X, ScreenCenterY - p1.Y,
                    ScreenCenterX + p2.X, ScreenCenterY - p2.Y);
            }

            _mainView.Image = (Bitmap)_mainView.Image;
        }

        private float ScreenCenterX => _mainView.Image.Width / 2f;
        private float ScreenCenterY => _mainView.Image.Height / 2f;

        private void MainView_SizeChanged(object sender, EventArgs e)
        {
            _mainView.Image = new Bitmap(_mainView.Width, _mainView.Height);
            _g = Graphics.FromImage(_mainView.Image);
        }

        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            DrawCube();
        }

        private void Kz_ValueChanged(object sender, EventArgs e)
        {
            K = (uint)inputKz.Value;
        }

        private void MainViewClear()
        {
            _mainView.Image = new Bitmap(_mainView.Image.Width, _mainView.Image.Height);
            _g = Graphics.FromImage(_mainView.Image);
        }

        private void CubeSide_ValueChanged(object sender, EventArgs e)
        {
            _cube.SideLength = (ushort)inputCubeSize.Value;
        }
    }
}