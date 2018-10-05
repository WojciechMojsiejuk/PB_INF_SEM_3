//
//  main.cpp
//  ASDZadanieB
//
//  Created by Admin on 05.10.2018.
//  Copyright © 2018 Admin. All rights reserved.
//

#include <iostream>
#include <cstdlib>
using namespace std;
int main(int argc, const char * argv[]) {
    int tab[]={2,3,4,4,5,1,3,2,5,4};
    int tz[sizeof(tab)*5];
    bool czy_wykonala_sie_operacja=true;
    int wynik=-1;
    for(int i=0;i<sizeof(tab);i++)
    {
        tz[tab[i]]++;
    }
    while(czy_wykonala_sie_operacja)
    {
        wynik=0;
        czy_wykonala_sie_operacja=false;
        for(int i=0;i<sizeof(tz);i++)
        {
            div_t result = div(tz[i],2);
            tz[2*i]+=result.quot/2;
            tz[i]=result.rem;
            if(result.rem==0&&result.quot==1)
            {
                czy_wykonala_sie_operacja=false;
                wynik++;
            }
        }
    }
    return wynik;
}
