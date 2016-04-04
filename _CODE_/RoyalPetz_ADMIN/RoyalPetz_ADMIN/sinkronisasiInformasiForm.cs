using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace RoyalPetz_ADMIN
{
    public partial class sinkronisasiInformasiForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");

        public sinkronisasiInformasiForm()
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
       
        private void exportDataMasterProduk()
        {
            string localDate = "";
            string fileName = "";
            string ipServer;
            string strCmdText;

            localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);
            fileName = "SYNCINFO_PRODUCT_" + localDate + ".sql";

            Directory.SetCurrentDirectory(Application.StartupPath);

            ipServer = DS.getIPServer();
            strCmdText = "/C mysqldump -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos MASTER_PRODUCT > " + fileName;
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        private void exportDataButton_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();
            //MessageBox.Show(saveFileDialog1.FileName);
            exportDataMasterProduk();
        }

        private void sinkronisasiInformasiForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void sinkronisasiInformasiForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }

        private void syncInformation(string fileName)
        {
            string ipServer = "";
            string strCmdText = "";

            Directory.SetCurrentDirectory(Application.StartupPath);

            ipServer = DS.getIPServer();
            strCmdText = "/C " + "mysql -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos < \"" + fileName + "\"";

            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        private void importFromFileButton_Click(object sender, EventArgs e)
        {
            if (fileNameTextbox.Text != "")
            {
                //restore database from file
                syncInformation(fileNameTextbox.Text);
            }
            else
            {
                String errormessage = "Filename is blank." + Environment.NewLine + "Please find the appropriate file!";
                gutil.showError(errormessage);
            }
        }
    }
}
