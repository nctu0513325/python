# ch24_17.py
import numpy as np
import matplotlib.pyplot as plt
from scipy.interpolate import interp1d

x = np.linspace(0,20,21)
y = np.sin(x**2/5.0)
plt.plot(x,y,'o',label='data')
plt.legend(loc='best')
plt.show()



      














