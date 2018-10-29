import matplotlib.pyplot as plt
import numpy as np

def genereteComplexSineWave(k,N,phase):
    n = np.arange(0, N, 1)
    omega=2*np.pi*k/N
    y=np.exp(np.sqrt(-1+0j)*(n*omega+phase))
    return y

if __name__ == "__main__":
    func=genereteComplexSineWave(2,64,0)
    fourier = np.fft.fft(func)
    real = fourier.real
    imaginary = fourier.imag
    angle = np.angle(fourier)
    modulus = np.abs(fourier)
    plt.subplot(3, 2, 1)
    plt.plot(func.real)
    plt.title("Część rzeczywista funkcji sinusoidalnej")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.xlim(-0.01, 64.01)
    plt.subplot(3, 2, 2)
    plt.title("Część urojona funkcji sinusoidalnej")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.plot(func.imag)
    plt.subplot(3, 2, 3)
    plt.title("Część rzeczywista Transformaty Fouriera")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.stem(real)
    plt.subplot(3, 2, 4)
    plt.title("Część urojona Transformaty Fouriera")
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.stem(imaginary)
    plt.subplot(3, 2, 5)
    plt.title("Kąt Transformaty Fouriera")
    plt.xlabel("Nr próbki")
    plt.ylabel("Kąt[rad]")
    plt.stem(angle)
    plt.subplot(3, 2, 6)
    plt.title("Moduł z Transformaty Fouriera")
    plt.xlabel("Nr próki")
    plt.ylabel("Magnituda")
    plt.stem(modulus)
    plt.tight_layout()
    plt.show()
