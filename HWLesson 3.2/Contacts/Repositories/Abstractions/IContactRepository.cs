using Entities;
using Models;

namespace  Repositories.Abstractions
{
    public interface IContactRepository
    {
        public string AddContact(Person person, Culture culture, PhoneNumber PhoneNumber, string section);

        public ContactEntity GetContact(string id);

        public void PrintContacts();

        public List<ContactEntity> GetContacts();
    }
}
