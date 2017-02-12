namespace AlphaSoft
{
    partial class exportStockOpnameForm
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
            this.exportToCSV = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.newButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // exportToCSV
            // 
            this.exportToCSV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exportToCSV.AutoSize = true;
            this.exportToCSV.Checked = true;
            this.exportToCSV.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportToCSV.Location = new System.Drawing.Point(36, 50);
            this.exportToCSV.Name = "exportToCSV";
            this.exportToCSV.Size = new System.Drawing.Size(148, 22);
            this.exportToCSV.TabIndex = 20;
            this.exportToCSV.TabStop = true;
            this.exportToCSV.Text = "Export to CSV";
            this.exportToCSV.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 29);
            this.panel1.TabIndex = 21;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(36, 118);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(163, 37);
            this.newButton.TabIndex = 23;
            this.newButton.Text = "EXPORT DATA";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // exportStockOpnameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(241, 183);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.exportToCSV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "exportStockOpnameForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EXPORT DATA";
            this.Load += new System.EventHandler(this.exportStockOpnameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton exportToCSV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}