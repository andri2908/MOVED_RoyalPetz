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

namespace RoyalPetz_ADMIN
{
    public partial class dataNomorAkunDetailForm : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private int originModuleID = 0;
        private int selectedAccountID = 0;
        private int options = 0;
        private Data_Access DS = new Data_Access();

        public dataNomorAkunDetailForm()
        {
            InitializeComponent();
        }

        public dataNomorAkunDetailForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        public dataNomorAkunDetailForm(int moduleID, int AccountID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedAccountID = AccountID;
        }
        
        private void dataNomorAkunDetailForm_Load(object sender, EventArgs e)
        {
            gUtil.reArrangeTabOrder(this);
        }

        private void loadAccountData()
        {
            //loadtypeaccount();

            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            sqlCommand = "SELECT MASTER_ACCOUNT.ACCOUNT_ID AS 'KODE AKUN', MASTER_ACCOUNT.ACCOUNT_NAME AS 'DESKRIPSI', MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_NAME AS 'TIPE', MASTER_ACCOUNT.ACCOUNT_ACTIVE AS 'ACTIVE' FROM MASTER_ACCOUNT, MASTER_ACCOUNT_TYPE WHERE MASTER_ACCOUNT.ACCOUNT_TYPE_ID = MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_ID AND MASTER_ACCOUNT.ID='" + selectedAccountID + "'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        kodeTextbox.Text = rdr.GetString("KODE AKUN");
                        DeskripsiTextbox.Text = rdr.GetString("DESKRIPSI");
                        //TipeComboBox.Text = rdr.GetString("TIPE");
                        TipeComboBox.SelectedIndex = TipeComboBox.FindString(rdr.GetString("TIPE"));
                        //cbxCategory.SelectedIndex = cbxCategory.Items.IndexOf("New") 
                        if (rdr.GetString("ACTIVE").Equals("1"))
                            NonactiveCheckbox.Checked = false;
                        else
                            NonactiveCheckbox.Checked = true;
                    }
                }
            }
        }
        private void loadtypeaccount()
        {
            TipeComboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT ACCOUNT_TYPE_ID as 'ID', ACCOUNT_TYPE_NAME AS 'NAME' FROM MASTER_ACCOUNT_TYPE"))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    TipeComboBox.DataSource = dt;
                    TipeComboBox.ValueMember = "ID";
                    TipeComboBox.DisplayMember = "NAME";
                }
            }
            TipeComboBox.SelectedIndex = 1;
        }

        private void dataNomorAkunDetailForm_Activated(object sender, EventArgs e)
        {
            //if need something
            loadtypeaccount();
            errorLabel.Text = "";
            switch (originModuleID)
            {
                case globalConstants.NEW_AKUN:
                    options = gUtil.INS;
                    NonactiveCheckbox.Enabled = false;
                    break;
                case globalConstants.EDIT_AKUN:
                    options = gUtil.UPD;
                    NonactiveCheckbox.Enabled = true;
                    loadAccountData();
                    break;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);
        }

        private bool dataValidated()
        {
            if (kodeTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "KODE AKUN TIDAK BOLEH KOSONG. ";
                return false;
            }

            if (DeskripsiTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "DESKRIPSI AKUN TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string kodeakun = kodeTextbox.Text.Trim();
            string deskripsiakun = DeskripsiTextbox.Text.Trim();
            int tipeakun = Int32.Parse(TipeComboBox.SelectedValue.ToString());
            int nonactive = 1;
            if (NonactiveCheckbox.Checked == true)
            {
                nonactive = 0;
            }

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_AKUN:
                        sqlCommand = "INSERT INTO MASTER_ACCOUNT (ACCOUNT_ID, ACCOUNT_NAME, ACCOUNT_TYPE_ID, ACCOUNT_ACTIVE) " +
                                            "VALUES ('" + kodeakun + "', '" + deskripsiakun + "', '" + tipeakun + "', " + nonactive + ")";
                        break;
                    case globalConstants.EDIT_AKUN:
                        sqlCommand = "UPDATE MASTER_ACCOUNT SET " +
                                            "ACCOUNT_ID = '" + kodeakun + "', " +
                                            "ACCOUNT_NAME = '" + deskripsiakun + "', " +
                                            "ACCOUNT_TYPE_ID = '" + tipeakun + "', " +
                                            "ACCOUNT_ACTIVE = '" + nonactive + "' " +
                                            "WHERE ID = '" + selectedAccountID + "'";
                        break;
                }

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gUtil.showDBOPError(e, "INSERT");
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
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            //save data
            if (saveData())
            {
                gUtil.showSuccess(options);
                gUtil.ResetAllControls(this);
            }
        }

        private void TipeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string tmp = TipeComboBox.SelectedIndex.ToString();
            //selectedtipeakun = 1 + Int32.Parse(tmp);
        }
    }
}
