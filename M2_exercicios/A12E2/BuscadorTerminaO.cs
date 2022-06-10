namespace A12E2
{
    public class BuscadorTerminaO : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            return palavra.ToLower().EndsWith("o") ? true : false;
        }
    }
}