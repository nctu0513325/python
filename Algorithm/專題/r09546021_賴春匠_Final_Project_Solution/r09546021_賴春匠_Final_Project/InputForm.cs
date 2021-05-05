using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r09546021_賴春匠_Final_Project
{
    public partial class InputForm : Form
    {
        float[,] processingTime;
        float[][,] setupTime;
        float valueBeforeChange;
        bool beforeIsNull;
        bool isConfirmed = false;
        bool[] setupDataComplete;
        bool processingDataComplete;

        public float[][,] SetupTime { get => setupTime; set => setupTime = value; }

        public InputForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dgvInputFormSetupTime.Columns.Clear();
            dgvInputFromProcessingTime.Columns.Clear();
            cbxInputFormMachine.Items.Clear();
            isConfirmed = false;
        }

        private void nupInputFormNumberOfJobs_ValueChanged(object sender, EventArgs e)
        {
            dgvInputFormSetupTime.Columns.Clear();
            dgvInputFromProcessingTime.Columns.Clear();
            cbxInputFormMachine.Items.Clear();
            isConfirmed = false;
        }

        private void btnInputFormConfirm_Click(object sender, EventArgs e)
        {
            int numberOfJobs = Convert.ToInt32(nupInputFormNumberOfJobs.Value);
            int numberOfMachines = Convert.ToInt32(nupInputFormNumberOfMachine.Value);
            // 初始化記憶體
            processingTime = new float[numberOfJobs, numberOfMachines];
            setupTime = new float[numberOfMachines][,];
            for (int i = 0; i < numberOfMachines; i++)
                setupTime[i] = new float[numberOfJobs, numberOfJobs];
            setupDataComplete = new bool[numberOfMachines];
            for (int i = 0; i < numberOfMachines; i++)
                setupDataComplete[i] = false;
            processingDataComplete = false;


            // 建構 DGV
            for (int i = 0; i < numberOfMachines; i++)
                dgvInputFromProcessingTime.Columns.Add($"Column_{i + 1}", $"Machine{i + 1}");
            dgvInputFromProcessingTime.Rows.Add(numberOfJobs);
            for (int i = 0; i < numberOfJobs; i++)
                dgvInputFormSetupTime.Columns.Add($"Column_{i + 1}", $"Job{i + 1}");
            dgvInputFormSetupTime.Rows.Add(numberOfJobs);
            for (int i = 0; i < numberOfJobs; i++)
                dgvInputFromProcessingTime.Rows[i].HeaderCell.Value = $"Job{i + 1}";
            dgvInputFromProcessingTime.RowHeadersWidth = 65;
            for (int i = 0; i < numberOfJobs; i++)
                dgvInputFormSetupTime.Rows[i].HeaderCell.Value = $"Job{i + 1}";
            dgvInputFormSetupTime.RowHeadersWidth = 65;
            for (int i = 0; i < numberOfMachines; i++)
                cbxInputFormMachine.Items.Add($"Machine {i + 1}");
            cbxInputFormMachine.SelectedIndex = 0;
            for (int i = 0; i < numberOfJobs; i++)
                dgvInputFormSetupTime.Rows[i].Cells[i].ReadOnly = true;

            isConfirmed = true;
        }

        // SetupTime 介面切換選擇的 Machine
        private void cbxInputFormMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            int numberOfJobs = Convert.ToInt32(nupInputFormNumberOfJobs.Value);
            int numberOfMachines = Convert.ToInt32(nupInputFormNumberOfMachine.Value);
            for (int i = 0; i < numberOfJobs; i++)
                for (int j = 0; j < numberOfJobs; j++)
                    dgvInputFormSetupTime.Rows[i].Cells[j].Value = null;
            for (int i = 0; i < numberOfJobs; i++)
                dgvInputFormSetupTime.Rows[i].Cells[i].Value = 0;
        }

        #region 設定 ProcessingTime 參數
        private void dgvInputFromProcessingTime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isConfirmed)
                if (Convert.ToSingle(dgvInputFromProcessingTime[e.ColumnIndex, e.RowIndex].Value) < 0)
                {
                    if (beforeIsNull == true) dgvInputFromProcessingTime[e.ColumnIndex, e.RowIndex].Value = null;
                    else dgvInputFromProcessingTime[e.ColumnIndex, e.RowIndex].Value = valueBeforeChange;
                }
        }
        private void dgvInputFromProcessingTime_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            beforeIsNull = false;
            if (dgvInputFromProcessingTime[e.ColumnIndex, e.RowIndex].Value != null)
                valueBeforeChange = Convert.ToSingle(dgvInputFromProcessingTime[e.ColumnIndex, e.RowIndex].Value);
            else
                beforeIsNull = true;
        }
        private void btnInputFormProcessingTimeSave_Click(object sender, EventArgs e)
        {
            int numberOfJobs = Convert.ToInt32(nupInputFormNumberOfJobs.Value);
            int numberOfMachines = Convert.ToInt32(nupInputFormNumberOfMachine.Value);
            // 檢查是否每格都有值
            bool isFulled = true;
            bool allSetupTimeCompleted = true;
            for(int i = 0; i < numberOfJobs; i++)
                for(int j = 0; j < numberOfMachines; j++)
                    if (dgvInputFromProcessingTime.Rows[i].Cells[j].Value == null) isFulled = false;
            if (isFulled)
            {
                for (int i = 0; i < numberOfJobs; i++)
                    for (int j = 0; j < numberOfMachines; j++)
                        processingTime[i, j] = Convert.ToSingle(dgvInputFromProcessingTime.Rows[i].Cells[j].Value);
                MessageBox.Show("儲存成功");
                processingDataComplete = true;
                for (int i = 0; i < numberOfMachines; i++)
                    if (setupDataComplete[i] == false)
                    {
                        allSetupTimeCompleted = false;
                        break;
                    }
                if (allSetupTimeCompleted && processingDataComplete)
                    btnInputFormSubmit.Enabled = true;
            }
            else
            {
                MessageBox.Show("請輸入完整資訊");
            }
        }

        #endregion

        #region 設定 SetupTime 參數

        private void dgvInputFormSetupTime_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isConfirmed)
                if (Convert.ToSingle(dgvInputFormSetupTime[e.ColumnIndex, e.RowIndex].Value) < 0)
                {
                    if (beforeIsNull == true) dgvInputFormSetupTime[e.ColumnIndex, e.RowIndex].Value = null;
                    else dgvInputFormSetupTime[e.ColumnIndex, e.RowIndex].Value = valueBeforeChange;
                }
        }
        private void dgvInputFormSetupTime_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            beforeIsNull = false;
            if (dgvInputFormSetupTime[e.ColumnIndex, e.RowIndex].Value != null)
                valueBeforeChange = Convert.ToSingle(dgvInputFormSetupTime[e.ColumnIndex, e.RowIndex].Value);
            else
                beforeIsNull = true;
        }
        private void btnInputFormSetupTimeSave_Click(object sender, EventArgs e)
        {
            int numberOfJobs = Convert.ToInt32(nupInputFormNumberOfJobs.Value);
            int numberOfMachines = Convert.ToInt32(nupInputFormNumberOfMachine.Value);
            // 檢查是否每格都有值
            bool isFulled = true;
            bool allSetupTimeCompleted = true;
            for (int i = 0; i < numberOfJobs; i++)
                for (int j = 0; j < numberOfJobs; j++)
                    if (dgvInputFormSetupTime.Rows[i].Cells[j].Value == null) isFulled = false;
            if (isFulled)
            {
                for (int i = 0; i < numberOfJobs; i++)
                    for (int j = 0; j < numberOfJobs; j++)
                        setupTime[cbxInputFormMachine.SelectedIndex][i, j] = Convert.ToSingle(dgvInputFormSetupTime.Rows[i].Cells[j].Value);
                MessageBox.Show("儲存成功");
                setupDataComplete[cbxInputFormMachine.SelectedIndex] = true;
                for(int i = 0; i < numberOfMachines; i++)
                    if(setupDataComplete[i] == false)
                    {
                        allSetupTimeCompleted = false;
                        break;
                    }
                if (allSetupTimeCompleted && processingDataComplete)
                    btnInputFormSubmit.Enabled = true;
            }
            else
            {
                MessageBox.Show("請輸入完整資訊");
            }
        }
        #endregion

        // 寫入檔案
        private void btnInputFormSubmit_Click(object sender, EventArgs e)
        {
            int numberOfJobs = Convert.ToInt32(nupInputFormNumberOfJobs.Value);
            int numberOfMachines = Convert.ToInt32(nupInputFormNumberOfMachine.Value);
            MainForm parentForm = (MainForm)this.Owner;
            parentForm.ProcessingTimeFromChild = processingTime;
            parentForm.SetupTimeFromChild = setupTime;
            parentForm.NumberOfChildJob = numberOfJobs;
            parentForm.NumberOfChildMachine = numberOfMachines;
            MessageBox.Show("新增完成");
            parentForm.ChildFormClosed = true;
            this.Close();
        }

        private void btnInputFormCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
