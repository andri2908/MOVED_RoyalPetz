namespace AlphaSoft
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.unitNameTextBox = new System.Windows.Forms.TextBox();
            this.dataUnitGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.satuannonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataUnitGridView)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "SATUAN";
            // 
            // unitNameTextBox
            // 
            this.unitNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.unitNameTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitNameTextBox.Location = new System.Drawing.Point(110, 21);
            this.unitNameTextBox.Name = "unitNameTextBox";
            this.unitNameTextBox.Size = new System.Drawing.Size(271, 27);
            this.unitNameTextBox.TabIndex = 31;
            this.unitNameTextBox.TextChanged += new System.EventHandler(this.unitNameTextBox_TextChanged);
            this.unitNameTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.unitNameTextBox_KeyUp);
            // 
            // dataUnitGridView
            // 
            this.dataUnitGridView.AllowUserToAddRows = false;
            this.dataUnitGridView.AllowUserToDeleteRows = false;
            this.dataUnitGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataUnitGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataUnitGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataUnitGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataUnitGridView.Location = new System.Drawing.Point(0, 143);
            this.dataUnitGridView.MultiSelect = false;
            this.dataUnitGridView.Name = "dataUnitGridView";
            this.dataUnitGridView.ReadOnly = true;
            this.dataUnitGridView.RowHeadersVisible = false;
            this.dataUnitGridView.Size = new System.Drawing.Size(518, 406);
            this.dataUnitGridView.TabIndex = 28;
            this.dataUnitGridView.DoubleClick += new System.EventHandler(this.dataUnitGridView_DoubleClick);
            this.dataUnitGridView.Enter += new System.EventHandler(this.dataUnitGridView_Enter);
            this.dataUnitGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataUnitGridView_KeyDown);
            this.dataUnitGridView.Leave += new System.EventHandler(this.dataUnitGridView_Leave);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(9, 45);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(78, 37);
            this.newButton.TabIndex = 32;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // satuannonactiveoption
            // 
            this.satuannonactiveoption.AutoSize = true;
            this.satuannonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.satuannonactiveoption.Location = new System.Drawing.Point(110, 54);
            this.satuannonactiveoption.Name = "satuannonactiveoption";
            this.satuannonactiveoption.Size = new System.Drawing.Size(184, 19);
            this.satuannonactiveoption.TabIndex = 36;
            this.satuannonactiveoption.Text = "Tampilkan Satuan Non Aktif?";
            this.satuannonactiveoption.UseVisualStyleBackColor = true;
            this.satuannonactiveoption.CheckedChanged += new System.EventHandler(this.satuannonactiveoption_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AllButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.satuannonactiveoption);
            this.groupBox1.Controls.Add(this.unitNameTextBox);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox1.Location = new System.Drawing.Point(65, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 125);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTER";
            // 
            // AllButton
            // 
            this.AllButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AllButton.Location = new System.Drawing.Point(110, 79);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(271, 28);
            this.AllButton.TabIndex = 42;
            this.AllButton.Text = "DISPLAY ALL";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // dataSatuanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(518, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataUnitGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataSatuanForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA SATUAN";
            this.Activated += new System.EventHandler(this.dataSatuanForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataSatuanForm_Deactivate);
            this.Load += new System.EventHandler(this.dataSatuanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUnitGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox unitNameTextBox;
        private System.Windows.Forms.DataGridView dataUnitGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.CheckBox satuannonactiveoption;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AllButton;
    }
}