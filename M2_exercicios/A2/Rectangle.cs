namespace A2
{
    public class Rectangle
    {
        private double _rectBase;
        private double _height;

        public double Area
        {
            get
            {
                return _rectBase * _height;
            }
        }

        public Rectangle(double rectBase, double height)
        {
            _rectBase = rectBase;
            _height = height;
        }

    }
}