using Models;
using Repositories;
using Services.Abstractions;

namespace Services
{
    public class GiftBasketService : GiftAssortmentService
    {
   
        private readonly string _giftTypeId;
        private readonly SweetsAssortment[] _sweetsAssortment;

        public GiftBasketService(GiftAssortmentRepository giftAssortmentRepository, string giftTypeId, SweetsAssortment[] sweetsAssortment) : base(giftAssortmentRepository)
        {
            this._giftTypeId = giftTypeId;
            this._sweetsAssortment = sweetsAssortment;
        }


        public override GiftAssortment[] GenerateGiftAssortment()
        {
            GiftAssortment[] GiftTypes = new GiftAssortment[3];
            GiftTypes[0] = GetGiftAssortment(AddGiftAssortment("LargeBasket", _giftTypeId, SweetsGenerateForGift(30, _sweetsAssortment,50)));
            GiftTypes[1] = GetGiftAssortment(AddGiftAssortment("MediumBasket", _giftTypeId, SweetsGenerateForGift(20, _sweetsAssortment,30)));
            GiftTypes[2] = GetGiftAssortment(AddGiftAssortment("SmallBasket", _giftTypeId, SweetsGenerateForGift(10, _sweetsAssortment,10)));
            return GiftTypes;
        }      
    }
}
