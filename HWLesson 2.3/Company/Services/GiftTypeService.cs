using Models;
using Repositories;
using Services.Abstractions;

namespace Services
{
    public class GiftTypeService : IGiftTypeService
    {
        private readonly GiftTypeRepository _giftTypeRepository;

        public GiftTypeService(GiftTypeRepository giftTypeRepository)
        {
            _giftTypeRepository = giftTypeRepository;
        }

        public string AddGiftType(string Name)
        {
            var id = _giftTypeRepository.AddGiftType(Name);
            return id;
        }

        public GiftType GetGiftType(string id)
        {
            var giftType = _giftTypeRepository.GetGiftType(id);

            if (giftType == null)
            {
                return null;
            }

            return new GiftType()
            {
                GiftTypeId = giftType.GiftTypeId,
                GiftTypeName = giftType.GiftTypeName
            };
        }

        public GiftType[] GenerateGiftType()
        {
            GiftType[] GiftTypes = new GiftType[3];
            GiftTypes[0] = GetGiftType(_giftTypeRepository.AddGiftType("Box"));
            GiftTypes[1] = GetGiftType(_giftTypeRepository.AddGiftType("Basket"));
            GiftTypes[2] = GetGiftType(_giftTypeRepository.AddGiftType("Pack"));
            return GiftTypes;
        }

        public void PrintGiftType(GiftType[] giftTypes)
        {
            foreach (var type in giftTypes)
            {
                Console.WriteLine($"{type.GiftTypeName} ");
            }
        }
    }
}
