using System.Collections.Generic;

namespace SerraAirlines.Domain
{
    public interface IClienteRepository
    {
        public void Atualizar(Cliente cliente);
        public Cliente BuscarPorCpf(string cpf);
        public List<Cliente> BuscarTodos();
        public void Deletar(string cpf);
        public void Registrar(Cliente cliente);
    }
}