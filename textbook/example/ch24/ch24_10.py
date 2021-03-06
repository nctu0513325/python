# ch24_10.py
import matplotlib.pyplot as plt
import scipy.stats as st
from scipy.integrate import trapz
import numpy as np

x = np.linspace(-3,3,100)
plt.plot(x, st.norm.pdf(x), 'r-')

xs = np.linspace(-2,2,100)
p = trapz(st.norm.pdf(xs), xs)
print("落在-2與2之件的機率是 %4.2f" % (100*p) + "%")
plt.fill_between(xs, st.norm.pdf(xs), color="yellow")

plt.show()











