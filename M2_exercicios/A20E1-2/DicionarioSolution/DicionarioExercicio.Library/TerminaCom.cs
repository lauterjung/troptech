namespace DicionarioExercicio.Library
{
    public class TerminaCom : IBuscadorComParametro
    {
        public bool AvaliarCriterio(string palavra, string letras)
        {
            return palavra.ToLower().EndsWith(letras.ToLower());
        }
    }
}