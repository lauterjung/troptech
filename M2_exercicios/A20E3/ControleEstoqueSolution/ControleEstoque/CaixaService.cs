using System.Linq;
using ControleEstoque.Excecoes;

namespace ControleEstoque
{
    public class CaixaService
    {
        private Estoque _estoque;

        public CaixaService(Estoque estoque)
        {
            _estoque = estoque;
        }

        public double RealizarVenda(int codigo)
        {
            try
            {
                var produto = _estoque.RegistrarSaidaDeProduto(codigo, 1);

                var venda = new Venda(produto);

                return venda.PrecoTotal;
            }
            catch (EstoqueInsuficienteException)
            {
                return double.NaN;
            }
            catch (ProdutoNaoEncontradoException)
            {
                return double.NaN;
            }
        }
        public double RealizarVenda(int codigo, int quantidade)
        {
            try
            {
                var produto = _estoque.RegistrarSaidaDeProduto(codigo, quantidade);

                var venda = new Venda(produto, quantidade);

                return venda.PrecoTotal;
            }
            catch (EstoqueInsuficienteException)
            {
                return double.NaN;
            }
            catch (ProdutoNaoEncontradoException)
            {
                return double.NaN;
            }
        }
    }
}