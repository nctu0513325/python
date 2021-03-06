# ch24_4.py
import numpy as np
import matplotlib.pyplot as plt
import scipy.stats as st

rv = st.randint(low=1, high=11)
x = np.arange(1, 11)
plt.plot(x, rv.pmf(x), 'o')
plt.vlines(x, 0, rv.pmf(x), linestyles='dashed')
plt.show()










