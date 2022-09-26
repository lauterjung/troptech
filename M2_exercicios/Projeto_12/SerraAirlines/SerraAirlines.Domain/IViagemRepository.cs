using System.Collections.Generic;

namespace SerraAirlines.Domain
{
    public interface IViagemRepository
    {
        public Viagem BuscarPorCodigo(string codigoViagem);
        public List<Viagem> BuscarTodasDeUmCliente(string cpf);
        public void Marcar(Viagem viagem);
        public void Remarcar(Viagem viagem);
    }
}