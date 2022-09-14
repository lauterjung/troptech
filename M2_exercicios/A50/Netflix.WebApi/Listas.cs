using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebApi
{
    public static class Listas
    {
        public static List<Avaliacao> listaAvaliacaoF1 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoF2 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoF3 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoF4 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoF5 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Filme> listaFilme = new List<Filme>()
        {
            new Filme(1, "Filme1", "Sinopse1", 2001, true, Genero.Ação, listaAvaliacaoF1),
            new Filme(2, "Filme2", "Sinopse2", 2002, false, Genero.Comédia, listaAvaliacaoF2),
            new Filme(3, "Filme3", "Sinopse3", 2003, true, Genero.Documentário, listaAvaliacaoF3),
            new Filme(4, "Filme4", "Sinopse4", 2004, false, Genero.Drama, listaAvaliacaoF4),
            new Filme(5, "Filme5", "Sinopse5", 2005, true, Genero.Ficção, listaAvaliacaoF5),
        };
        
        public static List<Avaliacao> listaAvaliacaoS1 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoS2 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoS3 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoS4 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Avaliacao> listaAvaliacaoS5 = new List<Avaliacao>()
        {
            new Avaliacao(1, 9.0, "Avaliacao1", "Usuario1"),
            new Avaliacao(1, 9.1, "Avaliacao2", "Usuario2"),
            new Avaliacao(1, 9.2, "Avaliacao3", "Usuario3"),
            new Avaliacao(1, 9.3, "Avaliacao4", "Usuario4"),
            new Avaliacao(1, 9.4, "Avaliacao5", "Usuario5"),
        };
        public static List<Serie> listaSerie = new List<Serie>()
        {
            new Serie(1, "Serie1", 1, 2001, true, Genero.Ação, listaAvaliacaoS1),
            new Serie(2, "Serie2", 2, 2002, false, Genero.Comédia, listaAvaliacaoS2),
            new Serie(3, "Serie3", 3, 2003, true, Genero.Documentário, listaAvaliacaoS3),
            new Serie(4, "Serie4", 4, 2004, false, Genero.Drama, listaAvaliacaoS4),
            new Serie(5, "Serie5", 5, 2005, true, Genero.Ficção, listaAvaliacaoS5),
        };
    }
}