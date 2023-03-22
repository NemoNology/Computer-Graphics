using System.Runtime.CompilerServices;

namespace WF
{
    internal class FillCustomSnail : IFillingAlghoritm
    {
        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor)
        {
            var voidColor = bmp.GetPixel(startFillPoint.X, startFillPoint.Y);

            if (!IsValidPoint(bmp, startFillPoint, voidColor))
            {
                bmp.SetPixel(startFillPoint.X, startFillPoint.Y, fillColor);
                return;
            }

            bmp.SetPixel(startFillPoint.X, startFillPoint.Y, fillColor);

            Snail snail = new Snail(startFillPoint, fillColor, voidColor);

            snail.GoToStart(bmp);

            while (snail.Move(ref bmp))
            {
                snail.Move(ref bmp);
            }
        }

        private bool IsValidPoint(Bitmap bmp, Point point, Color voidColor)
        {
            if (!RuntimeHelpers.TryEnsureSufficientExecutionStack())
            {
                return false;
            }

            if ((point.X > 0 && point.X < bmp.Width) &&
                (point.Y > 0 && point.Y < bmp.Height) &&
                bmp.GetPixel(point.X, point.Y).ToArgb() == voidColor.ToArgb())
            {
                return true;
            }

            return false;
        }
    }

    public class Snail
    {
        public enum Directions
        {
            Left,
            Right,
            Up,
            Down
        }

        public Point Coordinates { get; set; }
        public Color FillColor { get; set; }
        public Color VoidColor { get; set; }
        public Directions Direction { get; set; }

        private Point _lastRightTurn;

        public Snail(Point coordinates, Color fillColor, Color voidColor, Directions direction = Directions.Left)
        {
            Coordinates = coordinates;
            FillColor = fillColor;
            VoidColor = voidColor;
            Direction = direction;
        }

        public void GoToStart(Bitmap bmp)
        {
            while (IsValidPoint(bmp, Coordinates))
            {
                Coordinates = new Point(Coordinates.X, Coordinates.Y + 1);
            }

            Coordinates = new Point(Coordinates.X, Coordinates.Y - 1);
        }

        public bool Move(ref Bitmap bmp)
        {
            if (CanMoveTo(bmp, Directions.Right))
            {
                _lastRightTurn = Coordinates;
            }

            //Fill(ref bmp);

            bmp.SetPixel(Coordinates.X, Coordinates.Y, FillColor);

            if (CanMoveTo(bmp, Directions.Left))
            {
                Rotate(Directions.Left);
            }
            else if (!CanMoveTo(bmp, Directions.Left) && !CanMoveTo(bmp, Directions.Up))
            {
                Rotate(Directions.Right);
            }
            else if (!CanMoveTo(bmp, Directions.Left) &&
                !CanMoveTo(bmp, Directions.Up) &&
                !CanMoveTo(bmp, Directions.Right))
            {
                Coordinates = _lastRightTurn;
                Direction = Directions.Right;
            }

            MoveForward();

            return IsValidPoint(bmp, Coordinates);
        }

        private bool IsValidPoint(Bitmap bmp, Point point)
        {
            if (!RuntimeHelpers.TryEnsureSufficientExecutionStack())
            {
                return false;
            }

            if ((point.X > 0 && point.X < bmp.Width) &&
                (point.Y > 0 && point.Y < bmp.Height) &&
                bmp.GetPixel(point.X, point.Y).ToArgb() == VoidColor.ToArgb())
            {
                return true;
            }

            return false;
        }

        private bool CanMoveTo(Bitmap bmp, Directions point)
        {
            switch (Direction)
            {
                case Directions.Left:

                    switch (point)
                    {
                        case Directions.Left:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y + 1));

                        case Directions.Right:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y - 1));

                        case Directions.Up:

                            return IsValidPoint(bmp, new Point(Coordinates.X - 1, Coordinates.Y));

                        case Directions.Down:

                            return IsValidPoint(bmp, new Point(Coordinates.X + 1, Coordinates.Y));

                        default:
                            return false;
                    }

                case Directions.Right:

                    switch (point)
                    {
                        case Directions.Left:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y - 1));

                        case Directions.Right:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y + 1));

                        case Directions.Up:

                            return IsValidPoint(bmp, new Point(Coordinates.X + 1, Coordinates.Y));

                        case Directions.Down:

                            return IsValidPoint(bmp, new Point(Coordinates.X - 1, Coordinates.Y));

                        default:
                            return false;
                    }

                case Directions.Up:

                    switch (point)
                    {
                        case Directions.Left:

                            return IsValidPoint(bmp, new Point(Coordinates.X - 1, Coordinates.Y));

                        case Directions.Right:

                            return IsValidPoint(bmp, new Point(Coordinates.X + 1, Coordinates.Y));

                        case Directions.Up:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y - 1));

                        case Directions.Down:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y + 1));

                        default:
                            return false;
                    }

                case Directions.Down:

                    switch (point)
                    {
                        case Directions.Left:

                            return IsValidPoint(bmp, new Point(Coordinates.X + 1, Coordinates.Y));

                        case Directions.Right:

                            return IsValidPoint(bmp, new Point(Coordinates.X - 1, Coordinates.Y));

                        case Directions.Up:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y + 1));

                        case Directions.Down:

                            return IsValidPoint(bmp, new Point(Coordinates.X, Coordinates.Y - 1));

                        default:
                            return false;
                    }

                default:
                    return false;
            }
        }

        private void Rotate(Directions rotateDirection)
        {
            switch (Direction)
            {
                case Directions.Left:

                    switch (rotateDirection)
                    {
                        case Directions.Left:

                            Direction = Directions.Down;
                            return;

                        case Directions.Right:

                            Direction = Directions.Up;
                            return;

                        case Directions.Up:

                            Direction = Directions.Left;
                            return;

                        case Directions.Down:

                            Direction = Directions.Right;
                            return;

                        default:

                            return;
                    }

                case Directions.Right:

                    switch (rotateDirection)
                    {
                        case Directions.Left:

                            Direction = Directions.Up;
                            return;

                        case Directions.Right:

                            Direction = Directions.Down;
                            return;

                        case Directions.Up:

                            Direction = Directions.Right;
                            return;

                        case Directions.Down:

                            Direction = Directions.Left;
                            return;

                        default:

                            return;
                    }

                case Directions.Up:

                    switch (rotateDirection)
                    {
                        case Directions.Left:

                            Direction = Directions.Left;
                            return;

                        case Directions.Right:

                            Direction = Directions.Right;
                            return;

                        case Directions.Up:

                            Direction = Directions.Up;
                            return;

                        case Directions.Down:

                            Direction = Directions.Down;
                            return;

                        default:

                            return;
                    }

                case Directions.Down:

                    switch (rotateDirection)
                    {
                        case Directions.Left:

                            Direction = Directions.Right;
                            return;

                        case Directions.Right:

                            Direction = Directions.Left;
                            return;

                        case Directions.Up:

                            Direction = Directions.Down;
                            return;

                        case Directions.Down:

                            Direction = Directions.Up;
                            return;

                        default:

                            return;
                    }

                default:

                    return;
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Directions.Left:

                    Coordinates = new Point(Coordinates.X - 1, Coordinates.Y);
                    return;

                case Directions.Right:

                    Coordinates = new Point(Coordinates.X + 1, Coordinates.Y);
                    return;

                case Directions.Up:

                    Coordinates = new Point(Coordinates.X, Coordinates.Y - 1);
                    return;

                case Directions.Down:

                    Coordinates = new Point(Coordinates.X, Coordinates.Y + 1);
                    return;

                default:

                    return;
            }
        }

        private void Fill(ref Bitmap bmp)
        {
            if (Direction == Directions.Left)
            {
                var buffer = new Point(Coordinates.X, Coordinates.Y - 1);

                while (IsValidPoint(bmp, buffer))
                {
                    bmp.SetPixel(buffer.X, buffer.Y, FillColor);

                    buffer = new Point(buffer.X, buffer.Y - 1);
                }
            }
            else if (Direction == Directions.Right)
            {
                var buffer = new Point(Coordinates.X, Coordinates.Y + 1);

                while (IsValidPoint(bmp, buffer))
                {
                    bmp.SetPixel(buffer.X, buffer.Y, FillColor);

                    buffer = new Point(buffer.X, buffer.Y + 1);
                }
            }
            else if (Direction == Directions.Up)
            {
                var buffer = new Point(Coordinates.X + 1, Coordinates.Y);

                while (IsValidPoint(bmp, buffer))
                {
                    bmp.SetPixel(buffer.X, buffer.Y, FillColor);

                    buffer = new Point(buffer.X + 1, buffer.Y);
                }
            }
            else
            {
                var buffer = new Point(Coordinates.X - 1, Coordinates.Y);

                while (IsValidPoint(bmp, buffer))
                {
                    bmp.SetPixel(buffer.X, buffer.Y, FillColor);

                    buffer = new Point(buffer.X - 1, buffer.Y);
                }
            }
        }
    }
}
