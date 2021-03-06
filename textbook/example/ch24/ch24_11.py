# ch24_11.py
import matplotlib.pyplot as plt
import scipy.stats as st
import numpy as np

x = np.linspace(-3,3,100)
plt.plot(x, st.norm.pdf(x, loc=0, scale=1))
plt.plot(x, st.norm.pdf(x, loc=-1, scale=1.5))
plt.plot(x, st.norm.pdf(x, loc=1, scale=0.5))
plt.show()











