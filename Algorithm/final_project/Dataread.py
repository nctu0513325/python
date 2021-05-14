def list_order(y):
    pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
    pos_2 = [i for i, x in enumerate(y) if x >= 0]
    
    while ((max(pos_2)+1) != (min(pos_1))):        
        y[min(pos_1)], y[max(pos_2)] = y[max(pos_2)], y[min(pos_1)]
        pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
        pos_2 = [i for i, x in enumerate(y) if x >= 0]
        
