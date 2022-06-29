using ControleEstoque.Excecoes;
using System.Collections.Generic;
using System.Linq;

namespace ControleEstoque
{
    public class Estoque
    {
        private readonly List<Produto> _produtos;

        public List<Produto> Produtos { get => _produtos; }

        public Estoque(List<Produto> produtosPreCadastrados)
        {
            _produtos = produtosPreCadastrados;
        }

        public Estoque()
        {
            _produtos = new List<Produto>();
        }

        /// <summary>
        /// Cadastra um produto no estoque
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <param name="descricao">Descrição do produto</param>
        /// <returns>Retorna o produto cadastrado</returns>
        /// <exception cref="ProdutoJaCadastradoException">Ocorre quando produto já está cadastrado</exception>
        public Produto CadastrarProdutoNoEstoque(string nome, string descricao)
        {
            var produto = new Produto(nome, descricao);

            var produtoExiste = _produtos.Any(y => y.Equals(produto));

            if (produtoExiste)
                throw new ProdutoJaCadastradoException();

            produto.DefineId();

            _produtos.Add(produto);

            return produto;
        }

        /// <summary>
        /// Realiza a entrada de itens ao estoque
        /// </summary>
        /// <param name="codigo">Código do produto que será dada a entrada</param>
        /// <param name="quantidade">Quantidade de itens para entrada</param>
        /// <returns>Retorna o produto com quantidade atualizada</returns>
        /// <exception cref="QuantidadeMenorOuIgualAZeroException">Ocorre se a quantidade de entrada for menor ou igual a zero</exception>
        /// <exception cref="ProdutoNaoEncontradoException">Ocorre se o produto ainda não foi cadastrado em estoque</exception>
        public Produto RegistrarEntradaDeProduto(int codigo, int quantidade)
        {
            var produtoNoEstoque = _produtos.FirstOrDefault(y => y.Equals(codigo));

            if (produtoNoEstoque == null)
                throw new ProdutoNaoEncontradoException();

            produtoNoEstoque.AcrescentarQuantidade(quantidade);

            return produtoNoEstoque;
        }

        /// <summary>
        /// Registra a saída da quantidade de itens de produto informado
        /// </summary>
        /// <param name="codigoProduto">Produto que será dada a saída</param>
        /// <param name="quantidade">Quantidade de itens para saída</param>
        /// <returns>Retorna o produto com quantidade atualizada</returns>
        /// <exception cref="QuantidadeMenorOuIgualAZeroException">Ocorre se a quantidade de saída for menor ou igual a zero</exception>
        /// <exception cref="ProdutoNaoEncontradoException">Ocorre se o produto ainda não foi cadastrado em estoque</exception>
        public Produto RegistrarSaidaDeProduto(int codigoProduto, int quantidade)
        {
            var produtoNoEstoque = _produtos.FirstOrDefault(y => y.Equals(codigoProduto));

            if (produtoNoEstoque == null)
                throw new ProdutoNaoEncontradoException();

            produtoNoEstoque.DeduzirQuantidade(quantidade);

            return produtoNoEstoque;
        }

        public string RelatorioInventario()
        {
            string relatorio = string.Empty;

            foreach (var produto in _produtos)
            {
                relatorio = string.Concat(relatorio, produto.ToString(), "\n");
            }

            return relatorio;
        }

        public bool HaProdutosEmEstoque()
        {
            return _produtos.Count > 0;
        }
    }
}
