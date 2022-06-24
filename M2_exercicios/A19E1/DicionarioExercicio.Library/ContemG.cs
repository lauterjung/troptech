namespace DicionarioExercicio.Library
{
    public class ContemG : IBuscador
    {
        public bool AvaliarCriterio(string palavra)
        {
             var contemG = palavra.ToLower().Contains("g");
            return contemG;
        }
    }
}