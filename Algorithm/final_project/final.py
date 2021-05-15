import os
import re
import numpy as np
import Dataread

#先載入標竿問題
FileName = os.listdir (r"D:\NCTU\fifth grade\python\Algorithm\final_project\Instence")    #將標竿問題檔案名稱存成一陣列
#將FileName裡的資料都跑過一遍
for f in range(len(FileName)):
    #載入標竿問題
    instance = (FileName[f])
    
    with open("Instence/" + instance) as ins:
        #==============載入資料================
        data = ins.readlines()          #txt檔里全部數據        
        NUM = data[0].split()
        Num_of_Job = int(NUM[0])         #紀錄JOB數
        Num_of_Machine = int(NUM[1])     #紀錄machine數
        Proc_Time = np.zeros((Num_of_Job, Num_of_Machine))      #initialize 
        Setup_Time = np.zeros((Num_of_Machine, Num_of_Job, Num_of_Job))      #initialize 
        #processtime 資料
        for j in range(2,Num_of_Job + 2):                        
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
            for k in range(Num_of_Job):
                Setup_Time[i][j-(4+Num_of_Job)-Num_of_Job*i-i][k] = item[k]
            x = x + 1
        print("set_up time= " , Setup_Time)
        print("process time =", Proc_Time)
    #===========資料載入完畢==========

    #參數設定
    Num_of_Machine                #機台個數
    Num_of_Job                    #JOB數
    Proc_Time                       
    Setup_Time                     
    iteration = 200                  #迴圈個數
    NUM_CHROME = 3                     #染色體個數
    Pc = 0.5    					# 交配率 (代表共執行Pc*NUM_CHROME/2次交配)
    Pm = 0.1   					# 突變率 (代表共要執行Pm*NUM_CHROME*NUM_BIT次突變)
    NUM_BIT = Num_of_Job
    
    NUM_PARENT = NUM_CHROME                         # 父母的個數
    NUM_CROSSOVER = int(Pc * NUM_CHROME / 2)        # 交配的次數
    NUM_CROSSOVER_2 = NUM_CROSSOVER*2               # 上數的兩倍
    NUM_MUTATION = int(Pm * NUM_CHROME * NUM_BIT)   # 突變的次數
    #np.random.seed(0)
    
    #GA相關函數
    #初始化群體
    def init_pop():
        pop = []
        x = (Num_of_Machine-1)*Num_of_Job
        for i in range(NUM_CHROME):
            y = np.random.permutation(range(0,Num_of_Job))              #產生Num_of_job個數的排列
            y = np.pad(y, (0,x), 'constant', constant_values=(0,-1))    #塞入-1當作作業停止
            np.random.shuffle(y)                                        #打亂順序
            y = y.reshape((Num_of_Machine, Num_of_Job))
            for j in range(len(y)):
                Dataread.list_order(y[j])
            pop.append(y)
        return pop
    #適應度函數
    def fitfunction(x):
        time = np.zeros(Num_of_Machine)
        for i in range(len(x)):
            for j in range(Num_of_Job):
                if (x[i][j] != -1):
                    if (j != 0):
                        time[i] += Setup_Time[i][x[i][j-1]][x[i][j]]
                    time[i] += Proc_Time[x[i][j]][i]
        return -np.amax(time)
    #評估群體適應度
    def evaluatePop(x):
        return [fitFunc(p[i]) for i in range(len(p))]
    #利用二元式
    #主程式
    pop = init_pop()
    print("pop[0]= ", pop[0])
    fitfunction(pop[0])