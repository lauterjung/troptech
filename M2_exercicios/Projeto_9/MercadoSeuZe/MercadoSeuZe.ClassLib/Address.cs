using System;

namespace MercadoSeuZe.ClassLib
{
    public struct Address
    {
        public string Street;
        public int HouseNumber;
        public string Borough;
        public string PostalCode;
        public string Complement;

        public Address(string street, int houseNumber, string borough, string postalCode, string complement)
        {
            Street = street;
            HouseNumber = houseNumber;
            Borough = borough;
            PostalCode = postalCode;
            Complement = complement;
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Complement))
            {
                return $"Rua {Street}, nº {HouseNumber}, bairro {Borough}, CEP: {PostalCode}";
            }
            else
            {
                return $"Rua {Street}, nº {HouseNumber}, {Complement}, bairro {Borough}, CEP: {PostalCode}";
            }
        }
    }
}
