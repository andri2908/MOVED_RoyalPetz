namespace RoyalPetz_ADMIN
{
    partial class SetApplicationForm
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
            this.ip1Textbox = new System.Windows.Forms.MaskedTextBox();
            this.serverIPRadioButton = new System.Windows.Forms.RadioButton();
            this.localhostRadioButton = new System.Windows.Forms.RadioButton();
            this.ConModeBox = new System.Windows.Forms.GroupBox();
            this.ipServerBox = new System.Windows.Forms.GroupBox();
            this.ip3Textbox = new System.Windows.Forms.MaskedTextBox();
            this.ip4Textbox = new System.Windows.Forms.MaskedTextBox();
            this.ip2Textbox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.AppModeBox = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TeleponTextbox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AlamatTextbox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NamaTokoTextbox = new System.Windows.Forms.TextBox();
            this.HQIPBox = new System.Windows.Forms.GroupBox();
            this.HQIP3 = new System.Windows.Forms.MaskedTextBox();
            this.HQIP1 = new System.Windows.Forms.MaskedTextBox();
            this.HQIP4 = new System.Windows.Forms.MaskedTextBox();
            this.HQIP2 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.branchIDBox = new System.Windows.Forms.GroupBox();
            this.BranchIDTextbox = new System.Windows.Forms.MaskedTextBox();
            this.ConModeBox.SuspendLayout();
            this.ipServerBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AppModeBox.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.HQIPBox.SuspendLayout();
            this.branchIDBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ip1Textbox
            // 
            this.ip1Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip1Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip1Textbox.Location = new System.Drawing.Point(6, 19);
            this.ip1Textbox.Mask = "000";
            this.ip1Textbox.Name = "ip1Textbox";
            this.ip1Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip1Textbox.TabIndex = 20;
            this.ip1Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip1Textbox.Visible = false;
            this.ip1Textbox.Enter += new System.EventHandler(this.ip1Textbox_Enter);
            this.ip1Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip1Textbox_KeyPress);
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
            this.serverIPRadioButton.CheckedChanged += new System.EventHandler(this.serverIPRadioButton_CheckedChanged_1);
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
            this.localhostRadioButton.CheckedChanged += new System.EventHandler(this.localhostRadioButton_CheckedChanged_1);
            // 
            // ConModeBox
            // 
            this.ConModeBox.Controls.Add(this.ipServerBox);
            this.ConModeBox.Controls.Add(this.serverIPRadioButton);
            this.ConModeBox.Controls.Add(this.localhostRadioButton);
            this.ConModeBox.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConModeBox.Location = new System.Drawing.Point(9, 335);
            this.ConModeBox.Name = "ConModeBox";
            this.ConModeBox.Size = new System.Drawing.Size(219, 138);
            this.ConModeBox.TabIndex = 23;
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
            this.ip3Textbox.Location = new System.Drawing.Point(106, 18);
            this.ip3Textbox.Mask = "000";
            this.ip3Textbox.Name = "ip3Textbox";
            this.ip3Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip3Textbox.TabIndex = 24;
            this.ip3Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip3Textbox.Visible = false;
            this.ip3Textbox.Enter += new System.EventHandler(this.ip3Textbox_Enter);
            this.ip3Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip3Textbox_KeyPress);
            // 
            // ip4Textbox
            // 
            this.ip4Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip4Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip4Textbox.Location = new System.Drawing.Point(156, 18);
            this.ip4Textbox.Mask = "000";
            this.ip4Textbox.Name = "ip4Textbox";
            this.ip4Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip4Textbox.TabIndex = 26;
            this.ip4Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip4Textbox.Visible = false;
            this.ip4Textbox.Enter += new System.EventHandler(this.ip4Textbox_Enter);
            // 
            // ip2Textbox
            // 
            this.ip2Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip2Textbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ip2Textbox.Location = new System.Drawing.Point(56, 18);
            this.ip2Textbox.Mask = "000";
            this.ip2Textbox.Name = "ip2Textbox";
            this.ip2Textbox.Size = new System.Drawing.Size(38, 27);
            this.ip2Textbox.TabIndex = 22;
            this.ip2Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ip2Textbox.Visible = false;
            this.ip2Textbox.Enter += new System.EventHandler(this.ip2Textbox_Enter);
            this.ip2Textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip2Textbox_KeyPress);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 29);
            this.panel1.TabIndex = 22;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 6);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 26;
            this.errorLabel.Text = "   ";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(175, 532);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 37);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click_1);
            // 
            // AppModeBox
            // 
            this.AppModeBox.Controls.Add(this.groupBox4);
            this.AppModeBox.Controls.Add(this.ConModeBox);
            this.AppModeBox.Controls.Add(this.groupBox3);
            this.AppModeBox.Controls.Add(this.groupBox2);
            this.AppModeBox.Controls.Add(this.groupBox1);
            this.AppModeBox.Controls.Add(this.HQIPBox);
            this.AppModeBox.Controls.Add(this.branchIDBox);
            this.AppModeBox.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppModeBox.Location = new System.Drawing.Point(9, 36);
            this.AppModeBox.Name = "AppModeBox";
            this.AppModeBox.Size = new System.Drawing.Size(441, 489);
            this.AppModeBox.TabIndex = 24;
            this.AppModeBox.TabStop = false;
            this.AppModeBox.Text = "Pengaturan Aplikasi";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EmailTextbox);
            this.groupBox4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 275);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(426, 54);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "EMail ";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.Location = new System.Drawing.Point(6, 19);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(414, 27);
            this.EmailTextbox.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TeleponTextbox);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(426, 54);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Telepon";
            // 
            // TeleponTextbox
            // 
            this.TeleponTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeleponTextbox.Location = new System.Drawing.Point(6, 21);
            this.TeleponTextbox.Mask = "999999999999999999";
            this.TeleponTextbox.Name = "TeleponTextbox";
            this.TeleponTextbox.Size = new System.Drawing.Size(414, 27);
            this.TeleponTextbox.TabIndex = 3;
            this.TeleponTextbox.Enter += new System.EventHandler(this.TeleponTextbox_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AlamatTextbox);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 54);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alamat Toko";
            // 
            // AlamatTextbox
            // 
            this.AlamatTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AlamatTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlamatTextbox.Location = new System.Drawing.Point(6, 19);
            this.AlamatTextbox.Name = "AlamatTextbox";
            this.AlamatTextbox.Size = new System.Drawing.Size(414, 27);
            this.AlamatTextbox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NamaTokoTextbox);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 54);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nama Toko";
            // 
            // NamaTokoTextbox
            // 
            this.NamaTokoTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NamaTokoTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaTokoTextbox.Location = new System.Drawing.Point(6, 19);
            this.NamaTokoTextbox.Name = "NamaTokoTextbox";
            this.NamaTokoTextbox.Size = new System.Drawing.Size(414, 27);
            this.NamaTokoTextbox.TabIndex = 2;
            // 
            // HQIPBox
            // 
            this.HQIPBox.Controls.Add(this.HQIP3);
            this.HQIPBox.Controls.Add(this.HQIP1);
            this.HQIPBox.Controls.Add(this.HQIP4);
            this.HQIPBox.Controls.Add(this.HQIP2);
            this.HQIPBox.Controls.Add(this.label5);
            this.HQIPBox.Controls.Add(this.label6);
            this.HQIPBox.Controls.Add(this.label7);
            this.HQIPBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HQIPBox.Location = new System.Drawing.Point(9, 30);
            this.HQIPBox.Name = "HQIPBox";
            this.HQIPBox.Size = new System.Drawing.Size(200, 59);
            this.HQIPBox.TabIndex = 27;
            this.HQIPBox.TabStop = false;
            this.HQIPBox.Text = "IP Gudang Pusat";
            // 
            // HQIP3
            // 
            this.HQIP3.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HQIP3.Location = new System.Drawing.Point(106, 18);
            this.HQIP3.Mask = "000";
            this.HQIP3.Name = "HQIP3";
            this.HQIP3.Size = new System.Drawing.Size(38, 27);
            this.HQIP3.TabIndex = 24;
            this.HQIP3.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP3.Enter += new System.EventHandler(this.HQIP3_Enter);
            // 
            // HQIP1
            // 
            this.HQIP1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HQIP1.Location = new System.Drawing.Point(6, 19);
            this.HQIP1.Mask = "000";
            this.HQIP1.Name = "HQIP1";
            this.HQIP1.Size = new System.Drawing.Size(38, 27);
            this.HQIP1.TabIndex = 20;
            this.HQIP1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP1.Enter += new System.EventHandler(this.HQIP1_Enter);
            // 
            // HQIP4
            // 
            this.HQIP4.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HQIP4.Location = new System.Drawing.Point(156, 18);
            this.HQIP4.Mask = "000";
            this.HQIP4.Name = "HQIP4";
            this.HQIP4.Size = new System.Drawing.Size(38, 27);
            this.HQIP4.TabIndex = 26;
            this.HQIP4.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP4.Enter += new System.EventHandler(this.HQIP4_Enter);
            // 
            // HQIP2
            // 
            this.HQIP2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HQIP2.Location = new System.Drawing.Point(56, 18);
            this.HQIP2.Mask = "000";
            this.HQIP2.Name = "HQIP2";
            this.HQIP2.Size = new System.Drawing.Size(38, 27);
            this.HQIP2.TabIndex = 22;
            this.HQIP2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.HQIP2.Enter += new System.EventHandler(this.HQIP2_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(140, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "-";
            // 
            // branchIDBox
            // 
            this.branchIDBox.Controls.Add(this.BranchIDTextbox);
            this.branchIDBox.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchIDBox.Location = new System.Drawing.Point(235, 35);
            this.branchIDBox.Name = "branchIDBox";
            this.branchIDBox.Size = new System.Drawing.Size(200, 54);
            this.branchIDBox.TabIndex = 25;
            this.branchIDBox.TabStop = false;
            this.branchIDBox.Text = "Branch ID";
            // 
            // BranchIDTextbox
            // 
            this.BranchIDTextbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.BranchIDTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchIDTextbox.Location = new System.Drawing.Point(6, 18);
            this.BranchIDTextbox.Mask = "000";
            this.BranchIDTextbox.Name = "BranchIDTextbox";
            this.BranchIDTextbox.Size = new System.Drawing.Size(38, 27);
            this.BranchIDTextbox.TabIndex = 30;
            this.BranchIDTextbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.BranchIDTextbox.Enter += new System.EventHandler(this.BranchIDTextbox_Enter);
            // 
            // SetApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(458, 583);
            this.Controls.Add(this.AppModeBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetApplicationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pengaturan Sistem Aplikasi";
            this.Activated += new System.EventHandler(this.setDatabaseLocationForm_Activated);
            this.Load += new System.EventHandler(this.setDatabaseLocationForm_Load);
            this.ConModeBox.ResumeLayout(false);
            this.ConModeBox.PerformLayout();
            this.ipServerBox.ResumeLayout(false);
            this.ipServerBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.AppModeBox.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.HQIPBox.ResumeLayout(false);
            this.HQIPBox.PerformLayout();
            this.branchIDBox.ResumeLayout(false);
            this.branchIDBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox ip1Textbox;
        private System.Windows.Forms.RadioButton serverIPRadioButton;
        private System.Windows.Forms.RadioButton localhostRadioButton;
        private System.Windows.Forms.GroupBox ConModeBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.GroupBox AppModeBox;
        private System.Windows.Forms.GroupBox ipServerBox;
        private System.Windows.Forms.MaskedTextBox ip3Textbox;
        private System.Windows.Forms.MaskedTextBox ip4Textbox;
        private System.Windows.Forms.MaskedTextBox ip2Textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox branchIDBox;
        private System.Windows.Forms.GroupBox HQIPBox;
        private System.Windows.Forms.MaskedTextBox HQIP3;
        private System.Windows.Forms.MaskedTextBox HQIP1;
        private System.Windows.Forms.MaskedTextBox HQIP4;
        private System.Windows.Forms.MaskedTextBox HQIP2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox AlamatTextbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox NamaTokoTextbox;
        private System.Windows.Forms.MaskedTextBox TeleponTextbox;
        private System.Windows.Forms.MaskedTextBox BranchIDTextbox;
    }
}