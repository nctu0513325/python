L = [10, 20, 30, 40, 'ABC', '123', '456']

for i in range(len(L) - 1) :
    if type(L[i]) == type(L[i + 1]):
        continue
    elif type(L[i]) != type(L[i+1]):
        n = i + 1
        break

temp = L[0:n]
L[0:n] = L[n:]
L[n:] = temp

print(L)