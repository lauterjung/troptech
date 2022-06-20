namespace A15
{
    public class Solicitacao
    {
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Autor { get; set; }

        public Solicitacao(string categoria, string subcategoria, string descricao, DateTime dataAbertura, string autor)
        {
            Categoria = categoria;
            Subcategoria = subcategoria;
            Descricao = descricao;
            DataAbertura = dataAbertura;
            Autor = autor;
        }
        public Solicitacao()
        {
            DataAbertura = DateTime.Now;
        }
        public bool Validar()
        {
            if (String.IsNullOrEmpty(Categoria))
            {
                throw new SolicitacaoException("Categoria é obrigatória!");
                return false;
            }
            if (String.IsNullOrEmpty(Subcategoria))
            {
                throw new SolicitacaoException("Subcategoria é obrigatória!");
                return false;
            }
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new SolicitacaoException("Descricão é obrigatória!");
                return false;
            }
            // if (String.IsNullOrEmpty(DataAbertura))
            // {
            //     throw new SolicitacaoException("Categoria é obrigatória!");
            //     return false;
            // }
            if (String.IsNullOrEmpty(Autor) || Autor.Length < 3)
            {
                throw new SolicitacaoException("Campo autor é obrigatório e deve conter 3 caractéres!");
                return false;
            }
            System.Console.WriteLine("Cadastro realizado com sucesso!");
            return true;
        }

        public override string ToString()
        {
            return ($"Categoria = {Categoria}\n" +
                    $"Subcategoria: {Subcategoria}\n" +
                    $"Descricao: {Descricao}\n" +
                    $"DataAbertura: {DataAbertura}\n" +
                    $"Autor: {Autor}");
        }
    }
}