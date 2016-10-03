namespace RoyalPetz_ADMIN
{
    partial class pembayaranPiutangForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pembayaranPiutangForm));
            this.invoiceNoTextBox = new System.Windows.Forms.TextBox();
            this.detailPaymentInfoDataGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.confirmBayar = new System.Windows.Forms.ToolStripMenuItem();
            this.invalidPayment = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.paymentMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.detailSalesOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cairDTPicker = new System.Windows.Forms.DateTimePicker();
            this.paymentCombo = new System.Windows.Forms.ComboBox();
            this.labelCair = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pelangganNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.paymentDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.invoiceDateTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detailPaymentInfoDataGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailSalesOrderDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // invoiceNoTextBox
            // 
            this.invoiceNoTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceNoTextBox.Location = new System.Drawing.Point(241, 43);
            this.invoiceNoTextBox.Name = "invoiceNoTextBox";
            this.invoiceNoTextBox.ReadOnly = true;
            this.invoiceNoTextBox.Size = new System.Drawing.Size(226, 27);
            this.invoiceNoTextBox.TabIndex = 16;
            // 
            // detailPaymentInfoDataGrid
            // 
            this.detailPaymentInfoDataGrid.AllowUserToAddRows = false;
            this.detailPaymentInfoDataGrid.AllowUserToDeleteRows = false;
            this.detailPaymentInfoDataGrid.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailPaymentInfoDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.detailPaymentInfoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.detailPaymentInfoDataGrid.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailPaymentInfoDataGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.detailPaymentInfoDataGrid.Location = new System.Drawing.Point(3, 450);
            this.detailPaymentInfoDataGrid.MultiSelect = false;
            this.detailPaymentInfoDataGrid.Name = "detailPaymentInfoDataGrid";
            this.detailPaymentInfoDataGrid.ReadOnly = true;
            this.detailPaymentInfoDataGrid.RowHeadersVisible = false;
            this.detailPaymentInfoDataGrid.Size = new System.Drawing.Size(889, 151);
            this.detailPaymentInfoDataGrid.TabIndex = 62;
            this.detailPaymentInfoDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailPaymentInfoDataGrid_KeyDown);
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
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(221, 186);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 18);
            this.label13.TabIndex = 58;
            this.label13.Text = ":";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.descriptionTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.descriptionTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(241, 215);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(642, 27);
            this.descriptionTextBox.TabIndex = 58;
            // 
            // paymentMaskedTextBox
            // 
            this.paymentMaskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.paymentMaskedTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMaskedTextBox.Location = new System.Drawing.Point(241, 182);
            this.paymentMaskedTextBox.Mask = "00000000000";
            this.paymentMaskedTextBox.Name = "paymentMaskedTextBox";
            this.paymentMaskedTextBox.Size = new System.Drawing.Size(226, 27);
            this.paymentMaskedTextBox.TabIndex = 57;
            this.paymentMaskedTextBox.Text = "0";
            this.paymentMaskedTextBox.ValidatingType = typeof(int);
            this.paymentMaskedTextBox.TextChanged += new System.EventHandler(this.paymentMaskedTextBox_TextChanged);
            this.paymentMaskedTextBox.Enter += new System.EventHandler(this.paymentMaskedTextBox_Enter);
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalLabel.Location = new System.Drawing.Point(236, 112);
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
            this.label14.Location = new System.Drawing.Point(9, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 18);
            this.label14.TabIndex = 59;
            this.label14.Text = "PELANGGAN";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(221, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 18);
            this.label15.TabIndex = 60;
            this.label15.Text = ":";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(889, 29);
            this.panel1.TabIndex = 59;
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
            // detailSalesOrderDataGridView
            // 
            this.detailSalesOrderDataGridView.AllowUserToAddRows = false;
            this.detailSalesOrderDataGridView.AllowUserToDeleteRows = false;
            this.detailSalesOrderDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailSalesOrderDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.detailSalesOrderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailSalesOrderDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.detailSalesOrderDataGridView.Location = new System.Drawing.Point(4, 303);
            this.detailSalesOrderDataGridView.Name = "detailSalesOrderDataGridView";
            this.detailSalesOrderDataGridView.ReadOnly = true;
            this.detailSalesOrderDataGridView.RowHeadersVisible = false;
            this.detailSalesOrderDataGridView.Size = new System.Drawing.Size(888, 141);
            this.detailSalesOrderDataGridView.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(527, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "TANGGAL INVOICE :";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(304, 612);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(122, 37);
            this.saveButton.TabIndex = 61;
            this.saveButton.Text = "SAVE ";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cairDTPicker
            // 
            this.cairDTPicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cairDTPicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cairDTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cairDTPicker.Location = new System.Drawing.Point(706, 182);
            this.cairDTPicker.Name = "cairDTPicker";
            this.cairDTPicker.Size = new System.Drawing.Size(177, 27);
            this.cairDTPicker.TabIndex = 59;
            this.cairDTPicker.Visible = false;
            this.cairDTPicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.cairDTPicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // paymentCombo
            // 
            this.paymentCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.paymentCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.paymentCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.paymentCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentCombo.FormattingEnabled = true;
            this.paymentCombo.Location = new System.Drawing.Point(241, 150);
            this.paymentCombo.Name = "paymentCombo";
            this.paymentCombo.Size = new System.Drawing.Size(226, 26);
            this.paymentCombo.TabIndex = 63;
            this.paymentCombo.SelectedIndexChanged += new System.EventHandler(this.paymentCombo_SelectedIndexChanged);
            this.paymentCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.paymentCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // labelCair
            // 
            this.labelCair.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCair.AutoSize = true;
            this.labelCair.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCair.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelCair.Location = new System.Drawing.Point(596, 188);
            this.labelCair.Name = "labelCair";
            this.labelCair.Size = new System.Drawing.Size(104, 18);
            this.labelCair.TabIndex = 58;
            this.labelCair.Text = "TGL CAIR :";
            this.labelCair.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(9, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 18);
            this.label11.TabIndex = 20;
            this.label11.Text = "TGL PEMBAYARAN ";
            // 
            // pelangganNameTextBox
            // 
            this.pelangganNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pelangganNameTextBox.Location = new System.Drawing.Point(241, 76);
            this.pelangganNameTextBox.Name = "pelangganNameTextBox";
            this.pelangganNameTextBox.ReadOnly = true;
            this.pelangganNameTextBox.Size = new System.Drawing.Size(319, 27);
            this.pelangganNameTextBox.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(221, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "NO INVOICE";
            // 
            // paymentDateTimePicker
            // 
            this.paymentDateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.paymentDateTimePicker.Location = new System.Drawing.Point(241, 10);
            this.paymentDateTimePicker.Name = "paymentDateTimePicker";
            this.paymentDateTimePicker.Size = new System.Drawing.Size(226, 27);
            this.paymentDateTimePicker.TabIndex = 56;
            this.paymentDateTimePicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.paymentDateTimePicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // invoiceDateTextBox
            // 
            this.invoiceDateTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invoiceDateTextBox.Location = new System.Drawing.Point(720, 49);
            this.invoiceDateTextBox.Name = "invoiceDateTextBox";
            this.invoiceDateTextBox.ReadOnly = true;
            this.invoiceDateTextBox.Size = new System.Drawing.Size(159, 27);
            this.invoiceDateTextBox.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(221, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 52;
            this.label5.Text = ":";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(221, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 64;
            this.label8.Text = ":";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(9, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 29);
            this.label3.TabIndex = 51;
            this.label3.Text = "TOTAL";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(9, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 18);
            this.label7.TabIndex = 63;
            this.label7.Text = "TOTAL PEMBAYARAN";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(9, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(213, 18);
            this.label10.TabIndex = 65;
            this.label10.Text = "METODE PEMBAYARAN";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(221, 153);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 18);
            this.label16.TabIndex = 66;
            this.label16.Text = ":";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "DESKRIPSI";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printButton
            // 
            this.printButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.printButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printButton.Location = new System.Drawing.Point(432, 612);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(159, 37);
            this.printButton.TabIndex = 63;
            this.printButton.Text = "PRINT RECEIPT";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.descriptionTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cairDTPicker);
            this.groupBox1.Controls.Add(this.pelangganNameTextBox);
            this.groupBox1.Controls.Add(this.labelCair);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.paymentCombo);
            this.groupBox1.Controls.Add(this.paymentMaskedTextBox);
            this.groupBox1.Controls.Add(this.invoiceDateTextBox);
            this.groupBox1.Controls.Add(this.totalLabel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.invoiceNoTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.paymentDateTimePicker);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(3, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 260);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(221, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 57;
            this.label4.Text = ":";
            // 
            // pembayaranPiutangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(894, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.detailPaymentInfoDataGrid);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.detailSalesOrderDataGridView);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "pembayaranPiutangForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PEMBAYARAN PIUTANG";
            this.Activated += new System.EventHandler(this.pembayaranPiutangForm_Activated);
            this.Deactivate += new System.EventHandler(this.pembayaranPiutangForm_Deactivate);
            this.Load += new System.EventHandler(this.pembayaranPiutangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailPaymentInfoDataGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailSalesOrderDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox invoiceNoTextBox;
        private System.Windows.Forms.DataGridView detailPaymentInfoDataGrid;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.MaskedTextBox paymentMaskedTextBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView detailSalesOrderDataGridView;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox pelangganNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox invoiceDateTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.DateTimePicker paymentDateTimePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox paymentCombo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem confirmBayar;
        private System.Windows.Forms.ToolStripMenuItem invalidPayment;
        private System.Windows.Forms.DateTimePicker cairDTPicker;
        private System.Windows.Forms.Label labelCair;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
    }
}