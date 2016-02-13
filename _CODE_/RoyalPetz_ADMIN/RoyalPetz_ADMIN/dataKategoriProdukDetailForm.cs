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
    public partial class dataKategoriProdukDetailForm : Form
    {
        private int originModuleID = 0;
        private int selectedCategoryID = 0;

        Data_Access DS = new Data_Access();

        public dataKategoriProdukDetailForm()
        {
            InitializeComponent();
        }

        public dataKategoriProdukDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;            
        }

        public dataKategoriProdukDetailForm(int moduleID, int categoryID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedCategoryID = categoryID;
        }

        private void loadDataKategori()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_CATEGORY WHERE CATEGORY_ID =  " + selectedCategoryID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        categoryNameTextBox.Text = rdr.GetString("CATEGORY_NAME");
                        categoryDescriptionTextBox.Text = rdr.GetString("CATEGORY_DESCRIPTION");

                        if (rdr.GetString("CATEGORY_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }
        }

        private void dataKategoriProdukDetailForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";

            loadDataKategori();
        }

        private bool dataValidated()
        {
            if (categoryNameTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NAMA KATEGORI TIDAK BOLEH KOSONG";
                return false;
            }

            if (categoryDescriptionTextBox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "DESKRIPSI KATEGORI TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string categoryName = categoryNameTextBox.Text.Trim();
            string categoryDesc = categoryDescriptionTextBox.Text.Trim();           

            byte categoryStatus = 0;

            if (nonAktifCheckbox.Checked)
                categoryStatus = 0;
            else
                categoryStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_CATEGORY:
                        sqlCommand = "INSERT INTO MASTER_CATEGORY (CATEGORY_NAME, CATEGORY_DESCRIPTION, CATEGORY_ACTIVE) " +
                                            "VALUES ('" + categoryName + "', '" + categoryDesc + "', " + categoryStatus + ")";
                        break;
                    case globalConstants.EDIT_CATEGORY:
                        sqlCommand = "UPDATE MASTER_CATEGORY SET " +
                                            "CATEGORY_NAME = '" + categoryName + "', " +
                                            "CATEGORY_DESCRIPTION = '" + categoryDesc + "', " +
                                            "CATEGORY_ACTIVE = " + categoryStatus + " " +
                                            "WHERE CATEGORY_ID = " + selectedCategoryID;
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
            if (saveData())
            {
                MessageBox.Show("SUCCESS");
            }
        }
    }
}
