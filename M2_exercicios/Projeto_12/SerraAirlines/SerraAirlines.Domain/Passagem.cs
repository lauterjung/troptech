using System;
using SerraAirlines.Domain.Exceptions;

namespace SerraAirlines.Domain
{
    public class Passagem
    {
        public int Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Valor { get; set; }
        public DateTime DataHoraOrigem { get; set; }
        public DateTime DataHoraDestino { get; set; }
        public bool EstaVinculada { get; set; }

        public Passagem(string origem, string destino, double valor, DateTime dataHoraOrigem, DateTime dataHoraDestino)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
            DataHoraOrigem = dataHoraOrigem;
            DataHoraDestino = dataHoraDestino;
            EstaVinculada = false;

            if (VerificarDataValida() == false)
            {
                throw new DataHoraOrigemDestinoInvalida();
            }

            if (VerificarValorValido() == false)
            {
                throw new ValorInvalido();
            }
        }

        public Passagem()
        {

        }

        public bool VerificarDataValida()
        {
            if (DataHoraOrigem < DataHoraDestino)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarValorValido()
        {
            if (Valor > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}