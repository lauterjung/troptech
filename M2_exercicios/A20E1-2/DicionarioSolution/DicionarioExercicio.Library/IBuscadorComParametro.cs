namespace DicionarioExercicio.Library
{
    public interface IBuscadorComParametro
    {
        // Avalia se a palavra passada por parâmetro atende aos requisitos da busca
         bool AvaliarCriterio(string palavra, string letras);
    }
}