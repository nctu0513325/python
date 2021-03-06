# ch23_3.py
import numpy as np

X = np.arange(1,101).reshape(10,10)
A = np.sum(X, axis=0)
print("A = ", A)
sum = np.sum(X)
print("sum = ", sum)







