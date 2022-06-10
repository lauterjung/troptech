namespace A12E2
{
    public class BuscadorContemG : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            return palavra.ToLower().Contains("g") ? true : false;
        }
    }
}