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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.searchpanel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.searchlabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).BeginInit();
            this.searchpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nama";
            // 
            // namaUserTextbox
            // 
            this.namaUserTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaUserTextbox.Location = new System.Drawing.Point(85, 11);
            this.namaUserTextbox.Name = "namaUserTextbox";
            this.namaUserTextbox.Size = new System.Drawing.Size(211, 27);
            this.namaUserTextbox.TabIndex = 26;
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
            this.dataUserGridView.Location = new System.Drawing.Point(8, 90);
            this.dataUserGridView.Name = "dataUserGridView";
            this.dataUserGridView.RowHeadersVisible = false;
            this.dataUserGridView.Size = new System.Drawing.Size(602, 458);
            this.dataUserGridView.TabIndex = 23;
            this.dataUserGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(8, 39);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(60, 27);
            this.newButton.TabIndex = 27;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(85, 44);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 19);
            this.checkBox1.TabIndex = 29;
            this.checkBox1.Text = "Tampilkan User Non Aktif?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // searchpanel
            // 
            this.searchpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.searchpanel.Controls.Add(this.comboBox1);
            this.searchpanel.Controls.Add(this.searchlabel);
            this.searchpanel.Location = new System.Drawing.Point(382, 8);
            this.searchpanel.Name = "searchpanel";
            this.searchpanel.Size = new System.Drawing.Size(211, 66);
            this.searchpanel.TabIndex = 30;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 21);
            this.comboBox1.TabIndex = 32;
            // 
            // searchlabel
            // 
            this.searchlabel.AutoSize = true;
            this.searchlabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchlabel.ForeColor = System.Drawing.Color.FloralWhite;
            this.searchlabel.Location = new System.Drawing.Point(3, 4);
            this.searchlabel.Name = "searchlabel";
            this.searchlabel.Size = new System.Drawing.Size(203, 16);
            this.searchlabel.TabIndex = 31;
            this.searchlabel.Text = "Filter Pencarian - By Group";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(302, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 27);
            this.button1.TabIndex = 31;
            this.button1.Text = "SEARCH";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 549);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchpanel);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaUserTextbox);
            this.Controls.Add(this.dataUserGridView);
            this.Controls.Add(this.newButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataUserForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA USER";
            this.Activated += new System.EventHandler(this.dataUserForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).EndInit();
            this.searchpanel.ResumeLayout(false);
            this.searchpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaUserTextbox;
        private System.Windows.Forms.DataGridView dataUserGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel searchpanel;
        private System.Windows.Forms.Label searchlabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
    }
}