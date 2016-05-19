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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RoyalPetz_ADMIN
{
    public partial class SetApplicationForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private string appPath = Application.StartupPath;
        private string selectedIP = "";
        private string ip1, ip2, ip3, ip4;
        private int options = 0;
        private Data_Access DS = new Data_Access();

        public SetApplicationForm()
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
        private bool checkActiveSetting(int opt)
        {
            bool rslt = false;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT * FROM SYS_CONFIG WHERE ID =  " + opt))
            {
                if (rdr.HasRows)
                {
                    rslt = true;
                }
            }
            return rslt;
        }
        private void loadSettingDB(int opt)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT IFNULL(BRANCH_ID,0) AS 'BRANCH_ID', IFNULL(HQ_IP4,'') AS 'IP', IFNULL(STORE_NAME,'') AS 'NAME', IFNULL(STORE_ADDRESS,'') AS 'ADDRESS', IFNULL(STORE_PHONE,'') AS 'PHONE', IFNULL(STORE_EMAIL,'') AS 'EMAIL' FROM SYS_CONFIG WHERE ID =  " + opt))
            {
                if (rdr.HasRows)
                {                    
                    while (rdr.Read())
                    {
                        BranchIDTextbox.Text = rdr.GetString("BRANCH_ID");
                        string tmp = rdr.GetString("IP");
                        int pos = tmp.IndexOf(".");
                        string tmp2 = tmp.Substring(0, pos);
                        ip1 = tmp2;
                        HQIP1.Text = ip1;
                        tmp = tmp.Substring(pos + 1);
                        pos = tmp.IndexOf(".");
                        tmp2 = tmp.Substring(0, pos);
                        ip2 = tmp2;
                        HQIP2.Text = ip2;
                        tmp = tmp.Substring(pos + 1);
                        pos = tmp.IndexOf(".");
                        tmp2 = tmp.Substring(0, pos);
                        ip3 = tmp2;
                        HQIP3.Text = ip3;
                        tmp = tmp.Substring(pos + 1);
                        ip4 = tmp;
                        HQIP4.Text = ip4;
                        if (!String.IsNullOrEmpty(rdr.GetString("NAME")))
                        {
                            NamaTokoTextbox.Text = rdr.GetString("NAME");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("ADDRESS")))
                        {
                            AlamatTextbox.Text = rdr.GetString("ADDRESS");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("PHONE")))
                        {
                            TeleponTextbox.Text = rdr.GetString("PHONE");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("EMAIL")))
                        {
                            EmailTextbox.Text = rdr.GetString("EMAIL");
                        }                                  
                    }
                }
            }
        }

        private void setDatabaseLocationForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);

            errorLabel.Text = "";
            if (checkconfig())
            {
                if (selectedIP.Equals("localhost"))
                {
                    localhostRadioButton.PerformClick();
                }
                else
                {
                    serverIPRadioButton.PerformClick();
                    //ip1Textbox.Text = selectedIP;
                    //perform delimiter check
                    string tmp = selectedIP;
                    int pos = tmp.IndexOf(".");
                    string tmp2 = tmp.Substring(0, pos);
                    ip1 = tmp2;
                    ip1Textbox.Text = ip1;
                    tmp = tmp.Substring(pos + 1);
                    pos = tmp.IndexOf(".");
                    tmp2 = tmp.Substring(0, pos);
                    ip2 = tmp2;
                    ip2Textbox.Text = ip2;
                    tmp = tmp.Substring(pos + 1);
                    pos = tmp.IndexOf(".");
                    tmp2 = tmp.Substring(0, pos);
                    ip3 = tmp2;
                    ip3Textbox.Text = ip3;
                    tmp = tmp.Substring(pos + 1);
                    ip4 = tmp;
                    ip4Textbox.Text = ip4;
                }
            }

            if (checkActiveSetting(2))
            {
                loadSettingDB(2);
            }
            else
            {
                //warning default setting is loaded
                MessageBox.Show("Default Setting Loaded");
                loadSettingDB(1);
            }
        }

        private void createConfig(String inp1,String inp2,String inp3,String inp4)
        {
            //default config file name is pos.cfg
            string path = appPath + "\\pos.cfg";
            String rslt = "";
            if (inp1.Equals("localhost"))
            {
                rslt = inp1;
                gutil.saveSystemDebugLog(0, "SERVER IP IS LOCALHOST");
            }
            else
            {
                //check per input for trailing 0
                rslt = inp1.Trim() + "." + inp2.Trim() + "." + inp3.Trim() + "." + inp4.Trim();
                gutil.saveSystemDebugLog(0, "SERVER IP IS NOT LOCALHOST [" + rslt + "]");
            }
            File.WriteAllText(path, rslt);
            //gutil.showSuccess(gutil.UPD);
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
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            BranchIDTextbox.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            BranchIDTextbox.Visible = false;
        }

        private bool DataValidated()
        {
            /*if ((!HQIP1.Text.Trim().Equals("")) && (!HQIP1.Text.Trim().Equals("")) && (!HQIP1.Text.Trim().Equals("")) && (!HQIP1.Text.Trim().Equals("")))
            {
                errorLabel.Text = "Cek ulang IP Address Gudang Pusat!";
                return false;
            }*/
            if ((HQIP1.Text.Length == 0) && (HQIP2.Text.Length == 0) && (HQIP3.Text.Length == 0) && (HQIP4.Text.Length == 0))
            {
                errorLabel.Text = "Cek ulang IP Address Gudang Pusat!";
                return false;
            }
            if (serverIPRadioButton.Checked)
            {
                if ((ip1Textbox.Text.Length == 0) && (ip2Textbox.Text.Length == 0) && (ip3Textbox.Text.Length == 0) && (ip4Textbox.Text.Length == 0))
                {
                    errorLabel.Text = "Cek ulang IP Address Server DB!";
                    return false;
                }
            }
            if (BranchIDTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "Cek ulang Input Branch ID!";
                return false;
            }
            if (NamaTokoTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "Nama Toko Belum diisi!";
                return false;
            }
            if (AlamatTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "Alamat Toko Belum diisi!";
                return false;
            }
            if (TeleponTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "Telepon Toko Belum diisi!";
                return false;
            }
            /*if (EmailTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "Email Toko Belum diisi!";
                return false;
            }*/
            return true;
        }

        private bool saveDataTransaction(int mode)
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;
            string HQIP = HQIP1.Text.Trim() + "." + HQIP2.Text.Trim() + "." + HQIP3.Text.Trim() + "." + HQIP4.Text.Trim(); ;
            String branchID = BranchIDTextbox.Text;
            //String no_faktur = "";
            String nama_toko = MySqlHelper.EscapeString(NamaTokoTextbox.Text);
            String alamat_toko = MySqlHelper.EscapeString(AlamatTextbox.Text);
            String telepon_toko = MySqlHelper.EscapeString(TeleponTextbox.Text);
            String email_toko = MySqlHelper.EscapeString(EmailTextbox.Text);
            int id = 2;
            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (mode)
                {
                    case 1:
                        sqlCommand = "INSERT INTO SYS_CONFIG (ID, NO_FAKTUR, BRANCH_ID, HQ_IP4, STORE_NAME, STORE_ADDRESS, STORE_PHONE, STORE_EMAIL) " +
                                            "VALUES (2, '', '" + branchID + "', '" + HQIP + "', '" + nama_toko + "', '" + alamat_toko + "', '" + telepon_toko + "', '" + email_toko + "')";
                        options = gutil.INS;
                        gutil.saveSystemDebugLog(0, "INSERT DATA ID 2 TO SYS_CONFIG");

                        break;
                    case 2:
                        sqlCommand = "UPDATE SYS_CONFIG SET " +
                                            "BRANCH_ID = " + branchID + ", " +
                                            "HQ_IP4 = '" + HQIP + "', " +
                                            "STORE_NAME = '" + nama_toko + "', " +
                                            "STORE_ADDRESS = '" + alamat_toko + "', " +
                                            "STORE_PHONE = '" + telepon_toko + "', " +
                                            "STORE_EMAIL = '" + email_toko + "' " +                                        
                                            "WHERE ID = " + id;
                        options = gutil.UPD;
                        gutil.saveSystemDebugLog(0, "UPDATE DATA ID 2");

                        break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(0, "UPDATE / INSERT FAILED");

                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gutil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gutil.showDBOPError(e, "INSERT");
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private bool saveData(int mode)
        {
            if (DataValidated())
            {
                return saveDataTransaction(mode);
            }

            return false;
        }
        private void saveButton_Click_1(object sender, EventArgs e)
        {
            //save to setting 
            bool success1=false;
            bool success2 = false;
            if (serverIPRadioButton.Checked)
            {
                createConfig(ip1Textbox.Text,ip2Textbox.Text,ip3Textbox.Text,ip4Textbox.Text);
                success1 = true;
            } else
            {
                createConfig("localhost","","","");
                success1 = true;
            }
            if (checkActiveSetting(2))
            {
                //save to 2 update
                if (saveData(2))
                {
                    //gutil.showSuccess(options);
                    success2 = true;
                    gutil.ResetAllControls(this);                    
                }
            } else
            {
                //save to 2 new data
                if (saveData(1))
                {
                    //gutil.showSuccess(options);
                    success2 = true;
                    gutil.ResetAllControls(this);
                }
            }
            if (success1 && success2)
            {
                gutil.saveUserChangeLog(globalConstants.MENU_SINKRONISASI_INFORMASI, globalConstants.CHANGE_LOG_UPDATE, "UPDATE DATA APLIKASI");
                gutil.showSuccess(options);
            } else
            {
                if (success1 == false)
                {
                    //error saving config
                    gutil.showError();
                }
            }
        }

        private void localhostRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            ip1Textbox.Visible = false;
            ip2Textbox.Visible = false;
            ip3Textbox.Visible = false;
            ip4Textbox.Visible = false;
            ip1Textbox.Clear();
            ip2Textbox.Clear();
            ip3Textbox.Clear();
            ip4Textbox.Clear();
        }

        private void serverIPRadioButton_CheckedChanged_1(object sender, EventArgs e)
        {
            ip1Textbox.Visible = true;
            ip2Textbox.Visible = true;
            ip3Textbox.Visible = true;
            ip4Textbox.Visible = true;
        }

        private void HQIP1_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                HQIP1.SelectAll();
            });
        }

        private void HQIP2_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                HQIP2.SelectAll();
            });
        }

        private void HQIP3_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                HQIP3.SelectAll();
            });
        }

        private void HQIP4_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                HQIP4.SelectAll();
            });
        }

        private void BranchIDTextbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                BranchIDTextbox.SelectAll();
            });
        }

        private void TeleponTextbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                TeleponTextbox.SelectAll();
            });
        }

        private void ip1Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip1Textbox.SelectAll();
            });
        }

        private void ip2Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip2Textbox.SelectAll();
            });
        }

        private void ip3Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip3Textbox.SelectAll();
            });
        }

        private void ip4Textbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                ip4Textbox.SelectAll();
            });
        }

        private void ip1Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip2Textbox.Focus();
        }

        private void ip2Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip3Textbox.Focus();
        }

        private void ip3Textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                ip4Textbox.Focus();
        }

    }
}
