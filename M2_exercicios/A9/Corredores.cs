namespace A9
{
    public class Corredores : Atleta
    {
        private double _tempoProva;
        public double TempoProva
        {
            get { return _tempoProva; }
            set { _tempoProva = value; }
        }
        public Corredores(Ficha ficha, string nome, string sobrenome, double tempoProva) : base(ficha, nome, sobrenome)
        {
            _tempoProva = tempoProva;
        }
        public Corredores()
        {

        }
        public override string ToString()
        {
            return $"“---------------------------------”\n" +
                   $"{NomeCompleto.ToUpper()}\n" +
                   $"{Ficha.Numero}\n" +
                   $"{Ficha.Pais}\n" +
                   $"“---------------------------------”\n" +
                   "\n" +
                   $"Resultado: {TempoProva} segundos.\n";
        }
    }
}