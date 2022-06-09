namespace A11
{
    public class Caminhao : Veiculo
    {
        private double _pesoTotal;
        private double _valorDaCarga;
        public double PesoTotal
        {
            get { return _pesoTotal; }
            set { _pesoTotal = value; }
        }

        public double ValorDaCarga
        {
            get { return _valorDaCarga; }
            set { _valorDaCarga = value; }
        }

        public Caminhao(string placa, int anoDeFabricacao, string modelo, double pesoTotal, double valorDaCarga) : base(placa, anoDeFabricacao, modelo)
        {
            _pesoTotal = pesoTotal;
            _valorDaCarga = valorDaCarga;
            ValorDoPedagio = CalcularPedagio();
        }

        private double CalcularPedagio()
        {
            return 20;
        }

        public override string ToString()
        {
            return ($"CAMINHÃO\n" +
                    $"Modelo: {Modelo}\n" +
                    $"Placa: {Placa}\n" +
                    $"Ano de fabricação: {AnoDeFabricacao}\n" +
                    $"Tempo de uso: {TempoDeUso} anos\n" +
                    $"Peso total: {PesoTotal} kg\n" +
                    $"Valor da carga: R$ {ValorDaCarga}\n" + 
                    $"----------------------------------");
        }
    }
}