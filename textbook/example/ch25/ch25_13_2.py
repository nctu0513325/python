# ch25_13_2.py
import pandas as pd

fn = 'score_out.xlsx'

df = pd.DataFrame({
    'Name':['Tom', 'John'],
    'Math':[88, 92],
    'English':[76, 96],
    'Total':[164, 188]
})

df.to_excel(fn, index=False)
   



















