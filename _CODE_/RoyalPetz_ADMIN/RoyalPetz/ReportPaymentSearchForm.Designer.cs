namespace AlphaSoft
{
    partial class ReportPaymentSearchForm
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
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.CustomercomboBox = new System.Windows.Forms.ComboBox();
            this.nonactivecheckbox = new System.Windows.Forms.CheckBox();
            this.CariButton = new System.Windows.Forms.Button();
            this.SupplierNameCombobox = new System.Windows.Forms.ComboBox();
            this.LabelOptions = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datetoPicker = new System.Windows.Forms.DateTimePicker();
            this.datefromPicker = new System.Windows.Forms.DateTimePicker();
            this.BranchcomboBox = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.BranchcomboBox);
            this.groupBox1.Controls.Add(this.ErrorLabel);
            this.groupBox1.Controls.Add(this.CustomercomboBox);
            this.groupBox1.Controls.Add(this.nonactivecheckbox);
            this.groupBox1.Controls.Add(this.CariButton);
            this.groupBox1.Controls.Add(this.SupplierNameCombobox);
            this.groupBox1.Controls.Add(this.LabelOptions);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.datetoPicker);
            this.groupBox1.Controls.Add(this.datefromPicker);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 146);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kriteria Pencarian Data Pembayaran";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.Location = new System.Drawing.Point(233, 61);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(126, 18);
            this.ErrorLabel.TabIndex = 7;
            this.ErrorLabel.Text = "Data Kosong.";
            this.ErrorLabel.Visible = false;
            // 
            // CustomercomboBox
            // 
            this.CustomercomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CustomercomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CustomercomboBox.FormattingEnabled = true;
            this.CustomercomboBox.Location = new System.Drawing.Point(230, 58);
            this.CustomercomboBox.Name = "CustomercomboBox";
            this.CustomercomboBox.Size = new System.Drawing.Size(200, 26);
            this.CustomercomboBox.TabIndex = 6;
            this.CustomercomboBox.Text = "SEMUA";
            this.CustomercomboBox.Visible = false;
            // 
            // nonactivecheckbox
            // 
            this.nonactivecheckbox.AutoSize = true;
            this.nonactivecheckbox.Location = new System.Drawing.Point(443, 62);
            this.nonactivecheckbox.Name = "nonactivecheckbox";
            this.nonactivecheckbox.Size = new System.Drawing.Size(138, 22);
            this.nonactivecheckbox.TabIndex = 5;
            this.nonactivecheckbox.Text = "show hidden";
            this.nonactivecheckbox.UseVisualStyleBackColor = true;
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
            // SupplierNameCombobox
            // 
            this.SupplierNameCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.SupplierNameCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.SupplierNameCombobox.FormattingEnabled = true;
            this.SupplierNameCombobox.Location = new System.Drawing.Point(231, 58);
            this.SupplierNameCombobox.Name = "SupplierNameCombobox";
            this.SupplierNameCombobox.Size = new System.Drawing.Size(200, 26);
            this.SupplierNameCombobox.TabIndex = 1;
            this.SupplierNameCombobox.Text = "P-UMUM";
            this.SupplierNameCombobox.Visible = false;
            // 
            // LabelOptions
            // 
            this.LabelOptions.AutoSize = true;
            this.LabelOptions.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOptions.Location = new System.Drawing.Point(6, 63);
            this.LabelOptions.Name = "LabelOptions";
            this.LabelOptions.Size = new System.Drawing.Size(79, 18);
            this.LabelOptions.TabIndex = 3;
            this.LabelOptions.Text = "Supplier";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(437, 14);
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
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tanggal Pembayaran";
            // 
            // datetoPicker
            // 
            this.datetoPicker.Location = new System.Drawing.Point(470, 25);
            this.datetoPicker.Name = "datetoPicker";
            this.datetoPicker.Size = new System.Drawing.Size(200, 27);
            this.datetoPicker.TabIndex = 1;
            // 
            // datefromPicker
            // 
            this.datefromPicker.Location = new System.Drawing.Point(230, 25);
            this.datefromPicker.Name = "datefromPicker";
            this.datefromPicker.Size = new System.Drawing.Size(200, 27);
            this.datefromPicker.TabIndex = 0;
            // 
            // BranchcomboBox
            // 
            this.BranchcomboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.BranchcomboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.BranchcomboBox.FormattingEnabled = true;
            this.BranchcomboBox.Location = new System.Drawing.Point(230, 58);
            this.BranchcomboBox.Name = "BranchcomboBox";
            this.BranchcomboBox.Size = new System.Drawing.Size(200, 26);
            this.BranchcomboBox.TabIndex = 8;
            this.BranchcomboBox.Text = "SEMUA";
            this.BranchcomboBox.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(209, 64);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ReportPaymentSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 168);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReportPaymentSearchForm";
            this.Text = "Laporan Pembayaran Hutang dan Piutang";
            this.Load += new System.EventHandler(this.ReportPaymentSearchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.ComboBox CustomercomboBox;
        private System.Windows.Forms.CheckBox nonactivecheckbox;
        private System.Windows.Forms.Button CariButton;
        private System.Windows.Forms.ComboBox SupplierNameCombobox;
        private System.Windows.Forms.Label LabelOptions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datetoPicker;
        private System.Windows.Forms.DateTimePicker datefromPicker;
        private System.Windows.Forms.ComboBox BranchcomboBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}