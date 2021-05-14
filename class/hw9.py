from collections import Counter
S = " xyz abc xyz abc abc ABC "
set_1 = set(L)
cnt = Counter(S)
number = []
word = []
for i in set_1:
    word.append(i)
    number.append(S.count(i))

for i in range (len(number)):
    for j in range(i,len(number)):
        if (number[i] > number[j] ):
            number[i], number[j] = number[j], number[i]
            word[i], word[j] = word[j], word[i]

for i in range(len(number)):
    print(word[i], ':', number[i])