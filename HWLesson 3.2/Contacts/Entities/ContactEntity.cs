using Models;

namespace  Entities
{
    public class ContactEntity
    {
        public string ID { get; set; }

        public string Section { get; set; }

        public Person Person { get; set; }

        public Culture Culture { get; set; }

        public PhoneNumber PhoneNumber { get; set; }
    }
}
