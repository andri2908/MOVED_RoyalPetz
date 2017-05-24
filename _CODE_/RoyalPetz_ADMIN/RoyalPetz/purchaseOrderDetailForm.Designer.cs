namespace AlphaSoft
{
    partial class purchaseOrderDetailForm
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
            this.supplierHiddenCombo = new System.Windows.Forms.ComboBox();
            this.supplierCombo = new System.Windows.Forms.ComboBox();
            this.PODateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.MaskedTextBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.POinvoiceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.detailPODataGridView = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.termOfPaymentCombo = new System.Windows.Forms.ComboBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.detailPODataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // supplierHiddenCombo
            // 
            this.supplierHiddenCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierHiddenCombo.FormattingEnabled = true;
            this.supplierHiddenCombo.Location = new System.Drawing.Point(613, 52);
            this.supplierHiddenCombo.Name = "supplierHiddenCombo";
            this.supplierHiddenCombo.Size = new System.Drawing.Size(278, 26);
            this.supplierHiddenCombo.TabIndex = 19;
            this.supplierHiddenCombo.Visible = false;
            // 
            // supplierCombo
            // 
            this.supplierCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supplierCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supplierCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCombo.FormattingEnabled = true;
            this.supplierCombo.Location = new System.Drawing.Point(262, 52);
            this.supplierCombo.Name = "supplierCombo";
            this.supplierCombo.Size = new System.Drawing.Size(345, 26);
            this.supplierCombo.TabIndex = 18;
            this.supplierCombo.SelectedIndexChanged += new System.EventHandler(this.supplierCombo_SelectedIndexChanged);
            this.supplierCombo.Validated += new System.EventHandler(this.supplierCombo_Validated);
            // 
            // PODateTimePicker
            // 
            this.PODateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODateTimePicker.Location = new System.Drawing.Point(718, 19);
            this.PODateTimePicker.Name = "PODateTimePicker";
            this.PODateTimePicker.Size = new System.Drawing.Size(173, 27);
            this.PODateTimePicker.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(577, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "TANGGAL PO :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(322, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 18);
            this.label15.TabIndex = 44;
            this.label15.Text = "hari";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationTextBox.Location = new System.Drawing.Point(262, 116);
            this.durationTextBox.Mask = "000";
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(54, 27);
            this.durationTextBox.TabIndex = 43;
            this.durationTextBox.Text = "0";
            this.durationTextBox.Enter += new System.EventHandler(this.durationTextBox_Enter);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.generateButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateButton.Location = new System.Drawing.Point(474, 619);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(248, 37);
            this.generateButton.TabIndex = 45;
            this.generateButton.Text = "PRINT PURCHASE ORDER";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(242, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 18);
            this.label14.TabIndex = 39;
            this.label14.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(10, 122);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(186, 18);
            this.label13.TabIndex = 38;
            this.label13.Text = "LAMA PEMBAYARAN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(242, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = ":";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "NO PURCHASE ORDER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(242, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = ":";
            // 
            // POinvoiceTextBox
            // 
            this.POinvoiceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.POinvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POinvoiceTextBox.Location = new System.Drawing.Point(262, 19);
            this.POinvoiceTextBox.Name = "POinvoiceTextBox";
            this.POinvoiceTextBox.Size = new System.Drawing.Size(171, 27);
            this.POinvoiceTextBox.TabIndex = 16;
            this.POinvoiceTextBox.TextChanged += new System.EventHandler(this.POinvoiceTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(242, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = ":";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(157, 619);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(265, 37);
            this.saveButton.TabIndex = 48;
            this.saveButton.Text = "SAVE PURCHASE ORDER";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // detailPODataGridView
            // 
            this.detailPODataGridView.AllowUserToDeleteRows = false;
            this.detailPODataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPODataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.detailPODataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.detailPODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.detailPODataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.detailPODataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.detailPODataGridView.Location = new System.Drawing.Point(5, 244);
            this.detailPODataGridView.Name = "detailPODataGridView";
            this.detailPODataGridView.RowHeadersVisible = false;
            this.detailPODataGridView.Size = new System.Drawing.Size(888, 369);
            this.detailPODataGridView.TabIndex = 46;
            this.detailPODataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.detailPODataGridView_CellBeginEdit);
            this.detailPODataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailPODataGridView_CellEndEdit);
            this.detailPODataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.detailPODataGridView_CellFormatting);
            this.detailPODataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.detailPODataGridView_CellValueChanged);
            this.detailPODataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.detailPODataGridView_CurrentCellDirtyStateChanged);
            this.detailPODataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.detailPODataGridView_RowsAdded);
            this.detailPODataGridView.Enter += new System.EventHandler(this.detailPODataGridView_Enter);
            this.detailPODataGridView.Leave += new System.EventHandler(this.detailPODataGridView_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(8, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 29);
            this.label10.TabIndex = 35;
            this.label10.Text = "TOTAL";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(242, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 18);
            this.label12.TabIndex = 37;
            this.label12.Text = ":";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.totalLabel.Location = new System.Drawing.Point(257, 156);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(83, 29);
            this.totalLabel.TabIndex = 36;
            this.totalLabel.Text = "Rp. 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(10, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "MODE PEMBAYARAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "SUPPLIER";
            // 
            // termOfPaymentCombo
            // 
            this.termOfPaymentCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.termOfPaymentCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.termOfPaymentCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.termOfPaymentCombo.FormattingEnabled = true;
            this.termOfPaymentCombo.Items.AddRange(new object[] {
            "TUNAI",
            "KREDIT"});
            this.termOfPaymentCombo.Location = new System.Drawing.Point(262, 84);
            this.termOfPaymentCombo.Name = "termOfPaymentCombo";
            this.termOfPaymentCombo.Size = new System.Drawing.Size(171, 26);
            this.termOfPaymentCombo.TabIndex = 21;
            this.termOfPaymentCombo.SelectedIndexChanged += new System.EventHandler(this.termOfPaymentCombo_SelectedIndexChanged);
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 29);
            this.panel1.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.termOfPaymentCombo);
            this.groupBox1.Controls.Add(this.durationTextBox);
            this.groupBox1.Controls.Add(this.supplierHiddenCombo);
            this.groupBox1.Controls.Add(this.PODateTimePicker);
            this.groupBox1.Controls.Add(this.supplierCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.POinvoiceTextBox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.totalLabel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(2, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(897, 201);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(611, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 18);
            this.label6.TabIndex = 65;
            this.label6.Text = "UKURAN KERTAS";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1/2 KUARTO",
            "KUARTO"});
            this.comboBox1.Location = new System.Drawing.Point(613, 114);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 26);
            this.comboBox1.TabIndex = 64;
            this.comboBox1.Text = "1/2 KUARTO";
            // 
            // purchaseOrderDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(901, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.detailPODataGridView);
            this.Name = "purchaseOrderDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PURCHASE ORDER DETAIL";
            this.Activated += new System.EventHandler(this.purchaseOrderDetailForm_Activated);
            this.Deactivate += new System.EventHandler(this.purchaseOrderDetailForm_Deactivate);
            this.Load += new System.EventHandler(this.purchaseOrderDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detailPODataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox supplierHiddenCombo;
        private System.Windows.Forms.ComboBox supplierCombo;
        private System.Windows.Forms.DateTimePicker PODateTimePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox durationTextBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox POinvoiceTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView detailPODataGridView;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox termOfPaymentCombo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}