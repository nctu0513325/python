# ch9_36.py
address_dict = {
    "洪錦魁":"台北市天天街100號",
    "洪冰雨":"台北市地地街200號",
    }
print("=================== 我的通訊錄 ===================")
for name, address in address_dict.items():
    print(name, ":", address)
print()
message = "1:新增  2:編輯  3:刪除  4:結束 \n"

while True:
    selection = input(message)
    if selection == '1':
        name = input("姓名: ")
        address = input("地址: ")
        address_dict[name] = address
        print("新增成功")
    elif selection =='2':
        while True:
            name = input("姓名: ")
            if name not in address_dict:
                print("輸入錯誤, 請重新輸入!!")
            else:
                address = input("地址: ")
                address_dict[name] = address
                break
    elif selection == '3':
        while True:
            name = input("姓名: ")
            if name not in address_dict:
                print("輸入錯誤, 請重新輸入!!")
            else:
                del address_dict[name]    
                print("刪除成功")
                break
    else:
        print("結束")
        break
    
print()    
print("=================== 新的通訊錄 ===================")    
for name, address in address_dict.items():
    print(name, ":", address)










