namespace A10E3
{
    public abstract class Email
    {
        protected string Nome { get; private set; }
        protected string Texto { get; private set; }

        protected Email(string nome, string texto)
        {
            Nome = nome;
            Texto = texto;
        }

        public abstract void Template();
    }
}