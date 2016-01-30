namespace RoyalPetz_ADMIN
{
    partial class dataInvoiceForm
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
            this.namaSupplierTextbox = new System.Windows.Forms.TextBox();
            this.dataInvoiceDataGridView = new System.Windows.Forms.DataGridView();
            this.displayButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.noInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pelanggan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataInvoiceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "NO INVOICE";
            // 
            // namaSupplierTextbox
            // 
            this.namaSupplierTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaSupplierTextbox.Location = new System.Drawing.Point(147, 20);
            this.namaSupplierTextbox.Name = "namaSupplierTextbox";
            this.namaSupplierTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaSupplierTextbox.TabIndex = 36;
            // 
            // dataInvoiceDataGridView
            // 
            this.dataInvoiceDataGridView.AllowUserToAddRows = false;
            this.dataInvoiceDataGridView.AllowUserToDeleteRows = false;
            this.dataInvoiceDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataInvoiceDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataInvoiceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInvoiceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noInvoice,
            this.pelanggan});
            this.dataInvoiceDataGridView.Location = new System.Drawing.Point(0, 105);
            this.dataInvoiceDataGridView.Name = "dataInvoiceDataGridView";
            this.dataInvoiceDataGridView.RowHeadersVisible = false;
            this.dataInvoiceDataGridView.Size = new System.Drawing.Size(602, 480);
            this.dataInvoiceDataGridView.TabIndex = 33;
            this.dataInvoiceDataGridView.DoubleClick += new System.EventHandler(this.dataInvoiceDataGridView_DoubleClick);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(437, 37);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 34;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "PELANGGAN";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(147, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 27);
            this.textBox1.TabIndex = 38;
            // 
            // noInvoice
            // 
            this.noInvoice.HeaderText = "NO INVOICE";
            this.noInvoice.Name = "noInvoice";
            this.noInvoice.ReadOnly = true;
            this.noInvoice.Width = 200;
            // 
            // pelanggan
            // 
            this.pelanggan.HeaderText = "PELANGGAN";
            this.pelanggan.Name = "pelanggan";
            this.pelanggan.ReadOnly = true;
            this.pelanggan.Width = 350;
            // 
            // dataInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 586);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaSupplierTextbox);
            this.Controls.Add(this.dataInvoiceDataGridView);
            this.Controls.Add(this.displayButton);
            this.Name = "dataInvoiceForm";
            this.Text = "dataInvoiceForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataInvoiceDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaSupplierTextbox;
        private System.Windows.Forms.DataGridView dataInvoiceDataGridView;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn pelanggan;
    }
}