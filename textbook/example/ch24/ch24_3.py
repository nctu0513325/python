# ch24_3.py
import numpy as np
from scipy import linalg

A = np.array([[1,2],[3,4]])     # 定義陣列
l, v = linalg.eig(A)            
print("特徵值   : ", l)
print("特徵向量 : \n", v)








