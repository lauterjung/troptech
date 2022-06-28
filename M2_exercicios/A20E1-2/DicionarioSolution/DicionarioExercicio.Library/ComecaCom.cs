namespace DicionarioExercicio.Library
{
    public class ComecaCom : IBuscadorComParametro
    {
        public bool AvaliarCriterio(string palavra, string letras)
        {
             var contemP = palavra.ToLower().StartsWith(letras.ToLower());
            return contemP;
        }
    }
}