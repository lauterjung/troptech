namespace DicionarioExercicio.Library
{
    public class TerminaComAo : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            return palavra.ToLower().EndsWith("ão");
        }
    }
}