namespace A12E2
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
            string[] vetor = { "Futebol", "Voleibol", "Basquetebol", "Natação", "Rugby", "Handebol", "Esgrima", "Melancia", "Laranja", "Abacate", "Banana", "Uva", "Mexerica", "Manga", "Azul", "Branco", "Preto", "Amarelo", "Verde", "Vermelho", "Maria", "Carla", "Paulo", "Fernanda", "Carlos", "Amanda", "Haroldo" };
            _palavras = vetor.ToList<string>();
        }

        public List<string> Buscar(IBuscador buscador)
        {
            List<string> retorno = new List<string>();
            foreach (string item in _palavras)
            {
                if(buscador.AvaliarCriterio(item) == true)
                {
                    retorno.Add(item);
                }
            }
            return retorno;
        }
    }
}