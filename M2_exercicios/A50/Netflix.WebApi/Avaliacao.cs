using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebApi
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public double Nota { get; set; }
        public string Descricao { get; set; }
        public string NomeUsuario { get; set; }

        public Avaliacao(int id, double nota, string descricao, string nomeUsuario)
        {
            Id = id;
            Nota = nota;
            Descricao = descricao;
            NomeUsuario = nomeUsuario;
        }
        
        public Avaliacao()
        {

        }
    }
}