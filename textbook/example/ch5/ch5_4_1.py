# ch5_4_1.py
x, y = eval(input("請輸入2個數字："))
max_ = x if x > y else y
print("方法 1 最大值是 : ", max_)
max_ = max(x, y)
print("方法 2 最大值是 : ", max_)

min_ = x if x < y else y
print("方法 1 最小值是 : ", min_)
min_ = min(x, y)
print("方法 2 最小值是 : ", min_)

