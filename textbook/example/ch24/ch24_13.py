# ch24_13.py
from scipy.optimize import root
def fun(x):
    return (a*x[0]+b*x[1]+c, d*x[0]+e*x[1]+f)

a = 2
b = 3
c = -13
d = 1
e = -2
f = 4
r =  root(fun,[0,0])    # 初始迭代值0, 0
print(r.x)














