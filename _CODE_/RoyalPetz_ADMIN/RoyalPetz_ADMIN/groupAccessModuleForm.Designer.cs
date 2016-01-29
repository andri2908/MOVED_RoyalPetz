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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupAccessDataGridView = new System.Windows.Forms.DataGridView();
            this.newGroupButton = new System.Windows.Forms.Button();
            this.moduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hakAkses = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 347F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox3, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 119);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "KODE GROUP";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 47);
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
            this.label1.Location = new System.Drawing.Point(3, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "DESKRIPSI";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(179, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = ":";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(179, 47);
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
            this.label7.Location = new System.Drawing.Point(179, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = ":";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(202, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(93, 27);
            this.textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(202, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(340, 27);
            this.textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(202, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(210, 27);
            this.textBox3.TabIndex = 17;
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
            this.saveButton.Location = new System.Drawing.Point(158, 173);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 37);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // groupAccessDataGridView
            // 
            this.groupAccessDataGridView.AllowUserToAddRows = false;
            this.groupAccessDataGridView.AllowUserToDeleteRows = false;
            this.groupAccessDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.groupAccessDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.groupAccessDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupAccessDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.moduleID,
            this.hakAkses});
            this.groupAccessDataGridView.Location = new System.Drawing.Point(1, 227);
            this.groupAccessDataGridView.Name = "groupAccessDataGridView";
            this.groupAccessDataGridView.RowHeadersVisible = false;
            this.groupAccessDataGridView.Size = new System.Drawing.Size(569, 529);
            this.groupAccessDataGridView.TabIndex = 29;
            // 
            // newGroupButton
            // 
            this.newGroupButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.newGroupButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newGroupButton.Location = new System.Drawing.Point(296, 173);
            this.newGroupButton.Name = "newGroupButton";
            this.newGroupButton.Size = new System.Drawing.Size(151, 37);
            this.newGroupButton.TabIndex = 30;
            this.newGroupButton.Text = "NEW GROUP";
            this.newGroupButton.UseVisualStyleBackColor = true;
            this.newGroupButton.Click += new System.EventHandler(this.newGroupButton_Click);
            // 
            // moduleID
            // 
            this.moduleID.HeaderText = "MODULE";
            this.moduleID.Name = "moduleID";
            this.moduleID.ReadOnly = true;
            this.moduleID.Width = 350;
            // 
            // hakAkses
            // 
            this.hakAkses.HeaderText = "HAK AKSES";
            this.hakAkses.Name = "hakAkses";
            this.hakAkses.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hakAkses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hakAkses.Width = 150;
            // 
            // groupAccessModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(570, 757);
            this.Controls.Add(this.newGroupButton);
            this.Controls.Add(this.groupAccessDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "groupAccessModuleForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PENGATURAN GROUP AKSES";
            this.Load += new System.EventHandler(this.groupAccessModuleForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAccessDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView groupAccessDataGridView;
        private System.Windows.Forms.Button newGroupButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hakAkses;
    }
}