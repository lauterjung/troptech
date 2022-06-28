namespace DicionarioExercicio.Library
{
    public class ComecaComA : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
             var contemP = palavra.ToLower().StartsWith("a");
            return contemP;
        }
    }
}