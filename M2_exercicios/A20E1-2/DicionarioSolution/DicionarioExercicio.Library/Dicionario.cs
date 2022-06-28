using System.Collections.Generic;

namespace DicionarioExercicio.Library
{
    public class Dicionario
    {
        private List<string> _palavras;

        public List<string> Palavras
        {
            get { return _palavras; }
        }

        public Dicionario()
        {
            _palavras = new List<string> { "Futebol", "Voleibol",
                                       "Basquetebol", "Natação", "Rugby", "Handebol", "Esgrima",
                                        "Melancia", "Laranja", "Abacate", "Banana", "Uva", "Mexerica", "Manga",
                                        "Azul","Branco", "Preto", "Amarelo", "Verde","Vermelho",
                                        "Maria","Carla","Paulo","Fernanda","Carlos","Amanda","Haroldo"
                                };
        }

        public List<string> Pesquisar(IBuscador buscador)
        {
            var listaParaRetornar = new List<string>();

            foreach (var palavra in _palavras)
            {
                if (buscador.AvaliarCriterio(palavra))
                {
                    listaParaRetornar.Add(palavra);
                }
            }

            return listaParaRetornar;
        }

        public List<string> Pesquisar(IBuscadorComParametro buscador, string letras)
        {
            var listaParaRetornar = new List<string>();

            foreach (var palavra in _palavras)
            {
                if (buscador.AvaliarCriterio(palavra, letras))
                {
                    listaParaRetornar.Add(palavra);
                }
            }

            return listaParaRetornar;
        }
    }
}