namespace AlphaSoft
{
    partial class messagingForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.messageDataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setReadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.setAllReadMenu = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.messageDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageDataGridView
            // 
            this.messageDataGridView.AllowUserToAddRows = false;
            this.messageDataGridView.AllowUserToDeleteRows = false;
            this.messageDataGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.messageDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.messageDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.messageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.messageDataGridView.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.messageDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.messageDataGridView.Location = new System.Drawing.Point(2, 3);
            this.messageDataGridView.MultiSelect = false;
            this.messageDataGridView.Name = "messageDataGridView";
            this.messageDataGridView.ReadOnly = true;
            this.messageDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.messageDataGridView.Size = new System.Drawing.Size(982, 656);
            this.messageDataGridView.TabIndex = 0;
            this.messageDataGridView.DoubleClick += new System.EventHandler(this.messageDataGridView_DoubleClick);
            this.messageDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageDataGridView_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setReadMenu,
            this.setAllReadMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 48);
            // 
            // setReadMenu
            // 
            this.setReadMenu.Name = "setReadMenu";
            this.setReadMenu.Size = new System.Drawing.Size(167, 22);
            this.setReadMenu.Text = "SET TO READ";
            this.setReadMenu.Click += new System.EventHandler(this.setReadMenu_Click);
            // 
            // setAllReadMenu
            // 
            this.setAllReadMenu.Name = "setAllReadMenu";
            this.setAllReadMenu.Size = new System.Drawing.Size(167, 22);
            this.setAllReadMenu.Text = "SET ALL TO READ";
            this.setAllReadMenu.Click += new System.EventHandler(this.setAllReadMenu_Click);
            // 
            // messagingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.messageDataGridView);
            this.MaximizeBox = false;
            this.Name = "messagingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MESSAGING FORM";
            this.Load += new System.EventHandler(this.messagingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.messageDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView messageDataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem setReadMenu;
        private System.Windows.Forms.ToolStripMenuItem setAllReadMenu;
    }
}