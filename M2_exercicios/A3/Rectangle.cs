namespace A3
{
    public class Rectangle
    {
        private int _height;
        private int _rectBase;

        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = (int)value;
            }

        }
        public double Base
        {
            get
            {
                return _rectBase;
            }
            set
            {
                _rectBase = (int)value;
            }
        }

        public Rectangle()
        {

        }
        public Rectangle(int rectBase, int height)
        {
            _rectBase = rectBase;
            _height = height;
        }


        public void CalculateArea()
        {
            Console.WriteLine(_rectBase * _height);
        }

    }
}