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
using System.IO;

namespace RoyalPetz_ADMIN
{
    public partial class createConfigFileForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();
        private string appPath = Application.StartupPath;

        private string ipAddress = "";

        public createConfigFileForm()
        {
            InitializeComponent();
        }

        private bool testConnection(bool skipMessage = false)
        {
            bool result = false;
            MySqlException internalEX = null;

            ipAddress = gUtil.allTrim(IPMasked_1.Text) + "." + gUtil.allTrim(IPMasked_2.Text) + "." + gUtil.allTrim(IPMasked_3.Text) + "." + gUtil.allTrim(IPMasked_4.Text);
            DS.setConfigFileConnectionString(ipAddress);

            result = DS.testConfigConnectionString(ref internalEX);

            if (!skipMessage)
            { 
                if (!result)
                    MessageBox.Show("CONNECTION ERROR [" + internalEX.Message + "]");
                else
                    MessageBox.Show("CONNECTION SUCCESS");
            }

            return result;
        }

        private void saveConfigFile()
        {
            string fileName = appPath + "\\pos.cfg";
            string line = ipAddress;
            StreamWriter sw = null;

            if (!File.Exists(fileName))
                sw = File.CreateText(fileName);
            else
            {
                File.Delete(fileName);
                sw = File.CreateText(fileName);
            }

            sw.WriteLine(line);
            sw.Close();
        }

        private void createConfigFileForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            gUtil.reArrangeTabOrder(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testConnection();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (testConnection(true))
            {
                saveConfigFile();
            }

            this.Close();
        }

        private void IPMasked_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                IPMasked_2.Focus();
        }

        private void IPMasked_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                IPMasked_3.Focus();
        }

        private void IPMasked_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                IPMasked_4.Focus();
        }
    }
}
