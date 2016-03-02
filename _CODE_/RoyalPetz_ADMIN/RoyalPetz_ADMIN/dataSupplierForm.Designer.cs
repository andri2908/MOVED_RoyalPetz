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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.namaSupplierTextbox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.dataSupplierDataGridView = new System.Windows.Forms.DataGridView();
            this.suppliernonactiveoption = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataSupplierDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nama";
            // 
            // namaSupplierTextbox
            // 
            this.namaSupplierTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaSupplierTextbox.Location = new System.Drawing.Point(85, 12);
            this.namaSupplierTextbox.Name = "namaSupplierTextbox";
            this.namaSupplierTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaSupplierTextbox.TabIndex = 16;
            this.namaSupplierTextbox.TextChanged += new System.EventHandler(this.namaSupplierTextbox_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.Location = new System.Drawing.Point(363, 12);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 27);
            this.newButton.TabIndex = 17;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // dataSupplierDataGridView
            // 
            this.dataSupplierDataGridView.AllowUserToAddRows = false;
            this.dataSupplierDataGridView.AllowUserToDeleteRows = false;
            this.dataSupplierDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataSupplierDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataSupplierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSupplierDataGridView.Location = new System.Drawing.Point(0, 68);
            this.dataSupplierDataGridView.Name = "dataSupplierDataGridView";
            this.dataSupplierDataGridView.RowHeadersVisible = false;
            this.dataSupplierDataGridView.Size = new System.Drawing.Size(438, 480);
            this.dataSupplierDataGridView.TabIndex = 13;
            this.dataSupplierDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSupplierDataGridView_CellContentClick);
            this.dataSupplierDataGridView.DoubleClick += new System.EventHandler(this.dataSupplierDataGridView_DoubleClick);
            // 
            // suppliernonactiveoption
            // 
            this.suppliernonactiveoption.AutoSize = true;
            this.suppliernonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliernonactiveoption.Location = new System.Drawing.Point(85, 43);
            this.suppliernonactiveoption.Name = "suppliernonactiveoption";
            this.suppliernonactiveoption.Size = new System.Drawing.Size(191, 19);
            this.suppliernonactiveoption.TabIndex = 37;
            this.suppliernonactiveoption.Text = "Tampilkan Supplier Non Aktif?";
            this.suppliernonactiveoption.UseVisualStyleBackColor = true;
            this.suppliernonactiveoption.CheckedChanged += new System.EventHandler(this.suppliernonactiveoption_CheckedChanged);
            // 
            // dataSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(438, 549);
            this.Controls.Add(this.suppliernonactiveoption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaSupplierTextbox);
            this.Controls.Add(this.dataSupplierDataGridView);
            this.Controls.Add(this.newButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataSupplierForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA SUPPLIER";
            this.Activated += new System.EventHandler(this.dataSupplierForm_Activated);
            this.Load += new System.EventHandler(this.dataSupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSupplierDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaSupplierTextbox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.DataGridView dataSupplierDataGridView;
        private System.Windows.Forms.CheckBox suppliernonactiveoption;
    }
}