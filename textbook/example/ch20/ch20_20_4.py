# ch20_20_4.py
import matplotlib.pyplot as plt
import numpy as np

xpt = np.linspace(0, 5, 500)                            # 建立含500個元素的陣列
ypt = 1 - 0.5*np.abs(xpt-2)                             # y陣列的變化
lwidths = (1+xpt)**2                                    # 寬度陣列  
plt.scatter(xpt, ypt, s=50, c=ypt, cmap='hsv')          # 色彩隨y軸值變化
plt.show()




