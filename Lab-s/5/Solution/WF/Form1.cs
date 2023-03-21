using System.Numerics;

namespace WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);

            _g = Graphics.FromImage(outputMainView.Image);

            foreach (var item in Enum.GetValues(typeof(Filling.FillingTypes)))
            {
                inputFillingType.Items.Add(item);
            }

            inputFillingType.SelectedIndex = 0;
        }


        private Graphics _g;
        private Pen _pen = new Pen(Color.Black);
        private Point _firstLinePoint;


        private void ChoseColor_Click(object sender, EventArgs e)
        {
            if (inputColor_Dialog.ShowDialog() == DialogResult.OK)
            {
                _pen.Color = inputColor_Dialog.Color;
            }
        }

        private void MainView_Draw(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _g.DrawRectangle(_pen, e.X, e.Y, 0.5f, 0.5f);
            }
        }

        private void MainView_LineDrawStart(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                var filling = new Filling();

                var buffer = (Bitmap)outputMainView.Image;

                try
                {
                    var emptyColor = new Bitmap(1, 1).GetPixel(0, 0);

                    filling.Fill(ref buffer, e.Location, _pen.Color, emptyColor, (Filling.FillingTypes)inputFillingType.SelectedItem);
                    Redraw();
                }
                catch (StackOverflowException)
                {
                    MessageBox.Show("Stack Overflow");
                }
                catch (Exception exc)
                {
                    MessageBox.Show($"Error: {exc.Message}");
                }
            }

            if (e.Button == MouseButtons.Left)
            {
                _g.DrawRectangle(_pen, e.X, e.Y, 0.5f, 0.5f);
            }

            if (e.Button == MouseButtons.Right)
            {
                _firstLinePoint = e.Location;
            }
        }

        private void MainView_LineDrawEnd(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _g.DrawLine(_pen, _firstLinePoint, e.Location);
            }
        }

        private void MainView_SizeChanged(object sender, EventArgs e)
        {
            outputMainView.Image = new Bitmap(outputMainView.Width, outputMainView.Height);

            _g = Graphics.FromImage(outputMainView.Image);
        }

        private void Redraw()
        {
            outputMainView.Image = (Bitmap)outputMainView.Image;
        }

        private void Image_Clear(object sender, EventArgs e)
        {
            outputMainView.Image = new Bitmap(outputMainView.Image.Width, outputMainView.Image.Height);
        }
    }
}