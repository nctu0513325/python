def list_order(y):
    pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
    pos_2 = [i for i, x in enumerate(y) if x >= 0]      #正數位置

    if ( (len(pos_1) != 0) and (len(pos_2) != 0)):        
        while ((max(pos_2)+1) != (min(pos_1))):        
            y[min(pos_1)], y[max(pos_2)] = y[max(pos_2)], y[min(pos_1)]     #將正數位置與負數位置互換
            pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
            pos_2 = [i for i, x in enumerate(y) if x >= 0]          #正數位置
