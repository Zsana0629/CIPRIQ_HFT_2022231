using Microsoft.EntityFrameworkCore;
using System;
using CIPRIQ_HFT_2022231.Models;

namespace CIPRIQ_HFT_2022231.Repository
{
    public class PhoneDbContext : DbContext
    {
        public virtual DbSet<Country> country { get; set; }
        public virtual DbSet<Brand> brand { get; set; }
        public virtual DbSet<Phone> phone { get; set; }

        public PhoneDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            throw new NotImplementedException();
        }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>(entity =>
            {
                entity
                .HasOne(phone => phone.brand)
                .WithMany(brand => brand.Phones)
                .HasForeignKey(phone => phone.BrandID)
                .OnDelete(DeleteBehavior.Restrict);
            });

            Brand Samsung = new Brand() { Id = 1, name = "Samsung" };
            Brand Iphone = new Brand() { Id = 2, name = "Iphone" };
            Brand Huawei = new Brand() { Id = 3, name = "Huawei" };

            Phone samsung1 = new Phone() { ID = 1, BrandID = Samsung.Id, PriceCategory = "Hight", name = "Samsung S22"};
            Phone samsung2 = new Phone() { ID = 2, BrandID = Samsung.Id, PriceCategory = "Medium", name = "Samsung A53"};
            Phone Iphone1 = new Phone() { ID = 3, BrandID = Iphone.Id, PriceCategory = "Medium", name = "Iphone 11"};
            Phone Iphone2 = new Phone() { ID = 4, BrandID = Iphone.Id, PriceCategory = "Low", name = "Iphone 14"};
            Phone Huawei1 = new Phone() { ID = 5, BrandID = Huawei.Id, PriceCategory = "Low" , name = "Huawei P8"};
            Phone Huawei2 = new Phone() { ID = 6, BrandID = Huawei.Id, PriceCategory = "Hight", name = "Huawei P50"};

            modelBuilder.Entity<Brand>().HasData(Samsung, Iphone, Huawei);
            modelBuilder.Entity<Phone>().HasData(samsung1, samsung2, Iphone1, Iphone2, Huawei1, Huawei2);
        }
        
    }
}
