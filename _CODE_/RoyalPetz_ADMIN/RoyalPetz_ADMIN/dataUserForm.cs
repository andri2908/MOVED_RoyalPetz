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
        private globalUtilities gutil = new globalUtilities();

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
            string sqlfiltergroup, filtergroup;
            
            filtergroup = groupcombobox.SelectedValue.ToString();
            if (filtergroup.Equals("0"))
            {
                sqlfiltergroup = "";
            } else
            {
                sqlfiltergroup = "AND MASTER_USER.GROUP_ID = '" + filtergroup + "' ";
            }
            DS.mySqlConnect();

            if (usernonactiveoption.Checked)
            {
                sqlCommand = "SELECT ID, USER_NAME AS 'USER NAME', USER_FULL_NAME AS 'USER FULL NAME', MASTER_GROUP.GROUP_USER_NAME AS 'NAMA GROUP' " +
                                "FROM MASTER_USER, MASTER_GROUP " +
                                "WHERE MASTER_USER.GROUP_ID = MASTER_GROUP.GROUP_ID " + sqlfiltergroup + "AND MASTER_USER.USER_NAME LIKE '%" + userName + "%'";
            }
            else
            {
                sqlCommand = "SELECT ID, USER_NAME AS 'USER NAME', USER_FULL_NAME AS 'USER FULL NAME', MASTER_GROUP.GROUP_USER_NAME AS 'NAMA GROUP' " +
                                "FROM MASTER_USER, MASTER_GROUP " +
                                "WHERE USER_ACTIVE = 1 AND MASTER_USER.GROUP_ID = MASTER_GROUP.GROUP_ID " + sqlfiltergroup + "AND MASTER_USER.USER_NAME LIKE '%" + userName + "%'";
            }
            

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

        private void loadGroupUser()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();
            sqlCommand = "SELECT GROUP_ID AS 'ID', GROUP_USER_NAME AS 'NAME' " +
                                "FROM MASTER_GROUP " +
                                "WHERE GROUP_USER_ACTIVE = 1";
                                    
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Columns.Add("ID", typeof(string));
                    dt.Columns.Add("NAME", typeof(string));
                    dt.Load(rdr);
                    dt.Rows.Add("0", "ALL");
                    groupcombobox.ValueMember = "ID";
                    groupcombobox.DisplayMember = "NAME";
                    groupcombobox.DataSource = dt;
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
            loadGroupUser();
            groupcombobox.SelectedValue = "0";
            groupcombobox.Text = "ALL";
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void namaUserTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void dataUserForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void usernonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataUserGridView.DataSource = null;
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }

        private void groupcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataUserGridView.DataSource = null;
            if (!namaUserTextbox.Text.Equals(""))
                loadUserData(namaUserTextbox.Text);
        }
    }
}
