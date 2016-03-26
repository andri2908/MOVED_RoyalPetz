namespace RoyalPetz_ADMIN
{
    partial class createConfigFileForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.IPMasked_1 = new System.Windows.Forms.MaskedTextBox();
            this.IPMasked_2 = new System.Windows.Forms.MaskedTextBox();
            this.IPMasked_3 = new System.Windows.Forms.MaskedTextBox();
            this.IPMasked_4 = new System.Windows.Forms.MaskedTextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(21, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 18);
            this.label7.TabIndex = 64;
            this.label7.Text = "IP SERVER :";
            // 
            // IPMasked_1
            // 
            this.IPMasked_1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IPMasked_1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPMasked_1.Location = new System.Drawing.Point(142, 43);
            this.IPMasked_1.Mask = "000";
            this.IPMasked_1.Name = "IPMasked_1";
            this.IPMasked_1.Size = new System.Drawing.Size(38, 27);
            this.IPMasked_1.TabIndex = 65;
            this.IPMasked_1.UseWaitCursor = true;
            this.IPMasked_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPMasked_1_KeyPress);
            // 
            // IPMasked_2
            // 
            this.IPMasked_2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IPMasked_2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPMasked_2.Location = new System.Drawing.Point(192, 42);
            this.IPMasked_2.Mask = "000";
            this.IPMasked_2.Name = "IPMasked_2";
            this.IPMasked_2.Size = new System.Drawing.Size(38, 27);
            this.IPMasked_2.TabIndex = 66;
            this.IPMasked_2.UseWaitCursor = true;
            this.IPMasked_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPMasked_2_KeyPress);
            // 
            // IPMasked_3
            // 
            this.IPMasked_3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IPMasked_3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPMasked_3.Location = new System.Drawing.Point(242, 42);
            this.IPMasked_3.Mask = "000";
            this.IPMasked_3.Name = "IPMasked_3";
            this.IPMasked_3.Size = new System.Drawing.Size(38, 27);
            this.IPMasked_3.TabIndex = 67;
            this.IPMasked_3.UseWaitCursor = true;
            this.IPMasked_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPMasked_3_KeyPress);
            // 
            // IPMasked_4
            // 
            this.IPMasked_4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IPMasked_4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPMasked_4.Location = new System.Drawing.Point(295, 42);
            this.IPMasked_4.Mask = "000";
            this.IPMasked_4.Name = "IPMasked_4";
            this.IPMasked_4.Size = new System.Drawing.Size(38, 27);
            this.IPMasked_4.TabIndex = 68;
            this.IPMasked_4.UseWaitCursor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(190, 89);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(122, 37);
            this.saveButton.TabIndex = 69;
            this.saveButton.Text = "SAVE ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(38, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 37);
            this.button1.TabIndex = 70;
            this.button1.Text = "TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 29);
            this.panel1.TabIndex = 71;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(4, 5);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 56;
            this.errorLabel.Text = "   ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 25);
            this.label1.TabIndex = 72;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 25);
            this.label2.TabIndex = 73;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(277, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 25);
            this.label3.TabIndex = 74;
            this.label3.Text = "-";
            // 
            // createConfigFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(349, 138);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.IPMasked_4);
            this.Controls.Add(this.IPMasked_3);
            this.Controls.Add(this.IPMasked_2);
            this.Controls.Add(this.IPMasked_1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "createConfigFileForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP SERVER";
            this.Load += new System.EventHandler(this.createConfigFileForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox IPMasked_1;
        private System.Windows.Forms.MaskedTextBox IPMasked_2;
        private System.Windows.Forms.MaskedTextBox IPMasked_3;
        private System.Windows.Forms.MaskedTextBox IPMasked_4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}