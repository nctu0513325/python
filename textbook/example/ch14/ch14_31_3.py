# ch14_31_3.py
dst = 'bdata'
bytedata = bytes(range(0,256))
with open(dst, 'wb') as file_dst:
    file_dst.write(bytedata)








