import matplotlib.pyplot as plt
import numpy as np

def SinusoidalSignal(time,frequency,amplitude,phase,sampling):
    duration = time   # in seconds, may be float
    f = frequency     # sine frequency, Hz, may be float
    A = amplitude     # amplitude
    fi = phase        # phase shift
    fs = sampling     # sampling rate

    return A*(np.sin(2*np.pi*np.arange(fs*duration)*f/fs+(fi*np.pi/180)))

if __name__ == "__main__":
    frequency = 1000 #1kHz
    fs1 = 8000
    fs2 = 2000
    fs3 = 1200
    time = 5.1*10**-3  # w sekundach
    amplitude = 1
    phase = 0
    y1 = SinusoidalSignal(time, frequency, amplitude,phase, fs1)
    t1 = np.arange(0, time, 1 / fs1)
    plt.subplot(3, 1, 1)
    plt.plot(t1, y1, label="Wykres sygnału")
    plt.stem(t1, y1, 'goldenrod', markerfmt='o', label="Sample rate")
    plt.xlabel("Czas[ms]")
    plt.xticks((0, 1.0 * 10 ** -3, 2.0 * 10 ** -3, 3.0 * 10 ** -3, 4.0 * 10 ** -3, 5.0 * 10 ** -3), (0, 1, 2, 3, 4, 5))
    plt.ylabel("Amplituda")
    plt.title("fs=8000Hz f=1000Hz")
    plt.ylim(-1.1, 1.1)
    plt.legend()

    y2 = SinusoidalSignal(time, frequency, amplitude, phase, fs2)
    t2 = np.arange(0, time, 1 / fs2)
    plt.subplot(3, 1, 2)
    plt.plot(t2, y2, label="Wykres sygnału")
    plt.stem(t2, y2, 'goldenrod', markerfmt='o', label="Sample rate")
    plt.xlabel("Czas[ms]")
    plt.xticks((0, 1.0 * 10 ** -3, 2.0 * 10 ** -3, 3.0 * 10 ** -3, 4.0 * 10 ** -3, 5.0 * 10 ** -3), (0, 1, 2, 3, 4, 5))
    plt.ylabel("Amplituda")
    plt.title("fs=2000Hz f=1000Hz")
    plt.ylim(-1.1, 1.1)
    plt.legend()

    y3 = SinusoidalSignal(time, frequency, amplitude, phase, fs3)
    t3 = np.arange(0, time, 1 / fs3)
    plt.subplot(3, 1, 3)
    plt.plot(t3, y3, label="Wykres sygnału")
    plt.stem(t3, y3, 'goldenrod', markerfmt='o', label="Sample rate")
    plt.xlabel("Czas[ms]")
    plt.xticks((0, 1.0 * 10 ** -3, 2.0 * 10 ** -3, 3.0 * 10 ** -3, 4.0 * 10 ** -3, 5.0 * 10 ** -3), (0, 1, 2, 3, 4, 5))
    plt.ylabel("Amplituda")
    plt.title("fs=1200Hz f=1000Hz")
    plt.ylim(-1.1, 1.1)
    plt.legend()
    plt.tight_layout()
    plt.show()