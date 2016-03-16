namespace RoyalPetz_ADMIN
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
            this.label1 = new System.Windows.Forms.Label();
            this.noInvoiceTextBox = new System.Windows.Forms.TextBox();
            this.dataInvoiceDataGridView = new System.Windows.Forms.DataGridView();
            this.displayButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pelangganCombo = new System.Windows.Forms.ComboBox();
            this.pelangganComboHidden = new System.Windows.Forms.ComboBox();
            this.showAllCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataInvoiceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "NO INVOICE";
            // 
            // noInvoiceTextBox
            // 
            this.noInvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noInvoiceTextBox.Location = new System.Drawing.Point(147, 20);
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
            this.dataInvoiceDataGridView.Location = new System.Drawing.Point(0, 136);
            this.dataInvoiceDataGridView.Name = "dataInvoiceDataGridView";
            this.dataInvoiceDataGridView.RowHeadersVisible = false;
            this.dataInvoiceDataGridView.Size = new System.Drawing.Size(602, 449);
            this.dataInvoiceDataGridView.TabIndex = 33;
            this.dataInvoiceDataGridView.DoubleClick += new System.EventHandler(this.dataInvoiceDataGridView_DoubleClick);
            this.dataInvoiceDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataInvoiceDataGridView_KeyDown);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(147, 93);
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
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "PELANGGAN";
            // 
            // pelangganCombo
            // 
            this.pelangganCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pelangganCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pelangganCombo.FormattingEnabled = true;
            this.pelangganCombo.Location = new System.Drawing.Point(147, 53);
            this.pelangganCombo.Name = "pelangganCombo";
            this.pelangganCombo.Size = new System.Drawing.Size(260, 26);
            this.pelangganCombo.TabIndex = 46;
            this.pelangganCombo.SelectedIndexChanged += new System.EventHandler(this.pelangganCombo_SelectedIndexChanged);
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
            this.showAllCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.showAllCheckBox.AutoSize = true;
            this.showAllCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.showAllCheckBox.Location = new System.Drawing.Point(432, 57);
            this.showAllCheckBox.Name = "showAllCheckBox";
            this.showAllCheckBox.Size = new System.Drawing.Size(101, 22);
            this.showAllCheckBox.TabIndex = 48;
            this.showAllCheckBox.Text = "Show All";
            this.showAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 586);
            this.Controls.Add(this.showAllCheckBox);
            this.Controls.Add(this.pelangganComboHidden);
            this.Controls.Add(this.pelangganCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noInvoiceTextBox);
            this.Controls.Add(this.dataInvoiceDataGridView);
            this.Controls.Add(this.displayButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataInvoiceForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA INVOICE";
            this.Load += new System.EventHandler(this.dataInvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataInvoiceDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}