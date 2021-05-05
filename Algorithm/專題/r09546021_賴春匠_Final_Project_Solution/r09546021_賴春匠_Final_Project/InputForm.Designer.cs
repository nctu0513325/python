namespace r09546021_賴春匠_Final_Project
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spcInputFormMain = new System.Windows.Forms.SplitContainer();
            this.btnInputFormCancel = new System.Windows.Forms.Button();
            this.btnInputFormSubmit = new System.Windows.Forms.Button();
            this.btnInputFormConfirm = new System.Windows.Forms.Button();
            this.nupInputFormNumberOfJobs = new System.Windows.Forms.NumericUpDown();
            this.labelInputFormNumberOfJob = new System.Windows.Forms.Label();
            this.nupInputFormNumberOfMachine = new System.Windows.Forms.NumericUpDown();
            this.labelInputFormNumberOfMachine = new System.Windows.Forms.Label();
            this.tabpageInputFormMain = new System.Windows.Forms.TabControl();
            this.tabpageInputFormProcessingTime = new System.Windows.Forms.TabPage();
            this.btnInputFormProcessingTimeSave = new System.Windows.Forms.Button();
            this.labelInputFormProcessingTime = new System.Windows.Forms.Label();
            this.dgvInputFromProcessingTime = new System.Windows.Forms.DataGridView();
            this.tabpageInputFormSetupTime = new System.Windows.Forms.TabPage();
            this.btnInputFormSetupTimeSave = new System.Windows.Forms.Button();
            this.dgvInputFormSetupTime = new System.Windows.Forms.DataGridView();
            this.labelInputFormSetupTime = new System.Windows.Forms.Label();
            this.cbxInputFormMachine = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.spcInputFormMain)).BeginInit();
            this.spcInputFormMain.Panel1.SuspendLayout();
            this.spcInputFormMain.Panel2.SuspendLayout();
            this.spcInputFormMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupInputFormNumberOfJobs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupInputFormNumberOfMachine)).BeginInit();
            this.tabpageInputFormMain.SuspendLayout();
            this.tabpageInputFormProcessingTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputFromProcessingTime)).BeginInit();
            this.tabpageInputFormSetupTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputFormSetupTime)).BeginInit();
            this.SuspendLayout();
            // 
            // spcInputFormMain
            // 
            this.spcInputFormMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcInputFormMain.Location = new System.Drawing.Point(0, 0);
            this.spcInputFormMain.Name = "spcInputFormMain";
            // 
            // spcInputFormMain.Panel1
            // 
            this.spcInputFormMain.Panel1.Controls.Add(this.btnInputFormCancel);
            this.spcInputFormMain.Panel1.Controls.Add(this.btnInputFormSubmit);
            this.spcInputFormMain.Panel1.Controls.Add(this.btnInputFormConfirm);
            this.spcInputFormMain.Panel1.Controls.Add(this.nupInputFormNumberOfJobs);
            this.spcInputFormMain.Panel1.Controls.Add(this.labelInputFormNumberOfJob);
            this.spcInputFormMain.Panel1.Controls.Add(this.nupInputFormNumberOfMachine);
            this.spcInputFormMain.Panel1.Controls.Add(this.labelInputFormNumberOfMachine);
            // 
            // spcInputFormMain.Panel2
            // 
            this.spcInputFormMain.Panel2.Controls.Add(this.tabpageInputFormMain);
            this.spcInputFormMain.Size = new System.Drawing.Size(800, 450);
            this.spcInputFormMain.SplitterDistance = 169;
            this.spcInputFormMain.TabIndex = 0;
            // 
            // btnInputFormCancel
            // 
            this.btnInputFormCancel.Location = new System.Drawing.Point(26, 180);
            this.btnInputFormCancel.Name = "btnInputFormCancel";
            this.btnInputFormCancel.Size = new System.Drawing.Size(118, 23);
            this.btnInputFormCancel.TabIndex = 6;
            this.btnInputFormCancel.Text = "Cancel";
            this.btnInputFormCancel.UseVisualStyleBackColor = true;
            this.btnInputFormCancel.Click += new System.EventHandler(this.btnInputFormCancel_Click);
            // 
            // btnInputFormSubmit
            // 
            this.btnInputFormSubmit.Enabled = false;
            this.btnInputFormSubmit.Location = new System.Drawing.Point(26, 151);
            this.btnInputFormSubmit.Name = "btnInputFormSubmit";
            this.btnInputFormSubmit.Size = new System.Drawing.Size(118, 23);
            this.btnInputFormSubmit.TabIndex = 5;
            this.btnInputFormSubmit.Text = "Submit";
            this.btnInputFormSubmit.UseVisualStyleBackColor = true;
            this.btnInputFormSubmit.Click += new System.EventHandler(this.btnInputFormSubmit_Click);
            // 
            // btnInputFormConfirm
            // 
            this.btnInputFormConfirm.Location = new System.Drawing.Point(26, 122);
            this.btnInputFormConfirm.Name = "btnInputFormConfirm";
            this.btnInputFormConfirm.Size = new System.Drawing.Size(118, 23);
            this.btnInputFormConfirm.TabIndex = 4;
            this.btnInputFormConfirm.Text = "Confirm";
            this.btnInputFormConfirm.UseVisualStyleBackColor = true;
            this.btnInputFormConfirm.Click += new System.EventHandler(this.btnInputFormConfirm_Click);
            // 
            // nupInputFormNumberOfJobs
            // 
            this.nupInputFormNumberOfJobs.Location = new System.Drawing.Point(26, 81);
            this.nupInputFormNumberOfJobs.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nupInputFormNumberOfJobs.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupInputFormNumberOfJobs.Name = "nupInputFormNumberOfJobs";
            this.nupInputFormNumberOfJobs.Size = new System.Drawing.Size(118, 22);
            this.nupInputFormNumberOfJobs.TabIndex = 3;
            this.nupInputFormNumberOfJobs.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupInputFormNumberOfJobs.ValueChanged += new System.EventHandler(this.nupInputFormNumberOfJobs_ValueChanged);
            // 
            // labelInputFormNumberOfJob
            // 
            this.labelInputFormNumberOfJob.AutoSize = true;
            this.labelInputFormNumberOfJob.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelInputFormNumberOfJob.Location = new System.Drawing.Point(14, 62);
            this.labelInputFormNumberOfJob.Name = "labelInputFormNumberOfJob";
            this.labelInputFormNumberOfJob.Size = new System.Drawing.Size(116, 16);
            this.labelInputFormNumberOfJob.TabIndex = 2;
            this.labelInputFormNumberOfJob.Text = "Number of Jobs: ";
            // 
            // nupInputFormNumberOfMachine
            // 
            this.nupInputFormNumberOfMachine.Location = new System.Drawing.Point(26, 28);
            this.nupInputFormNumberOfMachine.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nupInputFormNumberOfMachine.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupInputFormNumberOfMachine.Name = "nupInputFormNumberOfMachine";
            this.nupInputFormNumberOfMachine.Size = new System.Drawing.Size(118, 22);
            this.nupInputFormNumberOfMachine.TabIndex = 1;
            this.nupInputFormNumberOfMachine.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupInputFormNumberOfMachine.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // labelInputFormNumberOfMachine
            // 
            this.labelInputFormNumberOfMachine.AutoSize = true;
            this.labelInputFormNumberOfMachine.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelInputFormNumberOfMachine.Location = new System.Drawing.Point(12, 9);
            this.labelInputFormNumberOfMachine.Name = "labelInputFormNumberOfMachine";
            this.labelInputFormNumberOfMachine.Size = new System.Drawing.Size(144, 16);
            this.labelInputFormNumberOfMachine.TabIndex = 0;
            this.labelInputFormNumberOfMachine.Text = "Number of Machines:";
            // 
            // tabpageInputFormMain
            // 
            this.tabpageInputFormMain.Controls.Add(this.tabpageInputFormProcessingTime);
            this.tabpageInputFormMain.Controls.Add(this.tabpageInputFormSetupTime);
            this.tabpageInputFormMain.Location = new System.Drawing.Point(3, 3);
            this.tabpageInputFormMain.Name = "tabpageInputFormMain";
            this.tabpageInputFormMain.SelectedIndex = 0;
            this.tabpageInputFormMain.Size = new System.Drawing.Size(621, 444);
            this.tabpageInputFormMain.TabIndex = 0;
            // 
            // tabpageInputFormProcessingTime
            // 
            this.tabpageInputFormProcessingTime.Controls.Add(this.btnInputFormProcessingTimeSave);
            this.tabpageInputFormProcessingTime.Controls.Add(this.labelInputFormProcessingTime);
            this.tabpageInputFormProcessingTime.Controls.Add(this.dgvInputFromProcessingTime);
            this.tabpageInputFormProcessingTime.Location = new System.Drawing.Point(4, 22);
            this.tabpageInputFormProcessingTime.Name = "tabpageInputFormProcessingTime";
            this.tabpageInputFormProcessingTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageInputFormProcessingTime.Size = new System.Drawing.Size(613, 418);
            this.tabpageInputFormProcessingTime.TabIndex = 0;
            this.tabpageInputFormProcessingTime.Text = "Processing Time";
            this.tabpageInputFormProcessingTime.UseVisualStyleBackColor = true;
            // 
            // btnInputFormProcessingTimeSave
            // 
            this.btnInputFormProcessingTimeSave.Location = new System.Drawing.Point(489, 19);
            this.btnInputFormProcessingTimeSave.Name = "btnInputFormProcessingTimeSave";
            this.btnInputFormProcessingTimeSave.Size = new System.Drawing.Size(118, 23);
            this.btnInputFormProcessingTimeSave.TabIndex = 7;
            this.btnInputFormProcessingTimeSave.Text = "Save";
            this.btnInputFormProcessingTimeSave.UseVisualStyleBackColor = true;
            this.btnInputFormProcessingTimeSave.Click += new System.EventHandler(this.btnInputFormProcessingTimeSave_Click);
            // 
            // labelInputFormProcessingTime
            // 
            this.labelInputFormProcessingTime.AutoSize = true;
            this.labelInputFormProcessingTime.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelInputFormProcessingTime.Location = new System.Drawing.Point(3, 15);
            this.labelInputFormProcessingTime.Name = "labelInputFormProcessingTime";
            this.labelInputFormProcessingTime.Size = new System.Drawing.Size(119, 16);
            this.labelInputFormProcessingTime.TabIndex = 1;
            this.labelInputFormProcessingTime.Text = "Processing Time: ";
            // 
            // dgvInputFromProcessingTime
            // 
            this.dgvInputFromProcessingTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputFromProcessingTime.Location = new System.Drawing.Point(3, 48);
            this.dgvInputFromProcessingTime.Name = "dgvInputFromProcessingTime";
            this.dgvInputFromProcessingTime.RowTemplate.Height = 24;
            this.dgvInputFromProcessingTime.Size = new System.Drawing.Size(607, 367);
            this.dgvInputFromProcessingTime.TabIndex = 0;
            this.dgvInputFromProcessingTime.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInputFromProcessingTime_CellBeginEdit);
            this.dgvInputFromProcessingTime.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputFromProcessingTime_CellValueChanged);
            // 
            // tabpageInputFormSetupTime
            // 
            this.tabpageInputFormSetupTime.Controls.Add(this.btnInputFormSetupTimeSave);
            this.tabpageInputFormSetupTime.Controls.Add(this.dgvInputFormSetupTime);
            this.tabpageInputFormSetupTime.Controls.Add(this.labelInputFormSetupTime);
            this.tabpageInputFormSetupTime.Controls.Add(this.cbxInputFormMachine);
            this.tabpageInputFormSetupTime.Location = new System.Drawing.Point(4, 22);
            this.tabpageInputFormSetupTime.Name = "tabpageInputFormSetupTime";
            this.tabpageInputFormSetupTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageInputFormSetupTime.Size = new System.Drawing.Size(613, 418);
            this.tabpageInputFormSetupTime.TabIndex = 1;
            this.tabpageInputFormSetupTime.Text = "SetupTime";
            this.tabpageInputFormSetupTime.UseVisualStyleBackColor = true;
            // 
            // btnInputFormSetupTimeSave
            // 
            this.btnInputFormSetupTimeSave.Location = new System.Drawing.Point(489, 19);
            this.btnInputFormSetupTimeSave.Name = "btnInputFormSetupTimeSave";
            this.btnInputFormSetupTimeSave.Size = new System.Drawing.Size(118, 23);
            this.btnInputFormSetupTimeSave.TabIndex = 7;
            this.btnInputFormSetupTimeSave.Text = "Save";
            this.btnInputFormSetupTimeSave.UseVisualStyleBackColor = true;
            this.btnInputFormSetupTimeSave.Click += new System.EventHandler(this.btnInputFormSetupTimeSave_Click);
            // 
            // dgvInputFormSetupTime
            // 
            this.dgvInputFormSetupTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputFormSetupTime.Location = new System.Drawing.Point(3, 48);
            this.dgvInputFormSetupTime.Name = "dgvInputFormSetupTime";
            this.dgvInputFormSetupTime.RowTemplate.Height = 24;
            this.dgvInputFormSetupTime.Size = new System.Drawing.Size(607, 367);
            this.dgvInputFormSetupTime.TabIndex = 2;
            this.dgvInputFormSetupTime.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInputFormSetupTime_CellBeginEdit);
            this.dgvInputFormSetupTime.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputFormSetupTime_CellValueChanged);
            // 
            // labelInputFormSetupTime
            // 
            this.labelInputFormSetupTime.AutoSize = true;
            this.labelInputFormSetupTime.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelInputFormSetupTime.Location = new System.Drawing.Point(3, 29);
            this.labelInputFormSetupTime.Name = "labelInputFormSetupTime";
            this.labelInputFormSetupTime.Size = new System.Drawing.Size(87, 16);
            this.labelInputFormSetupTime.TabIndex = 1;
            this.labelInputFormSetupTime.Text = "Setup Time: ";
            // 
            // cbxInputFormMachine
            // 
            this.cbxInputFormMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInputFormMachine.FormattingEnabled = true;
            this.cbxInputFormMachine.Location = new System.Drawing.Point(6, 6);
            this.cbxInputFormMachine.Name = "cbxInputFormMachine";
            this.cbxInputFormMachine.Size = new System.Drawing.Size(121, 20);
            this.cbxInputFormMachine.TabIndex = 0;
            this.cbxInputFormMachine.SelectedIndexChanged += new System.EventHandler(this.cbxInputFormMachine_SelectedIndexChanged);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.spcInputFormMain);
            this.Name = "InputForm";
            this.Text = "InputForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InputForm_FormClosed);
            this.spcInputFormMain.Panel1.ResumeLayout(false);
            this.spcInputFormMain.Panel1.PerformLayout();
            this.spcInputFormMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcInputFormMain)).EndInit();
            this.spcInputFormMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupInputFormNumberOfJobs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupInputFormNumberOfMachine)).EndInit();
            this.tabpageInputFormMain.ResumeLayout(false);
            this.tabpageInputFormProcessingTime.ResumeLayout(false);
            this.tabpageInputFormProcessingTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputFromProcessingTime)).EndInit();
            this.tabpageInputFormSetupTime.ResumeLayout(false);
            this.tabpageInputFormSetupTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputFormSetupTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcInputFormMain;
        private System.Windows.Forms.TabControl tabpageInputFormMain;
        private System.Windows.Forms.TabPage tabpageInputFormProcessingTime;
        private System.Windows.Forms.TabPage tabpageInputFormSetupTime;
        private System.Windows.Forms.Label labelInputFormSetupTime;
        private System.Windows.Forms.ComboBox cbxInputFormMachine;
        private System.Windows.Forms.Label labelInputFormProcessingTime;
        private System.Windows.Forms.DataGridView dgvInputFromProcessingTime;
        private System.Windows.Forms.DataGridView dgvInputFormSetupTime;
        private System.Windows.Forms.Button btnInputFormCancel;
        private System.Windows.Forms.Button btnInputFormSubmit;
        private System.Windows.Forms.Button btnInputFormConfirm;
        private System.Windows.Forms.NumericUpDown nupInputFormNumberOfJobs;
        private System.Windows.Forms.Label labelInputFormNumberOfJob;
        private System.Windows.Forms.NumericUpDown nupInputFormNumberOfMachine;
        private System.Windows.Forms.Label labelInputFormNumberOfMachine;
        private System.Windows.Forms.Button btnInputFormProcessingTimeSave;
        private System.Windows.Forms.Button btnInputFormSetupTimeSave;
    }
}