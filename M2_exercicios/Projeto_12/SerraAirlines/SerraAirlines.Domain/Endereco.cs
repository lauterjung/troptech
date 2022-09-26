namespace SerraAirlines.Domain
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        
        #nullable enable
        public string? Complemento { get; set; }

        public Endereco(string cep, string rua, string bairro, int numero, string complemento)
        {
            Cep = cep;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
        }
        
        public Endereco()
        {

        }
    }
}