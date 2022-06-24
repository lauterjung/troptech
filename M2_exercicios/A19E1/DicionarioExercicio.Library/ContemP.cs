namespace DicionarioExercicio.Library
{
    public class ContemP : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
            var contemP = palavra.ToLower().Contains("p");
            return contemP;
        }
    }
}