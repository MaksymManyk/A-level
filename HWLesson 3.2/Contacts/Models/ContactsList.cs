namespace  Models
{
    public class ContactsList
    {
        public Dictionary<string, List<Contact>> contacts = new Dictionary<string, List<Contact>>();

        public void AddContacts(List<Contact> contact, string section)
        {
            contacts.Add (section, contact);
        }

        public void PrintContacts()
        {
            foreach (var section in contacts)
            {
                Console.WriteLine($"{Environment.NewLine}{section.Key}");
                foreach (var contact in section.Value)
                {
                    contact.PrintContact();
                }
            }
        }
    }
}
