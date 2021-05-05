m = int(input('for m*n list, enter m: '))
n = int(input('for m*n list, enter n: '))

L = [[y * n + x if y % 2 == 0 else (y+1)*n-x-1 for x in range(n)] for y in range(m)]

print(L)  