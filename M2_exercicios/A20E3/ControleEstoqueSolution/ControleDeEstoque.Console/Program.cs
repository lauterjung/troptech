using ControleEstoque;
using System;

namespace ControleDeEstoque.Console
{
    internal class Program
    {
        private static Estoque _estoque;

        static void Main(string[] args)
        {
            _estoque = new Estoque();

            while (true)
            {
                var opcaoEscolhida = MenuPrincipal();

                switch (opcaoEscolhida)
                {
                    case "0":
                        CadastrarNovoProduto();
                        break;
                    case "1":
                        EntradaDeProduto();
                        break;
                    case "2":
                        SaidaDeProduto();
                        break;
                    case "3":
                        Relatorio();
                        break;

                }

            }
        }

        private static string MenuPrincipal()
        {
            System.Console.Clear();

            string header = "=========== Bem-Vindo ao sistema Controle de Estoque ===========";
            string opcao0 = "[0] Cadastrar produtos em estoque";
            string opcao1 = "[1] Entrada de produtos no estoque";
            string opcao2 = "[2] Saída de produtos no estoque";
            string opcao3 = "[3] Obter relatório de inventário";

            System.Console.WriteLine($"{header}\n\n{opcao0}\n{opcao1}\n{opcao2}\n{opcao3}\n");

            var opcaoEscolhida = System.Console.ReadLine();

            if (opcaoEscolhida != "0"
                && opcaoEscolhida != "1"
                && opcaoEscolhida != "2"
                && opcaoEscolhida != "3")
            {
                System.Console.WriteLine("Opção Inválida.\nClique em qualquer tecla para continuar");
                System.Console.ReadKey();

                return MenuPrincipal();
            }

            return opcaoEscolhida;
        }

        private static void CadastrarNovoProduto()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== CADASTRO DE PRODUTO ===========");

            System.Console.Write("NOME: ");
            var nome = System.Console.ReadLine();

            System.Console.Write("DESCRICAO: ");
            var descricao = System.Console.ReadLine();

            MostrarBarraCarregamento();

            try
            {
                var produto = _estoque.CadastrarProdutoNoEstoque(nome, descricao);

                System.Console.WriteLine("Produto cadastrado com sucesso!");
                System.Console.WriteLine("Gostaria de cadastrar outro? [S/n]");

                var opcaoEscolhida = System.Console.ReadLine();
                if (opcaoEscolhida == "S")
                {
                    CadastrarNovoProduto();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");

                System.Console.ReadKey();
                CadastrarNovoProduto();
                return;

            }
        }

        private static void EntradaDeProduto()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== ENTRADA DE PRODUTO ===========");
            
            if(!_estoque.HaProdutosEmEstoque())
            {
                System.Console.WriteLine("\nNão há nenhum produto no estoque. Por favor, cadastre antes e tente novamente.\n");
                System.Console.WriteLine("\nClique em qualquer tecla para voltar ao menu.");
                System.Console.ReadKey();

                return;
            }

            System.Console.WriteLine("\nLISTA DE PRODUTOS\n");
            System.Console.WriteLine(_estoque.RelatorioInventario());

            System.Console.Write("\nCódigo do produto que gostaria de dar entrada: ");

            var converteuCodigo = int.TryParse(System.Console.ReadLine(), out int codigoProduto);

            if (!converteuCodigo)
            {
                System.Console.WriteLine("Você digitou um código de produto inválido, tente novamente.");
                System.Console.ReadKey();
                EntradaDeProduto();
                return;
            }

            System.Console.Write("\nQuantidade: ");
            var converteuQtd = int.TryParse(System.Console.ReadLine(), out int qtdProduto);
            if (!converteuQtd)
            {
                System.Console.WriteLine("Você digitou uma quantidade de produto inválido, tente novamente.");
                System.Console.ReadKey();
                EntradaDeProduto();
                return;
            }

            MostrarBarraCarregamento();

            try
            {

                var produto = _estoque.RegistrarEntradaDeProduto(codigoProduto, qtdProduto);

                System.Console.WriteLine("Entrada realizada com sucesso.");
                System.Console.WriteLine(produto);

                System.Console.WriteLine("\nGostaria de dar entrada em outro? [S/n]");

                var opcaoEscolhida = System.Console.ReadLine();
                if (opcaoEscolhida == "S")
                {
                    EntradaDeProduto();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                System.Console.ReadKey();

                EntradaDeProduto();
                return;
            }

        }

        private static void SaidaDeProduto()
        {
            System.Console.Clear();
            System.Console.WriteLine("=========== SAÍDA DE PRODUTO ===========");

            if (!_estoque.HaProdutosEmEstoque())
            {
                System.Console.WriteLine("\nNão há nenhum produto no estoque. Por favor, cadastre antes e tente novamente.\n");
                System.Console.WriteLine("\nClique em qualquer tecla para voltar ao menu.");
                System.Console.ReadKey();

                return;
            }

            System.Console.WriteLine("\nLISTA DE PRODUTOS\n");
            System.Console.WriteLine(_estoque.RelatorioInventario());

            System.Console.Write("\nCódigo do produto que gostaria de dar saída: ");

            var converteuCodigo = int.TryParse(System.Console.ReadLine(), out int codigoProduto);

            if (!converteuCodigo)
            {
                System.Console.WriteLine("Você digitou um código de produto inválido, tente novamente.");
                System.Console.ReadKey();
                SaidaDeProduto();
                return;
            }

            System.Console.Write("\nQuantidade: ");
            var converteuQtd = int.TryParse(System.Console.ReadLine(), out int qtdProduto);
            if (!converteuQtd)
            {
                System.Console.WriteLine("Você digitou uma quantidade de produto inválido, tente novamente.");
                System.Console.ReadKey();
                SaidaDeProduto();
                return;
            }

            MostrarBarraCarregamento();

            try
            {
                var produto = _estoque.RegistrarSaidaDeProduto(codigoProduto, qtdProduto);

                System.Console.WriteLine("Entrada realizada com sucesso.");
                System.Console.WriteLine(produto);

                System.Console.WriteLine("\nGostaria de dar saída em outro? [S/n]");

                var opcaoEscolhida = System.Console.ReadLine();
                if (opcaoEscolhida == "S")
                {
                    SaidaDeProduto();
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ocorreu um erro:");
                System.Console.WriteLine(ex.Message);

                System.Console.WriteLine("\nClique em qualquer tecla para tentar novamente.");
                System.Console.ReadKey();

                SaidaDeProduto();
                return;
            }

        }
        
        private static void Relatorio()
        {
            System.Console.WriteLine("=========== RELATÓRIO DE PRODUTOS ===========");

            System.Console.WriteLine("\nLISTA DE PRODUTOS\n");
            System.Console.WriteLine(_estoque.RelatorioInventario());
            System.Console.ReadKey();
        }

        private static void MostrarBarraCarregamento()
        {
            for (int i = 0; i < 1; i++)
            {
                System.Console.Clear();
                System.Console.Write("Por favor, aguarde");

                for (int y = 0; y < 3; y++)
                {
                    System.Threading.Thread.Sleep(300);
                    System.Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
            }

            System.Console.Clear();
        }
    }
}
