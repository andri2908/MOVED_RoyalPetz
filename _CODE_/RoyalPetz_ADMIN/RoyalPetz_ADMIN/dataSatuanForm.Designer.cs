namespace RoyalPetz_ADMIN
{
    partial class dataSatuanForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.namaSupplierTextbox = new System.Windows.Forms.TextBox();
            this.dataSalesDataGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.displayButton = new System.Windows.Forms.Button();
            this.kodeSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaSatuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSalesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nama";
            // 
            // namaSupplierTextbox
            // 
            this.namaSupplierTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaSupplierTextbox.Location = new System.Drawing.Point(85, 21);
            this.namaSupplierTextbox.Name = "namaSupplierTextbox";
            this.namaSupplierTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaSupplierTextbox.TabIndex = 31;
            // 
            // dataSalesDataGridView
            // 
            this.dataSalesDataGridView.AllowUserToAddRows = false;
            this.dataSalesDataGridView.AllowUserToDeleteRows = false;
            this.dataSalesDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataSalesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataSalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSalesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodeSatuan,
            this.namaSatuan});
            this.dataSalesDataGridView.Location = new System.Drawing.Point(0, 67);
            this.dataSalesDataGridView.Name = "dataSalesDataGridView";
            this.dataSalesDataGridView.RowHeadersVisible = false;
            this.dataSalesDataGridView.Size = new System.Drawing.Size(602, 480);
            this.dataSalesDataGridView.TabIndex = 28;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(491, 15);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 32;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(360, 16);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 29;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            // 
            // kodeSatuan
            // 
            this.kodeSatuan.HeaderText = "KODE SATUAN";
            this.kodeSatuan.Name = "kodeSatuan";
            this.kodeSatuan.ReadOnly = true;
            this.kodeSatuan.Width = 200;
            // 
            // namaSatuan
            // 
            this.namaSatuan.HeaderText = "NAMA SATUAN";
            this.namaSatuan.Name = "namaSatuan";
            this.namaSatuan.ReadOnly = true;
            this.namaSatuan.Width = 350;
            // 
            // dataSatuanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaSupplierTextbox);
            this.Controls.Add(this.dataSalesDataGridView);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.displayButton);
            this.MaximizeBox = false;
            this.Name = "dataSatuanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA SATUAN";
            ((System.ComponentModel.ISupportInitialize)(this.dataSalesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaSupplierTextbox;
        private System.Windows.Forms.DataGridView dataSalesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeSatuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaSatuan;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button displayButton;
    }
}