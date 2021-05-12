import os
import re
import numpy as np

#先載入標竿問題
FileName = os.listdir (r"G:\NCTU\python\Algorithm\final_project\Instence")    #將標竿問題檔案名稱存成一陣列
#將FileName裡的資料都跑過一遍
for f in range(len(FileName)):
    #載入標竿問題
    instance = (FileName[f])
    
    with open("Instence/" + instance) as ins:
        #開始實作
        #載入數據
        data = ins.readlines()          #txt檔里全部數據        
        print(data)
        NUM = data[0].split()
        Num_of_Job = int(NUM[0])         #紀錄JOB數
        Num_of_Machine = int(NUM[1])     #紀錄machine數
        #儲存工作時間
        Proc_Time = np.zeros((Num_of_Job, Num_of_Machine))      #initialize 
        Setup_Time = np.zeros((Num_of_Machine, Num_of_Job, Num_of_Job))      #initialize 
        print(Setup_Time)
        for j in range(2,Num_of_Job+2):                        
            data[j] = re.sub('\n', '',data[j])                  #process time資料
            item = []
            item = data[j].split('\t')
            for k in range(2, len(item), 2): 
                Proc_Time[j-2][((k-2)//2)] = item[k]
        #儲存set_up_time
        i = 0                               #number of machine
        x = 0
        for j in range(4+Num_of_Job,len(data)):             #讀取完剩下的資料(set up time)
            if (x == Num_of_Job):
                x = 0
                i = i + 1
                continue
            
            data[j] = re.sub('\n', '',data[j])                  #process time資料
            item = []
            item = data[j].split('\t')
            print(item, "j= ", j)
            for k in range(Num_of_Job):
                Setup_Time[i][j-(4+Num_of_Job)-Num_of_Job*i-i][k] = item[k]
            x = x + 1
        