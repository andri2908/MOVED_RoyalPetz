namespace AlphaSoft
{
    partial class dataInvoiceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.noInvoiceTextBox = new System.Windows.Forms.TextBox();
            this.dataInvoiceDataGridView = new System.Windows.Forms.DataGridView();
            this.displayButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pelangganCombo = new System.Windows.Forms.ComboBox();
            this.pelangganComboHidden = new System.Windows.Forms.ComboBox();
            this.showAllCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataInvoiceDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "NO INVOICE";
            // 
            // noInvoiceTextBox
            // 
            this.noInvoiceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.noInvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noInvoiceTextBox.Location = new System.Drawing.Point(153, 21);
            this.noInvoiceTextBox.Name = "noInvoiceTextBox";
            this.noInvoiceTextBox.Size = new System.Drawing.Size(260, 27);
            this.noInvoiceTextBox.TabIndex = 36;
            // 
            // dataInvoiceDataGridView
            // 
            this.dataInvoiceDataGridView.AllowUserToAddRows = false;
            this.dataInvoiceDataGridView.AllowUserToDeleteRows = false;
            this.dataInvoiceDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataInvoiceDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataInvoiceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataInvoiceDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataInvoiceDataGridView.Location = new System.Drawing.Point(0, 135);
            this.dataInvoiceDataGridView.MultiSelect = false;
            this.dataInvoiceDataGridView.Name = "dataInvoiceDataGridView";
            this.dataInvoiceDataGridView.RowHeadersVisible = false;
            this.dataInvoiceDataGridView.Size = new System.Drawing.Size(602, 450);
            this.dataInvoiceDataGridView.TabIndex = 33;
            this.dataInvoiceDataGridView.DoubleClick += new System.EventHandler(this.dataInvoiceDataGridView_DoubleClick);
            this.dataInvoiceDataGridView.Enter += new System.EventHandler(this.dataInvoiceDataGridView_Enter);
            this.dataInvoiceDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataInvoiceDataGridView_KeyDown);
            this.dataInvoiceDataGridView.Leave += new System.EventHandler(this.dataInvoiceDataGridView_Leave);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.displayButton.Location = new System.Drawing.Point(428, 21);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 60);
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
            this.label2.Location = new System.Drawing.Point(14, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "PELANGGAN";
            // 
            // pelangganCombo
            // 
            this.pelangganCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pelangganCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pelangganCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pelangganCombo.FormattingEnabled = true;
            this.pelangganCombo.Location = new System.Drawing.Point(153, 55);
            this.pelangganCombo.Name = "pelangganCombo";
            this.pelangganCombo.Size = new System.Drawing.Size(260, 26);
            this.pelangganCombo.TabIndex = 46;
            this.pelangganCombo.SelectedIndexChanged += new System.EventHandler(this.pelangganCombo_SelectedIndexChanged);
            this.pelangganCombo.Enter += new System.EventHandler(this.pelangganCombo_Enter);
            this.pelangganCombo.Leave += new System.EventHandler(this.pelangganCombo_Leave);
            this.pelangganCombo.Validated += new System.EventHandler(this.pelangganCombo_Validated);
            // 
            // pelangganComboHidden
            // 
            this.pelangganComboHidden.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pelangganComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pelangganComboHidden.FormattingEnabled = true;
            this.pelangganComboHidden.Location = new System.Drawing.Point(290, 211);
            this.pelangganComboHidden.Name = "pelangganComboHidden";
            this.pelangganComboHidden.Size = new System.Drawing.Size(260, 26);
            this.pelangganComboHidden.TabIndex = 47;
            this.pelangganComboHidden.Visible = false;
            // 
            // showAllCheckBox
            // 
            this.showAllCheckBox.AutoSize = true;
            this.showAllCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.showAllCheckBox.Location = new System.Drawing.Point(153, 84);
            this.showAllCheckBox.Name = "showAllCheckBox";
            this.showAllCheckBox.Size = new System.Drawing.Size(101, 22);
            this.showAllCheckBox.TabIndex = 48;
            this.showAllCheckBox.Text = "Show All";
            this.showAllCheckBox.UseVisualStyleBackColor = true;
            this.showAllCheckBox.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.showAllCheckBox);
            this.groupBox1.Controls.Add(this.noInvoiceTextBox);
            this.groupBox1.Controls.Add(this.displayButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pelangganCombo);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(32, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 117);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // dataInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 586);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pelangganComboHidden);
            this.Controls.Add(this.dataInvoiceDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataInvoiceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA INVOICE";
            this.Activated += new System.EventHandler(this.dataInvoiceForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataInvoiceForm_Deactivate);
            this.Load += new System.EventHandler(this.dataInvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataInvoiceDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox noInvoiceTextBox;
        private System.Windows.Forms.DataGridView dataInvoiceDataGridView;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox pelangganCombo;
        private System.Windows.Forms.ComboBox pelangganComboHidden;
        private System.Windows.Forms.CheckBox showAllCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}