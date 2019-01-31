using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AVL
{
    class IOManager
    {
        StreamReader sr;
        StreamWriter wr;
        bool wrInitialised = false;
        public void WczytajSlowa(DrzewoAngielskie a, DrzewoPolskie p)
        {
            sr = new StreamReader("InOut0401.txt");
            string s = sr.ReadToEnd();
            sr.Close();
			bool rotacja = false;

			string[] substrings = s.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0;i<substrings.Count();i+=2)
            {
                a.CzyWywazone = false;
                p.CzyWywazone = false;
                rotacja = false;
                Debug.WriteLine("\t i={0}, substrings[i]={1}", i, substrings[i]);
                if(a.Wyszukaj(a.korzen, substrings[i]) != null)
                {
                    if (substrings[i].CompareTo(a.Wyszukaj(a.korzen, substrings[i]).Slowo) == 0)
                    {
                        Console.WriteLine("Słowo angielskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", substrings[i]);
                        continue;
                    }
                }

                if(p.Wyszukaj(p.korzen, substrings[i + 1])!=null)
                {
                    if (substrings[i + 1].CompareTo(p.Wyszukaj(p.korzen, substrings[i + 1]).Slowo) == 0)
                    {
                        Console.WriteLine("Słowo polskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", substrings[i + 1]);
                        continue;
                    }
                }

                try 
                {
                    a.WstawSlowo(ref a.korzen, substrings[i], ref rotacja);
                    p.WstawSlowo(ref p.korzen, substrings[i + 1], ref rotacja);

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                var ang = a.Wyszukaj(a.korzen, substrings[i]);
                rotacja = false;
				var pl = p.Wyszukaj(p.korzen, substrings[i + 1]);
                ang.Tlumaczenie = pl;
                pl.Tlumaczenie = ang;
                Debug.WriteLine(pl.Tlumaczenie.Slowo);
                Debug.WriteLine(ang.Tlumaczenie.Slowo);
            }
        }
        public void WypiszSlowa(Wezel korzen)
        {
            if (!wrInitialised)
            {
                wr = new StreamWriter("InOut0401.txt");
                wrInitialised = true;
            }
            if (korzen == null)
                return;
            if (korzen.Tlumaczenie == null)
                Console.WriteLine("Brak tlumaczenia dla {0}, nie zostało ono wypisane w pliku wyjsciowym", korzen.Slowo);
            else
                wr.WriteLine("{0} {1}", korzen.Slowo, korzen.Tlumaczenie.Slowo);
            if (korzen.Lewy != null)
            {
                WypiszSlowa(korzen.Lewy);
                //Console.WriteLine(korzen.Lewy.Slowo);
            }
            //if (korzen.Tlumaczenie == null)
            //    throw new Exception("Brak tlumaczenia");
            //else
            if (korzen.Prawy != null)
            {
                WypiszSlowa(korzen.Prawy);
            }
        }
        public void closeStreamWriter()
        {
            if(wr != null)
            {
                this.wr.Close();
                wrInitialised = false;
            }
        }
    }
}
