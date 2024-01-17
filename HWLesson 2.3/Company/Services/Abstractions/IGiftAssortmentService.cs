 using Models; 

namespace Services.Abstractions
{
    public interface IGiftAssortmentService
    {
         public string AddGiftAssortment(string Name, string TypeId, SweetsQuantity[] sweetsAssortments);

         public GiftAssortment GetGiftAssortment(string id);

         public SweetsQuantity[] SweetsGenerateForGift(int count, SweetsAssortment[] sweetsAssortment, int quantity);

         public GiftAssortment[] GenerateGiftAssortment();

         public double GetGiftWeight(SweetsQuantity[] sweetsAssortments);
    }
}
