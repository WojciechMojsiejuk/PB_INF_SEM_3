import matplotlib.pyplot as plt
import numpy as np

#funkcje wykorzystane w zadaniu

def y1(N):
    n=np.arange(0,N,1) #w jednej sekundzie jest fs probek
    phase=np.pi/4
    y=np.cos(2*np.pi*n/N+phase)
    return y

def y2(N):
    n=np.arange(0,N,1) #w jednej sekundzie jest fs probek
    phase=0
    y=0.5*np.cos(4*np.pi*n/N+phase)
    return y

def y3(N):
    n=np.arange(0,N,1) #w jednej sekundzie jest fs probek
    phase=np.pi/2
    y=0.25*np.cos(8*np.pi*n/N+phase)
    return y
def y4(y1,y2,y3):
    a=y1+y2+y3
    return a

if __name__ == "__main__":

    #zmienna okreslająca ilość próbek
    N=32

    #Wygenerowanie funkcji
    func1=y1(N)
    func2=y2(N)
    func3=y3(N)
    func4=y4(func1,func2,func3)

    # Część rzeczywista funkcji sinusoidalnych
    plt.subplot(4,1,1)
    plt.plot(func1)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title("Część rzeczywista funkcji sinusoidalnych\n"+r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(4,1,2)
    plt.plot(func2)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(4, 1, 3)
    plt.plot(func3)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(4, 1, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.plot(func4)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()

    #Wyliczenia transformat Fouriera oraz innych parametrów dla każdej funkcji
    fourier1=np.fft.fft(func1)
    real1=fourier1.real
    imaginary1=fourier1.imag
    angle1 = np.angle(fourier1)
    modulus1 = np.abs(fourier1)

    fourier2 = np.fft.fft(func2)
    real2 = fourier2.real
    imaginary2 = fourier2.imag
    angle2 = np.angle(fourier2)
    modulus2 = np.abs(fourier2)

    fourier3 = np.fft.fft(func3)
    real3 = fourier3.real
    imaginary3 = fourier3.imag
    angle3 = np.angle(fourier3)
    modulus3 = np.abs(fourier3)

    fourier4 = np.fft.fft(func4)
    real4 = fourier4.real
    imaginary4 = fourier4.imag
    angle4 = np.angle(fourier4)
    modulus4 = np.abs(fourier4)

    # Część urojona funkcji sinusoidalnych
    plt.subplot(4, 1, 1)
    plt.plot(func1.imag)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title("Część urojona funkcji sinusoidalnych\n" + r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(4, 1, 2)
    plt.plot(func2.imag)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(4, 1, 3)
    plt.plot(func3.imag)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(4, 1, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.plot(func4.imag)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()



    #Transformata Fouriera cz. rzeczywista
    plt.subplot(4,1,1)
    plt.stem(real1)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title("Część rzeczywista Transformaty Fouriera\n"+r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(4,1,2)
    plt.stem(real2)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(4, 1, 3)
    plt.stem(real3)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(4, 1, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(real4)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()

    # Transformata Fouriera cz. urojona
    plt.subplot(4, 1, 1)
    plt.stem(imaginary1)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title("Część urojona Transformaty Fouriera\n" + r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(4, 1, 2)
    plt.stem(imaginary2)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(4, 1, 3)
    plt.stem(imaginary3)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(4, 1, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(imaginary4)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()

    # Transformata Fouriera kąt
    plt.subplot(4, 1, 1)
    plt.stem(angle1)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title("Kąt Transformaty Fouriera\n" + r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(4, 1, 2)
    plt.stem(angle2)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(4, 1, 3)
    plt.stem(angle3)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(4, 1, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(angle4)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()


    # Transformata Fouriera moduł
    plt.subplot(4, 1, 1)
    plt.stem(modulus1)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title("Moduł z Transformaty Fouriera\n" + r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(4, 1, 2)
    plt.stem(modulus2)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(4, 1, 3)
    plt.stem(modulus3)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(4, 1, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(modulus4)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()

    '''Transformata jest adytywna
    Jaki jest związek pomiędzy amplitudą, fazą, liczbą okresów poszczególnych sygnałów a wartościami widma zespolonego?
        ● Przekształcenie Fouriera jest homogeniczne.
        ● Przesunięcie sygnału w czasie nie zmienia amplitudy jego transformaty, natomiast wpływ na jej fazę.
        ● Zwiększenie liczby okresów sygnału („przyspieszenie”) spowoduje poszerzenie widma częstotliwościowego (wystąpienie większych częstotliwości).
    '''
    #Odwrotne transformaty Fouriera
    plt.subplot(4, 1, 1)
    inversefourier1 = np.fft.ifft(fourier1)
    plt.stem(inversefourier1)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title("Odwrotne Transformaty Fouriera\n" + r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(4, 1, 2)
    inversefourier2 = np.fft.ifft(fourier2)
    plt.stem(inversefourier2)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(4, 1, 3)
    inversefourier3 = np.fft.ifft(fourier3)
    plt.stem(inversefourier3)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(4, 1, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    inversefourier4 = np.fft.ifft(fourier4)
    plt.stem(inversefourier4)
    plt.xlabel("Nr próbki[n]")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()
    '''
     plt.stem(real1,'r', markerfmt='ro',alpha=0.1)
    plt.stem(imaginary1,'g', markerfmt='go',alpha=0.1)
    plt.show()
    
    angle=np.angle(fourier)
    modulus=np.abs(fourier)
    plt.stem(func)
    plt.show()
    plt.stem(fourier)
    plt.show()
    plt.stem(real)
    plt.show()
    plt.stem(imaginary)
    plt.show()
    plt.stem(angle)
    plt.show()
    plt.stem(modulus)
    plt.show()
'''
    '''plt.xticks(
           [0, N / 4, N / 2, 3 * N / 4, N],
           ('0', r'$ \frac{\pi}{2}$', r'$ \pi$', r'$ \frac{3\pi}{2}$', r'$ 2\pi$'))
       '''
