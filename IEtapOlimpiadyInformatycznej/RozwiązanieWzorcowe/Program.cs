using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlakatowanieRedundatne
{
    class Program
    {

    
        static int liczba_budynkow = 0;
        static int liczba_plakatow = 0;
        static int [] Budynki ;
        static void Main(string[] args)
        {
            Stack<int> stos = new Stack<int>();
            liczba_budynkow = int.Parse(Console.ReadLine());
            Budynki = new int[liczba_budynkow];
            for (int i = 0; i < liczba_budynkow; i++)
            {
                Budynki[i] = int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);
            }

            for (int i = 0; i < liczba_budynkow; i++)
            {
          
                while (stos.Count!=0 && stos.First() > Budynki[i])
                {
                    stos.Pop();
                   
                }

                if (stos.Count == 0 || stos.First() < Budynki[i])
                {
                    stos.Push(Budynki[i]);
                    liczba_plakatow++;
                }
            }
             
               
               
               
           
            
            Console.WriteLine(liczba_plakatow);

        
        }
    }
}
