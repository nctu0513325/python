# ch23_6.py
import numpy as np
import matplotlib.pyplot as plt

mean, sigma = 0, 0.2
s = np.random.normal(mean, sigma, 1000)

plt.hist(s, bins=30)
plt.show()









