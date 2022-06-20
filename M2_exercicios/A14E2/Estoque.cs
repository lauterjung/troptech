namespace A14E2
{
    public class Estoque
    {
        private string _Estabelecimento;
        public string Estabelecimento
        {
            get { return _Estabelecimento; }
            set { _Estabelecimento = value; }
        }
        private string _gerente;
        public string Gerente
        {
            get { return _gerente; }
            set { _gerente = value; }
        }
        private List<Produto> _listaProdutos;
        public List<Produto> ListaProdutos
        {
            get { return _listaProdutos; }
            set { _listaProdutos = value; }
        }
        
        public int QtdProdutos
        {
            get { return ListaProdutos.Count; }
        }

        public Estoque()
        {
            ListaProdutos = new List<Produto>();
        }

        public bool VerificarProduto(Produto produto)
        {
            foreach (var item in ListaProdutos)
            {
                if (item.Codigo == produto.Codigo)
                {
                    Console.WriteLine("Código de produto já existe!");
                    return false;
                }
            }
            return true;
        }
        public void AdicionarProduto(Produto produto)
        {
            ListaProdutos.Add(produto);
        }

        public string ListarProdutos()
        {
            foreach (Produto item in ListaProdutos)
            {
                return item.ToString();
            }
            return "";
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Estabelecimento))
            {
                Console.WriteLine("Nome do estabelecimento é obrigatório!");
                return false;
            }
            if (string.IsNullOrEmpty(Gerente))
            {
                Console.WriteLine("Nome do gerente é obrigatório!");
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return ($" Nome do estabelecimento: {Estabelecimento}\n" +
                    $" Gerente: {Gerente}\n" +
                    $" Quantidade de produtos: {QtdProdutos}\n" +
                    $" Lista de produtos:\n {ListarProdutos()}");
        }
    }
}