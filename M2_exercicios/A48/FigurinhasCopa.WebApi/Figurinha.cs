namespace FigurinhasCopa.WebApi
{
    public class Figurinha
    {
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public TipoFigurinha Tipo { get; set; }
        public string Resumo
        {
            get { return $"{Numero} - {Tipo.ToString()}: {Descricao}"; }
        }

        public Figurinha(int numero, string descricao, TipoFigurinha tipo)
        {
            Numero = numero;
            Descricao = descricao;
            Tipo = tipo;
        }
        public Figurinha(int numero, string descricao, int tipo)
        {
            Numero = numero;
            Descricao = descricao;
            Tipo = (TipoFigurinha)tipo;
        }
        public Figurinha()
        {
            
        }
    }
}