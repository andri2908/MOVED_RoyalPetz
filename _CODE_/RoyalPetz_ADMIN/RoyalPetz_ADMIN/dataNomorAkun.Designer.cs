namespace RoyalPetz_ADMIN
{
    partial class dataNomorAkun
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
            this.namaAccountTextbox = new System.Windows.Forms.TextBox();
            this.dataAccountGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.accountnonactiveoption = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccountGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Deskripsi";
            // 
            // namaAccountTextbox
            // 
            this.namaAccountTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaAccountTextbox.Location = new System.Drawing.Point(100, 14);
            this.namaAccountTextbox.Name = "namaAccountTextbox";
            this.namaAccountTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaAccountTextbox.TabIndex = 36;
            this.namaAccountTextbox.TextChanged += new System.EventHandler(this.namaAccountTextbox_TextChanged);
            // 
            // dataAccountGridView
            // 
            this.dataAccountGridView.AllowUserToAddRows = false;
            this.dataAccountGridView.AllowUserToDeleteRows = false;
            this.dataAccountGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataAccountGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataAccountGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAccountGridView.Location = new System.Drawing.Point(0, 72);
            this.dataAccountGridView.Name = "dataAccountGridView";
            this.dataAccountGridView.RowHeadersVisible = false;
            this.dataAccountGridView.Size = new System.Drawing.Size(505, 475);
            this.dataAccountGridView.TabIndex = 33;
            this.dataAccountGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAccountGridView_CellContentDoubleClick);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(366, 14);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(59, 27);
            this.newButton.TabIndex = 37;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // accountnonactiveoption
            // 
            this.accountnonactiveoption.AutoSize = true;
            this.accountnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnonactiveoption.Location = new System.Drawing.Point(100, 47);
            this.accountnonactiveoption.Name = "accountnonactiveoption";
            this.accountnonactiveoption.Size = new System.Drawing.Size(172, 19);
            this.accountnonactiveoption.TabIndex = 38;
            this.accountnonactiveoption.Text = "Tampilkan Akun Non Aktif?";
            this.accountnonactiveoption.UseVisualStyleBackColor = true;
            this.accountnonactiveoption.CheckedChanged += new System.EventHandler(this.accountnonactiveoption_CheckedChanged);
            // 
            // dataNomorAkun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(505, 549);
            this.Controls.Add(this.accountnonactiveoption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaAccountTextbox);
            this.Controls.Add(this.dataAccountGridView);
            this.Controls.Add(this.newButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataNomorAkun";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA NOMOR AKUN";
            this.Activated += new System.EventHandler(this.dataNomorAkun_Activated);
            this.Load += new System.EventHandler(this.dataNomorAkun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAccountGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaAccountTextbox;
        private System.Windows.Forms.DataGridView dataAccountGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox accountnonactiveoption;
    }
}