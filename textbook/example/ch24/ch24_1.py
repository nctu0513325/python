# ch24_1.py
import numpy as np
from scipy import linalg

# 定義陣列
coeff = np.array([[3,2,0],[1,-1,0],[0,5,1]])
deps = np.array([8,1,10])

# 求解
ans = linalg.solve(coeff, deps)

print(ans)









