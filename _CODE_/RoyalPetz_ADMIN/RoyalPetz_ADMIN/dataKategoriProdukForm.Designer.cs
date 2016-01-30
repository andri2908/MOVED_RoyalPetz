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
            this.tagProdukDataGridView = new System.Windows.Forms.DataGridView();
            this.kodeKategori = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaKategori = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tagProdukDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tagProdukDataGridView
            // 
            this.tagProdukDataGridView.AllowUserToAddRows = false;
            this.tagProdukDataGridView.AllowUserToDeleteRows = false;
            this.tagProdukDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tagProdukDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tagProdukDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagProdukDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kodeKategori,
            this.namaKategori,
            this.counter,
            this.description});
            this.tagProdukDataGridView.Location = new System.Drawing.Point(0, 68);
            this.tagProdukDataGridView.Name = "tagProdukDataGridView";
            this.tagProdukDataGridView.RowHeadersVisible = false;
            this.tagProdukDataGridView.Size = new System.Drawing.Size(669, 480);
            this.tagProdukDataGridView.TabIndex = 0;
            this.tagProdukDataGridView.DoubleClick += new System.EventHandler(this.tagProdukDataGridView_DoubleClick);
            // 
            // kodeKategori
            // 
            this.kodeKategori.HeaderText = "KODE KATEGORI";
            this.kodeKategori.Name = "kodeKategori";
            this.kodeKategori.ReadOnly = true;
            this.kodeKategori.Width = 180;
            // 
            // namaKategori
            // 
            this.namaKategori.HeaderText = "NAMA KATEGORI";
            this.namaKategori.Name = "namaKategori";
            this.namaKategori.ReadOnly = true;
            this.namaKategori.Width = 180;
            // 
            // counter
            // 
            this.counter.HeaderText = "COUNTER";
            this.counter.Name = "counter";
            this.counter.ReadOnly = true;
            // 
            // description
            // 
            this.description.HeaderText = "DESKRIPSI";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Width = 200;
            // 
            // displayButton
            // 
            this.displayButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayButton.Location = new System.Drawing.Point(385, 22);
            this.displayButton.Name = "displayButton";
            this.displayButton.Size = new System.Drawing.Size(95, 37);
            this.displayButton.TabIndex = 4;
            this.displayButton.Text = "DISPLAY";
            this.displayButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(119, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 27);
            this.textBox1.TabIndex = 6;
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
            this.Controls.Add(this.displayButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tagProdukDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataKategoriProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KATEGORI PRODUK";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.tagProdukDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tagProdukDataGridView;
        private System.Windows.Forms.Button displayButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeKategori;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaKategori;
        private System.Windows.Forms.DataGridViewTextBoxColumn counter;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}