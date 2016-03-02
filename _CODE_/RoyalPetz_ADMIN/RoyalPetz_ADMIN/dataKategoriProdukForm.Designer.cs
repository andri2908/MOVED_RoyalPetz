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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kategoriProdukDataGridView = new System.Windows.Forms.DataGridView();
            this.categoryNameTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tagnonactiveoption = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kategoriProdukDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // kategoriProdukDataGridView
            // 
            this.kategoriProdukDataGridView.AllowUserToAddRows = false;
            this.kategoriProdukDataGridView.AllowUserToDeleteRows = false;
            this.kategoriProdukDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kategoriProdukDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.kategoriProdukDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kategoriProdukDataGridView.Location = new System.Drawing.Point(0, 74);
            this.kategoriProdukDataGridView.Name = "kategoriProdukDataGridView";
            this.kategoriProdukDataGridView.RowHeadersVisible = false;
            this.kategoriProdukDataGridView.Size = new System.Drawing.Size(669, 474);
            this.kategoriProdukDataGridView.TabIndex = 0;
            this.kategoriProdukDataGridView.DoubleClick += new System.EventHandler(this.tagProdukDataGridView_DoubleClick);
            // 
            // categoryNameTextBox
            // 
            this.categoryNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryNameTextBox.Location = new System.Drawing.Point(124, 16);
            this.categoryNameTextBox.Name = "categoryNameTextBox";
            this.categoryNameTextBox.Size = new System.Drawing.Size(260, 27);
            this.categoryNameTextBox.TabIndex = 6;
            this.categoryNameTextBox.TextChanged += new System.EventHandler(this.categoryNameTextBox_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(521, 10);
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
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "KATEGORI";
            // 
            // tagnonactiveoption
            // 
            this.tagnonactiveoption.AutoSize = true;
            this.tagnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tagnonactiveoption.Location = new System.Drawing.Point(124, 49);
            this.tagnonactiveoption.Name = "tagnonactiveoption";
            this.tagnonactiveoption.Size = new System.Drawing.Size(191, 19);
            this.tagnonactiveoption.TabIndex = 34;
            this.tagnonactiveoption.Text = "Tampilkan Kategori Non Aktif?";
            this.tagnonactiveoption.UseVisualStyleBackColor = true;
            this.tagnonactiveoption.CheckedChanged += new System.EventHandler(this.groupnonactiveoption_CheckedChanged);
            // 
            // dataKategoriProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(669, 549);
            this.Controls.Add(this.tagnonactiveoption);
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
            this.Activated += new System.EventHandler(this.dataKategoriProdukForm_Activated);
            this.Load += new System.EventHandler(this.dataKategoriProdukForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kategoriProdukDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView kategoriProdukDataGridView;
        private System.Windows.Forms.TextBox categoryNameTextBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox tagnonactiveoption;
    }
}