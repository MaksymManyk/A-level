using Models;
using Repositories;

namespace Services
{
    public class SweetsAssortmentService
    {
        private readonly SweetsAssortmentRepository _sweetsAssortmentRepository;
        private readonly SweetsTypeService _sweetsTypeService;

        public SweetsAssortmentService(SweetsAssortmentRepository sweetsAssortmentRepository , SweetsTypeService sweetsTypeService)
        {
            this._sweetsTypeService = sweetsTypeService;
            this._sweetsAssortmentRepository = sweetsAssortmentRepository;
        }

        public string AddSweetsAssortment(string assortmentName, string typeId, double weight, string color)
        {
            var id = this._sweetsAssortmentRepository.AddSweetsAssortment(assortmentName, typeId, weight, color);
            return id;
        }

        public SweetsAssortment GetSweetsAssortment(string id)
        {
            var sweetsAssortment = _sweetsAssortmentRepository.GetSweetsAssortment(id);

            if (sweetsAssortment == null)
            {
                return null;
            }

            return new SweetsAssortment()
            {
                AssortmentID = sweetsAssortment.AssortmentID,
                SweetsType = _sweetsTypeService.GetSweetsType(sweetsAssortment.TypeID),
                AssortmentName = sweetsAssortment.AssortmentName,
                Weight = sweetsAssortment.Weight,
                Color = sweetsAssortment.Color
            };
        }

        public SweetsAssortment[] GenerateSweetsAssortmens(SweetsType[] sweetsTypes)
        {
            SweetsAssortment[] sweetsAssortments = new SweetsAssortment[55];
            string[] colors = new string[] {"White", "Black", "Gray", "Yellow", "Red", "YellowGreen", "YellowBlue", "Green", "Pink" };

            sweetsAssortments[0] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Київська помадка", sweetsTypes[0].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[1] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Шоколадна помадка", sweetsTypes[0].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[2] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Корiвка", sweetsTypes[1].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[3] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Прем'єра", sweetsTypes[1].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[4] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Схiд", sweetsTypes[1].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[5] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Арiя", sweetsTypes[2].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[6] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Бiлочка", sweetsTypes[2].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[7] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Чародiйка", sweetsTypes[2].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[8] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Кара-Кум", sweetsTypes[2].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[9] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Червонi вiтрила", sweetsTypes[3].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[10] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Ельбрус", sweetsTypes[3].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[11] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Трiо", sweetsTypes[3].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[12] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Абрикосовi", sweetsTypes[4].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[13] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Лiто", sweetsTypes[4].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[14] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Пiвденна нiч", sweetsTypes[4].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[15] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Блакитне озеро", sweetsTypes[5].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[16] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Абрикосовий лiкер", sweetsTypes[5].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[17] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Альбатрос", sweetsTypes[5].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[18] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Арарат", sweetsTypes[5].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[19] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Кольоровий горошок", sweetsTypes[6].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[20] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Кристал", sweetsTypes[6].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[21] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Самоцвiт", sweetsTypes[6].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[21] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Золотиста", sweetsTypes[7].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[22] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Барбарис", sweetsTypes[7].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[23] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Дюшес", sweetsTypes[7].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[24] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Рибка", sweetsTypes[8].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[25] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Спорт", sweetsTypes[8].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[26] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Турист", sweetsTypes[8].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[27] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Теремок", sweetsTypes[8].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[28] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Особливий", sweetsTypes[9].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[29] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Схiдний ", sweetsTypes[9].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[30] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Дитячий", sweetsTypes[9].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[31] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Шкiльний", sweetsTypes[10].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[32] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Вершковий", sweetsTypes[10].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[33] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Прима ", sweetsTypes[10].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[34] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Кавовий ", sweetsTypes[11].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[35] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("М'ятний ", sweetsTypes[11].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[36] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Любительський ", sweetsTypes[11].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[37] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Арахiс в глазурi Капучино", sweetsTypes[12].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[38] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Арахiс у темнiй глазурi", sweetsTypes[12].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[39] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Мигдаль у темнiй глазурi", sweetsTypes[12].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[40] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Фундук у медовiй глазурi", sweetsTypes[13].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[41] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Арахiс у медовiй глазурi", sweetsTypes[13].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[42] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Мигдаль у медовiй глазурi", sweetsTypes[13].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[43] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Мигдаль у кунжутi", sweetsTypes[14].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[44] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Фундук у кунжутi", sweetsTypes[14].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[45] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Арахiс у кунжутi", sweetsTypes[14].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[46] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Молочний шоколад з фундуком", sweetsTypes[15].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[47] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Молочний шоколад з мигдалем", sweetsTypes[15].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[48] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Молочний шоколад з арахiсом", sweetsTypes[15].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[49] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Темний шоколад з фундуком", sweetsTypes[16].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[50] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Темний шоколад з мигдалем", sweetsTypes[16].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[51] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Темний шоколад з арахiсом", sweetsTypes[16].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[52] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Бiлий шоколад з фундуком", sweetsTypes[17].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[53] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Бiлий шоколад з мигдалем", sweetsTypes[17].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));
            sweetsAssortments[54] = GetSweetsAssortment(this._sweetsAssortmentRepository.AddSweetsAssortment("Бiлий шоколад з арахiсом", sweetsTypes[17].TypeID, Math.Round(new Random().Next(1, 10) + new Random().NextDouble(),2), colors[new Random().Next(0, 9)]));

            return sweetsAssortments;
        }

        public void PrintSweetsAssortment(SweetsAssortment[] sweetsAssortment)
        {

            Console.WriteLine($"{Environment.NewLine}{"Category",-15}{"Type",-40}{"Assortment",-40}{"Weight",-40}{Environment.NewLine}");
            foreach (var item in sweetsAssortment)
            {
                Console.WriteLine($"{item.SweetsType.SweetsCategory.Category,-15}{item.SweetsType.TypeName,-40}{item.AssortmentName,-40}{item.Weight,-40} ");
            }
        }
    }
}
