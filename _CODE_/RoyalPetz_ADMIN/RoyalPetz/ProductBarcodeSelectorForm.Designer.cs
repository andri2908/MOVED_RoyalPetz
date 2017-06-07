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
            this.PrintBarcodeButton = new System.Windows.Forms.Button();
            this.ProductBCGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBCGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintBarcodeButton
            // 
            this.PrintBarcodeButton.Location = new System.Drawing.Point(377, 325);
            this.PrintBarcodeButton.Name = "PrintBarcodeButton";
            this.PrintBarcodeButton.Size = new System.Drawing.Size(75, 38);
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
            this.ProductBCGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ProductBCGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductBCGridView.Location = new System.Drawing.Point(12, 12);
            this.ProductBCGridView.Name = "ProductBCGridView";
            this.ProductBCGridView.Size = new System.Drawing.Size(804, 305);
            this.ProductBCGridView.TabIndex = 2;
            this.ProductBCGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.ProductBCGridView_CurrentCellDirtyStateChanged);
            // 
            // ProductBarcodeSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 370);
            this.Controls.Add(this.ProductBCGridView);
            this.Controls.Add(this.PrintBarcodeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProductBarcodeSelectorForm";
            this.Text = "ProductBarcodeSelectorForm";
            this.Load += new System.EventHandler(this.ProductBarcodeSelectorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductBCGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrintBarcodeButton;
        private System.Windows.Forms.DataGridView ProductBCGridView;
    }
}