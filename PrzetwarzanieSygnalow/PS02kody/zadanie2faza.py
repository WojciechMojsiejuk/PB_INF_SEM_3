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
    frequency=2.0
    amplitude1=50
    phase1=0
    phase2 = 90
    phase3 = 180
    fs = 500 #czestoscprobkowania
    y1=SinusoidalSignal(time,frequency,amplitude1,phase1,fs)
    y2 = SinusoidalSignal(time,frequency,amplitude1,phase2,fs)
    y3 = SinusoidalSignal(time,frequency,amplitude1,phase3,fs)
    t=np.arange(0,2.0,1/fs)
    plt.subplot(3,1,1)
    plt.plot(t,y1)
    plt.ylabel("Amplituda")
    plt.xlabel("Czas trwania sygnału[s]")
    plt.title("Przebiegi sygnału sinusoidalnego dla różnego przesunięcia fazowego\n "+r'$\phi$'+"=0["+r'$rad$'+"]")
    plt.subplot(3, 1, 2)
    plt.plot(t, y2)
    plt.ylabel("Amplituda")
    plt.xlabel("Czas trwania sygnału[s]")
    plt.title(r'$\phi$'+"="+r'$\frac{\pi}{2}$'+"["+r'$rad$'+"]")
    plt.subplot(3, 1, 3)
    plt.plot(t, y3)
    plt.ylabel("Amplituda")
    plt.xlabel("Czas trwania sygnału[s]")
    plt.title(r'$\phi$'+"="+r'$\pi$'+"["+r'$rad$'+"]")
    plt.tight_layout()
    plt.show()