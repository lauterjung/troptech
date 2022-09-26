namespace SerraAirlines.Domain
{
    public interface IEnderecoRepository
    {
        public void Atualizar(Endereco endereco);
        public Endereco BuscarPorId(int id);
        public void Deletar(Endereco endereco);
        public void Registrar(Endereco endereco);
        public int RetornarUltimaKey();
    }
}