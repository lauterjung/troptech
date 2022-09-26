using System;
using System.Collections.Generic;

namespace SerraAirlines.Domain
{
    public interface IPassagemRepository
    {
        public void Adicionar(Passagem passagem);
        public void Atualizar(Passagem passagem);
        public List<Passagem> BuscarPorData(DateTime dataHora);
        public List<Passagem> BuscarPorDestino(string destino);
        public Passagem BuscarPorId(int id);
        public List<Passagem> BuscarPorOrigem(string origem);
        public List<Passagem> BuscarTodas();

    }
}