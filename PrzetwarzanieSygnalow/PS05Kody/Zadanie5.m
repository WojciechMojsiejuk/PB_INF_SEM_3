%nagranie bezechowe

[y,Fs] = audioread('Audio.wav');
t=0:1/Fs:5-1/Fs;
signal = y(1:8*Fs,1)';
%stem(t,signal)
%sound(signal,Fs);

%odpowiedz impulsowa Katedra
[iy,iFs]= audioread('CathedralRoom.wav');
impulse = iy(:,1)';
%sound(impulse);
wynik = conv(signal,impulse,'same');
stem(wynik);
sound(1/100*wynik,Fs);


%odpowiedz impulsowa jaskinia
[i2y,i2Fs]= audioread('BatteryBenson.wav');
impulse2 = i2y(:,1)';
%sound(impulse);
wynik2 = conv(signal,impulse2,'same');
stem(wynik2);
sound(1/100*wynik2,i2Fs);
