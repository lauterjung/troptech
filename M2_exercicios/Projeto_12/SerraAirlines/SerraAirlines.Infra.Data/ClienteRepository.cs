using System.Collections.Generic;
using SerraAirlines.Domain;
using SerraAirlines.Domain.Exceptions;
using SerraAirlines.Infra.Data.DAO;

namespace SerraAirlines.Infra.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private ClienteDAO _clienteDAO = new ClienteDAO();
        private EnderecoDAO _enderecoDAO = new EnderecoDAO();

        public void Atualizar(Cliente cliente)
        {
            Cliente clienteBuscado = _clienteDAO.BuscarPorCpf(cliente.Cpf);

            if (clienteBuscado is null)
            {
                throw new ClienteNaoEncontrado();
            }
            cliente.Endereco.Id = clienteBuscado.Endereco.Id;
            _clienteDAO.Atualizar(cliente);
            _enderecoDAO.Atualizar(cliente.Endereco);
        }

        public Cliente BuscarPorCpf(string cpf)
        {
            Cliente cliente = _clienteDAO.BuscarPorCpf(cpf);

            if (cliente is null)
            {
                throw new ClienteNaoEncontrado();
            }

            return cliente;
        }

        public List<Cliente> BuscarTodos()
        {
            List<Cliente> listaClientes = _clienteDAO.BuscarTodos();

            if (listaClientes.Count == 0)
            {
                throw new NenhumClienteRegistrado();
            }

            return listaClientes;
        }

        public void Deletar(string cpf)
        {
            Cliente clienteBuscado = _clienteDAO.BuscarPorCpf(cpf);

            if (clienteBuscado is null)
            {
                throw new ClienteNaoEncontrado();
            }
            _clienteDAO.Deletar(clienteBuscado);
            _enderecoDAO.Deletar(clienteBuscado.Endereco);
        }

        public void Registrar(Cliente cliente)
        {
            Cliente clienteBuscado = _clienteDAO.BuscarPorCpf(cliente.Cpf);

            if (clienteBuscado != null)
            {
                throw new ClienteJaExistente();
            }

            _enderecoDAO.Registrar(cliente.Endereco);
            int key = _enderecoDAO.RetornarUltimaKey();
            cliente.Endereco.Id = key;

            _clienteDAO.Registrar(cliente);
        }
    }
}