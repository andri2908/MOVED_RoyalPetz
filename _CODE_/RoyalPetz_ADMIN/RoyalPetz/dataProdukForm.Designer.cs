namespace AlphaSoft
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataProdukGridView = new System.Windows.Forms.DataGridView();
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.newButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.produknonactiveoption = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kodeProductTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataProdukGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataProdukGridView
            // 
            this.dataProdukGridView.AllowUserToAddRows = false;
            this.dataProdukGridView.AllowUserToDeleteRows = false;
            this.dataProdukGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataProdukGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataProdukGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataProdukGridView.Location = new System.Drawing.Point(0, 103);
            this.dataProdukGridView.MultiSelect = false;
            this.dataProdukGridView.Name = "dataProdukGridView";
            this.dataProdukGridView.ReadOnly = true;
            this.dataProdukGridView.RowHeadersVisible = false;
            this.dataProdukGridView.Size = new System.Drawing.Size(872, 457);
            this.dataProdukGridView.TabIndex = 0;
            this.dataProdukGridView.ColumnDisplayIndexChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataProdukGridView_ColumnDisplayIndexChanged);
            this.dataProdukGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataProdukGridView_ColumnHeaderMouseClick);
            this.dataProdukGridView.ColumnSortModeChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataProdukGridView_ColumnSortModeChanged);
            this.dataProdukGridView.DoubleClick += new System.EventHandler(this.tagProdukDataGridView_DoubleClick);
            this.dataProdukGridView.Enter += new System.EventHandler(this.dataProdukGridView_Enter);
            this.dataProdukGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataProdukGridView_KeyDown);
            this.dataProdukGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tagProdukDataGridView_KeyPress);
            this.dataProdukGridView.Leave += new System.EventHandler(this.dataProdukGridView_Leave);
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
            this.namaProdukTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.namaProdukTextBox_KeyPress);
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
            // kodeProductTextBox
            // 
            this.kodeProductTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kodeProductTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kodeProductTextBox.Location = new System.Drawing.Point(140, 12);
            this.kodeProductTextBox.Name = "kodeProductTextBox";
            this.kodeProductTextBox.Size = new System.Drawing.Size(260, 27);
            this.kodeProductTextBox.TabIndex = 37;
            this.kodeProductTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.kodeProductTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // dataProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(872, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kodeProductTextBox);
            this.Controls.Add(this.produknonactiveoption);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaProdukTextBox);
            this.Controls.Add(this.dataProdukGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dataProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA PRODUK";
            this.Activated += new System.EventHandler(this.dataProdukForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataProdukForm_Deactivate);
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
        private System.Windows.Forms.TextBox kodeProductTextBox;
    }
}