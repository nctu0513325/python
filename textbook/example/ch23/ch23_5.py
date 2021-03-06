# ch23_5.py
import numpy as np
import matplotlib.pyplot as plt

d1 = np.random.randint(1,6+1,1000)
d2 = np.random.randint(1,6+1,1000)
dsums = d1 + d2

plt.hist(dsums, bins=11)
plt.show()









