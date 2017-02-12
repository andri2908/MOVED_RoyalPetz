namespace AlphaSoft
{
    partial class pengaturanProdukForm
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
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.dataProdukDataGridView = new System.Windows.Forms.DataGridView();
            this.CHANGED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kodeProduk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaProduk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nama Produk";
            // 
            // namaProdukTextBox
            // 
            this.namaProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextBox.Location = new System.Drawing.Point(154, 27);
            this.namaProdukTextBox.Name = "namaProdukTextBox";
            this.namaProdukTextBox.Size = new System.Drawing.Size(260, 27);
            this.namaProdukTextBox.TabIndex = 34;
            this.namaProdukTextBox.TextChanged += new System.EventHandler(this.namaProdukTextBox_TextChanged);
            // 
            // dataProdukDataGridView
            // 
            this.dataProdukDataGridView.AllowUserToAddRows = false;
            this.dataProdukDataGridView.AllowUserToDeleteRows = false;
            this.dataProdukDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataProdukDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataProdukDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProdukDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHANGED,
            this.ID,
            this.kodeProduk,
            this.namaProduk});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataProdukDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataProdukDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataProdukDataGridView.Location = new System.Drawing.Point(0, 70);
            this.dataProdukDataGridView.Name = "dataProdukDataGridView";
            this.dataProdukDataGridView.RowHeadersVisible = false;
            this.dataProdukDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataProdukDataGridView.Size = new System.Drawing.Size(984, 501);
            this.dataProdukDataGridView.TabIndex = 35;
            this.dataProdukDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProdukDataGridView_CellValidated);
            // 
            // CHANGED
            // 
            this.CHANGED.HeaderText = "CHANGED";
            this.CHANGED.Name = "CHANGED";
            this.CHANGED.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // kodeProduk
            // 
            this.kodeProduk.HeaderText = "KODE PRODUK";
            this.kodeProduk.Name = "kodeProduk";
            this.kodeProduk.ReadOnly = true;
            this.kodeProduk.Width = 200;
            // 
            // namaProduk
            // 
            this.namaProduk.HeaderText = "NAMA PRODUK";
            this.namaProduk.Name = "namaProduk";
            this.namaProduk.ReadOnly = true;
            this.namaProduk.Width = 350;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(484, 21);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 37);
            this.saveButton.TabIndex = 36;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(617, 9);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 37;
            this.errorLabel.Text = "   ";
            // 
            // pengaturanProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(984, 571);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dataProdukDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaProdukTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "pengaturanProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PENGATURAN PRODUK";
            this.Activated += new System.EventHandler(this.pengaturanProdukForm_Activated);
            this.Load += new System.EventHandler(this.pengaturanProdukForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaProdukTextBox;
        private System.Windows.Forms.DataGridView dataProdukDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CHANGED;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn kodeProduk;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaProduk;
        private System.Windows.Forms.Label errorLabel;
    }
}