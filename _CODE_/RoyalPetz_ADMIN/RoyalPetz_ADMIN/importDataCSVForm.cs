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
                // skip the first line 
                s = sr.ReadLine();

                while ((s = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(s);
                    sValue = s.Split(',');
                    detailImportDataGrid.Rows.Add(sValue);
                }
            }
            
            return result;
        }

        private void searchKategoriButton_Click(object sender, EventArgs e)
        {
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
            string produkQty;
            string productID;
            int i = 0;
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                i = 0;
                while (i<detailImportDataGrid.Rows.Count)
                {
                    produkQty = detailImportDataGrid.Rows[i].Cells["productRealQty"].Value.ToString();
                    productID = detailImportDataGrid.Rows[i].Cells["productID"].Value.ToString();

                    sqlCommand = "UPDATE MASTER_PRODUCT SET " +
                                        "PRODUCT_STOCK_QTY = " + produkQty + " " +
                                        "WHERE PRODUCT_ID = '" + productID + "'";

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    i += 1;
                }

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
                if (saveDataTransaction())
                {
                    gutil.showSuccess(gutil.UPD);
                }
        }

        private void importDataCSVForm_Load(object sender, EventArgs e)
        {
            importButton.Enabled = false;
            gutil.reArrangeTabOrder(this);
        }

    }
}
