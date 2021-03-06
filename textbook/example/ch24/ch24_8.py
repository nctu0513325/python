# ch24_8.py
import matplotlib.pyplot as plt
import scipy.stats as st

x = st.norm.rvs(size=1000)
plt.hist(x, bins=20, density=True)
plt.ylabel("Frequency")
plt.show()











