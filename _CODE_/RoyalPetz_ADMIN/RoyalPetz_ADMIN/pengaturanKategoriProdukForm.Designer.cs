namespace RoyalPetz_ADMIN
{
    partial class pengaturanKategoriProdukForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.namaKategoriTextbox = new System.Windows.Forms.TextBox();
            this.deskripsiTextbox = new System.Windows.Forms.TextBox();
            this.pengaturanKategoriDataGridView = new System.Windows.Forms.DataGridView();
            this.changed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PRODUCT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hakAkses = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.namaProdukTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pengaturanKategoriDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.0597F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.9403F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 357F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.namaKategoriTextbox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.deskripsiTextbox, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(547, 70);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "NAMA KATEGORI";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(3, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "DESKRIPSI";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(170, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(170, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = ":";
            // 
            // namaKategoriTextbox
            // 
            this.namaKategoriTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.namaKategoriTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaKategoriTextbox.Location = new System.Drawing.Point(192, 3);
            this.namaKategoriTextbox.Name = "namaKategoriTextbox";
            this.namaKategoriTextbox.ReadOnly = true;
            this.namaKategoriTextbox.Size = new System.Drawing.Size(340, 27);
            this.namaKategoriTextbox.TabIndex = 16;
            // 
            // deskripsiTextbox
            // 
            this.deskripsiTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.deskripsiTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deskripsiTextbox.Location = new System.Drawing.Point(192, 38);
            this.deskripsiTextbox.Name = "deskripsiTextbox";
            this.deskripsiTextbox.ReadOnly = true;
            this.deskripsiTextbox.Size = new System.Drawing.Size(210, 27);
            this.deskripsiTextbox.TabIndex = 17;
            // 
            // pengaturanKategoriDataGridView
            // 
            this.pengaturanKategoriDataGridView.AllowUserToAddRows = false;
            this.pengaturanKategoriDataGridView.AllowUserToDeleteRows = false;
            this.pengaturanKategoriDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pengaturanKategoriDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pengaturanKategoriDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pengaturanKategoriDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.changed,
            this.PRODUCT_ID,
            this.moduleID,
            this.hakAkses});
            this.pengaturanKategoriDataGridView.Location = new System.Drawing.Point(1, 166);
            this.pengaturanKategoriDataGridView.Name = "pengaturanKategoriDataGridView";
            this.pengaturanKategoriDataGridView.RowHeadersVisible = false;
            this.pengaturanKategoriDataGridView.Size = new System.Drawing.Size(569, 495);
            this.pengaturanKategoriDataGridView.TabIndex = 34;
            this.pengaturanKategoriDataGridView.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.pengaturanKategoriDataGridView_CellValidated);
            this.pengaturanKategoriDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.pengaturanKategoriDataGridView_CellValueChanged);
            // 
            // changed
            // 
            this.changed.HeaderText = "changed";
            this.changed.Name = "changed";
            this.changed.Visible = false;
            // 
            // PRODUCT_ID
            // 
            this.PRODUCT_ID.HeaderText = "PRODUCT_ID";
            this.PRODUCT_ID.Name = "PRODUCT_ID";
            this.PRODUCT_ID.Visible = false;
            // 
            // moduleID
            // 
            this.moduleID.HeaderText = "NAMA PRODUK";
            this.moduleID.Name = "moduleID";
            this.moduleID.ReadOnly = true;
            this.moduleID.Width = 350;
            // 
            // hakAkses
            // 
            this.hakAkses.HeaderText = "";
            this.hakAkses.Name = "hakAkses";
            this.hakAkses.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.hakAkses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.hakAkses.Width = 150;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(452, 125);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 37);
            this.saveButton.TabIndex = 33;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 29);
            this.panel1.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(11, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "NAMA PRODUK";
            // 
            // namaProdukTextbox
            // 
            this.namaProdukTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.namaProdukTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextbox.Location = new System.Drawing.Point(207, 130);
            this.namaProdukTextbox.Name = "namaProdukTextbox";
            this.namaProdukTextbox.Size = new System.Drawing.Size(210, 27);
            this.namaProdukTextbox.TabIndex = 36;
            this.namaProdukTextbox.TextChanged += new System.EventHandler(this.namaProdukTextbox_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(184, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 37;
            this.label8.Text = ":";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Location = new System.Drawing.Point(1, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(569, 10);
            this.panel2.TabIndex = 33;
            // 
            // pengaturanKategoriProdukForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(570, 661);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.namaProdukTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pengaturanKategoriDataGridView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "pengaturanKategoriProdukForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PENGATURAN KATEGORI PRODUK";
            this.Activated += new System.EventHandler(this.pengaturanKategoriProdukForm_Activated);
            this.Load += new System.EventHandler(this.pengaturanKategoriProdukForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pengaturanKategoriDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox namaKategoriTextbox;
        private System.Windows.Forms.TextBox deskripsiTextbox;
        private System.Windows.Forms.DataGridView pengaturanKategoriDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox namaProdukTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn changed;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hakAkses;
    }
}