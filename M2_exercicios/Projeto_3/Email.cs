namespace MiguelBusarelloLauterjungM2P3
{
    public class Email
    {
        private static int _count = 1;
        public int ID { get; private set; }
        public string Message { get; set; }

        public Email(string message)
        {
            Message = message;
            ID = _count;
            _count++;
        }
        public Email()
        {
            ID = _count;
            _count++;
        }
        public virtual void Show()
        {
            
        }
    }
}