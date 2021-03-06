# ch24_9.py
import matplotlib.pyplot as plt
import scipy.stats as st
import numpy as np

x = st.norm.rvs(size=1000)
plt.hist(x, bins=20, density=True)
plt.ylabel("Frequency")

xs = np.linspace(-3,3,100)
plt.plot(xs,st.norm.pdf(xs), 'r-')

plt.show()











