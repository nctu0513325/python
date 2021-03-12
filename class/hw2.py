L = [10, 20, 30, 'ABC', '123', '456']

temp = L[0:3]
L[0:3] = L[3:]
L[3:] = temp

print(L)