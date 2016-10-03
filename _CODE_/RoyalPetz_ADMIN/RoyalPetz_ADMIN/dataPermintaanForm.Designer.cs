namespace RoyalPetz_ADMIN
{
    partial class dataPermintaanForm
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
            this.dataRequestOrderGridView = new System.Windows.Forms.DataGridView();
            this.displayButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RODtPicker_1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.branchFromCombo = new System.Windows.Forms.ComboBox();
            this.branchToCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RODtPicker_2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.showAllCheckBox = new System.Windows.Forms.CheckBox();
            this.branchFromHiddenCombo = new System.Windows.Forms.ComboBox();
            this.branchToHiddenCombo = new System.Windows.Forms.ComboBox();
            this.noROInvoiceTextBox = new System.Windows.Forms.TextBox();
            this.showExpiredCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataRequestOrderGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataRequestOrderGridView
            // 
            this.dataRequestOrderGridView.AllowUserToAddRows = false;
            this.dataRequestOrderGridView.AllowUserToDeleteRows = false;
            this.dataRequestOrderGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataRequestOrderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataRequestOrderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataRequestOrderGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataRequestOrderGridView.Location = new System.Drawing.Point(0, 198);
            this.dataRequestOrderGridView.MultiSelect = false;
            this.dataRequestOrderGridView.Name = "dataRequestOrderGridView";
            this.dataRequestOrderGridView.RowHeadersVisible = false;
            this.dataRequestOrderGridView.Size = new System.Drawing.Size(921, 440);
            this.dataRequestOrderGridView.TabIndex = 33;
            this.dataRequestOrderGridView.DoubleClick += new System.EventHandler(this.dataRequestOrderGridView_DoubleClick);
            this.dataRequestOrderGridView.Enter += new System.EventHandler(this.dataRequestOrderGridView_Enter);
            this.dataRequestOrderGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataRequestOrderGridView_KeyDown);
            this.dataRequestOrderGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataRequestOrderGridView_KeyPress);
            this.dataRequestOrderGridView.Leave += new System.EventHandler(this.dataRequestOrderGridView_Leave);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.displayButton.Location = new System.Drawing.Point(525, 21);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 34;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tanggal Permintaan";
            // 
            // RODtPicker_1
            // 
            this.RODtPicker_1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RODtPicker_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RODtPicker_1.Location = new System.Drawing.Point(195, 54);
            this.RODtPicker_1.Name = "RODtPicker_1";
            this.RODtPicker_1.Size = new System.Drawing.Size(151, 27);
            this.RODtPicker_1.TabIndex = 38;
            this.RODtPicker_1.Enter += new System.EventHandler(this.genericControl_Enter);
            this.RODtPicker_1.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Asal Permintaan";
            this.label3.Visible = false;
            // 
            // branchFromCombo
            // 
            this.branchFromCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.branchFromCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.branchFromCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromCombo.FormattingEnabled = true;
            this.branchFromCombo.Location = new System.Drawing.Point(195, 87);
            this.branchFromCombo.Name = "branchFromCombo";
            this.branchFromCombo.Size = new System.Drawing.Size(324, 26);
            this.branchFromCombo.TabIndex = 40;
            this.branchFromCombo.Visible = false;
            this.branchFromCombo.SelectedIndexChanged += new System.EventHandler(this.branchFromCombo_SelectedIndexChanged);
            this.branchFromCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchFromCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // branchToCombo
            // 
            this.branchToCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.branchToCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.branchToCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToCombo.FormattingEnabled = true;
            this.branchToCombo.Location = new System.Drawing.Point(195, 119);
            this.branchToCombo.Name = "branchToCombo";
            this.branchToCombo.Size = new System.Drawing.Size(324, 26);
            this.branchToCombo.TabIndex = 42;
            this.branchToCombo.SelectedIndexChanged += new System.EventHandler(this.branchToCombo_SelectedIndexChanged);
            this.branchToCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchToCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FloralWhite;
            this.label4.Location = new System.Drawing.Point(6, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "Tujuan Permintaan";
            // 
            // RODtPicker_2
            // 
            this.RODtPicker_2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RODtPicker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.RODtPicker_2.Location = new System.Drawing.Point(374, 53);
            this.RODtPicker_2.Name = "RODtPicker_2";
            this.RODtPicker_2.Size = new System.Drawing.Size(145, 27);
            this.RODtPicker_2.TabIndex = 43;
            this.RODtPicker_2.Enter += new System.EventHandler(this.genericControl_Enter);
            this.RODtPicker_2.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FloralWhite;
            this.label5.Location = new System.Drawing.Point(352, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "-";
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(525, 64);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(253, 37);
            this.newButton.TabIndex = 46;
            this.newButton.Text = "NEW REQUEST ORDER";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // showAllCheckBox
            // 
            this.showAllCheckBox.AutoSize = true;
            this.showAllCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.showAllCheckBox.Location = new System.Drawing.Point(418, 151);
            this.showAllCheckBox.Name = "showAllCheckBox";
            this.showAllCheckBox.Size = new System.Drawing.Size(101, 22);
            this.showAllCheckBox.TabIndex = 47;
            this.showAllCheckBox.Text = "Show All";
            this.showAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // branchFromHiddenCombo
            // 
            this.branchFromHiddenCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromHiddenCombo.FormattingEnabled = true;
            this.branchFromHiddenCombo.Location = new System.Drawing.Point(566, 274);
            this.branchFromHiddenCombo.Name = "branchFromHiddenCombo";
            this.branchFromHiddenCombo.Size = new System.Drawing.Size(311, 26);
            this.branchFromHiddenCombo.TabIndex = 48;
            this.branchFromHiddenCombo.Visible = false;
            // 
            // branchToHiddenCombo
            // 
            this.branchToHiddenCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToHiddenCombo.FormattingEnabled = true;
            this.branchToHiddenCombo.Location = new System.Drawing.Point(566, 306);
            this.branchToHiddenCombo.Name = "branchToHiddenCombo";
            this.branchToHiddenCombo.Size = new System.Drawing.Size(311, 26);
            this.branchToHiddenCombo.TabIndex = 49;
            this.branchToHiddenCombo.Visible = false;
            // 
            // noROInvoiceTextBox
            // 
            this.noROInvoiceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.noROInvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noROInvoiceTextBox.Location = new System.Drawing.Point(195, 21);
            this.noROInvoiceTextBox.Name = "noROInvoiceTextBox";
            this.noROInvoiceTextBox.Size = new System.Drawing.Size(324, 27);
            this.noROInvoiceTextBox.TabIndex = 36;
            // 
            // showExpiredCheckBox
            // 
            this.showExpiredCheckBox.AutoSize = true;
            this.showExpiredCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showExpiredCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.showExpiredCheckBox.Location = new System.Drawing.Point(195, 151);
            this.showExpiredCheckBox.Name = "showExpiredCheckBox";
            this.showExpiredCheckBox.Size = new System.Drawing.Size(180, 22);
            this.showExpiredCheckBox.TabIndex = 48;
            this.showExpiredCheckBox.Text = "Show Expired RO";
            this.showExpiredCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "No Permintaan";
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.importButton.Location = new System.Drawing.Point(525, 107);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(253, 37);
            this.importButton.TabIndex = 51;
            this.importButton.Text = "IMPORT REQUEST ORDER";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.showAllCheckBox);
            this.groupBox1.Controls.Add(this.showExpiredCheckBox);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.importButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.branchToCombo);
            this.groupBox1.Controls.Add(this.displayButton);
            this.groupBox1.Controls.Add(this.RODtPicker_2);
            this.groupBox1.Controls.Add(this.branchFromCombo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RODtPicker_1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.noROInvoiceTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(899, 180);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // dataPermintaanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(920, 637);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.branchToHiddenCombo);
            this.Controls.Add(this.branchFromHiddenCombo);
            this.Controls.Add(this.dataRequestOrderGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataPermintaanForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA PERMINTAAN";
            this.Activated += new System.EventHandler(this.dataPermintaanForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataPermintaanForm_Deactivate);
            this.Load += new System.EventHandler(this.dataPermintaanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataRequestOrderGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataRequestOrderGridView;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker RODtPicker_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox branchFromCombo;
        private System.Windows.Forms.ComboBox branchToCombo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker RODtPicker_2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox showAllCheckBox;
        private System.Windows.Forms.ComboBox branchFromHiddenCombo;
        private System.Windows.Forms.ComboBox branchToHiddenCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noROInvoiceTextBox;
        private System.Windows.Forms.CheckBox showExpiredCheckBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}