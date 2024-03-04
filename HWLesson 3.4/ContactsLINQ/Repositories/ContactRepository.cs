using Entities;
using Enums;
using Models;
using Repositories.IRepositories;

namespace Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<ContactEntity> _contactEntyties;
        private int _CountContacts;

        public ContactRepository()
        {
            _contactEntyties = new List<ContactEntity>();
            _CountContacts = 0;
        }

        public string AddContact(Person person, Phone phone, PhoneGroup group)
        {
            var contact = new ContactEntity()
            {
                 ID = Guid.NewGuid().ToString(),
                 Person = person,
                 Phone = phone,
                 Group = group
            };
            this._contactEntyties.Add(contact);
            this._CountContacts++;
            return contact.ID;
        }

        public ContactEntity GetContact(string id)
        {
            var contact = _contactEntyties.FirstOrDefault(x => x.ID == id);
            return contact;
        }

        public List<ContactEntity> GetContacts()
        {
            return _contactEntyties;
        }
    }
}
