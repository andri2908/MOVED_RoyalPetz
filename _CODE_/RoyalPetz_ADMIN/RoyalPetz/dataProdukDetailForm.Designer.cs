namespace AlphaSoft
{
    partial class dataProdukDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataProdukDetailForm));
            this.errorLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.masterProductTab = new System.Windows.Forms.TabPage();
            this.showInactiveExpiryCheckBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.expDataGridView = new System.Windows.Forms.DataGridView();
            this.expiredCheckBox = new System.Windows.Forms.CheckBox();
            this.nonAktifCheckbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.panelImage = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.hargaGrosirTextBox = new System.Windows.Forms.TextBox();
            this.grosirMargin = new System.Windows.Forms.TextBox();
            this.hargaPartaiTextBox = new System.Windows.Forms.TextBox();
            this.partaiMargin = new System.Windows.Forms.TextBox();
            this.hargaEcerTextBox = new System.Windows.Forms.TextBox();
            this.hppTextBox = new System.Windows.Forms.TextBox();
            this.ecerMargin = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.limitStokTextBox = new System.Windows.Forms.TextBox();
            this.stokAwalTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.noRakKolomTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SupplierHistoryButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.barcodeTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SupplierTextBox = new System.Windows.Forms.TextBox();
            this.produkKategoriTextBox = new System.Windows.Forms.TextBox();
            this.searchUnitButton = new System.Windows.Forms.Button();
            this.produkDescTextBox = new System.Windows.Forms.TextBox();
            this.namaProdukTextBox = new System.Windows.Forms.TextBox();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.searchKategoriButton = new System.Windows.Forms.Button();
            this.kodeProdukTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.produkJasaCheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.noRakBarisTextBox = new System.Windows.Forms.TextBox();
            this.resetbutton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.expDataGridViewHidden = new System.Windows.Forms.DataGridView();
            this.lotID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.masterProductTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expDataGridViewHidden)).BeginInit();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.errorLabel.AutoSize = true;
            this.errorLabel.BackColor = System.Drawing.Color.White;
            this.errorLabel.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(7, 6);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(23, 18);
            this.errorLabel.TabIndex = 26;
            this.errorLabel.Text = "   ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "*.jpg";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.errorLabel);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1101, 29);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.masterProductTab);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 659);
            this.tabControl1.TabIndex = 11;
            // 
            // masterProductTab
            // 
            this.masterProductTab.Controls.Add(this.showInactiveExpiryCheckBox);
            this.masterProductTab.Controls.Add(this.label11);
            this.masterProductTab.Controls.Add(this.expDataGridView);
            this.masterProductTab.Controls.Add(this.expiredCheckBox);
            this.masterProductTab.Controls.Add(this.nonAktifCheckbox);
            this.masterProductTab.Controls.Add(this.button1);
            this.masterProductTab.Controls.Add(this.label15);
            this.masterProductTab.Controls.Add(this.panelImage);
            this.masterProductTab.Controls.Add(this.groupBox3);
            this.masterProductTab.Controls.Add(this.groupBox2);
            this.masterProductTab.Controls.Add(this.noRakKolomTextBox);
            this.masterProductTab.Controls.Add(this.groupBox1);
            this.masterProductTab.Controls.Add(this.noRakBarisTextBox);
            this.masterProductTab.Controls.Add(this.resetbutton);
            this.masterProductTab.Controls.Add(this.label19);
            this.masterProductTab.Controls.Add(this.saveButton);
            this.masterProductTab.Location = new System.Drawing.Point(4, 29);
            this.masterProductTab.Name = "masterProductTab";
            this.masterProductTab.Padding = new System.Windows.Forms.Padding(3);
            this.masterProductTab.Size = new System.Drawing.Size(1093, 626);
            this.masterProductTab.TabIndex = 0;
            this.masterProductTab.Text = "DATA PRODUK";
            this.masterProductTab.UseVisualStyleBackColor = true;
            // 
            // showInactiveExpiryCheckBox
            // 
            this.showInactiveExpiryCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.showInactiveExpiryCheckBox.AutoSize = true;
            this.showInactiveExpiryCheckBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showInactiveExpiryCheckBox.Location = new System.Drawing.Point(861, 554);
            this.showInactiveExpiryCheckBox.Name = "showInactiveExpiryCheckBox";
            this.showInactiveExpiryCheckBox.Size = new System.Drawing.Size(223, 22);
            this.showInactiveExpiryCheckBox.TabIndex = 107;
            this.showInactiveExpiryCheckBox.Text = "Tampilkan Expiry Non Aktif";
            this.showInactiveExpiryCheckBox.UseVisualStyleBackColor = true;
            this.showInactiveExpiryCheckBox.CheckedChanged += new System.EventHandler(this.showInactiveExpiryCheckBox_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(765, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(215, 18);
            this.label11.TabIndex = 106;
            this.label11.Text = "DATA PRODUK EXPIRED ";
            // 
            // expDataGridView
            // 
            this.expDataGridView.AllowUserToDeleteRows = false;
            this.expDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.expDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expDataGridView.Location = new System.Drawing.Point(765, 44);
            this.expDataGridView.Name = "expDataGridView";
            this.expDataGridView.RowHeadersVisible = false;
            this.expDataGridView.Size = new System.Drawing.Size(319, 504);
            this.expDataGridView.TabIndex = 105;
            this.expDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.expDataGridView_CellBeginEdit);
            this.expDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.expDataGridView_CellEndEdit);
            this.expDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.expDataGridView_CellEnter);
            this.expDataGridView.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.expDataGridView_CellLeave);
            this.expDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.expDataGridView_CellValidating);
            this.expDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.expDataGridView_CellValueChanged);
            this.expDataGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.expDataGridView_CurrentCellDirtyStateChanged);
            this.expDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.expDataGridView_RowsAdded);
            this.expDataGridView.Enter += new System.EventHandler(this.expDataGridView_Enter);
            this.expDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.expDataGridView_KeyDown);
            this.expDataGridView.Leave += new System.EventHandler(this.expDataGridView_Leave);
            // 
            // expiredCheckBox
            // 
            this.expiredCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.expiredCheckBox.AutoSize = true;
            this.expiredCheckBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiredCheckBox.Location = new System.Drawing.Point(495, 304);
            this.expiredCheckBox.Name = "expiredCheckBox";
            this.expiredCheckBox.Size = new System.Drawing.Size(165, 22);
            this.expiredCheckBox.TabIndex = 98;
            this.expiredCheckBox.Text = "Produk Kadaluarsa";
            this.expiredCheckBox.UseVisualStyleBackColor = true;
            this.expiredCheckBox.CheckedChanged += new System.EventHandler(this.expiredCheckBox_CheckedChanged);
            // 
            // nonAktifCheckbox
            // 
            this.nonAktifCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nonAktifCheckbox.AutoSize = true;
            this.nonAktifCheckbox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonAktifCheckbox.Location = new System.Drawing.Point(6, 551);
            this.nonAktifCheckbox.Name = "nonAktifCheckbox";
            this.nonAktifCheckbox.Size = new System.Drawing.Size(152, 22);
            this.nonAktifCheckbox.TabIndex = 92;
            this.nonAktifCheckbox.Text = "Non Aktif Produk";
            this.nonAktifCheckbox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(679, 368);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 86;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(490, 344);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 18);
            this.label15.TabIndex = 93;
            this.label15.Text = "GAMBAR PRODUK";
            // 
            // panelImage
            // 
            this.panelImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImage.Location = new System.Drawing.Point(493, 368);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(180, 180);
            this.panelImage.TabIndex = 87;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.hargaGrosirTextBox);
            this.groupBox3.Controls.Add(this.grosirMargin);
            this.groupBox3.Controls.Add(this.hargaPartaiTextBox);
            this.groupBox3.Controls.Add(this.partaiMargin);
            this.groupBox3.Controls.Add(this.hargaEcerTextBox);
            this.groupBox3.Controls.Add(this.hppTextBox);
            this.groupBox3.Controls.Add(this.ecerMargin);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(465, 165);
            this.groupBox3.TabIndex = 91;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HARGA PRODUK";
            // 
            // hargaGrosirTextBox
            // 
            this.hargaGrosirTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hargaGrosirTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hargaGrosirTextBox.Location = new System.Drawing.Point(212, 124);
            this.hargaGrosirTextBox.Name = "hargaGrosirTextBox";
            this.hargaGrosirTextBox.Size = new System.Drawing.Size(159, 27);
            this.hargaGrosirTextBox.TabIndex = 49;
            this.hargaGrosirTextBox.Text = "0";
            this.hargaGrosirTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hargaGrosirTextBox.TextChanged += new System.EventHandler(this.hargaGrosirTextBox_TextChanged);
            // 
            // grosirMargin
            // 
            this.grosirMargin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.grosirMargin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grosirMargin.Location = new System.Drawing.Point(379, 124);
            this.grosirMargin.Name = "grosirMargin";
            this.grosirMargin.ReadOnly = true;
            this.grosirMargin.Size = new System.Drawing.Size(80, 27);
            this.grosirMargin.TabIndex = 77;
            this.grosirMargin.Text = "0";
            this.grosirMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hargaPartaiTextBox
            // 
            this.hargaPartaiTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hargaPartaiTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hargaPartaiTextBox.Location = new System.Drawing.Point(212, 91);
            this.hargaPartaiTextBox.Name = "hargaPartaiTextBox";
            this.hargaPartaiTextBox.Size = new System.Drawing.Size(159, 27);
            this.hargaPartaiTextBox.TabIndex = 49;
            this.hargaPartaiTextBox.Text = "0";
            this.hargaPartaiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hargaPartaiTextBox.TextChanged += new System.EventHandler(this.hargaPartaiTextBox_TextChanged);
            // 
            // partaiMargin
            // 
            this.partaiMargin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.partaiMargin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partaiMargin.Location = new System.Drawing.Point(379, 91);
            this.partaiMargin.Name = "partaiMargin";
            this.partaiMargin.ReadOnly = true;
            this.partaiMargin.Size = new System.Drawing.Size(80, 27);
            this.partaiMargin.TabIndex = 78;
            this.partaiMargin.Text = "0";
            this.partaiMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hargaEcerTextBox
            // 
            this.hargaEcerTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hargaEcerTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hargaEcerTextBox.Location = new System.Drawing.Point(212, 58);
            this.hargaEcerTextBox.Name = "hargaEcerTextBox";
            this.hargaEcerTextBox.Size = new System.Drawing.Size(159, 27);
            this.hargaEcerTextBox.TabIndex = 49;
            this.hargaEcerTextBox.Text = "0";
            this.hargaEcerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hargaEcerTextBox.TextChanged += new System.EventHandler(this.hargaEcerTextBox_TextChanged);
            // 
            // hppTextBox
            // 
            this.hppTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hppTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hppTextBox.Location = new System.Drawing.Point(212, 25);
            this.hppTextBox.Name = "hppTextBox";
            this.hppTextBox.Size = new System.Drawing.Size(159, 27);
            this.hppTextBox.TabIndex = 49;
            this.hppTextBox.Text = "0";
            this.hppTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hppTextBox.TextChanged += new System.EventHandler(this.hppTextBox_TextChanged);
            // 
            // ecerMargin
            // 
            this.ecerMargin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ecerMargin.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ecerMargin.Location = new System.Drawing.Point(379, 58);
            this.ecerMargin.Name = "ecerMargin";
            this.ecerMargin.ReadOnly = true;
            this.ecerMargin.Size = new System.Drawing.Size(80, 27);
            this.ecerMargin.TabIndex = 79;
            this.ecerMargin.Text = "0";
            this.ecerMargin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label21.Location = new System.Drawing.Point(6, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(189, 18);
            this.label21.TabIndex = 73;
            this.label21.Text = "HARGA POKOK (HPP)";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label22.Location = new System.Drawing.Point(6, 61);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(163, 18);
            this.label22.TabIndex = 74;
            this.label22.Text = "HARGA JUAL ECER";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label24.Location = new System.Drawing.Point(6, 94);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(188, 18);
            this.label24.TabIndex = 75;
            this.label24.Text = "HARGA JUAL GROSIR";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label25.Location = new System.Drawing.Point(6, 127);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(185, 18);
            this.label25.TabIndex = 76;
            this.label25.Text = "HARGA JUAL PARTAI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.limitStokTextBox);
            this.groupBox2.Controls.Add(this.stokAwalTextBox);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(465, 121);
            this.groupBox2.TabIndex = 90;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "STOK PRODUK";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 73;
            this.label4.Text = "LIMIT STOK";
            // 
            // limitStokTextBox
            // 
            this.limitStokTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.limitStokTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limitStokTextBox.Location = new System.Drawing.Point(157, 69);
            this.limitStokTextBox.Name = "limitStokTextBox";
            this.limitStokTextBox.Size = new System.Drawing.Size(175, 26);
            this.limitStokTextBox.TabIndex = 72;
            this.limitStokTextBox.Text = "0";
            this.limitStokTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.limitStokTextBox.TextChanged += new System.EventHandler(this.limitStokTextBox_TextChanged);
            // 
            // stokAwalTextBox
            // 
            this.stokAwalTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.stokAwalTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stokAwalTextBox.Location = new System.Drawing.Point(157, 30);
            this.stokAwalTextBox.Name = "stokAwalTextBox";
            this.stokAwalTextBox.Size = new System.Drawing.Size(175, 26);
            this.stokAwalTextBox.TabIndex = 71;
            this.stokAwalTextBox.Text = "0";
            this.stokAwalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.stokAwalTextBox.TextChanged += new System.EventHandler(this.stokAwalTextBox_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(-200, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 18);
            this.label13.TabIndex = 70;
            this.label13.Text = "LIMIT MINIMUM";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "STOK AWAL";
            // 
            // noRakKolomTextBox
            // 
            this.noRakKolomTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.noRakKolomTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noRakKolomTextBox.Location = new System.Drawing.Point(659, 263);
            this.noRakKolomTextBox.Mask = "00";
            this.noRakKolomTextBox.Name = "noRakKolomTextBox";
            this.noRakKolomTextBox.Size = new System.Drawing.Size(33, 26);
            this.noRakKolomTextBox.TabIndex = 88;
            this.noRakKolomTextBox.Enter += new System.EventHandler(this.noRakKolomTextBox_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SupplierHistoryButton);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.barcodeTextBox);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.SupplierTextBox);
            this.groupBox1.Controls.Add(this.produkKategoriTextBox);
            this.groupBox1.Controls.Add(this.searchUnitButton);
            this.groupBox1.Controls.Add(this.produkDescTextBox);
            this.groupBox1.Controls.Add(this.namaProdukTextBox);
            this.groupBox1.Controls.Add(this.unitTextBox);
            this.groupBox1.Controls.Add(this.searchKategoriButton);
            this.groupBox1.Controls.Add(this.kodeProdukTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.produkJasaCheckbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 240);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ID PRODUK";
            // 
            // SupplierHistoryButton
            // 
            this.SupplierHistoryButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SupplierHistoryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SupplierHistoryButton.BackgroundImage")));
            this.SupplierHistoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SupplierHistoryButton.Location = new System.Drawing.Point(425, 198);
            this.SupplierHistoryButton.Name = "SupplierHistoryButton";
            this.SupplierHistoryButton.Size = new System.Drawing.Size(26, 26);
            this.SupplierHistoryButton.TabIndex = 81;
            this.SupplierHistoryButton.UseVisualStyleBackColor = true;
            this.SupplierHistoryButton.Click += new System.EventHandler(this.SupplierHistoryButton_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(653, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 26);
            this.button3.TabIndex = 80;
            this.button3.Text = "CLEAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // barcodeTextBox
            // 
            this.barcodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.barcodeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.barcodeTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barcodeTextBox.Location = new System.Drawing.Point(468, 25);
            this.barcodeTextBox.MaxLength = 15;
            this.barcodeTextBox.Name = "barcodeTextBox";
            this.barcodeTextBox.Size = new System.Drawing.Size(174, 26);
            this.barcodeTextBox.TabIndex = 79;
            this.barcodeTextBox.TextChanged += new System.EventHandler(this.barcodeTextBox_TextChanged);
            this.barcodeTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.barcodeTextBox_KeyUp);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(653, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 26);
            this.button2.TabIndex = 78;
            this.button2.Text = "PRINT";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SupplierTextBox
            // 
            this.SupplierTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SupplierTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.SupplierTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SupplierTextBox.Enabled = false;
            this.SupplierTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierTextBox.Location = new System.Drawing.Point(133, 198);
            this.SupplierTextBox.MaxLength = 50;
            this.SupplierTextBox.Name = "SupplierTextBox";
            this.SupplierTextBox.Size = new System.Drawing.Size(286, 26);
            this.SupplierTextBox.TabIndex = 17;
            // 
            // produkKategoriTextBox
            // 
            this.produkKategoriTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.produkKategoriTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produkKategoriTextBox.Location = new System.Drawing.Point(133, 134);
            this.produkKategoriTextBox.Name = "produkKategoriTextBox";
            this.produkKategoriTextBox.ReadOnly = true;
            this.produkKategoriTextBox.Size = new System.Drawing.Size(477, 26);
            this.produkKategoriTextBox.TabIndex = 17;
            this.produkKategoriTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.produkKategoriTextBox_KeyUp);
            // 
            // searchUnitButton
            // 
            this.searchUnitButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchUnitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchUnitButton.BackgroundImage")));
            this.searchUnitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchUnitButton.Location = new System.Drawing.Point(425, 165);
            this.searchUnitButton.Name = "searchUnitButton";
            this.searchUnitButton.Size = new System.Drawing.Size(26, 26);
            this.searchUnitButton.TabIndex = 38;
            this.searchUnitButton.UseVisualStyleBackColor = true;
            this.searchUnitButton.Click += new System.EventHandler(this.searchUnitButton_Click);
            // 
            // produkDescTextBox
            // 
            this.produkDescTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.produkDescTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.produkDescTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produkDescTextBox.Location = new System.Drawing.Point(133, 103);
            this.produkDescTextBox.MaxLength = 100;
            this.produkDescTextBox.Name = "produkDescTextBox";
            this.produkDescTextBox.Size = new System.Drawing.Size(605, 26);
            this.produkDescTextBox.TabIndex = 33;
            this.produkDescTextBox.TextChanged += new System.EventHandler(this.produkDescTextBox_TextChanged);
            // 
            // namaProdukTextBox
            // 
            this.namaProdukTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.namaProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaProdukTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaProdukTextBox.Location = new System.Drawing.Point(133, 55);
            this.namaProdukTextBox.MaxLength = 50;
            this.namaProdukTextBox.Name = "namaProdukTextBox";
            this.namaProdukTextBox.Size = new System.Drawing.Size(605, 26);
            this.namaProdukTextBox.TabIndex = 33;
            this.namaProdukTextBox.TextChanged += new System.EventHandler(this.namaProdukTextBox_TextChanged);
            // 
            // unitTextBox
            // 
            this.unitTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.unitTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitTextBox.Location = new System.Drawing.Point(133, 166);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.ReadOnly = true;
            this.unitTextBox.Size = new System.Drawing.Size(286, 26);
            this.unitTextBox.TabIndex = 17;
            this.unitTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.unitTextBox_KeyUp);
            // 
            // searchKategoriButton
            // 
            this.searchKategoriButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.searchKategoriButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchKategoriButton.BackgroundImage")));
            this.searchKategoriButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.searchKategoriButton.Location = new System.Drawing.Point(616, 134);
            this.searchKategoriButton.Name = "searchKategoriButton";
            this.searchKategoriButton.Size = new System.Drawing.Size(26, 26);
            this.searchKategoriButton.TabIndex = 18;
            this.searchKategoriButton.UseVisualStyleBackColor = true;
            this.searchKategoriButton.Click += new System.EventHandler(this.searchKategoriButton_Click);
            // 
            // kodeProdukTextBox
            // 
            this.kodeProdukTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kodeProdukTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.kodeProdukTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kodeProdukTextBox.Location = new System.Drawing.Point(133, 25);
            this.kodeProdukTextBox.Name = "kodeProdukTextBox";
            this.kodeProdukTextBox.Size = new System.Drawing.Size(228, 26);
            this.kodeProdukTextBox.TabIndex = 15;
            this.kodeProdukTextBox.TextChanged += new System.EventHandler(this.kodeProdukTextBox_TextChanged);
            this.kodeProdukTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.kodeProdukTextBox_KeyUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "KODE";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "NAMA";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(6, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 73;
            this.label8.Text = "DESKRIPSI";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(376, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 18);
            this.label16.TabIndex = 16;
            this.label16.Text = "BARCODE";
            // 
            // produkJasaCheckbox
            // 
            this.produkJasaCheckbox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.produkJasaCheckbox.AutoSize = true;
            this.produkJasaCheckbox.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produkJasaCheckbox.Location = new System.Drawing.Point(133, 84);
            this.produkJasaCheckbox.Name = "produkJasaCheckbox";
            this.produkJasaCheckbox.Size = new System.Drawing.Size(238, 17);
            this.produkJasaCheckbox.TabIndex = 34;
            this.produkJasaCheckbox.Text = "Produk Jasa / Servis (non-inventory)";
            this.produkJasaCheckbox.UseVisualStyleBackColor = true;
            this.produkJasaCheckbox.CheckedChanged += new System.EventHandler(this.produkJasaCheckbox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(6, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "KATEGORI";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(6, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "SATUAN UNIT";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(6, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "SUPPLIER";
            // 
            // noRakBarisTextBox
            // 
            this.noRakBarisTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.noRakBarisTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.noRakBarisTextBox.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noRakBarisTextBox.Location = new System.Drawing.Point(619, 263);
            this.noRakBarisTextBox.MaxLength = 2;
            this.noRakBarisTextBox.Name = "noRakBarisTextBox";
            this.noRakBarisTextBox.Size = new System.Drawing.Size(34, 26);
            this.noRakBarisTextBox.TabIndex = 89;
            this.noRakBarisTextBox.TextChanged += new System.EventHandler(this.noRakBarisTextBox_TextChanged);
            // 
            // resetbutton
            // 
            this.resetbutton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.resetbutton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetbutton.Location = new System.Drawing.Point(605, 570);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(95, 37);
            this.resetbutton.TabIndex = 83;
            this.resetbutton.Text = "RESET";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(505, 266);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(118, 18);
            this.label19.TabIndex = 85;
            this.label19.Text = "NOMOR RAK ";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(392, 570);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(206, 37);
            this.saveButton.TabIndex = 82;
            this.saveButton.Text = "SAVE DATA PRODUK";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // expDataGridViewHidden
            // 
            this.expDataGridViewHidden.AllowUserToDeleteRows = false;
            this.expDataGridViewHidden.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.expDataGridViewHidden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.expDataGridViewHidden.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lotID});
            this.expDataGridViewHidden.Location = new System.Drawing.Point(1186, 103);
            this.expDataGridViewHidden.Name = "expDataGridViewHidden";
            this.expDataGridViewHidden.RowHeadersVisible = false;
            this.expDataGridViewHidden.Size = new System.Drawing.Size(200, 292);
            this.expDataGridViewHidden.TabIndex = 108;
            this.expDataGridViewHidden.Visible = false;
            // 
            // lotID
            // 
            this.lotID.HeaderText = "LOT_ID";
            this.lotID.Name = "lotID";
            this.lotID.Width = 70;
            // 
            // dataProdukDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1105, 690);
            this.Controls.Add(this.expDataGridViewHidden);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataProdukDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DETAIL DATA PRODUK ";
            this.Activated += new System.EventHandler(this.dataProdukDetailForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataProdukDetailForm_Deactivate);
            this.Load += new System.EventHandler(this.dataProdukDetailForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.masterProductTab.ResumeLayout(false);
            this.masterProductTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expDataGridViewHidden)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage masterProductTab;
        private System.Windows.Forms.CheckBox expiredCheckBox;
        private System.Windows.Forms.CheckBox nonAktifCheckbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox hargaGrosirTextBox;
        private System.Windows.Forms.TextBox grosirMargin;
        private System.Windows.Forms.TextBox hargaPartaiTextBox;
        private System.Windows.Forms.TextBox partaiMargin;
        private System.Windows.Forms.TextBox hargaEcerTextBox;
        private System.Windows.Forms.TextBox hppTextBox;
        private System.Windows.Forms.TextBox ecerMargin;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox limitStokTextBox;
        private System.Windows.Forms.TextBox stokAwalTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox noRakKolomTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SupplierHistoryButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox barcodeTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SupplierTextBox;
        private System.Windows.Forms.TextBox produkKategoriTextBox;
        private System.Windows.Forms.Button searchUnitButton;
        private System.Windows.Forms.TextBox produkDescTextBox;
        private System.Windows.Forms.TextBox namaProdukTextBox;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.Button searchKategoriButton;
        private System.Windows.Forms.TextBox kodeProdukTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox produkJasaCheckbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox noRakBarisTextBox;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView expDataGridView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView expDataGridViewHidden;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotID;
        private System.Windows.Forms.CheckBox showInactiveExpiryCheckBox;
    }
}