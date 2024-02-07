using Services.Abstractions;
using System.Globalization;

namespace Contacts
{
    public class App
    {
        private readonly IContactListService _contactListService;

        public App(IContactListService contactListService)
        {
            _contactListService = contactListService;
        }

        public void Start()
        {
            _contactListService.GenerateContactList();
            _contactListService.PrintContacts();
            CultureInfo current = CultureInfo.CurrentCulture;
            Console.WriteLine("The current culture is {0}", current.Name);
            _contactListService.AddContactsToContactList();

            Console.WriteLine($"{"Surname",-10}{"Name",-10}{"Phone Type",-15}{"Phone Number",-20}{"BirthDate",-20}{"Country",-15}{"Lang",-15}{"CountryCode",-15}");
            _contactListService.PrintContactList();
        }
    }
}
