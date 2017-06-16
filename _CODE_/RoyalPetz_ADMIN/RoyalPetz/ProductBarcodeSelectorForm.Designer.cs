namespace AlphaSoft
{
    partial class ProductBarcodeSelectorForm
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
            this.PrintBarcodeButton = new System.Windows.Forms.Button();
            this.ProductBCGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBCGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintBarcodeButton
            // 
            this.PrintBarcodeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PrintBarcodeButton.Location = new System.Drawing.Point(316, 440);
            this.PrintBarcodeButton.Name = "PrintBarcodeButton";
            this.PrintBarcodeButton.Size = new System.Drawing.Size(120, 38);
            this.PrintBarcodeButton.TabIndex = 1;
            this.PrintBarcodeButton.Text = "PRINT";
            this.PrintBarcodeButton.UseVisualStyleBackColor = true;
            this.PrintBarcodeButton.Click += new System.EventHandler(this.PrintBarcodeButton_Click);
            // 
            // ProductBCGridView
            // 
            this.ProductBCGridView.AllowUserToAddRows = false;
            this.ProductBCGridView.AllowUserToDeleteRows = false;
            this.ProductBCGridView.AllowUserToResizeRows = false;
            this.ProductBCGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductBCGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductBCGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ProductBCGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ProductBCGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProductBCGridView.Location = new System.Drawing.Point(12, 55);
            this.ProductBCGridView.Name = "ProductBCGridView";
            this.ProductBCGridView.RowHeadersVisible = false;
            this.ProductBCGridView.Size = new System.Drawing.Size(729, 377);
            this.ProductBCGridView.TabIndex = 2;
            this.ProductBCGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.ProductBCGridView_CurrentCellDirtyStateChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 29);
            this.panel1.TabIndex = 15;
            // 
            // ProductBarcodeSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(753, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProductBCGridView);
            this.Controls.Add(this.PrintBarcodeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProductBarcodeSelectorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRODUCT BARCODE SELECTOR";
            this.Load += new System.EventHandler(this.ProductBarcodeSelectorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductBCGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrintBarcodeButton;
        private System.Windows.Forms.DataGridView ProductBCGridView;
        private System.Windows.Forms.Panel panel1;
    }
}