using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Product2Context : DbContext
    {
        public DbSet<ProductModel> TableProduct { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Database=CqrsProduct2;Trusted_Connection=True;TrustServerCertificate=True;");
                // Bu örnekte SQL Server kullanılıyor, kendi veritabanı türünüze göre değiştirebilirsiniz.
            }
        }
    }
}
