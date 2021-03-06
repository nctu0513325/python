# ch24_7.py
import matplotlib.pyplot as plt
import scipy.stats as st

x = st.norm.rvs(size=1000)
plt.hist(x)     
plt.ylabel("Times")
plt.show()











