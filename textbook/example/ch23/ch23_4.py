# ch23_4.py
import numpy as np
import matplotlib.pyplot as plt

x = np.linspace(0, 10, 20)
y = np.sin(x)

xvals = np.linspace(0, 10, 100)
yinterp = np.interp(xvals, x, y)

plt.plot(x, y, 'o')
plt.plot(xvals, yinterp, '-x')
plt.show()









