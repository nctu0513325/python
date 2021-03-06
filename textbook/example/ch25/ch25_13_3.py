# ch25_13_3.py
import pandas as pd

fn = 'score_out2.xlsx'

df_test1 = pd.DataFrame({
    'Name':['Tom', 'John'],
    'Math':[88, 92],
    'English':[76, 96],
    'Total':[164, 188]
})
df_test2 = pd.DataFrame({
    'Name':['Tom', 'John'],
    'Math':[100, 92],
    'English':[99, 96],
    'Total':[199, 188]
})

with pd.ExcelWriter(fn) as writer:
    df_test1.to_excel(writer, index=False, sheet_name='test1')
    df_test2.to_excel(writer, index=False, sheet_name='test2')



















