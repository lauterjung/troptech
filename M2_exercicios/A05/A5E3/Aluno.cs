namespace A5
{
    public class Aluno
    {
        private string _nome;
        private int _idade;
        private string _turma;
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
        public string Turma
        {
            get { return _turma; }
            set { _turma = value; }
        }
        public Endereco EnderecoPessoal
        {
            get { return _enderecoPessoal; }
        }

        public Aluno(string nome, int idade, string turma, Endereco enderecoPessoal)
        {
            _nome = nome;
            _idade = idade;
            _turma = turma;
            _enderecoPessoal = enderecoPessoal;
        }
        public Aluno()
        {

        }

        public void Imprimir()
        {
            Console.WriteLine($"{Nome} - {Turma} - {_enderecoPessoal.Cep}");
        }
    }
}