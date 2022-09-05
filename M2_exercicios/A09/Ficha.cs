namespace A9
{
    public class Ficha
    {
        private int _numero;
        private Generos _genero;
        private string _pais;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        public string Pais
        {
            get { return _pais; }
            set { _pais = value; }
        }
        public Generos Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }
        public enum Generos
        {
            MASCULINO,
            FEMININO
        }

        public Ficha(int numero, Generos genero, string pais)
        {
        _numero = numero;
        _genero = genero;
        _pais = pais;
        }
        
    }
}