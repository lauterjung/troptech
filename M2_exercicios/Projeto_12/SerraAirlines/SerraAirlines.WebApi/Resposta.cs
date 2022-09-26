using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerraAirlines.WebApi
{

    public class Resposta
    {
        public int Status { get; set; }
        public string Mensagem { get; set; }

        public Resposta(int status, string mensagem)
        {
            Status = status;
            Mensagem = mensagem;
        }
    }
}
