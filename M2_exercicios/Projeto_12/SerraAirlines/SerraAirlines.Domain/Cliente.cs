using SerraAirlines.Domain.Exceptions;

namespace SerraAirlines.Domain
{
    public class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto
        {
            get { return Nome + " " + Sobrenome; }
        }
        public Endereco Endereco { get; set; }

        public Cliente(string cpf, string nome, string sobrenome, Endereco endereco)
        {
            Cpf = cpf;
            Nome = nome;
            Sobrenome = sobrenome;
            Endereco = endereco;
        }

        public Cliente()
        {
            Endereco = new Endereco();
        }

        public Viagem MarcarViagem(Viagem viagem)
        {
            if (viagem.VerificarCodigoValido() == false)
            {
                throw new CodigoInvalido();
            }

            if (viagem.PassagemVolta == null)
            {
                if (viagem.PassagemIda.EstaVinculada == true)
                {
                    throw new PassagemJaVinculada();
                }
            }
            else
            {
                if (viagem.PassagemIda.Id == viagem.PassagemVolta.Id)
                {
                    throw new PassagensRepetidas();
                }

                if (viagem.PassagemIda.EstaVinculada == true || viagem.PassagemVolta.EstaVinculada == true)
                {
                    throw new PassagemJaVinculada();
                }

                viagem.PassagemVolta.EstaVinculada = true;
            }

            viagem.PassagemIda.EstaVinculada = true;
            return viagem;
        }
    }
}


