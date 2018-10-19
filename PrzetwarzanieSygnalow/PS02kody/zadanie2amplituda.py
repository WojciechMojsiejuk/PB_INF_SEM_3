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
    frequency=2.0 # w Hz
    amplitude1=10
    amplitude2=50
    amplitude3=100
    phase=0
    fs = 500 #czestoscprobkowania
    y1=SinusoidalSignal(time,frequency,amplitude1,phase,fs)
    y2 = SinusoidalSignal(time,frequency,amplitude2,phase,fs)
    y3 = SinusoidalSignal(time,frequency,amplitude3,phase,fs)
    t=np.arange(0,2.0,1/fs)
    plt.plot(t,y1,label="Amplituda=10")
    plt.plot(t, y2, label="Amplituda=50")
    plt.plot(t, y3, label="Amplituda=100")
    plt.ylabel("Amplituda")
    plt.xlabel("Czas trwania sygnału[s]")
    plt.title("Przebiegi sygnału sinusoidalnego dla zmieniającej się amplitudy")
    plt.ylim(-101,101)
    plt.legend()
    plt.grid()
    plt.show()