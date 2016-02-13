namespace RoyalPetz_ADMIN
{
    partial class dataKategoriProdukForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kategoriProdukDataGridView = new System.Windows.Forms.DataGridView();
            this.categoryNameTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kategoriProdukDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // kategoriProdukDataGridView
            // 
            this.kategoriProdukDataGridView.AllowUserToAddRows = false;
            this.kategoriProdukDataGridView.AllowUserToDeleteRows = false;
            this.kategoriProdukDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kategoriProdukDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.kategoriProdukDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kategoriProdukDataGridView.Location = new System.Drawing.Point(0, 68);
            this.kategoriProdukDataGridView.Name = "kategoriProdukDataGridView";
            this.kategoriProdukDataGridView.RowHeadersVisible = false;
            this.kategoriProdukDataGridView.Size = new System.Drawing.Size(669, 480);
            this.kategoriProdukDataGridView.TabIndex = 0;
            this.kategoriProdukDataGridView.DoubleClick += new System.EventHandler(this.tagProdukDataGridView_DoubleClick);
            // 
            // categoryNameTextBox
            // 
            this.categoryNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryNameTextBox.Location = new System.Drawing.Point(119, 27);
            this.categoryNameTextBox.Name = "categoryNameTextBox";
            this.categoryNameTextBox.Size = new System.Drawing.Size(260, 27);
            this.categoryNameTextBox.TabIndex = 6;
            this.categoryNameTextBox.TextChanged += new System.EventHandler(this.categoryNameTextBox_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(516, 21);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 7;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "KATEGORI";
            // 
            // dataKategoriProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(669, 549);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.categoryNameTextBox);
            this.Controls.Add(this.kategoriProdukDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataKategoriProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KATEGORI PRODUK";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.dataKategoriProdukForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.kategoriProdukDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView kategoriProdukDataGridView;
        private System.Windows.Forms.TextBox categoryNameTextBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label1;
    }
}