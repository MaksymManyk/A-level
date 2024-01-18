using Models;
using Repositories;

namespace Services
{
    public class SweetsCategoryService
    {
        private readonly SweetsCategoryRepository _sweetsCategoryRepository;

        public SweetsCategoryService(SweetsCategoryRepository sweetsCategoryRepository)
        {
            this._sweetsCategoryRepository = sweetsCategoryRepository;
        }

        public string AddCategoryType(string categoryName)
        {
            var id = this._sweetsCategoryRepository.AddSweetsCategory(categoryName);
            return id;
        }

        public SweetsCategory GetSweetsCategory(string id)
        {
            var sweetsCategory = _sweetsCategoryRepository.GetSweetsCategory(id);

            if (sweetsCategory == null)
            {
                return null;
            }

            return new SweetsCategory()
            {
                CategoryID = sweetsCategory.CategoryID,
                Category = sweetsCategory.Category
            };
        }

        public SweetsCategory[] GenerateSweetsCategory()
        {
            SweetsCategory[] sweetsCategory = new SweetsCategory[5];
            sweetsCategory[0] = GetSweetsCategory(this._sweetsCategoryRepository.AddSweetsCategory("Цукерки"));
            sweetsCategory[1] = GetSweetsCategory(this._sweetsCategoryRepository.AddSweetsCategory("Карамель"));
            sweetsCategory[2] = GetSweetsCategory(this._sweetsCategoryRepository.AddSweetsCategory("Iрис"));
            sweetsCategory[3] = GetSweetsCategory(this._sweetsCategoryRepository.AddSweetsCategory("Драже"));
            sweetsCategory[4] = GetSweetsCategory(this._sweetsCategoryRepository.AddSweetsCategory("Шоколадки"));
            return sweetsCategory;
        }
    }
}
