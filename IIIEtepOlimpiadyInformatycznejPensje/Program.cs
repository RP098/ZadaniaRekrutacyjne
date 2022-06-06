using System;
using System.Collections.Generic;
using System.Linq;


namespace PensjaRozwiazanieWzorcoweAdamGórski
{

    class Wierzcholek
    {
        internal int pensja;
        internal int identyfikator;
        internal int numerPrzelozonego;
        internal int LiczbaPodwladnych = 0;
        public Wierzcholek(int identyfikator, int numerPrzelozonego,int pensja)
        {
            this.pensja = pensja;
            this.identyfikator = identyfikator; //numer pracownika w kolejności 
            this.numerPrzelozonego = numerPrzelozonego;
        }
        public override string ToString()
        {
            return $"{this.identyfikator } {this.pensja}";
        }

    }
    class Krawedz
    {

        internal Wierzcholek przelozony;
        internal Wierzcholek podwladny;
     
        public Krawedz() { }
        public Krawedz(Wierzcholek przelozony, Wierzcholek podwladny)
        {
            this.przelozony = przelozony;
            this.podwladny = podwladny;
        }
        public Wierzcholek WezDrugi(Wierzcholek wierzcholek)
        {
            return wierzcholek == this.przelozony ? this.podwladny : this.przelozony;
        }

        public override string ToString()
        {
            return $"{this.przelozony.identyfikator} {this.podwladny.identyfikator}";
        }
    }
    class Graf
    {
        internal static List<Krawedz> krawedzs = new List<Krawedz>();
        internal static Wierzcholek[] wierzcholek;
        internal List<Wierzcholek> odwiedzoneWierzcholki = new List<Wierzcholek>();
    }

    class Program
    {            
        static void Main(string[] args)
        {
            SortedDictionary<int, List<Krawedz>> drzewaKorzenie = new SortedDictionary<int, List<Krawedz>>(); //int to numer ojca a dalej dzieci     
            List<Wierzcholek> wierzcholeks = new List<Wierzcholek>();
            int liczba_pracownikow = int.Parse(Console.ReadLine());
            int[] dlaPensjiZwracaNumerOjca = new int[liczba_pracownikow+1];
            List<int> ojcowieDzieciZZerami = new List<int>(); //przelozeni nie zerowi
            SortedSet<int> numeryNiezerowychWierzcholkow = new SortedSet<int>();
          
            bool[] zarezerwowane = new bool[liczba_pracownikow+1];
            Graf.wierzcholek = new Wierzcholek[liczba_pracownikow+1];
            for (int i = 1; i < liczba_pracownikow + 1; i++)
            {
                var daneOpracowniku = Console.ReadLine().Split(new char[] { ' ' });
                int przelozony = int.Parse(daneOpracowniku[0]);
                int pensja = int.Parse(daneOpracowniku[1]);
                zarezerwowane[pensja] = true;
                Wierzcholek wierzcholek = new Wierzcholek(i, przelozony, pensja);
                Graf.wierzcholek[i] = wierzcholek;
                if (przelozony == i)
                    wierzcholek.pensja = liczba_pracownikow;
                if (pensja > 0)
                    numeryNiezerowychWierzcholkow.Add(i);
                else
                    wierzcholeks.Add(wierzcholek); //tylko zerowe dzieci
            }
            //budowanie drzew/krawedzi
            Graf graf = new Graf();
            int j = 0;
            foreach (var numeryNiezerowych in numeryNiezerowychWierzcholkow)
            { 
                Queue<Wierzcholek> kolejka = new Queue<Wierzcholek>();
                kolejka.Enqueue(Graf.wierzcholek[numeryNiezerowych]);
                drzewaKorzenie[Graf.wierzcholek[numeryNiezerowych].pensja] = new List<Krawedz>();
                while (kolejka.Count != 0)
                {
                    var rodzic = kolejka.Peek();
                    var wierzcholkiSosiednie = (from c in wierzcholeks where c.numerPrzelozonego==rodzic.identyfikator select c).AsParallel().ToList<Wierzcholek>();

                    foreach (var dziecko in wierzcholkiSosiednie)
                    {
                        Krawedz krawedz = new Krawedz(rodzic, dziecko);
                        drzewaKorzenie[Graf.wierzcholek[numeryNiezerowych].pensja].Add(krawedz);
                        dlaPensjiZwracaNumerOjca[Graf.wierzcholek[numeryNiezerowych].pensja] = numeryNiezerowych;
                        kolejka.Enqueue(dziecko);
                        wierzcholeks.Remove(dziecko);
                    }
                     kolejka.Dequeue();
                }
 
            }
            Queue<int> kluczeNieprzypisane = new Queue<int>();
            
            for (int i = 1; i < liczba_pracownikow+1; i++)
            {
                if (!zarezerwowane[i])
                {
                    kluczeNieprzypisane.Enqueue(i); //klucze które możemy przypisać
               
                }

            }
            //przypisywanie kluczy
            foreach (var item in drzewaKorzenie)
            {
                int wielkoscDrzewa = item.Value.Count;
                if (wielkoscDrzewa == 0)
                    continue;
                
                Stack<int> kluczePasujace = new Stack<int>();
                while(kluczeNieprzypisane.Count!=0 && kluczeNieprzypisane.Peek()<item.Key  )
                    kluczePasujace.Push(kluczeNieprzypisane.Dequeue());//tworzy zbior "m" które pasuja są mniejsze od wierzcholka drzewa

               
                if (kluczePasujace.Count<=wielkoscDrzewa)
                {
                    Queue<Wierzcholek> kolejka = new Queue<Wierzcholek>();
                    kolejka.Enqueue(Graf.wierzcholek[dlaPensjiZwracaNumerOjca[item.Key]]);
                    while (kluczePasujace.Count!=0)
                    {
                        var rodzic = kolejka.Dequeue();
                        var wierzcholkiSosiednie = (from c in item.Value where c.przelozony.identyfikator == rodzic.identyfikator select c).AsParallel().ToList<Krawedz>();
                        if (wierzcholkiSosiednie.Count > 1)
                            break;
                        if(wierzcholkiSosiednie.Count <= 1)
                        {
                            Graf.wierzcholek[wierzcholkiSosiednie[0].podwladny.identyfikator].pensja = kluczePasujace.Pop();
                        }
                        kolejka.Enqueue(wierzcholkiSosiednie[0].podwladny);
                    }

                }
                else
                {
                    while (kluczePasujace.Count != 0)
                        kluczePasujace.Pop();
                }
                if (kluczePasujace.Count > 0)
                    while (kluczePasujace.Count != 0)
                        kluczePasujace.Pop();//niejednakowe[kluczePasujace.Dequeue()] = true;

            }
           

            for (int i = 1; i < liczba_pracownikow+1; i++)
            {
                Console.WriteLine(Graf.wierzcholek[i].pensja);
            }

          Console.ReadKey();
        }
    }
}

