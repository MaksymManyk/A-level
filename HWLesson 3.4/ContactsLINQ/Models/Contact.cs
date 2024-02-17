using Enums;

namespace Models
{
    public class Contact
    {
        public Person Person { get; set; }

        public Phone Phone { get; set; }

        public PhoneGroup Group { get; set; }
    }
}
