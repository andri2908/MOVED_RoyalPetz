namespace RoyalPetz_ADMIN
{
    partial class dataSatuanForm
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
            this.unitNameTextBox = new System.Windows.Forms.TextBox();
            this.dataUnitGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.satuannonactiveoption = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataUnitGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(11, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nama";
            // 
            // unitNameTextBox
            // 
            this.unitNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.unitNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitNameTextBox.Location = new System.Drawing.Point(89, 12);
            this.unitNameTextBox.Name = "unitNameTextBox";
            this.unitNameTextBox.Size = new System.Drawing.Size(260, 27);
            this.unitNameTextBox.TabIndex = 31;
            this.unitNameTextBox.TextChanged += new System.EventHandler(this.unitNameTextBox_TextChanged);
            // 
            // dataUnitGridView
            // 
            this.dataUnitGridView.AllowUserToAddRows = false;
            this.dataUnitGridView.AllowUserToDeleteRows = false;
            this.dataUnitGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataUnitGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataUnitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUnitGridView.Location = new System.Drawing.Point(0, 70);
            this.dataUnitGridView.Name = "dataUnitGridView";
            this.dataUnitGridView.ReadOnly = true;
            this.dataUnitGridView.RowHeadersVisible = false;
            this.dataUnitGridView.Size = new System.Drawing.Size(518, 479);
            this.dataUnitGridView.TabIndex = 28;
            this.dataUnitGridView.DoubleClick += new System.EventHandler(this.dataUnitGridView_DoubleClick);
            this.dataUnitGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataUnitGridView_KeyDown);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.Location = new System.Drawing.Point(372, 12);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 27);
            this.newButton.TabIndex = 32;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // satuannonactiveoption
            // 
            this.satuannonactiveoption.AutoSize = true;
            this.satuannonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satuannonactiveoption.Location = new System.Drawing.Point(89, 45);
            this.satuannonactiveoption.Name = "satuannonactiveoption";
            this.satuannonactiveoption.Size = new System.Drawing.Size(184, 19);
            this.satuannonactiveoption.TabIndex = 36;
            this.satuannonactiveoption.Text = "Tampilkan Satuan Non Aktif?";
            this.satuannonactiveoption.UseVisualStyleBackColor = true;
            this.satuannonactiveoption.CheckedChanged += new System.EventHandler(this.satuannonactiveoption_CheckedChanged);
            // 
            // dataSatuanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(518, 549);
            this.Controls.Add(this.satuannonactiveoption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unitNameTextBox);
            this.Controls.Add(this.dataUnitGridView);
            this.Controls.Add(this.newButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataSatuanForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA SATUAN";
            this.Activated += new System.EventHandler(this.dataSatuanForm_Activated);
            this.Load += new System.EventHandler(this.dataSatuanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUnitGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox unitNameTextBox;
        private System.Windows.Forms.DataGridView dataUnitGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox satuannonactiveoption;
    }
}