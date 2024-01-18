using Repositories;
using Models; 
using Services.Abstractions;
using  Services;

namespace Services
{
    public class GiftPackService : GiftAssortmentService
    {
        private readonly string _giftTypeId;
        private readonly SweetsAssortment[] _sweetsAssortment;

        public GiftPackService(GiftAssortmentRepository giftAssortmentRepository, string giftTypeId, SweetsAssortment[] sweetsAssortment) : base (giftAssortmentRepository)
        {
            this._giftTypeId = giftTypeId;
            this._sweetsAssortment = sweetsAssortment;
        }

        public override GiftAssortment[] GenerateGiftAssortment()
        {
            GiftAssortment[] GiftTypes = new GiftAssortment[3];
            GiftTypes[0] = base.GetGiftAssortment(base.AddGiftAssortment("LargePack", _giftTypeId,  SweetsGenerateForGift(25, _sweetsAssortment, 100)));
            GiftTypes[1] = base.GetGiftAssortment(base.AddGiftAssortment("MediumPack", _giftTypeId, base.SweetsGenerateForGift(15, _sweetsAssortment, 50)));
            GiftTypes[2] = base.GetGiftAssortment(base.AddGiftAssortment("SmallPack", _giftTypeId, base.SweetsGenerateForGift(10, _sweetsAssortment, 20)));
            return GiftTypes;
        }
    }
}
