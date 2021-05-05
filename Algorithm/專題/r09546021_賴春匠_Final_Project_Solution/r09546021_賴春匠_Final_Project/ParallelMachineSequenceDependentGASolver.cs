using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace r09546021_賴春匠_Final_Project
{
    class ParallelMachineSequenceDependentGASolver
    {
        Random randomizer = new Random();

        #region Data Field

        // Problem 參數
        int numberOfJobs;
        int numberOfMachines;
        float[,] processingTime;
        float[,] integratedProcessingTime;
        float[] minIntegratedProcessingTime;
        float[][,] setupTime;
        
        // GA 參數
        int populationSize = 80;
        int iterationLimit = 1000;
        float pressure = 10;
        float crossoverRate = 0.5f;
        float mutationRate = 0.5f;
        float localSearchRate = 1f;
        float initialMIHeuristicRate = 0.1f;
        bool localSearch = true;

        // GA
        float[] objectiveValues;
        float[] fitnessValues;
        int[][][] chromosomes;
        int[][] child1Chromosome;
        int[][] child2Chromosome;
        int[][] crossoverAddCandidate1; // 紀錄在做 crossover 時 parent2 資訊
        int[][] crossoverAddCandidate2; // 紀錄在做 crossover 時 parent2 資訊
        int[] crossoverRemoveJob1;
        int[] crossoverRemoveJob2;
        int[][] MIIndividualChromosome;
        int[] machinesLoad; // 紀錄每台機器上目前排的 Job 數
        int[][] temp_chromosome;
        int[][] MIiterationBestChromosome;
        int[] temp_machineLoad;
        int[] crossoverRandomPosition;
        int numberOfInitialMIHeuristic;
        float[] machinesMakespan;
        int[][] soFarTheBestSolution;
        float soFarTheBestObjective;
        float iterationBestObjective;
        float iterationAverageObjective;
        int[][] iterationBestChromosome;
        float[][] MIHeuristicIndividual; // 用另一個 heuristic 方法產生一個較好的個體進入起始種群
        int iteration;
        int parent1Index;
        int parent2Index;

        // 中間參數
        int[] chromosomeIndices;
        int[] jobIndices;
        int[] MIJobExamineOrder;
        int[] N_TournamentCandidateIndex;
        int[] N_TournamentSelectedParentIndices;
        bool isLocalOptimal;

        // Gantt Chart 資訊
        float[][][] jobStartEndTime; // jobStartEndTime[i][j][k] => 再 machine i 上第 j 個 job [0] 開工時間, [1] 完工時間  


        #endregion

        #region Property
        public int PopulationSize 
        {
            get => populationSize;
            set { if (value > 1) populationSize = value; }
        }
        public float Pressure 
        { 
            get => pressure;
            set { if (value > 0 && value <= 100) pressure = value; }
        }
        public float CrossoverRate
        {
            get => crossoverRate;
            set { if (value > 0 && value <= 1) crossoverRate = value; }
        }
        public float MutationRate 
        { 
            get => mutationRate; 
            set { if (value > 0 && value <= 1) mutationRate = value; }
        }
        public float LocalSearchRate 
        {
            get => localSearchRate; 
            set { if (value > 0 && value <= 1) localSearchRate = value; }
        }

        public float InitialMIHeuristicRate 
        {
            get => initialMIHeuristicRate;
            set { if (value >= 0 && value <= 1) initialMIHeuristicRate = value; } 
        }

        public int IterationLimit 
        {
            get => iterationLimit; 
            set { if (value > 0) iterationLimit = value; } 
        }

        public bool LocalSearch { get => localSearch; set => localSearch = value; }


        [Browsable(false)]
        public float SoFarTheBestObjective { get => soFarTheBestObjective; }
        [Browsable(false)]
        public int[][] SoFarTheBestSolution { get => soFarTheBestSolution; }
        [Browsable(false)]
        public int Iteration { get => iteration; set => iteration = value; }
        [Browsable(false)]
        public float IterationBestObjective { get => iterationBestObjective; }
        [Browsable(false)]
        public float IterationAverageObjective { get => iterationAverageObjective; }


        #endregion

        #region Constructor

        public ParallelMachineSequenceDependentGASolver(ReadInInstance theProblem)
        {
            Random randomizer = new Random();

            // Problem 參數
            numberOfJobs = theProblem.NumberOfJobs;
            numberOfMachines = theProblem.NumberOfMachines;
            processingTime = theProblem.ProcessingTime;
            setupTime = theProblem.SetupTime;
            jobIndices = new int[numberOfJobs];
            for (int i = 0; i < numberOfJobs; i++)
                jobIndices[i] = i;
            MIJobExamineOrder = new int[numberOfJobs];
            for (int i = 0; i < numberOfJobs; i++)
                MIJobExamineOrder[i] = i;
            N_TournamentSelectedParentIndices = new int[2];
            crossoverRandomPosition = new int[numberOfMachines];
            machinesMakespan = new float[numberOfMachines];
            integratedProcessingTime = new float[numberOfJobs, numberOfMachines];
            minIntegratedProcessingTime = new float[numberOfJobs];
            crossoverRemoveJob1 = new int[numberOfJobs];
            crossoverRemoveJob2 = new int[numberOfJobs];
            crossoverAddCandidate1 = new int[numberOfMachines][];
            crossoverAddCandidate2 = new int[numberOfMachines][];
            for(int i = 0; i < numberOfMachines; i++)
            {
                crossoverAddCandidate1[i] = new int[numberOfJobs];
                crossoverAddCandidate2[i] = new int[numberOfJobs];
            }
            machinesLoad = new int[numberOfMachines];
            for (int i = 0; i < numberOfMachines; i++)
                machinesLoad[i] = 0;
            jobStartEndTime = new float[numberOfMachines][][];
            for(int i = 0; i < numberOfMachines; i++)
            {
                jobStartEndTime[i] = new float[numberOfJobs][];
                for (int j = 0; j < numberOfJobs; j++)
                    jobStartEndTime[i][j] = new float[2];
            }

        }

        #endregion

        #region Function

        public void Reset()
        {
            // 初始化 GA 參數
            objectiveValues = new float[populationSize];
            fitnessValues = new float[populationSize];
            chromosomes = new int[populationSize][][];
            temp_machineLoad = new int[numberOfMachines];
            iteration = 0;
            for (int i = 0; i < populationSize; i++)
            {
                chromosomes[i] = new int[numberOfMachines][];
                for (int j = 0; j < numberOfMachines; j++)
                    chromosomes[i][j] = new int[numberOfJobs];
            }
            child1Chromosome = new int[numberOfMachines][];
            child2Chromosome = new int[numberOfMachines][];
            for (int i = 0; i < numberOfMachines; i++)
            {
                child1Chromosome[i] = new int[numberOfJobs];
                child2Chromosome[i] = new int[numberOfJobs];
            }
            soFarTheBestObjective = float.MaxValue;
            iterationBestChromosome = new int[numberOfMachines][];
            for (int i = 0; i < numberOfMachines; i++)
                iterationBestChromosome[i] = new int[numberOfJobs];
            temp_chromosome = new int[numberOfMachines][];
            for (int i = 0; i < numberOfMachines; i++)
                temp_chromosome[i] = new int[numberOfJobs];
            MIIndividualChromosome = new int[numberOfMachines][];
            for (int i = 0; i < numberOfMachines; i++)
                MIIndividualChromosome[i] = new int[numberOfJobs];
            MIiterationBestChromosome = new int[numberOfMachines][];
            for (int i = 0; i < numberOfMachines; i++)
                MIiterationBestChromosome[i] = new int[numberOfJobs];
            // 先用 -1 將 chromosomes, child1, child2 chromosome 填滿
            for (int i = 0; i < populationSize; i++)
                for (int j = 0; j < numberOfMachines; j++)
                    for (int k = 0; k < numberOfJobs; k++)
                        chromosomes[i][j][k] = -1;
            for(int i = 0; i < numberOfMachines; i++)
                for(int j = 0; j < numberOfJobs; j++)
                {
                    child1Chromosome[i][j] = -1;
                    child2Chromosome[i][j] = -1;
                }
            soFarTheBestSolution = new int[numberOfMachines][];
            for (int i = 0; i < numberOfMachines; i++)
                soFarTheBestSolution[i] = new int[numberOfJobs];
            chromosomeIndices = new int[populationSize];
            for (int i = 0; i < populationSize; i++)
                chromosomeIndices[i] = i;

            #region 待做 (MI 產生起始個體)
            
            #endregion

            // 隨機產生 populationSize個個體進入起始種群 (因為盡可能讓每台機器都在運作為得到較好的解的合理情況, 故作法為將所有 Job 打亂依序放入 Machine 中)
            for (int i = 0; i < populationSize; i++)
            {
                int jobPutInCount = 0;
                ShuffleAnIntegerArray(jobIndices, numberOfJobs);
                for (int j = 0; j < numberOfJobs; j++)
                    for (int k = 0; k < numberOfMachines; k++)
                    {
                        if (jobPutInCount < numberOfJobs)
                        {
                            chromosomes[i][k][j] = jobIndices[jobPutInCount];
                            jobPutInCount++;
                        }
                        else break;
                    }
            }

            // 對 initialMIHeyristicRate 比例的起始個體做 MI Heuristic 以確保起始種群足夠好
            
            MIJobExamineOrder = GetMIExamineOrder();
            numberOfInitialMIHeuristic = (int)(populationSize * initialMIHeuristicRate);
            int[] initialMIHeuristicChromosomeIndices = new int[numberOfInitialMIHeuristic];
            for (int i = 0; i < numberOfInitialMIHeuristic; i++)
            {
                initialMIHeuristicChromosomeIndices[i] = randomizer.Next(populationSize);
                for(int j = 0; j < i; j++)
                    while(initialMIHeuristicChromosomeIndices[j] == initialMIHeuristicChromosomeIndices[i])
                    {
                        j = 0;
                        initialMIHeuristicChromosomeIndices[i] = randomizer.Next(populationSize);
                    }
            }

            for(int i = 0; i < numberOfInitialMIHeuristic; i++)
            {
                MIIndividualChromosome = GetMIPerformedChromosome(chromosomes[initialMIHeuristicChromosomeIndices[i]]);
                for (int j = 0; j < numberOfMachines; j++)
                    for (int k = 0; k < numberOfJobs; k++)
                        chromosomes[initialMIHeuristicChromosomeIndices[i]][j][k] = MIIndividualChromosome[j][k];
            }

            // 計算目前起始種群每個個體的 Makespan
            for(int i = 0; i < populationSize; i++)
                objectiveValues[i] = GetChromosomeMakespan(chromosomes[i]);
        }

        public void RunOneIteration()
        {
            double randomCrossoverRate = randomizer.NextDouble();
            double randomMutationRate;
            double randomLocalSearchRate;
            int originalBestIndex = getOriginalBestChromosomeIndex();
            iterationBestObjective = float.MaxValue;
            iterationAverageObjective = 0.0f;
            isLocalOptimal = false;

            performN_TournamentSelection();     // 選擇要進行交配的個體
            if (randomCrossoverRate <= crossoverRate)
            {
                performCrossover();     // 進行交配
                for(int i = 0; i < 2; i++)
                {
                    randomMutationRate = randomizer.NextDouble();       // 有 mutationRate 的機率進行突變
                    if (i == 0 && randomMutationRate < mutationRate) performMutation(child1Chromosome);
                    if (i == 1 && randomMutationRate < mutationRate) performMutation(child2Chromosome);
                }

                if (localSearch)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        randomLocalSearchRate = randomizer.NextDouble();    // 有 localSearchRate 的機率對子代做 local search
                        if (i == 0 && randomLocalSearchRate < localSearchRate)
                        {
                            temp_machineLoad = GetMachineLoad(child1Chromosome);
                            while (isLocalOptimal == false)
                                performLocalSearch(child1Chromosome);
                            isLocalOptimal = false;
                        }
                        if (i == 1 && randomLocalSearchRate < localSearchRate)
                        {
                            temp_machineLoad = GetMachineLoad(child2Chromosome);
                            while (isLocalOptimal == false)
                                performLocalSearch(child2Chromosome);
                            isLocalOptimal = false;
                        }
                    }
                }
            }

            if (localSearch)
            {
                randomLocalSearchRate = randomizer.NextDouble();
                if (randomLocalSearchRate < localSearchRate) // 有 localSearchRate 的機率對原始種群中最好的個體做 local search
                {
                    temp_machineLoad = GetMachineLoad(chromosomes[originalBestIndex]);
                    while (isLocalOptimal == false)
                        performLocalSearch(chromosomes[originalBestIndex]);   // 對這個 iteration 中除了 offspring 以外最好的個體做 local search
                    isLocalOptimal = false;
                }
                objectiveValues[originalBestIndex] = GetChromosomeMakespan(chromosomes[originalBestIndex]);   // 更新原種群做 local search 的個體的 objective value
            }

            if (randomCrossoverRate <= crossoverRate)    // 沒有 crossover 話就不用作替換
                performNextGenerationSelection();       // 若 offspring 比最差的親代好且 unique 則替換掉該親代
            updateSoFarTheBestSolutionAndObjective();       // 更新 so far the best
            iteration++; 
        }

        #endregion

        #region Class Methods

        // 打亂一個整數陣列
        void ShuffleAnIntegerArray(int[] a, int len)        // 簡易洗牌演算程序
        {
            if (a.Length < len) throw new Exception("Length Error");
            for (int i = 0; i < len; i++) a[i] = i;
            for (int c = len - 1; c > 1; c--)
            {
                int pos = randomizer.Next(c + 1);
                int temp = a[c];
                a[c] = a[pos];
                a[pos] = temp;
            }
        }

        // 用 processingTime, setupTime 找出整合了 setupTime 的 ProcessingTime 並回傳由大到小的 jobIndices 排序
        private int[] GetMIExamineOrder()
        {
            float temp_min;
            for(int i = 0; i < numberOfJobs; i++)
                for(int j = 0; j < numberOfMachines; j++)
                {
                    temp_min = float.MaxValue;
                    for(int k = 0; k < numberOfJobs; k++)
                    {
                        if ( (i != k) && (processingTime[i, j] + setupTime[j][i, k] < temp_min) ) 
                            temp_min = processingTime[i, j] + setupTime[j][i, k];
                    }
                    integratedProcessingTime[i, j] = temp_min;
                }
            for(int i = 0; i < numberOfJobs; i++)
            {
                temp_min = float.MaxValue;
                for (int j = 0; j < numberOfMachines; j++)
                    if (integratedProcessingTime[i, j] < temp_min) temp_min = integratedProcessingTime[i, j];
                minIntegratedProcessingTime[i] = temp_min;
            }
            Array.Sort(minIntegratedProcessingTime, MIJobExamineOrder, 0, numberOfJobs);
            Array.Reverse(MIJobExamineOrder, 0, numberOfJobs);
            return MIJobExamineOrder;
        }

        // 傳入一個 chromosome, 回傳經 MI 調整後的 chromosome
        private int[][] GetMIPerformedChromosome(int[][] theChromosome)
        {
            float temp_maxMakespan;
            for (int i = 0; i < numberOfMachines; i++)
                MIiterationBestChromosome[i] = new int[numberOfJobs];

            for (int i = 0; i < numberOfJobs; i++)
            {
                int t = 0;
                int machine_position = -1; // 要處理的 job 在哪台機器上
                int job_position = -1; // 要處理的 job 在該 machine 的第幾個位置上
                int processedJobIndex = MIJobExamineOrder[i];
                temp_maxMakespan = float.MaxValue;


                // 計算要處理 job 的位置
                for (int j = 0; j < numberOfMachines; j++)
                {
                    for (int k = 0; k < numberOfJobs; k++)
                        if (theChromosome[j][k] == processedJobIndex)
                        {
                            machine_position = j;
                            job_position = k;
                            t = -1;
                            break;
                        }
                    if (t == -1) break;
                }

                // 先移除要處理的 job
                for (int j = job_position; j < numberOfJobs; j++)
                {
                    if (j != numberOfJobs - 1) theChromosome[machine_position][j] = theChromosome[machine_position][j + 1];
                    else theChromosome[machine_position][j] = -1;
                }

                // 把處理的 job 放到 machine j 位置 k
                for(int j = 0; j < numberOfMachines; j++)
                {
                    int temp_load_1 = GetMachineLoad(theChromosome)[j];
                    for(int k = 0; k < temp_load_1 + 1; k++)
                    {
                        // 複製一份用於計算
                        for (int l = 0; l < numberOfMachines; l++)
                            for (int m = 0; m < numberOfJobs; m++)
                                temp_chromosome[l][m] = theChromosome[l][m];

                        // 計算該放法的 chromosome
                        for(int l = temp_load_1; l > k; l--)
                            temp_chromosome[j][l] = temp_chromosome[j][l - 1];
                        temp_chromosome[j][k] = processedJobIndex;

                        // 紀錄每種可能插入位置中最好的一個
                        if(GetChromosomeMakespan(temp_chromosome) < temp_maxMakespan)
                        {
                            temp_maxMakespan = GetChromosomeMakespan(temp_chromosome);
                            for (int l = 0; l < numberOfMachines; l++)
                                for (int m = 0; m < numberOfJobs; m++)
                                    MIiterationBestChromosome[l][m] = temp_chromosome[l][m];
                        }
                    }
                }

                // 將該 job 插入最好的位置
                for (int j = 0; j < numberOfMachines; j++)
                    for (int k = 0; k < numberOfJobs; k++)
                        theChromosome[j][k] = MIiterationBestChromosome[j][k];
            }

            return theChromosome;
        }

        // 傳入一條 chromosome, 回傳他的 Machine Load 陣列
        private int[] GetMachineLoad(int[][] theChromosome)
        {
            int j;
            int load_sum;

            for (int i = 0; i < numberOfMachines; i++)
            {
                j = 0;
                load_sum = 0;
                while (theChromosome[i][j] != -1)
                {
                    load_sum += 1;
                    j++;
                    if (j == numberOfJobs) break;
                }
                temp_machineLoad[i] = load_sum;
            }
            return temp_machineLoad;
        }

        // 傳入一條 chromosome, 回傳她的整體 makespan (速度較 IMI 慢)
        private float GetChromosomeMakespan(int[][] theChromosome)
        {
            float makespan = float.MinValue;
            float[] sum = new float[numberOfMachines];
            for (int i = 0; i < numberOfMachines; i++)
                sum[i] = 0;
            
            // 計算 ProcessingTime
            for(int i = 0; i < numberOfMachines; i++)
            {
                int key = 0;
                while(theChromosome[i][key] != -1)
                {
                    sum[i] += processingTime[theChromosome[i][key], i];
                    key++;
                    if (key == numberOfJobs) break;
                }
            }
            // 計算SetupTime
            for (int i = 0; i < numberOfMachines; i++)
            {
                int key = 1;
                while(theChromosome[i][key] != -1)
                {
                    sum[i] += setupTime[i][theChromosome[i][key - 1], theChromosome[i][key]];
                    key++;
                    if (key == numberOfJobs) break;
                }
            }
            // 計算整體 makespan
            for (int i = 0; i < numberOfMachines; i++)
                if (sum[i] > makespan) makespan = sum[i];

            return makespan;
        }

        // 傳入一個機器處理的 job 陣列, 回傳該機器的 completion time
        private float GetMachineCompletionTime(int[] MachineArray, int MachineLoad, int MachineIndex)
        {
            float sum = 0.0f;
            for(int i = 0; i < MachineLoad; i++)
                sum += processingTime[MachineArray[i], MachineIndex];
            for (int i = 1; i < MachineLoad; i++)
                sum += setupTime[MachineIndex][MachineArray[i - 1], MachineArray[i]];
            return sum;
        }

        // 判斷 Local Search 的一次插入是否有改善解
        private bool isInsert(int[] jobLeaveMachine, int[] jobEnterMachine, int Machine1Index, int Machine2Index,
            int leavePosition, int insertPosition, int Machine1Load, int Machine2Load, float makespan)
        {
            float jobLeaveMachineTimeChange = 0.0f;
            float jobEnterMachineTimeChange = 0.0f;
            float machine1CompletionTime;
            float machine2CompletionTime;
            float c1_new;
            float c2_new;
            int insertElement = jobLeaveMachine[leavePosition];     // 要離開的是哪個 job

            // 計算 job 離開機器時間變化
            if(leavePosition == 0)
            {
                if(Machine1Load != 1)
                    jobLeaveMachineTimeChange -= setupTime[Machine1Index][insertElement, jobLeaveMachine[leavePosition + 1]];
            }
            else if(leavePosition == Machine1Load - 1)
            {
                jobLeaveMachineTimeChange -= setupTime[Machine1Index][jobLeaveMachine[leavePosition - 1], insertElement];
            }
            else
            {
                jobLeaveMachineTimeChange -= (setupTime[Machine1Index][jobLeaveMachine[leavePosition - 1], insertElement] + setupTime[Machine1Index][insertElement, jobLeaveMachine[leavePosition + 1]]);
                jobLeaveMachineTimeChange += setupTime[Machine1Index][jobLeaveMachine[leavePosition - 1], jobLeaveMachine[leavePosition + 1]];
            }
            
            // 計算 job 進入機器時間變化
            if(insertPosition == 0)
            {
                if (Machine2Load != 0)
                    jobEnterMachineTimeChange += setupTime[Machine2Index][insertElement, jobEnterMachine[insertPosition]];
            }
            else if(insertPosition == Machine2Load)
            {
                jobEnterMachineTimeChange += setupTime[Machine2Index][jobEnterMachine[insertPosition - 1], insertElement];
            }
            else
            {
                jobEnterMachineTimeChange += (setupTime[Machine2Index][jobEnterMachine[insertPosition - 1], insertElement] + setupTime[Machine2Index][insertElement, jobEnterMachine[insertPosition]]);
                jobEnterMachineTimeChange -= setupTime[Machine2Index][jobEnterMachine[insertPosition - 1], jobEnterMachine[insertPosition]];
            }

            // 計算有動到的兩台 machine 的 completion time
            c1_new = GetMachineCompletionTime(jobLeaveMachine, Machine1Load, Machine1Index) + jobLeaveMachineTimeChange - processingTime[insertElement, Machine1Index];
            c2_new = GetMachineCompletionTime(jobEnterMachine, Machine2Load, Machine2Index) + jobEnterMachineTimeChange + processingTime[insertElement, Machine2Index];

            if ((jobLeaveMachineTimeChange - processingTime[insertElement, Machine1Index] < 0) && (jobEnterMachineTimeChange + processingTime[insertElement, Machine2Index] < 0))
            {
                return true;
            }
            else if((jobLeaveMachineTimeChange - processingTime[insertElement, Machine1Index] >= 0) && (jobEnterMachineTimeChange + processingTime[insertElement, Machine2Index] >= 0))
            {
                return false;
            }
            else
            {
                if(jobLeaveMachineTimeChange - processingTime[insertElement, Machine1Index] + jobEnterMachineTimeChange + processingTime[insertElement, Machine2Index] < 0)
                {
                    if(c1_new < makespan && c2_new < makespan)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        // 判斷傳入的 chromosome 在原本的種群中有沒有一謎一樣的個體
        private bool isUnique(int[][] theChromosome)
        {
            bool isDifferent;

            for(int i = 0; i < populationSize; i++)
            {
                isDifferent = false;
                for (int j = 0; j < numberOfMachines; j++)
                {
                    for (int k = 0; k < numberOfJobs; k++)
                    {
                        if (theChromosome[j][k] != chromosomes[i][j][k])
                        {
                            isDifferent = true;
                            break;
                        }
                    }
                    if (isDifferent == true)
                        break;
                }
                if (isDifferent == false)
                    return false;
            }
            return true;
        }

        #endregion

        #region GA Method

        private void performN_TournamentSelection()
        {
            for (int i = 0; i < 2; i++)
                N_TournamentSelectedParentIndices[i] = -1;
            int numberOfCandidate = Convert.ToInt32(populationSize * (pressure / 100));
            float bestObjectiveAmoungCandidate;
            N_TournamentCandidateIndex = new int[numberOfCandidate];
            for(int i = 0; i < 2; i++)
            {
                bestObjectiveAmoungCandidate = float.MaxValue;
                // 從種群中隨機選出 numberOfCandidate 個個體，將其 index 存入 N_TournamentCandidateIndex 中
                for (int j = 0; j < numberOfCandidate; j++)
                {
                    N_TournamentCandidateIndex[j] = randomizer.Next(populationSize);
                    while (N_TournamentCandidateIndex[j] == N_TournamentSelectedParentIndices[0])
                        N_TournamentCandidateIndex[j] = randomizer.Next(populationSize);
                    for (int k = 0; k < j; k++)
                        while (N_TournamentCandidateIndex[j] == N_TournamentCandidateIndex[k])
                        {
                            k = 0;
                            N_TournamentCandidateIndex[j] = randomizer.Next(populationSize);
                        }
                }
                // 從這些選中的個體中找到一個最好的
                for(int j = 0; j < numberOfCandidate; j++)
                {
                    if(objectiveValues[N_TournamentCandidateIndex[j]] < bestObjectiveAmoungCandidate)
                    {
                        bestObjectiveAmoungCandidate = objectiveValues[N_TournamentCandidateIndex[j]];
                        N_TournamentSelectedParentIndices[i] = N_TournamentCandidateIndex[j];
                    }
                }
            }
            parent1Index = N_TournamentSelectedParentIndices[0];
            parent2Index = N_TournamentSelectedParentIndices[1];
        }

        private void performCrossover()
        {
            for (int i = 0; i < numberOfMachines; i++)
                for (int j = 0; j < numberOfJobs; j++)
                {
                    child1Chromosome[i][j] = -1;
                    child2Chromosome[i][j] = -1;
                }
            int removeIndex1 = 0;
            int removeIndex2 = 0;
            for (int i = 0; i< numberOfJobs; i++)
            {
                crossoverRemoveJob1[i] = -1;    // 在 child1 中 parent1 已經放入的 job，在 parent2 放時準備刪除
                crossoverRemoveJob2[i] = -1;
            }
            for(int i = 0; i < numberOfMachines; i++)
                for(int j = 0; j < numberOfJobs; j++)
                {
                    crossoverAddCandidate1[i][j] = -1;
                    crossoverAddCandidate2[i][j] = -1;
                }

            temp_machineLoad = GetMachineLoad(chromosomes[parent1Index]);
            for(int i = 0; i < numberOfMachines; i++)
                crossoverRandomPosition[i] = randomizer.Next(temp_machineLoad[i] + 1);  // 每台 machine 上隨機選一個位置，包含頭尾

            // 把 parent1 資訊寫入 children
            for(int i = 0; i < numberOfMachines; i++)
            {
                for(int j = 0; j < crossoverRandomPosition[i]; j++)
                {
                    child1Chromosome[i][j] = chromosomes[parent1Index][i][j];
                    crossoverRemoveJob1[removeIndex1] = chromosomes[parent1Index][i][j];
                    removeIndex1++;
                }
                for (int j = crossoverRandomPosition[i]; j < temp_machineLoad[i]; j++)
                {
                    child2Chromosome[i][j - crossoverRandomPosition[i]] = chromosomes[parent1Index][i][j];
                    crossoverRemoveJob2[removeIndex2] = chromosomes[parent1Index][i][j];
                    removeIndex2++;
                }
            }

            // 取得 child1 中 parent2 中個機台還沒放的 Job
            for(int i = 0; i < numberOfMachines; i++)
            {
                int machineJobCount = 0;
                for (int j = 0; j < numberOfJobs; j++)
                {
                    if (chromosomes[parent2Index][i][j] == -1) break;
                    int removeKey = 0;
                    bool inParent2 = false;
                    while(crossoverRemoveJob1[removeKey] != -1)
                    {
                        if (chromosomes[parent2Index][i][j] == crossoverRemoveJob1[removeKey])
                        {
                            inParent2 = true;
                            break;
                        }
                        removeKey++;
                    }
                    if (inParent2 == false)
                    {
                        crossoverAddCandidate1[i][machineJobCount] = chromosomes[parent2Index][i][j];
                        machineJobCount++;
                    }
                }
            }

            // 取得 child2 中 parent2 中個機台還沒放的 Job
            for (int i = 0; i < numberOfMachines; i++)
            {
                int machineJobCount = 0;
                for (int j = 0; j < numberOfJobs; j++)
                {
                    if (chromosomes[parent2Index][i][j] == -1) break;
                    int removeKey = 0;
                    bool inParent2 = false;
                    while (crossoverRemoveJob2[removeKey] != -1)
                    {
                        if (chromosomes[parent2Index][i][j] == crossoverRemoveJob2[removeKey])
                        {
                            inParent2 = true;
                            break;
                        }
                        removeKey++;
                    }
                    if (inParent2 == false)
                    {
                        crossoverAddCandidate2[i][machineJobCount] = chromosomes[parent2Index][i][j];
                        machineJobCount++;
                    }
                }
            }

            // 把 parent2 資訊寫入 child1 中
            temp_machineLoad = GetMachineLoad(child1Chromosome);
            for (int i = 0; i < numberOfMachines; i++)
            {
                int addKey = 0;
                int positionChoice = -1;
                while(crossoverAddCandidate1[i][addKey] != -1)
                {
                    float machineMinSetupTime = float.MaxValue;
                    
                    // 對要加入的 job 找到在給定的 machine 上最好的插入位置
                    for (int j = 0; j < temp_machineLoad[i] + 1; j++)
                    {
                        if(j == 0)
                        {
                            if(temp_machineLoad[i] == 0)
                            {
                                positionChoice = j;
                            }
                            else if(setupTime[i][crossoverAddCandidate1[i][addKey], child1Chromosome[i][0]] < machineMinSetupTime)
                            {
                                machineMinSetupTime = setupTime[i][crossoverAddCandidate1[i][addKey], child1Chromosome[i][0]];
                                positionChoice = j;
                            }
                            
                        }
                        else if(j == temp_machineLoad[i])
                        {
                            if (setupTime[i][child1Chromosome[i][temp_machineLoad[i] - 1], crossoverAddCandidate1[i][addKey]] < machineMinSetupTime)
                            {
                                machineMinSetupTime = setupTime[i][child1Chromosome[i][temp_machineLoad[i] - 1], crossoverAddCandidate1[i][addKey]];
                                positionChoice = j;
                            }
                        }
                        else
                        {
                            if ((setupTime[i][child1Chromosome[i][j - 1], crossoverAddCandidate1[i][addKey]]) + (setupTime[i][crossoverAddCandidate1[i][addKey], child1Chromosome[i][j]]) - (setupTime[i][child1Chromosome[i][j - 1], child1Chromosome[i][j]]) < machineMinSetupTime)
                            {
                                machineMinSetupTime = (setupTime[i][child1Chromosome[i][j - 1], crossoverAddCandidate1[i][addKey]]) + (setupTime[i][crossoverAddCandidate1[i][addKey], child1Chromosome[i][j]]) - (setupTime[i][child1Chromosome[i][j - 1], child1Chromosome[i][j]]);
                                positionChoice = j;
                            }
                        }
                    }

                    // 把要插入位置之後的 job 全部往後移，空出位置給選定的 job 插入
                    for(int j = temp_machineLoad[i]; j > positionChoice; j--)
                        child1Chromosome[i][j] = child1Chromosome[i][j - 1];

                    // 將該 job 插入最好的位置
                    child1Chromosome[i][positionChoice] = crossoverAddCandidate1[i][addKey];
                    temp_machineLoad[i]++;
                    addKey++;
                }
            }

            // 把 parent2 資訊寫入 child2 中
            temp_machineLoad = GetMachineLoad(child2Chromosome);
            for (int i = 0; i < numberOfMachines; i++)
            {
                int addKey = 0;
                int positionChoice = -1;
                while (crossoverAddCandidate2[i][addKey] != -1)
                {
                    float machineMinSetupTime = float.MaxValue;

                    // 對要加入的 job 找到在給定的 machine 上最好的插入位置
                    for (int j = 0; j < temp_machineLoad[i] + 1; j++)
                    {
                        if (j == 0)
                        {
                            if(temp_machineLoad[i] == 0)
                            {
                                positionChoice = j;
                            }
                            else if(setupTime[i][crossoverAddCandidate2[i][addKey], child2Chromosome[i][0]] < machineMinSetupTime)
                            {
                                machineMinSetupTime = setupTime[i][crossoverAddCandidate2[i][addKey], child2Chromosome[i][0]];
                                positionChoice = j;
                            }
                        }
                        else if (j == temp_machineLoad[i])
                        {
                            if (setupTime[i][child2Chromosome[i][temp_machineLoad[i] - 1], crossoverAddCandidate2[i][addKey]] < machineMinSetupTime)
                            {
                                machineMinSetupTime = setupTime[i][child2Chromosome[i][temp_machineLoad[i] - 1], crossoverAddCandidate2[i][addKey]];
                                positionChoice = j;
                            }
                        }
                        else
                        {
                            if ((setupTime[i][child2Chromosome[i][j - 1], crossoverAddCandidate2[i][addKey]]) + (setupTime[i][crossoverAddCandidate2[i][addKey], child2Chromosome[i][j]]) - (setupTime[i][child2Chromosome[i][j - 1], child2Chromosome[i][j]]) < machineMinSetupTime)
                            {
                                machineMinSetupTime = (setupTime[i][child2Chromosome[i][j - 1], crossoverAddCandidate2[i][addKey]]) + (setupTime[i][crossoverAddCandidate2[i][addKey], child2Chromosome[i][j]]) - (setupTime[i][child2Chromosome[i][j - 1], child2Chromosome[i][j]]);
                                positionChoice = j;
                            }
                        }
                    }

                    // 把要插入位置之後的 job 全部往後移，空出位置給選定的 job 插入
                    for (int j = temp_machineLoad[i]; j > positionChoice; j--)
                        child2Chromosome[i][j] = child2Chromosome[i][j - 1];

                    // 將該 job 插入最好的位置
                    child2Chromosome[i][positionChoice] = crossoverAddCandidate2[i][addKey];
                    temp_machineLoad[i]++;
                    addKey++;
                }
            }

        }

        private void performMutation(int[][] theChromosome)
        {
            temp_machineLoad = GetMachineLoad(theChromosome);
            int randomMachine = randomizer.Next(numberOfMachines);
            int randomPosition = randomizer.Next(temp_machineLoad[randomMachine]);
            int randomInsertPosition = randomizer.Next(temp_machineLoad[randomMachine]);
            int randomInsertJob = theChromosome[randomMachine][randomPosition];
            while (randomInsertPosition == randomPosition)
            {
                if (randomInsertPosition == 0) break;
                randomInsertPosition = randomizer.Next(temp_machineLoad[randomMachine]);
            }

            // 把選到的 job 先拿掉， 其他全部往前移
            for (int i = randomPosition; i < temp_machineLoad[randomMachine]; i++)
            {
                if(temp_machineLoad[randomMachine] != numberOfJobs)
                    theChromosome[randomMachine][i] = theChromosome[randomMachine][i + 1];
                else
                {
                    if (i != numberOfJobs - 1)
                        theChromosome[randomMachine][i] = theChromosome[randomMachine][i + 1];
                    else
                        theChromosome[randomMachine][i] = -1;
                }

            }

            // 把選到要插入的位置之後的 job 全部往後移，空出一個位置
            for (int i = temp_machineLoad[randomMachine] - 1; i > randomInsertPosition; i--)
                theChromosome[randomMachine][i] = theChromosome[randomMachine][i - 1];

            // 把工作插入
            theChromosome[randomMachine][randomInsertPosition] = randomInsertJob;
        }

        private void performLocalSearch(int[][] theChromosome)
        {
            float theChromosomeMakespan = GetChromosomeMakespan(theChromosome);
            for(int i = 0; i < numberOfMachines; i++)
            {
                int jobKey = 0;
                while (theChromosome[i][jobKey] != -1)
                {
                    for(int j = 0; j < numberOfMachines; j++)
                    {
                        if(j != i)
                        {
                            for (int k = 0; k < temp_machineLoad[j] + 1; k++)
                            {
                                if (isInsert(theChromosome[i], theChromosome[j], i, j,
                                    jobKey, k, temp_machineLoad[i], temp_machineLoad[j], theChromosomeMakespan))
                                {
                                    int insertElement = theChromosome[i][jobKey];
                                    // 真的調整此 chromosome 資訊
                                    for (int l = jobKey; l < temp_machineLoad[i]; l++)
                                    {
                                        if (temp_machineLoad[i] != numberOfJobs)
                                            theChromosome[i][l] = theChromosome[i][l + 1];
                                        else
                                        {
                                            if (l != numberOfJobs - 1)
                                                theChromosome[i][l] = theChromosome[i][l + 1];
                                            else
                                                theChromosome[i][l] = -1;
                                        }
                                    }
                                        
                                    
                                        
                                    for (int l = temp_machineLoad[j]; l > k; l--)
                                        theChromosome[j][l] = theChromosome[j][l - 1];
                                    theChromosome[j][k] = insertElement;
                                    // 調整 temp_machineLoad 資訊
                                    temp_machineLoad[i]--;
                                    temp_machineLoad[j]++;
                                    // 從頭開始再做一次
                                    return;
                                }
                            }
                        }
                    }
                    jobKey++;
                }
            }
            isLocalOptimal = true;
            return;
        }

        private void performNextGenerationSelection()
        {
            float maxValue = float.MinValue;
            int worstIndex = -1;
            float child1objective = GetChromosomeMakespan(child1Chromosome);
            float child2objective = GetChromosomeMakespan(child2Chromosome);
            
            // 判斷子代獨特性 (選)



            // 找出最差的個體
            for(int i = 0; i < populationSize; i++)
                if(objectiveValues[i] > maxValue)
                {
                    maxValue = objectiveValues[i];
                    worstIndex = i;
                }

            // 若子代 1 比他好就將其替換掉
            if(child1objective < maxValue)
            {
                // 若 child1 為 unique 才替換掉
                if (isUnique(child1Chromosome))
                {
                    for (int i = 0; i < numberOfMachines; i++)
                        for (int j = 0; j < numberOfJobs; j++)
                            chromosomes[worstIndex][i][j] = child1Chromosome[i][j];
                    objectiveValues[worstIndex] = child1objective;
                }
            }

            maxValue = float.MinValue;
            worstIndex = -1;

            // 重新找最差的個體
            for (int i = 0; i < populationSize; i++)
                if (objectiveValues[i] > maxValue)
                {
                    maxValue = objectiveValues[i];
                    worstIndex = i;
                }

            // 若子代 2 比他好就將其替換掉
            if (child2objective < maxValue)
            {
                // 若 child2 為 unique　才替換掉
                if (isUnique(child2Chromosome))
                {
                    for (int i = 0; i < numberOfMachines; i++)
                        for (int j = 0; j < numberOfJobs; j++)
                            chromosomes[worstIndex][i][j] = child2Chromosome[i][j];
                    objectiveValues[worstIndex] = child2objective;
                }
            }
        }



        private void updateSoFarTheBestSolutionAndObjective()
        {
            int iterationBestIndex = -1;
            for(int i = 0; i < populationSize; i++)
            {
                iterationAverageObjective += objectiveValues[i];
                if(objectiveValues[i] < iterationBestObjective)
                {
                    iterationBestObjective = objectiveValues[i];
                    iterationBestIndex = i;
                }
            }
            iterationAverageObjective /= populationSize;
            if(iterationBestObjective < soFarTheBestObjective)
            {
                soFarTheBestObjective = iterationBestObjective;
                for (int i = 0; i < numberOfMachines; i++)
                    for (int j = 0; j < numberOfJobs; j++)
                        soFarTheBestSolution[i][j] = chromosomes[iterationBestIndex][i][j];
            }

        }

        private int getOriginalBestChromosomeIndex()
        {
            float minValue = float.MaxValue;
            int bestIndex = -1;
            for(int i = 0; i < populationSize; i++)
            {
                if(objectiveValues[i] < minValue)
                {
                    minValue = objectiveValues[i];
                    bestIndex = i;
                }
            }
            return bestIndex;
        }

        #endregion

        #region Graw Gantt Chart

        public void DrawGantt(Graphics g, Rectangle bound)
        {
            temp_machineLoad = GetMachineLoad(soFarTheBestSolution);
            // 計算開始與完工時間

            for (int i = 0; i < numberOfMachines; i++)
            {
                float machineTotalTime = 0;
                jobStartEndTime[i][0][0] = machineTotalTime;
                if(soFarTheBestSolution[i][0] != -1)    // 避免整台機器空的情況
                    machineTotalTime += processingTime[soFarTheBestSolution[i][0], i];
                jobStartEndTime[i][0][1] = machineTotalTime;
                
                int key = 1;
                
                while(soFarTheBestSolution[i][key] != -1)
                {
                    machineTotalTime += setupTime[i][soFarTheBestSolution[i][key - 1], soFarTheBestSolution[i][key]];
                    jobStartEndTime[i][key][0] = machineTotalTime;
                    machineTotalTime += processingTime[soFarTheBestSolution[i][key], i];
                    jobStartEndTime[i][key][1] = machineTotalTime;
                    key++;
                }
            }

            // 計算單位長度
            float unitWidth = (bound.Width - 100) / (soFarTheBestObjective * 1.01f);
            float unitHeight = (bound.Height - 40) / numberOfMachines;

            Rectangle processingTimeRect = Rectangle.Empty;
            Rectangle setupTimeRect = Rectangle.Empty;
            Point TimePoint = new Point();
            Point strJobPoint = new Point();
            Point strMachinePoint = new Point();
            Point strTime = new Point();
            Font jobFont = new Font("Arial", 8.0f);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < numberOfMachines; i++)
            {
                float rectHeight = i * unitHeight;
                processingTimeRect.Height = Convert.ToInt32(unitHeight * 0.9);
                processingTimeRect.Y = Convert.ToInt32(rectHeight + 10);
                setupTimeRect.Height = Convert.ToInt32(unitHeight * 0.9);
                setupTimeRect.Y = Convert.ToInt32(rectHeight + 10);
                strJobPoint.Y = Convert.ToInt32(rectHeight + 0.5 * processingTimeRect.Height + 10);

                for (int j = 0; j < temp_machineLoad[i]; j++)
                {
                    float rectWidth = (jobStartEndTime[i][j][1] - jobStartEndTime[i][j][0]) * unitWidth;
                    processingTimeRect.Width = Convert.ToInt32(rectWidth);
                    processingTimeRect.X = 100 + Convert.ToInt32(jobStartEndTime[i][j][0] * unitWidth);
                    strJobPoint.X = 100 + Convert.ToInt32(jobStartEndTime[i][j][0] * unitWidth + 0.5 * rectWidth);
                    g.FillRectangle(Brushes.DarkRed, processingTimeRect);
                    g.DrawString($"{soFarTheBestSolution[i][j] + 1}", jobFont, Brushes.White, strJobPoint, sf);
                }



                strMachinePoint.X = 50;
                strMachinePoint.Y = Convert.ToInt32(rectHeight + 0.5 * processingTimeRect.Height + 10);
                g.DrawString($"Machine {i + 1}", jobFont, Brushes.Black, strMachinePoint, sf);
            }

            TimePoint.Y = bound.Height - 15;
            strTime.X = 50;
            strTime.Y = bound.Height - 15;
            for (int i = 0; i < SoFarTheBestObjective; i++)
            {
                if(i % 5 == 0)
                {
                    TimePoint.X = Convert.ToInt32(100 + unitWidth * i);
                    g.DrawString($"{i}", jobFont, Brushes.Black, TimePoint, sf);
                }
            }
            g.DrawString("Time", jobFont, Brushes.Black, strTime, sf);
        }

        #endregion
    }
}
