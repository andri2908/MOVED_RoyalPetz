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

namespace RoyalPetz_ADMIN
{
    public partial class penyesuaianStokForm : Form
    {
        private int selectedProductID = 0;
        private double selectedProductLimitStock = 0;

        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");

        public penyesuaianStokForm()
        {
            InitializeComponent();
        }

        public penyesuaianStokForm(int productID)
        {
            InitializeComponent();
            selectedProductID = productID;
        }

        private void loadProductData()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT * FROM MASTER_PRODUCT WHERE ID = " + selectedProductID;
            using(rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();

                    kodeProductTextBox.Text = rdr.GetString("PRODUCT_ID");
                    namaProductTextBox.Text = rdr.GetString("PRODUCT_NAME");
                    jumlahAwalMaskedTextBox.Text = rdr.GetString("PRODUCT_STOCK_QTY");
                    selectedProductLimitStock = rdr.GetDouble("PRODUCT_LIMIT_STOCK");
                }
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private void jumlahBaruMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            jumlahBaruMaskedTextBox.Text = gutil.allTrim(jumlahBaruMaskedTextBox.Text);
        }


        private bool dataValidated()
        {
            double newStockQty = 0;

            newStockQty = Convert.ToDouble(jumlahBaruMaskedTextBox.Text);

            if (newStockQty<=0)
            {
                if (DialogResult.No == MessageBox.Show("JUMLAH STOK BARU SEBESAR = " + newStockQty.ToString(), "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return false;
            }

            if (selectedProductLimitStock > newStockQty)
            {
                errorLabel.Text = "JUMLAH BARU DI BAWAH LIMIT STOCK";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            double newStockQty = 0;
            string adjustmentDate;
            string descriptionParam;

            MySqlException internalEX = null;

            newStockQty = Convert.ToDouble(jumlahBaruMaskedTextBox.Text);
            adjustmentDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            if (descriptionTextBox.Text.Length <= 0)
                descriptionTextBox.Text = " ";

            descriptionParam = MySqlHelper.EscapeString(descriptionTextBox.Text);

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // UPDATE MASTER PRODUCT WITH THE NEW QTY
                sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = " + newStockQty + " WHERE ID = " + selectedProductID;

                gutil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "UPDATE STOCK QTY [" + selectedProductID + "]");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                // INSERT INTO PRODUCT ADJUSTMENT TABLE
                sqlCommand = "INSERT INTO PRODUCT_ADJUSTMENT (PRODUCT_ID, PRODUCT_ADJUSTMENT_DATE, PRODUCT_OLD_STOCK_QTY, PRODUCT_NEW_STOCK_QTY, PRODUCT_ADJUSTMENT_DESCRIPTION) VALUES " +
                                    "('" + kodeProductTextBox.Text + "', STR_TO_DATE('" + adjustmentDate + "', '%d-%m-%Y'), " + jumlahAwalMaskedTextBox.Text + ", " + jumlahBaruMaskedTextBox.Text + ", '" + descriptionParam + "')";

                gutil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "INSERT INTO PRODUCT ADJUSTMENT TABLE [" + kodeProductTextBox.Text + ", " + jumlahAwalMaskedTextBox.Text + ", " + jumlahBaruMaskedTextBox.Text + "]");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

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
                        gutil.showDBOPError(ex, "ROLLBACK");
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
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }
        
        private void saveButton_Click(object sender, EventArgs e)
        {
            gutil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "TRY TO DO MANUAL STOCK ADJUSTMENT");
            if (saveData())
            {
                gutil.saveUserChangeLog(globalConstants.MENU_PENYESUAIAN_STOK, globalConstants.CHANGE_LOG_UPDATE, "PENYESUAIAN STOK PRODUK [" + namaProductTextBox.Text + "] " + jumlahAwalMaskedTextBox.Text + "/" + jumlahBaruMaskedTextBox.Text);
                gutil.showSuccess(gutil.INS);
                saveButton.Enabled = false;
                errorLabel.Text = "";
            }
        }
        
        private void penyesuaianStokForm_Load(object sender, EventArgs e)
        {
            loadProductData();
            errorLabel.Text = "";
            gutil.reArrangeTabOrder(this);
        }

        private void penyesuaianStokForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }

        private void jumlahBaruMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                jumlahBaruMaskedTextBox.SelectAll();
            });
        }
    }
}
