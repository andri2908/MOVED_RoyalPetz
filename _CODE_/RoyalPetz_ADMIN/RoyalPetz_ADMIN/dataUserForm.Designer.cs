namespace RoyalPetz_ADMIN
{
    partial class dataUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.namaUserTextbox = new System.Windows.Forms.TextBox();
            this.dataUserGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.usernonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupcombobox = new System.Windows.Forms.ComboBox();
            this.searchlabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CetakButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama";
            // 
            // namaUserTextbox
            // 
            this.namaUserTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaUserTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaUserTextbox.Location = new System.Drawing.Point(9, 42);
            this.namaUserTextbox.Name = "namaUserTextbox";
            this.namaUserTextbox.Size = new System.Drawing.Size(214, 27);
            this.namaUserTextbox.TabIndex = 0;
            this.namaUserTextbox.TextChanged += new System.EventHandler(this.namaUserTextbox_TextChanged);
            // 
            // dataUserGridView
            // 
            this.dataUserGridView.AllowUserToAddRows = false;
            this.dataUserGridView.AllowUserToDeleteRows = false;
            this.dataUserGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataUserGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataUserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUserGridView.Location = new System.Drawing.Point(1, 109);
            this.dataUserGridView.Name = "dataUserGridView";
            this.dataUserGridView.ReadOnly = true;
            this.dataUserGridView.RowHeadersVisible = false;
            this.dataUserGridView.Size = new System.Drawing.Size(634, 438);
            this.dataUserGridView.TabIndex = 2;
            this.dataUserGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            this.dataUserGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataUserGridView_KeyDown);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.Color.Black;
            this.newButton.Location = new System.Drawing.Point(229, 41);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(73, 27);
            this.newButton.TabIndex = 4;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // usernonactiveoption
            // 
            this.usernonactiveoption.AutoSize = true;
            this.usernonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernonactiveoption.Location = new System.Drawing.Point(9, 70);
            this.usernonactiveoption.Name = "usernonactiveoption";
            this.usernonactiveoption.Size = new System.Drawing.Size(171, 19);
            this.usernonactiveoption.TabIndex = 1;
            this.usernonactiveoption.Text = "Tampilkan User Non Aktif?";
            this.usernonactiveoption.UseVisualStyleBackColor = true;
            this.usernonactiveoption.CheckedChanged += new System.EventHandler(this.usernonactiveoption_CheckedChanged);
            // 
            // groupcombobox
            // 
            this.groupcombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.groupcombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.groupcombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupcombobox.FormattingEnabled = true;
            this.groupcombobox.Location = new System.Drawing.Point(328, 42);
            this.groupcombobox.Name = "groupcombobox";
            this.groupcombobox.Size = new System.Drawing.Size(217, 28);
            this.groupcombobox.TabIndex = 3;
            this.groupcombobox.Text = "ALL";
            this.groupcombobox.SelectedIndexChanged += new System.EventHandler(this.groupcombobox_SelectedIndexChanged);
            // 
            // searchlabel
            // 
            this.searchlabel.AutoSize = true;
            this.searchlabel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.searchlabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.searchlabel.Location = new System.Drawing.Point(325, 21);
            this.searchlabel.Name = "searchlabel";
            this.searchlabel.Size = new System.Drawing.Size(188, 18);
            this.searchlabel.TabIndex = 7;
            this.searchlabel.Text = "Cari Berdasar Group";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CetakButton);
            this.groupBox1.Controls.Add(this.searchlabel);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.usernonactiveoption);
            this.groupBox1.Controls.Add(this.groupcombobox);
            this.groupBox1.Controls.Add(this.namaUserTextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(1, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pilihan Pencarian";
            // 
            // CetakButton
            // 
            this.CetakButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CetakButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.CetakButton.ForeColor = System.Drawing.Color.Black;
            this.CetakButton.Location = new System.Drawing.Point(551, 41);
            this.CetakButton.Name = "CetakButton";
            this.CetakButton.Size = new System.Drawing.Size(73, 27);
            this.CetakButton.TabIndex = 8;
            this.CetakButton.Text = "CETAK";
            this.CetakButton.UseVisualStyleBackColor = true;
            this.CetakButton.Click += new System.EventHandler(this.CetakButton_Click);
            // 
            // dataUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(636, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataUserGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataUserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA USER";
            this.Activated += new System.EventHandler(this.dataUserForm_Activated);
            this.Load += new System.EventHandler(this.dataUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaUserTextbox;
        private System.Windows.Forms.DataGridView dataUserGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox usernonactiveoption;
        private System.Windows.Forms.Label searchlabel;
        private System.Windows.Forms.ComboBox groupcombobox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CetakButton;
    }
}