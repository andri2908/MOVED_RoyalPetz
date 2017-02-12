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

namespace AlphaSoft
{
    public partial class setNoFakturForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private string noFakturValue = "";

        public setNoFakturForm()
        {
            InitializeComponent();
        }

        private void setNoFakturForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            gutil.reArrangeTabOrder(this);
        }

        private void loadNoFaktur()
        {
            noFakturValue = DS.getDataSingleValue("SELECT IFNULL(NO_FAKTUR, '') FROM SYS_CONFIG WHERE ID = 1").ToString();
            noFakturTextBox.Text = noFakturValue;
        }

        private void setNoFakturForm_Activated(object sender, EventArgs e)
        {
            //if need something
            loadNoFaktur();
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private bool dataValidated()
        {
            if (noFakturTextBox.Text.Length<=0)
            {
                errorLabel.Text = "NO FAKTUR TIDAK BOLEH KOSONG";
                return false;
            }

            if (!gutil.matchRegEx(noFakturTextBox.Text, globalUtilities.REGEX_ALPHANUMERIC_ONLY))
            {
                errorLabel.Text = "NO FAKTUR HARUS ALPHA NUMERIC";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            DS.beginTransaction();

            noFakturValue = noFakturTextBox.Text;
            try
            {
                DS.mySqlConnect();

                sqlCommand = "UPDATE SYS_CONFIG SET NO_FAKTUR = '" + noFakturValue + "' WHERE ID = 1";
                gutil.saveSystemDebugLog(globalConstants.MENU_SET_NO_FAKTUR, "UPDATE SYS CONFIG VALUE [" + noFakturValue + "]");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_SET_NO_FAKTUR, "EXCEPTION THROWN [" + e.Message + "]");
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
        
        private bool saveData()
        {
            bool result = false;
            if (dataValidated())
            {
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();
                result = saveDataTransaction();

                pleaseWait.Close();

                return result;
            }

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            gutil.saveSystemDebugLog(globalConstants.MENU_SET_NO_FAKTUR, "ATTEMPT TO SAVE NO FAKTUR");
            if (saveData())
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_SET_NO_FAKTUR, "NO FAKTUR SAVED");
                gutil.saveUserChangeLog(globalConstants.MENU_SET_NO_FAKTUR, globalConstants.CHANGE_LOG_UPDATE, "SET NO FAKTUR [" + noFakturTextBox.Text + "]");
                gutil.showSuccess(gutil.UPD);
                errorLabel.Text = "";
            }
        }

        private void noFakturTextBox_TextChanged(object sender, EventArgs e)
        {
            noFakturTextBox.Text = gutil.allTrim(noFakturTextBox.Text);
        }
    }
}
