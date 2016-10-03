namespace RoyalPetz_ADMIN
{
    partial class permintaanProdukForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.ROinvoiceTextBox = new System.Windows.Forms.TextBox();
            this.deactivateButton = new System.Windows.Forms.Button();
            this.RODateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.branchFromComboHidden = new System.Windows.Forms.ComboBox();
            this.branchFromCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.branchToComboHidden = new System.Windows.Forms.ComboBox();
            this.branchToCombo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.detailRequestOrderDataGridView = new System.Windows.Forms.DataGridView();
            this.exportButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailRequestOrderDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 29);
            this.panel1.TabIndex = 25;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 7);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 35;
            this.errorLabel.Text = "   ";
            // 
            // ROinvoiceTextBox
            // 
            this.ROinvoiceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ROinvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROinvoiceTextBox.Location = new System.Drawing.Point(267, 13);
            this.ROinvoiceTextBox.Name = "ROinvoiceTextBox";
            this.ROinvoiceTextBox.Size = new System.Drawing.Size(166, 27);
            this.ROinvoiceTextBox.TabIndex = 43;
            this.ROinvoiceTextBox.TextChanged += new System.EventHandler(this.ROinvoiceTextBox_TextChanged);
            // 
            // deactivateButton
            // 
            this.deactivateButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deactivateButton.Location = new System.Drawing.Point(439, 13);
            this.deactivateButton.Name = "deactivateButton";
            this.deactivateButton.Size = new System.Drawing.Size(248, 29);
            this.deactivateButton.TabIndex = 43;
            this.deactivateButton.Text = "SET NON ACTIVE";
            this.deactivateButton.UseVisualStyleBackColor = true;
            this.deactivateButton.Click += new System.EventHandler(this.deactivateButton_Click);
            // 
            // RODateTimePicker
            // 
            this.RODateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RODateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RODateTimePicker.Location = new System.Drawing.Point(267, 46);
            this.RODateTimePicker.Name = "RODateTimePicker";
            this.RODateTimePicker.Size = new System.Drawing.Size(166, 27);
            this.RODateTimePicker.TabIndex = 21;
            this.RODateTimePicker.Enter += new System.EventHandler(this.genericControl_Enter);
            this.RODateTimePicker.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(6, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(219, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "TANGGAL PERMINTAAN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(249, 117);
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
            this.label1.Location = new System.Drawing.Point(6, 16);
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
            this.label4.Location = new System.Drawing.Point(249, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = ":";
            // 
            // branchFromComboHidden
            // 
            this.branchFromComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromComboHidden.FormattingEnabled = true;
            this.branchFromComboHidden.Location = new System.Drawing.Point(618, 114);
            this.branchFromComboHidden.Name = "branchFromComboHidden";
            this.branchFromComboHidden.Size = new System.Drawing.Size(266, 26);
            this.branchFromComboHidden.TabIndex = 19;
            this.branchFromComboHidden.Visible = false;
            // 
            // branchFromCombo
            // 
            this.branchFromCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.branchFromCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.branchFromCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromCombo.FormattingEnabled = true;
            this.branchFromCombo.Location = new System.Drawing.Point(267, 114);
            this.branchFromCombo.Name = "branchFromCombo";
            this.branchFromCombo.Size = new System.Drawing.Size(345, 26);
            this.branchFromCombo.TabIndex = 18;
            this.branchFromCombo.Visible = false;
            this.branchFromCombo.SelectedIndexChanged += new System.EventHandler(this.branchFromCombo_SelectedIndexChanged);
            this.branchFromCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchFromCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            this.branchFromCombo.Validated += new System.EventHandler(this.branchFromCombo_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(249, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = ":";
            this.label5.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(7, 117);
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
            this.label6.Location = new System.Drawing.Point(249, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(4, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 29);
            this.label10.TabIndex = 35;
            this.label10.Text = "TOTAL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(247, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 29);
            this.label12.TabIndex = 37;
            this.label12.Text = ":";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalLabel.Location = new System.Drawing.Point(262, 182);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(83, 29);
            this.totalLabel.TabIndex = 36;
            this.totalLabel.Text = "Rp. 0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(6, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 18);
            this.label13.TabIndex = 38;
            this.label13.Text = "MASA BERLAKU";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(327, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 18);
            this.label15.TabIndex = 44;
            this.label15.Text = "hari";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationTextBox.Location = new System.Drawing.Point(267, 81);
            this.durationTextBox.Mask = "000";
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(54, 27);
            this.durationTextBox.TabIndex = 43;
            this.durationTextBox.Text = "0";
            this.durationTextBox.Enter += new System.EventHandler(this.durationTextBox_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(6, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "TUJUAN PERMINTAAN";
            this.label3.Visible = false;
            // 
            // branchToComboHidden
            // 
            this.branchToComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToComboHidden.FormattingEnabled = true;
            this.branchToComboHidden.Location = new System.Drawing.Point(617, 146);
            this.branchToComboHidden.Name = "branchToComboHidden";
            this.branchToComboHidden.Size = new System.Drawing.Size(267, 26);
            this.branchToComboHidden.TabIndex = 22;
            this.branchToComboHidden.Visible = false;
            // 
            // branchToCombo
            // 
            this.branchToCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.branchToCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.branchToCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToCombo.FormattingEnabled = true;
            this.branchToCombo.Location = new System.Drawing.Point(267, 146);
            this.branchToCombo.Name = "branchToCombo";
            this.branchToCombo.Size = new System.Drawing.Size(342, 26);
            this.branchToCombo.TabIndex = 21;
            this.branchToCombo.Visible = false;
            this.branchToCombo.SelectedIndexChanged += new System.EventHandler(this.branchToCombo_SelectedIndexChanged);
            this.branchToCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchToCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            this.branchToCombo.Validated += new System.EventHandler(this.branchToCombo_Validated);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(249, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 18);
            this.label14.TabIndex = 39;
            this.label14.Text = ":";
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.generateButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(288, 618);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(248, 37);
            this.generateButton.TabIndex = 31;
            this.generateButton.Text = "KIRIM REQUEST ORDER";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // detailRequestOrderDataGridView
            // 
            this.detailRequestOrderDataGridView.AllowUserToDeleteRows = false;
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
            this.detailRequestOrderDataGridView.Location = new System.Drawing.Point(5, 271);
            this.detailRequestOrderDataGridView.Name = "detailRequestOrderDataGridView";
            this.detailRequestOrderDataGridView.RowHeadersVisible = false;
            this.detailRequestOrderDataGridView.Size = new System.Drawing.Size(888, 340);
            this.detailRequestOrderDataGridView.TabIndex = 32;
            this.detailRequestOrderDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.detailRequestOrderDataGridView_CellBeginEdit);
            this.detailRequestOrderDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellEndEdit);
            this.detailRequestOrderDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.detailRequestOrderDataGridView_CellFormatting);
            this.detailRequestOrderDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellValidated);
            this.detailRequestOrderDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailRequestOrderDataGridView_CellValueChanged);
            this.detailRequestOrderDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.detailRequestOrderDataGridView_CurrentCellDirtyStateChanged);
            this.detailRequestOrderDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.detailRequestOrderDataGridView_RowsAdded);
            this.detailRequestOrderDataGridView.Enter += new System.EventHandler(this.detailRequestOrderDataGridView_Enter);
            this.detailRequestOrderDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailRequestOrderDataGridView_KeyDown);
            this.detailRequestOrderDataGridView.Leave += new System.EventHandler(this.detailRequestOrderDataGridView_Leave);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exportButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportButton.Location = new System.Drawing.Point(569, 618);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(305, 37);
            this.exportButton.TabIndex = 33;
            this.exportButton.Text = "EXPORT REQUEST ORDER";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(32, 618);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(226, 37);
            this.saveButton.TabIndex = 34;
            this.saveButton.Text = "SAVE REQUEST ORDER";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.branchToComboHidden);
            this.groupBox1.Controls.Add(this.totalLabel);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.branchToCombo);
            this.groupBox1.Controls.Add(this.branchFromComboHidden);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.branchFromCombo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.durationTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.deactivateButton);
            this.groupBox1.Controls.Add(this.RODateTimePicker);
            this.groupBox1.Controls.Add(this.ROinvoiceTextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(5, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 228);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            // 
            // permintaanProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(901, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.detailRequestOrderDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "permintaanProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PERMINTAAN PRODUK";
            this.Activated += new System.EventHandler(this.permintaanProdukForm_Activated);
            this.Deactivate += new System.EventHandler(this.permintaanProdukForm_Deactivate);
            this.Load += new System.EventHandler(this.permintaanProdukForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailRequestOrderDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox branchFromCombo;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox branchToCombo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView detailRequestOrderDataGridView;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox durationTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker RODateTimePicker;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.ComboBox branchToComboHidden;
        private System.Windows.Forms.ComboBox branchFromComboHidden;
        private System.Windows.Forms.TextBox ROinvoiceTextBox;
        private System.Windows.Forms.Button deactivateButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}