# ch14_26_1.py
fn = 'out14_26.txt'
string = 'I love Python.'

with open(fn, 'w') as file_Obj:
    print(file_Obj.write(string))

