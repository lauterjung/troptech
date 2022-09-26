using SerraAirlines.Domain;
using SerraAirlines.Domain.Exceptions;
using SerraAirlines.Infra.Data.DAO;

namespace SerraAirlines.Infra.Data
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private EnderecoDAO _enderecoDAO = new EnderecoDAO();

        public void Atualizar(Endereco endereco)
        {
            Endereco enderecoBuscado = _enderecoDAO.BuscarPorId(endereco.Id);

            if (endereco is null)
            {
                throw new EnderecoNaoEncontrado();
            }

            _enderecoDAO.Atualizar(endereco);
        }

        public Endereco BuscarPorId(int id)
        {
            Endereco endereco = _enderecoDAO.BuscarPorId(id);

            if (endereco is null)
            {
                throw new EnderecoNaoEncontrado();
            }

            return endereco;
        }

        public void Deletar(Endereco endereco)
        {
            Endereco enderecoBuscado = _enderecoDAO.BuscarPorId(endereco.Id);

            if (endereco is null)
            {
                throw new EnderecoNaoEncontrado();
            }

            _enderecoDAO.Deletar(endereco);
        }

        public void Registrar(Endereco endereco)
        {
            _enderecoDAO.Registrar(endereco);
        }

        public int RetornarUltimaKey()
        {
            return _enderecoDAO.RetornarUltimaKey();
        }
    }
}