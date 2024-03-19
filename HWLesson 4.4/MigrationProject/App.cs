using Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationProject
{
    public class App
    {
        private readonly AppDbContext _dbContext;

        public App(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Start()
        {
            var data = await _dbContext.Pets.ToListAsync();
        }
    }
}
