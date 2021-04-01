x = input("input x")
y = input("input y")

try:
    float(x)
    
    try:
        float(y)
        print(float(x) + float(y))
        
    except ValueError:
        print(x)
        
except ValueError:
    
    try:
        float(y)
        print(x+y)
        
    except ValueError:
        print(len(x) + len(y))  