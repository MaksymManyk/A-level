using Models;
using Repositories;
using Services.Abstractions;

namespace Services
{
    public class GiftBasketService : IGiftAssortmentService
    {
        private readonly GiftAssortmentRepository _giftAssortmentRepository;
        private readonly string _giftTypeId;
        private readonly SweetsAssortment[] _sweetsAssortment;

        public GiftBasketService(GiftAssortmentRepository giftAssortmentRepository, string giftTypeId, SweetsAssortment[] sweetsAssortment)
        {
            this._giftAssortmentRepository = giftAssortmentRepository;
            this._giftTypeId = giftTypeId;
            this._sweetsAssortment = sweetsAssortment;
        }

        public string AddGiftAssortment(string Name, string TypeId, SweetsQuantity[] sweetsAssortments)
        {
            var id = this._giftAssortmentRepository.AddGiftAssortment(Name, TypeId, sweetsAssortments, GetGiftWeight(sweetsAssortments));
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

        public GiftAssortment[] GenerateGiftAssortment()
        {
            GiftAssortment[] GiftTypes = new GiftAssortment[3];
            GiftTypes[0] = GetGiftAssortment(AddGiftAssortment("LargeBasket", _giftTypeId, SweetsGenerateForGift(30, _sweetsAssortment,50)));
            GiftTypes[1] = GetGiftAssortment(AddGiftAssortment("MediumBasket", _giftTypeId, SweetsGenerateForGift(20, _sweetsAssortment,30)));
            GiftTypes[2] = GetGiftAssortment(AddGiftAssortment("SmallBasket", _giftTypeId, SweetsGenerateForGift(10, _sweetsAssortment,10)));
            return GiftTypes;
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

        public double GetGiftWeight(SweetsQuantity[] sweetsAssortments)
        {
            double weight = 0;
            foreach (SweetsQuantity item in sweetsAssortments)
            {
                weight += item.Quantitity * item.Assortments.Weight;
            }

            return weight;
        }
    }
}
