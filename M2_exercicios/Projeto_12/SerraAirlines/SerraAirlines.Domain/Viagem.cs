using System;
using System.Linq;
using System.Text;
using SerraAirlines.Domain.Enums;
using SerraAirlines.Domain.Exceptions;

namespace SerraAirlines.Domain
{
    public class Viagem
    {
        public string CodigoReserva { get; set; }
        public DateTime DataHoraCompra { get; set; }
        public Cliente Cliente { get; set; }
        public Passagem PassagemIda { get; set; }
#nullable enable
        public Passagem? PassagemVolta { get; set; }
        public double? ValorTotal
        {
            get { return CalcularValorTotal(); }
        }
        public TipoViagem TipoViagem
        {
            get { return VerificarTipoViagem(); }
        }
        public string ResumoViagem
        {
            get { return ResumirViagem(); }
        }

        public Viagem(string codigoReserva, DateTime dataHoraCompra, Cliente cliente, Passagem passagemIda, Passagem? passagemVolta)
        {
            CodigoReserva = codigoReserva;
            DataHoraCompra = dataHoraCompra;
            Cliente = cliente;
            PassagemIda = passagemIda;
            PassagemVolta = passagemVolta;

            if (VerificarCodigoValido() == false)
            {
                throw new CodigoInvalido();
            }

            if (VerificarDataValida() == false)
            {
                throw new DataHoraIdaVoltaInvalida();
            }
        }

        public Viagem()
        {
            Cliente = new Cliente();
            PassagemIda = new Passagem();
        }

        public double? CalcularValorTotal()
        {
            if (PassagemVolta == null)
            {
                return PassagemIda.Valor;
            }
            else
            {
                return PassagemIda.Valor + PassagemVolta.Valor;
            }
        }

        public string ResumirViagem()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Seu voo {(PassagemVolta != null ? "de ida de" : "de")} {PassagemIda.Origem} a {PassagemIda.Destino} será dia {PassagemIda.DataHoraOrigem.ToShortDateString()} as {PassagemIda.DataHoraOrigem.ToShortTimeString()}");

            if (PassagemVolta != null)
            {
                sb.Append($" e seu voo de volta de {PassagemVolta.Origem} a {PassagemVolta.Destino} será dia {PassagemVolta.DataHoraOrigem.ToShortDateString()} as {PassagemVolta.DataHoraOrigem.ToShortTimeString()}");
            }

            return sb.ToString();
        }

        public bool VerificarCodigoValido()
        {
            if (!String.IsNullOrEmpty(CodigoReserva) && CodigoReserva.Length == 6 && CodigoReserva.All(Char.IsLetter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public TipoViagem VerificarTipoViagem()
        {
            if (PassagemVolta == null)
            {
                return (TipoViagem)0;
            }
            else
            {
                return (TipoViagem)1;
            }
        }

        public bool VerificarDataValida()
        {
            if (PassagemVolta != null && PassagemIda.DataHoraDestino > PassagemVolta.DataHoraOrigem)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Viagem RemarcarViagem(Viagem novaViagem)
        {
            Viagem viagemRemarcada = this;

            viagemRemarcada.PassagemIda.DataHoraOrigem = novaViagem.PassagemIda.DataHoraOrigem;
            viagemRemarcada.PassagemIda.DataHoraDestino = novaViagem.PassagemIda.DataHoraDestino;

            if ((viagemRemarcada.PassagemIda != null) != (novaViagem.PassagemIda != null) ||
            (viagemRemarcada.PassagemVolta != null) != (novaViagem.PassagemVolta != null))
            {
                throw new PassagensIncompativeis();
            }

            if (viagemRemarcada.PassagemIda != null && viagemRemarcada.PassagemIda.VerificarDataValida() == false)
            {
                throw new DataHoraOrigemDestinoInvalida();
            }

            if (viagemRemarcada.PassagemVolta != null && novaViagem.PassagemVolta != null)
            {
                viagemRemarcada.PassagemVolta.DataHoraOrigem = novaViagem.PassagemVolta.DataHoraOrigem;
                viagemRemarcada.PassagemVolta.DataHoraDestino = novaViagem.PassagemVolta.DataHoraDestino;

                if (viagemRemarcada.PassagemVolta.VerificarDataValida() == false)
                {
                    throw new DataHoraOrigemDestinoInvalida();
                }
            }

            if (!viagemRemarcada.VerificarDataValida())
            {
                throw new DataHoraIdaVoltaInvalida();
            }

            return viagemRemarcada;
        }
    }
}