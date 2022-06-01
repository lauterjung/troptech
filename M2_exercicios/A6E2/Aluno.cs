namespace A6
{
    public class Aluno
    {
        private string _nome;
        private int _numeroMatricula;
        private int _notaDaProva;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int NumeroMatricula
        {
            get { return _numeroMatricula; }
            set { _numeroMatricula = value; }
        }
        public int NotaDaProva
        {
            get { return _notaDaProva; }
            set { _notaDaProva = value; }
        }

        public Aluno(string nome, int numeroMatricula, int notaDaProva)
        {
            _nome = nome;
            _numeroMatricula = numeroMatricula;
            _notaDaProva = notaDaProva;
        }
        public Aluno()
        {

        }

        public void Imprimir()
        {
            Console.WriteLine($"Nome: {Nome} - Matrícula: {NumeroMatricula} - Nota: {NotaDaProva}");
        }
    }
}