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
    public partial class dataNomorAkun : Form
    {
        private int originModuleID = 0;
        private globalUtilities gutil = new globalUtilities();
        private int selectedAccountID = 0;
        private dataTransaksiJurnalHarianDetailForm parentForm;
        private Data_Access DS = new Data_Access();

        public dataNomorAkun()
        {
            InitializeComponent();
        }

        public dataNomorAkun(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            newButton.Visible = false;
        }

        public dataNomorAkun(int moduleID, dataTransaksiJurnalHarianDetailForm thisForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = thisForm;
        }

        private void displaySpecificForm()
        {
            int selectedrowindex = dataAccountGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataAccountGridView.Rows[selectedrowindex];
            selectedAccountID = Convert.ToInt32(selectedRow.Cells["KODE AKUN"].Value);

            switch (originModuleID)
            {
                case globalConstants.TAMBAH_HAPUS_JURNAL_HARIAN:
                    parentForm.addSelectedAccountID(selectedAccountID);
                    this.Close();
                    break;
                default:
                    dataNomorAkunDetailForm displayedForm = new dataNomorAkunDetailForm(globalConstants.EDIT_AKUN, selectedAccountID);
                    displayedForm.ShowDialog(this);
                    break;
            }
        }

        private void loadAccountData(string accountnameParam)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string accountName = MySqlHelper.EscapeString(accountnameParam);

            DS.mySqlConnect();
            if (accountnonactiveoption.Checked)
            {
                sqlCommand = "SELECT MASTER_ACCOUNT.ID AS 'ID', MASTER_ACCOUNT.ACCOUNT_ID AS 'KODE AKUN', MASTER_ACCOUNT.ACCOUNT_NAME AS 'DESKRIPSI', MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_NAME AS 'TIPE' FROM MASTER_ACCOUNT, MASTER_ACCOUNT_TYPE WHERE MASTER_ACCOUNT.ACCOUNT_TYPE_ID = MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_ID AND MASTER_ACCOUNT.ACCOUNT_NAME LIKE '%" + accountName + "%'";
            }
            else
            {
                sqlCommand = "SELECT MASTER_ACCOUNT.ID AS 'ID', MASTER_ACCOUNT.ACCOUNT_ID AS 'KODE AKUN', MASTER_ACCOUNT.ACCOUNT_NAME AS 'DESKRIPSI', MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_NAME AS 'TIPE' FROM MASTER_ACCOUNT, MASTER_ACCOUNT_TYPE WHERE MASTER_ACCOUNT.ACCOUNT_ACTIVE = 1 AND MASTER_ACCOUNT.ACCOUNT_TYPE_ID = MASTER_ACCOUNT_TYPE.ACCOUNT_TYPE_ID AND MASTER_ACCOUNT.ACCOUNT_NAME LIKE '%" + accountName + "%'";
            }
            
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataAccountGridView.DataSource = dt;

                    dataAccountGridView.Columns["ID"].Visible = false;
                    dataAccountGridView.Columns["KODE AKUN"].Width = 150;
                    dataAccountGridView.Columns["DESKRIPSI"].Width = 250;
                    dataAccountGridView.Columns["TIPE"].Width = 100;
                }
            }
        }

        private void dataNomorAkun_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            gutil.reArrangeTabOrder(this);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PENGATURAN_NO_AKUN, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
                newButton.Visible = true;
            else
                newButton.Visible = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataNomorAkunDetailForm displayedForm = new dataNomorAkunDetailForm(globalConstants.NEW_AKUN, 0);
            displayedForm.ShowDialog(this);
        }

        private void dataNomorAkun_Activated(object sender, EventArgs e)
        {
            //if need something
            if (!namaAccountTextbox.Text.Equals(""))
            {
                loadAccountData(namaAccountTextbox.Text);
            }
        }

        private void accountnonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataAccountGridView.DataSource = null;
            if (!namaAccountTextbox.Text.Equals(""))
            {
                loadAccountData(namaAccountTextbox.Text);
            }
            //loaddata
        }
           
        private void namaAccountTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaAccountTextbox.Text.Equals(""))
            {
                loadAccountData(namaAccountTextbox.Text);
            }
        }

        private void dataAccountGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataAccountGridView.Rows.Count > 0)
                displaySpecificForm();

           /* int selectedrowindex = dataAccountGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataAccountGridView.Rows[selectedrowindex];
            selectedAccountID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            dataNomorAkunDetailForm displayedForm = new dataNomorAkunDetailForm(globalConstants.EDIT_AKUN, selectedAccountID);
            displayedForm.ShowDialog(this);

            */
        }

        private void dataAccountGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (dataAccountGridView.Rows.Count > 0)
                    displaySpecificForm();
        }

        private void dataAccountGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataAccountGridView.Rows.Count > 0)
                displaySpecificForm();
        }
    }
}
