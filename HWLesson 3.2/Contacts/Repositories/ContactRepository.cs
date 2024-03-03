using Entities;
using Models;
using Repositories.Abstractions;

namespace  Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly List<ContactEntity> _mockStorage = new List<ContactEntity>();
        private int _mockStorageCursor = 0;

        public string AddContact(Person person, Culture culture, PhoneNumber PhoneNumber, string section)
        {
            var contact = new ContactEntity()
            {
                ID = Guid.NewGuid().ToString(),
                Person = person,
                Culture = culture,
                PhoneNumber = PhoneNumber,
                Section = section
            };

            this._mockStorage.Add(contact);
            this._mockStorageCursor++;
            return contact.ID;
        }

        public ContactEntity GetContact(string id)
        {
            foreach (var contact in this._mockStorage)
            {
                if (contact.ID == id)
                {
                    return contact;
                }
            }

            return null;
        }

        public void PrintContacts()
        {
            foreach (var contact in this._mockStorage)
            {
                if (contact != null)
                {
                    Console.WriteLine($"{contact.ID}, {contact.Person.Name}, {contact.Person.Surname}, {contact.Person.BirthdateAt}, {contact.Culture.Country}, {contact.Culture.Language} , {contact.Culture.CountryCode}, {contact.Section}");
                }
                else break;
            }
        }

        public List<ContactEntity> GetContacts()
        {
            List < ContactEntity > contacts = new List<ContactEntity >();
            foreach (var contact in this._mockStorage)
            {
                if (contact != null)  contacts.Add(contact);
            }

            return contacts;
        }
    }
}
