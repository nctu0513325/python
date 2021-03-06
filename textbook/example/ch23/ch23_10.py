# ch23_10.py
import numpy as np

x = np.arange(16).reshape(4,4)
np.savetxt('ch23_10.txt',x,delimiter=',', header='ch23_10.txt',
           footer='bye',fmt="%d")
np.savetxt('out23_10.txt',x,delimiter=',', header='out23_10.txt',
           footer='bye',fmt="%4.2f")













