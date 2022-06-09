namespace A11E2
{
    public static class AcoesDoSistema
    {
        public static List<ItemOrcamento> CadastrarItemOrcamento()
        {
            List<ItemOrcamento> listaItens = new List<ItemOrcamento>();
            while (true)
            {
                Console.Clear();
                System.Console.Write("Digite o histórico do item: ");
                string historico = Console.ReadLine();
                if (historico.ToLower() == "encerrar")
                {
                    System.Console.WriteLine("Cadastro encerrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return listaItens;
                }

                System.Console.Write("Digite o valor do item (R$): ");
                decimal valor = Convert.ToDecimal(Console.ReadLine());

                ItemOrcamento item = new ItemOrcamento(historico, valor);
                listaItens.Add(item);
                System.Console.WriteLine("Item do orçamento cadastrado com sucesso!");
                Console.ReadLine();
            }
        }
        public static void ImprimirInicio()
        {
            Console.Clear();
            System.Console.WriteLine("$$$ Orçamento Troptech $$$");
            System.Console.WriteLine("Cadastro iniciado.");
            System.Console.WriteLine("Digite 'encerrar' no histórico do item finalizar.");
        }

        public static void Pesquisar(Orcamento orcamento)
        {
            Console.Clear();
            System.Console.WriteLine("Pesquisa iniciada.");
            System.Console.Write("Digite o histórico pesquisado: ");
            string historicoPesquisado = Console.ReadLine();

            if (orcamento.EncontraItem(historicoPesquisado) == null)
            {
                System.Console.WriteLine("Não encontrado.");
            }
            else
            {
                System.Console.WriteLine(orcamento.EncontraItem(historicoPesquisado).ToString());
            }
            Console.ReadLine();
        }
        public static void ExibirItens(Orcamento orcamento)
        {
            foreach (ItemOrcamento item in orcamento.Itens)
            {
                System.Console.WriteLine(item.ToString());
            }
        }
        public static void RodarPrograma()
        {
            ImprimirInicio();
            List<ItemOrcamento> listaOrcamento = CadastrarItemOrcamento();
            Orcamento orcamento = new Orcamento(listaOrcamento); // constante
            Pesquisar(orcamento);
            ExibirItens(orcamento);
        }

    }
}