﻿namespace RoyalPetz_ADMIN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.namaAccountTextbox = new System.Windows.Forms.TextBox();
            this.dataAccountGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.accountnonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccountGridView)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "NAMA AKUN";
            // 
            // namaAccountTextbox
            // 
            this.namaAccountTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaAccountTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaAccountTextbox.Location = new System.Drawing.Point(135, 21);
            this.namaAccountTextbox.Name = "namaAccountTextbox";
            this.namaAccountTextbox.Size = new System.Drawing.Size(283, 27);
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataAccountGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataAccountGridView.Location = new System.Drawing.Point(0, 138);
            this.dataAccountGridView.MultiSelect = false;
            this.dataAccountGridView.Name = "dataAccountGridView";
            this.dataAccountGridView.ReadOnly = true;
            this.dataAccountGridView.RowHeadersVisible = false;
            this.dataAccountGridView.Size = new System.Drawing.Size(505, 409);
            this.dataAccountGridView.TabIndex = 33;
            this.dataAccountGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAccountGridView_CellContentDoubleClick);
            this.dataAccountGridView.DoubleClick += new System.EventHandler(this.dataAccountGridView_DoubleClick);
            this.dataAccountGridView.Enter += new System.EventHandler(this.dataAccountGridView_Enter);
            this.dataAccountGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataAccountGridView_KeyDown);
            this.dataAccountGridView.Leave += new System.EventHandler(this.dataAccountGridView_Leave);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(9, 45);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(112, 37);
            this.newButton.TabIndex = 37;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // accountnonactiveoption
            // 
            this.accountnonactiveoption.AutoSize = true;
            this.accountnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountnonactiveoption.Location = new System.Drawing.Point(135, 54);
            this.accountnonactiveoption.Name = "accountnonactiveoption";
            this.accountnonactiveoption.Size = new System.Drawing.Size(172, 19);
            this.accountnonactiveoption.TabIndex = 38;
            this.accountnonactiveoption.Text = "Tampilkan Akun Non Aktif?";
            this.accountnonactiveoption.UseVisualStyleBackColor = true;
            this.accountnonactiveoption.CheckedChanged += new System.EventHandler(this.accountnonactiveoption_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AllButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.namaAccountTextbox);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.accountnonactiveoption);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(40, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 120);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // AllButton
            // 
            this.AllButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AllButton.Location = new System.Drawing.Point(135, 79);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(283, 28);
            this.AllButton.TabIndex = 39;
            this.AllButton.Text = "DISPLAY ALL";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // dataNomorAkun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(505, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataAccountGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataNomorAkun";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA NOMOR AKUN";
            this.Activated += new System.EventHandler(this.dataNomorAkun_Activated);
            this.Deactivate += new System.EventHandler(this.dataNomorAkun_Deactivate);
            this.Load += new System.EventHandler(this.dataNomorAkun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAccountGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaAccountTextbox;
        private System.Windows.Forms.DataGridView dataAccountGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox accountnonactiveoption;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AllButton;
    }
}