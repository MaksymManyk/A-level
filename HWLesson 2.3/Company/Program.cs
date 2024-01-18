using Services;
using Repositories;
using Models;
using SweetGifts;
using Services;
using Repositories;
using Services.Abstractions;

namespace Company
{
    public class Program
    {
        static void Main(string[] args)
        {
            var app = new App(new SweetsCategoryService(new SweetsCategoryRepository()));
            app.Start();
        }
    }
}
