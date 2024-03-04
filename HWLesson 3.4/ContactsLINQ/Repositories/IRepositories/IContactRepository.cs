using Entities;
using Enums;
using Models;

namespace Repositories.IRepositories
{
    public interface IContactRepository
    {
        public string AddContact(Person person, Phone phone, PhoneGroup group);

        public ContactEntity GetContact(string id);

        public List<ContactEntity> GetContacts();
    }
}
