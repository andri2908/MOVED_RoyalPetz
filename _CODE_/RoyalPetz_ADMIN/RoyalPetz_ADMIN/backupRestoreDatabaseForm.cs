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
            openFileDialog1.Filter = "SQL File (.sql)|*.sql";
            openFileDialog1.FileName = "";
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

         private void ProcessExited(Object source, EventArgs e)
        {
            gUtil.saveSystemDebugLog(0, "PROCESS FINISHED");
            MessageBox.Show("DONE");            
        }

        private void backupDatabase(string fileName)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            string ipServer;
            
            ipServer = DS.getIPServer();
            proc.StartInfo.FileName = "CMD.exe";
            proc.StartInfo.Arguments = "/C " + "mysqldump -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos > \"" + fileName + "\"";
            proc.Exited += new EventHandler(ProcessExited);
            proc.EnableRaisingEvents = true;
            gUtil.saveSystemDebugLog(0, "BACKUP DATABASE PROCESS STARTED [" + fileName + "]");
            proc.Start();

        }

        private void backupButton_Click(object sender, EventArgs e)
        {
            string localDate = "";
            string fileName = "";
            localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);
            fileName = "BACKUP_" + localDate + ".sql";

            saveFileDialog1.FileName = fileName;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "sql";
            saveFileDialog1.Filter = "SQL File (.sql)|*.sql";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName.Length > 0 )
                backupDatabase(saveFileDialog1.FileName);
        }

        private void restoreDatabase(string fileName)
        {
            string ipServer = "";
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            
            ipServer = DS.getIPServer();

            proc.StartInfo.FileName = "CMD.exe";
            proc.StartInfo.Arguments = "/C " + "mysql -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos < \"" + fileName + "\"";
            proc.Exited += new EventHandler(ProcessExited);
            proc.EnableRaisingEvents = true;
            gUtil.saveSystemDebugLog(0, "RESTORE DATABASE PROCESS STARTED [" + fileName + "]");
            proc.Start();
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            if (fileNameTextbox.Text != "")
            {
                //restore database from file
                restoreDatabase(fileNameTextbox.Text);
                gUtil.saveUserChangeLog(globalConstants.MENU_SINKRONISASI_INFORMASI, globalConstants.CHANGE_LOG_UPDATE, "RESTORE DATABASE FROM LOCAL BACKUP");
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
