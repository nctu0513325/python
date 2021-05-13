def list_order(y):
    pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
    pos_2 = [i for i, x in enumerate(y) if (x > 0 or x ==0)]
    
    while ((max(pos_2)+1) != (min(pos_1))):
        
        y[min(pos_1)], y[max(pos_2)] = y[max(pos_2)], y[min(pos_1)]
        pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
        pos_2 = [i for i, x in enumerate(y) if x >= 0]
        
        
    '''for i in range(len(y)-1):
        for j in range(len(y)-1):
            if (y[i] < 0 ):
                y[i], y[i+1] = y[i+1], y[i]'''
    