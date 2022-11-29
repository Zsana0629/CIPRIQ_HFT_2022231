using Microsoft.EntityFrameworkCore;
using System;
using CIPRIQ_HFT_2022231.Models;
using System.Collections.Generic;

namespace CIPRIQ_HFT_2022231.Repository
{
    public class PhoneDbContext : DbContext
    {
        public virtual DbSet<Country> countries { get; set; }
        public virtual DbSet<Brand> brands { get; set; }
        public virtual DbSet<Phone> phones { get; set; }

        public PhoneDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PhoneDb");
            base.OnConfiguring(optionsBuilder);
            //throw new NotImplementedException();
        }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<Phone>().HasOne(t => t.brand).WithMany(t => t.Phones).HasForeignKey(t => t.BrandID);
            modelBuilder.Entity<Brand>().HasOne(t => t.country).WithMany(t => t.Brands).HasForeignKey(t => t.CountryID);

            Country Korea = new Country() { ID = 1, name = "Korea" };
            Country USA = new Country() { ID = 2, name = "USA" };
            Country China = new Country() { ID = 3, name = "China" };

            Brand Samsung = new Brand() { Id = 1, name = "Samsung",CountryID = Korea.ID};
            Brand Apple = new Brand() { Id = 2, name = "Apple",CountryID=USA.ID};
            Brand Huawei = new Brand() { Id = 3, name = "Huawei",CountryID = China.ID};

            Phone samsung1 = new Phone() { ID = 1, BrandID = Samsung.Id, PriceCategory = "Hight", Price=400000, name = "Samsung S22"};
            Phone samsung2 = new Phone() { ID = 2, BrandID = Samsung.Id, PriceCategory = "Medium",Price = 170000, name = "Samsung A53"};
            Phone Iphone1 = new Phone() { ID = 3, BrandID = Apple.Id, PriceCategory = "Medium", Price = 250000, name = "Iphone 11"};
            Phone Iphone2 = new Phone() { ID = 4, BrandID = Apple.Id, PriceCategory = "Low", Price = 700000, name = "Iphone 14"};
            Phone Huawei1 = new Phone() { ID = 5, BrandID = Huawei.Id, PriceCategory = "Low", Price = 40000, name = "Huawei P8"};
            Phone Huawei2 = new Phone() { ID = 6, BrandID = Huawei.Id, PriceCategory = "Hight", Price = 340000, name = "Huawei P50"};

            modelBuilder.Entity<Brand>().HasData(Samsung, Apple, Huawei);
            modelBuilder.Entity<Phone>().HasData(samsung1, samsung2, Iphone1, Iphone2, Huawei1, Huawei2);
            modelBuilder.Entity<Country>().HasData(Korea,USA,China);
        }
        
    }
}
