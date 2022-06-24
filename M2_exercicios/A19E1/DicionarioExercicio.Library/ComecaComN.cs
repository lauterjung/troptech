namespace DicionarioExercicio.Library
{
    public class ComecaComN : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
             var contemP = palavra.ToLower().StartsWith("n");
            return contemP;
        }
    }
}