%zmienne
a1=0.9;
a2=0.1;
b0=0.1;
b1=0.2;
b2=0.3;
a=[a1,a2]; 
b=[b0,b1,b2];
x=0:1:15;
imp=zeros(1,length(x));
imp(1)=1;
odp_imp=filtr(b,a,imp);
%podpunkt a
figure;
stem(odp_imp);
title('OdpowiedŸ filtru obliczona z równania ró¿nicowego');
xlabel('Numer próbki');
ylabel('Amplituda');
%podpunkt b
figure;
af=[1,a1,a2];
bf=[b0,b1,b2];
wbud=filter(bf,af,imp);
stem(wbud)
title('OdpowiedŸ filtru obliczona funkcj¹ filter');
xlabel('Numer próbki');
ylabel('Amplituda');
%podpunkt c
figure;
%zmienne
[h,w]=freqz(odp_imp);
[phi,w] = phasez(odp_imp);
subplot(2,1,1)
plot(w/pi,20*log10(abs(h)))
title('Charakterystyka amplitudowa');
ax = gca;
ax.XTick = 0:.5:2;
xlabel('Normalized Frequency (\times\pi rad/sample)')
ylabel('Magnitude (dB)')
subplot(2,1,2)
plot(w/pi,phi*180/pi);
title('Charakterystyka fazowa');
ax = gca;
ax.XTick = 0:.5:2;
xlabel('Normalized Frequency (\times\pi rad/sample)')
ylabel('Phase [stopnie]')
%biegun
fvtool(bf,af,'polezero');
[bx,ax] = eqtflength(bf,af);
[z,p,k] = tf2zp(bx,ax);
text(real(z)+.1,imag(z),'zero');
text(real(p)+.1,imag(p),'pole');
figure;
%szum=normrnd(0,1,[1,64]);
N=1024;
arg=0:1:N-1;
szum=randn(N,1).';
y=filtr(b,a,szum);

%plot(arg/pi,(abs(fft(szum))));
yy=20*log10(abs(fft(szum)));
xx = linspace(0,2,length(y));
subplot(2,1,1);
plot(xx,yy);

xlim([0 1]);

xlabel('Normalized Frequency (\times\pi rad/sample)');
ylabel('Magnitude (dB)');
title('Single-Sided Amplitude Spectrum of X(t)');
subplot(2,1,2);
y=20*log10(abs(fft(y)));
x = linspace(0,2,length(y));
plot(x,y);
xlim([0 1]);

xlabel('Normalized Frequency (\times\pi rad/sample)');
ylabel('Magnitude (dB)');
title('Single-Sided Amplitude Spectrum of Y(t)');
