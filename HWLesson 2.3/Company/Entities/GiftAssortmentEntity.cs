using Models;

namespace Entities
{
    public class GiftAssortmentEntity : GiftTypeEntity
    {
        public string GiftAssortmenId { get; set; }

        public string GiftTypeId { get; set; }

        public string GiftName { get; set; }

        public double Weight { get; set; }

        public SweetsQuantity[] SweetsAssortments { get; set; }
    }
}
