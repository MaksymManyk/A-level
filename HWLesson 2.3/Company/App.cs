using Models;
using Repositories;
using Services;
using Services.Abstractions;

namespace SweetGifts
{
    public class App
    {
        private readonly SweetsCategoryService _sweetsCategoryService;
        private readonly SweetsTypeService _sweetsTypeService;
        private readonly SweetsAssortmentService _sweetsAssortmentService;
        private readonly GiftTypeService _giftTypeService;

        public App(SweetsCategoryService sweetsCategoryService)
        {
            this._sweetsCategoryService = sweetsCategoryService;
            this._sweetsTypeService = new SweetsTypeService(new SweetsTypeRepository(), this._sweetsCategoryService);
            this._sweetsAssortmentService = new SweetsAssortmentService(new SweetsAssortmentRepository(), this._sweetsTypeService);
            this._giftTypeService = new GiftTypeService(new GiftTypeRepository());
        }

        public void Start()
        {
            SweetsCategory[] sweetsCategories = this._sweetsCategoryService.GenerateSweetsCategory();

            SweetsType[] sweetstypes = _sweetsTypeService.GenerateSweetsTypes(sweetsCategories);

            SweetsAssortment[] sweetsAssortment = _sweetsAssortmentService.GenerateSweetsAssortmens(sweetstypes);

            GiftType[] giftTypes = _giftTypeService.GenerateGiftType();

            Console.WriteLine("Welcome Customer. We offer the following sweets:");

            _sweetsAssortmentService.PrintSweetsAssortment(sweetsAssortment);

            Console.WriteLine($"{Environment.NewLine}We also offer you 3 types of gifts:{Environment.NewLine}");

            _giftTypeService.PrintGiftType(giftTypes);

            Console.WriteLine($"{Environment.NewLine}What type of gift do you want?{Environment.NewLine}");

            string unswerGiftType = Console.ReadLine().ToLower();
            IGiftAssortmentService? gift = SelectGiftType(unswerGiftType, giftTypes, sweetsAssortment);

            if (gift is not null)
            {
                GiftAssortment[] giftAssortment = gift.GenerateGiftAssortment();

                PrintGiftAssortment(giftAssortment, unswerGiftType);

                Console.WriteLine($"{Environment.NewLine}Which type of {unswerGiftType} you want?{Environment.NewLine}");

                string unswerGiftName = Console.ReadLine().ToLower();

                foreach (var sweet in giftAssortment)
                {
                    if (sweet.GiftName.ToLower() == unswerGiftName)
                    {
                        Array.Sort(sweet.SweetsAssortments);
                        Console.WriteLine($"{Environment.NewLine} You selected {sweet.GiftName}, weight = {sweet.Weight} grams");
                        Console.WriteLine($"{Environment.NewLine}{"Assortment",-30}{"Quantitity",-50} {Environment.NewLine}");
                        Array.Sort(sweet.SweetsAssortments);

                        foreach (var item in sweet.SweetsAssortments)
                        {
                            Console.WriteLine($"{item.Assortments.AssortmentName,-30}   {item.Quantitity,-50}");
                        }

                        Console.WriteLine($"{Environment.NewLine}Input please, which sweet you search in a gift");
                        string unswerSweets = Console.ReadLine();

                        bool isInclude = SearchSweets(sweet.SweetsAssortments, unswerSweets);

                        if (!isInclude)
                            {
                                Console.WriteLine($"{unswerSweets} not include in gift");
                            }
                    }
                }
            }
            else
            {
                Console.WriteLine($"You didn`t choice gift type!");
            }
        }

        public IGiftAssortmentService SelectGiftType(string unswerGiftType, GiftType[] giftTypes, SweetsAssortment[] sweetsAssortment)
        {
            IGiftAssortmentService? gift = null;

            if (unswerGiftType == "box")
            {
                gift = new GiftBoxService(new GiftAssortmentRepository(), giftTypes[0].GiftTypeId, sweetsAssortment);
            }
            else if (unswerGiftType == "basket")
            {
                gift = new GiftBasketService(new GiftAssortmentRepository(), giftTypes[1].GiftTypeId, sweetsAssortment);
            }
            else if (unswerGiftType == "pack")
            {
                gift = new GiftPackService(new GiftAssortmentRepository(), giftTypes[2].GiftTypeId, sweetsAssortment);
            }

            return gift;
        }

        public void PrintGiftAssortment(GiftAssortment[] giftAssortment, string unswerGiftType)
        {
            Console.WriteLine($"{Environment.NewLine}We have next type of {unswerGiftType}{Environment.NewLine}");

            foreach (var bask in giftAssortment)
            {
                Console.WriteLine($"{Environment.NewLine} {bask.GiftName}   {bask.GiftTypeName}");

                Console.WriteLine($"{Environment.NewLine}{"Assortment",-30}{"Quantitity",-50} {Environment.NewLine}");

                foreach (var item in bask.SweetsAssortments)
                {
                    Console.WriteLine($"{item.Assortments.AssortmentName,-30}   {item.Quantitity,-50}");
                }
            }
        }

        public bool SearchSweets(SweetsQuantity[] SweetsAssortments, string unswerSweets)
        {
            bool isExist = false;

            foreach (var item in SweetsAssortments)
            {
                if (unswerSweets.ToLower() == item.Assortments.AssortmentName.ToLower())
                {
                    isExist = true;
                    Console.WriteLine($"Sweets {item.Assortments.AssortmentName} include in gift, Quantity = {item.Quantitity} pcs");
                }
            }

            return isExist;
        }
    }
}