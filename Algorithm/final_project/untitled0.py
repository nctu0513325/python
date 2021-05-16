a = []

for i in range(NUM_CROSSOVER):
    #產生mask(決定哪個bit要用哪個parent的)
    mask = []
    for j in range(Num_of_Machine):
        for k in range(Num_JOB):
            mask.append(np.random.randint(2, size = Num_of_Job))
    print(mask)