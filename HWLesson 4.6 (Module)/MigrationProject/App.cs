using Services.Abstractions;

namespace CRUDModuleProject
{
    public class App
    {
        private readonly ICategoryService  _categorService;

        private readonly ILocationService _locationService;

        private readonly IBreedService _breedService;

        private readonly IPetService _petService;

        public App(ICategoryService categorService, ILocationService locationService, IBreedService breedService, IPetService petService)
        {
            _categorService = categorService;
            _locationService = locationService;
            _breedService = breedService;
            _petService = petService;
        }

        public async Task Start()
        {
            await GenerateData();

            await _petService.PrintAllPets();

            var categoryCount = await _petService.GetCategoryCount();

            foreach(var category in categoryCount) { Console.WriteLine($"{category.CategoryName} {category.Count}"); }
        }

        public async Task GenerateData()
        {
            await GenerateCategoryAsync();
            await GenerateLocationAsync();
            await GenerateBreedAsync();
            await GeneratePetAsync();
        }

        public async Task GenerateBreedAsync()
        {
            var breeds = await _breedService.GetBreedAsync();

            if (breeds == null)
            {
                var categoryCat = await _categorService.GetCategoryAsync("Cat");
                var categoryDog = await _categorService.GetCategoryAsync("Dog");
                var categoryHorse = await _categorService.GetCategoryAsync("Horse");
                var categoryFox = await _categorService.GetCategoryAsync("Fox");
                var categoryPig = await _categorService.GetCategoryAsync("Pig");

                await _breedService.AddBreedAsync(categoryDog.CategoryID, "Mastiff");
                await _breedService.AddBreedAsync(categoryDog.CategoryID, "Doberman");
                await _breedService.AddBreedAsync(categoryDog.CategoryID, "Rottweiler");
                await _breedService.AddBreedAsync(categoryCat.CategoryID, "Persian");
                await _breedService.AddBreedAsync(categoryCat.CategoryID, "Siamese");
                await _breedService.AddBreedAsync(categoryCat.CategoryID, "Bengal");
                await _breedService.AddBreedAsync(categoryHorse.CategoryID, "Arabian");
                await _breedService.AddBreedAsync(categoryHorse.CategoryID, "Pony");
                await _breedService.AddBreedAsync(categoryHorse.CategoryID, "Mustang");
                await _breedService.AddBreedAsync(categoryFox.CategoryID, "Red Fox");
                await _breedService.AddBreedAsync(categoryFox.CategoryID, "Fenec");
                await _breedService.AddBreedAsync(categoryPig.CategoryID, "Landras");
            }
        }

        public async Task GeneratePetAsync()
        {
            var pets = await _petService.GetPetAsync();

            if (pets == null)
            {
                var mastiff = await _breedService.GetBreedAsync("Mastiff");
                var doberman = await _breedService.GetBreedAsync("Doberman");
                var rottweiler = await _breedService.GetBreedAsync("Rottweiler");
                var persian = await _breedService.GetBreedAsync("Persian");
                var siamese = await _breedService.GetBreedAsync("Siamese");
                var bengal = await _breedService.GetBreedAsync("Bengal");
                var arabian = await _breedService.GetBreedAsync("Arabian");
                var pony = await _breedService.GetBreedAsync("Pony");
                var mustang = await _breedService.GetBreedAsync("Mustang");
                var redFox = await _breedService.GetBreedAsync("Red Fox");
                var fenec = await _breedService.GetBreedAsync("Fenec");
                var landras = await _breedService.GetBreedAsync("Landras");

                var ukr = await _locationService.GetLocationAsync("Ukraine");
                var deu = await _locationService.GetLocationAsync("Germany");
                var fra = await _locationService.GetLocationAsync("France");
                var ita = await _locationService.GetLocationAsync("Italy");

                await _petService.AddPetAsync("Bob", mastiff.Category.CategoryID , mastiff.BreedID, 2, ukr.Id, "Friends dog", "non url");
                await _petService.AddPetAsync("Kira", persian.Category.CategoryID, persian.BreedID, 3, ukr.Id, "My Cat" );
                await _petService.AddPetAsync("Chack", doberman.Category.CategoryID, mastiff.BreedID, 6, ukr.Id);
                await _petService.AddPetAsync("Luky", mustang.Category.CategoryID, mustang.BreedID, 9, ita.Id, "Champion");
                await _petService.AddPetAsync("Red", fenec.Category.CategoryID, fenec.BreedID, 2, deu.Id, "Fox");
                await _petService.AddPetAsync("Pigi", landras.Category.CategoryID, landras.BreedID, 1, fra.Id, "Becon", "non url");
                await _petService.AddPetAsync("Kleopatra", siamese.Category.CategoryID, siamese.BreedID, 6, ukr.Id);
                await _petService.AddPetAsync("Gnome", pony.Category.CategoryID, pony.BreedID, 2, fra.Id, "Pony", "non url");
                await _petService.AddPetAsync("Gvard", rottweiler.Category.CategoryID, rottweiler.BreedID, 5, ukr.Id, "Gvardian");
                await _petService.AddPetAsync("Booky", redFox.Category.CategoryID, redFox.BreedID, 2, deu.Id);
            }
        }

        public async Task GenerateCategoryAsync()
        {
            var categories = await _categorService.GetCategoryAsync();

            if (categories == null)
            {
                 await _categorService.AddCategoryAsync("Cat");
                 await _categorService.AddCategoryAsync("Dog");
                 await _categorService.AddCategoryAsync("Horse");
                 await _categorService.AddCategoryAsync("Fox");
                 await _categorService.AddCategoryAsync("Pig");
            }
        }

        public async Task GenerateLocationAsync()
        {
            var locations = await _locationService.GetLocationAsync();

            if (locations == null)
            {
                await _locationService.AddLocationAsync("Ukraine");
                await _locationService.AddLocationAsync("Germany");
                await _locationService.AddLocationAsync("France");
                await _locationService.AddLocationAsync("Italy");
            }
        }
    }
}
