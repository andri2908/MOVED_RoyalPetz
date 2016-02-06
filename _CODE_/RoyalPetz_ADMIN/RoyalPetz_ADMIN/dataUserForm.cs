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
    public partial class dataUserForm : Form
    {
        private int originModuleID = 0;
        private int selectedUserID = 0;

        Data_Access DS = new Data_Access();

        public dataUserForm()
        {
            InitializeComponent();
        }

        public dataUserForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;

            newButton.Visible = false;
        }

        private void loadUserData(string userName)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            sqlCommand = "SELECT ID, USER_NAME AS 'USER NAME', USER_FULL_NAME AS 'USER FULL NAME', MASTER_GROUP.GROUP_USER_NAME AS 'NAMA GROUP' " +
                                "FROM MASTER_USER, MASTER_GROUP " +
                                "WHERE USER_ACTIVE = 1 AND MASTER_USER.GROUP_ID = MASTER_GROUP.GROUP_ID AND MASTER_USER.USER_NAME LIKE '%"+userName+"%'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataUserGridView.DataSource = dt;

                    dataUserGridView.Columns["ID"].Visible = false;
                    dataUserGridView.Columns["USER NAME"].Width = 200;
                    dataUserGridView.Columns["USER FULL NAME"].Width = 300;
                    dataUserGridView.Columns["NAMA GROUP"].Width = 200;
                }
            }

        }
        
        
        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                default:
                    dataUserDetailForm displayForm = new dataUserDetailForm(globalConstants.EDIT_USER, selectedUserID);
                    displayForm.ShowDialog(this);
                    break;
            }
        }


        private void newButton_Click(object sender, EventArgs e)
        {
            dataUserDetailForm displayForm = new dataUserDetailForm(globalConstants.NEW_USER);
            displayForm.ShowDialog(this);
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataUserGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataUserGridView.Rows[selectedrowindex];
            selectedUserID = Convert.ToInt32(selectedRow.Cells["ID"].Value);

            displaySpecificForm();
        }

        private void dataUserForm_Activated(object sender, EventArgs e)
        {
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void namaUserTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }
    }
}
