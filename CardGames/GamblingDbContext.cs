    using CardGames.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    public class GamblingDbContext : DbContext
    {
        public DbSet<User> User => Set<User>();
        public DbSet<Item> Item => Set<Item>();
        public DbSet<Inventory> Inventory => Set<Inventory>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string projectPath = Path.GetFullPath(@"..\..\..\Resources\Gambling.db");

            optionsBuilder.UseSqlite(@"Data Source =" + projectPath);

        }
    }
}
