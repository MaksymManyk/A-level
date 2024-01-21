using Extension;
using Models;
using Repositories;
using Services.Abstractions;

namespace  Services
{
    public class GiftAssortmentService : IGiftAssortmentService
    {
        private readonly GiftAssortmentRepository _giftAssortmentRepository;

        public GiftAssortmentService(GiftAssortmentRepository giftAssortmentRepository)
        {
            this._giftAssortmentRepository = giftAssortmentRepository;
 
        }

        public string AddGiftAssortment(string Name, string TypeId, SweetsQuantity[] sweetsAssortments)
        {
            var id = this._giftAssortmentRepository.AddGiftAssortment(Name, TypeId, sweetsAssortments,  sweetsAssortments.CalculateGiftWeight());
            return id;
        }
        public GiftAssortment GetGiftAssortment(string id)
        {
            var giftAssortment = _giftAssortmentRepository.GetGiftAssortment(id);

            if (giftAssortment == null)
            {
                return null;
            }

            return new GiftAssortment()
            {
                GiftAssortmenId = giftAssortment.GiftAssortmenId,
                GiftName = giftAssortment.GiftName,
                GiftTypeName = giftAssortment.GiftTypeName,
                SweetsAssortments = giftAssortment.SweetsAssortments,
                Weight = giftAssortment.Weight
            };
        }

        

        public SweetsQuantity[] SweetsGenerateForGift(int count, SweetsAssortment[] sweetsAssortment, int quantity)
        {
            SweetsQuantity[] sweets = new SweetsQuantity[count];

            for (int i = 0; i < sweets.Length; i++)
            {
                sweets[i] = new SweetsQuantity
                {
                    Assortments = sweetsAssortment[new Random().Next(0, sweetsAssortment.Length)],
                    Quantitity = new Random().Next(1, quantity)
                };
            }

            return sweets;
        }

        public virtual GiftAssortment[] GenerateGiftAssortment()
        {
            throw new NotImplementedException();
        }
    }
}
