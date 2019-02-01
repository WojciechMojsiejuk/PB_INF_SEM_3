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
                Wezel temp1 = a.Wyszukaj(a.korzen, substrings[i]);
                Wezel temp2 = p.Wyszukaj(p.korzen, substrings[i + 1]);
                if(temp1 == null && temp2 == null)
                {
                    try
                    {
                        rotacja = false;
                        a.WstawSlowo(ref a.korzen, substrings[i], ref rotacja);
                        rotacja = false;
                        p.WstawSlowo(ref p.korzen, substrings[i + 1], ref rotacja);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }

                    var ang = a.Wyszukaj(a.korzen, substrings[i]);
                    var pl = p.Wyszukaj(p.korzen, substrings[i + 1]);
                    ang.Tlumaczenie = pl;
                    pl.Tlumaczenie = ang;
                    Debug.WriteLine(pl.Tlumaczenie.Slowo);
                    Debug.WriteLine(ang.Tlumaczenie.Slowo);
                }
                else
                {
                    if (temp2 == null)
                    {
                        Console.WriteLine("Słowo angielskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", substrings[i]);
                        continue;
                    }
                    if (temp1 == null)
                    {
                        Console.WriteLine("Słowo polskie {0} znajduje sie juz w zbiorze, nie zostanie dodane", substrings[i + 1]);
                        continue;
                    }
                    if(temp1!=null && temp2 !=null)
                    {
                        Console.WriteLine("Słowo angielskie {0} i słowo polskie {1} znajdują sie juz w zbiorze, nie zostaną dodane", substrings[i], substrings[i + 1]);
                        continue;
                    }
                    throw new Exception("Fatal error");

                }
               
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
