﻿using System;
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
    public partial class stokPecahBarangForm : Form
    {
        private int newSelectedInternalProductID = 0;
        private int selectedInternalProductID = 0;
        private int selectedLotID = 0;
        private int selectedUnitID = 0;
        private DateTime originalExpiryDate;
        private List<int> selectedKategoriID = new List<int>();
        private double currentStockQty;
        private int currentUnitID;
        private int newUnitID;
        private double newUnitConverter;

        private Data_Access DS = new Data_Access();
        private string previousInput = "";
        private string previousInputActual = "";
        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private bool isLoading = false;

        dataProdukForm displayBrowseDataProdukForm = null;
        dataProdukDetailForm newProdukForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        public stokPecahBarangForm()
        {
            InitializeComponent();
        }

        public stokPecahBarangForm(int productID)
        {
            string selectedProductID;
            InitializeComponent();

            if (globalFeatureList.EXPIRY_MODULE == 1)
            {
                selectedLotID = productID;
                selectedProductID = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_ID, '') FROM PRODUCT_EXPIRY WHERE ID = " + selectedLotID).ToString();

                if (selectedProductID != "")
                {
                    selectedInternalProductID = Convert.ToInt32(DS.getDataSingleValue("SELECT ID FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + selectedProductID + "'"));
                }
                else
                    selectedInternalProductID = 0;
            }
            else
            {
                selectedInternalProductID = productID;
            }
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

        public void setNewSelectedProductID(int productID)
        {
            newSelectedInternalProductID = productID;

            loadProductName();
        }

        private void newProduk_Click(object sender, EventArgs e)
        {
            if (null == newProdukForm || newProdukForm.IsDisposed)
                    newProdukForm = new dataProdukDetailForm(globalConstants.STOK_PECAH_BARANG, this);

            newProdukForm.Show();
            newProdukForm.WindowState = FormWindowState.Normal;
            //loadProductName();
        }

        private void browseProdukButton_Click(object sender, EventArgs e)
        {
            if (null == displayBrowseDataProdukForm || displayBrowseDataProdukForm.IsDisposed)
                    displayBrowseDataProdukForm = new dataProdukForm(globalConstants.BROWSE_STOK_PECAH_BARANG, this);

            displayBrowseDataProdukForm.Show();
            displayBrowseDataProdukForm.WindowState = FormWindowState.Normal;

            numberOfProductTextBox.Text = "0";
        }

        private void loadProductName()
        {
            string productName = "";

            if ( (newSelectedInternalProductID == selectedInternalProductID) || newSelectedInternalProductID == 0 )
                return;

            DS.mySqlConnect();

            productName = DS.getDataSingleValue("SELECT PRODUCT_NAME FROM MASTER_PRODUCT WHERE ID = " + newSelectedInternalProductID).ToString();

            newProductIDTextBox.Text = productName;
        }

        private void loadNewUnitID()
        {
            if ((newSelectedInternalProductID == selectedInternalProductID) || newSelectedInternalProductID == 0)
                return;

            DS.mySqlConnect();

            newUnitID = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(UNIT_ID, 0) FROM MASTER_PRODUCT WHERE ID = " + newSelectedInternalProductID));
        }

        private void loadProductInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            DS.mySqlConnect();

            if (globalFeatureList.EXPIRY_MODULE == 1)
            {
                sqlCommand = "SELECT MP.UNIT_ID, MP.PRODUCT_ID, MP.PRODUCT_NAME, MP.PRODUCT_BASE_PRICE, MP.PRODUCT_RETAIL_PRICE, MP.PRODUCT_BULK_PRICE, MP.PRODUCT_WHOLESALE_PRICE, PE.PRODUCT_AMOUNT, PE.PRODUCT_EXPIRY_DATE " +
                                       "FROM MASTER_PRODUCT MP, PRODUCT_EXPIRY PE WHERE PE.PRODUCT_ID = MP.PRODUCT_ID AND PE.ID =  " + selectedLotID;
            }
            else
            {
                sqlCommand = "SELECT * FROM MASTER_PRODUCT WHERE ID =  " + selectedInternalProductID;
            }

            // LOAD PRODUCT DATA
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        productIDTextBox.Text = rdr.GetString("PRODUCT_ID");
                        productNameTextBox.Text = rdr.GetString("PRODUCT_NAME");
                        hppTextBox.Text = rdr.GetString("PRODUCT_BASE_PRICE");
                        hargaEcerTextBox.Text = rdr.GetString("PRODUCT_RETAIL_PRICE");
                        hargaPartaiTextBox.Text = rdr.GetString("PRODUCT_BULK_PRICE");
                        hargaGrosirTextBox.Text = rdr.GetString("PRODUCT_WHOLESALE_PRICE");

                        if (globalFeatureList.EXPIRY_MODULE == 1)
                        {
                            stockTextBox.Text = rdr.GetString("PRODUCT_AMOUNT");
                            currentStockQty = rdr.GetDouble("PRODUCT_AMOUNT");
                            expDatePicker.Value = rdr.GetDateTime("PRODUCT_EXPIRY_DATE");
                            originalExpiryDate = rdr.GetDateTime("PRODUCT_EXPIRY_DATE");
                        }
                        else
                        {
                            stockTextBox.Text = rdr.GetString("PRODUCT_STOCK_QTY");
                            currentStockQty = rdr.GetDouble("PRODUCT_STOCK_QTY");
                        }

                        selectedUnitID = rdr.GetInt32("UNIT_ID");
                    }
                }
            }

        }

        private void loadCategoryInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string kategoriInformation = "";

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT P.*, M.CATEGORY_NAME FROM PRODUCT_CATEGORY P, MASTER_CATEGORY M WHERE PRODUCT_ID =  '"+ productIDTextBox.Text +"' AND P.CATEGORY_ID = M.CATEGORY_ID" ))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        selectedKategoriID.Add(rdr.GetInt32("CATEGORY_ID"));

                        if (kategoriInformation.Equals(""))
                            kategoriInformation = rdr.GetString("CATEGORY_NAME");
                        else
                            kategoriInformation = kategoriInformation + ", "  + rdr.GetString("CATEGORY_NAME");
                    }
                }
            }

            productCategoryTextBox.Text = kategoriInformation;

        }

        private void loadUnitInformation()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_UNIT WHERE UNIT_ID =  " + selectedUnitID ))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        unitTextBox.Text = rdr.GetString("UNIT_NAME");
                        currentUnitID = rdr.GetInt32("UNIT_ID");
                    }
                }
            }
        }

        private void stokPecahBarangForm_Load(object sender, EventArgs e)
        {
            gUtil.reArrangeTabOrder(this);

            if (globalFeatureList.EXPIRY_MODULE == 1)
            {
                expLabel.Visible = true;
                expDatePicker.Visible = true;
            }
        }

        private double getNewUnitConverterValue()
        {
            double convertValue = 0;
            DS.mySqlConnect();

            if (currentUnitID != newUnitID)
                convertValue = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(CONVERT_MULTIPLIER , 0) FROM UNIT_CONVERT WHERE CONVERT_UNIT_ID_1 = " + currentUnitID + " AND CONVERT_UNIT_ID_2 = " + newUnitID));
            else
                convertValue = 1;

            return convertValue;
        }

        private void calculateResultForNewProduct()
        {
            double tempValue;
            double result;

            tempValue = Convert.ToDouble(numberOfProductTextBox.Text);

            if (tempValue <= currentStockQty)
            {
                errorLabel.Text = "";

                loadNewUnitID();
                newUnitConverter = getNewUnitConverterValue();

                result = Math.Round(tempValue * newUnitConverter,2);
                resultTextBox.Text = result.ToString();
                actualQtyTextBox.Text = result.ToString();
            }
            else
            {
                errorLabel.Text = "JUMLAH STOK TIDAK CUKUP";
            }
        }

        private bool isValidQtyInput(string textToCheck)
        {
            if (gUtil.matchRegEx(textToCheck, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL) && (!textToCheck.Equals("")) && (!textToCheck.Equals(".")))
                return true;

            return false;
        }

        private void numberOfProductTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString = "";

            if (isLoading)
                return;

            isLoading = true;
            if (numberOfProductTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                previousInput = "0";
                numberOfProductTextBox.Text = "0";

                numberOfProductTextBox.SelectionStart = numberOfProductTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (numberOfProductTextBox.Text.IndexOf('0') == 0 && numberOfProductTextBox.Text.Length > 1 && numberOfProductTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = numberOfProductTextBox.Text;
                numberOfProductTextBox.Text = tempString.Remove(0, 1);
            }
            
            if (isValidQtyInput(numberOfProductTextBox.Text))
            {
                previousInput = numberOfProductTextBox.Text;
                calculateResultForNewProduct();
            }
            else
            {
                numberOfProductTextBox.Text = previousInput;
            }

            numberOfProductTextBox.SelectionStart = numberOfProductTextBox.Text.Length;

            isLoading = false;
        }

        private bool dataValidated()
        {
            if (numberOfProductTextBox.Text.Length<=0)
            {
                errorLabel.Text = "JUMLAH BARANG YG MAU DIPECAH TIDAK BOLEH NOL";
                return false;
            }

            if (Convert.ToDouble(numberOfProductTextBox.Text) > currentStockQty)
            {
                errorLabel.Text = "JUMLAH STOK TIDAK CUKUP";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;
            
            double calculatedResult = 0;
            double actualResult = 0;
            double productLoss = 0;
            string selectedDate = DateTime.Now.ToString();
            string pl_Date = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(selectedDate));

            DS.beginTransaction();

            calculatedResult = Convert.ToDouble(resultTextBox.Text);
            actualResult = Convert.ToDouble(actualQtyTextBox.Text);

            productLoss = calculatedResult - actualResult;

            try
            {
                DS.mySqlConnect();

                //REDUCE CURRENT STOCK QTY
                sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + gUtil.validateDecimalNumericInput(Convert.ToDouble(numberOfProductTextBox.Text)) + " WHERE ID = " + selectedInternalProductID;
                gUtil.saveSystemDebugLog(globalConstants.MENU_PECAH_SATUAN_PRODUK, "REDUCE QTY [" + productIDTextBox.Text + "] AMT [" + gUtil.validateDecimalNumericInput(Convert.ToDouble(numberOfProductTextBox.Text)) + "]");

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                //INCREASE NEW STOCK QTY
                sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY + " + actualResult + " WHERE ID = " + newSelectedInternalProductID;
                gUtil.saveSystemDebugLog(globalConstants.MENU_PECAH_SATUAN_PRODUK, "ADD QTY [" + newProductIDTextBox.Text + "] AMT [" + actualResult + "]");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                if (globalFeatureList.EXPIRY_MODULE == 1)
                {
                    expiryModuleUtil expUtil = new expiryModuleUtil();
                    // REDUCE CURRENT STOCK QTY FOR THE EXACT EXPIRY DATE
                    sqlCommand = "UPDATE PRODUCT_EXPIRY SET PRODUCT_AMOUNT = PRODUCT_AMOUNT - " + gUtil.validateDecimalNumericInput(Convert.ToDouble(numberOfProductTextBox.Text)) + " WHERE ID = " + selectedLotID;
                    gUtil.saveSystemDebugLog(globalConstants.MENU_PECAH_SATUAN_PRODUK, "REDUCE QTY [" + productIDTextBox.Text + "] AMT [" + gUtil.validateDecimalNumericInput(Convert.ToDouble(numberOfProductTextBox.Text)) + "]");

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    // INCREASE NEW STOCK QTY FOR THE EXACT EXPIRY DATE
                    string productExpiryDate = String.Format(culture, "{0:dd-MM-yyyy}", expDatePicker.Value);
                    string productID = newProductIDTextBox.Text;
                    double adjustmentQty = actualResult;
                    int lotID = 0;

                    // CHECK WHETHER THE PRODUCT WITH SAME EXPIRY DATE EXIST
                    lotID = expUtil.getLotIDBasedOnExpiryDate(expDatePicker.Value, productID);

                    if (lotID == 0)
                    {
                        //sqlCommand = "INSERT INTO PRODUCT_EXPIRY (PRODUCT_ID, PRODUCT_EXPIRY_DATE, PRODUCT_AMOUNT, PR_INVOICE) VALUES ( '" + detailGridView.Rows[i].Cells["productID"].Value.ToString() + "', STR_TO_DATE('" + productExpiryDate + "', '%d-%m-%Y'), " + Convert.ToDouble(detailGridView.Rows[i].Cells["qtyReceived"].Value) + ", '" + PRInvoice + "')";
                        sqlCommand = "INSERT INTO PRODUCT_EXPIRY (PRODUCT_ID, PRODUCT_EXPIRY_DATE, PRODUCT_AMOUNT) VALUES ( '" + newProductIDTextBox.Text + "', STR_TO_DATE('" + productExpiryDate + "', '%d-%m-%Y'), " + adjustmentQty + ")";
                    }
                    else
                        sqlCommand = "UPDATE PRODUCT_EXPIRY SET PRODUCT_AMOUNT = PRODUCT_AMOUNT + " + adjustmentQty + " WHERE ID = " + lotID;

                    gUtil.saveSystemDebugLog(globalConstants.MENU_PECAH_SATUAN_PRODUK, "INSERT TO PRODUCT EXPIRY [" + productID + "]");
                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                if (actualResult < calculatedResult)
                {
                    // INSERT INTO PRODUCT LOSS TABLE
                    sqlCommand = "INSERT INTO PRODUCT_LOSS (PL_DATETIME, PRODUCT_ID, PRODUCT_QTY, NEW_PRODUCT_ID, NEW_PRODUCT_QTY, TOTAL_LOSS) " +
                                        "VALUES (STR_TO_DATE('" + pl_Date + "', '%d-%m-%Y'), " + selectedInternalProductID + ", " + Convert.ToDouble(numberOfProductTextBox.Text) + ", " + newSelectedInternalProductID + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(resultTextBox.Text)) + ", " + gUtil.validateDecimalNumericInput(productLoss) + ")";
                    gUtil.saveSystemDebugLog(globalConstants.MENU_PECAH_SATUAN_PRODUK, "ADD PRODUCT LOSS QTY [" + productIDTextBox.Text + "] AMT [" + gUtil.validateDecimalNumericInput(productLoss) + "]");

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_PECAH_SATUAN_PRODUK, "EXCEPTION THROWN [" + e.Message + "]");
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
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
            if (saveData())
            {
                gUtil.saveUserChangeLog(globalConstants.MENU_PECAH_SATUAN_PRODUK, globalConstants.CHANGE_LOG_UPDATE, "PECAH SATUAN PRODUK [" + productIDTextBox.Text + "/" + numberOfProductTextBox.Text + "] -> [" + newProductIDTextBox.Text + "/" + actualQtyTextBox.Text + "]");

                //MessageBox.Show("SUCCESS");
                gUtil.showSuccess(gUtil.UPD);
                stockTextBox.Text = currentStockQty.ToString();

            }
        }

        private void actualQtyTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString = "";

            if (isLoading)
                return;

            isLoading = true;
            if (actualQtyTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                previousInputActual = "0";
                actualQtyTextBox.Text = "0";

                actualQtyTextBox.SelectionStart = actualQtyTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (actualQtyTextBox.Text.IndexOf('0') == 0 && actualQtyTextBox.Text.Length > 1 && actualQtyTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = actualQtyTextBox.Text;
                actualQtyTextBox.Text = tempString.Remove(0, 1);
            }

            if ( (isValidQtyInput(actualQtyTextBox.Text)) 
                && (Convert.ToDouble(actualQtyTextBox.Text) <= Convert.ToDouble(resultTextBox.Text))
               )
            {
                previousInputActual = actualQtyTextBox.Text;
            }
            else
            {
                actualQtyTextBox.Text = previousInputActual;
            }

            actualQtyTextBox.SelectionStart = actualQtyTextBox.Text.Length;
            isLoading = false;
        }

        private void stokPecahBarangForm_Activated(object sender, EventArgs e)
        {

            errorLabel.Text = "";

            loadProductInformation();

            loadUnitInformation();

            loadCategoryInformation();

            registerGlobalHotkey();
        }

        private void stokPecahBarangForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }
        
    }
}