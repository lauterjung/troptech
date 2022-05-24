namespace A1
{
    public class ItemDaAgenda
    {
        public string Name;
        public string Address;
        public string PhoneNumber;
        public string Job;
        public static int ItemCount;

        public ItemDaAgenda()
        {
            ItemCount++;
        }
        public ItemDaAgenda(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            ItemCount++;
        }
    }
}