namespace MiguelBusarelloLauterjungM2P2
{
    public class Venda
    {
        private Cliente _cliente;
        private string _descricao;
        private decimal _valorTotal;
        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }
        public decimal ValorTotal
        {
            get { return _valorTotal; }
            set { _valorTotal = value; }
        }

        public Venda(Cliente cliente)
        {
            _cliente = cliente;
        }
        public Venda(Cliente cliente, string descricao, decimal valorTotal)
        {
            _cliente = cliente;
            _descricao = descricao;
            _valorTotal = valorTotal;
        }

        public override string ToString()
        {
            return ($"Cliente: {Cliente.Nome}\n" +
                    $"Telefone: {Cliente.Telefone}\n" +
                    $"Descrição: {Descricao}\n" +
                    $"Valor total: {ValorTotal}");
        }
    }
}