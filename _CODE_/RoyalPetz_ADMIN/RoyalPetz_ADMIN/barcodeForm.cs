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
    public partial class barcodeForm : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        Form parentForm;
        cashierForm originCashierForm;
        penerimaanBarangForm originPenerimaanForm;
        int originModuleID = 0;

        public barcodeForm(Form originForm, int moduleID)
        {
            InitializeComponent();

            parentForm = originForm;
            originModuleID = moduleID;
        }

        private string getProductName(string barcodeValue)
        {
            string productName = "";

            if (barcodeValue.Length > 0)
                try
                { 
                    productName = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_NAME, '') FROM MASTER_PRODUCT WHERE PRODUCT_BARCODE = '" + barcodeValue + "'").ToString();
                }
                catch (Exception e)
                {}

            return productName;
        }

        private void barcodeTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void barcodeForm_Load(object sender, EventArgs e)
        {
            barcodeTextBox.Focus();
            DS.mySqlConnect();
        }

        private void barcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            { 
                productNameTextBox.Text = getProductName(barcodeTextBox.Text);

                if (productNameTextBox.Text.Length > 0)
                {
                    if (originModuleID == globalConstants.CASHIER_MODULE)
                    {
                        originCashierForm = (cashierForm)parentForm;
                        originCashierForm.addNewRowFromBarcode(productNameTextBox.Text);
                    }
                    else if (originModuleID == globalConstants.PENERIMAAN_BARANG)
                    {
                        originPenerimaanForm = (penerimaanBarangForm)parentForm;
                        originPenerimaanForm.addNewRowFromBarcode(productNameTextBox.Text);
                    }
                }

                barcodeTextBox.SelectAll();
            }
            else if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

        private void productNameTextBox_Validated(object sender, EventArgs e)
        {
        }

        private void barcodeTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                barcodeTextBox.SelectAll();
            });
        }

        private void productNameTextBox_Enter(object sender, EventArgs e)
        {
            barcodeTextBox.Focus();
        }
    }
}
