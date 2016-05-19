namespace RoyalPetz_ADMIN
{
    partial class barcodeForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barcodeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(30, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 29);
            this.label5.TabIndex = 44;
            this.label5.Text = "BARCODE";
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.productNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameTextBox.Location = new System.Drawing.Point(235, 52);
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.ReadOnly = true;
            this.productNameTextBox.Size = new System.Drawing.Size(342, 27);
            this.productNameTextBox.TabIndex = 70;
            this.productNameTextBox.Enter += new System.EventHandler(this.productNameTextBox_Enter);
            this.productNameTextBox.Validated += new System.EventHandler(this.productNameTextBox_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(240, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 29);
            this.label1.TabIndex = 71;
            this.label1.Text = "NAMA PRODUK";
            // 
            // barcodeTextBox
            // 
            this.barcodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barcodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.barcodeTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeTextBox.Location = new System.Drawing.Point(35, 52);
            this.barcodeTextBox.MaxLength = 15;
            this.barcodeTextBox.Name = "barcodeTextBox";
            this.barcodeTextBox.Size = new System.Drawing.Size(174, 26);
            this.barcodeTextBox.TabIndex = 80;
            this.barcodeTextBox.TextChanged += new System.EventHandler(this.barcodeTextBox_TextChanged);
            this.barcodeTextBox.Enter += new System.EventHandler(this.barcodeTextBox_Enter);
            this.barcodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barcodeTextBox_KeyPress);
            // 
            // barcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(595, 115);
            this.ControlBox = false;
            this.Controls.Add(this.barcodeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productNameTextBox);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "barcodeForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "BARCODE";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.barcodeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox barcodeTextBox;
    }
}