using CIPRIQ_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPRIQ_HFT_2022231.Client
{
    public class NonCrudService
    {
        RestService restService;
        public NonCrudService(RestService restService)
        {
            this.restService = restService;
        }
        public void PhoneFinder()
        {
            Console.WriteLine("Enter the phone you want:");
            string name = Console.ReadLine();
            var item = restService.GetSingle<Country>($"Stat/PhoneFinder?input={name}");
            Console.WriteLine(item);
            Console.ReadLine();
        }

        public void CountryPhoneStats()
        {
            var items = restService.Get<CountryStat>($"Stat/CountryPhoneStats");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void CountriesPhoneRam()
        {
            Console.WriteLine("Ram:");
            int input = int.Parse(Console.ReadLine());
            var items = restService.Get<Country>($"Stat/CountriesPhoneRam?ram={input}");
            foreach (var item in items) Console.WriteLine(item);
            Console.ReadLine();
        }

      

        public void PhonesInCountry()
        {
            Console.WriteLine("Country:");
            string input = Console.ReadLine();
            var items = restService.Get<Country>($"Stat/PhonesInCountry?input={input}");
            foreach (var item in items) Console.WriteLine(item);
            Console.ReadLine();
        }



        public void CountryPhonesAvgStorage()
        {
            Console.WriteLine("Country:");
            string input = Console.ReadLine();
            var item = restService.GetSingle<double>($"Stat/CountryPhonesAvgStorage?name={input}");
           Console.WriteLine(item);
            Console.ReadLine();
        }


    }
}

