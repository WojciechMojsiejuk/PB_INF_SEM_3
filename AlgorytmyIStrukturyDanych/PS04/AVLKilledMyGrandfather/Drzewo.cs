using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AVL
{
    class Drzewo
    {
        bool czyWywazone = false;
        public Wezel korzen;

        public bool CzyWywazone { get => czyWywazone; set => czyWywazone = value; }

        //public virtual object korzen { get; set; }

        public void LL(ref Wezel element)
        {
            //zmiana pozycji
            Wezel A = element;
            element = A.Prawy;
            Wezel II = element.Lewy;
            element.Lewy = A;
            element.Lewy.Prawy = II;
        }

        public void RR(ref Wezel element)
        {
            //zmiana pozycji
            Wezel A = element;
            element = A.Lewy;
            Wezel II = element.Prawy;
            element.Prawy = A;
            element.Prawy.Lewy = II;
        }

        /// <summary>
        /// Wypisuje oba drzewa korzystajac z przypisanych tlumaczen wraz z wagami
        /// </summary>
        /// <param name="korzen"></param>
        public void WypiszDrzewoKLP(Wezel korzen)
        {
            if (korzen == null)
                return;
            Console.WriteLine("slowo: {0} {1}\ttlumaczenie: {2} {3}", korzen.Slowo, korzen.Waga, korzen.Tlumaczenie.Slowo, korzen.Tlumaczenie.Waga);
            if (korzen.Lewy != null)
            {
                WypiszDrzewoKLP(korzen.Lewy);
            }
            if (korzen.Prawy != null)
            {
                WypiszDrzewoKLP(korzen.Prawy);
            }
        }

        public void WypiszDrzewo(Wezel korzen)
        {
            if (korzen == null)
                return;
            Console.WriteLine(korzen.Slowo);
            if (korzen.Lewy != null)
            {
                WypiszDrzewo(korzen.Lewy);
                //Console.WriteLine(korzen.Lewy.Slowo);
            }
            if (korzen.Prawy != null)
            {
                WypiszDrzewo(korzen.Prawy);
            }
        }
        public Wezel Wyszukaj(Wezel korzen, string slowo)
        {
            // Base Cases: root is null or key is present at root   
            if (korzen == null || slowo.CompareTo(korzen.Slowo) == 0)
                return korzen;
            //return null;  
            // Key is greater than root's key   
            if (korzen.Slowo.CompareTo(slowo) < 0)
                return Wyszukaj(korzen.Prawy, slowo);
            //Key is smaller than root's key    
            return Wyszukaj(korzen.Lewy, slowo);
        }

        public Wezel WyszukajNastepnika(Wezel korzen)
        {
            Wezel nastepca = korzen.Prawy;
            while (nastepca.Lewy != null)
            {
                nastepca = nastepca.Lewy;
            }
            return nastepca;
        }

        public void UsunSlowo(ref Wezel korzen, string slowo, ref bool ZnalezionoElement, ref bool DrzewoWywazone, ref Wezel tlumaczenia, Drzewo przeciwne)
        {
            Wezel obj = null;
            //Wyszukaj powinno zwracac czy slowo nieistnieje
            if (korzen == null)
            {
                throw new Exception("Nie znaleziono slowa");
            }
            if (slowo.CompareTo(korzen.Slowo) == 0)
            {
                //Przypadek gdy element ktory chcemy usunac jest korzeniem
                if (korzen == this.korzen)
                {
                    if (korzen.Prawy == null && korzen.Lewy == null)
                    {
                        //przypadek gdy usuwany element jest lisciem
                        string tlumaczenie = korzen.Tlumaczenie.Slowo;
                        korzen = null;
                        this.korzen = korzen;
                        if (tlumaczenia != null)
                        {
                            bool znaleziony = false;
                            bool wywazone = false;
                            przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);
                        }
                        return;
                    }
                    if (korzen.Prawy == null && korzen.Lewy != null)
                    {

                        Wezel temp = korzen;
                        string tlumaczenie = temp.Tlumaczenie.Slowo;
                        korzen = temp.Lewy;
                        if (tlumaczenia != null)
                        {
                            bool znaleziony = false;
                            bool wywazone = false;
                            przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);

                        }
                        return;
                    }
                    if (korzen.Prawy != null && korzen.Lewy == null)
                    {
                        Wezel temp = korzen;
                        string tlumaczenie = temp.Tlumaczenie.Slowo;
                        korzen = temp.Prawy;
                        if (tlumaczenia != null)
                        {

                            bool znaleziony = false;
                            bool wywazone = false;
                            przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);

                        }
                        return;
                    }
                    if (korzen.Prawy != null && korzen.Lewy != null)
                    {
                        Wezel temp = korzen;
                        Wezel tlumaczenieDoUsuniecia = temp.Tlumaczenie;
                        Wezel nastepnik = WyszukajNastepnika(temp);
                        Wezel nowapozycjaTlumaczenie = nastepnik.Tlumaczenie;
                        string nowapozycjaSlowo = nastepnik.Slowo;
                        nastepnik.Tlumaczenie = tlumaczenieDoUsuniecia;
                        bool znaleziony = false;
                        bool wywazone = false;
                        UsunSlowo(ref temp, nastepnik.Slowo, ref znaleziony, ref wywazone, ref tlumaczenia, przeciwne);
                        temp.Slowo = nowapozycjaSlowo;
                        temp.Tlumaczenie = nowapozycjaTlumaczenie;
                        korzen = temp;
                        return;

                    }
                }
                //Jeżeli usuwamy element z dwoma synami musimy poczekać z usuwaniem dopóki nie usuniemy następnika
                if (korzen.Lewy != null && korzen.Prawy != null)
                    DrzewoWywazone = true;
                ZnalezionoElement = true;
                return;
            }
            // Key is greater than root's key   
            if (slowo.CompareTo(korzen.Slowo) < 0)
            {
                Wezel lewy = korzen.Lewy;
                bool element = ZnalezionoElement;
                bool wywazenie = DrzewoWywazone;
                UsunSlowo(ref lewy, slowo, ref element, ref wywazenie, ref tlumaczenia, przeciwne);
                korzen.Lewy = lewy;
                DrzewoWywazone = wywazenie;
                ZnalezionoElement = element;
                if (!DrzewoWywazone)
                {
                    korzen.Waga--;
                    if (korzen.Waga == -1 || korzen.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }
                }
            }
            if (ZnalezionoElement)
            {
                ZnalezionoElement = false;
                if (korzen.Lewy.Prawy == null && korzen.Lewy.Lewy == null)
                {
                    //przypadek gdy usuwany element jest lisciem
                    string tlumaczenie = korzen.Lewy.Tlumaczenie.Slowo;
                    korzen.Lewy = null;
                    if (tlumaczenia != null)
                    {
                        bool znaleziony = false;
                        bool wywazone = false;
                        przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);
                    }
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }
                }
                else if (korzen.Lewy.Prawy == null && korzen.Lewy.Lewy != null)
                {

                    Wezel temp = korzen.Lewy;
                    string tlumaczenie = temp.Tlumaczenie.Slowo;
                    korzen.Lewy = temp.Lewy;
                    if (tlumaczenia != null)
                    {
                        bool znaleziony = false;
                        bool wywazone = false;
                        przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);

                    }
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }
                }
                else if (korzen.Lewy.Prawy != null && korzen.Lewy.Lewy == null)
                {
                    Wezel temp = korzen.Lewy;
                    string tlumaczenie = temp.Tlumaczenie.Slowo;
                    korzen.Lewy = temp.Prawy;
                    if (tlumaczenia != null)
                    {

                        bool znaleziony = false;
                        bool wywazone = false;
                        przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);

                    }
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }
                }
                else if (korzen.Lewy.Prawy != null && korzen.Lewy.Lewy != null)
                {
                    Wezel temp = korzen.Lewy;
                    Wezel tlumaczenieDoUsuniecia = temp.Tlumaczenie;
                    Wezel nastepnik = WyszukajNastepnika(temp);
                    Wezel nowapozycjaTlumaczenie = nastepnik.Tlumaczenie;
                    string nowapozycjaSlowo = nastepnik.Slowo;
                    nastepnik.Tlumaczenie = tlumaczenieDoUsuniecia;
                    bool znaleziony = false;
                    bool wywazone = false;
                    UsunSlowo(ref temp, nastepnik.Slowo, ref znaleziony, ref wywazone, ref tlumaczenia, przeciwne);
                    temp.Slowo = nowapozycjaSlowo;
                    temp.Tlumaczenie = nowapozycjaTlumaczenie;
                    korzen.Lewy = temp;
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }

                }
            }
            //Key is smaller than root's key
            if (slowo.CompareTo(korzen.Slowo) > 0)
            {
                Wezel prawy = korzen.Prawy;
                bool element = ZnalezionoElement;
                bool wywazenie = DrzewoWywazone;
                UsunSlowo(ref prawy, slowo, ref element, ref wywazenie, ref tlumaczenia, przeciwne);
                korzen.Prawy = prawy;
                DrzewoWywazone = wywazenie;
                ZnalezionoElement = element;
                if (!DrzewoWywazone)
                {
                    korzen.Waga++;
                    if (korzen.Waga == -1 || korzen.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }
                }
            }
            //Usuwanie znalezionego elementu
            if (ZnalezionoElement)
            {
                ZnalezionoElement = false;
                if (korzen.Prawy.Prawy == null && korzen.Prawy.Lewy == null)
                {
                    //przypadek gdy usuwany element jest lisciem
                    string tlumaczenie = korzen.Prawy.Tlumaczenie.Slowo;
                    korzen.Prawy = null;
                    if (tlumaczenia != null)
                    {
                        bool znaleziony = false;
                        bool wywazone = false;
                        przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);
                    }
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -1 || korzen.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }
                }
                else if (korzen.Prawy.Prawy == null && korzen.Prawy.Lewy != null)
                {
                    Wezel temp = korzen.Prawy;
                    string tlumaczenie = korzen.Prawy.Tlumaczenie.Slowo;
                    korzen.Prawy = temp.Lewy;
                    if (tlumaczenia != null)
                    {
                        bool znaleziony = false;
                        bool wywazone = false;
                        przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);
                    }
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -1 || korzen.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }

                }

               else if (korzen.Prawy.Prawy != null && korzen.Prawy.Lewy == null)
                {
                    Wezel temp = korzen.Prawy;
                    string tlumaczenie = korzen.Prawy.Tlumaczenie.Slowo;
                    korzen.Prawy = temp.Prawy;
                    if (tlumaczenia != null)
                    {
                        bool znaleziony = false;
                        bool wywazone = false;
                        przeciwne.UsunSlowo(ref tlumaczenia, tlumaczenie, ref znaleziony, ref wywazone, ref obj, null);
                    }
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -1 || korzen.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }
                }
                else if (korzen.Prawy.Prawy != null && korzen.Prawy.Lewy != null)
                {
                    Wezel temp = korzen.Prawy;
                    Wezel tlumaczenieDoUsuniecia = temp.Tlumaczenie;
                    Wezel nastepnik = WyszukajNastepnika(temp);
                    string nowapozycjaSlowo = nastepnik.Slowo;
                    Wezel nowapozycjaTlumaczenie = nastepnik.Tlumaczenie;
                    nastepnik.Tlumaczenie = tlumaczenieDoUsuniecia;
                    bool znaleziony = false;
                    bool wywazone = false;
                    UsunSlowo(ref temp, nastepnik.Slowo, ref znaleziony, ref wywazone, ref tlumaczenia, przeciwne);
                    temp.Slowo = nowapozycjaSlowo;
                    temp.Tlumaczenie = nowapozycjaTlumaczenie;
                    korzen.Prawy = temp;
                    if (korzen.Waga == 2 && korzen.Prawy == null && korzen.Lewy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        RR(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = -1;
                        korzen.Prawy.Waga = 1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -2 && korzen.Lewy == null && korzen.Prawy.Waga == 0)
                    {
                        Wezel wezel = korzen;
                        LL(ref wezel);
                        korzen = wezel;
                        //ustawianie nowych wag
                        korzen.Waga = 1;
                        korzen.Lewy.Waga = -1;
                        DrzewoWywazone = true;
                    }
                    if (korzen.Waga == -1 || korzen.Waga == 1)
                    {
                        DrzewoWywazone = true;
                        //dalsze wyważanie nie ma sensu
                    }
                }
            }


            //ROTACJE
            if (korzen.Waga == 2)
            {
                if(korzen.Lewy.Waga==-1)
                {
                    Wezel C = korzen.Lewy.Prawy;
                    Wezel wezel = korzen.Lewy;
                    LL(ref wezel);
                    korzen.Lewy = wezel;
                    wezel = korzen;
                    RR(ref wezel);
                    korzen = wezel;
                    //ustawianie nowych wag
                    switch (C.Waga)
                    {
                        case (1):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = -1;
                            break;
                        case (0):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = 0;
                            break;
                        case (-1):
                            korzen.Prawy.Waga = 1;
                            korzen.Lewy.Waga = 0;
                            break;

                    }
                    korzen.Waga = 0;
                }
                else
                {
                    Wezel wezel = korzen;
                    RR(ref wezel);
                    korzen = wezel;
                    //ustawianie nowych wag
                    korzen.Waga = 0;
                    korzen.Prawy.Waga = 0;
                }

            }
            if (korzen.Waga == -2)
            {

                if (korzen.Prawy.Waga == 1)
                {
                    Wezel C = korzen.Prawy.Lewy;
                    Wezel wezel = korzen.Prawy;
                    RR(ref wezel);
                    korzen.Prawy = wezel;
                    wezel = korzen;
                    LL(ref wezel);
                    korzen = wezel;
                    //ustawianie nowych wag
                    switch (C.Waga)
                    {
                        case (1):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = -1;
                            break;
                        case (0):

                            korzen.Prawy.Waga = 0;
                            korzen.Lewy.Waga = 0;
                            break;
                        case (-1):
                            korzen.Prawy.Waga = 1;
                            korzen.Lewy.Waga = 0;
                            break;

                    }
                    korzen.Waga = 0;

                }
                else
                {
                    Wezel wezel = korzen;
                    LL(ref wezel);
                    korzen = wezel;
                    //ustawianie nowych wag
                    korzen.Waga = 0;
                    korzen.Lewy.Waga = 0;
                }
            }



        }

        public Wezel WstawSlowo(ref Wezel root, string slowo, ref bool CzyBylaRotacja)
        {
            if (root == null)
            {
                root = new Wezel(slowo);
            }
            else if (slowo.CompareTo(root.Slowo) < 0)
            {
                Wezel lewy = root.Lewy;
                bool rotacja = CzyBylaRotacja;
                root.Lewy = WstawSlowo(ref lewy, slowo, ref rotacja);
                CzyBylaRotacja = rotacja;
                if (this.czyWywazone == false && CzyBylaRotacja == false)
                    root.Waga++;

                if (root.Waga == 0) //We wstawianiu rotacja wykona sie tylko raz
                {
                    this.czyWywazone = true;
                }
                else
                {

                }
            }
            else if (slowo.CompareTo(root.Slowo) > 0)
            {
                Wezel prawy = root.Prawy;
                bool rotacja = CzyBylaRotacja;
                root.Prawy = WstawSlowo(ref prawy, slowo, ref rotacja);
                CzyBylaRotacja = rotacja;
                if (this.czyWywazone == false && CzyBylaRotacja == false)
                    root.Waga--;

                if (root.Waga == 0) //We wstawianiu rotacja wykona sie tylko raz
                {
                    this.czyWywazone = true;
                }
                else
                {

                }
            }
            else
            {
                throw new Exception("Slowo znajduje sie juz w zbiorze, synonimy sa niedopuszczalne");
            }
            if (CzyBylaRotacja)
            {
                return root;
            }
            if (root.Waga == 2)
            {
                if (root.Lewy.Waga == 1)
                {
                    Wezel wezel = root;
                    CzyBylaRotacja = true;
                    RR(ref wezel);
                    root = wezel;
                    //ustawianie nowych wag
                    root.Waga = 0;
                    root.Prawy.Waga = 0;
                }
                else
                {
                    Wezel C = root.Lewy.Prawy;
                    Wezel wezel = root.Lewy;
                    CzyBylaRotacja = true;
                    LL(ref wezel);
                    root.Lewy = wezel;
                    wezel = root;
                    RR(ref wezel);
                    root = wezel;
                    //ustawianie nowych wag
                    switch (C.Waga)
                    {
                        case (1):

                            root.Prawy.Waga = -1;
                            root.Lewy.Waga = 0;
                            break;
                        case (0):

                            root.Prawy.Waga = 0;
                            root.Lewy.Waga = 0;
                            break;
                        case (-1):
                            root.Prawy.Waga = 0;
                            root.Lewy.Waga = 1;
                            break;

                    }
                    root.Waga = 0;
                }
            }
            if (root.Waga == -2)
            {

                if (root.Prawy.Waga == 1)
                {
                    Wezel C = root.Prawy.Lewy;
                    Wezel wezel = root.Prawy;
                    CzyBylaRotacja = true;
                    RR(ref wezel);
                    root.Prawy = wezel;
                    wezel = root;
                    LL(ref wezel);
                    root = wezel;
                    //ustawianie nowych wag
                    switch (C.Waga)
                    {
                        case (1):

                            root.Prawy.Waga = -1;
                            root.Lewy.Waga = 0;
                            break;
                        case (0):

                            root.Prawy.Waga = 0;
                            root.Lewy.Waga = 0;
                            break;
                        case (-1):
                            root.Prawy.Waga = 0;
                            root.Lewy.Waga = 1;
                            break;

                    }
                    root.Waga = 0;

                }
                else
                {
                    Wezel wezel = root;
                    CzyBylaRotacja = true;
                    LL(ref wezel);
                    root = wezel;
                    //ustawianie nowych wag
                    root.Waga = 0;
                    root.Lewy.Waga = 0;
                }
            }
            Debug.WriteLine("\t\t{0}", slowo);
            Debug.WriteLine("\t\t{0}", root.Slowo);
            return root;
        }
    }
}
