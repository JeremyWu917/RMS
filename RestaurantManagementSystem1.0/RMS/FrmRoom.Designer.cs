﻿namespace RMS
{
    partial class FrmRoom
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
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpdateDesk = new System.Windows.Forms.Button();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddDesk = new System.Windows.Forms.Button();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDeskInfo = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvRoomInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeskInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "IsDefault";
            this.Column5.HeaderText = "默认编号";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btnUpdateDesk
            // 
            this.btnUpdateDesk.Location = new System.Drawing.Point(422, 271);
            this.btnUpdateDesk.Name = "btnUpdateDesk";
            this.btnUpdateDesk.Size = new System.Drawing.Size(90, 23);
            this.btnUpdateDesk.TabIndex = 39;
            this.btnUpdateDesk.Text = "修改餐桌";
            this.btnUpdateDesk.UseVisualStyleBackColor = true;
            this.btnUpdateDesk.Click += new System.EventHandler(this.btnUpdateDesk_Click);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "RoomType";
            this.Column6.HeaderText = "房间类型";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DeskRegion";
            this.Column8.HeaderText = "餐桌描述";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "DeskName";
            this.Column7.HeaderText = "餐桌编号";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DeskId";
            this.dataGridViewTextBoxColumn1.HeaderText = "餐桌id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "DeskRemark";
            this.Column12.HeaderText = "餐桌备注";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // btnAddDesk
            // 
            this.btnAddDesk.Location = new System.Drawing.Point(422, 226);
            this.btnAddDesk.Name = "btnAddDesk";
            this.btnAddDesk.Size = new System.Drawing.Size(90, 23);
            this.btnAddDesk.TabIndex = 38;
            this.btnAddDesk.Text = "添加餐桌";
            this.btnAddDesk.UseVisualStyleBackColor = true;
            this.btnAddDesk.Click += new System.EventHandler(this.btnAddDesk_Click);
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "RoomId";
            this.Column11.HeaderText = "房间类型";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // dgvDeskInfo
            // 
            this.dgvDeskInfo.AllowUserToAddRows = false;
            this.dgvDeskInfo.AllowUserToDeleteRows = false;
            this.dgvDeskInfo.BackgroundColor = System.Drawing.Color.MediumSeaGreen;
            this.dgvDeskInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeskInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column12,
            this.Column11});
            this.dgvDeskInfo.Location = new System.Drawing.Point(12, 216);
            this.dgvDeskInfo.Name = "dgvDeskInfo";
            this.dgvDeskInfo.ReadOnly = true;
            this.dgvDeskInfo.RowHeadersVisible = false;
            this.dgvDeskInfo.RowTemplate.Height = 23;
            this.dgvDeskInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeskInfo.Size = new System.Drawing.Size(404, 150);
            this.dgvDeskInfo.TabIndex = 36;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "DeskStateString";
            this.Column9.HeaderText = "餐桌状态";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(422, 33);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(90, 23);
            this.btnAddRoom.TabIndex = 35;
            this.btnAddRoom.Text = "增加房间";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RoomMaxConsumer";
            this.Column4.HeaderText = "房间人数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RoomMinimunConsume";
            this.Column3.HeaderText = "房间最低消费";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RoomName";
            this.Column2.HeaderText = "房间的名字";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RoomId";
            this.Column1.HeaderText = "房间的id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(422, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "删除餐桌";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(422, 137);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteRoom.TabIndex = 34;
            this.btnDeleteRoom.Text = "删除房间";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "修改房间";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvRoomInfo
            // 
            this.dgvRoomInfo.AllowUserToAddRows = false;
            this.dgvRoomInfo.AllowUserToDeleteRows = false;
            this.dgvRoomInfo.BackgroundColor = System.Drawing.Color.MediumAquamarine;
            this.dgvRoomInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvRoomInfo.Location = new System.Drawing.Point(12, 10);
            this.dgvRoomInfo.Name = "dgvRoomInfo";
            this.dgvRoomInfo.ReadOnly = true;
            this.dgvRoomInfo.RowHeadersVisible = false;
            this.dgvRoomInfo.RowTemplate.Height = 23;
            this.dgvRoomInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomInfo.Size = new System.Drawing.Size(404, 180);
            this.dgvRoomInfo.TabIndex = 32;
            // 
            // FrmRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SpringGreen;
            this.ClientSize = new System.Drawing.Size(520, 372);
            this.Controls.Add(this.btnUpdateDesk);
            this.Controls.Add(this.btnAddDesk);
            this.Controls.Add(this.dgvDeskInfo);
            this.Controls.Add(this.btnAddRoom);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDeleteRoom);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dgvRoomInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "房间/餐桌设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRoom_FormClosed);
            this.Load += new System.EventHandler(this.FrmRoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeskInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button btnUpdateDesk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Button btnAddDesk;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridView dgvDeskInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvRoomInfo;
    }
}