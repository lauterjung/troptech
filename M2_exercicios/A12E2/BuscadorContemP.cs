namespace A12E2
{
    public class BuscadorContemP : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            return palavra.ToLower().Contains("p") ? true : false;
        }
    }
}