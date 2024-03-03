using Enums;
using Models;
using Extensions;
using System.Globalization;
using Services.Abstractions;
using Repositories.Abstractions;

namespace Services
{
    public class ContactListService : IContactListService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ContactsList _contactList;

        public ContactListService(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
            this._contactList = new ContactsList();
        }

        public string AddContact(Person person, Culture culture, PhoneNumber PhoneNumber)
        {
            var id = _contactRepository.AddContact(person, culture, PhoneNumber, CheckSection(person));
            return id;
        }

        public string CheckSection(Person person)
        {
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            if (char.IsDigit(person.Surname[0]) || char.IsDigit(person.Name[0]))
            {
                return Sections.numb.GetSection();
            }
            else
            {
                return CheckCulture(currentCulture, person.Surname + person.Name);
            }
        }

        public string CheckCulture(CultureInfo currentCulture, string word)
        {
            string alphabetEng = "qwertyuiopasdfghjklzxcvbnm";
            string alphabetUkr = "'йцукенгшщзхїфівапролджєячсмитьбю";

            string alphabet = currentCulture.Name == "uk-UA" ? alphabetUkr : alphabetEng;

            foreach (char c in word)
            {
                if (!(currentCulture.CompareInfo.IndexOf(alphabet, c, CompareOptions.IgnoreCase) >= 0))
                {
                    return Sections.octothorpe.GetSection();
                }
            }

            return Sections.alphabet.GetSection();
        }

        public Contact GetContact(string id)
        {
            var contact = _contactRepository.GetContact(id);

            if (contact == null)
            {
                return null;
            }
            else
            {
                return new Contact()
                {
                    Person = contact.Person,
                    Culture = contact.Culture,
                    PhoneNumber = contact.PhoneNumber,
                    Section = contact.Section
                };
            }
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts  = new List<Contact>();
            foreach (var contact in this._contactRepository.GetContacts())
            {
                if (contact == null)
                {
                    return null;
                }
                else
                {
                    contacts.Add(new Contact()
                    {
                        Person = contact.Person,
                        Culture = contact.Culture,
                        PhoneNumber = contact.PhoneNumber,
                        Section = contact.Section
                    });
                }
            }

            return contacts;
        }

        public void AddContactsToContactList()
        {
            List<Contact> sortedList = this.GetContacts().OrderByDescending(item => item.Section).ThenBy(item => item.Person.Surname).ThenBy(item => item.Person.Name).ToList();

            this.AddContactToContactList(sortedList, Sections.alphabet);
            this.AddContactToContactList(sortedList, Sections.numb);
            this.AddContactToContactList(sortedList, Sections.octothorpe);
        }

        public void AddContactToContactList(List<Contact> contacts, Sections section)
        {
            List<Contact> contactSection = contacts.Where(obj => obj.Section == section.GetSection()).ToList();
            _contactList.AddContacts(contactSection, section.GetSection());
        }


        public void GenerateContactList()
        {
            this.AddContact(
             new Person() { Name = "Max", Surname = "Cronson", BirthdateAt = new DateTime(1980, 2, 1) },
             new Culture() { Country = "Ukraine", CountryCode = "UA", Language = Languages.Eng.GetSection() },
             new PhoneNumber() { PhoneTypes = Enums.PhoneTypes.Mobile, Number = "088050055250" });

            this.AddContact(
            new Person() { Name = "Максим", Surname = "Мронсон", BirthdateAt = new DateTime(1980, 6, 1) },
            new Culture() { Country = "Ukraine", CountryCode = "UA", Language = Languages.Ukr.GetSection() },
            new PhoneNumber() { PhoneTypes = Enums.PhoneTypes.Homephone, Number = "044050055250" });

            this.AddContact(
            new Person() { Name = "54Максим", Surname = "Арон", BirthdateAt = new DateTime(1984, 3, 1) },
            new Culture() { Country = "USA", CountryCode = "US", Language = Languages.Eng.GetSection() },
            new PhoneNumber() { PhoneTypes = Enums.PhoneTypes.Satellite, Number = "088050055250" });

            this.AddContact(
           new Person() { Name = "Максим", Surname = "Аронсон", BirthdateAt = new DateTime(1980, 6, 1) },
           new Culture() { Country = "Ukraine", CountryCode = "UA", Language = Languages.Ukr.GetSection() },
           new PhoneNumber() { PhoneTypes = Enums.PhoneTypes.Homephone, Number = "044050055250" });

            this.AddContact(
           new Person() { Name = "Давід", Surname = "Аронсон", BirthdateAt = new DateTime(1980, 6, 1) },
           new Culture() { Country = "Ukraine", CountryCode = "UA", Language = Languages.Ukr.GetSection() },
           new PhoneNumber() { PhoneTypes = Enums.PhoneTypes.Homephone, Number = "044050055250" });

            this.AddContact(
            new Person() { Name = "Мак45сим", Surname = "Арон", BirthdateAt = new DateTime(1984, 3, 1) },
            new Culture() { Country = "USA", CountryCode = "US", Language = Languages.Eng.GetSection() },
            new PhoneNumber() { PhoneTypes = Enums.PhoneTypes.Satellite, Number = "088050055250" });
        }

        public void PrintContacts()
        {
            _contactRepository.PrintContacts();
        }

        public void PrintContactList()
        {
            _contactList.PrintContacts();
          }
    }
}
