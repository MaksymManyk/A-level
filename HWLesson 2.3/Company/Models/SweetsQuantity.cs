
namespace Models
{
    public class SweetsQuantity : IComparable<SweetsQuantity>
    {
        public SweetsAssortment Assortments;
        public int Quantitity;

        public int CompareTo(SweetsQuantity? Assortments)
        {
            return string.Compare(this.Assortments.AssortmentName, Assortments.Assortments.AssortmentName, StringComparison.Ordinal);
        }
    }
}
