namespace A15E2
{
    public static class AcoesDoSistema
    {
        private static string _userInput;
        private static List<Participante> listaPessoas = new List<Participante>();
        private static List<Projeto> listaProjetos = new List<Projeto>();
        public static void ChamarMenu()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("[1] Cadastrar Participante");
            Console.WriteLine("[2] Cadastrar Projeto");
            Console.WriteLine("[3] Exibir Participantes");
            Console.WriteLine("[4] Exibir Projetos");
            Console.WriteLine("[0] Sair");
            Console.WriteLine("============================\n");
        }

        public static void PedirInput()
        {
            Console.Write("Digite a opção desejada: ");
            _userInput = Console.ReadLine();
        }

        public static void RealizarEscolha()
        {
            switch (_userInput)
            {
                case "1":
                    CadastrarParticipante();
                    break;
                case "2":
                    CadastrarProjeto();
                    break;
                case "3":
                    ListarParticipantes();
                    break;
                case "4":
                    ListarProjetos();
                    break;
                case "0":
                    Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Operação inválida. Pressione enter para continuar...");
                    break;
            }
            Console.ReadKey();
        }

        public static void CadastrarParticipante()
        {
            Console.Clear();
            Participante participante = new Participante();

            Console.Write("Digite o nome do participante: ");
            participante.Nome = Console.ReadLine();
            Console.Write("Digite a função do participante: ");
            participante.Funcao = Console.ReadLine();

            try
            {
                if (participante.Validar())
                {
                    listaPessoas.Add(participante);
                    System.Console.WriteLine("Cadastro realizado com sucesso!");
                }
            }
            catch (ParticipanteException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void CadastrarProjeto()
        {
            Console.Clear();
            if (listaPessoas.Count >= 1)
            {
                Projeto projeto = new Projeto();

                Console.Write("Digite a descrição do projeto: ");
                projeto.Descricao = Console.ReadLine();
                Console.Write("Digite a Data de Início (dd/mm/yyyy): ");
                projeto.DataInicio = DateTime.Parse(Console.ReadLine());
                Console.Write("Digite a Data Final (dd/mm/yyyy): ");
                projeto.DataFim = DateTime.Parse(Console.ReadLine());

                List<string> listaNomes = new List<string>();
                while (true)
                {
                    Console.Write("Digite o nome do participante (vazio para sair): ");
                    string input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        break;
                    }
                    listaNomes.Add(input);
                }
                projeto.InlcuirParticipante(listaNomes, listaPessoas);

                try
                {
                    if (projeto.Validar())
                    {
                        listaProjetos.Add(projeto);
                        System.Console.WriteLine("Cadastro realizado com sucesso!");
                    }
                }
                catch (ProjetoException e)
                {
                    System.Console.WriteLine(e.Message);
                }
            }
            else
            {
                System.Console.WriteLine("Nenhum participante cadastrado!");
                return;
            }
        }
        public static void ListarParticipantes()
        {
            Console.Clear();
            if (listaPessoas.Count != 0)
            {
                foreach (Participante item in listaPessoas)
                {
                    System.Console.WriteLine(item.ToString());
                    System.Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nenhum participante registrado!");
            }
        }
        public static void ListarProjetos()
        {
            Console.Clear();
            if (listaProjetos.Count != 0)
            {
                foreach (Projeto item in listaProjetos)
                {
                    System.Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("Nenhum projeto registrado!");
            }
        }

        public static void RodarPrograma()
        {
            while (true)
            {
                ChamarMenu();
                PedirInput();
                RealizarEscolha();
            }
        }
    }
}