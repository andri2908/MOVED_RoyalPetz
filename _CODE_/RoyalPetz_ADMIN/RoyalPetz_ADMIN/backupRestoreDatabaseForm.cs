using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.IO;

namespace RoyalPetz_ADMIN
{
    
    public partial class backupRestoreDatabaseForm : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");

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

        private void backupDatabase()
        {
            string localDate = "";
            string fileName = "";
            string ipServer;
            string strCmdText;
            
            localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);
            fileName = "EXPORT_" + localDate + ".sql";

            Directory.SetCurrentDirectory(Application.StartupPath);
            
            ipServer = DS.getIPServer();
            strCmdText = "/C mysqldump -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos > " + fileName;
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();
            //MessageBox.Show(saveFileDialog1.FileName);
            backupDatabase();
        }

        private void restoreDatabase(string fileName)
        {
            string ipServer = "";
            string strCmdText = "";

            Directory.SetCurrentDirectory(Application.StartupPath);
            
            ipServer = DS.getIPServer();
            strCmdText = "/C " + "mysql -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos < \"" + fileName + "\"";

            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (fileNameTextbox.Text != "")
            {
                //restore database from file
                restoreDatabase(fileNameTextbox.Text);
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
