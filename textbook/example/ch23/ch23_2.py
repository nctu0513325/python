# ch23_2.py
import numpy as np

A = 0
X = np.arange(1,101).reshape(10,10)
print(X)
for x in X:
    A += x
print(type(A))
print("A = ", A)

sum = 0
for a in A:
    sum += a
print(type(sum))
print("sum = ", sum)







