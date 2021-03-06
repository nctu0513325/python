# ch24_16.py
from scipy.optimize import root
from scipy.optimize import minimize_scalar
import matplotlib.pyplot as plt
import numpy as np
def fmax(x):
    return (-1*(-3*(x-2)**2 + 3))

def f(x):
    return (-3*(x-2)**2 + 3)

# 計算最大值
r = minimize_scalar(fmax)
print("當x是 %4.2f 時, 有函數最大值" % r.x)
print("座標是 ", r.x, f(r.x))
# 繪製此函數圖形
x = np.linspace(0, 4, 40)
y = -3*(x-2)**2 + 3
plt.plot(r.x, f(r.x), 'o')
plt.plot(x, y, '-')
plt.show()








