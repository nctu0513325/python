# enter four type of coin
c_1 = int(input("enter the first type of coin:"))
c_2 = int(input("enter the second type of coin:"))
c_3 = int(input("enter the third type of coin:"))
c_4 = int(input("enter the forth type of coin:"))
l = [c_1, c_2, c_3, c_4]

# enter price and purchase
price = int(input("請輸入價錢:"))
purchase = int(input("輸入purchase:"))

change = purchase - price

print("The change will be ", change, "dollars")

# calculate number of change
c50 = change // l[0]
c10 = (change % l[0]) // l[1]
c5  = (change % l[0] % l[1]) // l[2]
c1  = (change % l[0] % l[1] % l[2]) // l[3]

print("50 * ", c50 )
print("10 * ", c10 )
print("5 * ", c5 )
print("1* ", c1 )