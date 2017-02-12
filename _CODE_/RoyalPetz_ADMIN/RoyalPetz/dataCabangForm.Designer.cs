namespace AlphaSoft
{
    partial class dataCabangForm
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
            this.namaBranchTextbox = new System.Windows.Forms.TextBox();
            this.dataCabangGridView = new System.Windows.Forms.DataGridView();
            this.cabangnonactiveoption = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.newButton = new System.Windows.Forms.Button();
            this.AllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataCabangGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nama";
            // 
            // namaBranchTextbox
            // 
            this.namaBranchTextbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.namaBranchTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaBranchTextbox.Location = new System.Drawing.Point(89, 19);
            this.namaBranchTextbox.Name = "namaBranchTextbox";
            this.namaBranchTextbox.Size = new System.Drawing.Size(283, 27);
            this.namaBranchTextbox.TabIndex = 31;
            this.namaBranchTextbox.TextChanged += new System.EventHandler(this.namaBranchTextbox_TextChanged);
            // 
            // dataCabangGridView
            // 
            this.dataCabangGridView.AllowUserToAddRows = false;
            this.dataCabangGridView.AllowUserToDeleteRows = false;
            this.dataCabangGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataCabangGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataCabangGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataCabangGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataCabangGridView.Location = new System.Drawing.Point(0, 135);
            this.dataCabangGridView.MultiSelect = false;
            this.dataCabangGridView.Name = "dataCabangGridView";
            this.dataCabangGridView.ReadOnly = true;
            this.dataCabangGridView.RowHeadersVisible = false;
            this.dataCabangGridView.Size = new System.Drawing.Size(402, 414);
            this.dataCabangGridView.TabIndex = 28;
            this.dataCabangGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataCabangGridView_CellContentClick);
            this.dataCabangGridView.DoubleClick += new System.EventHandler(this.dataCabangGridView_DoubleClick);
            this.dataCabangGridView.Enter += new System.EventHandler(this.dataCabangGridView_Enter);
            this.dataCabangGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataCabangGridView_KeyDown);
            this.dataCabangGridView.Leave += new System.EventHandler(this.dataCabangGridView_Leave);
            // 
            // cabangnonactiveoption
            // 
            this.cabangnonactiveoption.AutoSize = true;
            this.cabangnonactiveoption.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cabangnonactiveoption.Location = new System.Drawing.Point(89, 52);
            this.cabangnonactiveoption.Name = "cabangnonactiveoption";
            this.cabangnonactiveoption.Size = new System.Drawing.Size(188, 19);
            this.cabangnonactiveoption.TabIndex = 34;
            this.cabangnonactiveoption.Text = "Tampilkan Cabang Non Aktif?";
            this.cabangnonactiveoption.UseVisualStyleBackColor = true;
            this.cabangnonactiveoption.CheckedChanged += new System.EventHandler(this.cabangnonactiveoption_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cabangnonactiveoption);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.namaBranchTextbox);
            this.groupBox2.Controls.Add(this.newButton);
            this.groupBox2.Controls.Add(this.AllButton);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FloralWhite;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 117);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FILTER ";
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.newButton.Location = new System.Drawing.Point(9, 47);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(56, 37);
            this.newButton.TabIndex = 35;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click_2);
            // 
            // AllButton
            // 
            this.AllButton.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AllButton.Location = new System.Drawing.Point(89, 77);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(283, 28);
            this.AllButton.TabIndex = 34;
            this.AllButton.Text = "DISPLAY ALL";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // dataCabangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(402, 549);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataCabangGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataCabangForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATA CABANG";
            this.Activated += new System.EventHandler(this.dataCabangForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataCabangForm_Deactivate);
            this.Load += new System.EventHandler(this.dataCabangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataCabangGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaBranchTextbox;
        private System.Windows.Forms.DataGridView dataCabangGridView;
        private System.Windows.Forms.CheckBox cabangnonactiveoption;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AllButton;
        private System.Windows.Forms.Button newButton;
    }
}