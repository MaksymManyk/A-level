using System;

namespace Models
{
    public class Basket
    {
       public User User { get; set; }
       public ToyQuantity[] Toys { get; set; }
    }
}
