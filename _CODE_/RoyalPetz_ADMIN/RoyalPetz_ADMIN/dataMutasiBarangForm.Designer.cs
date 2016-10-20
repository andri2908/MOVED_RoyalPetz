namespace RoyalPetz_ADMIN
{
    partial class dataMutasiBarangForm
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
            this.newButton = new System.Windows.Forms.Button();
            this.noMutasiTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.branchToCombo = new System.Windows.Forms.ComboBox();
            this.branchFromCombo = new System.Windows.Forms.ComboBox();
            this.PMDtPicker_1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.PMDtPicker_2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.showAllCheckBox = new System.Windows.Forms.CheckBox();
            this.displayButton = new System.Windows.Forms.Button();
            this.branchToComboHidden = new System.Windows.Forms.ComboBox();
            this.branchFromComboHidden = new System.Windows.Forms.ComboBox();
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
            this.dataRequestOrderGridView.Location = new System.Drawing.Point(-1, 240);
            this.dataRequestOrderGridView.MultiSelect = false;
            this.dataRequestOrderGridView.Name = "dataRequestOrderGridView";
            this.dataRequestOrderGridView.RowHeadersVisible = false;
            this.dataRequestOrderGridView.Size = new System.Drawing.Size(940, 398);
            this.dataRequestOrderGridView.TabIndex = 33;
            this.dataRequestOrderGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            this.dataRequestOrderGridView.Enter += new System.EventHandler(this.dataRequestOrderGridView_Enter);
            this.dataRequestOrderGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataRequestOrderGridView_KeyDown);
            this.dataRequestOrderGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataRequestOrderGridView_KeyPress);
            this.dataRequestOrderGridView.Leave += new System.EventHandler(this.dataRequestOrderGridView_Leave);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(35, 177);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(144, 37);
            this.newButton.TabIndex = 34;
            this.newButton.Text = "NEW MUTASI";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // noMutasiTextBox
            // 
            this.noMutasiTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noMutasiTextBox.Location = new System.Drawing.Point(186, 21);
            this.noMutasiTextBox.Name = "noMutasiTextBox";
            this.noMutasiTextBox.Size = new System.Drawing.Size(260, 27);
            this.noMutasiTextBox.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tanggal Mutasi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Asal Mutasi";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FloralWhite;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 18);
            this.label4.TabIndex = 41;
            this.label4.Text = "Tujuan Mutasi";
            // 
            // branchToCombo
            // 
            this.branchToCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.branchToCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.branchToCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToCombo.FormattingEnabled = true;
            this.branchToCombo.Location = new System.Drawing.Point(186, 119);
            this.branchToCombo.Name = "branchToCombo";
            this.branchToCombo.Size = new System.Drawing.Size(321, 26);
            this.branchToCombo.TabIndex = 42;
            this.branchToCombo.SelectedIndexChanged += new System.EventHandler(this.branchToCombo_SelectedIndexChanged);
            this.branchToCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchToCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // branchFromCombo
            // 
            this.branchFromCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.branchFromCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.branchFromCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromCombo.FormattingEnabled = true;
            this.branchFromCombo.Location = new System.Drawing.Point(186, 87);
            this.branchFromCombo.Name = "branchFromCombo";
            this.branchFromCombo.Size = new System.Drawing.Size(321, 26);
            this.branchFromCombo.TabIndex = 40;
            this.branchFromCombo.Visible = false;
            this.branchFromCombo.SelectedIndexChanged += new System.EventHandler(this.branchFromCombo_SelectedIndexChanged);
            this.branchFromCombo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.branchFromCombo.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // PMDtPicker_1
            // 
            this.PMDtPicker_1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PMDtPicker_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PMDtPicker_1.Location = new System.Drawing.Point(186, 54);
            this.PMDtPicker_1.Name = "PMDtPicker_1";
            this.PMDtPicker_1.Size = new System.Drawing.Size(146, 27);
            this.PMDtPicker_1.TabIndex = 38;
            this.PMDtPicker_1.Enter += new System.EventHandler(this.genericControl_Enter);
            this.PMDtPicker_1.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FloralWhite;
            this.label5.Location = new System.Drawing.Point(341, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "-";
            // 
            // PMDtPicker_2
            // 
            this.PMDtPicker_2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PMDtPicker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PMDtPicker_2.Location = new System.Drawing.Point(366, 54);
            this.PMDtPicker_2.Name = "PMDtPicker_2";
            this.PMDtPicker_2.Size = new System.Drawing.Size(150, 27);
            this.PMDtPicker_2.TabIndex = 43;
            this.PMDtPicker_2.Enter += new System.EventHandler(this.genericControl_Enter);
            this.PMDtPicker_2.Leave += new System.EventHandler(this.genericControl_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "No Mutasi";
            // 
            // showAllCheckBox
            // 
            this.showAllCheckBox.AutoSize = true;
            this.showAllCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.showAllCheckBox.Location = new System.Drawing.Point(186, 150);
            this.showAllCheckBox.Name = "showAllCheckBox";
            this.showAllCheckBox.Size = new System.Drawing.Size(101, 22);
            this.showAllCheckBox.TabIndex = 47;
            this.showAllCheckBox.Text = "Show All";
            this.showAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.displayButton.Location = new System.Drawing.Point(189, 177);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 52;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // branchToComboHidden
            // 
            this.branchToComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchToComboHidden.FormattingEnabled = true;
            this.branchToComboHidden.Location = new System.Drawing.Point(314, 305);
            this.branchToComboHidden.Name = "branchToComboHidden";
            this.branchToComboHidden.Size = new System.Drawing.Size(311, 26);
            this.branchToComboHidden.TabIndex = 53;
            this.branchToComboHidden.Visible = false;
            // 
            // branchFromComboHidden
            // 
            this.branchFromComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.branchFromComboHidden.FormattingEnabled = true;
            this.branchFromComboHidden.Location = new System.Drawing.Point(314, 263);
            this.branchFromComboHidden.Name = "branchFromComboHidden";
            this.branchFromComboHidden.Size = new System.Drawing.Size(311, 26);
            this.branchFromComboHidden.TabIndex = 54;
            this.branchFromComboHidden.Visible = false;
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.importButton.Location = new System.Drawing.Point(294, 177);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(224, 37);
            this.importButton.TabIndex = 55;
            this.importButton.Text = "IMPORT DATA MUTASI";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PMDtPicker_2);
            this.groupBox1.Controls.Add(this.importButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.branchToCombo);
            this.groupBox1.Controls.Add(this.showAllCheckBox);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.displayButton);
            this.groupBox1.Controls.Add(this.PMDtPicker_1);
            this.groupBox1.Controls.Add(this.branchFromCombo);
            this.groupBox1.Controls.Add(this.noMutasiTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(193, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 222);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // dataMutasiBarangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(938, 637);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.branchFromComboHidden);
            this.Controls.Add(this.branchToComboHidden);
            this.Controls.Add(this.dataRequestOrderGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataMutasiBarangForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MUTASI BARANG";
            this.Activated += new System.EventHandler(this.dataMutasiBarangForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataMutasiBarangForm_Deactivate);
            this.Load += new System.EventHandler(this.dataMutasiBarangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataRequestOrderGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataRequestOrderGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.TextBox noMutasiTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox branchToCombo;
        private System.Windows.Forms.ComboBox branchFromCombo;
        private System.Windows.Forms.DateTimePicker PMDtPicker_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker PMDtPicker_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showAllCheckBox;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.ComboBox branchToComboHidden;
        private System.Windows.Forms.ComboBox branchFromComboHidden;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}