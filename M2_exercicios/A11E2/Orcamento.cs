namespace A11E2
{
    public class Orcamento
    {
        private List<ItemOrcamento> _itens;
        public List<ItemOrcamento> Itens
        {
            get { return _itens; }
        }
        public string Descricao { get; set; }

        public Orcamento(List<ItemOrcamento> itens)
        {
            _itens = itens;
        }

        public decimal GetValor()
        {
            decimal valorTotal = 0;
            foreach (ItemOrcamento item in Itens)
            {
                valorTotal += item.GetValor();
            }
            return valorTotal;
        }
        public ItemOrcamento EncontraItem(string historico)
        {
            foreach (ItemOrcamento item in Itens)
            {
                if (historico == item.GetHistorico())
                {
                    return item;
                }
            }
            return null;
        }

    }
}