kod_zad_4.txt
Informacje
Aktywność
kod_zad_4.txt
Informacje o udostępnianiu
K
Informacje ogólne
Typ
Tekst
Rozmiar
3 KB (3 220 bajtów)
Wykorzystane miejsce na dane:
0 bajtówWłasność domeny undefined
Lokalizacja
zad4
Właściciel
Kamil Mierzwiński
Zmodyfikowany
13:24 przez: Kamil Mierzwiński
Otwarty
19:04 przeze mnie
Utworzono
13:24
Opis
Brak opisu
Uprawnienia do pobierania
Przeglądający mogą pobierać

fs = 8000;
f1 = 1000;
f2=2000;
f3=3000;
r1=0;
r2=0.5;
r3=0.9;
r4=1;
r5=1.1;
r6=2;
r7=3;
b1 = [1, -2 * cos(2 * pi * f1/fs), 1];
b2 = [1, -2 * cos(2 * pi * f2/fs), 1];
b3 = [1, -2 * cos(2 * pi * f3/fs), 1];

a1 = [1, -2 * r1 * cos(2 * pi * f1/fs), r1 * r1];
a2 = [1, -2 * r2 * cos(2 * pi * f1/fs), r2 * r2];
a3 = [1, -2 * r3 * cos(2 * pi * f1/fs), r3 * r3];
a4 = [1, -2 * r4 * cos(2 * pi * f1/fs), r4 * r4];
a5 = [1, -2 * r5 * cos(2 * pi * f1/fs), r5 * r5];
a6 = [1, -2 * r6 * cos(2 * pi * f1/fs), r6 * r6];
a7 = [1, -2 * r7 * cos(2 * pi * f1/fs), r7 * r7];
%f0=1000 hz
fvtool(b1,a1,b1,a2,b1,a3,b1,a4,b1,a5,b1,a6,b1,a7,'Fs',fs,'Legend','on');
ylim([-70 10]);
legend('r1=0','r2=0.5','r3=0.9','r4=1','r5=1.1','r6=2','r7=3');
title('Charakterystyka amplitudowa, {f_0=1000 Hz}');



%f0=2000 hz

a1f2 = [1, -2 * r1 * cos(2 * pi * f2/fs), r1 * r1];
a2f2= [1, -2 * r2 * cos(2 * pi * f2/fs), r2 * r2];
a3f2= [1, -2 * r3 * cos(2 * pi * f2/fs), r3 * r3];
a4f2= [1, -2 * r4 * cos(2 * pi * f2/fs), r4 * r4];
a5f2= [1, -2 * r5 * cos(2 * pi * f2/fs), r5 * r5];
a6f2= [1, -2 * r6 * cos(2 * pi * f2/fs), r6 * r6];
a7f2= [1, -2 * r7 * cos(2 * pi * f2/fs), r7 * r7];

fvtool(b2,a1f2,b2,a2f2,b2,a3f2,b2,a4f2,b2,a5f2,b2,a6f2,b2,a7f2,'Fs',fs,'Legend','on');
ylim([-70 10]);
legend('r1=0','r2=0.5','r3=0.9','r4=1','r5=1.1','r6=2','r7=3');
title('Charakterystyka amplitudowa, {f_0=2000 Hz}');

%f0=3000 hz

a1f3 = [1, -2 * r1 * cos(2 * pi * f3/fs), r1 * r1];
a2f3= [1, -2 * r2 * cos(2 * pi * f3/fs), r2 * r2];
a3f3= [1, -2 * r3 * cos(2 * pi * f3/fs), r3 * r3];
a4f3= [1, -2 * r4 * cos(2 * pi * f3/fs), r4 * r4];
a5f3= [1, -2 * r5 * cos(2 * pi * f3/fs), r5 * r5];
a6f3= [1, -2 * r6 * cos(2 * pi * f3/fs), r6 * r6];
a7f3= [1, -2 * r7 * cos(2 * pi * f3/fs), r7 * r7];

fvtool(b3,a1f3,b3,a2f3,b3,a3f3,b3,a4f3,b3,a5f3,b3,a6f3,b3,a7f3,'Fs',fs,'Legend','on');
ylim([-70 10]);
legend('r1=0','r2=0.5','r3=0.9','r4=1','r5=1.1','r6=2','r7=3');
title('Charakterystyka amplitudowa, {f_0=3000 Hz}');

%f0=1000 r=0.9
szum = normrnd(1,sqrt(2),1,8000);
filtr1 = filter(b1,a3,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=1000 Hz},r=0.9');
%f0=2000 r=0.9
figure;
filtr1 = filter(b2,a3f2,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=2000 Hz},r=0.9');
%f0=3000 r=0.9
figure;
filtr1 = filter(b3,a3f3,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=3000 Hz},r=0.9');

%f0=2000 r=0
figure;
filtr1 = filter(b2,a1f2,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=2000 Hz},r=0');

%f0=2000 r=0.5
figure;
filtr1 = filter(b2,a2f2,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=2000 Hz},r=0.5');

%f0=2000 r=0.9
figure;
filtr1 = filter(b2,a3f2,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=2000 Hz},r=0.9');

%f0=2000 r=1
figure;
filtr1 = filter(b2,a4f2,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=2000 Hz},r=1');


%f0=2000 r=1.1
figure;
filtr1 = filter(b2,a5f2,szum);
spectrogram(filtr1,window(@bartlett,256),[],512,8000);
title('{f_0=2000 Hz},r=1.1(filtr niestabilny)');
