namespace A12E2
{
    public class BuscadorComecaN : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            return palavra.ToLower().StartsWith("n") ? true : false;
        }
    }
}