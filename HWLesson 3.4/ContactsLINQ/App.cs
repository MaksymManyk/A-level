using Models;
using Services.IServices;
using static Services.ContactService;

namespace ContactsLINQ
{
    public class App
    {
        IContactService _contactsService;

        public App(IContactService contactsService)
        {
            _contactsService = contactsService;
        }

        public void Start()
        {
            _contactsService.GenerateContacts();

            List<Contact> contacts = _contactsService.GetContacts();
            string search;
            _contactsService.PrintContacts(contacts, "Full Contacts List:");

            SearchContacts("Italian", contacts, SearchByNationality, "Search by Nationality");
            SearchContacts("Relatives", contacts, SearchByGroup, "Search by Group");
            SearchContacts("Gus", contacts, SearchPerson, "Search Person");
            _contactsService.GetCountContacts();
            _contactsService.GetAverageContactsAge();

            //delegate
            Func<int, int, int> sumMethod;

            sumMethod = CalculateSum;
            var sum = TryCatch(CalculateSum, TryCatch(CalculateSum, 5, 3), TryCatch(CalculateSum, 3, 7));

            Console.WriteLine($"Sum = {sum}");
        }

        public void SearchContacts(string search, List<Contact> contacts, SearchDelegate searchDelegate, string messege)
        {

            _contactsService.SearchContact(search, contacts, searchDelegate, $"{messege} {search}:");
        }

        public List<Contact> SearchByNationality(string nationality, List<Contact> contacts)
        { 
            return contacts.Where(x => x.Person.Nationality.ToString().ToUpper() == nationality.ToUpper()).ToList();
        }

        public List<Contact> SearchByGroup(string group, List<Contact> contacts)
        {
            return contacts.Where(x => x.Group.ToString().ToUpper() == group.ToUpper()).ToList();
        }

        public List<Contact> SearchPerson(string person, List<Contact> contacts)
        {
            return contacts.Where(x => x.Person.Name.ToString().ToUpper().Contains(person.ToUpper()) || x.Person.Surname.ToString().ToUpper().Contains(person.ToUpper())).ToList();
        }

        public int CalculateSum (int a, int b)
        { return a + b; }

        public int TryCatch(Func<int, int, int> sumMethod , int a, int b)
        {
            int sum;
            try
            {
               sum = sumMethod.Invoke(a, b);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                return 0;
            }

            return sum;
        }
    }
}
