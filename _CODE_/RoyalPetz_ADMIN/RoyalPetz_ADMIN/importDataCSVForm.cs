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
using System.Globalization;
using System.IO;

namespace RoyalPetz_ADMIN
{
    public partial class importDataCSVForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");        

        string selectedFileName = "";

        public importDataCSVForm()
        {
            InitializeComponent();
        }

        private bool loadToDataGrid()
        {
            bool result = true;
            string s = "";
            string[] sValue;

            detailImportDataGrid.Rows.Clear();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(selectedFileName))
            {
                // skip the first and second line 
                //s = sr.ReadLine();
                //exportDate.Text = s;

                s = sr.ReadLine();

                while ((s = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(s);
                    sValue = s.Split(',');
                    if (!sValue[3].Equals(sValue[4]))
                        detailImportDataGrid.Rows.Add(sValue);
                }
            }
            
            return result;
        }

        private void searchKategoriButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CSV File(.csv) | *.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = openFileDialog1.FileName;

                importFileNameTextBox.Text = selectedFileName;
                
                if (loadToDataGrid())
                    importButton.Enabled = true;
            }
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            string productQty;
            string productOldQty;
            string productID;
            string adjusmentDate = "";
            string productDescription = "";
            int i = 0;
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                adjusmentDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

                DS.mySqlConnect();

                i = 0;
                while (i<detailImportDataGrid.Rows.Count)
                {
                    productQty = detailImportDataGrid.Rows[i].Cells["productRealQty"].Value.ToString();
                    productID = MySqlHelper.EscapeString(detailImportDataGrid.Rows[i].Cells["productID"].Value.ToString());
                    productOldQty = detailImportDataGrid.Rows[i].Cells["productQty"].Value.ToString();
                    productDescription =MySqlHelper.EscapeString(detailImportDataGrid.Rows[i].Cells["description"].Value.ToString());

                    if (!productOldQty.Equals(productQty))
                    { 
                        sqlCommand = "UPDATE MASTER_PRODUCT SET " +
                                            "PRODUCT_STOCK_QTY = " + productQty + " " +
                                            "WHERE PRODUCT_ID = '" + productID + "'";

                        gutil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "UPDATE STOCK QTY [" + productID + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        sqlCommand = "INSERT INTO PRODUCT_ADJUSTMENT (PRODUCT_ID, PRODUCT_ADJUSTMENT_DATE, PRODUCT_OLD_STOCK_QTY, PRODUCT_NEW_STOCK_QTY, PRODUCT_ADJUSTMENT_DESCRIPTION) " +
                                            "VALUES " +
                                            "('" + productID + "', STR_TO_DATE('" + adjusmentDate + "', '%d-%m-%Y'), " + productOldQty + ", " + productQty + ", '" + productDescription + "')";

                        gutil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "INSERT INTO PRODUCT ADJUSTMENT [" + productID + ", " + productOldQty + ", " + productQty + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;
                    }

                    i += 1;
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "EXCEPTION THROWN [" + e.Message + "]");
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

                gutil.showDBOPError(e, "ROLLBACK");
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }
        
        private void importButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("IMPORT DATA ?", "WARNING", MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "TRY TO IMPORT DATA FROM CSV FILE"); 
                if (saveDataTransaction())
                {
                    gutil.saveUserChangeLog(globalConstants.MENU_PENYESUAIAN_STOK, globalConstants.CHANGE_LOG_UPDATE, "IMPORT DATA CSV [" + importFileNameTextBox.Text + "]");
                    gutil.showSuccess(gutil.UPD);
                    searchKategoriButton.Enabled = false;
                    importButton.Enabled = false;
                    detailImportDataGrid.ReadOnly = true;
                }
            }
        }

        private void importDataCSVForm_Load(object sender, EventArgs e)
        {
            importButton.Enabled = false;
            exportDate.Text = "";
            gutil.reArrangeTabOrder(this);
        }

    }
}
