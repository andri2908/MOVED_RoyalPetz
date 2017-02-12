namespace AlphaSoft
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.namaSupplierTextbox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.dataSupplierDataGridView = new System.Windows.Forms.DataGridView();
            this.suppliernonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataSupplierDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "NAMA";
            // 
            // namaSupplierTextbox
            // 
            this.namaSupplierTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaSupplierTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaSupplierTextbox.Location = new System.Drawing.Point(91, 24);
            this.namaSupplierTextbox.Name = "namaSupplierTextbox";
            this.namaSupplierTextbox.Size = new System.Drawing.Size(293, 27);
            this.namaSupplierTextbox.TabIndex = 16;
            this.namaSupplierTextbox.TextChanged += new System.EventHandler(this.namaSupplierTextbox_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(10, 48);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 37);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataSupplierDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataSupplierDataGridView.Location = new System.Drawing.Point(0, 144);
            this.dataSupplierDataGridView.MultiSelect = false;
            this.dataSupplierDataGridView.Name = "dataSupplierDataGridView";
            this.dataSupplierDataGridView.ReadOnly = true;
            this.dataSupplierDataGridView.RowHeadersVisible = false;
            this.dataSupplierDataGridView.Size = new System.Drawing.Size(438, 404);
            this.dataSupplierDataGridView.TabIndex = 13;
            this.dataSupplierDataGridView.DoubleClick += new System.EventHandler(this.dataSupplierDataGridView_DoubleClick);
            this.dataSupplierDataGridView.Enter += new System.EventHandler(this.dataSupplierDataGridView_Enter);
            this.dataSupplierDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataSupplierDataGridView_KeyDown);
            this.dataSupplierDataGridView.Leave += new System.EventHandler(this.dataSupplierDataGridView_Leave);
            // 
            // suppliernonactiveoption
            // 
            this.suppliernonactiveoption.AutoSize = true;
            this.suppliernonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suppliernonactiveoption.Location = new System.Drawing.Point(91, 57);
            this.suppliernonactiveoption.Name = "suppliernonactiveoption";
            this.suppliernonactiveoption.Size = new System.Drawing.Size(191, 19);
            this.suppliernonactiveoption.TabIndex = 37;
            this.suppliernonactiveoption.Text = "Tampilkan Supplier Non Aktif?";
            this.suppliernonactiveoption.UseVisualStyleBackColor = true;
            this.suppliernonactiveoption.CheckedChanged += new System.EventHandler(this.suppliernonactiveoption_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AllButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.suppliernonactiveoption);
            this.groupBox1.Controls.Add(this.namaSupplierTextbox);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 126);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // AllButton
            // 
            this.AllButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AllButton.Location = new System.Drawing.Point(91, 82);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(293, 28);
            this.AllButton.TabIndex = 40;
            this.AllButton.Text = "DISPLAY ALL";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // dataSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(438, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataSupplierDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataSupplierForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA SUPPLIER";
            this.Activated += new System.EventHandler(this.dataSupplierForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataSupplierForm_Deactivate);
            this.Load += new System.EventHandler(this.dataSupplierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSupplierDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaSupplierTextbox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.DataGridView dataSupplierDataGridView;
        private System.Windows.Forms.CheckBox suppliernonactiveoption;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AllButton;
    }
}