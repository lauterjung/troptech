using System;
using System.Collections.Generic;

namespace A10E3
{
    class Program
    {
        static void Main(string[] args)
        {
            Email emailDuvida = new EmailDuvida("Miguel", "Duvida");
            Email emailMaterial = new EmailMaterial("Miguel", "Material");

            emailDuvida.Template();
            emailMaterial.Template();
        }
    }
}

