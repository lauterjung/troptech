using System.Linq;

namespace A4
{
    public class Pilha
    {
        private string[] _storage = new string[0];
        private int _size = 0;

        public int Size
        {
            get { return _size; }
        }
        public string Topo
        {
            get { return _storage[_size-1]; }
        }

        public Pilha()
        {

        }

        public void Empilhar()
        {
            _size++;
            Array.Resize(ref _storage, _size);

            Console.Write("Digite o item: ");
            string item = Console.ReadLine();
            _storage[_size - 1] = item;
            Console.WriteLine($"Existem {_size} itens na pilha.");
            Console.ReadKey();
        }
        public void Desempilhar()
        {
            _size--;
            Array.Resize(ref _storage, _size);
            Console.WriteLine($"Existem {_size} itens na pilha.");
            Console.ReadKey();
        }
        public void VerTopo()
        {
            Console.WriteLine($"O item do topo é {_storage[_size-1]}.");
            Console.ReadKey();
        }
        public void Limpar()
        {
            _size = 0;
            Array.Resize(ref _storage, _size);
            Console.WriteLine($"Existem {_size} itens na pilha.");
            Console.ReadKey();
        }
        public void Verificar()
        {
            Console.Write("Digite o item: ");
            string item = Console.ReadLine();

            if (_storage.Contains(item))
            {
                Console.WriteLine($"O item {item} existe na pilha.");
            }
            else
            {
                Console.WriteLine($"O item {item} não existe na pilha.");
            }
            Console.ReadKey();
        }
        
    }
}