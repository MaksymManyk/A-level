using Collections;
using ExtensionMethods;

namespace CustomCollection
{
    public class Program
    {
        static void Main(string[] args)
        {
            Collections.CustomCollection<decimal> collectionsInt = new Collections.CustomCollection<decimal>();

            collectionsInt.Add(10);
            collectionsInt.Add(2);
            collectionsInt.Add(1);
            collectionsInt.Add(7);

            collectionsInt.Sort();

            collectionsInt.SetDefaultAt(2);

            collectionsInt.Print();         

        }
    }
}
