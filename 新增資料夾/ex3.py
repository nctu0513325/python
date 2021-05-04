L = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]

odd = []
even = []

for i in range(len(L)):
    if L[i] % 2 == 0:
        even.append(L[i])
    elif L[i] %2 == 1:
        odd.append(L[i])

print("奇數值總和減偶數值總和 = " , sum(odd) - sum(even) )
print("儲存偶數值的List",even)
print("儲存奇數值的LIST",odd)