S1 = set()
while True:
    x = int(input('Input a positive number for S1: '))
    if x < 0:
        break
    else:
        S1.add(x)
S2 = set()
while True:
    x = int(input('Input a positive number for S2: '))
    if x < 0:
        break
    else:
        S2.add(x)

L1 = list(S1.union(S2))
L2 = list(S1.intersection(S2))
n1 = 0
print("S1 = ", S1)
print("S2 = ", S2)


for i in range(len(L2)):
    if (L2[i]%2 == 0):
        n1 = n1 + 1
    
print('The probability of even numbers in S1 and S2 is: ', (n1/len(L1)))
print('The conditional probability of even numbers under S2 is: ', (n1/len(S2)))