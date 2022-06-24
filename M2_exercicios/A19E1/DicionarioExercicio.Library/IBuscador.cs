namespace DicionarioExercicio.Library
{
    public interface IBuscador
    {
        // Avalia se a palavra passada por parâmetro atende aos requisitos da busca
         bool AvaliarCriterio(string palavra);
    }
}