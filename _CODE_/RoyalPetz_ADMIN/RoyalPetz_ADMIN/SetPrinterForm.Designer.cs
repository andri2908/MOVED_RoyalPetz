namespace RoyalPetz_ADMIN
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
            this.ChangePrinterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PrinterlistBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChangePrinterButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.PrinterlistBox);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pengaturan Printer";
            // 
            // ChangePrinterButton
            // 
            this.ChangePrinterButton.Location = new System.Drawing.Point(104, 157);
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
            this.label2.Location = new System.Drawing.Point(6, 29);
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
            this.PrinterlistBox.Location = new System.Drawing.Point(6, 51);
            this.PrinterlistBox.Name = "PrinterlistBox";
            this.PrinterlistBox.Size = new System.Drawing.Size(270, 84);
            this.PrinterlistBox.TabIndex = 1;
            this.PrinterlistBox.SelectedValueChanged += new System.EventHandler(this.PrinterlistBox_SelectedValueChanged);
            // 
            // SetPrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 225);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetPrinterForm";
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
    }
}