# ch24_2.py
import numpy as np
from scipy import linalg

A = np.array([[1,2],[3,4]])     # 定義陣列
x = linalg.det(A)               # 求解
print(x)









