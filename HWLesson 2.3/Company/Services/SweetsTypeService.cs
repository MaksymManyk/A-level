using Models;
using Repositories;

namespace Services
{
    public class SweetsTypeService
    {
        private readonly SweetsTypeRepository  _sweetsTypeRepository;
        private readonly SweetsCategoryService _sweetsCategoryService;

        public SweetsTypeService (SweetsTypeRepository sweetsTypeRepository, SweetsCategoryService sweetsCategoryService)
        {
           this._sweetsTypeRepository = sweetsTypeRepository;
           this._sweetsCategoryService = sweetsCategoryService;
        }

        public string AddSweetsType(string typeName, string categoryId)
        {
            var id = this._sweetsTypeRepository.AddSweetsType(typeName, categoryId);
            return id;
        }

        public SweetsType GetSweetsType(string id)
        {
            var SweetsType = _sweetsTypeRepository.SweetsType(id);

            if (SweetsType == null)
            {
               return null;
            }

            return new SweetsType()
            {
                TypeID = SweetsType.TypeID,
                TypeName = SweetsType.TypeName,
                SweetsCategory = _sweetsCategoryService.GetSweetsCategory(SweetsType.CategoryID)
            };
        }

        public SweetsType[] GenerateSweetsTypes(SweetsCategory[] sweetsCategory)
        {
            SweetsType[] sweetsTypes = new SweetsType[18];
            sweetsTypes[0] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Помаднi цукерки", sweetsCategory[0].CategoryID));
            sweetsTypes[1] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Молочнi цукерки", sweetsCategory[0].CategoryID));
            sweetsTypes[2] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Пралiновi цукерки", sweetsCategory[0].CategoryID));
            sweetsTypes[3] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Марципановi цукерки", sweetsCategory[0].CategoryID));
            sweetsTypes[4] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Фруктово-желейнi цукерки", sweetsCategory[0].CategoryID));
            sweetsTypes[5] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Лiкернi цукерки", sweetsCategory[0].CategoryID));
            sweetsTypes[6] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Карамель льодяникова вiдкрита", sweetsCategory[1].CategoryID));
            sweetsTypes[7] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Карамель льодяникова в загортцi", sweetsCategory[1].CategoryID));
            sweetsTypes[8] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Фiгурна карамель", sweetsCategory[1].CategoryID));
            sweetsTypes[9] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Литий твердий", sweetsCategory[2].CategoryID));
            sweetsTypes[10] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Тиражений м'який", sweetsCategory[2].CategoryID));
            sweetsTypes[11] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Тиражений тягучий", sweetsCategory[2].CategoryID));
            sweetsTypes[12] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("В шоколаднiй глазурi", sweetsCategory[3].CategoryID));
            sweetsTypes[13] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("В медовiй глазурi", sweetsCategory[3].CategoryID));
            sweetsTypes[14] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("В кунжутi", sweetsCategory[3].CategoryID));
            sweetsTypes[15] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Молочний шоколад", sweetsCategory[4].CategoryID));
            sweetsTypes[16] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Темний шоколад", sweetsCategory[4].CategoryID));
            sweetsTypes[17] = GetSweetsType(this._sweetsTypeRepository.AddSweetsType("Бiлий шоколад", sweetsCategory[4].CategoryID));
            return sweetsTypes;
        }
    }
}
