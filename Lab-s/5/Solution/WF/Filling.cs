namespace WF
{
    internal class Filling
    {
        public enum FillingTypes
        {
            Recursive_Can_eat_almost_all_Stack,
            FillWithLines,
            FillQueue,
            FillStack
        }

        public Filling()
        {
            _fillingAlgorithms.Add(FillingTypes.Recursive_Can_eat_almost_all_Stack, new FillRecursive());
            _fillingAlgorithms.Add(FillingTypes.FillWithLines, new FillLine());
            _fillingAlgorithms.Add(FillingTypes.FillQueue, new FillQueue());
            _fillingAlgorithms.Add(FillingTypes.FillStack, new FillStack());
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
            _fillingAlgorithms[type].Fill(ref bmp, fillingStart, fillColor);
        }
    }
}
