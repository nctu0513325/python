L = [10, 20, 30, 40, 'ABC', '123', '456']

if (len(L) % 2) == 0 :
    n = len(L) // 2
    L[:n], L[n:]  = L[n:], L[:n]
    
    
elif (len(L) % 2) == 1 :
    n = len(L) // 2 + 1
    temp = L[0:n]
    L[0:n-1] = L[n:]
    L[n-1:] = temp

print(L)