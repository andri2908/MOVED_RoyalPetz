namespace RoyalPetz_ADMIN
{
    partial class groupAccessModuleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.namaGroupTextBox = new System.Windows.Forms.TextBox();
            this.deskripsiTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupAccessDataGridView = new System.Windows.Forms.DataGridView();
            this.moduleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hakAkses = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.moduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newGroupButton = new System.Windows.Forms.Button();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAccessDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.0597F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.9403F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.namaGroupTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.deskripsiTextBox, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 83);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "NAMA GROUP";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "DESKRIPSI";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(172, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(172, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = ":";
            // 
            // namaGroupTextBox
            // 
            this.namaGroupTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.namaGroupTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaGroupTextBox.Location = new System.Drawing.Point(195, 8);
            this.namaGroupTextBox.Name = "namaGroupTextBox";
            this.namaGroupTextBox.ReadOnly = true;
            this.namaGroupTextBox.Size = new System.Drawing.Size(346, 27);
            this.namaGroupTextBox.TabIndex = 16;
            // 
            // deskripsiTextBox
            // 
            this.deskripsiTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.deskripsiTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deskripsiTextBox.Location = new System.Drawing.Point(195, 49);
            this.deskripsiTextBox.Name = "deskripsiTextBox";
            this.deskripsiTextBox.ReadOnly = true;
            this.deskripsiTextBox.Size = new System.Drawing.Size(346, 27);
            this.deskripsiTextBox.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 29);
            this.panel1.TabIndex = 23;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(130, 136);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 37);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupAccessDataGridView
            // 
            this.groupAccessDataGridView.AllowUserToAddRows = false;
            this.groupAccessDataGridView.AllowUserToDeleteRows = false;
            this.groupAccessDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.groupAccessDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.groupAccessDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupAccessDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.moduleName,
            this.hakAkses,
            this.moduleID,
            this.featureID});
            this.groupAccessDataGridView.Location = new System.Drawing.Point(1, 184);
            this.groupAccessDataGridView.Name = "groupAccessDataGridView";
            this.groupAccessDataGridView.RowHeadersVisible = false;
            this.groupAccessDataGridView.Size = new System.Drawing.Size(569, 477);
            this.groupAccessDataGridView.TabIndex = 29;
            // 
            // moduleName
            // 
            this.moduleName.HeaderText = "MODULE";
            this.moduleName.Name = "moduleName";
            this.moduleName.ReadOnly = true;
            this.moduleName.Width = 350;
            // 
            // hakAkses
            // 
            this.hakAkses.HeaderText = "HAK AKSES";
            this.hakAkses.Name = "hakAkses";
            this.hakAkses.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hakAkses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hakAkses.Width = 150;
            // 
            // moduleID
            // 
            this.moduleID.HeaderText = "moduleID";
            this.moduleID.Name = "moduleID";
            this.moduleID.Visible = false;
            // 
            // featureID
            // 
            this.featureID.HeaderText = "featureID";
            this.featureID.Name = "featureID";
            this.featureID.Visible = false;
            // 
            // newGroupButton
            // 
            this.newGroupButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.newGroupButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGroupButton.Location = new System.Drawing.Point(231, 136);
            this.newGroupButton.Name = "newGroupButton";
            this.newGroupButton.Size = new System.Drawing.Size(151, 37);
            this.newGroupButton.TabIndex = 30;
            this.newGroupButton.Text = "NEW GROUP";
            this.newGroupButton.UseVisualStyleBackColor = true;
            this.newGroupButton.Click += new System.EventHandler(this.newGroupButton_Click);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(478, 156);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(71, 17);
            this.checkAll.TabIndex = 31;
            this.checkAll.Text = "Check All";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // groupAccessModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(570, 661);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.newGroupButton);
            this.Controls.Add(this.groupAccessDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "groupAccessModuleForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PENGATURAN GROUP AKSES";
            this.Activated += new System.EventHandler(this.groupAccessModuleForm_Activated);
            this.Load += new System.EventHandler(this.groupAccessModuleForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAccessDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox namaGroupTextBox;
        private System.Windows.Forms.TextBox deskripsiTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView groupAccessDataGridView;
        private System.Windows.Forms.Button newGroupButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hakAkses;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureID;
        private System.Windows.Forms.CheckBox checkAll;
    }
}