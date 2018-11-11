fs = 8000;
czas = 5;
t = [0:1/fs:czas-1/fs];
%funkcja generująca szum gaussowski
y1 = randn(czas*fs,1);
y1 = transpose(y1);
%obwiednia szumu gaussowskiego
[up1,lo1] = envelope(y1);
%funkcja generująca sygnał sinusoidalny o stałej częstotliwości
y2 = sin(250*pi*t);
%obwiednia sygnału sinusoidalnego
[up2,lo2] = envelope(y2);
%funkcja generująca sygnał o zmiennej częstotliwości w zakresie od 0Hz (0s)
%do 1kHz(5s)
y3 = chirp(t,0,5,1000,'quadratic',[],'concave');
%obwiednia sygnału zmiennego
[up3,lo3] = envelope(y3);
%wczytanie sygnału mowy
[y4,fs]=audioread('mowa.wav');
%obwiednia sygnału mowy;
[up4,lo4] = envelope(y4);
figure;
%SZUM GAUSSOWSKI
subplot(4,2,1);
hold on;
plot(t,y1);
title('Szum gaussowski');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,2);
hold on;
title('Szum gaussowski - Obwiednia mocy, \alpha = 0.999')
alpha=0.999;
%pierwsza wartość nie może odwołać się do poprzednich
up1(1)=(1-alpha)*up1(1)^2;
for n = 2:fs*czas
    up1(n)=alpha*up1(n-1)+(1-alpha)*up1(n)^2;
end
plot(t,up1);
hold off;
%SYGNAŁ SINUSOIDALNY STAŁY
subplot(4,2,3)
hold on;
plot(t,y2);
title('Sygnał sinusoidalny o stałej częstotliwości');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,4)
hold on;
title('Sygnał sinusoidalny - Obwiednia mocy, \alpha = 0.999')
alpha=0.999;
%pierwsza wartość nie może odwołać się do poprzednich
up2(1)=(1-alpha)*up2(1)^2;
for n = 2:fs*czas
    up2(n)=alpha*up2(n-1)+(1-alpha)*up2(n)^2;
end
lo2(1)=(1-alpha)*lo2(1)^2;
for n = 2:fs*czas
    lo2(n)=alpha*lo2(n-1)+(1-alpha)*lo2(n)^2;
end
%lo rysuje tak samo up by było jak w przykladowym podzielimy przez 2
plot(t,lo2);
hold off;
%SYGNAŁ ZMIENNY
subplot(4,2,5)
hold on;
plot(t,y3);
title('Sygnał o zmiennej częstotliwości');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,6)
hold on;
title('Sygnał o zmiennej częstotliwości - Obwiednia mocy, \alpha = 0.999')
alpha=0.999;
%pierwsza wartość nie może odwołać się do poprzednich
up3(1)=(1-alpha)*up3(1)^2;
for n = 2:fs*czas
    up3(n)=alpha*up3(n-1)+(1-alpha)*up3(n)^2;
end
lo3(1)=(1-alpha)*lo3(1)^2;
for n = 2:fs*czas
    lo3(n)=alpha*lo3(n-1)+(1-alpha)*lo3(n)^2;
end
plot(t,up3,t,lo3);
hold off;
%SYGNAŁ MOWY
subplot(4,2,7)
hold on;
plot(t,y4);
title('Sygnał mowy');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,8)
hold on;
title('Sygnał mowy - Obwiednia mocy, \alpha = 0.999')
alpha=0.999;
%pierwsza wartość nie może odwołać się do poprzednich
up4(1)=(1-alpha)*up4(1)^2;
for n = 2:fs*czas
    up4(n)=alpha*up4(n-1)+(1-alpha)*up4(n)^2;
end
lo4(1)=(1-alpha)*lo4(1)^2;
for n = 2:fs*czas
    lo4(n)=alpha*lo4(n-1)+(1-alpha)*lo4(n)^2;
end
plot(t,up4,t,lo4);
hold off;



%POWTÓRZENIE WYKRESÓW DLA ALFA=0.99




figure;
%SZUM GAUSSOWSKI
subplot(4,2,1);
hold on;
plot(t,y1);
title('Szum gaussowski');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,2);
hold on;
title('Szum gaussowski - Obwiednia mocy, \alpha = 0.99')
alpha=0.99;
%pierwsza wartość nie może odwołać się do poprzednich
up1(1)=(1-alpha)*up1(1)^2;
for n = 2:fs*czas
    up1(n)=alpha*up1(n-1)+(1-alpha)*up1(n)^2;
end
plot(t,up1);
hold off;
%SYGNAŁ SINUSOIDALNY STAŁY
subplot(4,2,3)
hold on;
plot(t,y2);
title('Sygnał sinusoidalny o stałej częstotliwości');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,4)
hold on;
title('Sygnał sinusoidalny - Obwiednia mocy, \alpha = 0.99')
alpha=0.99;
%pierwsza wartość nie może odwołać się do poprzednich
up2(1)=(1-alpha)*up2(1)^2;
for n = 2:fs*czas
    up2(n)=alpha*up2(n-1)+(1-alpha)*up2(n)^2;
end
lo2(1)=(1-alpha)*lo2(1)^2;
for n = 2:fs*czas
    lo2(n)=alpha*lo2(n-1)+(1-alpha)*lo2(n)^2;
end
%lo rysuje tak samo up by było jak w przykladowym podzielimy przez 2
plot(t,lo2);
hold off;
%SYGNAŁ ZMIENNY
subplot(4,2,5)
hold on;
plot(t,y3);
title('Sygnał o zmiennej częstotliwości');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,6)
hold on;
title('Sygnał o zmiennej częstotliwości - Obwiednia mocy, \alpha = 0.99')
alpha=0.99;
%pierwsza wartość nie może odwołać się do poprzednich
up3(1)=(1-alpha)*up3(1)^2;
for n = 2:fs*czas
    up3(n)=alpha*up3(n-1)+(1-alpha)*up3(n)^2;
end
lo3(1)=(1-alpha)*lo3(1)^2;
for n = 2:fs*czas
    lo3(n)=alpha*lo3(n-1)+(1-alpha)*lo3(n)^2;
end
plot(t,up3,t,lo3);
hold off;
%SYGNAŁ MOWY
subplot(4,2,7)
hold on;
plot(t,y4);
title('Sygnał mowy');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,8)
hold on;
title('Sygnał mowy - Obwiednia mocy, \alpha = 0.99')
alpha=0.99;
%pierwsza wartość nie może odwołać się do poprzednich
up4(1)=(1-alpha)*up4(1)^2;
for n = 2:fs*czas
    up4(n)=alpha*up4(n-1)+(1-alpha)*up4(n)^2;
end
lo4(1)=(1-alpha)*lo4(1)^2;
for n = 2:fs*czas
    lo4(n)=alpha*lo4(n-1)+(1-alpha)*lo4(n)^2;
end
plot(t,up4,t,lo4);
hold off;

%POWTÓRZENIE WYKRESÓW DLA ALFA=0.01




figure;
%SZUM GAUSSOWSKI
subplot(4,2,1);
hold on;
plot(t,y1);
title('Szum gaussowski');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,2);
hold on;
title('Szum gaussowski - Obwiednia mocy, \alpha = 0.001')
alpha=0.001;
%pierwsza wartość nie może odwołać się do poprzednich
up1(1)=(1-alpha)*up1(1)^2;
for n = 2:fs*czas
    up1(n)=alpha*up1(n-1)+(1-alpha)*up1(n)^2;
end
plot(t,up1);
hold off;
%SYGNAŁ SINUSOIDALNY STAŁY
subplot(4,2,3)
hold on;
plot(t,y2);
title('Sygnał sinusoidalny o stałej częstotliwości');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,4)
hold on;
title('Sygnał sinusoidalny - Obwiednia mocy, \alpha = 0.001')
alpha=0.001;
%pierwsza wartość nie może odwołać się do poprzednich
up2(1)=(1-alpha)*up2(1)^2;
for n = 2:fs*czas
    up2(n)=alpha*up2(n-1)+(1-alpha)*up2(n)^2;
end
lo2(1)=(1-alpha)*lo2(1)^2;
for n = 2:fs*czas
    lo2(n)=alpha*lo2(n-1)+(1-alpha)*lo2(n)^2;
end
%lo rysuje tak samo up by było jak w przykladowym podzielimy przez 2
plot(t,lo2);
hold off;
%SYGNAŁ ZMIENNY
subplot(4,2,5)
hold on;
plot(t,y3);
title('Sygnał o zmiennej częstotliwości');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,6)
hold on;
title('Sygnał o zmiennej częstotliwości - Obwiednia mocy, \alpha = 0.001')
alpha=0.001;
%pierwsza wartość nie może odwołać się do poprzednich
up3(1)=(1-alpha)*up3(1)^2;
for n = 2:fs*czas
    up3(n)=alpha*up3(n-1)+(1-alpha)*up3(n)^2;
end
lo3(1)=(1-alpha)*lo3(1)^2;
for n = 2:fs*czas
    lo3(n)=alpha*lo3(n-1)+(1-alpha)*lo3(n)^2;
end
plot(t,up3,t,lo3);
hold off;
%SYGNAŁ MOWY
subplot(4,2,7)
hold on;
plot(t,y4);
title('Sygnał mowy');
xlabel('Czas[s]');
ylabel('Amplituda');
hold off;
subplot(4,2,8)
hold on;
title('Sygnał mowy - Obwiednia mocy, \alpha = 0.001')
alpha=0.001;
%pierwsza wartość nie może odwołać się do poprzednich
up4(1)=(1-alpha)*up4(1)^2;
for n = 2:fs*czas
    up4(n)=alpha*up4(n-1)+(1-alpha)*up4(n)^2;
end
lo4(1)=(1-alpha)*lo4(1)^2;
for n = 2:fs*czas
    lo4(n)=alpha*lo4(n-1)+(1-alpha)*lo4(n)^2;
end
plot(t,up4,t,lo4);
hold off;
