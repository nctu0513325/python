x, y, z = eval(input("input three number:"))

if( x > y):
    a = x
    x = y
    y = a
if( x > z):
    a = x
    x = z
    z = a
if( y > z):
    a = y
    y = z
    z = a
    
print(x, "\n", y, "\n", z)