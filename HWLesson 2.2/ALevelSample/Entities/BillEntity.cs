using System;
using Models;

namespace Entities
{
    public class BillEntity
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public int Cost { get; set; }
        public string UserID { get; set; }
        public DateTime Date { get; set; }
    }
}
