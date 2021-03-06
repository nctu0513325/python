# ch24_19.py
import numpy as np
import matplotlib.pyplot as plt
from scipy.interpolate import interp1d

x = np.linspace(0,20,21)
y = np.sin(x**2/5.0)

fLinear = interp1d(x,y)                             # Linear插值函數
fCubic = interp1d(x,y,kind='cubic')                 # Cubic插值函數
xnew = np.linspace(0,20,61)                         # 擴充的x軸數據

plt.plot(x,y,'o',label='data')
plt.plot(xnew,fLinear(xnew),'-',label='linear')     # Linear
plt.plot(xnew,fCubic(xnew),'--',label='cubic')      # Cubic

plt.legend(loc='best')
plt.show()



      














