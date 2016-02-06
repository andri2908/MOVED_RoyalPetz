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
            ((System.ComponentModel.ISupportInitialize)(this.dataUserGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nama";
            // 
            // namaUserTextbox
            // 
            this.namaUserTextbox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.namaUserTextbox.Location = new System.Drawing.Point(85, 22);
            this.namaUserTextbox.Name = "namaUserTextbox";
            this.namaUserTextbox.Size = new System.Drawing.Size(260, 27);
            this.namaUserTextbox.TabIndex = 26;
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
            this.dataUserGridView.Location = new System.Drawing.Point(0, 68);
            this.dataUserGridView.Name = "dataUserGridView";
            this.dataUserGridView.RowHeadersVisible = false;
            this.dataUserGridView.Size = new System.Drawing.Size(602, 480);
            this.dataUserGridView.TabIndex = 23;
            this.dataUserGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(432, 16);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 27;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // dataUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(602, 549);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox namaUserTextbox;
        private System.Windows.Forms.DataGridView dataUserGridView;
        private System.Windows.Forms.Button newButton;
    }
}