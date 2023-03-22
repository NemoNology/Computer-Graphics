namespace WF
{
    internal class Filling
    {
        public enum FillingTypes
        {
            Recursive_Can_Destroy_App,
            CustomSnail_Can_Destroy_App_Not_Completed
        }

        public Filling()
        {
            _fillingAlgorithms.Add(FillingTypes.Recursive_Can_Destroy_App, new FillRecursive());
            _fillingAlgorithms.Add(FillingTypes.CustomSnail_Can_Destroy_App_Not_Completed, new FillCustomSnail());
        }

        private Dictionary<FillingTypes, IFillingAlghoritm> _fillingAlgorithms = new Dictionary<FillingTypes, IFillingAlghoritm>();

        /// <summary>
        /// Fill some contour in inputted Bitmap with inputted Pen <br/> 
        /// Stating filling in inputted Point
        /// </summary>
        /// <param name="bmp"> Bitmap that will have some contour that will be filled </param>
        /// <param name="fillingStart"> Start filling point </param>
        /// <param name="pen"> Pen, that will fill contour </param>
        /// <param name="voidColor"> Color which is empty/background color, that can be filled <br/> That is not a any contour color </param>
        /// <param name="type"> Filling type in <see cref="FillingTypes"/> </param>
        public void Fill(ref Bitmap bmp, Point fillingStart, Color fillColor, FillingTypes type)
        {
            try
            {
                _fillingAlgorithms[type].Fill(ref bmp, fillingStart, fillColor);
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
    }
}
