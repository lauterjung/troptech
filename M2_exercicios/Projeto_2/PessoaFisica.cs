namespace MiguelBusarelloLauterjungM2P2
{
    public class PessoaFisica : Cliente
    {
        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public PessoaFisica(string nome, string telefone, Endereco endereco, string cpf) : base(nome, telefone, endereco)
        {
            base.nome = nome;
            base.telefone = telefone;
            base.endereco = endereco;
            _cpf = cpf;
        }

        public override string ToString()
        {
            return ($"Nome: {Nome}\n" +
                    $"Telefone: {Telefone}\n" +
                    $"Endereco: {Endereco.Completo}\n" +
                    $"CNPJ: {Cpf}");
        }
    }
}