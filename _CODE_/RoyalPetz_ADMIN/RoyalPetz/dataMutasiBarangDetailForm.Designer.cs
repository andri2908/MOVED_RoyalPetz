namespace AlphaSoft
{
    partial class dataMutasiBarangDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.detailRequestOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ROExpiredDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.RODateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.approveButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ROInvoiceTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.createPOButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.PMDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.totalApproved = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.totalApprovedLabel = new System.Windows.Forms.Label();
            this.branchToComboHidden = new System.Windows.Forms.ComboBox();
            this.branchToCombo = new System.Windows.Forms.ComboBox();
            this.branchFromComboHidden = new System.Windows.Forms.ComboBox();
            this.branchFromCombo = new System.Windows.Forms.ComboBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.rejectButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.acceptedButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detailRequestOrderDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailRequestOrderDataGridView
            // 
            this.detailRequestOrderDataGridView.AllowUserToDeleteRows = false;
            this.detailRequestOrderDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailRequestOrderDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailRequestOrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.detailRequestOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailRequestOrderDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.detailRequestOrderDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.detailRequestOrderDataGridView.Location = new System.Drawing.Point(0, 308);
            this.detailRequestOrderDataGridView.MultiSelect = false;
            this.detailRequestOrderDataGridView.Name = "detailRequestOrderDataGridView";
            this.detailRequestOrderDataGridView.RowHeadersVisible = false;
            this.detailRequestOrderDataGridView.Size = new System.Drawing.Size(894, 297);
            this.detailRequestOrderDataGridView.TabIndex = 39;
            this.detailRequestOrderDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.detailRequestOrderDataGridView_CellBeginEdit);
            this.detailRequestOrderDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellEndEdit);
            this.detailRequestOrderDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellEnter);
            this.detailRequestOrderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.detailRequestOrderDataGridView_CellFormatting);
            this.detailRequestOrderDataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellLeave);
            this.detailRequestOrderDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellValidated);
            this.detailRequestOrderDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellValueChanged);
            this.detailRequestOrderDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.detailRequestOrderDataGridView_CurrentCellDirtyStateChanged);
            this.detailRequestOrderDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.detailRequestOrderDataGridView_RowsAdded);
            this.detailRequestOrderDataGridView.Enter += new System.EventHandler(this.detailRequestOrderDataGridView_Enter);
            this.detailRequestOrderDataGridView.Leave += new System.EventHandler(this.detailRequestOrderDataGridView_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(11, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "ASAL PERMINTAAN";
            this.label2.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(272, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = ":";
            // 
            // ROExpiredDateTimePicker
            // 
            this.ROExpiredDateTimePicker.Enabled = false;
            this.ROExpiredDateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROExpiredDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ROExpiredDateTimePicker.Location = new System.Drawing.Point(680, 73);
            this.ROExpiredDateTimePicker.Name = "ROExpiredDateTimePicker";
            this.ROExpiredDateTimePicker.Size = new System.Drawing.Size(149, 27);
            this.ROExpiredDateTimePicker.TabIndex = 23;
            this.ROExpiredDateTimePicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.ROExpiredDateTimePicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // RODateTimePicker
            // 
            this.RODateTimePicker.Enabled = false;
            this.RODateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RODateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RODateTimePicker.Location = new System.Drawing.Point(292, 76);
            this.RODateTimePicker.Name = "RODateTimePicker";
            this.RODateTimePicker.Size = new System.Drawing.Size(146, 27);
            this.RODateTimePicker.TabIndex = 22;
            this.RODateTimePicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.RODateTimePicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(476, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(178, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "TANGGAL EXPIRED";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(660, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = ":";
            // 
            // approveButton
            // 
            this.approveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.approveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveButton.Location = new System.Drawing.Point(27, 614);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(271, 37);
            this.approveButton.TabIndex = 41;
            this.approveButton.Text = "APPROVE SEBAGAI MUTASI";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(272, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = ":";
            this.label8.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(11, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "NO PERMINTAAN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(272, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = ":";
            // 
            // ROInvoiceTextBox
            // 
            this.ROInvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROInvoiceTextBox.Location = new System.Drawing.Point(292, 43);
            this.ROInvoiceTextBox.Name = "ROInvoiceTextBox";
            this.ROInvoiceTextBox.ReadOnly = true;
            this.ROInvoiceTextBox.Size = new System.Drawing.Size(179, 27);
            this.ROInvoiceTextBox.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(11, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "TANGGAL PERMINTAAN";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(9, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 29);
            this.label10.TabIndex = 42;
            this.label10.Text = "TOTAL";
            // 
            // createPOButton
            // 
            this.createPOButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.createPOButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPOButton.Location = new System.Drawing.Point(330, 614);
            this.createPOButton.Name = "createPOButton";
            this.createPOButton.Size = new System.Drawing.Size(248, 37);
            this.createPOButton.TabIndex = 38;
            this.createPOButton.Text = "IMPORT SEBAGAI PO";
            this.createPOButton.UseVisualStyleBackColor = true;
            this.createPOButton.Click += new System.EventHandler(this.createPOButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(11, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "ASAL PERMINTAAN";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(11, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(169, 18);
            this.label15.TabIndex = 25;
            this.label15.Text = "TANGGAL MUTASI";
            // 
            // PMDateTimePicker
            // 
            this.PMDateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PMDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PMDateTimePicker.Location = new System.Drawing.Point(292, 10);
            this.PMDateTimePicker.Name = "PMDateTimePicker";
            this.PMDateTimePicker.Size = new System.Drawing.Size(149, 27);
            this.PMDateTimePicker.TabIndex = 27;
            this.PMDateTimePicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.PMDateTimePicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // totalApproved
            // 
            this.totalApproved.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalApproved.AutoSize = true;
            this.totalApproved.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalApproved.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalApproved.Location = new System.Drawing.Point(307, 222);
            this.totalApproved.Name = "totalApproved";
            this.totalApproved.Size = new System.Drawing.Size(83, 29);
            this.totalApproved.TabIndex = 44;
            this.totalApproved.Text = "Rp. 0";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(272, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 18);
            this.label13.TabIndex = 45;
            this.label13.Text = ":";
            // 
            // totalApprovedLabel
            // 
            this.totalApprovedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalApprovedLabel.AutoSize = true;
            this.totalApprovedLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalApprovedLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalApprovedLabel.Location = new System.Drawing.Point(9, 222);
            this.totalApprovedLabel.Name = "totalApprovedLabel";
            this.totalApprovedLabel.Size = new System.Drawing.Size(255, 29);
            this.totalApprovedLabel.TabIndex = 44;
            this.totalApprovedLabel.Text = "TOTAL APPROVED";
            // 
            // branchToComboHidden
            // 
            this.branchToComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToComboHidden.FormattingEnabled = true;
            this.branchToComboHidden.Location = new System.Drawing.Point(619, 141);
            this.branchToComboHidden.Name = "branchToComboHidden";
            this.branchToComboHidden.Size = new System.Drawing.Size(211, 26);
            this.branchToComboHidden.TabIndex = 2;
            this.branchToComboHidden.Visible = false;
            // 
            // branchToCombo
            // 
            this.branchToCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToCombo.FormattingEnabled = true;
            this.branchToCombo.Location = new System.Drawing.Point(292, 141);
            this.branchToCombo.Name = "branchToCombo";
            this.branchToCombo.Size = new System.Drawing.Size(321, 26);
            this.branchToCombo.TabIndex = 1;
            this.branchToCombo.SelectedIndexChanged += new System.EventHandler(this.branchToCombo_SelectedIndexChanged);
            this.branchToCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchToCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // branchFromComboHidden
            // 
            this.branchFromComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromComboHidden.FormattingEnabled = true;
            this.branchFromComboHidden.Location = new System.Drawing.Point(619, 109);
            this.branchFromComboHidden.Name = "branchFromComboHidden";
            this.branchFromComboHidden.Size = new System.Drawing.Size(211, 26);
            this.branchFromComboHidden.TabIndex = 1;
            this.branchFromComboHidden.Visible = false;
            // 
            // branchFromCombo
            // 
            this.branchFromCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromCombo.FormattingEnabled = true;
            this.branchFromCombo.Location = new System.Drawing.Point(292, 109);
            this.branchFromCombo.Name = "branchFromCombo";
            this.branchFromCombo.Size = new System.Drawing.Size(321, 26);
            this.branchFromCombo.TabIndex = 0;
            this.branchFromCombo.Visible = false;
            this.branchFromCombo.SelectedIndexChanged += new System.EventHandler(this.branchFromCombo_SelectedIndexChanged);
            this.branchFromCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchFromCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalLabel.Location = new System.Drawing.Point(307, 182);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(83, 29);
            this.totalLabel.TabIndex = 43;
            this.totalLabel.Text = "Rp. 0";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(272, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 18);
            this.label12.TabIndex = 44;
            this.label12.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(272, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 18);
            this.label14.TabIndex = 48;
            this.label14.Text = ":";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 29);
            this.panel1.TabIndex = 37;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(7, 6);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 36;
            this.errorLabel.Text = "   ";
            // 
            // rejectButton
            // 
            this.rejectButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rejectButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectButton.Location = new System.Drawing.Point(607, 614);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(248, 37);
            this.rejectButton.TabIndex = 45;
            this.rejectButton.Text = "REJECT PERMINTAAN";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exportButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(330, 614);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(248, 37);
            this.exportButton.TabIndex = 46;
            this.exportButton.Text = "EXPORT DATA MUTASI";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // acceptedButton
            // 
            this.acceptedButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.acceptedButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptedButton.Location = new System.Drawing.Point(607, 614);
            this.acceptedButton.Name = "acceptedButton";
            this.acceptedButton.Size = new System.Drawing.Size(248, 37);
            this.acceptedButton.TabIndex = 47;
            this.acceptedButton.Text = "MUTASI DITERIMA";
            this.acceptedButton.UseVisualStyleBackColor = true;
            this.acceptedButton.Click += new System.EventHandler(this.acceptedButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.totalApproved);
            this.groupBox1.Controls.Add(this.branchToComboHidden);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.branchFromComboHidden);
            this.groupBox1.Controls.Add(this.totalApprovedLabel);
            this.groupBox1.Controls.Add(this.branchToCombo);
            this.groupBox1.Controls.Add(this.totalLabel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ROExpiredDateTimePicker);
            this.groupBox1.Controls.Add(this.branchFromCombo);
            this.groupBox1.Controls.Add(this.ROInvoiceTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.RODateTimePicker);
            this.groupBox1.Controls.Add(this.PMDateTimePicker);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(1, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 266);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(272, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 18);
            this.label11.TabIndex = 49;
            this.label11.Text = ":";
            // 
            // dataMutasiBarangDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(896, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.acceptedButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.createPOButton);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.detailRequestOrderDataGridView);
            this.Controls.Add(this.exportButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dataMutasiBarangDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRODUK MUTASI";
            this.Activated += new System.EventHandler(this.dataMutasiBarangDetailForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataMutasiBarangDetailForm_Deactivate);
            this.Load += new System.EventHandler(this.dataMutasiBarangDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailRequestOrderDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView detailRequestOrderDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ROInvoiceTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button createPOButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label totalApproved;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalApprovedLabel;
        private System.Windows.Forms.DateTimePicker RODateTimePicker;
        private System.Windows.Forms.DateTimePicker ROExpiredDateTimePicker;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker PMDateTimePicker;
        private System.Windows.Forms.ComboBox branchToCombo;
        private System.Windows.Forms.ComboBox branchFromCombo;
        private System.Windows.Forms.ComboBox branchToComboHidden;
        private System.Windows.Forms.ComboBox branchFromComboHidden;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button acceptedButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
    }
}