import os
import re
import numpy as np
import csv
import time

#==========其他函數==========
# 將-1 移至工作順序最後面
def list_order(y):
    pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
    pos_2 = [i for i, x in enumerate(y) if x >= 0]      #正數位置

    if ( (len(pos_1) != 0) and (len(pos_2) != 0)):        
        while ((max(pos_2)+1) != (min(pos_1))):        
            y[min(pos_1)], y[max(pos_2)] = y[max(pos_2)], y[min(pos_1)]     #將正數位置與負數位置互換
            pos_1 = [i for i, x in enumerate(y) if x == -1]      #負數位置
            pos_2 = [i for i, x in enumerate(y) if x >= 0]          #正數位置

#==========GA相關函數==========
# 初始化群體
def init_pop():
    pop = []
    x = (Num_of_Machine-1)*Num_of_Job
    for i in range(NUM_CHROME):
        y = np.random.permutation(range(0,Num_of_Job))              #產生Num_of_job個數的排列
        y = np.pad(y, (0,x), 'constant', constant_values=(0,-1))    #塞入-1當作作業停止
        np.random.shuffle(y)                                        #打亂順序
        y = y.reshape((Num_of_Machine, Num_of_Job))
        for j in range(len(y)):
            list_order(y[j])
        pop.append(y)
    return pop

# 適應度函數
def fitfunction(x):
    makesspan = np.zeros(Num_of_Machine)
    for i in range(len(x)):
        for j in range(Num_of_Job):
            if (x[i][j] != -1):
                if (j != 0):
                    makesspan[i] += Setup_Time[i][x[i][j-1]][x[i][j]]
                makesspan[i] += Proc_Time[x[i][j]][i]
    return -np.amax(makesspan)

# 評估群體適應度
def evaluatePop(p):
    return [fitfunction(p[i]) for i in range(len(p))]

# N-tournament selection
def select(pop, pop_fit, Num_pressure):
    a = []
    a_fit = []
    fit_select = np.random.choice(NUM_CHROME, Num_pressure, replace = False)
    for i in range(len(fit_select)):
        if (pop_fit[i] > a_fit):
            print('pop_fit[i]=', pop_fit[i])
            a = pop[i]
            a_fit = pop_fit[i]
    print('a = ', a)
    print('a_fit = ', a_fit)
    return a

# local search enhanced
def local_search_enhanced(pop, pop_fit):
    a = []
    parent_1 = []
    parent_2 = []
    child_1 = np.zeros((Num_of_Machine, Num_of_Job))
    child_2 = np.zeros((Num_of_Machine, Num_of_Job))
    
    for i in range(NUM_CROSSOVER):
        parent_1 = select(pop, pop_fit)
        parent_2 = select(pop, pop_fit)
        print("paren_1 = ", parent_1)
        
        for j in range(len(parent_1)):
            x = parent_1[j].index(-1)             #找出-1的位置
            place = np.random.randint(0, x)       #切割位置
            a.append(parent_1[:place])
        
        print(a)
        
    return a

# 突變
def mutation(p):
    for i in range(NUM_MUTATION):
        mut = np.random.randint(NUM_CROSSOVER_2)           #選一組基因出來
        [mut_mach_1, mut_mach_2] = np.random.choice(Num_of_Machine, 2, replace = False)           #選哪兩個機台要突變
        [mut_job_1, mut_job_2] = np.random.choice(Num_of_Job-1, 2, replace = False)             #選兩個job互換
        p[mut][mut_mach_1][mut_job_1], p[mut][mut_mach_2][mut_job_2] = \
            p[mut][mut_mach_2][mut_job_2], p[mut][mut_mach_1][mut_job_1]
        list_order(p[mut][mut_mach_1])
        list_order(p[mut][mut_mach_2])
        
# a的根據a_fit由大排到小
def sortChrome(a, a_fit):
    a_index = range(len(a))                         # 產生 0, 1, 2, ..., |a|-1 的 list
    a_fit, a_index = zip(*sorted(zip(a_fit,a_index), reverse=True)) # a_index 根據 a_fit 的大小由大到小連動的排序
    return [a[i] for i in a_index], a_fit           # 根據 a_index 的次序來回傳 a，並把對應的 fit 回傳

# a的根據a_fit由大排到小
def replace(p, p_fit, a, a_fit):            # 適者生存
    b = np.concatenate((p,a), axis=0)               # 把本代 p 和子代 a 合併成 b
    b_fit = p_fit + a_fit                           # 把上述兩代的 fitness 合併成 b_fit
    b, b_fit = sortChrome(b, b_fit)                 # b 和 b_fit 連動的排序
    return b[:NUM_CHROME], list(b_fit[:NUM_CHROME]) # 回傳 NUM_CHROME 個為新的一個世代

# ==========開始實作==========
# 載入標竿問題
FileName = os.listdir (r"D:\NCTU\fifth grade\python\Algorithm\final_project\Instence")    #將標竿問題檔案名稱存成一陣列
result = []
# 將FileName裡的資料都跑過一遍
for f in range(len(FileName)):
    #載入標竿問題
    instance = (FileName[f])
    #==============載入資料================
    with open("Instence/" + instance) as ins:
        data = ins.readlines()          #txt檔里全部數據        
        NUM = data[0].split()
        Num_of_Job = int(NUM[0])         #紀錄JOB數
        Num_of_Machine = int(NUM[1])     #紀錄machine數
        Proc_Time = np.zeros((Num_of_Job, Num_of_Machine))      #initialize 
        Setup_Time = np.zeros((Num_of_Machine, Num_of_Job, Num_of_Job))      #initialize 
        # processtime 資料
        for j in range(2,Num_of_Job + 2):                        
            data[j] = re.sub('\n', '',data[j])                  #process time資料
            item = []
            item = data[j].split('\t')
            for k in range(2, len(item), 2): 
                Proc_Time[j-2][((k-2)//2)] = item[k]
        # set_up_time
        i = 0                               #number of machine
        x = 0
        for j in range(4+Num_of_Job,len(data)):             #讀取完剩下的資料(set up time)
            if (x == Num_of_Job):
                x = 0
                i = i + 1
                continue
            
            data[j] = re.sub('\n', '', data[j])                  #process time資料
            item = []
            item = data[j].split('\t')
            for k in range(Num_of_Job):
                Setup_Time[i][j-(4+Num_of_Job)-Num_of_Job*i-i][k] = item[k]
            x = x + 1
    #===========資料載入完畢==========

    #========參數設定========
    Num_of_Machine                #機台個數
    Num_of_Job                    #JOB數
    Proc_Time                       
    Setup_Time                     
    iteration = 20                  #迴圈個數
    NUM_CHROME = 500                     #染色體個數
    Pc = 0.5    					# 交配率 (代表共執行Pc*NUM_CHROME/2次交配)
    Pm = 0.1   					# 突變率 (代表共要執行Pm*NUM_CHROME*Num_of_Job次突變)
    pressure = 0.5               # N-tourment 參數
    
    NUM_PARENT = NUM_CHROME                         # 父母的個數
    Num_pressure = int(pressure * NUM_CHROME)
    NUM_CROSSOVER = int(Pc * NUM_CHROME / 2)        # 交配的次數
    NUM_CROSSOVER_2 = NUM_CROSSOVER*2               # 上數的兩倍
    NUM_MUTATION = int(Pm * NUM_CHROME * Num_of_Job)   # 突變的次數
    #np.random.seed(0)
    
    #==========主程式==========
    start = time.process_time()             #演算法開始
    pop = init_pop()
    pop_fit = evaluatePop(pop)
    
    best_output = []
    best_output.append(np.max(pop_fit))
    
    mean_output = []
    mean_output.append(np.average(pop_fit))
    
    for i in range(iteration):
        offspring = local_search_enhanced(pop, pop_fit, Num_pressure)
        mutation(offspring)
        offspring_fit = evaluatePop(offspring)
        pop, pop_fit = replace(pop, pop_fit, offspring, offspring_fit)
        
        best_output.append(np.max(pop_fit))
        mean_output.append(np.average(pop_fit))
    print('iteration %d: x = %s, y = %d'	%(i, pop[0], -pop_fit[0]))     # fit 改負的
    stop = time.process_time()                                      #演算法結束
    
    # 將此標竿問題結果存起來 格式==>[標竿問題名稱, 機台數, 任務數, 解, 運算時間]
    the_result = [ instance, Num_of_Machine, Num_of_Job, -pop_fit[0], stop-start]
    result.append(the_result)

# ==========將結果輸出為csv檔案==========
with open('result.csv', 'w', newline='') as csvfile:
    # 建立 CSV 檔寫入器
    writer = csv.writer(csvfile)

    # 寫入資料
    writer.writerow(['標竿問題', '機台數', '任務數', '最佳解', '運算時間'])
    
    for i in range(len(result)):
        writer.writerow(result[i])