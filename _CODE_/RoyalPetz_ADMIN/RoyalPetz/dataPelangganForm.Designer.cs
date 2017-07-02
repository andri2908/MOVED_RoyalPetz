namespace AlphaSoft
{
    partial class dataPelangganForm
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
            this.namaPelangganTextbox = new System.Windows.Forms.TextBox();
            this.dataPelangganDataGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.pelanggangnonactiveoption = new System.Windows.Forms.CheckBox();
            this.unknownCustomerButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataPelangganDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "NAMA";
            // 
            // namaPelangganTextbox
            // 
            this.namaPelangganTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaPelangganTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaPelangganTextbox.Location = new System.Drawing.Point(78, 21);
            this.namaPelangganTextbox.Name = "namaPelangganTextbox";
            this.namaPelangganTextbox.Size = new System.Drawing.Size(271, 27);
            this.namaPelangganTextbox.TabIndex = 11;
            this.namaPelangganTextbox.TextChanged += new System.EventHandler(this.namaPelangganTextbox_TextChanged);
            // 
            // dataPelangganDataGridView
            // 
            this.dataPelangganDataGridView.AllowUserToAddRows = false;
            this.dataPelangganDataGridView.AllowUserToDeleteRows = false;
            this.dataPelangganDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPelangganDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataPelangganDataGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPelangganDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataPelangganDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataPelangganDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataPelangganDataGridView.Location = new System.Drawing.Point(0, 142);
            this.dataPelangganDataGridView.MultiSelect = false;
            this.dataPelangganDataGridView.Name = "dataPelangganDataGridView";
            this.dataPelangganDataGridView.ReadOnly = true;
            this.dataPelangganDataGridView.RowHeadersVisible = false;
            this.dataPelangganDataGridView.Size = new System.Drawing.Size(884, 618);
            this.dataPelangganDataGridView.TabIndex = 8;
            this.dataPelangganDataGridView.DoubleClick += new System.EventHandler(this.dataPelangganDataGridView_DoubleClick);
            this.dataPelangganDataGridView.Enter += new System.EventHandler(this.dataPelangganDataGridView_Enter);
            this.dataPelangganDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataPelangganDataGridView_KeyDown);
            this.dataPelangganDataGridView.Leave += new System.EventHandler(this.dataPelangganDataGridView_Leave);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(9, 49);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 27);
            this.newButton.TabIndex = 12;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // pelanggangnonactiveoption
            // 
            this.pelanggangnonactiveoption.AutoSize = true;
            this.pelanggangnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pelanggangnonactiveoption.Location = new System.Drawing.Point(78, 54);
            this.pelanggangnonactiveoption.Name = "pelanggangnonactiveoption";
            this.pelanggangnonactiveoption.Size = new System.Drawing.Size(205, 19);
            this.pelanggangnonactiveoption.TabIndex = 34;
            this.pelanggangnonactiveoption.Text = "Tampilkan Pelanggan Non Aktif?";
            this.pelanggangnonactiveoption.UseVisualStyleBackColor = true;
            this.pelanggangnonactiveoption.CheckedChanged += new System.EventHandler(this.pelanggangnonactiveoption_CheckedChanged);
            // 
            // unknownCustomerButton
            // 
            this.unknownCustomerButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.unknownCustomerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.unknownCustomerButton.Location = new System.Drawing.Point(355, 21);
            this.unknownCustomerButton.Name = "unknownCustomerButton";
            this.unknownCustomerButton.Size = new System.Drawing.Size(122, 86);
            this.unknownCustomerButton.TabIndex = 35;
            this.unknownCustomerButton.Text = "PELANGGAN UMUM";
            this.unknownCustomerButton.UseVisualStyleBackColor = true;
            this.unknownCustomerButton.Visible = false;
            this.unknownCustomerButton.Click += new System.EventHandler(this.unknownCustomerButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.AllButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.unknownCustomerButton);
            this.groupBox1.Controls.Add(this.namaPelangganTextbox);
            this.groupBox1.Controls.Add(this.pelanggangnonactiveoption);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(198, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 124);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // AllButton
            // 
            this.AllButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AllButton.Location = new System.Drawing.Point(78, 79);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(271, 28);
            this.AllButton.TabIndex = 41;
            this.AllButton.Text = "DISPLAY ALL";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // dataPelangganForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(884, 761);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataPelangganDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "dataPelangganForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA PELANGGAN";
            this.Activated += new System.EventHandler(this.dataPelangganForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataPelangganForm_Deactivate);
            this.Load += new System.EventHandler(this.dataPelangganForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataPelangganDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaPelangganTextbox;
        private System.Windows.Forms.DataGridView dataPelangganDataGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox pelanggangnonactiveoption;
        private System.Windows.Forms.Button unknownCustomerButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AllButton;
    }
}