using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad6
{
    class Normalizuj
    {
       
        public List<string> normalizujNumery2(List<string> numeryNormalizacja, int numerKierunkowy = 48, char znaczekZprzodu = '+')
        {
            List<string> numeryZnormalizowane = new List<string>();
            string kierunkowy = numerKierunkowy.ToString();
            string[] znormalizowane = new string[12];
            znormalizowane[0] = znaczekZprzodu.ToString();
            znormalizowane[1] = kierunkowy[0].ToString();
            znormalizowane[2] = kierunkowy[1].ToString();
            foreach (var item in numeryNormalizacja)
            {
               
                int koniecCiagu = item.Length - 1;
                int j = 0;
                for (int i = 0; i < koniecCiagu + 1; i++)
                {
                    if (j == 9)
                        break;
                    if (char.IsNumber(item[koniecCiagu - i]))
                    {
                        znormalizowane[11-j] = item[koniecCiagu - i].ToString();
                        j++;
                    }
                    else
                        continue;
                }
                string znormalizowanyCiag = "";
                foreach (string item2 in znormalizowane)
                {
                    znormalizowanyCiag += item2;
                }
                numeryZnormalizowane.Add(znormalizowanyCiag);
            }
            return numeryZnormalizowane;
        }
    }
}
