namespace AlphaSoft
{
    partial class pembayaranLumpSumForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.paymentCombo = new System.Windows.Forms.ComboBox();
            this.cairDTPicker = new System.Windows.Forms.DateTimePicker();
            this.labelCair = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cabangNameTextBox = new System.Windows.Forms.TextBox();
            this.paymentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.paymentMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detailPaymentInfoDataGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.confirmBayar = new System.Windows.Forms.ToolStripMenuItem();
            this.invalidPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.detailPMDataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailPaymentInfoDataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailPMDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 29);
            this.panel1.TabIndex = 60;
            // 
            // paymentCombo
            // 
            this.paymentCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.paymentCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.paymentCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentCombo.FormattingEnabled = true;
            this.paymentCombo.Location = new System.Drawing.Point(294, 113);
            this.paymentCombo.Name = "paymentCombo";
            this.paymentCombo.Size = new System.Drawing.Size(229, 26);
            this.paymentCombo.TabIndex = 66;
            this.paymentCombo.SelectedIndexChanged += new System.EventHandler(this.paymentCombo_SelectedIndexChanged);
            this.paymentCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.paymentCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // cairDTPicker
            // 
            this.cairDTPicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cairDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cairDTPicker.Location = new System.Drawing.Point(703, 142);
            this.cairDTPicker.Name = "cairDTPicker";
            this.cairDTPicker.Size = new System.Drawing.Size(173, 27);
            this.cairDTPicker.TabIndex = 59;
            this.cairDTPicker.Visible = false;
            this.cairDTPicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.cairDTPicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // labelCair
            // 
            this.labelCair.AutoSize = true;
            this.labelCair.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCair.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelCair.Location = new System.Drawing.Point(593, 148);
            this.labelCair.Name = "labelCair";
            this.labelCair.Size = new System.Drawing.Size(104, 18);
            this.labelCair.TabIndex = 58;
            this.labelCair.Text = "TGL CAIR :";
            this.labelCair.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(6, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 18);
            this.label4.TabIndex = 66;
            this.label4.Text = "METODE PEMBAYARAN";
            // 
            // cabangNameTextBox
            // 
            this.cabangNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cabangNameTextBox.Location = new System.Drawing.Point(294, 43);
            this.cabangNameTextBox.Name = "cabangNameTextBox";
            this.cabangNameTextBox.ReadOnly = true;
            this.cabangNameTextBox.Size = new System.Drawing.Size(319, 27);
            this.cabangNameTextBox.TabIndex = 16;
            // 
            // paymentDateTimePicker
            // 
            this.paymentDateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.paymentDateTimePicker.Location = new System.Drawing.Point(294, 10);
            this.paymentDateTimePicker.Name = "paymentDateTimePicker";
            this.paymentDateTimePicker.Size = new System.Drawing.Size(171, 27);
            this.paymentDateTimePicker.TabIndex = 56;
            this.paymentDateTimePicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.paymentDateTimePicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(274, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(274, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 18);
            this.label13.TabIndex = 58;
            this.label13.Text = ":";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalLabel.Location = new System.Drawing.Point(289, 75);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(83, 29);
            this.totalLabel.TabIndex = 49;
            this.totalLabel.Text = "Rp. 0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(6, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 18);
            this.label14.TabIndex = 59;
            this.label14.Text = "CABANG";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(274, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 60;
            this.label15.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(274, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 64;
            this.label8.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(4, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 29);
            this.label3.TabIndex = 51;
            this.label3.Text = "TOTAL PIUTANG";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 18);
            this.label11.TabIndex = 20;
            this.label11.Text = "TGL PEMBAYARAN ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "DESKRIPSI";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descriptionTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(294, 178);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(582, 27);
            this.descriptionTextBox.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(6, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 18);
            this.label7.TabIndex = 63;
            this.label7.Text = "TOTAL PEMBAYARAN";
            // 
            // paymentMaskedTextBox
            // 
            this.paymentMaskedTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMaskedTextBox.Location = new System.Drawing.Point(294, 145);
            this.paymentMaskedTextBox.Mask = "00000000000";
            this.paymentMaskedTextBox.Name = "paymentMaskedTextBox";
            this.paymentMaskedTextBox.Size = new System.Drawing.Size(147, 27);
            this.paymentMaskedTextBox.TabIndex = 57;
            this.paymentMaskedTextBox.Text = "0";
            this.paymentMaskedTextBox.ValidatingType = typeof(int);
            this.paymentMaskedTextBox.TextChanged += new System.EventHandler(this.paymentMaskedTextBox_TextChanged);
            this.paymentMaskedTextBox.Enter += new System.EventHandler(this.paymentMaskedTextBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(274, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = ":";
            // 
            // detailPaymentInfoDataGrid
            // 
            this.detailPaymentInfoDataGrid.AllowUserToAddRows = false;
            this.detailPaymentInfoDataGrid.AllowUserToDeleteRows = false;
            this.detailPaymentInfoDataGrid.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailPaymentInfoDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.detailPaymentInfoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailPaymentInfoDataGrid.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailPaymentInfoDataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.detailPaymentInfoDataGrid.Location = new System.Drawing.Point(0, 450);
            this.detailPaymentInfoDataGrid.MultiSelect = false;
            this.detailPaymentInfoDataGrid.Name = "detailPaymentInfoDataGrid";
            this.detailPaymentInfoDataGrid.ReadOnly = true;
            this.detailPaymentInfoDataGrid.RowHeadersVisible = false;
            this.detailPaymentInfoDataGrid.Size = new System.Drawing.Size(889, 151);
            this.detailPaymentInfoDataGrid.TabIndex = 64;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmBayar,
            this.invalidPayment});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(188, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // confirmBayar
            // 
            this.confirmBayar.Name = "confirmBayar";
            this.confirmBayar.Size = new System.Drawing.Size(187, 22);
            this.confirmBayar.Text = "Confirm Pembayaran";
            this.confirmBayar.Click += new System.EventHandler(this.confirmBayar_Click);
            // 
            // invalidPayment
            // 
            this.invalidPayment.Name = "invalidPayment";
            this.invalidPayment.Size = new System.Drawing.Size(187, 22);
            this.invalidPayment.Text = "Pembayaran Invalid";
            this.invalidPayment.Click += new System.EventHandler(this.invalidPayment_Click);
            // 
            // detailPMDataGridView
            // 
            this.detailPMDataGridView.AllowUserToAddRows = false;
            this.detailPMDataGridView.AllowUserToDeleteRows = false;
            this.detailPMDataGridView.AllowUserToOrderColumns = true;
            this.detailPMDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailPMDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.detailPMDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailPMDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.detailPMDataGridView.Location = new System.Drawing.Point(1, 307);
            this.detailPMDataGridView.Name = "detailPMDataGridView";
            this.detailPMDataGridView.ReadOnly = true;
            this.detailPMDataGridView.RowHeadersVisible = false;
            this.detailPMDataGridView.Size = new System.Drawing.Size(888, 141);
            this.detailPMDataGridView.TabIndex = 63;
            this.detailPMDataGridView.SelectionChanged += new System.EventHandler(this.detailPMDataGridView_SelectionChanged);
            this.detailPMDataGridView.Click += new System.EventHandler(this.detailPMDataGridView_Click);
            this.detailPMDataGridView.DoubleClick += new System.EventHandler(this.detailPMDataGridView_DoubleClick);
            this.detailPMDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailPMDataGridView_KeyDown);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(380, 221);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(122, 37);
            this.saveButton.TabIndex = 65;
            this.saveButton.Text = "SAVE ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(689, 243);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(187, 17);
            this.checkBox1.TabIndex = 66;
            this.checkBox1.Text = "Tampilkan Invoice yg sudah lunas";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cairDTPicker);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.paymentCombo);
            this.groupBox1.Controls.Add(this.saveButton);
            this.groupBox1.Controls.Add(this.labelCair);
            this.groupBox1.Controls.Add(this.cabangNameTextBox);
            this.groupBox1.Controls.Add(this.paymentDateTimePicker);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.paymentMaskedTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.totalLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 266);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(274, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 67;
            this.label6.Text = ":";
            // 
            // pembayaranLumpSumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(890, 662);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.detailPaymentInfoDataGrid);
            this.Controls.Add(this.detailPMDataGridView);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "pembayaranLumpSumForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA PIUTANG MUTASI";
            this.Activated += new System.EventHandler(this.pembayaranLumpSumForm_Activated);
            this.Deactivate += new System.EventHandler(this.pembayaranLumpSumForm_Deactivate);
            this.Load += new System.EventHandler(this.dataPiutangMutasiForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailPaymentInfoDataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detailPMDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox cabangNameTextBox;
        private System.Windows.Forms.DateTimePicker paymentDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.MaskedTextBox paymentMaskedTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView detailPaymentInfoDataGrid;
        private System.Windows.Forms.DataGridView detailPMDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox paymentCombo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem confirmBayar;
        private System.Windows.Forms.ToolStripMenuItem invalidPayment;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker cairDTPicker;
        private System.Windows.Forms.Label labelCair;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
    }
}