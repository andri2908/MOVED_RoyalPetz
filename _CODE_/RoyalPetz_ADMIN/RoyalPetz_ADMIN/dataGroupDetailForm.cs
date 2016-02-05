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
    public partial class dataGroupDetailForm : Form
    {
        private int originModuleID = 0;
        private int selectedGroupID = 0;

        private Data_Access DS = new Data_Access();
        private globalStringOP stringOP = new globalStringOP();

        public dataGroupDetailForm()
        {
            InitializeComponent();
        }

        public dataGroupDetailForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        public dataGroupDetailForm(int moduleID, int groupID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedGroupID = groupID;
        }

        private void loadUserGroupDataInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_GROUP WHERE GROUP_ID = "+selectedGroupID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    { 
                        namaGroupTextBox.Text = rdr.GetString("GROUP_USER_NAME");
                        deskripsiTextBox.Text = rdr.GetString("GROUP_USER_DESCRIPTION");

                        if (rdr.GetString("GROUP_USER_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = true;
                        else
                            nonAktifCheckbox.Checked = false;
                    }
                }
            }
        }

        private void dataGroupDetailForm_Load(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.EDIT_GROUP_USER)
            { 
                loadUserGroupDataInformation();
            }
        }

        private bool dataValidated()
        {
            bool result = false;



            return true;
        }

        private bool saveData()
        {
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string groupName = namaGroupTextBox.Text.Trim();
            string groupDesc = deskripsiTextBox.Text.Trim();
            byte groupStatus= 0;

            if (nonAktifCheckbox.Checked)
                groupStatus = 0;
            else
                groupStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch(originModuleID)
                {
                    case globalConstants.NEW_GROUP_USER:
                        sqlCommand = "INSERT INTO MASTER_GROUP (GROUP_USER_NAME, GROUP_USER_DESCRIPTION, GROUP_USER_ACTIVE) VALUES ('" + groupName + "', '" + groupDesc + "', " + groupStatus + ")";
                        break;
                    case globalConstants.EDIT_GROUP_USER:
                        sqlCommand = "UPDATE MASTER_GROUP SET GROUP_USER_NAME = '" + groupName + "', GROUP_USER_DESCRIPTION = '" + groupDesc + "', GROUP_USER_ACTIVE = " + groupStatus + " WHERE GROUP_ID = "+selectedGroupID;
                        break;
                }

                DS.executeNonQueryCommand(sqlCommand);

                DS.commit();
            }
            catch (Exception e)
            {
                try
                {
                    //myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        MessageBox.Show("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }

                MessageBox.Show("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                MessageBox.Show("Neither record was written to database.");
            }
            finally
            {
                DS.mySqlClose();
                result = true;
            }

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("SUCCESS");
                //this.Close();
            }
        }
    }
}
