import matplotlib.pyplot as plt
import numpy as np
from scipy import signal
x=np.linspace(0,40,40)
y=signal.unit_impulse(40,0)
plt.title("Impuls oraz impuls przesunięty o N=40 próbek")
plt.xlabel("Numer próbki")
plt.ylabel("Wartość próbki")
plt.stem(x,y)
plt.xticks((0,10,20,30,40))
plt.yticks((0,1))
y2=signal.unit_impulse(40,39)
plt.stem(x,y2)
plt.show()