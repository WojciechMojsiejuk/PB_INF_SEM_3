import matplotlib.pyplot as plt
import numpy as np
mi=0
delta=np.sqrt(0.5)
y=np.random.normal(mi,delta,200)
plt.figure()
plt.plot(y)
plt.title("Wykres szumu gaussowskiego, "+r'$\mu$ ='+str(round(np.mean(y),5))+r' $\delta ^2$ ='+str(round(np.var(y),5)))
plt.xlabel("Numer próbki")
plt.ylabel("Wartość chwilowa")
print("Wariancja="+str(np.var(y)))

plt.show()