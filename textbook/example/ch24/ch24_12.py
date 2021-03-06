# ch24_12.py
from scipy.optimize import root
def f(x):
    return (a*x**2 + b*x + c)

a = 3
b = 5
c = 1
r1 = root(f,0)          # 初始迭代值0
print(r1.x)
r2 = root(f,-1)         # 初始迭代值-1
print(r2.x)












