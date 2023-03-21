namespace WF
{
    internal interface IFillingAlghoritm
    {
        public void Fill(ref Bitmap bmp, Point startFillPoint, Color fillColor, Color voidColor);
    }
}
