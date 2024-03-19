using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath (Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            optionBuilder.UseSqlServer (connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new AppDbContext(optionBuilder.Options);
        }
    }
}
