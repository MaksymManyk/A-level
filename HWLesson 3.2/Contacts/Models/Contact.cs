
namespace Models
{
    public class Contact
    {
        public string Section { get; set; }

        public Person Person { get; set; }

        public Culture Culture { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public void PrintContact()
        {

            Console.WriteLine($" {Person.Surname,-10}{Person.Name,-10}{PhoneNumber.PhoneTypes,-15}{PhoneNumber.Number,-20}" +
                $"{Person.BirthdateAt,-20}{Culture.Country,-15}{Culture.Language,-15}{Culture.CountryCode,-15}");
        }
    }
}
