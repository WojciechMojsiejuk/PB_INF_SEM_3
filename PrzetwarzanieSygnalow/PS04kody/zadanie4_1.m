fs = 8000;
czas = 5;
t = [0:1/fs:czas-1/fs];
%wspolczynnik
alfa=0.999;
%funkcja generująca szum gaussowski
y1 = randn(czas*fs,1);
y1 = transpose(y1);
%obwiednia szumu gaussowskiego
%zakladamy ze dla t<=0 gaussEnvelope zwraca 0
gaussEnvelope(1)=(1-alfa)*y1(1);
for n = 2:fs*czas
  gaussEnvelope(n) = alfa*gaussEnvelope(n-1)+(1-alfa)*y1(n)^2;
end
%funkcja generująca sygnał sinusoidalny o stałej częstotliwości
y2 = sin(250*pi*t);
%obwiednia sygnału sinusoidalnego
sinEnvelope(1)=(1-alfa)*y2(1);
for n = 2:fs*czas
  sinEnvelope(n) = alfa*sinEnvelope(n-1)+(1-alfa)*y2(n)^2;
end
%funkcja generująca sygnał o zmiennej częstotliwości w zakresie od 0Hz (0s)
%do 1kHz(5s)
y3 = chirp(t,0,5,1000);
%obwiednia sygnału zmiennego
chirpEnvelope(1)=(1-alfa)*y3(1);
for n = 2:fs*czas
  chirpEnvelope(n) = alfa*chirpEnvelope(n-1)+(1-alfa)*y3(n)^2;
end
%wczytanie sygnału mowy
[y4,fs]=audioread('mowa.wav');
%obwiednia sygnału mowy;
voiceEnvelope(1)=(1-alfa)*y4(1);
for n = 2:fs*czas
  voiceEnvelope(n) = alfa*voiceEnvelope(n-1)+(1-alfa)*y4(n)^2;
end

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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Szum gaussowski - Obwiednia mocy, \alpha = 0.999')
axis([-inf inf 0 2]);
plot(t,gaussEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał sinusoidalny - Obwiednia mocy, \alpha = 0.999')
axis([-inf inf 0 1]);
plot(t,sinEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał o zmiennej częstotliwości - Obwiednia mocy, \alpha = 0.999')
axis([-inf inf 0 1]);
plot(t,chirpEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał mowy - Obwiednia mocy, \alpha = 0.999')
axis([-inf inf 0 0.1]);
plot(t,voiceEnvelope);
hold off;

%POWTÓRZENIE WYKRESÓW DLA ALFA=0.99

%wspolczynnik
alfa=0.99;
%funkcja generująca szum gaussowski
y1 = randn(czas*fs,1);
y1 = transpose(y1);
%obwiednia szumu gaussowskiego
%zakladamy ze dla t<=0 gaussEnvelope zwraca 0
gaussEnvelope(1)=(1-alfa)*y1(1);
for n = 2:fs*czas
  gaussEnvelope(n) = alfa*gaussEnvelope(n-1)+(1-alfa)*y1(n)^2;
end
%funkcja generująca sygnał sinusoidalny o stałej częstotliwości
y2 = sin(250*pi*t);
%obwiednia sygnału sinusoidalnego
sinEnvelope(1)=(1-alfa)*y2(1);
for n = 2:fs*czas
  sinEnvelope(n) = alfa*sinEnvelope(n-1)+(1-alfa)*y2(n)^2;
end
%funkcja generująca sygnał o zmiennej częstotliwości w zakresie od 0Hz (0s)
%do 1kHz(5s)
y3 = chirp(t,0,5,1000);
%obwiednia sygnału zmiennego
chirpEnvelope(1)=(1-alfa)*y3(1);
for n = 2:fs*czas
  chirpEnvelope(n) = alfa*chirpEnvelope(n-1)+(1-alfa)*y3(n)^2;
end
%wczytanie sygnału mowy
[y4,fs]=audioread('mowa.wav');
%obwiednia sygnału mowy;
voiceEnvelope(1)=(1-alfa)*y4(1);
for n = 2:fs*czas
  voiceEnvelope(n) = alfa*voiceEnvelope(n-1)+(1-alfa)*y4(n)^2;
end

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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Szum gaussowski - Obwiednia mocy, \alpha = 0.99')
axis([-inf inf 0 2]);
%Z jakiegos powodu nalezy pomnozyc przez -1
plot(t,gaussEnvelope);
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

xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał sinusoidalny - Obwiednia mocy, \alpha = 0.99')
axis([-inf inf 0 1]);
plot(t,sinEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał o zmiennej częstotliwości - Obwiednia mocy, \alpha = 0.99')
axis([-inf inf 0 1]);
plot(t,chirpEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał mowy - Obwiednia mocy, \alpha = 0.99')
axis([-inf inf 0 0.2]);
plot(t,voiceEnvelope);
hold off;

%POWTÓRZENIE WYKRESÓW DLA ALFA=0.001

%wspolczynnik
alfa=0.001;
%funkcja generująca szum gaussowski
y1 = randn(czas*fs,1);
y1 = transpose(y1);
%obwiednia szumu gaussowskiego
%zakladamy ze dla t<=0 gaussEnvelope zwraca 0
gaussEnvelope(1)=(1-alfa)*y1(1);
for n = 2:fs*czas
  gaussEnvelope(n) = alfa*gaussEnvelope(n-1)+(1-alfa)*y1(n)^2;
end
%funkcja generująca sygnał sinusoidalny o stałej częstotliwości
y2 = sin(250*pi*t);
%obwiednia sygnału sinusoidalnego
sinEnvelope(1)=(1-alfa)*y2(1);
for n = 2:fs*czas
  sinEnvelope(n) = alfa*sinEnvelope(n-1)+(1-alfa)*y2(n)^2;
end
%funkcja generująca sygnał o zmiennej częstotliwości w zakresie od 0Hz (0s)
%do 1kHz(5s)
y3 = chirp(t,0,5,1000);
%obwiednia sygnału zmiennego
chirpEnvelope(1)=(1-alfa)*y3(1);
for n = 2:fs*czas
  chirpEnvelope(n) = alfa*chirpEnvelope(n-1)+(1-alfa)*y3(n)^2;
end
%wczytanie sygnału mowy
[y4,fs]=audioread('mowa.wav');
%obwiednia sygnału mowy;
voiceEnvelope(1)=(1-alfa)*y4(1);
for n = 2:fs*czas
  voiceEnvelope(n) = alfa*voiceEnvelope(n-1)+(1-alfa)*y4(n)^2;
end

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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Szum gaussowski - Obwiednia mocy, \alpha = 0.001')
axis([-inf inf 0 20]);
plot(t,gaussEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał sinusoidalny - Obwiednia mocy, \alpha = 0.001')
axis([-inf inf 0 1]);
plot(t,sinEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał o zmiennej częstotliwości - Obwiednia mocy, \alpha = 0.001')
axis([-inf inf 0 1]);
plot(t,chirpEnvelope);
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
xlabel('Czas[s]');
ylabel('Moc');
hold on;
title('Sygnał mowy - Obwiednia mocy, \alpha = 0.001')
axis([-inf inf 0 1]);
plot(t,voiceEnvelope);
hold off;
