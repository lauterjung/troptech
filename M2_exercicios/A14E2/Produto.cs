namespace A14E2
{
    public class Produto
    {
        private int _codigo;
        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private double _preco;
        public double Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
        private DateTime _validade;
        public DateTime Validade
        {
            get { return _validade; }
            set { _validade = value; }
        }

        public Produto()
        {
            Validade = new DateTime();
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                Console.WriteLine("Nome do produto é obrigatório!");
                return false;
            }
            if (Codigo <= 0)
            {
                Console.WriteLine("Código não pode ser menor ou igual a 0!");
                return false;
            }
            if (Preco <= 0)
            {
                Console.WriteLine("Preço não pode ser menor ou igual a 0!");
                return false;
            }
            if (DateTime.Now > Validade)
            {
                Console.WriteLine("A data de validade precisa ser superior a data de hoje!");
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return ($"Código produto: {Codigo}\n" +
                    $"Produto: {Nome}\n" +
                    $"Preco: {Preco}\n" +
                    $"Validade: {Validade.ToShortDateString()}");
        }
    }
}