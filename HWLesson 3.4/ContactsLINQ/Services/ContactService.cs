using Enums;
using Models;
using Repositories.IRepositories;
using Services.IServices;

namespace Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;

        public delegate List<Contact> SearchDelegate(string searchWord, List<Contact> contacts);

        public SearchDelegate _searchDelegate {get; set; }

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public string AddContact(Person person, Phone phone, PhoneGroup group)
        {
            return  _contactRepository.AddContact( person, phone, group );       

        }

        public void GenerateContacts()
        {
            this.AddContact(new Person() { Name = "Lucia", Surname = "Mikelangelo", Age = 29, Nationality = Nationality.Italian }
                            , new Phone() { CountryCode = "+39", PhoneCode = "330", PhoneNumber = "7456923" }, PhoneGroup.Relatives);

            this.AddContact(new Person() { Name = "Mykola", Surname = "Kotygoroshko", Age = 25, Nationality = Nationality.Ukrainian }
                            , new Phone() { CountryCode = "+38", PhoneCode = "050", PhoneNumber = "5253252" }, PhoneGroup.Job);

            this.AddContact(new Person() { Name = "Andreas", Surname = "Sholc", Age = 45, Nationality = Nationality.German  }
                            , new Phone() { CountryCode = "+49", PhoneCode = "163", PhoneNumber = "7584256" }, PhoneGroup.Friends);

            this.AddContact(new Person() { Name = "Lucas", Surname = "Parmecano", Age = 32, Nationality = Nationality.Italian }
                            , new Phone() { CountryCode = "+39", PhoneCode = "330", PhoneNumber = "3256425" }, PhoneGroup.Friends);

            this.AddContact(new Person() { Name = "Grygory", Surname = "Kuvalda", Age = 20, Nationality = Nationality.Ukrainian }
                            , new Phone() { CountryCode = "+38", PhoneCode = "050", PhoneNumber = "3265762" }, PhoneGroup.Job);

            this.AddContact(new Person() { Name = "Anton", Surname = "Richka", Age = 22, Nationality = Nationality.Ukrainian }
                            , new Phone() { CountryCode = "+38", PhoneCode = "066", PhoneNumber = "3269545" }, PhoneGroup.Friends );

            this.AddContact(new Person() { Name = "Karl", Surname = "Gustav", Age = 32, Nationality = Nationality.German }
                           , new Phone() { CountryCode = "+49", PhoneCode = "163", PhoneNumber = "3265236" }, PhoneGroup.Relatives);

            this.AddContact(new Person() { Name = "Marya", Surname = "Manyk", Age = 60, Nationality = Nationality.Ukrainian }
                            , new Phone() { CountryCode = "+38", PhoneCode = "067", PhoneNumber = "2553647" }, PhoneGroup.Relatives);
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
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
                        Phone = contact.Phone,
                        Group = contact.Group
                    });
                }
            }

            return contacts;
        }

        public void PrintContacts(List<Contact> contacts, string messege)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{messege}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"Name",-10}{"Surname",-20}{"Age",-10}{"Nationality",-20}{"CountryCode",-20}{"PhoneCode",-15}{"PhoneNumber",-15}{"Group",-15}{Environment.NewLine}");
            Console.ResetColor();
            foreach (var contact in contacts.OrderBy(x => x.Person.Name).ToList())
            {
                Console.WriteLine($"{contact.Person.Name,-10}{contact.Person.Surname,-20}{contact.Person.Age,-10}{contact.Person.Nationality,-20}" +
                    $"{contact.Phone.CountryCode,-20}{contact.Phone.PhoneCode,-15}{contact.Phone.PhoneNumber,-15}{contact.Group,-15}");
            }

            Console.WriteLine();
        }

        public void SearchContact(string searchWord, List<Contact> contacts, SearchDelegate searchDelegate, string messege)
        {
            PrintContacts(searchDelegate.Invoke(searchWord, contacts), messege);
        }

        public void GetCountContacts()
        {
            var count =  this.GetContacts().Count();
            Console.WriteLine($"The count of contacts is {count.ToString()}");
        }

        public void GetAverageContactsAge()
        {
            var av = this.GetContacts().Average(x => x.Person.Age);
            Console.WriteLine($"The average age of contacts is {av}");
        }
    }
}
