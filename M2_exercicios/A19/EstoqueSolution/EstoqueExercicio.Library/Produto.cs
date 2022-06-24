using System;

namespace EstoqueExercicio.Library
{
    /*
     2.	Controle de estoque. Crie uma classe produto com as seguintes propriedes: Código, Nome, Preço, Unidade e Data de Validade. Crie uma classe estoque com as seguintes propriedades:  Nome do estabelecimento e Nome do gerente, lista de produtos e quantidade de produtos. A classe estoque será responsável pelo cadastro dos produtos.
        Requisitos:
        Produto:
            Código, Nome, preço, unidade e data de vencimento são obrigatórios;
            Preço deve ser maior 0,00;
            Data de vencimento deve ser maior que data atual;
            Estoque:
            Nome do estabelecimento e gerente são obrigatórios;
            Não é permitido ter 2 ou mais produtos na lista com o mesmo código;
    */

    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime DataValidade { get; set; }

        public Produto()
        {
            DataValidade = new DateTime();
        }

        public override string ToString()
        {
            return $"Código produto: {this.Codigo} \n Nome produto: {this.Nome} \n Preco produto: {this.Preco} \n Data Validade: {this.DataValidade.ToShortDateString()}";
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(this.Nome))
            {
                Console.WriteLine("Nome do produto é obrigatório!");
                return false;
            }
            if (this.Codigo <= 0)
            {
                Console.WriteLine("Código não pode ser 0 ou menor que 0!");
                return false;
            }
            if (this.Preco <= 0)
            {
                Console.WriteLine("Preço não pode ser 0 ou menor que 0!");
                return false;
            }
            if (DateTime.Now > DataValidade)
            {
                Console.WriteLine("A data de vencimento precisa ser maior que a data de hoje!");
                return false;
            }
            return true;
        }
    }
}