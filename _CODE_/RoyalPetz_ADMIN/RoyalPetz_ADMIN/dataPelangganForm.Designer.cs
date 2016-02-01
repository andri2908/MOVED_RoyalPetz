namespace RoyalPetz_ADMIN
{
    partial class dataPelangganForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.namaPelangganTextbox = new System.Windows.Forms.TextBox();
            this.dataPelangganDataGridView = new System.Windows.Forms.DataGridView();
            this.kodePelanggan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaPelanggan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newButton = new System.Windows.Forms.Button();
            this.displayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataPelangganDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nama";
            // 
            // namaPelangganTextbox
            // 
            this.namaPelangganTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaPelangganTextbox.Location = new System.Drawing.Point(85, 22);
            this.namaPelangganTextbox.Name = "namaPelangganTextbox";
            this.namaPelangganTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaPelangganTextbox.TabIndex = 11;
            // 
            // dataPelangganDataGridView
            // 
            this.dataPelangganDataGridView.AllowUserToAddRows = false;
            this.dataPelangganDataGridView.AllowUserToDeleteRows = false;
            this.dataPelangganDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPelangganDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataPelangganDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPelangganDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodePelanggan,
            this.namaPelanggan});
            this.dataPelangganDataGridView.Location = new System.Drawing.Point(0, 68);
            this.dataPelangganDataGridView.Name = "dataPelangganDataGridView";
            this.dataPelangganDataGridView.RowHeadersVisible = false;
            this.dataPelangganDataGridView.Size = new System.Drawing.Size(602, 480);
            this.dataPelangganDataGridView.TabIndex = 8;
            // 
            // kodePelanggan
            // 
            this.kodePelanggan.HeaderText = "KODE PELANGGAN";
            this.kodePelanggan.Name = "kodePelanggan";
            this.kodePelanggan.ReadOnly = true;
            this.kodePelanggan.Width = 200;
            // 
            // namaPelanggan
            // 
            this.namaPelanggan.HeaderText = "NAMA PELANGGAN";
            this.namaPelanggan.Name = "namaPelanggan";
            this.namaPelanggan.ReadOnly = true;
            this.namaPelanggan.Width = 350;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(491, 16);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 12;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(360, 17);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 9;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            // 
            // dataPelangganForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaPelangganTextbox);
            this.Controls.Add(this.dataPelangganDataGridView);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.displayButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataPelangganForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA PELANGGAN";
            ((System.ComponentModel.ISupportInitialize)(this.dataPelangganDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaPelangganTextbox;
        private System.Windows.Forms.DataGridView dataPelangganDataGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodePelanggan;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaPelanggan;
    }
}