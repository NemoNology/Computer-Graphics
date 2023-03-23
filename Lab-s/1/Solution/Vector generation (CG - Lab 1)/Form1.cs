using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vector_generation__CG___Lab_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            p1_x.Maximum = p1_y.Maximum = p2_x.Maximum = p2_y.Maximum = n - 1;
            grid = FillGrid(n, n);
            Array2D2DataGridView(ref View1, grid);
            Array2D2DataGridView(ref View2, grid);
        }

        /// <summary>
        /// Our calculating grid
        /// </summary>
        private string[,] grid = new string[n, n];

        /// <summary>
        /// Size n - rectangle (image) size (pixels amount)
        /// </summary>
        const int n = 20;

        const string cellEmpty = "◇";
        const string cellFilled = "◆";
        const string cellFilledStart = "■";

        /// <summary>
        /// Draw a vector on DataGridView
        /// </summary>
        private void ButtonDraw_Click(object sender, EventArgs e)
        {
            try
            {
                grid = FillGrid(n, n);

                DDAPessemetry(ref grid, new Point((int)p1_x.Value, (int)p1_y.Value), new Point((int)p2_x.Value, (int)p2_y.Value));

                Array2D2DataGridView(ref View1, grid);
                ChangeBackground(ref View1);

                grid = FillGrid(n, n);

                Bresenhem(ref grid, new Point((int)p1_x.Value, (int)p1_y.Value), new Point((int)p2_x.Value, (int)p2_y.Value));

                Array2D2DataGridView(ref View2, grid);
                ChangeBackground(ref View2);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        /// <param name="width"> Width of returning 2D string array </param>
        /// <param name="height"> Height of returning 2D string array </param>
        /// <param name="emptyCell"> Symbol/String that fill empty/null values in returning 2D string array </param>
        /// <returns> A new 2D string array with inputed width and height </returns>
        public string[,] FillGrid(int width, int height, string emptyCell = cellEmpty)
        {
            string[,] result = new string[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    result[i,j] = emptyCell;
                }
            }

            return result;
        }

        /// <summary>
        /// Fill cell with inputed string in 2D string vector
        /// </summary>
        /// <param name="grid"> 2D string array which cell if filling </param>
        /// <param name="point"> Point that keep coordinates to filling </param>
        /// <param name="filledCell"> String value which will been filled cell </param>
        public void SetPixel(ref string[,] grid, Point point, string filledCell = cellFilled)
        {
            grid[point.X, point.Y] = filledCell;
        }

        /// <summary>
        /// Draw in 2D string array - grid vector by simple vector generation algirithm
        /// </summary>
        /// <param name="grid"> Grid - View - place where will be draw vector </param>
        /// <param name="p1"> First point - coordinates: x and y </param>
        /// <param name="p2"> Second point - coordinates: x and y </param>
        /// <param name="emptyCell"> String that will take a role of empty cell in grid </param>
        /// <param name="filledCell"> String that will take a role of filled cell in grid </param>
        /// <param name="startPointsCell"> String that will take a role of start points (p1 & p2) cell in grid </param>
        public void SimpleVectorGenerator(ref string[,] grid, Point p1, Point p2,
            string emptyCell = cellEmpty, string filledCell = cellFilled, string startPointsCell = cellFilledStart)
        {
            double x1 = p1.X;
            double y1 = p1.Y;

            double x2 = p2.X;
            double y2 = p2.Y;

            SetPixel(ref grid, p1, "■");
            SetPixel(ref grid, p2, "■");

            if (Math.Abs(x2 - x1) >= Math.Abs(y2 - y1))
            {
                if (x2 - x1 == 0)
                {
                    return;
                }

                if (x2 < x1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref y1, ref y2);
                }

                double k = (y2 - y1) / (x2 - x1);

                double y = y1;

                for (double x = x1; x < x2; x++)
                {
                    SetPixel(ref grid, new Point((int)x, (int)y));
                    y += k;
                }
            }
            else
            {
                if (y2 - y1 == 0)
                {
                    return;
                }

                

                if (y2 < y1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref y1, ref y2);
                }

                double k = (x2 - x1) / (y2 - y1);

                double x = x1;

                for (int y = (int)y1; y < (int)y2; y++)
                {
                    SetPixel(ref grid, new Point((int)x, (int)y));
                    x += k;
                }
                
            }

            SetPixel(ref grid, p1, "■");
            SetPixel(ref grid, p2, "■");
        }

        /// <summary>
        /// Draw in 2D string array - grid vector by DDA pessemetry algirithm
        /// </summary>
        /// <param name="grid"> Grid - View - place where will be draw vector </param>
        /// <param name="p1"> First point - coordinates: x and y </param>
        /// <param name="p2"> Second point - coordinates: x and y </param>
        /// <param name="emptyCell"> String that will take a role of empty cell in grid </param>
        /// <param name="filledCell"> String that will take a role of filled cell in grid </param>
        /// <param name="startPointsCell"> String that will take a role of start points (p1 & p2) cell in grid </param>
        public void DDAPessemetry(ref string[,] grid, Point p1, Point p2,
            string emptyCell = cellEmpty, string filledCell = cellFilled, string startPointsCell = cellFilledStart)
        {
            double x1 = p1.X;
            double y1 = p1.Y;

            double x2 = p2.X;
            double y2 = p2.Y;

            SetPixel(ref grid, p1, "■");
            SetPixel(ref grid, p2, "■");

            double Px = x2 - x1;
            double Py = y2 - y1;


            if (Math.Abs(x2 - x1) >= Math.Abs(y2 - y1))
            {
                if (x2 < x1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref y1, ref y2);
                }

                while (x1 < x2)
                {
                    x1 += 1;
                    y1 += Py / Px;

                    SetPixel(ref grid, new Point((int)x1, (int)y1));
                }
            }
            else
            {
                if (y2 < y1)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref y1, ref y2);
                }

                while (y1 < y2)
                {
                    y1 += 1;
                    x1 += Px / Py;

                    SetPixel(ref grid, new Point((int)x1, (int)y1));
                }
            }




            SetPixel(ref grid, p1, "■");
            SetPixel(ref grid, p2, "■");
        }

        /// <summary>
        /// Draw in 2D string array - grid vector by Bresenhem algirithm
        /// </summary>
        /// <param name="grid"> Grid - View - place where will be draw vector </param>
        /// <param name="p1"> First point - coordinates: x and y </param>
        /// <param name="p2"> Second point - coordinates: x and y </param>
        /// <param name="emptyCell"> String that will take a role of empty cell in grid </param>
        /// <param name="filledCell"> String that will take a role of filled cell in grid </param>
        /// <param name="startPointsCell"> String that will take a role of start points (p1 & p2) cell in grid </param>
        public void Bresenhem(ref string[,] grid, Point p1, Point p2,
            string emptyCell = cellEmpty, string filledCell = cellFilled, string startPointsCell = cellFilledStart)
        {
            int x1 = p1.X;
            int y1 = p1.Y;

            int x2 = p2.X;
            int y2 = p2.Y;



            if (Math.Abs(x2 - x1) >= Math.Abs(y2 - y1))
            {
                if (x1 > x2)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref y1, ref y2);
                }

                int X = x1;
                int Y = y1;

                int Px = x2 - x1;
                int Py = y2 < y1 ? Math.Abs(y2 - y1) : y2 - y1;
                int E = 2 * Py - Px;

                int l = Px;

                for (int i = 0; i < l; i++)
                {
                    if (E >= 0)
                    {
                        if (y2 < y1 && x1 < x2)
                        {
                            Y--;
                        }
                        else
                        {
                            Y++;
                        }

                        E += 2 * (Py - Px);
                    }
                    else
                    {
                        E += 2 * Py;
                    }

                    X++;

                    SetPixel(ref grid, new Point(X, Y));
                }
            }
            else
            {
                if (y1 > y2)
                {
                    Swap(ref x1, ref x2);
                    Swap(ref y1, ref y2);
                }

                int X = x1;
                int Y = y1;

                int Px = x2 < x1 ? Math.Abs(x2 - x1) : x2 - x1;
                int Py = y2 - y1;
                int E = 2 * Px - Py;

                int l = Py;

                for (int i = 0; i < l; i++)
                {
                    if (E >= 0)
                    {
                        if (x2 < x1 && y1 < y2)
                        {
                            X--;
                        }
                        else
                        {
                            X++;
                        }

                        E += 2 * (Px - Py);
                    }
                    else
                    {
                        E += 2 * Px;
                    }

                    Y++;

                    SetPixel(ref grid, new Point(X, Y));
                }
            }

            SetPixel(ref grid, p1, "■");
            SetPixel(ref grid, p2, "■");

        }


        /// <summary>
        /// Converter taht copy data from array to DataGridView
        /// </summary>
        /// <param name="grid"> DataGridView that need to be filled </param>
        /// <param name="array"> Array (string) that data will be taken from </param>
        public void Array2D2DataGridView(ref DataGridView grid, string[,] array)
        {
            grid.ColumnCount = array.GetLength(0) - 1;
            grid.RowCount = array.GetLength(1) - 1;

            for (int i = 0; i < grid.ColumnCount; i++)
            {
                for (int j = 0; j < grid.RowCount; j++)
                {
                    grid.Rows[j].Cells[i].Value = array[i, j];
                }
            }
        }


        public void ChangeBackground(ref DataGridView grid)
        {
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                for (int j = 0; j < grid.RowCount; j++)
                {
                    if (grid.Rows[j].Cells[i].Value.Equals(cellEmpty))
                    {
                        grid.Rows[j].Cells[i].Style.BackColor = Color.White;
                    }
                    else if (grid.Rows[j].Cells[i].Value.Equals(cellFilled))
                    {
                        grid.Rows[j].Cells[i].Style.BackColor = Color.DarkGray;
                    }
                    else if (grid.Rows[j].Cells[i].Value.Equals(cellFilledStart))
                    {
                        grid.Rows[j].Cells[i].Style.BackColor = Color.Black;
                    }
                }
            }
        }


        #region Features

        /// <summary>
        /// Hot keys
        /// </summary>
        private void HotKeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                buttonDraw.PerformClick();
            }
        }

        /// <summary>
        /// Chose new first point coordinates
        /// </summary>
        private void MainView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            p1_x.Value = e.ColumnIndex;
            p1_y.Value = e.RowIndex;
        }

        /// <summary>
        /// Chose new second point coordinates
        /// </summary>
        private void MainView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            p2_x.Value = e.ColumnIndex;
            p2_y.Value = e.RowIndex;
        }

        /// <summary>
        /// Chose new first point coordinates
        /// </summary>
        private void MainView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            p1_x.Value = e.ColumnIndex;
            p1_y.Value = e.RowIndex;
        }

        /// <summary>
        /// Chose new second point coordinates
        /// </summary>
        private void MainView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            p2_x.Value = e.ColumnIndex;
            p2_y.Value = e.RowIndex;
        }

        /// <summary>
        /// Swap two double values between each other
        /// </summary>
        public void Swap(ref double item1, ref double item2)
        {
            double buffer = item1;
            item1 = item2;
            item2 = buffer;
        }

        /// <summary>
        /// Swap two int values between each other
        /// </summary>
        public void Swap(ref int item1, ref int item2)
        {
            int buffer = item1;
            item1 = item2;
            item2 = buffer;
        }

        #endregion


    }
}
