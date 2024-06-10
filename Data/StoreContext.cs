using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreProject.Data;
using StoreProject.Models;
using Microsoft.EntityFrameworkCore;


namespace StoreProject.Data
{
    public class StoreContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=store;Trusted_Connection=True;");
        }

    }
}
