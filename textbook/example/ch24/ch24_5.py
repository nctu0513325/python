# ch24_5.py
import numpy as np
import matplotlib.pyplot as plt
import scipy.stats as st

n_trials = 50
x = np.arange(n_trials)

plt.plot(x, st.binom(n_trials, 0.5).pmf(x), '-o', label='p=0.5, n=50')
plt.plot(x, st.binom(n_trials, 0.3).pmf(x), '-o', label='p=0.3, n=50')
plt.plot(x, st.binom(n_trials, 0.7).pmf(x), '-o', label='p=0.7, n=50')
plt.title("Binomial Distribution")
plt.xlabel("Probability Mass Function")
plt.legend()
plt.show()











