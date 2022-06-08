using System.Text.RegularExpressions;

namespace A10E2
{
    public class Pessoa
    {
        private string _nome;
        private string _sobrenome;
        private string _nomeCompleto;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Sobrenome
        {
            get { return _sobrenome; }
            set { _sobrenome = value; }
        }
        public string NomeCompleto
        {
            get { return _nomeCompleto; }
            set { _nomeCompleto = value; }
        }

        public Pessoa(string nome, string sobrenome)
        {
            NomeCompleto = nome + " " + sobrenome;
        }
        public Pessoa(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto;
        }

        public static string operator +(Pessoa pessoa, string palavra)
        {
            return pessoa.NomeCompleto + " " + palavra;
        }
        public static string operator -(Pessoa pessoa, string palavra)
        {
            // return String.Replace(pessoa.NomeCompleto, palavra, string.Empty, RegexOptions.IgnoreCase);
            return pessoa.NomeCompleto.Replace(palavra, "").Trim();
        }

        public override bool Equals(object obj)
        {
            var otherName = (Pessoa)obj;
            return Nome == otherName.Nome;
        }
    }
}