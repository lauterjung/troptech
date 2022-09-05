namespace A5
{
    public class Professor
    {
        private string _nome;
        private string _materia;
        private string _cpf;
        private Endereco _enderecoPessoal;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Materia
        {
            get { return _materia; }
            set { _materia = value; }
        }
        public string cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        public Endereco EnderecoPessoal
        {
            get { return _enderecoPessoal; }
        }

        public Professor(string nome, string materia, string cpf, Endereco enderecoPessoal)
        {
            _nome = nome;
            _materia = materia;
            _cpf = cpf;
            _enderecoPessoal = enderecoPessoal;
        }
        public Professor()
        {

        }

        public void Imprimir()
        {
            Console.WriteLine($"{Nome} - {Materia} - {_enderecoPessoal.Cep}");
        }
    }
}