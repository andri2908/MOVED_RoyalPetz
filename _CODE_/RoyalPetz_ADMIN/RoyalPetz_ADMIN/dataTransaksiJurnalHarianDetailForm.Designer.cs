namespace RoyalPetz_ADMIN
{
    partial class dataTransaksiJurnalHarianDetailForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataTransaksiJurnalHarianDetailForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.NamaAkunTextbox = new System.Windows.Forms.TextBox();
            this.DeskripsiAkunTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            this.NominalTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TransaksiAccountGridView = new System.Windows.Forms.DataGridView();
            this.Tanggal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kode_akun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nama_Akun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deskripsi_akun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.journal_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.searchButton = new System.Windows.Forms.Button();
            this.TanggalTransaksi = new System.Windows.Forms.DateTimePicker();
            this.commitButton = new System.Windows.Forms.Button();
            this.carabayarcombobox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransaksiAccountGridView)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Location = new System.Drawing.Point(1, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 10);
            this.panel2.TabIndex = 40;
            // 
            // NamaAkunTextbox
            // 
            this.NamaAkunTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NamaAkunTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NamaAkunTextbox.Location = new System.Drawing.Point(3, 3);
            this.NamaAkunTextbox.Name = "NamaAkunTextbox";
            this.NamaAkunTextbox.Size = new System.Drawing.Size(319, 27);
            this.NamaAkunTextbox.TabIndex = 15;
            this.NamaAkunTextbox.TextChanged += new System.EventHandler(this.kodeAkunTextbox_TextChanged);
            // 
            // DeskripsiAkunTextbox
            // 
            this.DeskripsiAkunTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DeskripsiAkunTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeskripsiAkunTextbox.Location = new System.Drawing.Point(201, 43);
            this.DeskripsiAkunTextbox.Name = "DeskripsiAkunTextbox";
            this.DeskripsiAkunTextbox.Size = new System.Drawing.Size(362, 27);
            this.DeskripsiAkunTextbox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "TANGGAL";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(243, 239);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 37);
            this.saveButton.TabIndex = 41;
            this.saveButton.Text = "ADD";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.errorLabel);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 29);
            this.panel1.TabIndex = 39;
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(2, 5);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 1;
            this.errorLabel.Text = "   ";
            // 
            // NominalTextbox
            // 
            this.NominalTextbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NominalTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NominalTextbox.Location = new System.Drawing.Point(201, 119);
            this.NominalTextbox.Name = "NominalTextbox";
            this.NominalTextbox.Size = new System.Drawing.Size(269, 27);
            this.NominalTextbox.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(179, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = ":";
            // 
            // TransaksiAccountGridView
            // 
            this.TransaksiAccountGridView.AllowUserToAddRows = false;
            this.TransaksiAccountGridView.AllowUserToDeleteRows = false;
            this.TransaksiAccountGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TransaksiAccountGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.TransaksiAccountGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransaksiAccountGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tanggal,
            this.Kode_akun,
            this.Nama_Akun,
            this.PaymentMethodID,
            this.PaymentMethod,
            this.debet,
            this.kredit,
            this.deskripsi_akun,
            this.journal_id});
            this.TransaksiAccountGridView.Location = new System.Drawing.Point(1, 286);
            this.TransaksiAccountGridView.Name = "TransaksiAccountGridView";
            this.TransaksiAccountGridView.RowHeadersVisible = false;
            this.TransaksiAccountGridView.Size = new System.Drawing.Size(580, 357);
            this.TransaksiAccountGridView.TabIndex = 42;
            this.TransaksiAccountGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransaksiAccountGridView_CellDoubleClick);
            // 
            // Tanggal
            // 
            this.Tanggal.HeaderText = "TANGGAL";
            this.Tanggal.MinimumWidth = 90;
            this.Tanggal.Name = "Tanggal";
            this.Tanggal.Width = 90;
            // 
            // Kode_akun
            // 
            this.Kode_akun.HeaderText = "KODE AKUN";
            this.Kode_akun.Name = "Kode_akun";
            this.Kode_akun.Visible = false;
            // 
            // Nama_Akun
            // 
            this.Nama_Akun.HeaderText = "NAMA AKUN";
            this.Nama_Akun.MinimumWidth = 160;
            this.Nama_Akun.Name = "Nama_Akun";
            this.Nama_Akun.ReadOnly = true;
            this.Nama_Akun.Width = 160;
            // 
            // PaymentMethodID
            // 
            this.PaymentMethodID.HeaderText = "KODE BAYAR";
            this.PaymentMethodID.Name = "PaymentMethodID";
            this.PaymentMethodID.Visible = false;
            // 
            // PaymentMethod
            // 
            this.PaymentMethod.HeaderText = "PEMBAYARAN";
            this.PaymentMethod.MinimumWidth = 125;
            this.PaymentMethod.Name = "PaymentMethod";
            this.PaymentMethod.Width = 125;
            // 
            // debet
            // 
            this.debet.HeaderText = "DEBET";
            this.debet.MinimumWidth = 100;
            this.debet.Name = "debet";
            // 
            // kredit
            // 
            this.kredit.HeaderText = "KREDIT";
            this.kredit.MinimumWidth = 100;
            this.kredit.Name = "kredit";
            // 
            // deskripsi_akun
            // 
            this.deskripsi_akun.HeaderText = "DESKRIPSI";
            this.deskripsi_akun.Name = "deskripsi_akun";
            this.deskripsi_akun.Visible = false;
            // 
            // journal_id
            // 
            this.journal_id.HeaderText = "Kode Journal";
            this.journal_id.Name = "journal_id";
            this.journal_id.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.NamaAkunTextbox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.searchButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(201, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(362, 32);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchButton.BackgroundImage")));
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchButton.Location = new System.Drawing.Point(328, 3);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(31, 25);
            this.searchButton.TabIndex = 48;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // TanggalTransaksi
            // 
            this.TanggalTransaksi.CalendarFont = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TanggalTransaksi.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TanggalTransaksi.Location = new System.Drawing.Point(207, 36);
            this.TanggalTransaksi.Name = "TanggalTransaksi";
            this.TanggalTransaksi.Size = new System.Drawing.Size(368, 27);
            this.TanggalTransaksi.TabIndex = 46;
            this.TanggalTransaksi.ValueChanged += new System.EventHandler(this.TanggalTransaksi_ValueChanged);
            // 
            // commitButton
            // 
            this.commitButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.commitButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commitButton.Location = new System.Drawing.Point(243, 653);
            this.commitButton.Name = "commitButton";
            this.commitButton.Size = new System.Drawing.Size(95, 37);
            this.commitButton.TabIndex = 47;
            this.commitButton.Text = "SAVE";
            this.commitButton.UseVisualStyleBackColor = true;
            this.commitButton.Click += new System.EventHandler(this.commitButton_Click);
            // 
            // carabayarcombobox
            // 
            this.carabayarcombobox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.carabayarcombobox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carabayarcombobox.FormattingEnabled = true;
            this.carabayarcombobox.Location = new System.Drawing.Point(201, 82);
            this.carabayarcombobox.Name = "carabayarcombobox";
            this.carabayarcombobox.Size = new System.Drawing.Size(269, 26);
            this.carabayarcombobox.TabIndex = 22;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NominalTextbox, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.DeskripsiAkunTextbox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.carabayarcombobox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 82);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(569, 152);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "NAMA AKUN";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "DESKRIPSI";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "METODE BAYAR";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "NOMINAL";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(173, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = ":";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(173, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = ":";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(173, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(173, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 18);
            this.label10.TabIndex = 7;
            this.label10.Text = ":";
            // 
            // dataTransaksiJurnalHarianDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(581, 698);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.commitButton);
            this.Controls.Add(this.TanggalTransaksi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TransaksiAccountGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataTransaksiJurnalHarianDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA TRANSAKSI JURNAL HARIAN";
            this.Activated += new System.EventHandler(this.dataTransaksiJurnalHarianDetailForm_Activated);
            this.Load += new System.EventHandler(this.dataTransaksiJurnalHarianDetailForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransaksiAccountGridView)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox NamaAkunTextbox;
        private System.Windows.Forms.TextBox DeskripsiAkunTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox NominalTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView TransaksiAccountGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker TanggalTransaksi;
        private System.Windows.Forms.Button commitButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ComboBox carabayarcombobox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanggal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kode_akun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nama_Akun;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn debet;
        private System.Windows.Forms.DataGridViewTextBoxColumn kredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn deskripsi_akun;
        private System.Windows.Forms.DataGridViewTextBoxColumn journal_id;
    }
}