namespace A12
{
    public class Retangulo : IAreaCalculavel
    {

        public double Lado { get; set; }
        public double Altura { get; set; }
        public Retangulo(double lado, double altura)
        {
            this.Lado = lado;
            this.Altura = altura;

        }

        public double CalcularArea()
        {
            return Lado * Altura;
        }
    }
}