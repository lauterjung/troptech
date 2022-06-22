namespace ControlePonto.ClassLibs
{
    public class Ponto
    {
        public enum TipoPonto
        {
            Entrada,
            Saida
        }
        public DateTime Data { get; set; }
        public string Hora { get; set; }
        public TipoPonto Tipo { get; set; }
        public Funcionario Funcionario { get; set; }

        public bool Validar()
        {
            if (Data == null)
            {
                throw new PontoException("Data é obrigatória!");
                return false;
            }
            if (Hora == null)
            {
                throw new PontoException("Hora é obrigatória!");
                return false;
            }
            if (!Enum.IsDefined(typeof(TipoPonto), Tipo))
            {
                throw new PontoException("Tipo de ponto inválido!");
                return false;
            }
            if (Funcionario == null)
            {
                throw new PontoException("Funcionário é obrigatório!");
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return $"Data: {Data}\n" +
                   $"Hora: {Hora}\n" +
                   $"Tipo: {Tipo}\n" +
                   $"Funcionario: {Funcionario.Nome}\n";
        }
    }
}
