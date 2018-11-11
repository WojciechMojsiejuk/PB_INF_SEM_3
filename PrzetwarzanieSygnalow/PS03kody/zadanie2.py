import matplotlib.pyplot as plt
import numpy as np

# funkcje wykorzystane w zadaniu

def y1(N):
    n = np.arange(0,N)
    phase = np.pi/4
    y = np.cos(2 * np.pi * n/N +phase)
    return y


def y2(N):
    n = np.arange(0,N)
    phase = 0
    y = 0.5 * np.cos(4 * np.pi*n/N + phase)
    return y


def y3(N):
    n = np.arange(0,N)
    phase = np.pi / 2
    y = 0.25 * np.cos( 8 * np.pi*n/N + phase)
    return y


def y4(y1, y2, y3):
    a = y1 + y2 + y3
    return a


if __name__ == "__main__":
    N = 32  # zmienna okreslająca ilość próbek

    # Wygenerowanie funkcji
    func1 = y1(N)
    func2 = y2(N)
    func3 = y3(N)
    func4 = y4(func1, func2, func3)

    # Część rzeczywista funkcji sinusoidalnych
    plt.figure().suptitle("Część rzeczywista funkcji sinusoidalnych")
    plt.subplot(2, 2, 1)
    plt.plot(func1)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.title(r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(2, 2, 2)
    plt.plot(func2)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(2, 2, 3)
    plt.plot(func3)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(2, 2, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.plot(func4)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()
    

    # Wyliczenia transformat Fouriera oraz innych parametrów dla każdej funkcji
    fourier1 = 2*np.fft.fft(func1)/N
    real1 = fourier1.real
    imaginary1 = fourier1.imag
    angle1 = np.angle(fourier1)
    modulus1 = np.abs(fourier1)

    fourier2 = 2*np.fft.fft(func2)/N
    real2 = fourier2.real
    imaginary2 = fourier2.imag
    angle2 = np.angle(fourier2)
    modulus2 = np.abs(fourier2)

    fourier3 = 2*np.fft.fft(func3)/N
    real3 = fourier3.real
    imaginary3 = fourier3.imag
    angle3 = np.angle(fourier3)
    modulus3 = np.abs(fourier3)

    fourier4 = 2*np.fft.fft(func4)/N
    real4 = fourier4.real
    imaginary4 = fourier4.imag
    angle4 = np.angle(fourier4)
    modulus4 = np.abs(fourier4)

    # Część urojona funkcji sinusoidalnych
    plt.figure().suptitle("Część urojona funkcji sinusoidalnych")
    plt.subplot(2, 2, 1)
    plt.plot(func1.imag)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.title(r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(2, 2, 2)
    plt.plot(func2.imag)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(2, 2, 3)
    plt.plot(func3.imag)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(2, 2, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.plot(func4.imag)
    plt.xlabel("Nr próbki")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()

    # Transformata Fouriera cz. rzeczywista
    plt.figure().suptitle("Część rzeczywista Transformaty Fouriera")
    plt.subplot(2, 2, 1)
    plt.ylim(-0.05, 0.8)
    plt.stem(real1)
    plt.hlines(np.abs(round(real1[1], 3)), 0, 32, colors="red", linestyles="dotted")
    plt.yticks((0,0.25,0.5, np.abs(round(imaginary1[1], 3))))
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.title(r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(2, 2, 2)
    plt.ylim(-0.05, 0.8)
    plt.yticks((0,0.250, np.abs(round(real2[2], 3)),0.707))
    plt.stem(real2)
    plt.hlines(np.abs(round(real2[2], 3)), 0, 32, colors="orange", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(2, 2, 3)
    plt.ylim(-0.05, 0.8)
    plt.yticks((np.abs(round(real3[4], 3)),0.250,0.50,0.707))
    plt.stem(real3)
    plt.hlines(np.abs(round(real3[4], 3)), 0, 32, colors="gold", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(2, 2, 4)
    plt.ylim(-0.05, 0.8)
    plt.yticks((np.abs(round(real3[4], 3)), 0.25, np.abs(round(real2[2], 3)),np.abs(round(real1[1], 3)) ))
    plt.hlines(np.abs(round(real1[1], 3)), 0, 32, colors="red", linestyles="dotted")
    plt.hlines(np.abs(round(real2[2], 3)), 0, 32, colors="orange", linestyles="dotted")
    plt.hlines(np.abs(round(real3[4], 3)), 0, 32, colors="gold", linestyles="dotted")
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(real4)
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()


    # Transformata Fouriera cz. urojona
    plt.figure().suptitle("Część urojona Transformaty Fouriera")
    plt.subplot(2, 2, 1)
    plt.hlines(-np.abs(round(imaginary1[1],3)), 0, 32, colors="red", linestyles="dotted")
    plt.yticks((-np.abs(round(imaginary1[1], 3)), 0, np.abs(round(imaginary1[1], 3)),))
    plt.stem(imaginary1)
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.title(r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(2, 2, 2)
    plt.stem(imaginary2)
    plt.ylim(-1, 1)
    plt.hlines(-np.abs(round(imaginary2[2],3)), 0, 32, colors="orange", linestyles="dotted")
    plt.hlines(np.abs(round(imaginary2[2],3)), 0, 32, colors="orange", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(2, 2, 3)
    plt.stem(imaginary3)
    plt.yticks((-np.abs(round(imaginary3[4],3)), 0, np.abs(round(imaginary3[4],3)),))
    plt.hlines(-np.abs(round(imaginary3[4],3)), 0, 32, colors="gold", linestyles="dotted")
    plt.hlines(np.abs(round(imaginary3[4],3)), 0, 32, colors="gold", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(2, 2, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(imaginary4)
    plt.yticks((-np.abs(round(imaginary1[1], 3)),-np.abs(round(imaginary3[4], 3)), 0, np.abs(round(imaginary3[4], 3)),np.abs(round(imaginary1[1], 3))))
    plt.hlines(-np.abs(round(imaginary1[1],3)), 0, 32, colors="red", linestyles="dotted")
    plt.hlines(np.abs(round(imaginary1[1],3)), 0, 32, colors="red", linestyles="dotted")
    plt.hlines(-np.abs(round(imaginary2[2],3)), 0, 32, colors="orange", linestyles="dotted")
    plt.hlines(np.abs(round(imaginary2[2],3)), 0, 32, colors="orange", linestyles="dotted")
    plt.hlines(-np.abs(round(imaginary3[4],3)), 0, 32, colors="gold", linestyles="dotted")
    plt.hlines(np.abs(round(imaginary3[4],3)), 0, 32, colors="gold", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Amplituda")
    plt.tight_layout()
    plt.show()

    # Transformata Fouriera kąt
    plt.figure().suptitle("Kąt Transformaty Fouriera")
    plt.subplot(2, 2, 1)
    plt.text(0.5,0.3,str(round(angle1[1]/np.pi,3)))
    plt.hlines(0.25, 0, 32, colors="red", linestyles="dotted")
    plt.stem(angle1/np.pi)
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Faza[pi*rad]")
    plt.title(r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(2, 2, 2)
    plt.text(1.5,0.1,str(np.abs(round(angle2[2] / np.pi,3))))
    plt.hlines(0.0, 0, 32, colors="orange", linestyles="dotted")
    plt.stem(angle2/np.pi)
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Faza[pi*rad]")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(2, 2, 3)
    plt.text(3.5,0.6,str(round(angle3[4] / np.pi,3)))
    plt.hlines(0.5, 0, 32, colors="gold", linestyles="dotted")
    plt.stem(angle3/np.pi)
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Faza[pi*rad]")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(2, 2, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(angle4/np.pi)
    plt.text(1.5, 0.1, str(np.abs(round(angle4[2] / np.pi, 3))))
    plt.text(0.5, 0.3, str(np.abs(round(angle1[1] / np.pi, 3))))
    plt.text(3.5, 0.6, str(np.abs(round(angle4[4] / np.pi, 3))))
    plt.hlines(0.25, 0, 32, colors="red", linestyles="dotted")
    plt.hlines(0.0, 0, 32, colors="orange", linestyles="dotted")
    plt.hlines(0.5, 0, 32, colors="gold", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Faza[pi*rad]")
    plt.tight_layout()
    plt.show()

    # Transformata Fouriera moduł
    plt.figure().suptitle("Moduł z Transformaty Fouriera")
    plt.subplot(2, 2, 1)
    plt.stem(modulus1)
    plt.ylim(-0.05,1.1)
    plt.text(1, round(modulus1[1], 3)+0.03, str(round(modulus1[1], 3)))
    plt.hlines(modulus1[1], 0, 32, colors="red", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Magnituda")
    plt.title(r'$y_1=\cos$(2$\pi \cdot \frac{n}{N}$+$\frac{\pi}{4}$)')
    plt.subplot(2, 2, 2)
    plt.stem(modulus2)
    plt.ylim(-0.025,0.6)
    plt.text(2, round(modulus2[2], 3)+0.03, str(round(modulus2[2], 3)))
    plt.hlines(modulus2[2], 0, 32, colors="orange", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Magnituda")
    plt.title(r'$y_2=\frac{1}{2}\cos$(4$\pi \cdot \frac{n}{N}$)')
    plt.subplot(2, 2, 3)
    plt.stem(modulus3)
    plt.ylim(-0.00125, 0.4)
    plt.text(4, round(modulus3[4], 3)+0.03, str(round(modulus3[4], 3)))
    plt.hlines(modulus3[4], 0, 32, colors="gold", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Magnituda")
    plt.title(r'$y_3=\frac{1}{4}\cos$(8$\pi \cdot \frac{n}{N}$ +$\frac{\pi}{2}$)')
    plt.subplot(2, 2, 4)
    plt.title(r'$y_4$ = $y_1+y_2+y_3$')
    plt.stem(modulus4)
    plt.ylim(-0.05, 1.1)
    plt.text(0.5, round(modulus1[1]+0.03, 3), str(np.abs(round(modulus1[1], 3))))
    plt.hlines(modulus1[1], 0, 32, colors="red", linestyles="dotted")
    plt.text(1.5, round(modulus2[2]+0.03, 3), str(np.abs(round(modulus2[2], 3))))
    plt.hlines(modulus2[2], 0, 32, colors="orange", linestyles="dotted")
    plt.text(3.5, round(modulus3[4], 3)+0.03, str(np.abs(round(modulus3[4], 3))))
    plt.hlines(modulus3[4], 0, 32, colors="gold", linestyles="dotted")
    plt.xlabel("Nr pasma częstotliwościowego")
    plt.ylabel("Magnituda")
    plt.tight_layout()
    plt.show()

'''
Transformata jest adytywna
    Jaki jest związek pomiędzy amplitudą, fazą, liczbą okresów poszczególnych sygnałów a wartościami widma zespolonego?
        ● Przekształcenie Fouriera jest homogeniczne.
        ● Przesunięcie sygnału w czasie nie zmienia amplitudy jego transformaty, natomiast wpływ na jej fazę.
        ● Zwiększenie liczby okresów sygnału („przyspieszenie”) spowoduje poszerzenie widma częstotliwościowego (wystąpienie większych częstotliwości).
    '''
