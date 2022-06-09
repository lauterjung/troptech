namespace A11E2
{
    public class ItemOrcamento
    {
        private string _historico;
        private decimal _valor;

        public ItemOrcamento(string historico, decimal valor)
        {
            _historico = historico;
            _valor = valor;
        }

        public string GetHistorico()
        {
            return _historico;
        }
        public decimal GetValor()
        {
            return _valor;
        }
        public override string ToString()
        {
            return ($"Histórico: {GetHistorico()}\n" + 
                    $"Valor: {GetValor()}\n" + 
                    $"--------------------");
        }
    }
}