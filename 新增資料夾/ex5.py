a = [77, 5, 5, 22, 13, 55, 97, 4, 796, 1, 0, 9]
b = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]


#交集
def inter(a, b):
    c=[]
    c_1=[]
    #找出相同項
    for i in range(len(a)):
        for j in range(len(b)):
            if a[i] == b[j]:
                c_1.append(a[i]);
    #刪除重複項
    for k in range(len(c_1)):
        if not c_1[k] in c:
            c.append(c_1[k])
    return sorted(c)

#差集
def difference (a,b):
    c=[]
    c_1=[]
    #找出不同項
    for i in range(len(a)):
        if not a[i] in b:
            c_1.append(a[i])
    #刪除重複項
    for k in range(len(c_1)):
        if not c_1[k] in c:
            c.append(c_1[k])
    return sorted(c)
    
#聯集
def union (a, b):
    c_1 = []
    c = []
    
    #將兩個list合併
    c_1 = a +b
    #刪除重複項
    for k in range(len(c_1)):
        if not c_1[k] in c:
            c.append(c_1[k])
    
    return sorted(c)

c = inter(a,b)
print('交集 c: ',c)
d = difference(a,b)
print("差集 d: ", d)
e = union(a, b)
print('聯集 e: ',e)
