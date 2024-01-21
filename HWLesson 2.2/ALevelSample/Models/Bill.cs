using System;

namespace Models
{
    public class Bill
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public int Cost { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}
