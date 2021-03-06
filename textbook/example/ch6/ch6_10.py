# ch6_10.py
james = [23, 19, 22, 31, 18]        # 定義james的5場比賽得分
games = len(james)                  # 獲得場次數據    
print("經過 %d 場比賽最高得分 = " % games, max(james))
print("經過 %d 場比賽最低得分 = " % games, min(james))
print("經過 %d 場比賽得分總計 = " % games, sum(james))
    
