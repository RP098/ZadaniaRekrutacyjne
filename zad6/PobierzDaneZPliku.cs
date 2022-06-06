using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace zad6
{
    class PobierzDaneZPliku
    {
        public static List<string> pobierzDane(string nazwa)
        {
            List<string> listaNumerow = new List<string>();
            StreamReader streamReader = new StreamReader(nazwa);

            string line;
            while ((line = streamReader.ReadLine()) != null)
                listaNumerow.Add(line);

            streamReader.Close();

            return listaNumerow;
        }
    }
}
