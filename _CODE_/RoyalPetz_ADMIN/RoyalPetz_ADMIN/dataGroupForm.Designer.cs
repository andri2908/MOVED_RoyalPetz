namespace RoyalPetz_ADMIN
{
    partial class dataGroupForm
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
            this.namaGroupTextbox = new System.Windows.Forms.TextBox();
            this.dataUserGroupGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.groupnonactiveoption = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGroupGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nama";
            // 
            // namaGroupTextbox
            // 
            this.namaGroupTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaGroupTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaGroupTextbox.Location = new System.Drawing.Point(79, 13);
            this.namaGroupTextbox.Name = "namaGroupTextbox";
            this.namaGroupTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaGroupTextbox.TabIndex = 31;
            this.namaGroupTextbox.TextChanged += new System.EventHandler(this.namaGroupTextbox_TextChanged);
            // 
            // dataUserGroupGridView
            // 
            this.dataUserGroupGridView.AllowUserToAddRows = false;
            this.dataUserGroupGridView.AllowUserToDeleteRows = false;
            this.dataUserGroupGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataUserGroupGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataUserGroupGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUserGroupGridView.Location = new System.Drawing.Point(0, 74);
            this.dataUserGroupGridView.MultiSelect = false;
            this.dataUserGroupGridView.Name = "dataUserGroupGridView";
            this.dataUserGroupGridView.ReadOnly = true;
            this.dataUserGroupGridView.RowHeadersVisible = false;
            this.dataUserGroupGridView.Size = new System.Drawing.Size(603, 475);
            this.dataUserGroupGridView.TabIndex = 28;
            this.dataUserGroupGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            this.dataUserGroupGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataUserGroupGridView_KeyDown);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.Location = new System.Drawing.Point(345, 13);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 27);
            this.newButton.TabIndex = 32;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // groupnonactiveoption
            // 
            this.groupnonactiveoption.AutoSize = true;
            this.groupnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupnonactiveoption.Location = new System.Drawing.Point(79, 46);
            this.groupnonactiveoption.Name = "groupnonactiveoption";
            this.groupnonactiveoption.Size = new System.Drawing.Size(172, 19);
            this.groupnonactiveoption.TabIndex = 33;
            this.groupnonactiveoption.Text = "Tampilkan Grup Non Aktif?";
            this.groupnonactiveoption.UseVisualStyleBackColor = true;
            this.groupnonactiveoption.CheckedChanged += new System.EventHandler(this.usernonactiveoption_CheckedChanged);
            // 
            // dataGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 549);
            this.Controls.Add(this.groupnonactiveoption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.namaGroupTextbox);
            this.Controls.Add(this.dataUserGroupGridView);
            this.Controls.Add(this.newButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataGroupForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NAMA GROUP";
            this.Activated += new System.EventHandler(this.dataGroupForm_Activated);
            this.Load += new System.EventHandler(this.dataGroupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGroupGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaGroupTextbox;
        private System.Windows.Forms.DataGridView dataUserGroupGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox groupnonactiveoption;
    }
}