argr_gra = 500;
args = 8000;
N = 3;
arg = argr_gra * 2 / args;

%funkcje cheby...
[Bcheby1, Acheby1] = cheby1(N, 1, arg);
[Bcheby2, Acheby2] = cheby2(N, 20, arg);
[Belip, Aelip] = ellip(N, 1, 20, arg);
[Bbutter, Abutter] = butter(N, arg);

%freqz Frequency response of digital filter

[HCH1, wch1] = freqz(Bcheby1, Acheby1);
[hch2, wch2] = freqz(Bcheby2, Acheby2);
[hbutt, wbutt] = freqz(Bbutter, Abutter);
[h_elip, w_elip] = freqz(Belip, Aelip);

%faza
[phi_ch1, w_ch1] = phasez(Bcheby1, Acheby1);
[phi_ch2, h_ch2] = phasez(Bcheby2, Acheby2);
[phi_butt, h_butt] = phasez(Bbutter, Abutter);
[phi_elip, h_pha_elip] = phasez(Belip, Aelip);


%wykres charakterystyki amplitudowej
figure;
plot(wbutt * args / pi / 2, mag2db(abs(hbutt)), 'blue');
hold on;
plot(wch1 * args / pi / 2, mag2db(abs(HCH1)), 'red');
plot(wch2 * args / pi / 2, mag2db(abs(hch2)), 'black');
plot(w_elip * args / pi / 2, mag2db(abs(h_elip)), 'green');
ylabel('Magnituda [dB]');
xlabel('Czestotliwosc [Hz]');
title('Charakterystyka amplitudowa');
legend('Butterworth','Chebyshev 1','Chebyshev 2','Elliptic');
axis([0 4000 -60 5]);
hold off;

%wykres charakterystyki fazowej

figure;
plot(h_butt * args / pi / 2,phi_butt, 'blue');
hold on;
plot(w_ch1 * args / pi / 2,phi_ch1, 'red');
plot(h_ch2 * args / pi / 2,phi_ch2 , 'black');
plot(h_pha_elip * args / pi / 2,phi_elip, 'green');
ylabel('Faza [\times\pi rad]');
xlabel('Czestotliwosc [Hz]');
title('Charakterystyka fazowa');
legend('Butterworth','Chebyshev 1','Chebyshev 2','Elliptic');
axis([0 4000 -6 2]);
hold off;
