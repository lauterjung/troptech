namespace A11
{
    public class Veiculo
    {
        public enum TipoVeiculo
        {
            CAMINHAO,
            CARRO,
            MOTO
        }

        private string _placa;
        private int _anoDeFabricacao;
        private string _modelo;
        private double _valorDoPedagio;
        public string Placa
        {
            get { return _placa; }
            set { _placa = value; }
        }
        public int AnoDeFabricacao
        {
            get { return _anoDeFabricacao; }
            set { _anoDeFabricacao = value; }
        }
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }
        public double ValorDoPedagio
        {
            get { return _valorDoPedagio; }
            set { _valorDoPedagio = value; }
        }
        public int TempoDeUso
        {
            get { return DateTime.Now.Year - AnoDeFabricacao; }
        }

        public Veiculo(string placa, int anoDeFabricacao, string modelo)
        {
        _placa = placa;
        _anoDeFabricacao = anoDeFabricacao;
        _modelo = modelo;
        }
        public Veiculo()
        {
            
        }
    }
}