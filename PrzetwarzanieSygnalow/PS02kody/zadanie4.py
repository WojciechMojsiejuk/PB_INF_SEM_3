from scipy.io.wavfile import read
from scipy.io.wavfile import write
import matplotlib.pyplot as plt
import numpy as np

# read audio samples
fs = read('test.wav')[0]
signal = read('test.wav')[1]
t=np.arange(0,len(signal)/fs,1/fs)
k=35 #Wspolczynik
noise = k*np.random.normal(size=len(signal[:,0]),loc=0,scale=1)
rmssignal=np.sqrt(np.mean(np.square(signal[:,0])))
rmsnoise=np.sqrt(np.mean(np.square(noise)))
db=20 * np.log10(rmssignal/rmsnoise)
plt.subplot(3, 1, 1)
plt.plot(t, signal[:,0])
plt.xlabel('Czas [s]')
plt.title("Wykres sygnału, SNR= "+str(db))
plt.ylabel("Amplituda")
plt.ylim(-4000,4000)
plt.subplot(3, 1, 2)
plt.ylim(-4000,4000)
plt.title("Wykres szumu")
plt.xlabel('Czas [s]')
plt.ylabel("Amplituda")
plt.plot(t,noise,'r')
plt.subplot(3, 1, 3)
plt.ylabel("Amplituda")
plt.title("Wykres sygnał + szum")
plt.plot(t, signal[:,0]+noise,'r',t, signal[:,0],'b');
plt.xlabel('Czas [s]')
plt.ylim(-4000,4000)
plt.tight_layout()
plt.show()
write('testzszumem.wav',fs,signal[:,0]+noise)
