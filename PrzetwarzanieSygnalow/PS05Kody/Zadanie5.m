%nagranie bezechowe

[y,Fs] = audioread('Audio.wav')
t=0:1/Fs:5-1/Fs;
signal = y(1:8*Fs,1)';
%stem(t,signal)
%sound(signal,Fs);

%odpowiedz impulsowa Katedra
[iy,iFs]= audioread('CathedralRoom.wav')
impulse = 1/100*iy(:,1)';
%sound(impulse);
wynik = conv(signal,impulse,'same');
stem(wynik);
%sound(wynik,Fs);


%odpowiedz impulsowa jaskinia
[i2y,i2Fs]= audioread('ir_2_L_2.wav')
impulse2 = 1/100*i2y(:,1)';
%sound(impulse);
wynik2 = conv(signal,impulse2,'same');
stem(wynik2);
sound(wynik2,i2Fs);
