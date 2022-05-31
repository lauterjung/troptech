namespace MiguelBusarelloLauterjungM2P1
{
    public static class AcoesDoSistema
    {
        private static string _userInput = "";
        private static Fila _fila = new Fila();

        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("===================");
            Console.WriteLine("1) Entrar na fila");
            Console.WriteLine("2) Remover da fila");
            Console.WriteLine("3) Ver quem está na vez");
            Console.WriteLine("4) Checar item");
            Console.WriteLine("5) Limpar");
            Console.WriteLine("6) Sair");
            Console.WriteLine("===================\n");
        }
        public static void PedirInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }
        public static void RealizarEscolha(Fila _fila)
        {
            switch (_userInput)
            {
                case "1":
                    Enfileirar(_fila);
                    break;
                case "2":
                    Desenfileirar(_fila);
                    break;
                case "3":
                    VerPrimeiro(_fila);
                    break;
                case "4":
                    Verificar(_fila);
                    break;
                case "5":
                    Limpar(_fila);
                    break;
                case "6":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Não entendi a operação. Pressione enter para continuar...");
                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }
        public static void Enfileirar(Fila _fila)
        {
            Console.Write("Digite o item a ser inserido na fila: ");
            string valorDigitado = Console.ReadLine();

            if (valorDigitado == string.Empty)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor inválido, tente novamente.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            _fila.Enfileirar(Convert.ToInt32(valorDigitado));
            Console.WriteLine($"Existem {_fila.Quantidade} itens na fila.");
        }

        public static void Desenfileirar(Fila _fila)
        {
            if (_fila.Quantidade == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("A fila está vazia, não há itens para desenfileirar.");
                Console.ForegroundColor = ConsoleColor.White;

                return;
            }

            int item = _fila.Desenfileirar();
            Console.WriteLine($"O item desenfileirado é: {item}");
            Console.WriteLine($"Existem {_fila.Quantidade} itens na fila.");
        }

        public static void VerPrimeiro(Fila _fila)
        {
            if (_fila.Quantidade == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("A fila está vazia.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.WriteLine($"{_fila.Primeiro}");
        }

        public static void Limpar(Fila _fila)
        {
            _fila.Limpar();
            Console.WriteLine($"Existem {_fila.Quantidade} itens na fila.");
        }

        public static void Verificar(Fila _fila)
        {
            Console.Write("Digite o item para verificar se existe na fila: ");
            int valorDigitado = Convert.ToInt32(Console.ReadLine());
            bool existe = _fila.Verificar(valorDigitado);

            if (existe)
            {
                Console.WriteLine($"O valor '{valorDigitado}' existe na fila.");
                return;
            }

            Console.WriteLine($"O valor '{valorDigitado}' não existe na fila.");
        }

        public static void RodarPrograma()
        {
            while (true)
            {
                ChamarMenu();
                PedirInput();
                RealizarEscolha(_fila);
            }
        }
    }
}
