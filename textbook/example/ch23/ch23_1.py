# ch23_1.py
import numpy as np

sum = 0
ave = 0
x = np.array([88, 92, 90, 0, 0])
for data in x:
    sum += data
x[3] = sum
x[4] = sum / 3
print(x)





