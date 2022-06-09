namespace A11
{
    public static class AcoesDoSistema
    {
        private static List<Veiculo> listaVeiculos = new List<Veiculo>();
        private static string _userInput;

        public static void CadastrarVeiculo()
        {
            while (true)
            {
                System.Console.Write("Digite a placa: ");
                string placa = Console.ReadLine();
                if (placa.ToLower() == "encerrar")
                {
                    System.Console.WriteLine("Cadastro encerrado. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }
                System.Console.WriteLine("Qual o tipo do veículo?");
                System.Console.WriteLine("1 - Caminhão");
                System.Console.WriteLine("2 - Carro");
                System.Console.WriteLine("3 - Moto");
                Veiculo.TipoVeiculo tipoVeiculo =
                    (Veiculo.TipoVeiculo)(Convert.ToInt32(Console.ReadLine()) - 1);

                System.Console.Write("Digite o ano de fabricação: ");
                int anoDeFabricacao = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Digite o modelo: ");
                string modelo = Console.ReadLine();

                switch (tipoVeiculo)
                {
                    case Veiculo.TipoVeiculo.CAMINHAO:
                        System.Console.Write("Digite o peso total (kg): ");
                        double pesoTotal = Convert.ToDouble(Console.ReadLine());
                        System.Console.Write("Digite o valor da carga (R$): ");
                        double valorDaCarga = Convert.ToDouble(Console.ReadLine());
                        Caminhao caminhao = new Caminhao(placa, anoDeFabricacao, modelo, pesoTotal, valorDaCarga);
                        listaVeiculos.Add(caminhao);
                        break;
                    case Veiculo.TipoVeiculo.CARRO:
                        System.Console.Write("Digite o número de passageiors: ");
                        int qtdPassageiros = Convert.ToInt32(Console.ReadLine());
                        Carro carro = new Carro(placa, anoDeFabricacao, modelo, qtdPassageiros);
                        listaVeiculos.Add(carro);
                        break;
                    case Veiculo.TipoVeiculo.MOTO:
                        System.Console.Write("Digite o número de cilindradas: ");
                        int qtdCilindradas = Convert.ToInt32(Console.ReadLine());
                        Moto moto = new Moto(placa, anoDeFabricacao, modelo, qtdCilindradas);
                        listaVeiculos.Add(moto);
                        break;
                    default:
                        System.Console.WriteLine("Tipo de veículo não existente. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

                System.Console.WriteLine("Veículo cadastrado com sucesso!");
            }

        }
        private static void ExibirVeiculos()
        {
            foreach (Veiculo veiculo in listaVeiculos)
            {
                System.Console.WriteLine(veiculo.ToString());
            }
        }
        public static void RodarPrograma()
        {
            System.Console.WriteLine("$$$ Pedágio Troptech $$$");
            System.Console.WriteLine("Cadastro iniciado.");
            System.Console.WriteLine("Digite 'encerrar' no valor da placa para finalizar");

            CadastrarVeiculo();
            ExibirVeiculos();
            Console.ReadLine();
        }


    }
}