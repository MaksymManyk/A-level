using Enums;
using Models;
using static Services.ContactService;

namespace Services.IServices
{
    public interface IContactService
    {
        public string AddContact(Person person, Phone phone, PhoneGroup group);

        public void GenerateContacts();

        public List<Contact> GetContacts();

        public void PrintContacts(List<Contact> contacts, string messege);

        public SearchDelegate _searchDelegate { get; set; }

        public void SearchContact(string searchWord, List<Contact> contacts, SearchDelegate searchDelegate, string messege);

        public void GetCountContacts();

        public void GetAverageContactsAge();
    }
}
