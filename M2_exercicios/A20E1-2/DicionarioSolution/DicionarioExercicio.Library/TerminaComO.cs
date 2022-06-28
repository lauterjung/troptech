namespace DicionarioExercicio.Library
{
    public class TerminaComO : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            return palavra.ToLower().EndsWith("o");
        }
    }
}