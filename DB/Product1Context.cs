using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Product1Context : DbContext
    {
        public DbSet<ProductModel> TableProduct { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Database=CqrsProduct;Trusted_Connection=True;TrustServerCertificate=True;");
                // Bu örnekte SQL Server kullanılıyor, kendi veritabanı türünüze göre değiştirebilirsiniz.
            }
        }
    }
    //public class TableProduct
    //{
    //    public int Id { get; set; }
    //    public string ProductName { get; set; }
    //    public string ProductCode { get; set; }
    //    public int Stock { get; set; }
    //    public decimal Amount { get; set; }
    //}
}
