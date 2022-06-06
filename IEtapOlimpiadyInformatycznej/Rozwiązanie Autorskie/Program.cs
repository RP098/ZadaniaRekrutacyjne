using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AdamGórskiPlakatowanie
{
    class Program
    {
        int najwyzszy_Budynek = 0;
        int najnizszy_Budynek = 0;
        int liczba_budynkow = 0;
        int liczba_plakatow = 1;
        int [] tablica_wysokosci_budynkow;
        static void Main()
        {
            
            Program program = new Program();
         
            program.liczba_budynkow = Convert.ToInt32(Console.ReadLine());
        
            program.tablica_wysokosci_budynkow = new int[program.liczba_budynkow+1];
            for (int i = 0; i < program.liczba_budynkow; i++)
            {
                var podzielone =Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                program.tablica_wysokosci_budynkow[i] = int.Parse(podzielone[1]);
            }

            program.znajdzNajwyzszyBudynek();
            program.znajdzNajnizszyBudynek();
            program.obetnijDol(); //0 to odstepy na następnym poziomie
            program.znajdzNajwyzszyBudynek();
            program.znajdzNajnizszyBudynek();
            if ((program.najwyzszy_Budynek - program.najnizszy_Budynek) == 0)
            {
                Console.WriteLine(program.liczba_plakatow); //wtedy gdy jest jeden budynek
            }
            else
            {
                int ile = program.najwyzszy_Budynek - program.najnizszy_Budynek;
                for (int i = 0; i <= ile; i++)
                {
                    for (int j = 0; j < program.liczba_budynkow; j++)
                    {
                        if (program.tablica_wysokosci_budynkow[j] == program.najnizszy_Budynek)
                        {
                            program.liczba_plakatow++;
                            for (int k = j+1; k < program.liczba_budynkow; k++)
                            {
                                if (0 == program.tablica_wysokosci_budynkow[k])
                                {
                                    j = k;
                                    break;
                                }
                            }
                        }
                    }
                    program.obetnijDol();
                    program.znajdzNajwyzszyBudynek();
                    program.znajdzNajnizszyBudynek();
                   
                }
            }


            Console.WriteLine(program.liczba_plakatow);
           // Console.ReadKey();
        }

        private void obetnijDol()
        {
            for (int i = 0; i < liczba_budynkow; i++)
            {
                if(tablica_wysokosci_budynkow[i]!=0)
                    tablica_wysokosci_budynkow[i] -= najnizszy_Budynek;
            }
        }

    
         void znajdzNajwyzszyBudynek()
        {
            najwyzszy_Budynek = 0;
            for (int i = 0; i < liczba_budynkow; i++)
            {
                if (tablica_wysokosci_budynkow[i] > najwyzszy_Budynek)
                {
                    najwyzszy_Budynek = tablica_wysokosci_budynkow[i];
                }
            }
        }

        void znajdzNajnizszyBudynek()
        {
            najnizszy_Budynek = najwyzszy_Budynek;
            for (int i = 0; i < liczba_budynkow; i++)
            {
                if (tablica_wysokosci_budynkow[i] < najnizszy_Budynek && tablica_wysokosci_budynkow[i]!=0)
                {
                    najnizszy_Budynek = tablica_wysokosci_budynkow[i];
                }
            }
        }


      

    }
}
