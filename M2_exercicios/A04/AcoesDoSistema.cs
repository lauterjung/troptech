namespace A4
{
    public static class AcoesDoSistema
    {
        private static string _userInput;

        public static void ChamarMenu()
        {
            Console.WriteLine("===================");
            Console.WriteLine("1) Empilhar");
            Console.WriteLine("2) Desempilhar");
            Console.WriteLine("3) Ver topo");
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
        public static void RealizarEscolha(Pilha pilha)
        {
            switch (_userInput)
            {
                case "1":
                    pilha.Empilhar();
                    break;
                case "2":
                    pilha.Desempilhar();
                    break;
                case "3":
                    pilha.VerTopo();
                    break;
                case "4":
                    pilha.Verificar();
                    break;
                case "5":
                    pilha.Limpar();
                    break;
                case "6":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Não entendi a operação. Pressione enter para continuar...");
                    Console.ReadKey();
                    break;
            }
        }

        public static void RodarPrograma(Pilha pilha)
        {
            while (true)
            {
                ChamarMenu();
                PedirInput();
                RealizarEscolha(pilha);
            }
        }
    }
}