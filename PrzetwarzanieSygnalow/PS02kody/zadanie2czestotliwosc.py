import matplotlib.pyplot as plt
import numpy as np

def SinusoidalSignal(time,frequency,amplitude,phase,sampling):
    duration = time   # in seconds, may be float
    f = frequency     # sine frequency, Hz, may be float
    A = amplitude     # amplitude
    fi = phase        # phase shift
    fs = sampling     # sampling rate

    return A*(np.sin(2*np.pi*np.arange(fs*duration)*f/fs+(fi*np.pi/180)))

if __name__=="__main__":

    time=2.0 # w sekundach
    frequency1=1.0 # w Hz
    frequency2 = 2.0
    frequency3 = 4.0
    amplitude1=50
    phase=0
    fs = 500 #czestoscprobkowania
    y1=SinusoidalSignal(time,frequency1,amplitude1,phase,fs)
    y2 = SinusoidalSignal(time,frequency2,amplitude1,phase,fs)
    y3 = SinusoidalSignal(time,frequency3,amplitude1,phase,fs)
    t=np.arange(0,2.0,1/fs)
    plt.subplot(3,1,1)
    plt.plot(t,y1)
    plt.ylabel("Amplituda")
    plt.xlabel("Czas trwania sygnału[s]")
    plt.title("Przebiegi sygnału sinusoidalnego dla zmieniającej się częstotliwości\n f=1Hz")
    plt.subplot(3, 1, 2)
    plt.plot(t, y2)
    plt.ylabel("Amplituda")
    plt.xlabel("Czas trwania sygnału[s]")
    plt.title("f=2Hz")
    plt.subplot(3, 1, 3)
    plt.plot(t, y3)
    plt.ylabel("Amplituda")
    plt.xlabel("Czas trwania sygnału[s]")
    plt.title("f=4Hz")
    plt.tight_layout()
    plt.show()