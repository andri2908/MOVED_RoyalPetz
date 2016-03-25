using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RoyalPetz_ADMIN
{
    public partial class setDatabaseLocationForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        string appPath = Application.StartupPath;
        string selectedIP = "";

        public setDatabaseLocationForm()
        {
            InitializeComponent();
        }

        private void serverIPRadioButton_Click(object sender, EventArgs e)
        {
            /*if (serverIPRadioButton.Checked)
            {
                //ipAddressMaskedTextbox.Enabled = true;
                localhostRadioButton.Checked = false;
                serverIPRadioButton.Checked = true;
            }
            else
            {
                //ipAddressMaskedTextbox.Enabled = false;
                localhostRadioButton.Checked = true;
                serverIPRadioButton.Checked = false;
            }*/
        }

        private void localhostRadioButton_Click(object sender, EventArgs e)
        {
            /*if (localhostRadioButton.Checked)
            {
                ipAddressMaskedTextbox.Enabled = false;
                localhostRadioButton.Checked = true;
                serverIPRadioButton.Checked = false;
            }
            else
            {
                ipAddressMaskedTextbox.Enabled = true;
                localhostRadioButton.Checked = false;
                serverIPRadioButton.Checked = true;
            }*/
        }

        private void setDatabaseLocationForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void createConfig(String IPAdrs)
        {
            //default config file name is pos.cfg
            string path = appPath + "\\pos.cfg";

            File.WriteAllText(path, IPAdrs);
            MessageBox.Show("Update Success!");
            /*if (!File.Exists(@path))
            {
                File.Create(@path);
                TextWriter tw = new StreamWriter(@path,true);

                //assume localconnection if IPAdrs is error
                tw.WriteLine(IPAdrs);
                tw.Close();
            }
            else if (File.Exists(@path))
            {
                using (var fs = new FileStream(@path, FileMode.Truncate))
                {
                }
                TextWriter tw = new StreamWriter(@path);
                tw.WriteLine(IPAdrs);
                tw.Close();
            }*/
        }

        private bool checkconfig()
        {
            bool rslt = false;
            string installpath = appPath + "\\pos.cfg";
            String tmp = "";
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                
                using (StreamReader sr = new StreamReader(installpath))
                {
                    string line;

                    // Read and display lines from the file until 
                    // the end of the file is reached. 
                    while ((line = sr.ReadLine()) != null)
                    {
                        tmp = tmp + line;
                    }
                }
                rslt = true;
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                errorLabel.Text = "File Config Not Found";
                rslt = false;
            }
            finally
            {
                selectedIP = tmp.Trim();
            }
            return rslt;
        }

        private void setDatabaseLocationForm_Activated(object sender, EventArgs e)
        {
            //if need something

            if (checkconfig())
            {
                if (selectedIP.Equals("localhost"))
                {
                    localhostRadioButton.PerformClick();
                }
                else
                {
                    serverIPRadioButton.PerformClick();
                    ipAddressMaskedTextbox.Text = selectedIP;
                }
            }
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            //save to setting 
            if (serverIPRadioButton.Checked)
            {
                createConfig(ipAddressMaskedTextbox.Text);
            } else
            {
                createConfig("localhost");
            }
        }

        private void localhostRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            ipAddressMaskedTextbox.Visible = false;
            ipAddressMaskedTextbox.Clear();
        }

        private void serverIPRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            ipAddressMaskedTextbox.Visible = true;
        }
    }
}
