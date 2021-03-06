# ch23_7.py
import numpy as np
import matplotlib.pyplot as plt

s = np.random.triangular(-2, 0, 10, 10000)
plt.hist(s, bins=200, density=True)
plt.show()









