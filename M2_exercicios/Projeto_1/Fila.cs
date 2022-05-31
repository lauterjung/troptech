using System.Linq;

namespace MiguelBusarelloLauterjungM2P1
{
    public class Fila
    {
        private int[] _vetor;
        private int _quantidade;

        public int Quantidade
        {
            get { return _quantidade; }
        }
        public int Primeiro
        {
            get { return VerPrimeiro(); }
        }

        public Fila()
        {
            _vetor = new int[0];
        }

        public void Enfileirar(int novoItem)
        {
            _quantidade++;
            Array.Resize(ref _vetor, _quantidade);

            _vetor[_quantidade - 1] = novoItem;
        }
        public int Desenfileirar()
        {
            _quantidade--;
            int itemRemovido = _vetor[0];
            DiminuirFila();
            return (itemRemovido);
        }
        public int VerPrimeiro()
        {
            return (_vetor[0]);
        }
        public void Limpar()
        {
            _quantidade = 0;
            _vetor = new int[0];
        }
        public bool Verificar(int item)
        {
            foreach(int element in _vetor)
            {
                if(element == item)
                {
                    return(true);
                }
            }
            return(false);
        }

        private int DiminuirFila()
        {
            int[] vetorAux = _vetor;
            _vetor = new int[_vetor.Length - 1];

            for (int i = 0; i < _vetor.Length; i++)
                _vetor[i] = vetorAux[i + 1];

            return vetorAux[_vetor.Length];
        }

    }
}