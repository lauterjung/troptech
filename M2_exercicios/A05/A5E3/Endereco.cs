namespace A5
{
    public struct Endereco
    {
        public string Cep;
        public int Numero;
        public string Complemento;

        public Endereco(string cep, int numero, string complemento)
        {
            Cep = cep;
            Numero = numero;
            Complemento = complemento;
        }
    }
}