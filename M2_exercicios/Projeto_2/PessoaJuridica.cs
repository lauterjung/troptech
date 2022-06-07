namespace MiguelBusarelloLauterjungM2P2
{
    public class PessoaJuridica : Cliente
    {
        private string _cnpj;
        public string Cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }

        public PessoaJuridica(string nome, string telefone, Endereco endereco, string cnpj) : base(nome, telefone, endereco)
        {
            base.nome = nome;
            base.telefone = telefone;
            base.endereco = endereco;
            _cnpj = cnpj;
        }

        public override string ToString()
        {
            return ($"Nome: {Nome}\n" +
                    $"Telefone: {Telefone}\n" +
                    $"Endereco: {Endereco.Completo}\n" +
                    $"CNPJ: {Cnpj}");
        }
    }
}