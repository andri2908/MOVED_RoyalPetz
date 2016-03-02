namespace RoyalPetz_ADMIN
{
    partial class dataNomorAkun
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
            this.label1 = new System.Windows.Forms.Label();
            this.namaSupplierTextbox = new System.Windows.Forms.TextBox();
            this.dataSalesDataGridView = new System.Windows.Forms.DataGridView();
            this.kodeAkun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deskripsi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newButton = new System.Windows.Forms.Button();
            this.displayButton = new System.Windows.Forms.Button();
            this.accountnonactiveoption = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSalesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Deskripsi";
            // 
            // namaSupplierTextbox
            // 
            this.namaSupplierTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaSupplierTextbox.Location = new System.Drawing.Point(100, 14);
            this.namaSupplierTextbox.Name = "namaSupplierTextbox";
            this.namaSupplierTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaSupplierTextbox.TabIndex = 36;
            // 
            // dataSalesDataGridView
            // 
            this.dataSalesDataGridView.AllowUserToAddRows = false;
            this.dataSalesDataGridView.AllowUserToDeleteRows = false;
            this.dataSalesDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataSalesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataSalesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSalesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodeAkun,
            this.deskripsi,
            this.tipe});
            this.dataSalesDataGridView.Location = new System.Drawing.Point(0, 72);
            this.dataSalesDataGridView.Name = "dataSalesDataGridView";
            this.dataSalesDataGridView.RowHeadersVisible = false;
            this.dataSalesDataGridView.Size = new System.Drawing.Size(602, 475);
            this.dataSalesDataGridView.TabIndex = 33;
            this.dataSalesDataGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            // 
            // kodeAkun
            // 
            this.kodeAkun.HeaderText = "KODE AKUN";
            this.kodeAkun.Name = "kodeAkun";
            this.kodeAkun.ReadOnly = true;
            this.kodeAkun.Width = 200;
            // 
            // deskripsi
            // 
            this.deskripsi.HeaderText = "DESKRIPSI";
            this.deskripsi.Name = "deskripsi";
            this.deskripsi.ReadOnly = true;
            this.deskripsi.Width = 280;
            // 
            // tipe
            // 
            this.tipe.HeaderText = "TIPE";
            this.tipe.Name = "tipe";
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(502, 14);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(59, 27);
            this.newButton.TabIndex = 37;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(381, 14);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 27);
            this.displayButton.TabIndex = 34;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // accountnonactiveoption
            // 
            this.accountnonactiveoption.AutoSize = true;
            this.accountnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnonactiveoption.Location = new System.Drawing.Point(100, 47);
            this.accountnonactiveoption.Name = "accountnonactiveoption";
            this.accountnonactiveoption.Size = new System.Drawing.Size(172, 19);
            this.accountnonactiveoption.TabIndex = 38;
            this.accountnonactiveoption.Text = "Tampilkan Akun Non Aktif?";
            this.accountnonactiveoption.UseVisualStyleBackColor = true;
            this.accountnonactiveoption.CheckedChanged += new System.EventHandler(this.accountnonactiveoption_CheckedChanged);
            // 
            // dataNomorAkun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 549);
            this.Controls.Add(this.accountnonactiveoption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaSupplierTextbox);
            this.Controls.Add(this.dataSalesDataGridView);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.displayButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataNomorAkun";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA NOMOR AKUN";
            this.Activated += new System.EventHandler(this.dataNomorAkun_Activated);
            this.Load += new System.EventHandler(this.dataNomorAkun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSalesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaSupplierTextbox;
        private System.Windows.Forms.DataGridView dataSalesDataGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeAkun;
        private System.Windows.Forms.DataGridViewTextBoxColumn deskripsi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipe;
        private System.Windows.Forms.CheckBox accountnonactiveoption;
    }
}