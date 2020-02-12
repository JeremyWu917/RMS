namespace RMS
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnBilling = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.lblTablesType_TName = new System.Windows.Forms.Label();
            this.lblTablesAllInfos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurrentTables_Per = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblStopTablesInfos = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBookTableNumer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSpareTables_Number = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUseTable_Number = new System.Windows.Forms.Label();
            this.lblTablesCount = new System.Windows.Forms.Label();
            this.lblCostsMoney1 = new System.Windows.Forms.Label();
            this.lblCostsMoney = new System.Windows.Forms.Label();
            this.lblUserTime = new System.Windows.Forms.Label();
            this.lblCostsTime = new System.Windows.Forms.Label();
            this.lblMealTime1 = new System.Windows.Forms.Label();
            this.lblMealTime = new System.Windows.Forms.Label();
            this.lblListMoney = new System.Windows.Forms.Label();
            this.lblTables_LittleMoney = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabC = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddMoney = new System.Windows.Forms.Button();
            this.btnBalance = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnRoom = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 112);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnBilling
            // 
            this.btnBilling.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBilling.BackgroundImage")));
            this.btnBilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBilling.Location = new System.Drawing.Point(122, 12);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(83, 81);
            this.btnBilling.TabIndex = 1;
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 112);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            this.splitContainer1.Panel1.Controls.Add(this.lbTime);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(936, 566);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabStatus);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 26);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(177, 540);
            this.tabControl2.TabIndex = 1;
            // 
            // tabStatus
            // 
            this.tabStatus.Controls.Add(this.lblTablesType_TName);
            this.tabStatus.Controls.Add(this.lblTablesAllInfos);
            this.tabStatus.Controls.Add(this.label8);
            this.tabStatus.Controls.Add(this.lblServer);
            this.tabStatus.Controls.Add(this.label1);
            this.tabStatus.Controls.Add(this.label7);
            this.tabStatus.Controls.Add(this.lblCurrentTables_Per);
            this.tabStatus.Controls.Add(this.label6);
            this.tabStatus.Controls.Add(this.lblStopTablesInfos);
            this.tabStatus.Controls.Add(this.label5);
            this.tabStatus.Controls.Add(this.label4);
            this.tabStatus.Controls.Add(this.lblBookTableNumer);
            this.tabStatus.Controls.Add(this.label3);
            this.tabStatus.Controls.Add(this.lblSpareTables_Number);
            this.tabStatus.Controls.Add(this.label2);
            this.tabStatus.Controls.Add(this.lblUseTable_Number);
            this.tabStatus.Controls.Add(this.lblTablesCount);
            this.tabStatus.Controls.Add(this.lblCostsMoney1);
            this.tabStatus.Controls.Add(this.lblCostsMoney);
            this.tabStatus.Controls.Add(this.lblUserTime);
            this.tabStatus.Controls.Add(this.lblCostsTime);
            this.tabStatus.Controls.Add(this.lblMealTime1);
            this.tabStatus.Controls.Add(this.lblMealTime);
            this.tabStatus.Controls.Add(this.lblListMoney);
            this.tabStatus.Controls.Add(this.lblTables_LittleMoney);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(169, 514);
            this.tabStatus.TabIndex = 1;
            this.tabStatus.Text = "状态";
            this.tabStatus.UseVisualStyleBackColor = true;
            // 
            // lblTablesType_TName
            // 
            this.lblTablesType_TName.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTablesType_TName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTablesType_TName.Location = new System.Drawing.Point(3, 3);
            this.lblTablesType_TName.Name = "lblTablesType_TName";
            this.lblTablesType_TName.Size = new System.Drawing.Size(172, 23);
            this.lblTablesType_TName.TabIndex = 27;
            this.lblTablesType_TName.Text = "大厅";
            this.lblTablesType_TName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTablesAllInfos
            // 
            this.lblTablesAllInfos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTablesAllInfos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTablesAllInfos.Location = new System.Drawing.Point(3, 173);
            this.lblTablesAllInfos.Name = "lblTablesAllInfos";
            this.lblTablesAllInfos.Size = new System.Drawing.Size(172, 23);
            this.lblTablesAllInfos.TabIndex = 28;
            this.lblTablesAllInfos.Text = "餐台总状态";
            this.lblTablesAllInfos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 26;
            this.label8.Text = "当前维修：";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(82, 343);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(53, 12);
            this.lblServer.TabIndex = 25;
            this.lblServer.Text = "当前维修";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Font = new System.Drawing.Font("华文行楷", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-1, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 73);
            this.label1.TabIndex = 23;
            this.label1.Text = "小吴工作室";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 22;
            this.label7.Text = "上座率：";
            // 
            // lblCurrentTables_Per
            // 
            this.lblCurrentTables_Per.AutoSize = true;
            this.lblCurrentTables_Per.Location = new System.Drawing.Point(82, 410);
            this.lblCurrentTables_Per.Name = "lblCurrentTables_Per";
            this.lblCurrentTables_Per.Size = new System.Drawing.Size(53, 12);
            this.lblCurrentTables_Per.TabIndex = 21;
            this.lblCurrentTables_Per.Text = "上座率：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "当前停用：";
            // 
            // lblStopTablesInfos
            // 
            this.lblStopTablesInfos.AutoSize = true;
            this.lblStopTablesInfos.Location = new System.Drawing.Point(82, 374);
            this.lblStopTablesInfos.Name = "lblStopTablesInfos";
            this.lblStopTablesInfos.Size = new System.Drawing.Size(65, 12);
            this.lblStopTablesInfos.TabIndex = 19;
            this.lblStopTablesInfos.Text = "当前停用：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "当前预定：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "当前可供：";
            // 
            // lblBookTableNumer
            // 
            this.lblBookTableNumer.AutoSize = true;
            this.lblBookTableNumer.Location = new System.Drawing.Point(82, 312);
            this.lblBookTableNumer.Name = "lblBookTableNumer";
            this.lblBookTableNumer.Size = new System.Drawing.Size(65, 12);
            this.lblBookTableNumer.TabIndex = 16;
            this.lblBookTableNumer.Text = "当前预定：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "当前占用：";
            // 
            // lblSpareTables_Number
            // 
            this.lblSpareTables_Number.AutoSize = true;
            this.lblSpareTables_Number.Location = new System.Drawing.Point(82, 281);
            this.lblSpareTables_Number.Name = "lblSpareTables_Number";
            this.lblSpareTables_Number.Size = new System.Drawing.Size(65, 12);
            this.lblSpareTables_Number.TabIndex = 4;
            this.lblSpareTables_Number.Text = "当前可供：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "餐台总数：";
            // 
            // lblUseTable_Number
            // 
            this.lblUseTable_Number.AutoSize = true;
            this.lblUseTable_Number.Location = new System.Drawing.Point(82, 250);
            this.lblUseTable_Number.Name = "lblUseTable_Number";
            this.lblUseTable_Number.Size = new System.Drawing.Size(53, 12);
            this.lblUseTable_Number.TabIndex = 12;
            this.lblUseTable_Number.Text = "当前占用";
            // 
            // lblTablesCount
            // 
            this.lblTablesCount.AutoSize = true;
            this.lblTablesCount.Location = new System.Drawing.Point(82, 219);
            this.lblTablesCount.Name = "lblTablesCount";
            this.lblTablesCount.Size = new System.Drawing.Size(65, 12);
            this.lblTablesCount.TabIndex = 11;
            this.lblTablesCount.Text = "餐台总数：";
            // 
            // lblCostsMoney1
            // 
            this.lblCostsMoney1.AutoSize = true;
            this.lblCostsMoney1.Location = new System.Drawing.Point(82, 134);
            this.lblCostsMoney1.Name = "lblCostsMoney1";
            this.lblCostsMoney1.Size = new System.Drawing.Size(65, 12);
            this.lblCostsMoney1.TabIndex = 10;
            this.lblCostsMoney1.Text = "消费金额：";
            // 
            // lblCostsMoney
            // 
            this.lblCostsMoney.AutoSize = true;
            this.lblCostsMoney.Location = new System.Drawing.Point(8, 137);
            this.lblCostsMoney.Name = "lblCostsMoney";
            this.lblCostsMoney.Size = new System.Drawing.Size(65, 12);
            this.lblCostsMoney.TabIndex = 9;
            this.lblCostsMoney.Text = "消费金额：";
            // 
            // lblUserTime
            // 
            this.lblUserTime.AutoSize = true;
            this.lblUserTime.Location = new System.Drawing.Point(82, 103);
            this.lblUserTime.Name = "lblUserTime";
            this.lblUserTime.Size = new System.Drawing.Size(65, 12);
            this.lblUserTime.TabIndex = 8;
            this.lblUserTime.Text = "已用时间：";
            // 
            // lblCostsTime
            // 
            this.lblCostsTime.AutoSize = true;
            this.lblCostsTime.Location = new System.Drawing.Point(8, 105);
            this.lblCostsTime.Name = "lblCostsTime";
            this.lblCostsTime.Size = new System.Drawing.Size(65, 12);
            this.lblCostsTime.TabIndex = 7;
            this.lblCostsTime.Text = "已用时间：";
            // 
            // lblMealTime1
            // 
            this.lblMealTime1.AutoSize = true;
            this.lblMealTime1.Location = new System.Drawing.Point(82, 71);
            this.lblMealTime1.Name = "lblMealTime1";
            this.lblMealTime1.Size = new System.Drawing.Size(65, 12);
            this.lblMealTime1.TabIndex = 6;
            this.lblMealTime1.Text = "进店时间：";
            // 
            // lblMealTime
            // 
            this.lblMealTime.AutoSize = true;
            this.lblMealTime.Location = new System.Drawing.Point(8, 73);
            this.lblMealTime.Name = "lblMealTime";
            this.lblMealTime.Size = new System.Drawing.Size(65, 12);
            this.lblMealTime.TabIndex = 5;
            this.lblMealTime.Text = "进店时间：";
            // 
            // lblListMoney
            // 
            this.lblListMoney.AutoSize = true;
            this.lblListMoney.Location = new System.Drawing.Point(82, 39);
            this.lblListMoney.Name = "lblListMoney";
            this.lblListMoney.Size = new System.Drawing.Size(11, 12);
            this.lblListMoney.TabIndex = 14;
            this.lblListMoney.Text = "0";
            // 
            // lblTables_LittleMoney
            // 
            this.lblTables_LittleMoney.AutoSize = true;
            this.lblTables_LittleMoney.Location = new System.Drawing.Point(8, 41);
            this.lblTables_LittleMoney.Name = "lblTables_LittleMoney";
            this.lblTables_LittleMoney.Size = new System.Drawing.Size(65, 12);
            this.lblTables_LittleMoney.TabIndex = 15;
            this.lblTables_LittleMoney.Text = "最低消费：";
            // 
            // lbTime
            // 
            this.lbTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTime.Location = new System.Drawing.Point(0, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(177, 26);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "当前时间";
            this.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabC);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(755, 566);
            this.splitContainer2.SplitterDistance = 381;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabC
            // 
            this.tabC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabC.Location = new System.Drawing.Point(0, 0);
            this.tabC.Name = "tabC";
            this.tabC.SelectedIndex = 0;
            this.tabC.Size = new System.Drawing.Size(755, 381);
            this.tabC.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(755, 181);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAddMoney
            // 
            this.btnAddMoney.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddMoney.BackgroundImage")));
            this.btnAddMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddMoney.Location = new System.Drawing.Point(245, 12);
            this.btnAddMoney.Name = "btnAddMoney";
            this.btnAddMoney.Size = new System.Drawing.Size(83, 81);
            this.btnAddMoney.TabIndex = 3;
            this.btnAddMoney.UseVisualStyleBackColor = true;
            this.btnAddMoney.Click += new System.EventHandler(this.btnAddMoney_Click);
            // 
            // btnBalance
            // 
            this.btnBalance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBalance.BackgroundImage")));
            this.btnBalance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBalance.Location = new System.Drawing.Point(368, 12);
            this.btnBalance.Name = "btnBalance";
            this.btnBalance.Size = new System.Drawing.Size(83, 81);
            this.btnBalance.TabIndex = 4;
            this.btnBalance.UseVisualStyleBackColor = true;
            this.btnBalance.Click += new System.EventHandler(this.btnBalance_Click);
            // 
            // btnMember
            // 
            this.btnMember.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMember.BackgroundImage")));
            this.btnMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMember.Location = new System.Drawing.Point(491, 12);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(83, 81);
            this.btnMember.TabIndex = 5;
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnProduct.BackgroundImage")));
            this.btnProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProduct.Location = new System.Drawing.Point(614, 12);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(83, 81);
            this.btnProduct.TabIndex = 6;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRoom.BackgroundImage")));
            this.btnRoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRoom.Location = new System.Drawing.Point(737, 12);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(83, 81);
            this.btnRoom.TabIndex = 7;
            this.btnRoom.UseVisualStyleBackColor = true;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "空闲.png");
            this.imageList1.Images.SetKeyName(1, "就餐.png");
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 678);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnRoom);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnMember);
            this.Controls.Add(this.btnBalance);
            this.Controls.Add(this.btnAddMoney);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "餐饮管理系统 Version 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabStatus.ResumeLayout(false);
            this.tabStatus.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnAddMoney;
        private System.Windows.Forms.Button btnBalance;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.TabControl tabC;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabStatus;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lblTablesType_TName;
        private System.Windows.Forms.Label lblTablesAllInfos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCurrentTables_Per;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStopTablesInfos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBookTableNumer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSpareTables_Number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUseTable_Number;
        private System.Windows.Forms.Label lblTablesCount;
        private System.Windows.Forms.Label lblCostsMoney1;
        private System.Windows.Forms.Label lblCostsMoney;
        private System.Windows.Forms.Label lblUserTime;
        private System.Windows.Forms.Label lblCostsTime;
        private System.Windows.Forms.Label lblMealTime1;
        private System.Windows.Forms.Label lblMealTime;
        private System.Windows.Forms.Label lblListMoney;
        private System.Windows.Forms.Label lblTables_LittleMoney;
        private System.Windows.Forms.ImageList imageList1;
    }
}