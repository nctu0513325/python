#Q1
st = input("enter an interger:")

n = int(st)

L = list(st)

L.sort()

p = len(L)
m = 0

for i in range(len(L)):
    m = m + int(L[i])*(10**(p-i-1))

m = m +n
    
print( "the result is " , m )

#Q2

L = [123, 4, 567, 9801, 1234, 0] 

for i in range(len(L)):
    L[i]  = str(L[i])

L.sort(key = len, reverse=True)

for i in range(len(L)):
    L[i]  = int(L[i])

print(L)