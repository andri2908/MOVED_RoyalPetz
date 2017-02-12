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
    public partial class barcodeForm : Form
    {
        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        Form parentForm;
        cashierForm originCashierForm;
        penerimaanBarangForm originPenerimaanForm;
        purchaseOrderDetailForm originPOForm;
        dataMutasiBarangDetailForm originMutasiForm;
        permintaanProdukForm originRequestForm;
        dataReturPenjualanForm originReturJualForm;
        dataReturPermintaanForm originReturBeliForm;

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

        private string getProductID(string barcodeValue)
        {
            string productID = "";

            if (barcodeValue.Length > 0)
                try
                {
                    productID = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_ID, '') FROM MASTER_PRODUCT WHERE PRODUCT_BARCODE = '" + barcodeValue + "'").ToString();
                }
                catch (Exception e)
                { }

            return productID;
        }

        private void barcodeTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void barcodeForm_Load(object sender, EventArgs e)
        {
            barcodeTextBox.Select();
        }

        private void barcodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string productID = "";
            if (e.KeyChar == 13)
            { 
                productNameTextBox.Text = getProductName(barcodeTextBox.Text);
                productID = getProductID(barcodeTextBox.Text);

                if (productNameTextBox.Text.Length > 0)
                {
                    switch(originModuleID)
                    {
                        case globalConstants.CASHIER_MODULE:
                            originCashierForm = (cashierForm)parentForm;
                            originCashierForm.addNewRowFromBarcode(productID, productNameTextBox.Text);
                            break;

                        case globalConstants.PENERIMAAN_BARANG:
                            originPenerimaanForm = (penerimaanBarangForm)parentForm;
                            originPenerimaanForm.addNewRowFromBarcode(productID, productNameTextBox.Text);
                            break;

                        case globalConstants.NEW_PURCHASE_ORDER:
                            originPOForm = (purchaseOrderDetailForm)parentForm;
                            originPOForm.addNewRowFromBarcode(productID, productNameTextBox.Text);
                            break;

                        case globalConstants.MUTASI_BARANG:
                            originMutasiForm = (dataMutasiBarangDetailForm)parentForm;
                            originMutasiForm.addNewRowFromBarcode(productID, productNameTextBox.Text);
                            break;

                        case globalConstants.NEW_REQUEST_ORDER:
                            originRequestForm = (permintaanProdukForm)parentForm;
                            originRequestForm.addNewRowFromBarcode(productID, productNameTextBox.Text);
                            break;

                        case globalConstants.RETUR_PENJUALAN:
                            originReturJualForm = (dataReturPenjualanForm)parentForm;
                            originReturJualForm.addNewRowFromBarcode(productID, productNameTextBox.Text);
                            break;

                        case globalConstants.RETUR_PEMBELIAN:
                            originReturBeliForm = (dataReturPermintaanForm)parentForm;
                            originReturBeliForm.addNewRowFromBarcode(productID, productNameTextBox.Text);
                            break;

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
