using Enums;
using Models;
using System.Globalization;

namespace Services.Abstractions
{
    public interface IContactListService
    {
        public string AddContact(Person person, Culture culture, PhoneNumber PhoneNumber);

        public string CheckSection(Person person);

        public string CheckCulture(CultureInfo currentCulture, string word);

        public Contact GetContact(string id);

        public List<Contact> GetContacts();

        public void AddContactsToContactList();

        public void AddContactToContactList(List<Contact> contacts, Sections section);

        public void GenerateContactList();

        public void PrintContacts();

        public void PrintContactList();
    }
}
