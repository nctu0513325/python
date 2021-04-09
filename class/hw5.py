A = [ 1, 3, 7, 2, 4]

a = 0
for i in range( len(A) ):
    a = a + A[i]
    i = i+1
    
i=0
a = a/len(A)
v = 0

while i < (len(A)):
    v = v + (A[i] - a ) ** 2
    i = i+1

s = (v / ( len(A) - 1) ) ** 0.5

print("AVG= ", a, "STD= ", s)