using Enums;
using Models; 

namespace Entities
{
    public class ContactEntity
    {
        public string ID { get; set; }

        public Person Person { get; set; }

        public Phone Phone { get; set; }

        public PhoneGroup Group { get; set; }
    }
}
