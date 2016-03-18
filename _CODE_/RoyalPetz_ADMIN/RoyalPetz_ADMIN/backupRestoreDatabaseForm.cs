using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalPetz_ADMIN
{
    
    public partial class backupRestoreDatabaseForm : Form
    {

        private globalUtilities gUtil = new globalUtilities();
        public backupRestoreDatabaseForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog1.FileName;
                    fileNameTextbox.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            MessageBox.Show(saveFileDialog1.FileName);
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (fileNameTextbox.Text != "")
            {
                //restore database from file
            }
            else
            {
                String errormessage = "Filename is blank." + Environment.NewLine + "Please find the appropriate file!";
                gUtil.showError(errormessage);
            }
        }

        private void backupRestoreDatabaseForm_Load(object sender, EventArgs e)
        {
            gUtil.reArrangeTabOrder(this);
        }
        private void backupRestoreDatabaseForm_Activated(object sender, EventArgs e)
        {
            //ig need something
        }
    }
}
