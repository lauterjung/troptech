namespace A11
{
    public class Carro : Veiculo
    {
        private int _qtdPassageiros;
        public int QtdPassageiros
        {
            get { return _qtdPassageiros; }
            set { _qtdPassageiros = value; }
        }
        public Carro(string placa, int anoDeFabricacao, string modelo, int qtdPassageiros) : base(placa, anoDeFabricacao, modelo)
        {
            _qtdPassageiros = qtdPassageiros;
            ValorDoPedagio = CalcularPedagio();
        }
        private double CalcularPedagio()
        {
            return 10;
        }
        public override string ToString()
        {
            return ($"CARRO\n" +
                    $"Modelo: {Modelo}\n" +
                    $"Placa: {Placa}\n" +
                    $"Ano de fabricação: {AnoDeFabricacao}\n" +
                    $"Tempo de uso: {TempoDeUso} anos\n" +
                    $"Número de passageiros: {QtdPassageiros} pessoas\n" + 
                    $"----------------------------------");
        }
    }
}