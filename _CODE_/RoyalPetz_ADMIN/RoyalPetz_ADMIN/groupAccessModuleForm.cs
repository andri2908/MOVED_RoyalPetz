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
    public partial class groupAccessModuleForm : Form
    {
        private Data_Access DS = new Data_Access();

        private int selectedGroupID = 0;

        private void fillInDummyData()
        {
            groupAccessDataGridView.Rows.Add("PENGATURAN LOKASI DATABASE", false);
            groupAccessDataGridView.Rows.Add("BACKUP/RESTORE DATABASE", false);
            groupAccessDataGridView.Rows.Add("TAMBAH USER", false);
            groupAccessDataGridView.Rows.Add("HAPUS USER", false);
            groupAccessDataGridView.Rows.Add("EDIT USER", false);
        }
            
        public groupAccessModuleForm()
        {
            InitializeComponent();
        }

        public groupAccessModuleForm(int groupID)
        {
            InitializeComponent();

            selectedGroupID = groupID;
        }

        public void setSelectedGroupID(int groupID)
        {
            selectedGroupID = groupID;
        }

        private void newGroupButton_Click(object sender, EventArgs e)
        {
            dataGroupDetailForm displayForm = new dataGroupDetailForm(globalConstants.PENGATURAN_GRUP_AKSES);
            displayForm.ShowDialog(this);

            loadGroupUserInformation();
        }

        private void loadGroupUserInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_GROUP WHERE GROUP_ID = " + selectedGroupID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        namaGroupTextBox.Text = rdr.GetString("GROUP_USER_NAME");
                        deskripsiTextBox.Text = rdr.GetString("GROUP_USER_DESCRIPTION");
                    }
                }
            }
        }

        private void loadUserAccessInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";

            int moduleFeatures;
            int userAccess;

            DS.mySqlConnect();

            sqlCommand = "SELECT MM.MODULE_ID, MM.MODULE_NAME, MM.MODULE_FEATURES, IFNULL(UAM.USER_ACCESS_OPTION,0) AS USER_ACCESS_OPTION " +
                                "FROM MASTER_MODULE MM LEFT OUTER JOIN USER_ACCESS_MANAGEMENT UAM ON (MM.MODULE_ID = UAM.MODULE_ID AND UAM.GROUP_ID = " + selectedGroupID + ") " +
                                "WHERE MM.MODULE_ACTIVE = 1";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        moduleFeatures = rdr.GetInt32("MODULE_FEATURES");
                        userAccess = rdr.GetInt32("USER_ACCESS_OPTION");

                        switch(moduleFeatures)
                        {
                            case 1: // VIEW
                                break;
                            case 2: // ENABLE, DISABLE
                                if (userAccess == 1)
                                    groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME"), true, rdr.GetString("MODULE_ID"), "1");
                                else
                                    groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "1");
                                break;

                            case 3: // INSERT, UPDATE, DELETE
                                //groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME"), false, rdr.GetString("MODULE_ID"), "1111");
                                groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME") + " - VIEW", false, rdr.GetString("MODULE_ID"), "1000");
                                groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME") + " - INSERT", false, rdr.GetString("MODULE_ID"), "100");
                                groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME") + " - UPDATE", false, rdr.GetString("MODULE_ID"), "10");
                                groupAccessDataGridView.Rows.Add(rdr.GetString("MODULE_NAME") + " - DELETE", false, rdr.GetString("MODULE_ID"), "1"); 
                                break;
                        }
                    }
                }
            }
        }

        private void groupAccessModuleForm_Load(object sender, EventArgs e)
        {
            loadGroupUserInformation();
            loadUserAccessInformation();
           //fillInDummyData();
        }
    }
}
