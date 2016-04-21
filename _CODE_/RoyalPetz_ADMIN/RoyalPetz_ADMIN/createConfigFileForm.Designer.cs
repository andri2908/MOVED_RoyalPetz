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
            this.saveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.ConModeBox = new System.Windows.Forms.GroupBox();
            this.ipServerBox = new System.Windows.Forms.GroupBox();
            this.ip3Textbox = new System.Windows.Forms.MaskedTextBox();
            this.ip1Textbox = new System.Windows.Forms.MaskedTextBox();
            this.ip4Textbox = new System.Windows.Forms.MaskedTextBox();
            this.ip2Textbox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serverIPRadioButton = new System.Windows.Forms.RadioButton();
            this.localhostRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.ConModeBox.SuspendLayout();
            this.ipServerBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(146, 193);
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
            this.button1.Location = new System.Drawing.Point(13, 193);
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
            this.panel1.Size = new System.Drawing.Size(285, 29);
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
            // ConModeBox
            // 
            this.ConModeBox.Controls.Add(this.ipServerBox);
            this.ConModeBox.Controls.Add(this.serverIPRadioButton);
            this.ConModeBox.Controls.Add(this.localhostRadioButton);
            this.ConModeBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConModeBox.Location = new System.Drawing.Point(31, 48);
            this.ConModeBox.Name = "ConModeBox";
            this.ConModeBox.Size = new System.Drawing.Size(219, 138);
            this.ConModeBox.TabIndex = 72;
            this.ConModeBox.TabStop = false;
            this.ConModeBox.Text = "Opsi Jaringan Koneksi DB";
            // 
            // ipServerBox
            // 
            this.ipServerBox.Controls.Add(this.ip3Textbox);
            this.ipServerBox.Controls.Add(this.ip1Textbox);
            this.ipServerBox.Controls.Add(this.ip4Textbox);
            this.ipServerBox.Controls.Add(this.ip2Textbox);
            this.ipServerBox.Controls.Add(this.label1);
            this.ipServerBox.Controls.Add(this.label4);
            this.ipServerBox.Controls.Add(this.label3);
            this.ipServerBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipServerBox.Location = new System.Drawing.Point(9, 73);
            this.ipServerBox.Name = "ipServerBox";
            this.ipServerBox.Size = new System.Drawing.Size(200, 59);
            this.ipServerBox.TabIndex = 25;
            this.ipServerBox.TabStop = false;
            this.ipServerBox.Text = "IP Server";
            // 
            // ip3Textbox
            // 
            this.ip3Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip3Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip3Textbox.Location = new System.Drawing.Point(106, 20);
            this.ip3Textbox.Mask = "000";
            this.ip3Textbox.Name = "ip3Textbox";
            this.ip3Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip3Textbox.TabIndex = 29;
            this.ip3Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip3Textbox.Visible = false;
            this.ip3Textbox.Enter += new System.EventHandler(this.ip3Textbox_Enter);
            this.ip3Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPMasked_3_KeyPress);
            // 
            // ip1Textbox
            // 
            this.ip1Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip1Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip1Textbox.Location = new System.Drawing.Point(6, 21);
            this.ip1Textbox.Mask = "000";
            this.ip1Textbox.Name = "ip1Textbox";
            this.ip1Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip1Textbox.TabIndex = 27;
            this.ip1Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip1Textbox.Visible = false;
            this.ip1Textbox.Enter += new System.EventHandler(this.ip1Textbox_Enter);
            this.ip1Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPMasked_1_KeyPress);
            // 
            // ip4Textbox
            // 
            this.ip4Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip4Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip4Textbox.Location = new System.Drawing.Point(156, 20);
            this.ip4Textbox.Mask = "000";
            this.ip4Textbox.Name = "ip4Textbox";
            this.ip4Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip4Textbox.TabIndex = 30;
            this.ip4Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip4Textbox.Visible = false;
            this.ip4Textbox.Enter += new System.EventHandler(this.ip4Textbox_Enter);
            // 
            // ip2Textbox
            // 
            this.ip2Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip2Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip2Textbox.Location = new System.Drawing.Point(56, 20);
            this.ip2Textbox.Mask = "000";
            this.ip2Textbox.Name = "ip2Textbox";
            this.ip2Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip2Textbox.TabIndex = 28;
            this.ip2Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip2Textbox.Visible = false;
            this.ip2Textbox.Enter += new System.EventHandler(this.ip2Textbox_Enter);
            this.ip2Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPMasked_2_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 25);
            this.label1.TabIndex = 21;
            this.label1.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(140, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 25);
            this.label3.TabIndex = 23;
            this.label3.Text = "-";
            // 
            // serverIPRadioButton
            // 
            this.serverIPRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serverIPRadioButton.AutoSize = true;
            this.serverIPRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIPRadioButton.Location = new System.Drawing.Point(6, 48);
            this.serverIPRadioButton.Name = "serverIPRadioButton";
            this.serverIPRadioButton.Size = new System.Drawing.Size(110, 22);
            this.serverIPRadioButton.TabIndex = 19;
            this.serverIPRadioButton.Text = "Server IP";
            this.serverIPRadioButton.UseVisualStyleBackColor = true;
            this.serverIPRadioButton.CheckedChanged += new System.EventHandler(this.serverIPRadioButton_CheckedChanged);
            // 
            // localhostRadioButton
            // 
            this.localhostRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.localhostRadioButton.AutoSize = true;
            this.localhostRadioButton.Checked = true;
            this.localhostRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localhostRadioButton.Location = new System.Drawing.Point(6, 20);
            this.localhostRadioButton.Name = "localhostRadioButton";
            this.localhostRadioButton.Size = new System.Drawing.Size(174, 22);
            this.localhostRadioButton.TabIndex = 20;
            this.localhostRadioButton.TabStop = true;
            this.localhostRadioButton.Text = "Local Connection";
            this.localhostRadioButton.UseVisualStyleBackColor = true;
            // 
            // createConfigFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(285, 243);
            this.Controls.Add(this.ConModeBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveButton);
            this.MaximizeBox = false;
            this.Name = "createConfigFileForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IP SERVER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.createConfigFileForm_FormClosed);
            this.Load += new System.EventHandler(this.createConfigFileForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ConModeBox.ResumeLayout(false);
            this.ConModeBox.PerformLayout();
            this.ipServerBox.ResumeLayout(false);
            this.ipServerBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.GroupBox ConModeBox;
        private System.Windows.Forms.GroupBox ipServerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton serverIPRadioButton;
        private System.Windows.Forms.RadioButton localhostRadioButton;
        private System.Windows.Forms.MaskedTextBox ip3Textbox;
        private System.Windows.Forms.MaskedTextBox ip1Textbox;
        private System.Windows.Forms.MaskedTextBox ip4Textbox;
        private System.Windows.Forms.MaskedTextBox ip2Textbox;
    }
}