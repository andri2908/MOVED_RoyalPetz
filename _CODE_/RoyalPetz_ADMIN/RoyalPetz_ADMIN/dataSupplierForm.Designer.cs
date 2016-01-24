namespace RoyalPetz_ADMIN
{
    partial class dataSupplierForm
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
            this.dataSupplierDataGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.displayButton = new System.Windows.Forms.Button();
            this.kodeSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaSupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataSupplierDataGridView)).BeginInit();
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
            this.label1.TabIndex = 15;
            this.label1.Text = "Nama";
            // 
            // namaSupplierTextbox
            // 
            this.namaSupplierTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaSupplierTextbox.Location = new System.Drawing.Point(85, 22);
            this.namaSupplierTextbox.Name = "namaSupplierTextbox";
            this.namaSupplierTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaSupplierTextbox.TabIndex = 16;
            // 
            // dataSupplierDataGridView
            // 
            this.dataSupplierDataGridView.AllowUserToAddRows = false;
            this.dataSupplierDataGridView.AllowUserToDeleteRows = false;
            this.dataSupplierDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataSupplierDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataSupplierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSupplierDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodeSupplier,
            this.namaSupplier});
            this.dataSupplierDataGridView.Location = new System.Drawing.Point(0, 68);
            this.dataSupplierDataGridView.Name = "dataSupplierDataGridView";
            this.dataSupplierDataGridView.RowHeadersVisible = false;
            this.dataSupplierDataGridView.Size = new System.Drawing.Size(602, 480);
            this.dataSupplierDataGridView.TabIndex = 13;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(491, 16);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 17;
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
            this.displayButton.TabIndex = 14;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            // 
            // kodeSupplier
            // 
            this.kodeSupplier.HeaderText = "KODE SUPPLIER";
            this.kodeSupplier.Name = "kodeSupplier";
            this.kodeSupplier.ReadOnly = true;
            this.kodeSupplier.Width = 200;
            // 
            // namaSupplier
            // 
            this.namaSupplier.HeaderText = "NAMA SUPPLIER";
            this.namaSupplier.Name = "namaSupplier";
            this.namaSupplier.ReadOnly = true;
            this.namaSupplier.Width = 350;
            // 
            // dataSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 549);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaSupplierTextbox);
            this.Controls.Add(this.dataSupplierDataGridView);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.displayButton);
            this.Name = "dataSupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA SUPPLIER";
            ((System.ComponentModel.ISupportInitialize)(this.dataSupplierDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaSupplierTextbox;
        private System.Windows.Forms.DataGridView dataSupplierDataGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaSupplier;
    }
}