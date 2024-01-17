using Models; 

namespace Services.Abstractions
{
    public interface IGiftTypeService
    {
        public string AddGiftType(string Name);

        public GiftType[] GenerateGiftType();

        public GiftType GetGiftType(string id);
    }
}
