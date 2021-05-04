L = [77, 5, 5, 22, 13, 55, 97, 4, 796, 1, 0, 9]
K = []

while len(L) > 0:
    a = min (L)
    L.remove(a)
    K.append(a)

print("排序完的結果為:",K)