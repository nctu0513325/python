namespace r09546021_賴春匠_Final_Project
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series35 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series36 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.spcLeft = new System.Windows.Forms.SplitContainer();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelNumberOfMachines = new System.Windows.Forms.Label();
            this.labelNumberOfJobs = new System.Windows.Forms.Label();
            this.spcLeft_Down = new System.Windows.Forms.SplitContainer();
            this.thePropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabpageMain = new System.Windows.Forms.TabControl();
            this.tabpageProcessingTime = new System.Windows.Forms.TabPage();
            this.dgvProcessingTime = new System.Windows.Forms.DataGridView();
            this.labelProcessingTime = new System.Windows.Forms.Label();
            this.tabpageSetupTime = new System.Windows.Forms.TabPage();
            this.dgvSetupTime = new System.Windows.Forms.DataGridView();
            this.cbxSetupTimeMachine = new System.Windows.Forms.ComboBox();
            this.labelSetupTime = new System.Windows.Forms.Label();
            this.spcRight = new System.Windows.Forms.SplitContainer();
            this.spcRightTop = new System.Windows.Forms.SplitContainer();
            this.btnCreateGASolver = new System.Windows.Forms.Button();
            this.rtbBestChromosome = new System.Windows.Forms.RichTextBox();
            this.labelBestChromosome = new System.Windows.Forms.Label();
            this.tbBestObjectiveValue = new System.Windows.Forms.TextBox();
            this.labelBestObjectiveValue = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRunToEnd = new System.Windows.Forms.Button();
            this.btnRunOneIteration = new System.Windows.Forms.Button();
            this.theProgressBar = new System.Windows.Forms.ProgressBar();
            this.GAEfficiencyChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).BeginInit();
            this.spcLeft.Panel1.SuspendLayout();
            this.spcLeft.Panel2.SuspendLayout();
            this.spcLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft_Down)).BeginInit();
            this.spcLeft_Down.Panel1.SuspendLayout();
            this.spcLeft_Down.Panel2.SuspendLayout();
            this.spcLeft_Down.SuspendLayout();
            this.tabpageMain.SuspendLayout();
            this.tabpageProcessingTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessingTime)).BeginInit();
            this.tabpageSetupTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetupTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).BeginInit();
            this.spcRight.Panel1.SuspendLayout();
            this.spcRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRightTop)).BeginInit();
            this.spcRightTop.Panel1.SuspendLayout();
            this.spcRightTop.Panel2.SuspendLayout();
            this.spcRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GAEfficiencyChart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1131, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 24);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.spcLeft);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.spcRight);
            this.spcMain.Size = new System.Drawing.Size(1131, 641);
            this.spcMain.SplitterDistance = 279;
            this.spcMain.TabIndex = 1;
            // 
            // spcLeft
            // 
            this.spcLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLeft.Location = new System.Drawing.Point(0, 0);
            this.spcLeft.Name = "spcLeft";
            this.spcLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcLeft.Panel1
            // 
            this.spcLeft.Panel1.Controls.Add(this.labelFileName);
            this.spcLeft.Panel1.Controls.Add(this.labelNumberOfMachines);
            this.spcLeft.Panel1.Controls.Add(this.labelNumberOfJobs);
            // 
            // spcLeft.Panel2
            // 
            this.spcLeft.Panel2.Controls.Add(this.spcLeft_Down);
            this.spcLeft.Size = new System.Drawing.Size(279, 641);
            this.spcLeft.SplitterDistance = 80;
            this.spcLeft.TabIndex = 0;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelFileName.Location = new System.Drawing.Point(13, 9);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(80, 16);
            this.labelFileName.TabIndex = 3;
            this.labelFileName.Text = "File Name: ";
            // 
            // labelNumberOfMachines
            // 
            this.labelNumberOfMachines.AutoSize = true;
            this.labelNumberOfMachines.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelNumberOfMachines.Location = new System.Drawing.Point(13, 60);
            this.labelNumberOfMachines.Name = "labelNumberOfMachines";
            this.labelNumberOfMachines.Size = new System.Drawing.Size(148, 16);
            this.labelNumberOfMachines.TabIndex = 2;
            this.labelNumberOfMachines.Text = "Number of Machines: ";
            // 
            // labelNumberOfJobs
            // 
            this.labelNumberOfJobs.AutoSize = true;
            this.labelNumberOfJobs.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelNumberOfJobs.Location = new System.Drawing.Point(13, 34);
            this.labelNumberOfJobs.Name = "labelNumberOfJobs";
            this.labelNumberOfJobs.Size = new System.Drawing.Size(116, 16);
            this.labelNumberOfJobs.TabIndex = 1;
            this.labelNumberOfJobs.Text = "Number of Jobs: ";
            // 
            // spcLeft_Down
            // 
            this.spcLeft_Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcLeft_Down.Location = new System.Drawing.Point(0, 0);
            this.spcLeft_Down.Name = "spcLeft_Down";
            this.spcLeft_Down.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcLeft_Down.Panel1
            // 
            this.spcLeft_Down.Panel1.Controls.Add(this.thePropertyGrid);
            // 
            // spcLeft_Down.Panel2
            // 
            this.spcLeft_Down.Panel2.Controls.Add(this.tabpageMain);
            this.spcLeft_Down.Size = new System.Drawing.Size(279, 557);
            this.spcLeft_Down.SplitterDistance = 220;
            this.spcLeft_Down.TabIndex = 0;
            // 
            // thePropertyGrid
            // 
            this.thePropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thePropertyGrid.Location = new System.Drawing.Point(4, 3);
            this.thePropertyGrid.Name = "thePropertyGrid";
            this.thePropertyGrid.Size = new System.Drawing.Size(271, 214);
            this.thePropertyGrid.TabIndex = 0;
            // 
            // tabpageMain
            // 
            this.tabpageMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabpageMain.Controls.Add(this.tabpageProcessingTime);
            this.tabpageMain.Controls.Add(this.tabpageSetupTime);
            this.tabpageMain.Location = new System.Drawing.Point(3, 3);
            this.tabpageMain.Name = "tabpageMain";
            this.tabpageMain.SelectedIndex = 0;
            this.tabpageMain.Size = new System.Drawing.Size(272, 326);
            this.tabpageMain.TabIndex = 0;
            // 
            // tabpageProcessingTime
            // 
            this.tabpageProcessingTime.Controls.Add(this.dgvProcessingTime);
            this.tabpageProcessingTime.Controls.Add(this.labelProcessingTime);
            this.tabpageProcessingTime.Location = new System.Drawing.Point(4, 22);
            this.tabpageProcessingTime.Name = "tabpageProcessingTime";
            this.tabpageProcessingTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageProcessingTime.Size = new System.Drawing.Size(264, 300);
            this.tabpageProcessingTime.TabIndex = 0;
            this.tabpageProcessingTime.Text = "Processing Time";
            this.tabpageProcessingTime.UseVisualStyleBackColor = true;
            // 
            // dgvProcessingTime
            // 
            this.dgvProcessingTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProcessingTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcessingTime.Location = new System.Drawing.Point(6, 52);
            this.dgvProcessingTime.Name = "dgvProcessingTime";
            this.dgvProcessingTime.RowHeadersWidth = 51;
            this.dgvProcessingTime.RowTemplate.Height = 24;
            this.dgvProcessingTime.Size = new System.Drawing.Size(252, 241);
            this.dgvProcessingTime.TabIndex = 5;
            this.dgvProcessingTime.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProcessingTime_CellBeginEdit);
            this.dgvProcessingTime.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProcessingTime_CellValueChanged);
            // 
            // labelProcessingTime
            // 
            this.labelProcessingTime.AutoSize = true;
            this.labelProcessingTime.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelProcessingTime.Location = new System.Drawing.Point(6, 19);
            this.labelProcessingTime.Name = "labelProcessingTime";
            this.labelProcessingTime.Size = new System.Drawing.Size(119, 16);
            this.labelProcessingTime.TabIndex = 0;
            this.labelProcessingTime.Text = "Processing Time: ";
            // 
            // tabpageSetupTime
            // 
            this.tabpageSetupTime.Controls.Add(this.dgvSetupTime);
            this.tabpageSetupTime.Controls.Add(this.cbxSetupTimeMachine);
            this.tabpageSetupTime.Controls.Add(this.labelSetupTime);
            this.tabpageSetupTime.Location = new System.Drawing.Point(4, 22);
            this.tabpageSetupTime.Name = "tabpageSetupTime";
            this.tabpageSetupTime.Padding = new System.Windows.Forms.Padding(3);
            this.tabpageSetupTime.Size = new System.Drawing.Size(264, 300);
            this.tabpageSetupTime.TabIndex = 1;
            this.tabpageSetupTime.Text = "Setup Time";
            this.tabpageSetupTime.UseVisualStyleBackColor = true;
            // 
            // dgvSetupTime
            // 
            this.dgvSetupTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSetupTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetupTime.Location = new System.Drawing.Point(6, 52);
            this.dgvSetupTime.Name = "dgvSetupTime";
            this.dgvSetupTime.RowHeadersWidth = 51;
            this.dgvSetupTime.RowTemplate.Height = 24;
            this.dgvSetupTime.Size = new System.Drawing.Size(252, 241);
            this.dgvSetupTime.TabIndex = 4;
            this.dgvSetupTime.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSetupTime_CellBeginEdit);
            this.dgvSetupTime.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetupTime_CellValueChanged);
            // 
            // cbxSetupTimeMachine
            // 
            this.cbxSetupTimeMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSetupTimeMachine.Font = new System.Drawing.Font("新細明體", 12F);
            this.cbxSetupTimeMachine.FormattingEnabled = true;
            this.cbxSetupTimeMachine.Location = new System.Drawing.Point(6, 6);
            this.cbxSetupTimeMachine.Name = "cbxSetupTimeMachine";
            this.cbxSetupTimeMachine.Size = new System.Drawing.Size(121, 24);
            this.cbxSetupTimeMachine.TabIndex = 3;
            this.cbxSetupTimeMachine.SelectedIndexChanged += new System.EventHandler(this.cbxSetupTimeMachine_SelectedIndexChanged);
            // 
            // labelSetupTime
            // 
            this.labelSetupTime.AutoSize = true;
            this.labelSetupTime.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelSetupTime.Location = new System.Drawing.Point(6, 33);
            this.labelSetupTime.Name = "labelSetupTime";
            this.labelSetupTime.Size = new System.Drawing.Size(87, 16);
            this.labelSetupTime.TabIndex = 2;
            this.labelSetupTime.Text = "Setup Time: ";
            // 
            // spcRight
            // 
            this.spcRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRight.Location = new System.Drawing.Point(0, 0);
            this.spcRight.Name = "spcRight";
            this.spcRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcRight.Panel1
            // 
            this.spcRight.Panel1.Controls.Add(this.spcRightTop);
            // 
            // spcRight.Panel2
            // 
            this.spcRight.Panel2.BackColor = System.Drawing.SystemColors.Info;
            this.spcRight.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.spcRight_Panel2_Paint);
            this.spcRight.Size = new System.Drawing.Size(848, 641);
            this.spcRight.SplitterDistance = 335;
            this.spcRight.TabIndex = 0;
            // 
            // spcRightTop
            // 
            this.spcRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcRightTop.Location = new System.Drawing.Point(0, 0);
            this.spcRightTop.Name = "spcRightTop";
            // 
            // spcRightTop.Panel1
            // 
            this.spcRightTop.Panel1.Controls.Add(this.btnCreateGASolver);
            this.spcRightTop.Panel1.Controls.Add(this.rtbBestChromosome);
            this.spcRightTop.Panel1.Controls.Add(this.labelBestChromosome);
            this.spcRightTop.Panel1.Controls.Add(this.tbBestObjectiveValue);
            this.spcRightTop.Panel1.Controls.Add(this.labelBestObjectiveValue);
            this.spcRightTop.Panel1.Controls.Add(this.btnReset);
            this.spcRightTop.Panel1.Controls.Add(this.btnRunToEnd);
            this.spcRightTop.Panel1.Controls.Add(this.btnRunOneIteration);
            // 
            // spcRightTop.Panel2
            // 
            this.spcRightTop.Panel2.Controls.Add(this.theProgressBar);
            this.spcRightTop.Panel2.Controls.Add(this.GAEfficiencyChart);
            this.spcRightTop.Size = new System.Drawing.Size(848, 335);
            this.spcRightTop.SplitterDistance = 198;
            this.spcRightTop.TabIndex = 0;
            // 
            // btnCreateGASolver
            // 
            this.btnCreateGASolver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateGASolver.Enabled = false;
            this.btnCreateGASolver.Location = new System.Drawing.Point(3, 7);
            this.btnCreateGASolver.Name = "btnCreateGASolver";
            this.btnCreateGASolver.Size = new System.Drawing.Size(192, 23);
            this.btnCreateGASolver.TabIndex = 10;
            this.btnCreateGASolver.Text = "Create GA Solver";
            this.btnCreateGASolver.UseVisualStyleBackColor = true;
            this.btnCreateGASolver.Click += new System.EventHandler(this.btnCreateGASolver_Click);
            // 
            // rtbBestChromosome
            // 
            this.rtbBestChromosome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBestChromosome.Location = new System.Drawing.Point(6, 186);
            this.rtbBestChromosome.Name = "rtbBestChromosome";
            this.rtbBestChromosome.ReadOnly = true;
            this.rtbBestChromosome.Size = new System.Drawing.Size(188, 146);
            this.rtbBestChromosome.TabIndex = 9;
            this.rtbBestChromosome.Text = "";
            // 
            // labelBestChromosome
            // 
            this.labelBestChromosome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBestChromosome.AutoSize = true;
            this.labelBestChromosome.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelBestChromosome.Location = new System.Drawing.Point(3, 167);
            this.labelBestChromosome.Name = "labelBestChromosome";
            this.labelBestChromosome.Size = new System.Drawing.Size(131, 16);
            this.labelBestChromosome.TabIndex = 8;
            this.labelBestChromosome.Text = "Best Chromosome: ";
            // 
            // tbBestObjectiveValue
            // 
            this.tbBestObjectiveValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBestObjectiveValue.Location = new System.Drawing.Point(6, 142);
            this.tbBestObjectiveValue.Name = "tbBestObjectiveValue";
            this.tbBestObjectiveValue.ReadOnly = true;
            this.tbBestObjectiveValue.Size = new System.Drawing.Size(188, 22);
            this.tbBestObjectiveValue.TabIndex = 7;
            // 
            // labelBestObjectiveValue
            // 
            this.labelBestObjectiveValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBestObjectiveValue.AutoSize = true;
            this.labelBestObjectiveValue.Font = new System.Drawing.Font("新細明體", 12F);
            this.labelBestObjectiveValue.Location = new System.Drawing.Point(3, 120);
            this.labelBestObjectiveValue.Name = "labelBestObjectiveValue";
            this.labelBestObjectiveValue.Size = new System.Drawing.Size(148, 16);
            this.labelBestObjectiveValue.TabIndex = 4;
            this.labelBestObjectiveValue.Text = "Best Objective Value: ";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(3, 36);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(192, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRunToEnd
            // 
            this.btnRunToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunToEnd.Enabled = false;
            this.btnRunToEnd.Location = new System.Drawing.Point(3, 94);
            this.btnRunToEnd.Name = "btnRunToEnd";
            this.btnRunToEnd.Size = new System.Drawing.Size(192, 23);
            this.btnRunToEnd.TabIndex = 6;
            this.btnRunToEnd.Text = "Run To End";
            this.btnRunToEnd.UseVisualStyleBackColor = true;
            this.btnRunToEnd.Click += new System.EventHandler(this.btnRunToEnd_Click);
            // 
            // btnRunOneIteration
            // 
            this.btnRunOneIteration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunOneIteration.Enabled = false;
            this.btnRunOneIteration.Location = new System.Drawing.Point(3, 65);
            this.btnRunOneIteration.Name = "btnRunOneIteration";
            this.btnRunOneIteration.Size = new System.Drawing.Size(192, 23);
            this.btnRunOneIteration.TabIndex = 5;
            this.btnRunOneIteration.Text = "Run One Iteration";
            this.btnRunOneIteration.UseVisualStyleBackColor = true;
            this.btnRunOneIteration.Click += new System.EventHandler(this.btnRunOneIteration_Click);
            // 
            // theProgressBar
            // 
            this.theProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.theProgressBar.Location = new System.Drawing.Point(3, 307);
            this.theProgressBar.Name = "theProgressBar";
            this.theProgressBar.Size = new System.Drawing.Size(638, 23);
            this.theProgressBar.TabIndex = 1;
            // 
            // GAEfficiencyChart
            // 
            this.GAEfficiencyChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea18.Name = "theLineChartArea";
            this.GAEfficiencyChart.ChartAreas.Add(chartArea18);
            legend18.Name = "Legend1";
            this.GAEfficiencyChart.Legends.Add(legend18);
            this.GAEfficiencyChart.Location = new System.Drawing.Point(3, 3);
            this.GAEfficiencyChart.Name = "GAEfficiencyChart";
            series35.ChartArea = "theLineChartArea";
            series35.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series35.Legend = "Legend1";
            series35.Name = "Iteration Average";
            series36.ChartArea = "theLineChartArea";
            series36.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series36.Legend = "Legend1";
            series36.Name = "So Far The Best";
            this.GAEfficiencyChart.Series.Add(series35);
            this.GAEfficiencyChart.Series.Add(series36);
            this.GAEfficiencyChart.Size = new System.Drawing.Size(638, 298);
            this.GAEfficiencyChart.TabIndex = 0;
            this.GAEfficiencyChart.Text = "chart1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 665);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "r09546021 Final Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcLeft.Panel1.ResumeLayout(false);
            this.spcLeft.Panel1.PerformLayout();
            this.spcLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft)).EndInit();
            this.spcLeft.ResumeLayout(false);
            this.spcLeft_Down.Panel1.ResumeLayout(false);
            this.spcLeft_Down.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcLeft_Down)).EndInit();
            this.spcLeft_Down.ResumeLayout(false);
            this.tabpageMain.ResumeLayout(false);
            this.tabpageProcessingTime.ResumeLayout(false);
            this.tabpageProcessingTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcessingTime)).EndInit();
            this.tabpageSetupTime.ResumeLayout(false);
            this.tabpageSetupTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetupTime)).EndInit();
            this.spcRight.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRight)).EndInit();
            this.spcRight.ResumeLayout(false);
            this.spcRightTop.Panel1.ResumeLayout(false);
            this.spcRightTop.Panel1.PerformLayout();
            this.spcRightTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRightTop)).EndInit();
            this.spcRightTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GAEfficiencyChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.SplitContainer spcLeft;
        private System.Windows.Forms.SplitContainer spcLeft_Down;
        private System.Windows.Forms.SplitContainer spcRight;
        private System.Windows.Forms.PropertyGrid thePropertyGrid;
        private System.Windows.Forms.TabControl tabpageMain;
        private System.Windows.Forms.TabPage tabpageProcessingTime;
        private System.Windows.Forms.Label labelProcessingTime;
        private System.Windows.Forms.TabPage tabpageSetupTime;
        private System.Windows.Forms.ComboBox cbxSetupTimeMachine;
        private System.Windows.Forms.Label labelSetupTime;
        private System.Windows.Forms.DataGridView dgvProcessingTime;
        private System.Windows.Forms.DataGridView dgvSetupTime;
        private System.Windows.Forms.Label labelNumberOfMachines;
        private System.Windows.Forms.Label labelNumberOfJobs;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.SplitContainer spcRightTop;
        private System.Windows.Forms.Button btnRunToEnd;
        private System.Windows.Forms.Button btnRunOneIteration;
        private System.Windows.Forms.DataVisualization.Charting.Chart GAEfficiencyChart;
        private System.Windows.Forms.RichTextBox rtbBestChromosome;
        private System.Windows.Forms.Label labelBestChromosome;
        private System.Windows.Forms.TextBox tbBestObjectiveValue;
        private System.Windows.Forms.Label labelBestObjectiveValue;
        private System.Windows.Forms.Button btnCreateGASolver;
        private System.Windows.Forms.ProgressBar theProgressBar;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

