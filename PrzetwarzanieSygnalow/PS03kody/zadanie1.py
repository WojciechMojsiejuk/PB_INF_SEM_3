import matplotlib.pyplot as plt
import numpy as np

def genereteSineWave(amplitude,frequency, phase, fs):
    t=np.arange(0,1-1/fs,1/fs) #w jednej sekundzie jest fs probek
    y=np.sin(2*np.pi*frequency*t+phase)
    return t,y

def genereteComplexSineWave(k,N,phase):
    n = np.arange(0, N, 1)
    omega=2*np.pi*k/N
    y=np.exp(complex(n*omega)+phase)
    return y

if __name__ == "__main__":
    #3.1
    N=64
    [time,func]=genereteSineWave(1,1,0,N)
    fourier=np.fft.fft(func)
    real=fourier.real
    imaginary=fourier.imag
    angle=np.angle(fourier)
    modulus=np.abs(fourier)
    #fig=plt.figure(tight_layout=True, y=1.08)
    #fig.suptitle("Transformata Fouriera")
    plt.subplot(3,2,1)
    plt.plot(func.real)
    plt.title("Część rzeczywista funkcji sinusoidalnej")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.xlim(-0.01,64.01)
    plt.subplot(3,2,2)
    plt.title("Część urojona funkcji sinusoidalnej")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.plot(func.imag)
    plt.subplot(3,2,3)
    plt.title("Część rzeczywista Transformaty Fouriera")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.stem(real)
    plt.subplot(3,2,4)
    plt.title("Część urojona Transformaty Fouriera")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.stem(imaginary)
    plt.subplot(3,2,5)
    plt.title("Kąt Transformaty Fouriera")
    plt.xlabel("Nr próbki")
    plt.ylabel("Kąt[rad]")
    plt.stem(angle)
    plt.subplot(3,2,6)
    plt.title("Moduł z Transformaty Fouriera")
    plt.xlabel("Nr próki")
    plt.ylabel("Magnituda")
    plt.stem(modulus)
    plt.tight_layout()
    plt.show()



    #3.3
    plt.title("Odwrotna Transformata Fouriera")
    plt.xlabel("nr próbki")
    plt.ylabel("amplituda")
    plt.xlim(-0.01, 64.01)
    inversefourier=np.fft.ifft(fourier)
    plt.stem(inversefourier)
    plt.show()

    #numer/indeks pasma czestotliwosciowego
    #czesc urojona zadania2
    #modul magnituda
    #pi radianow faza
