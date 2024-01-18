using Models;
namespace Extension
{
    public static class Extension
    {

        public static double CalculateGiftWeight(this SweetsQuantity[] sweetsAssortments)
        {
            double weight = 0;
            foreach (SweetsQuantity item in sweetsAssortments)
            {
                weight += item.Quantitity * item.Assortments.Weight;
            }

            return weight;
        }

        public static string ToLower(this string str)
        {
            return str.ToLower();
        }
    }
}
