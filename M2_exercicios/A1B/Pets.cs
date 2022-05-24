namespace A1B
{
    public class Pets
    {
        public string Name;
        public string Type;
        public string Characteristic1;
        public string Characteristic2;
        public static int nOfDogs;
        public static int nOfCats;
        public static int nOfFishes;

        public Pets(string name, string type)
        {
            Name = name;

            if(type == "Dog")
            {
                Type = "Dog";
                nOfDogs++;
            }
            else if(type == "Cat")
            {
                Type = "Cat";
                nOfCats++;
            }
            else
            {
                Type = "Fish";
                nOfFishes++;
            }
            
        }
        public Pets()
        {
            
        }
    }
}