namespace A11
{
    public class Moto : Veiculo
    {
        private int _qtdCilindradas;
        public int QtdCilindradas
        {
            get { return _qtdCilindradas; }
            set { _qtdCilindradas = value; }
        }
        public Moto(string placa, int anoDeFabricacao, string modelo, int qtdCilindradas) : base(placa, anoDeFabricacao, modelo)
        {
            _qtdCilindradas = qtdCilindradas;
            ValorDoPedagio = CalcularPedagio();
        }
        private double CalcularPedagio()
        {
            return 5;
        }
        public override string ToString()
        {
            return ($"MOTO\n" +
                    $"Modelo: {Modelo}\n" +
                    $"Placa: {Placa}\n" +
                    $"Ano de fabricação: {AnoDeFabricacao}\n" +
                    $"Tempo de uso: {TempoDeUso} anos\n" +
                    $"Quantidade de cilindradas: {QtdCilindradas}\n" + 
                    $"----------------------------------");
        }
    }
}