using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace zad6
{
   public class Wyswietl
    {

        public void WyswietlZnormalizowaneNumery()
        {
            
            Normalizuj normalizuj = new Normalizuj();
            Console.WriteLine("Twoje znormalizowane numerki");
            foreach (var item in normalizuj.normalizujNumery2(PobierzDaneZPliku.pobierzDane(ConfigurationSettings.AppSettings[1])))
                Console.WriteLine(item);
        }



    }
}
