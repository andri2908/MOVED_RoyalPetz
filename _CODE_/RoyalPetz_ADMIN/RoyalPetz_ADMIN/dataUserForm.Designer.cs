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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.namaUserTextbox = new System.Windows.Forms.TextBox();
            this.dataUserGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.usernonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupcombobox = new System.Windows.Forms.ComboBox();
            this.searchlabel = new System.Windows.Forms.Label();
            this.optionpanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nama";
            // 
            // namaUserTextbox
            // 
            this.namaUserTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaUserTextbox.Location = new System.Drawing.Point(80, 11);
            this.namaUserTextbox.Name = "namaUserTextbox";
            this.namaUserTextbox.Size = new System.Drawing.Size(250, 27);
            this.namaUserTextbox.TabIndex = 0;
            this.namaUserTextbox.TextChanged += new System.EventHandler(this.namaUserTextbox_TextChanged);
            // 
            // dataUserGridView
            // 
            this.dataUserGridView.AllowUserToAddRows = false;
            this.dataUserGridView.AllowUserToDeleteRows = false;
            this.dataUserGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataUserGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataUserGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUserGridView.Location = new System.Drawing.Point(2, 86);
            this.dataUserGridView.Name = "dataUserGridView";
            this.dataUserGridView.RowHeadersVisible = false;
            this.dataUserGridView.Size = new System.Drawing.Size(602, 458);
            this.dataUserGridView.TabIndex = 2;
            this.dataUserGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(4, 36);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 38);
            this.newButton.TabIndex = 4;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // usernonactiveoption
            // 
            this.usernonactiveoption.AutoSize = true;
            this.usernonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernonactiveoption.Location = new System.Drawing.Point(80, 44);
            this.usernonactiveoption.Name = "usernonactiveoption";
            this.usernonactiveoption.Size = new System.Drawing.Size(171, 19);
            this.usernonactiveoption.TabIndex = 1;
            this.usernonactiveoption.Text = "Tampilkan User Non Aktif?";
            this.usernonactiveoption.UseVisualStyleBackColor = true;
            this.usernonactiveoption.CheckedChanged += new System.EventHandler(this.usernonactiveoption_CheckedChanged);
            // 
            // groupcombobox
            // 
            this.groupcombobox.FormattingEnabled = true;
            this.groupcombobox.Location = new System.Drawing.Point(362, 42);
            this.groupcombobox.Name = "groupcombobox";
            this.groupcombobox.Size = new System.Drawing.Size(217, 21);
            this.groupcombobox.TabIndex = 3;
            this.groupcombobox.Text = "ALL";
            this.groupcombobox.SelectedIndexChanged += new System.EventHandler(this.groupcombobox_SelectedIndexChanged);
            // 
            // searchlabel
            // 
            this.searchlabel.AutoSize = true;
            this.searchlabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.searchlabel.Location = new System.Drawing.Point(368, 17);
            this.searchlabel.Name = "searchlabel";
            this.searchlabel.Size = new System.Drawing.Size(203, 16);
            this.searchlabel.TabIndex = 7;
            this.searchlabel.Text = "Filter Pencarian - By Group";
            // 
            // optionpanel
            // 
            this.optionpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.optionpanel.Location = new System.Drawing.Point(350, 11);
            this.optionpanel.Name = "optionpanel";
            this.optionpanel.Size = new System.Drawing.Size(245, 63);
            this.optionpanel.TabIndex = 6;
            // 
            // dataUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(607, 549);
            this.Controls.Add(this.dataUserGridView);
            this.Controls.Add(this.groupcombobox);
            this.Controls.Add(this.searchlabel);
            this.Controls.Add(this.usernonactiveoption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaUserTextbox);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.optionpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataUserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA USER";
            this.Activated += new System.EventHandler(this.dataUserForm_Activated);
            this.Load += new System.EventHandler(this.dataUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaUserTextbox;
        private System.Windows.Forms.DataGridView dataUserGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox usernonactiveoption;
        private System.Windows.Forms.Label searchlabel;
        private System.Windows.Forms.ComboBox groupcombobox;
        private System.Windows.Forms.Panel optionpanel;
    }
}