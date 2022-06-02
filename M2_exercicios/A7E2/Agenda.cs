namespace A7
{
    public class Agenda
    {
        private List<Contact> _contacts;

        public Agenda()
        {
            _contacts = new List<Contact>();
        }
        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }
        public void RemoveContact(string contactName)
        {
            Contact contactToRemove = new Contact();
            foreach (var element in _contacts)
            {
                if (element.Name == contactName)
                {
                    contactToRemove = element;
                }
            }
            _contacts.Remove(contactToRemove);
        }
        public bool SearchContact(string contactName)
        {
            foreach (var element in _contacts)
            {
                if (element.Name == contactName)
                {
                    return true;
                }
            }
            return false;
            // _contacts.Any(x => x.Name == contactName);
        }
        public void ShowAll()
        {
            foreach (var element in _contacts)
            {
                System.Console.WriteLine(element.Name);
            }
        }
        public List<string> GetSortedNames()
        {
            List<string> sortedList = new List<string>();
            foreach (var element in _contacts)
            {
                sortedList.Add(element.Name);
            }
            sortedList.Sort();
            return sortedList;
        }

    }
}