def list_order(y):
    pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
    pos_2 = [i for i, x in enumerate(y) if (x > 0 or x ==0)]
    print(max(pos_2))
    print(min(pos_1))
    
    while ((max(pos_2)+1) != (min(pos_1))):
        
        y[min(pos_1)], y[max(pos_2)] = y[max(pos_2)], y[min(pos_1)]
        pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
        pos_2 = [i for i, x in enumerate(y) if x > 0]
        print("pos_1 = ", pos_1)
        print("pos_2 = ", pos_2)
        print(y, len(y))
        
        
    '''for i in range(len(y)-1):
        for j in range(len(y)-1):
            if (y[i] < 0 ):
                y[i], y[i+1] = y[i+1], y[i]'''
    