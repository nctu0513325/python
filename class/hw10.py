def leftpad(s, n, c='0'):
    x = len(s)
    y = len(c)
    
    a = (n-x) // y
    b = (n-x) % y
    
    if (n <= x):
        result = s
    else:
        result = c[len(c)-b:] + a*c +s
    return result

