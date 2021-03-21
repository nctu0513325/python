import random as R

def ten_random ():
    L = []
     
    for i in range(10):
        L.append( R.randint(1, 50) )
    print (L)

def squaresum ():
    L = []
    n = 0
    for i in range(10):
        L.append( int(input("enter interger:")))
    for i in range(10):
        n += L[i] ** 2
    print(n)
        
ten_random()

squaresum()
        