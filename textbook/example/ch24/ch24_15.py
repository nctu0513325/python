# ch24_15.py
from scipy.optimize import root
from scipy.optimize import minimize_scalar
import matplotlib.pyplot as plt
import numpy as np
def f(x):
    return (3*(x-2)**2 - 2)

# 計算最小值
r = minimize_scalar(f)
print("當x是 %4.2f 時, 有函數最小值" % r.x)
print("座標是 ", r.x, f(r.x))
# 繪製此函數圖形
x = np.linspace(0, 4, 40)
y = 3*(x-2)**2 - 2
plt.plot(r.x, f(r.x), 'o')
plt.plot(x, y, '-')
plt.show()










