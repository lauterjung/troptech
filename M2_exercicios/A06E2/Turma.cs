namespace A6
{
    public class Turma
    {
        string _nome;
        private List<Aluno> _listaAlunos = new List<Aluno>();
        
        public List<Aluno> ListaAlunos
        {
            get { return _listaAlunos; }
        }
        
        public Turma(string nome)
        {

        }
        public Turma()
        {

        }
        
        public void AdicionarAluno(Aluno aluno)
        {
            _listaAlunos.Add(aluno);
        }
        public double CalcularMedia()
        {
            int count = 0;
            double soma = 0;
            foreach(Aluno element in _listaAlunos)
            {
                soma = soma + element.NotaDaProva;
                count++;
            }
            return(soma/count);
        }
    }
}