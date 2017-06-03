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

using Hotkeys;

namespace AlphaSoft
{
    public partial class penyesuaianStokForm : Form
    {
        private int selectedProductID = 0;
        private int selectedLotID = 0;
        private double selectedProductLimitStock = 0;

        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private DateTime originalProductExpiryDate;

        public penyesuaianStokForm()
        {
            InitializeComponent();
        }

        public penyesuaianStokForm(int productID)
        {
            InitializeComponent();

            if (globalFeatureList.EXPIRY_MODULE == 1)
                selectedLotID = productID;
            else
                selectedProductID = productID;
        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;
                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;

                if (modifier == Constants.NOMOD)
                    captureAll(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_UP = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_UP.Register();

            ghk_DOWN = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Down, this);
            ghk_DOWN.Register();
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
        }

        private void loadProductData()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            if (globalFeatureList.EXPIRY_MODULE == 1)
            {
                sqlCommand = "SELECT MP.ID, MP.PRODUCT_ID, MP.PRODUCT_NAME, PE.PRODUCT_AMOUNT, MP.PRODUCT_LIMIT_STOCK, PE.PRODUCT_EXPIRY_DATE FROM MASTER_PRODUCT MP, PRODUCT_EXPIRY PE WHERE PE.PRODUCT_ID = MP.PRODUCT_ID AND PE.ID = " + selectedLotID;
                using (rdr = DS.getData(sqlCommand))
                {
                    if (rdr.HasRows)
                    {
                        rdr.Read();

                        selectedProductID = rdr.GetInt32("ID");
                        kodeProductTextBox.Text = rdr.GetString("PRODUCT_ID");
                        namaProductTextBox.Text = rdr.GetString("PRODUCT_NAME");
                        jumlahAwalMaskedTextBox.Text = rdr.GetString("PRODUCT_AMOUNT");
                        selectedProductLimitStock = rdr.GetDouble("PRODUCT_LIMIT_STOCK");
                        expDatePicker.Value = rdr.GetDateTime("PRODUCT_EXPIRY_DATE");
                        originalProductExpiryDate = expDatePicker.Value;
                    }
                }
            }
            else
            {
                sqlCommand = "SELECT * FROM MASTER_PRODUCT WHERE ID = " + selectedProductID;
                using (rdr = DS.getData(sqlCommand))
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
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);
        }

        private void jumlahBaruMaskedTextBox_TextChanged(object sender, EventArgs e)
        {
            jumlahBaruMaskedTextBox.Text = gUtil.allTrim(jumlahBaruMaskedTextBox.Text);
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
            double oldStockQty = 0;
            double diffQty = 0;
            string adjustmentDate;
            string descriptionParam;
            string productExpiryDate;
            int lotID = 0;

            MySqlException internalEX = null;

            oldStockQty = Convert.ToDouble(jumlahAwalMaskedTextBox.Text);
            newStockQty = Convert.ToDouble(gUtil.allTrim(jumlahBaruMaskedTextBox.Text));
            adjustmentDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            if (descriptionTextBox.Text.Length <= 0)
                descriptionTextBox.Text = " ";

            descriptionParam = MySqlHelper.EscapeString(descriptionTextBox.Text);

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                if (globalFeatureList.EXPIRY_MODULE == 1)
                {
                    // INSERT TO PRODUCT_EXPIRY
                    //DateTime productExpiryDateValue = Convert.ToDateTime(detailGridView.Rows[i].Cells["expiryDateValue"].Value.ToString());
                    productExpiryDate = String.Format(culture, "{0:dd-MM-yyyy}", expDatePicker.Value);
                    string productID = kodeProductTextBox.Text;
                    expiryModuleUtil expUtil = new expiryModuleUtil();
                    double adjustmentQty = Convert.ToDouble(jumlahBaruMaskedTextBox.Text);

                    // CHECK WHETHER THE PRODUCT WITH SAME EXPIRY DATE EXIST
                    lotID = expUtil.getLotIDBasedOnExpiryDate(originalProductExpiryDate, productID);

                    if (lotID == 0)
                    {
                        //sqlCommand = "INSERT INTO PRODUCT_EXPIRY (PRODUCT_ID, PRODUCT_EXPIRY_DATE, PRODUCT_AMOUNT, PR_INVOICE) VALUES ( '" + detailGridView.Rows[i].Cells["productID"].Value.ToString() + "', STR_TO_DATE('" + productExpiryDate + "', '%d-%m-%Y'), " + Convert.ToDouble(detailGridView.Rows[i].Cells["qtyReceived"].Value) + ", '" + PRInvoice + "')";
                        sqlCommand = "INSERT INTO PRODUCT_EXPIRY (PRODUCT_ID, PRODUCT_EXPIRY_DATE, PRODUCT_AMOUNT) VALUES ( '" + kodeProductTextBox.Text + "', STR_TO_DATE('" + productExpiryDate + "', '%d-%m-%Y'), " + adjustmentQty + ")";
                    }
                    else
                        sqlCommand = "UPDATE PRODUCT_EXPIRY SET PRODUCT_AMOUNT = " + adjustmentQty + ",  PRODUCT_EXPIRY_DATE = STR_TO_DATE('" + productExpiryDate + "', '%d-%m-%Y') WHERE ID = " + lotID;

                    gUtil.saveSystemDebugLog(globalConstants.MENU_PENERIMAAN_BARANG, "INSERT TO PRODUCT EXPIRY [" + productID + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                if (globalFeatureList.EXPIRY_MODULE == 1)
                {
                    if (lotID > 0)
                    { 
                        diffQty = Math.Abs(oldStockQty - newStockQty);
                        if (oldStockQty > newStockQty)
                            sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + diffQty + " WHERE ID = " + selectedProductID;
                        else
                            sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY + " + diffQty + " WHERE ID = " + selectedProductID;
                    }
                    else
                        sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY + " + newStockQty + " WHERE ID = " + selectedProductID;
                }
                else
                { 
                    // UPDATE MASTER PRODUCT WITH THE NEW QTY
                    sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = " + newStockQty + " WHERE ID = " + selectedProductID;
                }

                gUtil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "UPDATE STOCK QTY [" + selectedProductID + "]");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                if (globalFeatureList.EXPIRY_MODULE == 1)
                {
                    productExpiryDate = String.Format(culture, "{0:dd-MM-yyyy}", expDatePicker.Value);
                    // INSERT INTO PRODUCT ADJUSTMENT TABLE
                    sqlCommand = "INSERT INTO PRODUCT_ADJUSTMENT (PRODUCT_ID, PRODUCT_ADJUSTMENT_DATE, PRODUCT_OLD_STOCK_QTY, PRODUCT_NEW_STOCK_QTY, PRODUCT_ADJUSTMENT_DESCRIPTION, PRODUCT_EXPIRY_DATE) VALUES " +
                                        "('" + kodeProductTextBox.Text + "', STR_TO_DATE('" + adjustmentDate + "', '%d-%m-%Y'), " + jumlahAwalMaskedTextBox.Text + ", " + jumlahBaruMaskedTextBox.Text + ", '" + descriptionParam + "', STR_TO_DATE('" + productExpiryDate + "', '%d-%m-%Y'))";
                }
                else
                {
                    // INSERT INTO PRODUCT ADJUSTMENT TABLE
                    sqlCommand = "INSERT INTO PRODUCT_ADJUSTMENT (PRODUCT_ID, PRODUCT_ADJUSTMENT_DATE, PRODUCT_OLD_STOCK_QTY, PRODUCT_NEW_STOCK_QTY, PRODUCT_ADJUSTMENT_DESCRIPTION) VALUES " +
                                        "('" + kodeProductTextBox.Text + "', STR_TO_DATE('" + adjustmentDate + "', '%d-%m-%Y'), " + jumlahAwalMaskedTextBox.Text + ", " + jumlahBaruMaskedTextBox.Text + ", '" + descriptionParam + "')";
                }

                gUtil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "INSERT INTO PRODUCT ADJUSTMENT TABLE [" + kodeProductTextBox.Text + ", " + jumlahAwalMaskedTextBox.Text + ", " + jumlahBaruMaskedTextBox.Text + "]");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "EXCEPTION THROWN [" + e.Message + "]");
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                        gUtil.showDBOPError(ex, "ROLLBACK");
                }

                gUtil.showDBOPError(e, "INSERT");
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
            gUtil.saveSystemDebugLog(globalConstants.MENU_PENYESUAIAN_STOK, "TRY TO DO MANUAL STOCK ADJUSTMENT");
            if (saveData())
            {
                gUtil.saveUserChangeLog(globalConstants.MENU_PENYESUAIAN_STOK, globalConstants.CHANGE_LOG_UPDATE, "PENYESUAIAN STOK PRODUK [" + namaProductTextBox.Text + "] " + jumlahAwalMaskedTextBox.Text + "/" + jumlahBaruMaskedTextBox.Text);
                gUtil.showSuccess(gUtil.INS);
                saveButton.Enabled = false;
                errorLabel.Text = "";
            }
        }
        
        private void penyesuaianStokForm_Load(object sender, EventArgs e)
        {
            loadProductData();
            errorLabel.Text = "";
            gUtil.reArrangeTabOrder(this);

            if (globalFeatureList.EXPIRY_MODULE == 1)
            {
                expLabel.Visible = true;
                expDatePicker.Visible = true;

                expDatePicker.Format = DateTimePickerFormat.Custom;
                expDatePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            }
        }

        private void penyesuaianStokForm_Activated(object sender, EventArgs e)
        {
            //if need something
            registerGlobalHotkey();
        }

        private void jumlahBaruMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                jumlahBaruMaskedTextBox.SelectAll();
            });
        }

        private void penyesuaianStokForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
