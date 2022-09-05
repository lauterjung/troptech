namespace A9
{
    public class Atleta
    {
        protected Ficha _ficha;
        protected string _nome;
        protected string _sobrenome;
        protected string _nomeCompleto;
        protected string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        protected string Sobrenome
        {
            get { return _sobrenome; }
            set { _sobrenome = value; }
        }
        public Ficha Ficha
        {
            get { return _ficha; }
            set { _ficha = value; }
        }
        public string NomeCompleto
        {
            get { return _nome + " " + _sobrenome; }
        }

        public Atleta()
        {

        }
        public Atleta(Ficha ficha, string nome, string sobrenome)
        {
            _ficha = ficha;
            _nome = nome;
            _sobrenome = sobrenome;
        }
    }
}