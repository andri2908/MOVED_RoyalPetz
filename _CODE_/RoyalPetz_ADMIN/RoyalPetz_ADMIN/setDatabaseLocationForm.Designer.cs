namespace RoyalPetz_ADMIN
{
    partial class setDatabaseLocationForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.serverIPRadioButton = new System.Windows.Forms.RadioButton();
            this.ipAddressMaskedTextbox = new System.Windows.Forms.MaskedTextBox();
            this.localhostRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.0597F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.9403F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 354F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.localhostRadioButton, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 113);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "DATABASE";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(120, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(9, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = ":";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.serverIPRadioButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ipAddressMaskedTextbox, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(135, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 59);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // serverIPRadioButton
            // 
            this.serverIPRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.serverIPRadioButton.AutoSize = true;
            this.serverIPRadioButton.Checked = true;
            this.serverIPRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIPRadioButton.Location = new System.Drawing.Point(3, 3);
            this.serverIPRadioButton.Name = "serverIPRadioButton";
            this.serverIPRadioButton.Size = new System.Drawing.Size(110, 22);
            this.serverIPRadioButton.TabIndex = 19;
            this.serverIPRadioButton.TabStop = true;
            this.serverIPRadioButton.Text = "Server IP";
            this.serverIPRadioButton.UseVisualStyleBackColor = true;
            this.serverIPRadioButton.CheckedChanged += new System.EventHandler(this.serverIPRadioButton_CheckedChanged);
            this.serverIPRadioButton.Click += new System.EventHandler(this.serverIPRadioButton_Click);
            // 
            // ipAddressMaskedTextbox
            // 
            this.ipAddressMaskedTextbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ipAddressMaskedTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressMaskedTextbox.Location = new System.Drawing.Point(3, 32);
            this.ipAddressMaskedTextbox.Mask = "000.000.000.000";
            this.ipAddressMaskedTextbox.Name = "ipAddressMaskedTextbox";
            this.ipAddressMaskedTextbox.Size = new System.Drawing.Size(149, 27);
            this.ipAddressMaskedTextbox.TabIndex = 20;
            this.ipAddressMaskedTextbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // localhostRadioButton
            // 
            this.localhostRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.localhostRadioButton.AutoSize = true;
            this.localhostRadioButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localhostRadioButton.Location = new System.Drawing.Point(135, 78);
            this.localhostRadioButton.Name = "localhostRadioButton";
            this.localhostRadioButton.Size = new System.Drawing.Size(134, 22);
            this.localhostRadioButton.TabIndex = 20;
            this.localhostRadioButton.TabStop = true;
            this.localhostRadioButton.Text = "LOCALHOST";
            this.localhostRadioButton.UseVisualStyleBackColor = true;
            this.localhostRadioButton.CheckedChanged += new System.EventHandler(this.localhostRadioButton_CheckedChanged);
            this.localhostRadioButton.Click += new System.EventHandler(this.localhostRadioButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 29);
            this.panel1.TabIndex = 18;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(190, 164);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 37);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // setDatabaseLocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(489, 215);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "setDatabaseLocationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengaturan Lokasi Database";
            this.Activated += new System.EventHandler(this.setDatabaseLocationForm_Activated);
            this.Load += new System.EventHandler(this.setDatabaseLocationForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton serverIPRadioButton;
        private System.Windows.Forms.MaskedTextBox ipAddressMaskedTextbox;
        private System.Windows.Forms.RadioButton localhostRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
    }
}