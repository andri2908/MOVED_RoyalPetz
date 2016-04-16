namespace RoyalPetz_ADMIN
{
    partial class dataProdukForm
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
            this.dataProdukGridView = new System.Windows.Forms.DataGridView();
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.produknonactiveoption = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataProdukGridView
            // 
            this.dataProdukGridView.AllowUserToAddRows = false;
            this.dataProdukGridView.AllowUserToDeleteRows = false;
            this.dataProdukGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataProdukGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataProdukGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProdukGridView.Location = new System.Drawing.Point(0, 103);
            this.dataProdukGridView.MultiSelect = false;
            this.dataProdukGridView.Name = "dataProdukGridView";
            this.dataProdukGridView.ReadOnly = true;
            this.dataProdukGridView.RowHeadersVisible = false;
            this.dataProdukGridView.Size = new System.Drawing.Size(669, 445);
            this.dataProdukGridView.TabIndex = 0;
            this.dataProdukGridView.DoubleClick += new System.EventHandler(this.tagProdukDataGridView_DoubleClick);
            this.dataProdukGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataProdukGridView_KeyDown);
            this.dataProdukGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tagProdukDataGridView_KeyPress);
            // 
            // namaProdukTextBox
            // 
            this.namaProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextBox.Location = new System.Drawing.Point(140, 46);
            this.namaProdukTextBox.Name = "namaProdukTextBox";
            this.namaProdukTextBox.Size = new System.Drawing.Size(260, 27);
            this.namaProdukTextBox.TabIndex = 6;
            this.namaProdukTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.Location = new System.Drawing.Point(418, 12);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 27);
            this.newButton.TabIndex = 7;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama Produk";
            // 
            // produknonactiveoption
            // 
            this.produknonactiveoption.AutoSize = true;
            this.produknonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produknonactiveoption.Location = new System.Drawing.Point(140, 78);
            this.produknonactiveoption.Name = "produknonactiveoption";
            this.produknonactiveoption.Size = new System.Drawing.Size(184, 19);
            this.produknonactiveoption.TabIndex = 35;
            this.produknonactiveoption.Text = "Tampilkan Produk Non Aktif?";
            this.produknonactiveoption.UseVisualStyleBackColor = true;
            this.produknonactiveoption.CheckedChanged += new System.EventHandler(this.produknonactiveoption_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FloralWhite;
            this.label2.Location = new System.Drawing.Point(7, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 36;
            this.label2.Text = "Kode Produk";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(140, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 27);
            this.textBox1.TabIndex = 37;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // dataProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(669, 549);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.produknonactiveoption);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaProdukTextBox);
            this.Controls.Add(this.dataProdukGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA PRODUK";
            this.Activated += new System.EventHandler(this.dataProdukForm_Activated);
            this.Load += new System.EventHandler(this.dataProdukForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataProdukGridView;
        private System.Windows.Forms.TextBox namaProdukTextBox;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox produknonactiveoption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}