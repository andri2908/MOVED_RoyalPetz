namespace AlphaSoft
{
    partial class konversiSatuanForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.convertValueTextBox = new System.Windows.Forms.TextBox();
            this.unit2Combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.unit1Combo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.newButton = new System.Windows.Forms.Button();
            this.dataConvertGridView = new System.Windows.Forms.DataGridView();
            this.unit1ComboHidden = new System.Windows.Forms.ComboBox();
            this.unit2ComboHidden = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConvertGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.44177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.55823F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 228F));
            this.tableLayoutPanel1.Controls.Add(this.convertValueTextBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.unit2Combo, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.unit1Combo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.57426F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(701, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // convertValueTextBox
            // 
            this.convertValueTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.convertValueTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertValueTextBox.Location = new System.Drawing.Point(286, 11);
            this.convertValueTextBox.MaxLength = 13;
            this.convertValueTextBox.Name = "convertValueTextBox";
            this.convertValueTextBox.Size = new System.Drawing.Size(180, 27);
            this.convertValueTextBox.TabIndex = 43;
            this.convertValueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.convertValueTextBox.TextChanged += new System.EventHandler(this.convertValueTextBox_TextChanged);
            // 
            // unit2Combo
            // 
            this.unit2Combo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unit2Combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.unit2Combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.unit2Combo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unit2Combo.FormattingEnabled = true;
            this.unit2Combo.Location = new System.Drawing.Point(475, 12);
            this.unit2Combo.Name = "unit2Combo";
            this.unit2Combo.Size = new System.Drawing.Size(204, 26);
            this.unit2Combo.TabIndex = 35;
            this.unit2Combo.SelectedIndexChanged += new System.EventHandler(this.unit2Combo_SelectedIndexChanged);
            this.unit2Combo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.unit2Combo.Leave += new System.EventHandler(this.genericControl_Leave);
            this.unit2Combo.Validated += new System.EventHandler(this.unit2Combo_Validated);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(255, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "=";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "1";
            // 
            // unit1Combo
            // 
            this.unit1Combo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unit1Combo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.unit1Combo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.unit1Combo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unit1Combo.FormattingEnabled = true;
            this.unit1Combo.Location = new System.Drawing.Point(29, 12);
            this.unit1Combo.Name = "unit1Combo";
            this.unit1Combo.Size = new System.Drawing.Size(204, 26);
            this.unit1Combo.TabIndex = 9;
            this.unit1Combo.SelectedIndexChanged += new System.EventHandler(this.unit1Combo_SelectedIndexChanged);
            this.unit1Combo.Enter += new System.EventHandler(this.genericControl_Enter);
            this.unit1Combo.Leave += new System.EventHandler(this.genericControl_Leave);
            this.unit1Combo.Validated += new System.EventHandler(this.unit1Combo_Validated);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 29);
            this.panel1.TabIndex = 15;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(4, 6);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 53;
            this.errorLabel.Text = "   ";
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(709, 43);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 33;
            this.newButton.Text = "SAVE";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // dataConvertGridView
            // 
            this.dataConvertGridView.AllowUserToAddRows = false;
            this.dataConvertGridView.AllowUserToDeleteRows = false;
            this.dataConvertGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataConvertGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataConvertGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataConvertGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataConvertGridView.Location = new System.Drawing.Point(1, 94);
            this.dataConvertGridView.Name = "dataConvertGridView";
            this.dataConvertGridView.ReadOnly = true;
            this.dataConvertGridView.RowHeadersVisible = false;
            this.dataConvertGridView.Size = new System.Drawing.Size(814, 348);
            this.dataConvertGridView.TabIndex = 34;
            this.dataConvertGridView.DoubleClick += new System.EventHandler(this.dataConvertGridView_DoubleClick);
            this.dataConvertGridView.Enter += new System.EventHandler(this.dataConvertGridView_Enter);
            this.dataConvertGridView.Leave += new System.EventHandler(this.dataConvertGridView_Leave);
            // 
            // unit1ComboHidden
            // 
            this.unit1ComboHidden.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unit1ComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unit1ComboHidden.FormattingEnabled = true;
            this.unit1ComboHidden.Location = new System.Drawing.Point(32, 158);
            this.unit1ComboHidden.Name = "unit1ComboHidden";
            this.unit1ComboHidden.Size = new System.Drawing.Size(204, 26);
            this.unit1ComboHidden.TabIndex = 35;
            this.unit1ComboHidden.Visible = false;
            // 
            // unit2ComboHidden
            // 
            this.unit2ComboHidden.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unit2ComboHidden.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unit2ComboHidden.FormattingEnabled = true;
            this.unit2ComboHidden.Location = new System.Drawing.Point(487, 158);
            this.unit2ComboHidden.Name = "unit2ComboHidden";
            this.unit2ComboHidden.Size = new System.Drawing.Size(204, 26);
            this.unit2ComboHidden.TabIndex = 36;
            this.unit2ComboHidden.Visible = false;
            // 
            // konversiSatuanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(816, 442);
            this.Controls.Add(this.unit2ComboHidden);
            this.Controls.Add(this.unit1ComboHidden);
            this.Controls.Add(this.dataConvertGridView);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "konversiSatuanForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KONVERSI SATUAN";
            this.Activated += new System.EventHandler(this.konversiSatuanForm_Activated);
            this.Deactivate += new System.EventHandler(this.konversiSatuanForm_Deactivate);
            this.Load += new System.EventHandler(this.konversiSatuanForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConvertGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox unit1Combo;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.DataGridView dataConvertGridView;
        private System.Windows.Forms.ComboBox unit2Combo;
        private System.Windows.Forms.ComboBox unit1ComboHidden;
        private System.Windows.Forms.ComboBox unit2ComboHidden;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.TextBox convertValueTextBox;
    }
}