namespace DicionarioExercicio.Library
{
    public class ContemM : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            var contemP = palavra.ToLower().Contains("m");
            return contemP;
        }
    }
}