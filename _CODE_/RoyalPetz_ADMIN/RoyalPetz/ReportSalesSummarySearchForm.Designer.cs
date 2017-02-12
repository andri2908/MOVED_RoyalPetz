namespace AlphaSoft
{
    partial class ReportSalesSummarySearchForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProductcomboBox = new System.Windows.Forms.ComboBox();
            this.nonactivecheckbox = new System.Windows.Forms.CheckBox();
            this.CariButton = new System.Windows.Forms.Button();
            this.CustNameCombobox = new System.Windows.Forms.ComboBox();
            this.LabelOptions = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datetoPicker = new System.Windows.Forms.DateTimePicker();
            this.datefromPicker = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.ProductcomboBox);
            this.groupBox1.Controls.Add(this.nonactivecheckbox);
            this.groupBox1.Controls.Add(this.CariButton);
            this.groupBox1.Controls.Add(this.CustNameCombobox);
            this.groupBox1.Controls.Add(this.LabelOptions);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.datetoPicker);
            this.groupBox1.Controls.Add(this.datefromPicker);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kriteria Pencarian Data Penjualan";
            // 
            // ProductcomboBox
            // 
            this.ProductcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.ProductcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ProductcomboBox.FormattingEnabled = true;
            this.ProductcomboBox.Location = new System.Drawing.Point(204, 58);
            this.ProductcomboBox.Name = "ProductcomboBox";
            this.ProductcomboBox.Size = new System.Drawing.Size(200, 26);
            this.ProductcomboBox.TabIndex = 6;
            this.ProductcomboBox.Text = "SEMUA";
            this.ProductcomboBox.Visible = false;
            // 
            // nonactivecheckbox
            // 
            this.nonactivecheckbox.AutoSize = true;
            this.nonactivecheckbox.Location = new System.Drawing.Point(417, 62);
            this.nonactivecheckbox.Name = "nonactivecheckbox";
            this.nonactivecheckbox.Size = new System.Drawing.Size(138, 22);
            this.nonactivecheckbox.TabIndex = 5;
            this.nonactivecheckbox.Text = "show hidden";
            this.nonactivecheckbox.UseVisualStyleBackColor = true;
            this.nonactivecheckbox.CheckedChanged += new System.EventHandler(this.nonactivecheckbox_CheckedChanged);
            // 
            // CariButton
            // 
            this.CariButton.Location = new System.Drawing.Point(294, 99);
            this.CariButton.Name = "CariButton";
            this.CariButton.Size = new System.Drawing.Size(75, 34);
            this.CariButton.TabIndex = 4;
            this.CariButton.Text = "Cari";
            this.CariButton.UseVisualStyleBackColor = true;
            this.CariButton.Click += new System.EventHandler(this.CariButton_Click);
            // 
            // CustNameCombobox
            // 
            this.CustNameCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CustNameCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CustNameCombobox.FormattingEnabled = true;
            this.CustNameCombobox.Location = new System.Drawing.Point(204, 58);
            this.CustNameCombobox.Name = "CustNameCombobox";
            this.CustNameCombobox.Size = new System.Drawing.Size(200, 26);
            this.CustNameCombobox.TabIndex = 1;
            this.CustNameCombobox.Text = "P-UMUM";
            this.CustNameCombobox.Visible = false;
            // 
            // LabelOptions
            // 
            this.LabelOptions.AutoSize = true;
            this.LabelOptions.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOptions.Location = new System.Drawing.Point(6, 63);
            this.LabelOptions.Name = "LabelOptions";
            this.LabelOptions.Size = new System.Drawing.Size(101, 18);
            this.LabelOptions.TabIndex = 3;
            this.LabelOptions.Text = "Pelanggan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(411, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tanggal Penjualan";
            // 
            // datetoPicker
            // 
            this.datetoPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datetoPicker.Location = new System.Drawing.Point(444, 25);
            this.datetoPicker.Name = "datetoPicker";
            this.datetoPicker.Size = new System.Drawing.Size(200, 27);
            this.datetoPicker.TabIndex = 1;
            // 
            // datefromPicker
            // 
            this.datefromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datefromPicker.Location = new System.Drawing.Point(204, 25);
            this.datefromPicker.Name = "datefromPicker";
            this.datefromPicker.Size = new System.Drawing.Size(200, 27);
            this.datefromPicker.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(183, 66);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ReportSalesSummarySearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 168);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportSalesSummarySearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Penjualan";
            this.Load += new System.EventHandler(this.ReportSalesSummarySearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datetoPicker;
        private System.Windows.Forms.DateTimePicker datefromPicker;
        private System.Windows.Forms.Button CariButton;
        private System.Windows.Forms.ComboBox CustNameCombobox;
        private System.Windows.Forms.Label LabelOptions;
        private System.Windows.Forms.CheckBox nonactivecheckbox;
        private System.Windows.Forms.ComboBox ProductcomboBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}