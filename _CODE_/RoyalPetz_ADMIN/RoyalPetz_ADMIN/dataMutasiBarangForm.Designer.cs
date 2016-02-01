namespace RoyalPetz_ADMIN
{
    partial class dataMutasiBarangForm
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
            this.dataMutasiBarangGridView = new System.Windows.Forms.DataGridView();
            this.noMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tujuanMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asalMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanggalMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalMutasi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataMutasiBarangGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataMutasiBarangGridView
            // 
            this.dataMutasiBarangGridView.AllowUserToAddRows = false;
            this.dataMutasiBarangGridView.AllowUserToDeleteRows = false;
            this.dataMutasiBarangGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataMutasiBarangGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataMutasiBarangGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMutasiBarangGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noMutasi,
            this.tujuanMutasi,
            this.asalMutasi,
            this.tanggalMutasi,
            this.totalMutasi});
            this.dataMutasiBarangGridView.Location = new System.Drawing.Point(0, 50);
            this.dataMutasiBarangGridView.Name = "dataMutasiBarangGridView";
            this.dataMutasiBarangGridView.RowHeadersVisible = false;
            this.dataMutasiBarangGridView.Size = new System.Drawing.Size(938, 496);
            this.dataMutasiBarangGridView.TabIndex = 33;
            this.dataMutasiBarangGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            // 
            // noMutasi
            // 
            this.noMutasi.HeaderText = "NO MUTASI";
            this.noMutasi.Name = "noMutasi";
            this.noMutasi.ReadOnly = true;
            this.noMutasi.Width = 180;
            // 
            // tujuanMutasi
            // 
            this.tujuanMutasi.HeaderText = "TUJUAN MUTASI";
            this.tujuanMutasi.Name = "tujuanMutasi";
            this.tujuanMutasi.Width = 180;
            // 
            // asalMutasi
            // 
            this.asalMutasi.HeaderText = "ASAL MUTASI";
            this.asalMutasi.Name = "asalMutasi";
            this.asalMutasi.Width = 180;
            // 
            // tanggalMutasi
            // 
            this.tanggalMutasi.HeaderText = "TANGGAL MUTASI";
            this.tanggalMutasi.Name = "tanggalMutasi";
            this.tanggalMutasi.ReadOnly = true;
            this.tanggalMutasi.Width = 180;
            // 
            // totalMutasi
            // 
            this.totalMutasi.HeaderText = "TOTAL MUTASI";
            this.totalMutasi.Name = "totalMutasi";
            this.totalMutasi.Width = 200;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(805, 7);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 34;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // dataMutasiBarangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(938, 549);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.dataMutasiBarangGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataMutasiBarangForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA MUTASI";
            ((System.ComponentModel.ISupportInitialize)(this.dataMutasiBarangGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataMutasiBarangGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn noMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tujuanMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn asalMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggalMutasi;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMutasi;
        private System.Windows.Forms.Button newButton;
    }
}