using Microsoft.EntityFrameworkCore;
using ORMHW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMHW.Contexts
{
    public class ShopDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-6I4SKCDS; Database=Shop; Trusted_Connection=true;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
    }
}
