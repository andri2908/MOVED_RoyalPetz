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
    public partial class pengaturanKategoriProdukForm : Form
    {
        private struct categoryProduct
        {
            public string productID;
            public bool hasCategoryID;
        }

        private string previousInput = "";
        private int selectedCategoryID = 0;
        private Data_Access DS = new Data_Access();
        private List<categoryProduct> categoryProductValue = new List<categoryProduct>();
        private globalUtilities gutil = new globalUtilities();
        
        public pengaturanKategoriProdukForm()
        {
            InitializeComponent();
        }

        public pengaturanKategoriProdukForm(int categoryID)
        {
            InitializeComponent();
            selectedCategoryID = categoryID;
        }

        private void fillInDummydata()
        {
            namaKategoriTextbox.Text = "PROMOSI";
            deskripsiTextbox.Text = "PROMOSI";
            namaProdukTextbox.Text = "ITEM";

            pengaturanKategoriDataGridView.Rows.Add("item 1", false);
            pengaturanKategoriDataGridView.Rows.Add("item 2", true);
            pengaturanKategoriDataGridView.Rows.Add("item 3", false);
            pengaturanKategoriDataGridView.Rows.Add("item 4", true);
        }

        private void loadKategoriInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT IFNULL(CATEGORY_NAME, '') AS CATEGORY_NAME, IFNULL(CATEGORY_DESCRIPTION, '') AS CATEGORY_DESCRIPTION FROM MASTER_CATEGORY WHERE CATEGORY_ID =  " + selectedCategoryID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        namaKategoriTextbox.Text = rdr.GetString("CATEGORY_NAME");
                        deskripsiTextbox.Text = rdr.GetString("CATEGORY_DESCRIPTION");
                    }
                }
            }            
        }

        private void loadProdukName()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            bool valCheckBox = false;
            string sqlCommand = "";
            categoryProduct tempValue;
            string namaProductParam = MySqlHelper.EscapeString(namaProdukTextbox.Text);
            string kodeProductParam = MySqlHelper.EscapeString(textBox1.Text);


            DS.mySqlConnect();
            sqlCommand = "SELECT M.PRODUCT_ID, M.PRODUCT_NAME, IFNULL(P.CATEGORY_ID, 0) AS CATEGORY_ID FROM MASTER_PRODUCT M LEFT OUTER JOIN PRODUCT_CATEGORY P ON (P.PRODUCT_ID = M.PRODUCT_ID AND P.CATEGORY_ID = " + selectedCategoryID + ") WHERE M.PRODUCT_NAME LIKE '%" + namaProductParam + "%' AND M.PRODUCT_ID LIKE '%" + kodeProductParam + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (!rdr.GetString("CATEGORY_ID").Equals("0"))
                            valCheckBox = true;
                        else
                            valCheckBox = false;
                        
                        pengaturanKategoriDataGridView.Rows.Add(false, rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), valCheckBox);
                        
                        tempValue.productID = rdr.GetString("PRODUCT_ID");
                        tempValue.hasCategoryID = valCheckBox;

                        categoryProductValue.Add(tempValue);
                    }
                }
            }            
        }

        private void pengaturanKategoriProdukForm_Load(object sender, EventArgs e)
        {
            //loadKategoriInformation();
            //fillInDummydata();
            gutil.reArrangeTabOrder(this);
        }

        private void namaProdukTextbox_TextChanged(object sender, EventArgs e)
        {
            bool continueProcess = true;

            /*if ( previousInput.Equals(namaProdukTextbox.Text) )
                return;

            if (!previousInput.Equals(""))
            {
                if (DialogResult.Yes == MessageBox.Show("GANTI TAMPILAN DATA ?", "WARNING", MessageBoxButtons.YesNo))
                    continueProcess = true;
                else
                    continueProcess = false;
            }
            */

            if (continueProcess)
            {
                categoryProductValue.Clear();
                pengaturanKategoriDataGridView.Rows.Clear();
                loadProdukName();
                
                previousInput = namaProdukTextbox.Text;
            }
            else
                namaProdukTextbox.Text = previousInput;           
        }

        private void pengaturanKategoriDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if ( pengaturanKategoriDataGridView.SelectedCells.Count <= 0 )
                return;

            int selectedrowindex = pengaturanKategoriDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = pengaturanKategoriDataGridView.Rows[selectedrowindex];

            if ( categoryProductValue[selectedrowindex].hasCategoryID != Convert.ToBoolean(selectedRow.Cells["hakAkses"].Value))                         
            {
                selectedRow.Cells["changed"].Value = true;

                namaProdukTextbox.ReadOnly = true;
                textBox1.ReadOnly = true;
                selectedRow.DefaultCellStyle.BackColor = Color.LightCoral;
       //         namaProdukTextbox.BackColor = Color.Red;
            }
            else
            {
                selectedRow.DefaultCellStyle.BackColor = Color.White;
            }

        }

        private bool dataValidated()
        {
            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                for (int i = 0; i < pengaturanKategoriDataGridView.Rows.Count; i++)
                {
                    if (categoryProductValue[i].hasCategoryID != Convert.ToBoolean(pengaturanKategoriDataGridView.Rows[i].Cells["hakAkses"].Value))
                    {
                        if ((categoryProductValue[i].hasCategoryID))
                        {
                            sqlCommand = "DELETE FROM PRODUCT_CATEGORY WHERE PRODUCT_ID = '" + pengaturanKategoriDataGridView.Rows[i].Cells["PRODUCT_ID"].Value.ToString() + "' AND CATEGORY_ID = " + selectedCategoryID;
                            gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_KATEGORI_PRODUK, "REMOVE CATEGORY ["+ selectedCategoryID+"] FOR PRODUCT ["+ pengaturanKategoriDataGridView.Rows[i].Cells["PRODUCT_ID"].Value.ToString()+"]");
                        }
                        else 
                        {
                            sqlCommand = "INSERT INTO PRODUCT_CATEGORY (PRODUCT_ID, CATEGORY_ID) VALUES ('" + pengaturanKategoriDataGridView.Rows[i].Cells["PRODUCT_ID"].Value.ToString() + "', " + selectedCategoryID + ")";
                            gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_KATEGORI_PRODUK, "ADD CATEGORY [" + selectedCategoryID + "] FOR PRODUCT [" + pengaturanKategoriDataGridView.Rows[i].Cells["PRODUCT_ID"].Value.ToString() + "]");
                        }

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;
                    }
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_KATEGORI_PRODUK, "EXCEPTION THROWN [" + e.Message + "]");

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
            if (saveData())
            {
                gutil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_KATEGORI_PRODUK, globalConstants.CHANGE_LOG_UPDATE, "PENGATURAN KATEGORI PRODUK [" + namaKategoriTextbox.Text + "]");
                //MessageBox.Show("SUCCESS");
                gutil.showSuccess(gutil.UPD);
                //gutil.ResetAllControls(this); //notneeded?
                pengaturanKategoriDataGridView.Rows.Clear();
                categoryProductValue.Clear();
                namaProdukTextbox.ReadOnly = false;
                textBox1.ReadOnly = false;
                loadProdukName();
            }
        }

        private void pengaturanKategoriDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void pengaturanKategoriProdukForm_Activated(object sender, EventArgs e)
        {
            loadKategoriInformation();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            categoryProductValue.Clear();
            pengaturanKategoriDataGridView.Rows.Clear();
            loadProdukName();
        }
    }
}
