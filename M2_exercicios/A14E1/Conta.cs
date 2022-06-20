namespace A14
{
    public class Conta
    {
        public enum Tipo
        {
            POUPANCA = 1228,
            CORRENTE = 001,
            INVESTIMENTO = 009
        }

        private int _agencia;
        public int Agencia
        {
            get { return _agencia; }
            set { _agencia = value; }
        }
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }


        private Tipo _tipoConta;
        public Tipo TipoConta
        {
            get { return _tipoConta; }
            set { _tipoConta = value; }
        }

        public Conta()
        {

        }

        public bool Validate()
        {
            if (Agencia <= 0)
            {
                Console.WriteLine("Agencia não pode ser vazia!");
                return false;
            }
            if (Numero <= 0)
            {
                Console.WriteLine("Numero não pode ser vazio!");
                return false;
            }
            if (!Enum.IsDefined(typeof(Tipo), TipoConta))
            {
                Console.WriteLine("Tipo de conta inválido!");
                return false;
            }
            if (string.IsNullOrEmpty(Nome))
            {
                Console.WriteLine("O campo nome está vazio!");
                return false;
            }
            if (string.IsNullOrEmpty(Cpf))
            {
                Console.WriteLine("O campo CPF está vazio!");
                return false;
            }
            if (Cpf.Length != 11)
            {
                Console.WriteLine("O CPF digitado é inválido!");
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return ($"Agencia: {Agencia}\n" +
                    $"Número: {Numero}\n" +
                    $"Tipo Conta: {TipoConta}\n" + 
                    $"Cliente: {Nome} \n" +
                    $"CPF: {Cpf}");
        }
    }
}