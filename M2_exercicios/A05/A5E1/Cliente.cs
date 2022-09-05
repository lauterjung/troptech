namespace A5
{
    public class Cliente
    {
        private string _nome;
        private int _idade;
        private Endereco _enderecoPessoal;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }
        public Endereco EnderecoPessoal
        {
            get { return _enderecoPessoal; }
        }
        
        
        public Cliente(string nome, int idade, Endereco enderecoPessoal)
        {
            _nome = nome;
            _idade = idade;
            _enderecoPessoal = enderecoPessoal;
        }
        public Cliente()
        {
            
        }
    }
}