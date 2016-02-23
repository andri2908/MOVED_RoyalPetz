namespace RoyalPetz_ADMIN
{
    partial class dataMutasiBarangForm
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
            this.dataRequestOrderGridView = new System.Windows.Forms.DataGridView();
            this.newButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataRequestOrderGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataRequestOrderGridView
            // 
            this.dataRequestOrderGridView.AllowUserToAddRows = false;
            this.dataRequestOrderGridView.AllowUserToDeleteRows = false;
            this.dataRequestOrderGridView.BackgroundColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataRequestOrderGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataRequestOrderGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRequestOrderGridView.Location = new System.Drawing.Point(0, 50);
            this.dataRequestOrderGridView.Name = "dataRequestOrderGridView";
            this.dataRequestOrderGridView.RowHeadersVisible = false;
            this.dataRequestOrderGridView.Size = new System.Drawing.Size(938, 496);
            this.dataRequestOrderGridView.TabIndex = 33;
            this.dataRequestOrderGridView.DoubleClick += new System.EventHandler(this.dataSalesDataGridView_DoubleClick);
            this.dataRequestOrderGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataRequestOrderGridView_KeyPress);
            // 
            // newButton
            // 
            this.newButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newButton.Location = new System.Drawing.Point(805, 7);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(95, 37);
            this.newButton.TabIndex = 34;
            this.newButton.Text = "NEW";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // importButton
            // 
            this.importButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importButton.Location = new System.Drawing.Point(510, 7);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(254, 37);
            this.importButton.TabIndex = 35;
            this.importButton.Text = "IMPORT REQUEST ORDER";
            this.importButton.UseVisualStyleBackColor = true;
            // 
            // dataMutasiBarangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(938, 549);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.dataRequestOrderGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "dataMutasiBarangForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REQUEST ORDER";
            this.Activated += new System.EventHandler(this.dataMutasiBarangForm_Activated);
            this.Deactivate += new System.EventHandler(this.dataMutasiBarangForm_Deactivate);
            this.Load += new System.EventHandler(this.dataMutasiBarangForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataRequestOrderGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataRequestOrderGridView;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button importButton;
    }
}