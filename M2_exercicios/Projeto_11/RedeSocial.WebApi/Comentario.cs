using System;

namespace RedeSocial.WebApi
{
    public class Comentario
    {
        public int IdComentario { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario { get; set; }
        public string Usuario { get; set; }
        public int Curtidas { get; set; }
        public int IdPublicacao { get; set; }

        public Comentario(int idComentario, string descricao, DateTime dataComentario, string usuario, int curtidas, int idPublicacao)
        {
            IdComentario = idComentario;
            Descricao = descricao;
            DataComentario = dataComentario;
            Usuario = usuario;
            Curtidas = curtidas;
            IdPublicacao = idPublicacao;
        }

        public Comentario()
        {

        }
    }
}
