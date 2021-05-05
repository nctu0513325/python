using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r09546021_賴春匠_Final_Project
{
    public partial class MainForm : Form
    {
        ReadInInstance theProblem;
        ParallelMachineSequenceDependentGASolver theSolver;
        float valueBeforeChanged;
        bool afterReadinFile = false;
        bool afterOneIteration = false;
        
        // 接收子表單訊息
        float[,] processingTimeFromChild;
        float[][,] setupTimeFromChild;
        int numberOfChildMachine;
        int numberOfChildJob;
        bool childFormClosed;

        public float[,] ProcessingTimeFromChild
        {
            set { processingTimeFromChild = value; }
        }
        public float[][,] SetupTimeFromChild
        {
            set { setupTimeFromChild = value; }
        }

        public int NumberOfChildMachine { set => numberOfChildMachine = value; }
        public int NumberOfChildJob { set => numberOfChildJob = value; }
        public bool ChildFormClosed { set => childFormClosed = value; }

        public MainForm()
        {
            InitializeComponent();
            theProblem = new ReadInInstance();
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterReadinFile = false;
            // 開新檔案時更新 dgv
            dgvProcessingTime.Rows.Clear(); 
            dgvProcessingTime.Columns.Clear();
            dgvSetupTime.Rows.Clear();
            dgvSetupTime.Columns.Clear();
            cbxSetupTimeMachine.Items.Clear();

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            theProblem.OpenFile(dlg.FileName);

            labelNumberOfJobs.Text = $"Number of Jobs: {theProblem.NumberOfJobs}";
            labelNumberOfMachines.Text = $"Number of Machines: {theProblem.NumberOfMachines}";
            string[] splitFileName = dlg.FileName.Split('\\');// 一定是單引 
            string fileName = splitFileName[splitFileName.Length - 1];
            labelFileName.Text = $"File Name: {fileName}";
            // 讓使用者可以選擇要看哪台 Machine 上的 SetupTime 資訊
            for (int i = 0; i < theProblem.NumberOfMachines; i++)
                cbxSetupTimeMachine.Items.Add($"Machine {i + 1}");

            // 輸入資料進 dgvProcessingTime
            for(int i = 0; i < theProblem.NumberOfMachines; i++)
                dgvProcessingTime.Columns.Add($"Column{i + 1}", $"Machine{i + 1}");
            dgvProcessingTime.Rows.Add(theProblem.NumberOfJobs);
            for (int i = 0; i < theProblem.NumberOfJobs; i++)
                dgvProcessingTime.Rows[i].HeaderCell.Value = $"Job{i + 1}";
            dgvProcessingTime.RowHeadersWidth = 65;
            for (int i = 0; i < theProblem.NumberOfJobs; i++)
                for (int j = 0; j < theProblem.NumberOfMachines; j++)
                    dgvProcessingTime.Rows[i].Cells[j].Value = theProblem.ProcessingTime[i, j];
            // 輸入資料進 dgvSetupTime
            for (int i = 0; i < theProblem.NumberOfJobs; i++)
                dgvSetupTime.Columns.Add($"Column{i + 1}", $"Job{i + 1}");
            dgvSetupTime.Rows.Add(theProblem.NumberOfJobs);
            for(int i = 0; i < theProblem.NumberOfJobs; i++)
                dgvSetupTime.Rows[i].HeaderCell.Value = $"Job{i + 1}";
            dgvSetupTime.RowHeadersWidth = 65;
            for (int i = 0; i < theProblem.NumberOfJobs; i++)
                for (int j = 0; j < theProblem.NumberOfJobs; j++)
                    dgvSetupTime.Rows[i].Cells[j].Value = theProblem.SetupTime[0][i, j];
            
            cbxSetupTimeMachine.SelectedIndex = 0;

            btnCreateGASolver.Enabled = true;
            btnReset.Enabled = false;
            btnRunToEnd.Enabled = false;
            btnRunOneIteration.Enabled = false;

            afterReadinFile = true;
            // setupTime 同一個工作換到自己 setupTime 一定為 0
            for (int i = 0; i < theProblem.NumberOfJobs; i++)
                dgvSetupTime.Rows[i].Cells[i].ReadOnly = true;

        }

        private void cbxSetupTimeMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < theProblem.NumberOfJobs; i++)
                for (int j = 0; j < theProblem.NumberOfJobs; j++)
                    dgvSetupTime.Rows[i].Cells[j].Value = theProblem.SetupTime[cbxSetupTimeMachine.SelectedIndex][i, j];
        }

        private void btnCreateGASolver_Click(object sender, EventArgs e)
        {
            theSolver = new ParallelMachineSequenceDependentGASolver(theProblem);
            thePropertyGrid.SelectedObject = theSolver;
            btnReset.Enabled = true;
            afterOneIteration = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            theSolver.Reset();
            GAEfficiencyChart.Series[0].Points.Clear();
            GAEfficiencyChart.Series[1].Points.Clear();
            btnRunOneIteration.Enabled = true;
            btnRunToEnd.Enabled = true;
        }

        private void btnRunOneIteration_Click(object sender, EventArgs e)
        {
            afterOneIteration = true;   // 可以開始畫甘特圖
            string strSoFarTheBestSolution = "";
            theSolver.RunOneIteration();
            
            // 印出 soFarTheBestSolution
            for(int i = 0; i < theProblem.NumberOfMachines; i++)
            {
                int key = 0;
                while(theSolver.SoFarTheBestSolution[i][key] != -1)
                {
                    strSoFarTheBestSolution += (theSolver.SoFarTheBestSolution[i][key] + " ");
                    key++;
                }
                strSoFarTheBestSolution += "\n\n";
            }

            GAEfficiencyChart.Series[0].Points.AddXY(theSolver.Iteration, theSolver.IterationAverageObjective);
            GAEfficiencyChart.Series[1].Points.AddXY(theSolver.Iteration, theSolver.SoFarTheBestObjective);
            GAEfficiencyChart.Update();

            rtbBestChromosome.Text = strSoFarTheBestSolution;
            tbBestObjectiveValue.Text = theSolver.SoFarTheBestObjective.ToString();

            spcRight.Panel2.Refresh();
        }

        private void btnRunToEnd_Click(object sender, EventArgs e)
        {
            afterOneIteration = true;   // 可以開始畫甘特圖
            string strSoFarTheBestSolution = "";
            int theProgress;
            for(int i = 0; i < theSolver.IterationLimit; i++)
            {
                theSolver.RunOneIteration();
                theProgress = (i * 100) / theSolver.IterationLimit;
                theProgressBar.Value = theProgress;
                theProgressBar.Refresh();

                GAEfficiencyChart.Series[0].Points.AddXY(theSolver.Iteration, theSolver.IterationAverageObjective);
                GAEfficiencyChart.Series[1].Points.AddXY(theSolver.Iteration, theSolver.SoFarTheBestObjective);
                GAEfficiencyChart.Update();
            }
            theProgressBar.Value = 100;
            theProgressBar.Refresh();

            // 印出 soFarTheBestSolution
            for (int i = 0; i < theProblem.NumberOfMachines; i++)
            {
                int key = 0;
                while (theSolver.SoFarTheBestSolution[i][key] != -1)
                {
                    strSoFarTheBestSolution += (theSolver.SoFarTheBestSolution[i][key] + " ");
                    key++;
                }
                strSoFarTheBestSolution += "\n\n";
            }

            rtbBestChromosome.Text = strSoFarTheBestSolution;
            tbBestObjectiveValue.Text = theSolver.SoFarTheBestObjective.ToString();
            spcRight.Panel2.Refresh();
        }

        private void spcRight_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (theSolver != null && afterOneIteration == true)
                theSolver.DrawGantt(e.Graphics, e.ClipRectangle);
        }

        // 給使用者新增檔案
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            childFormClosed = false;
            Form inputForm = new InputForm();
            inputForm.FormClosed += new FormClosedEventHandler(InputForm_FormClosed);
            inputForm.Owner = this;
            inputForm.Show();
            
        }

        void InputForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (childFormClosed)
            {
                afterReadinFile = false;
                // 開新檔案時更新 dgv
                dgvProcessingTime.Rows.Clear();
                dgvProcessingTime.Columns.Clear();
                dgvSetupTime.Rows.Clear();
                dgvSetupTime.Columns.Clear();
                cbxSetupTimeMachine.Items.Clear();
                theProblem.SetupTime = setupTimeFromChild;
                theProblem.ProcessingTime = processingTimeFromChild;
                theProblem.NumberOfJobs = numberOfChildJob;
                theProblem.NumberOfMachines = numberOfChildMachine;


                labelNumberOfJobs.Text = $"Number of Jobs: {theProblem.NumberOfJobs}";
                labelNumberOfMachines.Text = $"Number of Machines: {theProblem.NumberOfMachines}";
                labelFileName.Text = $"New File";
                // 讓使用者可以選擇要看哪台 Machine 上的 SetupTime 資訊
                for (int i = 0; i < theProblem.NumberOfMachines; i++)
                    cbxSetupTimeMachine.Items.Add($"Machine {i + 1}");

                // 輸入資料進 dgvProcessingTime
                for (int i = 0; i < theProblem.NumberOfMachines; i++)
                    dgvProcessingTime.Columns.Add($"Column{i + 1}", $"Machine{i + 1}");
                dgvProcessingTime.Rows.Add(theProblem.NumberOfJobs);
                for (int i = 0; i < theProblem.NumberOfJobs; i++)
                    dgvProcessingTime.Rows[i].HeaderCell.Value = $"Job{i + 1}";
                dgvProcessingTime.RowHeadersWidth = 65;
                for (int i = 0; i < theProblem.NumberOfJobs; i++)
                    for (int j = 0; j < theProblem.NumberOfMachines; j++)
                        dgvProcessingTime.Rows[i].Cells[j].Value = theProblem.ProcessingTime[i, j];
                // 輸入資料進 dgvSetupTime
                for (int i = 0; i < theProblem.NumberOfJobs; i++)
                    dgvSetupTime.Columns.Add($"Column{i + 1}", $"Job{i + 1}");
                dgvSetupTime.Rows.Add(theProblem.NumberOfJobs);
                for (int i = 0; i < theProblem.NumberOfJobs; i++)
                    dgvSetupTime.Rows[i].HeaderCell.Value = $"Job{i + 1}";
                dgvSetupTime.RowHeadersWidth = 65;
                for (int i = 0; i < theProblem.NumberOfJobs; i++)
                    for (int j = 0; j < theProblem.NumberOfJobs; j++)
                        dgvSetupTime.Rows[i].Cells[j].Value = theProblem.SetupTime[0][i, j];

                cbxSetupTimeMachine.SelectedIndex = 0;

                btnCreateGASolver.Enabled = true;
                btnReset.Enabled = false;
                btnRunToEnd.Enabled = false;
                btnRunOneIteration.Enabled = false;

                afterReadinFile = true;
                // setupTime 同一個工作換到自己 setupTime 一定為 0
                for (int i = 0; i < theProblem.NumberOfJobs; i++)
                    dgvSetupTime.Rows[i].Cells[i].ReadOnly = true;
            }
        }


        // 給使用者調整 processingTime 參數
        private void dgvProcessingTime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (afterReadinFile)
            {
                if (Convert.ToSingle(dgvProcessingTime[e.ColumnIndex, e.RowIndex].Value) < 0)
                    dgvProcessingTime[e.ColumnIndex, e.RowIndex].Value = valueBeforeChanged;
                else
                    theProblem.ChangeProcessingTime(e.RowIndex, e.ColumnIndex, Convert.ToSingle(dgvProcessingTime[e.ColumnIndex, e.RowIndex].Value));
            }
        }
        private void dgvProcessingTime_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            valueBeforeChanged = Convert.ToSingle(dgvProcessingTime[e.ColumnIndex, e.RowIndex].Value);
        }

        // 給使用者調整 setupTime 參數
        private void dgvSetupTime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (afterReadinFile)
            {
                if (Convert.ToSingle(dgvSetupTime[e.ColumnIndex, e.RowIndex].Value) < 0)
                    dgvSetupTime[e.ColumnIndex, e.RowIndex].Value = valueBeforeChanged;
                else
                    theProblem.ChangeSetupTime(cbxSetupTimeMachine.SelectedIndex, e.RowIndex, e.ColumnIndex, Convert.ToSingle(dgvSetupTime[e.ColumnIndex, e.RowIndex].Value));
            }
        }
        private void dgvSetupTime_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            valueBeforeChanged = Convert.ToSingle(dgvSetupTime[e.ColumnIndex, e.RowIndex].Value);
        }

        // 存檔功能
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (theProblem.NumberOfJobs == 0) MessageBox.Show("沒有可以存檔的檔案");
            else
            {
                int numberOfJobs = theProblem.NumberOfJobs;
                int numberOfMachine = theProblem.NumberOfMachines;
                string[] strfile;
                string temp_str = "";
                strfile = new string[(numberOfMachine + 1) * numberOfJobs + numberOfMachine + 3];
                strfile[0] = $"{numberOfJobs}  {numberOfMachine}  1";
                strfile[1] = numberOfMachine.ToString();
                for(int i = 0; i < numberOfJobs; i++)
                {
                    temp_str = "";
                    for(int j = 0; j < numberOfMachine; j++)
                        temp_str += $"\t {j} \t {theProblem.ProcessingTime[i, j]}";
                    strfile[i + 2] = temp_str;
                }
                strfile[2 + numberOfJobs] = "SSD";
                for (int i = 0; i < numberOfMachine; i++)
                {
                    for(int j = 0; j < numberOfJobs + 1; j++)
                    {
                        if (j == 0) strfile[numberOfJobs + 3 + (numberOfJobs + 1) * i] = $"M{i}";
                        else
                        {
                            temp_str = "";
                            for (int k = 0; k < numberOfJobs; k++)
                                temp_str += $"{theProblem.SetupTime[i][(j - 1), k]} \t";
                            strfile[numberOfJobs + 3 + (numberOfJobs + 1) * i + j] = temp_str;
                        }
                    }
                }

                SaveFileDialog save = new SaveFileDialog();
                save.FileName = "DefaultOutputName.txt";
                save.Filter = "Text File | *.txt";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(save.OpenFile());
                    for (int i = 0; i < 3 * numberOfJobs + numberOfMachine + 3; i++)
                    {
                        writer.WriteLine(strfile[i]);
                    }
                    writer.Dispose();
                    writer.Close();
                }
            }
        }
    }
}
