namespace MiguelBusarelloLauterjungM2P2
{
    public static class AcoesCliente
    {
        public static List<PessoaFisica> listaFisica = new List<PessoaFisica>();
        public static List<PessoaJuridica> listaJuridica = new List<PessoaJuridica>();

        public static string PerguntarTipoPessoa()
        {
            while (true)
            {
                Console.Clear();
                System.Console.Write("Qual tipo de pessoa deseja cadastrar?\n" +
                                     "[1] Pessoa Física\n" +
                                     "[2] Pessoa Jurídica\n");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    return "F";
                }
                else if (input == "2")
                {
                    return "J";
                }
            }
        }
        public static void CadastrarCliente()
        {
            string tipoCliente = PerguntarTipoPessoa();

            System.Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            System.Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();
            System.Console.Write("Digite a rua: ");
            string rua = Console.ReadLine();
            System.Console.Write("Digite o número: ");
            int numero = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Digite a cidade: ");
            string cidade = Console.ReadLine();
            System.Console.Write("Digite o estado: ");
            string estado = Console.ReadLine();
            System.Console.Write("Digite o país: ");
            string pais = Console.ReadLine();

            Endereco endereco = new Endereco(rua, numero, cidade, estado, pais);
            if (tipoCliente == "F")
            {
                System.Console.Write("Digite o CPF: ");
                string cpf = Console.ReadLine();
                PessoaFisica pessoaFisica = new PessoaFisica(nome, telefone, endereco, cpf);
                listaFisica.Add(pessoaFisica);
            }
            else // tipoCliente == "J"
            {
                System.Console.Write("Digite o CNPJ: ");
                string cnpj = Console.ReadLine();
                PessoaJuridica pessoaJuridica = new PessoaJuridica(nome, telefone, endereco, cnpj);
                listaJuridica.Add(pessoaJuridica);
            }
            System.Console.WriteLine("Cliente cadastrado com sucesso!");
        }
        public static void ExibirClientes(bool isPesquisa = false)
        {
            Console.Clear();
            List<PessoaFisica> pessoasFisicas = new List<PessoaFisica>();
            List<PessoaJuridica> pessoasJuridicas = new List<PessoaJuridica>();

            if (isPesquisa)
            {
                System.Console.Write("Digite o nome do cliente a ser pesquisado: ");
                string nomePesquisado = Console.ReadLine();
                if (!PesquisarClienteFisico(nomePesquisado).Any(x => x.Nome == nomePesquisado) &&
                    !PesquisarClienteJuridico(nomePesquisado).Any(x => x.Nome == nomePesquisado))
                {
                    System.Console.WriteLine("Cliente não existente!");
                    return;
                }

                pessoasFisicas = PesquisarClienteFisico(nomePesquisado);
                pessoasJuridicas = PesquisarClienteJuridico(nomePesquisado);
            }
            else
            {
                pessoasFisicas = listaFisica;
                pessoasJuridicas = listaJuridica;
            }

            if (pessoasFisicas.Count() > 0)
            {
                System.Console.WriteLine("PESSOAS FÍSICAS");
                foreach (PessoaFisica cliente in pessoasFisicas)
                {
                    System.Console.WriteLine("--------------------------");
                    System.Console.WriteLine(cliente.ToString());
                }
            }
            if (pessoasJuridicas.Count() > 0)
            {
                System.Console.WriteLine("==========================");

                System.Console.WriteLine("PESSOAS JURÍDICAS");
                foreach (PessoaJuridica cliente in pessoasJuridicas)
                {
                    System.Console.WriteLine("--------------------------");
                    System.Console.WriteLine(cliente.ToString());
                }
            }
        }
        public static List<PessoaFisica> PesquisarClienteFisico(string nomePesquisado)
        {
            List<PessoaFisica> listaPesquisa = new List<PessoaFisica>();
            foreach (PessoaFisica cliente in listaFisica)
            {
                if (cliente.Nome == nomePesquisado)
                {
                    listaPesquisa.Add(cliente);
                }
            }
            return listaPesquisa;
        }
        public static List<PessoaJuridica> PesquisarClienteJuridico(string nomePesquisado)
        {
            List<PessoaJuridica> listaPesquisa = new List<PessoaJuridica>();
            foreach (PessoaJuridica cliente in listaJuridica)
            {
                if (cliente.Nome == nomePesquisado)
                {
                    listaPesquisa.Add(cliente);
                }
            }
            return listaPesquisa;
        }

        public static void RemoverCliente()
        {
            Console.Clear();
            System.Console.Write("Digite o nome do cliente a ser removido: ");
            string nomePesquisado = Console.ReadLine();

            if (!PesquisarClienteFisico(nomePesquisado).Any(x => x.Nome == nomePesquisado) &&
                !PesquisarClienteJuridico(nomePesquisado).Any(x => x.Nome == nomePesquisado))
            {
                System.Console.WriteLine("Cliente não existente!");
                return;
            }

            foreach (PessoaFisica cliente in PesquisarClienteFisico(nomePesquisado))
            {
                listaFisica.Remove(cliente);
            }
            foreach (PessoaJuridica cliente in PesquisarClienteJuridico(nomePesquisado))
            {
                listaJuridica.Remove(cliente);
            }
            System.Console.WriteLine("Cliente(s) removido(s) com sucesso!");
        }
    }
}

