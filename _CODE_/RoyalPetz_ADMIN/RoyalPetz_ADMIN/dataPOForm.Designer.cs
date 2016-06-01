namespace RoyalPetz_ADMIN
{
    partial class dataPOForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.noPOInvoiceTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PODtPicker_1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.PODtPicker_2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.supplierHiddenCombo = new System.Windows.Forms.ComboBox();
            this.showAllCheckBox = new System.Windows.Forms.CheckBox();
            this.newButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.supplierCombo = new System.Windows.Forms.ComboBox();
            this.displayButton = new System.Windows.Forms.Button();
            this.dataPurchaseOrder = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPurchaseOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // noPOInvoiceTextBox
            // 
            this.noPOInvoiceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.noPOInvoiceTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPOInvoiceTextBox.Location = new System.Drawing.Point(185, 3);
            this.noPOInvoiceTextBox.Name = "noPOInvoiceTextBox";
            this.noPOInvoiceTextBox.Size = new System.Drawing.Size(260, 27);
            this.noPOInvoiceTextBox.TabIndex = 36;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.PODtPicker_1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.PODtPicker_2, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(185, 36);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(359, 33);
            this.tableLayoutPanel2.TabIndex = 43;
            // 
            // PODtPicker_1
            // 
            this.PODtPicker_1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_1.Location = new System.Drawing.Point(3, 3);
            this.PODtPicker_1.Name = "PODtPicker_1";
            this.PODtPicker_1.Size = new System.Drawing.Size(144, 27);
            this.PODtPicker_1.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FloralWhite;
            this.label5.Location = new System.Drawing.Point(153, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "-";
            // 
            // PODtPicker_2
            // 
            this.PODtPicker_2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PODtPicker_2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PODtPicker_2.Location = new System.Drawing.Point(175, 3);
            this.PODtPicker_2.Name = "PODtPicker_2";
            this.PODtPicker_2.Size = new System.Drawing.Size(145, 27);
            this.PODtPicker_2.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "No Purchase Order";
            // 
            // supplierHiddenCombo
            // 
            this.supplierHiddenCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierHiddenCombo.FormattingEnabled = true;
            this.supplierHiddenCombo.Location = new System.Drawing.Point(566, 274);
            this.supplierHiddenCombo.Name = "supplierHiddenCombo";
            this.supplierHiddenCombo.Size = new System.Drawing.Size(311, 26);
            this.supplierHiddenCombo.TabIndex = 55;
            this.supplierHiddenCombo.Visible = false;
            // 
            // showAllCheckBox
            // 
            this.showAllCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.showAllCheckBox.AutoSize = true;
            this.showAllCheckBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAllCheckBox.ForeColor = System.Drawing.Color.FloralWhite;
            this.showAllCheckBox.Location = new System.Drawing.Point(550, 79);
            this.showAllCheckBox.Name = "showAllCheckBox";
            this.showAllCheckBox.Size = new System.Drawing.Size(101, 22);
            this.showAllCheckBox.TabIndex = 47;
            this.showAllCheckBox.Text = "Show All";
            this.showAllCheckBox.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(566, 150);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(243, 37);
            this.newButton.TabIndex = 54;
            this.newButton.Text = "NEW PURCHASE ORDER";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.91938F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.08062F));
            this.tableLayoutPanel1.Controls.Add(this.noPOInvoiceTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.supplierCombo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.showAllCheckBox, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(899, 108);
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 37;
            this.label2.Text = "Tanggal PO";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FloralWhite;
            this.label3.Location = new System.Drawing.Point(3, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Supplier";
            // 
            // supplierCombo
            // 
            this.supplierCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supplierCombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supplierCombo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCombo.FormattingEnabled = true;
            this.supplierCombo.Location = new System.Drawing.Point(185, 75);
            this.supplierCombo.Name = "supplierCombo";
            this.supplierCombo.Size = new System.Drawing.Size(311, 26);
            this.supplierCombo.TabIndex = 40;
            this.supplierCombo.SelectedIndexChanged += new System.EventHandler(this.supplierCombo_SelectedIndexChanged);
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(194, 150);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 53;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            this.displayButton.Click += new System.EventHandler(this.displayButton_Click);
            // 
            // dataPurchaseOrder
            // 
            this.dataPurchaseOrder.AllowUserToAddRows = false;
            this.dataPurchaseOrder.AllowUserToDeleteRows = false;
            this.dataPurchaseOrder.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPurchaseOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataPurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPurchaseOrder.Location = new System.Drawing.Point(0, 211);
            this.dataPurchaseOrder.MultiSelect = false;
            this.dataPurchaseOrder.Name = "dataPurchaseOrder";
            this.dataPurchaseOrder.RowHeadersVisible = false;
            this.dataPurchaseOrder.Size = new System.Drawing.Size(921, 427);
            this.dataPurchaseOrder.TabIndex = 52;
            this.dataPurchaseOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPurchaseOrder_CellContentClick);
            this.dataPurchaseOrder.DoubleClick += new System.EventHandler(this.dataPurchaseOrder_DoubleClick);
            this.dataPurchaseOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataPurchaseOrder_KeyDown);
            // 
            // dataPOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(920, 637);
            this.Controls.Add(this.supplierHiddenCombo);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.dataPurchaseOrder);
            this.MaximizeBox = false;
            this.Name = "dataPOForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA PURCHASE ORDER";
            this.Activated += new System.EventHandler(this.dataPOForm_Activated);
            this.Load += new System.EventHandler(this.dataPOForm_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPurchaseOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox noPOInvoiceTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker PODtPicker_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker PODtPicker_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox supplierHiddenCombo;
        private System.Windows.Forms.CheckBox showAllCheckBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox supplierCombo;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.DataGridView dataPurchaseOrder;
    }
}