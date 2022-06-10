namespace A12
{
    public class Quadrado : IAreaCalculavel
    {
        public double Lado { get; set; }
        public Quadrado(double lado)
        {
            this.Lado = lado;

        }
        public double CalcularArea()
        {
            return Lado * Lado;
        }
    }
}