namespace A8
{
    public class Animal
    {
        public string Nome { get; set; }
        public string Dono { get; set; }
        public CategoriaAnimal Categoria { get; set; }
        public enum CategoriaAnimal
        {
            Cachorro,
            Gato,
            Coelho,
            Peixe,
        }
        public Animal()
        {

        }
        public Animal(string nome, string dono)
        {
            Nome = nome;
            Dono = dono;
        }
        public override string ToString()
        {
            return ($"Nome: {Nome}, Categoria: {Categoria}, Dono: {Dono}");
        }
    }
}