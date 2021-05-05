st = '人易科技: 上 機 測 驗 - 演算法'

st_1=''
#將:改全形
for i in range(len(st)):
    if (st[i] == ':'):
        u_code = ord(st[i])
        u_code += 65248
        st_1 += chr(u_code)
    else:
        st_1 += chr(ord(st[i]))
print(st_1) #印出結果

#刪除空白
st_2 = st.replace(' ','')
index = st_2.find('-')
st_2final = st_2[:index] + ' ' + st_2[index] + ' ' + st_2[index+1:]

print(st_2final)  #印出結果
#印出:到-的字元
for i in range(len(st)):
    if (st[i] == ':'):
        n = i
    if (st[i] == '-'):
        m = i
print(st[n+1:m]) #印出結果
