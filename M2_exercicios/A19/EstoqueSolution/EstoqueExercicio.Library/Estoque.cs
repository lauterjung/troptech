using System;
using System.Collections.Generic;

namespace EstoqueExercicio.Library
{
    public class Estoque
    {
        public string NomeEsbelecimento { get; set; }
        public string NomeGerente { get; set; }
        public int QuantidadeProdutos { get { return ListaProdutos.Count; } }

        public List<Produto> ListaProdutos { get; set; }

        public Estoque()
        {
            ListaProdutos = new List<Produto>();
        }

        public Estoque(List<Produto> listaInicial)
        {
            ListaProdutos = listaInicial;
        }

        public override string ToString()
        {
            return $" Nome do estabelecimento: {NomeEsbelecimento} \n" +
            $" Gerente: {NomeGerente} \n" +
            $" Quantidade de produtos: {QuantidadeProdutos} \n" +
            $" Lista de produtos: \n {ListarProdutos()}";

        }

        public bool VerificaSeProdutoExiste(Produto produto)
        {
            foreach (var item in ListaProdutos)
            {
                if (item.Codigo == produto.Codigo)
                {
                    Console.WriteLine("Código de produto já existe no estoque!");
                    return true;
                }
            }

            return false;
        }
        
        public bool Validar()
        {
            if (string.IsNullOrEmpty(this.NomeEsbelecimento))
            {
                Console.WriteLine("Nome do estabelecimento é obrigatório!");
                return false;
            }
            if (string.IsNullOrEmpty(this.NomeGerente))
            {
                Console.WriteLine("Nome do gerente é obrigatório!");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Adiciona um produto se não existir produto igual
        /// </summary>
        /// <param name="produto"></param>
        /// <returns>True se produto foi adicionado ou False caso não foi</returns>
        public bool AdicionarProduto(Produto produto)
        {
            var produtoExiste = VerificaSeProdutoExiste(produto);
            if (!produtoExiste)
                this.ListaProdutos.Add(produto);

            return !produtoExiste;
        }

        // IEnumerable é um tipo de listagem de dados
        public IEnumerable<string> ListarProdutos()
        {
            foreach (var item in this.ListaProdutos)
            {
                // o yield retorna porém continua a iteração, adicionando os itens retornados em um IEnumerable
                yield return item.ToString();
            }
        }
    }
}