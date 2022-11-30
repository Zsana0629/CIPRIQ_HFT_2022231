using CIPRIQ_HFT_2022231.Logic.Classes;
using CIPRIQ_HFT_2022231.Models;
using CIPRIQ_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Tests
    {
        CountryLogic countryLogic;
        PhoneLogic phoneLogic;
        BrandLogic brandLogic;
        Mock<IRepository<Country>> countryMock;
        Mock<IRepository<Brand>> brandMock;
        Mock<IRepository<Phone>> phoneMock;
        Country country1;
        Country country2;
        Brand brand;
        Brand brand2;
        Phone phone;
        Phone phone1;

        [SetUp]
        public void Init()//másold át az egészet egy új Nunittesztbe
        {
            countryMock = new Mock<IRepository<Country>>();
            phoneMock = new Mock<IRepository<Phone>>();
            brandMock = new Mock<IRepository<Brand>>();
            country1 = new Country() { name = "Korea" }; country2 = new Country() { name = "USA" };
            brand = new Brand() { name = "Samsung", CountryID = country1.ID }; brand2 = new Brand() { name = "Apple", CountryID = country2.ID };
            phone = new Phone() { name = "S22", BrandID = brand.Id, brand = brand, Price = 50000, PriceCategory = "High", RAM = 16, Storage = 256 };
            phone1 = new Phone() { name = "Iphone 11", BrandID = brand2.Id, brand = brand2, Price = 55000, PriceCategory = "High", RAM = 16, Storage = 100 };
            List<Country> list = new List<Country>() { country1, country2 };
            List<Brand> list2 = new List<Brand>() { brand, brand2 };
            List<Phone> list3 = new List<Phone>() { phone, phone1 };
            country1.Brands.Add(brand);
            country2.Brands.Add(brand2);
            brand.Phones.Add(phone); brand2.Phones.Add(phone1);
            countryMock.Setup(c => c.ReadAll()).Returns(list.AsQueryable());
            brandMock.Setup(c => c.ReadAll()).Returns(list2.AsQueryable());
            phoneMock.Setup(c => c.ReadAll()).Returns(list3.AsQueryable());
            countryLogic = new CountryLogic(countryMock.Object);
            phoneLogic = new PhoneLogic(phoneMock.Object);
            brandLogic = new BrandLogic(brandMock.Object);

        }

        [Test]
        public void PhoneFinderTest()
        {
            var test = countryLogic.PhoneFinder("Iphone 11");
            string valami = test.name;
            Assert.That(test.name, Is.EqualTo("USA"));
        }
        [Test]
        public void CountryPhoneStatsTest()
        {
            var test = countryLogic.CountryPhoneStats();
            Assert.That(test, Has.Exactly(2).Items);
        }
        [Test]
        public void CountriesPhoneRamTest()
        {
            var test = countryLogic.CountriesPhoneRam(10);
            Assert.That(test, Has.Exactly(2).Items);
        }
        [Test]
        public void CountryPhonesAvgStorageTest()
        {
            var test = countryLogic.CountryPhonesAvgStorage("USA");
            Assert.That(test, Is.EqualTo(100));
        }
        [Test]
        public void PhonesInCountryTest()
        {
            var test = countryLogic.PhonesInCountry("Korea");
            Assert.That(test, Has.Exactly(1).Items);
        }

        [Test]
        public void CountryCreateTest()
        {
            Country country = new Country() { name = "" };
            Assert.Throws<FormatException>(() =>
            {
                countryLogic.Create(country);
            });
            countryMock.Verify(x => x.Create(country), Times.Never);
        }
        [Test]
        public void CountryReadAllTest()
        {
            var countries = countryLogic.ReadAll();
            Assert.That(countries.Count() > 1);
        }
        [Test]
        public void PhonesReadAll()
        {
            var phones = phoneLogic.ReadAll();
            Assert.That(phones.Count() < 3);
        }
    }
}