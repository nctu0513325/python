import random as R

def ten_random ():
    for i in range(10):
        L[i] = R.randint(1, 50)

def squaresum ():
    for i in range(10):
        L[i] = int(input("enter interger:"))
    for i in range(10):
        n = L[i] ** 2
        
ten_random()

squaresum()
        