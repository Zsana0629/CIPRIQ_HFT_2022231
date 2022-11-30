using CIPRIQ_HFT_2022231.Models;
using ConsoleTools;
using System;

namespace CIPRIQ_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:35240/", "Phone");
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var PhoneSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Phone>())
                .Add("Create", () => crud.Create<Phone>())
                .Add("Delete", () => crud.Delete<Phone>())
                .Add("Update", () => crud.Update<Phone>())
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Brand>())
                 .Add("Create", () => crud.Create<Brand>())
                 .Add("Delete", () => crud.Delete<Brand>())
                 .Add("Update", () => crud.Update<Brand>())
                 .Add("Exit", ConsoleMenu.Close);

            var countrySubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Country>())
                 .Add("Create", () => crud.Create<Country>())
                 .Add("Delete", () => crud.Delete<Country>())
                 .Add("Update", () => crud.Update<Country>())
                 .Add("Exit", ConsoleMenu.Close);
            var statsSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("PhoneFinder", () => nonCrud.PhoneFinder())
                 .Add("Phones in Country", () => nonCrud.PhonesInCountry())
                 .Add("Country Phone Statistics", () => nonCrud.CountryPhoneStats())
                 .Add("Phone finder by ram", () => nonCrud.CountriesPhoneRam())
                 .Add("Contry Phones Average Storage", () => nonCrud.CountryPhonesAvgStorage())
                 .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Phones", () => PhoneSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Countries", () => countrySubMenu.Show())
                .Add("Non-CRUD", () => statsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
