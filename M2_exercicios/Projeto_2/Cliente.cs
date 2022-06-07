namespace MiguelBusarelloLauterjungM2P2
{
    public class Cliente
    {
        protected string nome;
        protected string telefone;
        protected Endereco endereco;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Telefone
        {
            get { return telefone; }
            set { telefone = value; }
        }
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }

        public Cliente(string nome, string telefone, Endereco endereco)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.endereco = endereco;
        }
        // public Cliente()
        // {

        // }
    }
}