namespace AlphaSoft
{
    partial class SetPrinterForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.ChangePrinterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PrinterlistBox = new System.Windows.Forms.ListBox();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ChangePrinterButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PrinterlistBox);
            this.groupBox1.Controls.Add(this.sizeComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pengaturan Printer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Size Kertas";
            // 
            // ChangePrinterButton
            // 
            this.ChangePrinterButton.Location = new System.Drawing.Point(110, 196);
            this.ChangePrinterButton.Name = "ChangePrinterButton";
            this.ChangePrinterButton.Size = new System.Drawing.Size(75, 26);
            this.ChangePrinterButton.TabIndex = 5;
            this.ChangePrinterButton.Text = "Ubah";
            this.ChangePrinterButton.UseVisualStyleBackColor = true;
            this.ChangePrinterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Opsi Pilihan Printer";
            // 
            // PrinterlistBox
            // 
            this.PrinterlistBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.PrinterlistBox.FormattingEnabled = true;
            this.PrinterlistBox.ItemHeight = 16;
            this.PrinterlistBox.Location = new System.Drawing.Point(12, 51);
            this.PrinterlistBox.Name = "PrinterlistBox";
            this.PrinterlistBox.Size = new System.Drawing.Size(270, 84);
            this.PrinterlistBox.TabIndex = 1;
            this.PrinterlistBox.SelectedValueChanged += new System.EventHandler(this.PrinterlistBox_SelectedValueChanged);
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sizeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Items.AddRange(new object[] {
            "POS Receipt",
            "1/2 Kwarto",
            "Kwarto"});
            this.sizeComboBox.Location = new System.Drawing.Point(136, 146);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(146, 26);
            this.sizeComboBox.TabIndex = 13;
            this.sizeComboBox.Text = "POS Receipt";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 29);
            this.panel1.TabIndex = 64;
            // 
            // SetPrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(308, 293);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetPrinterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengaturan Printer";
            this.Load += new System.EventHandler(this.SetPrinterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox PrinterlistBox;
        private System.Windows.Forms.Button ChangePrinterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox sizeComboBox;
    }
}