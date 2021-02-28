using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{   
    // İlişkinelndirme yapabilmek için context oluştururuz. 
    //Context: Db tabloları ile proje classlarını bağlamayı sağlar.
    public class NorthwindContext:DbContext
    {
        // Metod projemizin hangi veri tabanıyla ilişkiliyi belirttiğimiz yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Trusted_Connection ;Kullancı adı şifre gerekemz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocalDb;Database=Northwind;Trusted_Connection=true");
           
        }
        //Hangi nesne hangi nesneye karşılık gelir?
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer>  Customers{ get; set; }

    }
}
