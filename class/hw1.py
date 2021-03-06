price = int(input("請輸入價錢:"))
purchase = int(input("輸入purchase:"))

change = purchase - price

print("The change will be ", change, "dollars")

c50 = change // 50
c10 = (change % 50) // 10
c5  = (change % 50 % 10) // 5
c1  = (change % 50 % 10 % 5) // 1

print("50 * " , c50 )
print("10 * " , c10 )
print("5 * " , c5 )
print("1* " , c1 )