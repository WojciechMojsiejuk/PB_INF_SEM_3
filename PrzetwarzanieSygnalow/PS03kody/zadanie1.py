import matplotlib.pyplot as plt
import numpy as np

def genereteSineWave(N):                        #funkcja generująca sinusoidę
    x = np.array(np.linspace(0, 2 * np.pi, N))  #przedział 1 okresu
    y = np.sin(x)                               #funkcja sinusa
    return y


if __name__ == "__main__":
    N=64                                        #ilość próbek
    func=genereteSineWave(N)
    fourier=2*np.fft.fft(func)/N                #transformata fouriera funkcji sinusoidalnej
    real=fourier.real                           #część rzeczywista transformaty
    imaginary=fourier.imag                      #część urojona transformaty
    angle=np.angle(fourier)                     #kąt transformaty
    modulus=np.abs(fourier)                     #moduł transformaty
    plt.subplot(3,2,1)
    plt.plot(np.real(func))
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
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.stem(real)
    plt.subplot(3,2,4)
    plt.title("Część urojona Transformaty Fouriera")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.stem(imaginary)
    plt.subplot(3,2,5)
    plt.title("Kąt Transformaty Fouriera")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Faza[pi*rad]")
    plt.stem(angle/np.pi)
    plt.subplot(3,2,6)
    plt.title("Moduł z Transformaty Fouriera")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Magnituda")
    plt.stem(modulus)
    plt.tight_layout()
    plt.show()
