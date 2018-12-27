fs = 8000;
fg = 500;
filtr1 = fdesign.lowpass('N,Fc',10,fg,fs,'linear');
filtr2 = fdesign.lowpass('N,Fc',20,fg,fs,'linear');
filtr3 = fdesign.lowpass('N,Fc',40,fg,fs,'linear');
filtr4 = fdesign.lowpass('N,Fc',80,fg,fs,'linear');
des1 = design(filtr1,'window','window',@rectwin);
des2 = design(filtr2,'window','window',@rectwin);
des3 = design(filtr3,'window','window',@rectwin);
des4 = design(filtr4,'window','window',@rectwin);
fvtool(des1,des2,des3,des4);
legend('Rz¹d=10','Rz¹d=20','Rz¹d=40','Rz¹d=80');
ax = gca;
ax.YLim = [-60 10];


fvtool(des1,des2,des3,des4,'Phase');
legend('Rz¹d=10','Rz¹d=20','Rz¹d=40','Rz¹d=80');

filename = 'www.wav';
[signalhandel, fshandel] = audioread(filename);
figure;
spectrogram(signalhandel,window(@blackman, 512),[],512,fshandel);
title('Sygna³ Oryginalny');
figure;
handle = filter(des4, signalhandel);
spectrogram(handle,window(@blackman, 512),[],512,fshandel);
title('Sygna³ przefiltrowany, fg=500, filtr SOI, Rz¹d 80');
