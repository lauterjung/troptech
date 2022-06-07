namespace A9
{
    public class Arremessadores : Atleta
    {
        private List<double> _marcas;
        public List<double> Marcas
        {
            get { return _marcas; }
            set { _marcas = value; }
        }
        public Arremessadores(Ficha ficha, string nome, string sobrenome) : base(ficha, nome, sobrenome)
        {
            List<double> _marcas = new List<double>();
        }
        public Arremessadores()
        {
            List<double> _marcas = new List<double>();
        }
        public void RegistrarMarcas()
        {
            Console.Clear();
            System.Console.WriteLine("Para encerrar a digitação, digite um número negativo.");
            List<double> marcas = new List<double>();

            for (int i = 0; i < 6; i++)
            {
                System.Console.Write($"Digite a marca {i + 1}: ");
                double input = Convert.ToDouble(Console.ReadLine());
                if (input < 0)
                {
                    break;
                }
                marcas.Add(input);
            }
            _marcas = marcas;
        }
        public double VerificarMaiorMarca()
        {
            return _marcas.Max();
        }

        public override string ToString()
        {
            return $"“---------------------------------”\n" +
                   $"{NomeCompleto.ToUpper()}\n" +
                   $"{Ficha.Numero}\n" +
                   $"{Ficha.Pais}\n" +
                   $"“---------------------------------”\n" +
                   "\n" +
                   $"Maior marca: {VerificarMaiorMarca()} metros.\n";
        }
    }
}