using System.Collections.Generic;
using SerraAirlines.Domain;
using SerraAirlines.Domain.Exceptions;
using SerraAirlines.Infra.Data.DAO;

namespace SerraAirlines.Infra.Data
{
    public class ViagemRepository : IViagemRepository
    {
        ViagemDAO _viagemDAO = new ViagemDAO();
        ClienteDAO _clienteDAO = new ClienteDAO();
        PassagemDAO _passagemDAO = new PassagemDAO();

        public Viagem BuscarPorCodigo(string codigoReserva)
        {
            Viagem viagem = _viagemDAO.BuscarPorCodigo(codigoReserva);
            return viagem;
        }

        public List<Viagem> BuscarTodasDeUmCliente(string cpf)
        {
            List<Viagem> listaViagens = _viagemDAO.BuscarTodasDeUmCliente(cpf);

            if (listaViagens.Count == 0)
            {
                throw new NenhumaViagemRegistrada();
            }

            return listaViagens;
        }

        public void Marcar(Viagem viagem)
        {
            Viagem viagemBuscada = BuscarPorCodigo(viagem.CodigoReserva);

            if (viagemBuscada != null)
            {
                throw new ViagemJaExistente();
            }

            Cliente cliente = _clienteDAO.BuscarPorCpf(viagem.Cliente.Cpf);

            if (cliente == null)
            {
                throw new ClienteNaoEncontrado();
            }

            viagem.PassagemIda = _passagemDAO.BuscarPorId(viagem.PassagemIda.Id);
            if (viagem.PassagemIda == null)
            {
                throw new PassagemNaoEncontrada();
            }

            if (viagem.PassagemVolta != null)
            {
                viagem.PassagemVolta = _passagemDAO.BuscarPorId(viagem.PassagemVolta.Id);

                if (viagem.PassagemVolta == null)
                {
                    throw new PassagemNaoEncontrada();
                }
            }

            Viagem viagemMarcada = cliente.MarcarViagem(viagem);

            // como executar o bloco inteiro seguinte (envolvendo sql) de uma vez só?
            _viagemDAO.Marcar(viagemMarcada);
            _passagemDAO.Atualizar(viagemMarcada.PassagemIda);
            if (viagem.PassagemVolta != null)
            {
                _passagemDAO.Atualizar(viagem.PassagemVolta);
            }
        }

        public void Remarcar(Viagem viagemParaRemarcar)
        {
            Viagem viagemExistente = _viagemDAO.BuscarPorCodigo(viagemParaRemarcar.CodigoReserva);

            if (viagemExistente is null)
            {
                throw new PassagemNaoEncontrada();
            }

            Viagem viagemRemarcada = viagemExistente.RemarcarViagem(viagemParaRemarcar);

            // dúvida: Como fazer para o bloco ser executado por completo (atualizar tanto ida como volta de uma única vez, sem falhar pela metade)? Usando try?
            _passagemDAO.Atualizar(viagemRemarcada.PassagemIda);
            if (viagemParaRemarcar.PassagemVolta != null)
            {
                _passagemDAO.Atualizar(viagemRemarcada.PassagemVolta);
            }
        }
    }
}
