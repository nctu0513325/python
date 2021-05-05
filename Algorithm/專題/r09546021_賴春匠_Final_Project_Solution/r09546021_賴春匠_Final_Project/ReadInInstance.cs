using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace r09546021_賴春匠_Final_Project
{
    class ReadInInstance
    {
        #region Data Field

        string fileName;
        int numberOfJobs;
        int numberOfMachines;

        float[,] processingTime;    // processingTime[i, j]: Job_i process on Machine_j 的 processing time
        float[][,] setupTime;       // setupTime[m][i, j]  : 在 Machine_i 上, Job_i 接 Job_j 的 setup time

        #endregion

        #region Property

        public int NumberOfJobs 
        { 
            get => numberOfJobs;
            set { if (value >= 2) numberOfJobs = value; }
        }
        public int NumberOfMachines 
        { 
            get => numberOfMachines;
            set { if (value >= 2) numberOfMachines = value; }
        }

        public float[][,] SetupTime { get => setupTime; set => setupTime = value; }
        public float[,] ProcessingTime { get => processingTime; set => processingTime = value; }

        #endregion

        #region Functions

        // 讀取已經存在的實例檔案.txt
        public void OpenFile(string path)
        {
            // 讀取檔案
            fileName = path;
            StreamReader sr = new StreamReader(fileName);
            string str;
            string[] items;
            char[] sep = { ' ' };
            str = sr.ReadLine();
            items = str.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            numberOfJobs = Convert.ToInt32(items[0]);
            numberOfMachines = Convert.ToInt32(items[1]);
            sr.ReadLine(); // 實例檔案多一行紀錄 machine 數

            // 根據讀入檔案的 machine, job 數開記憶體
            processingTime = new float[numberOfJobs, numberOfMachines];
            setupTime = new float[numberOfMachines][,];
            for (int i = 0; i < numberOfMachines; i++)
                setupTime[i] = new float[numberOfJobs, numberOfJobs];

            // 寫入 processingTime 參數
            for(int i = 0; i < numberOfJobs; i++)
            {
                str = sr.ReadLine();
                items = str.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int j = 1; j < items.Length; j += 2)
                    processingTime[i, (j - 1) / 2] = Convert.ToInt32(items[j]);
            }
            sr.ReadLine(); // 原資料多一行 SSD

            // 寫入 setupTime 參數
            for(int i = 0; i < numberOfMachines; i++)
            {
                sr.ReadLine(); // 跳過原資料第幾台 Machine 資訊行
                for(int j = 0; j < numberOfJobs; j++)
                {
                    str = sr.ReadLine();
                    items = str.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < numberOfJobs; k++)
                        setupTime[i][j, k] = Convert.ToSingle(items[k]);
                }
            }
            
            sr.Close();
        }

        #endregion

        #region 使用者調整參數 Function

        // 調整 processingTime 參數
        public void ChangeProcessingTime(int job_index, int machine_index, float newProcessingTime)
        {
            processingTime[job_index, machine_index] = newProcessingTime;
        }

        // 調整 setupTime 參數
        public void ChangeSetupTime(int machine_index, int job1Index, int job2Index, float newSetupTime)
        {
            setupTime[machine_index][job1Index, job2Index] = newSetupTime;
        }



        #endregion
    }
}
