a = input("enter a string:")

b = len(a)

i=0

for i in range (b):
    if( a[i].islower() ):
        print (a[i].upper(),end="")
    
    elif( a[i].upper() ):
        print (a[i].lower(),end="")
    else:
        print(a[i],end="")
