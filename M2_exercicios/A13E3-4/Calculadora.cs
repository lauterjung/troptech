namespace A13E2
{
    public abstract class Calculadora
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract double Compute();
    }
}