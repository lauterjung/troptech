using System;

namespace A4
{
    class Program
    {
        static void Main(string[] args)
        {
            Pilha pilha = new Pilha();

            while (true)
            {
                AcoesDoSistema.RodarPrograma(pilha);
            }

        }
    }
}
