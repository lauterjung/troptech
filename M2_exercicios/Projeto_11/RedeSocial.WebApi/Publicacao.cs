using System;

namespace RedeSocial.WebApi
{
    public class Publicacao
    {
        public int IdPublicacao { get; set; }
        public string Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public string Usuario { get; set; }
        public int Curtidas { get; set; }

        public Publicacao(int idPublicacao, string titulo, DateTime dataPublicacao, string usuario, int curtidas)
        {
            IdPublicacao = idPublicacao;
            Titulo = titulo;
            DataPublicacao = dataPublicacao;
            Usuario = usuario;
            Curtidas = curtidas;
        }

        public Publicacao()
        {

        }
    }
}
