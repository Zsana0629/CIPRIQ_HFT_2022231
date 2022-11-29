using CIPRIQ_HFT_2022231.Models;
using System;

namespace CIPRIQ_HFT_2022231.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:33531/", typeof(Phone).Name);
            CrudService crud = new CrudService(rest);
            NonCrudService nonCrud = new NonCrudService(rest);

            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => crud.List<Car>())
                .Add("Create", () => crud.Create<Car>())
                .Add("Delete", () => crud.Delete<Car>())
                .Add("Update", () => crud.Update<Car>())
                .Add("Exit", ConsoleMenu.Close);

            var brandSubMenu = new ConsoleMenu(args, level: 1)
                 .Add("List", () => crud.List<Brand>())
                 .Add("Create", () => crud.Create<Brand>())
                 .Add("Delete", () => crud.Delete<Brand>())
                 .Add("Update", () => crud.Update<Brand>())
                 .Add("Exit", ConsoleMenu.Close);

            var statsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Average car price", () => nonCrud.AvgCarPrice())
                .Add("Brand statistics", () => nonCrud.ReadBrandStats())
                .Add("Cars by Price range", () => nonCrud.GetCarsByPriceRange())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Cars", () => carSubMenu.Show())
                .Add("Brands", () => brandSubMenu.Show())
                .Add("Non-CRUD", () => statsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
