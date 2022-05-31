namespace A5
{
    public class Paciente
    {
        private string _nome;
        private int _idade;
        private Imc _imc;
        private double _imcCalculado;
        private string _categoriaImc;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }
        public Imc ImcPessoal
        {
            get { return _imc; }
        }

        public double ImcCalculado
        {
            get { return _imcCalculado; }
        }
        public string CategoriaImc
        {
            get { return _categoriaImc; }
        }


        public Paciente(string nome, int idade, Imc imc)
        {
            _nome = nome;
            _idade = idade;
            _imc = imc;
            _imcCalculado = imc.Peso/(imc.Altura*imc.Altura);
            _categoriaImc = CategorizarImc(_imcCalculado);
        }
        public Paciente()
        {

        }

        public string CategorizarImc(double imcCalculado)
        {
            if (imcCalculado < 16)
            {
                return ("Baixo peso Grau III");
            }
            else if (imcCalculado >= 16 && imcCalculado < 17)
            {
                return ("Baixo peso Grau II");
            }
            else if (imcCalculado >= 17 && imcCalculado < 18.5)
            {
                return ("Baixo peso Grau I");
            }
            else if (imcCalculado >= 18.5 && imcCalculado < 25)
            {
                return ("Peso ideal");
            }
            else if (imcCalculado >= 25 && imcCalculado < 30)
            {
                return ("Sobrepeso");
            }
            else if (imcCalculado >= 30 && imcCalculado < 35)
            {
                return ("Obesidade Grau I");
            }
            else if (imcCalculado >= 35 && imcCalculado < 40)
            {
                return ("Obesidade Grau II");
            }
            else
            {
                return ("Obesidade Grau III");
            }
        }
    }
}