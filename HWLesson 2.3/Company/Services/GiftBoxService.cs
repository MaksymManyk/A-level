using Models;
using Repositories; 

namespace  Services
{
    public class GiftBoxService : GiftAssortmentService
    {
        private readonly string _giftTypeId;
        private readonly SweetsAssortment[] _sweetsAssortment;

        public GiftBoxService(GiftAssortmentRepository giftAssortmentRepository, string giftTypeId, SweetsAssortment[] sweetsAssortment) : base(giftAssortmentRepository)
        {
            this._giftTypeId = giftTypeId;
            this._sweetsAssortment = sweetsAssortment;
        }

        public override GiftAssortment[] GenerateGiftAssortment()
        {
            GiftAssortment[] GiftTypes = new GiftAssortment[3];
            GiftTypes[0] = GetGiftAssortment(AddGiftAssortment("LargeBox", _giftTypeId, SweetsGenerateForGift(20, _sweetsAssortment, 40)));
            GiftTypes[1] = GetGiftAssortment(AddGiftAssortment("MediumBox", _giftTypeId, SweetsGenerateForGift(15, _sweetsAssortment, 20)));
            GiftTypes[2] = GetGiftAssortment(AddGiftAssortment("SmallBox", _giftTypeId, SweetsGenerateForGift(5, _sweetsAssortment, 10)));
            return GiftTypes;
        }
    }
}
