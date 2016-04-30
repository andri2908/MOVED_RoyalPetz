using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotkeys;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Drawing.Printing;

namespace RoyalPetz_ADMIN
{
    public partial class cashierForm : Form
    {
        private string selectedsalesinvoice = "";
        public static int objCounter = 1;
        private DateTime localDate = DateTime.Now;
        private double globalTotalValue = 0;
        private double discValue = 0;
        private int selectedPelangganID = 0;
        private int selectedPaymentMethod = 0;
        private bool isLoading = false;
        private double bayarAmount = 0;
        private double sisaBayar = 0;

        private Data_Access DS = new Data_Access();

        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private List<string> salesQty = new List<string>();
        private List<string> disc1 = new List<string>();
        private List<string> disc2 = new List<string>();
        private List<string> discRP = new List<string>();
        
        private Hotkeys.GlobalHotkey ghk_F1;
        private Hotkeys.GlobalHotkey ghk_F2;
        private Hotkeys.GlobalHotkey ghk_F3;
        private Hotkeys.GlobalHotkey ghk_F4;
        private Hotkeys.GlobalHotkey ghk_F5;
        private Hotkeys.GlobalHotkey ghk_F7;
        private Hotkeys.GlobalHotkey ghk_F8;
        private Hotkeys.GlobalHotkey ghk_F9;
        private Hotkeys.GlobalHotkey ghk_F10;
        private Hotkeys.GlobalHotkey ghk_F11;
        private Hotkeys.GlobalHotkey ghk_F12;
        
        private Hotkeys.GlobalHotkey ghk_CTRL_DEL;
        private Hotkeys.GlobalHotkey ghk_CTRL_C;
        private Hotkeys.GlobalHotkey ghk_CTRL_U;

        private Hotkeys.GlobalHotkey ghk_ALT_F4;

        private adminForm parentForm;

        public cashierForm()
        {
            InitializeComponent();
        }

        public cashierForm(int counter)
        {
            InitializeComponent();
            label1.Text = "Struk # : " + counter;

            objCounter = counter + 1;
        }

        public void setCustomerID(int ID)
        {
            selectedPelangganID = ID;
            setCustomerProfile();

            refreshProductPrice();
        }
        
        private void updateLabel()
        {
            localDate = DateTime.Now;
            dateTimeStampLabel.Text = String.Format(culture, "{0:dddd, dd-MM-yyyy - HH:mm}", localDate);
        }

        private void updateRowNumber()
        {
            for (int i = 0;i<cashierDataGridView.Rows.Count;i++)
                cashierDataGridView.Rows[i].Cells["F8"].Value = i + 1;
        }

        private void addNewRow()
        {
            int prevValue = 0;
            bool allowToAdd = true;
                
            if (cashierDataGridView.Rows.Count > 0 )
            {
                prevValue = Convert.ToInt32(cashierDataGridView.Rows[cashierDataGridView.Rows.Count-1].Cells["F8"].Value);

                if (null == cashierDataGridView.Rows[cashierDataGridView.Rows.Count - 1].Cells["productID"].Value)
                    allowToAdd = false;
            }

            if (allowToAdd)
            {
                cashierDataGridView.Rows.Add();

                salesQty.Add("0");
                disc1.Add("0");
                disc2.Add("0");
                discRP.Add("0");

                cashierDataGridView.Rows[cashierDataGridView.Rows.Count - 1].Cells["F8"].Value = prevValue + 1;
            }

            cashierDataGridView.Focus();

        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.F3:
                    cashierForm displayForm = new cashierForm(objCounter);
                    displayForm.Show();
                    break;
            
                case Keys.F4:
                    //MessageBox.Show("F4");
                    dataPelangganForm pelangganForm = new dataPelangganForm(globalConstants.CASHIER_MODULE, this);
                    pelangganForm.ShowDialog(this);
                    break;
            
                case Keys.F8:
                    addNewRow();
                    break;

                case Keys.F9:
                    saveAndPrintOutInvoice();
                    break;

                
                
                case Keys.F1:
                    MessageBox.Show("F1");
                    break;
                case Keys.F2:
                    MessageBox.Show("F2");
                    break;
                case Keys.F5:
                    MessageBox.Show("F5");
                    break;
                case Keys.F7:
                    MessageBox.Show("F7");
                    break;
                case Keys.F10:
                    MessageBox.Show("F10");
                    break;
                case Keys.F11:
                    MessageBox.Show("F11");
                    break;
                case Keys.F12:
                    MessageBox.Show("F12");
                    break;
            }
        }

        private void captureAltModifier(Keys key)
        {
            switch (key)
            {
                case Keys.F4: // ALT + F4
                    MessageBox.Show("ALT+F4");
                    this.Close();
                    break;
            }
        }

        private void captureCtrlModifier(Keys key)
        {
            switch (key)
            {
                case Keys.Delete: // CTRL + DELETE
                    MessageBox.Show("CTRL+DELETE");
                    break;
                case Keys.C: // CTRL + C
                    MessageBox.Show("CTRL+C");
                    break;
                case Keys.U: // CTRL + U
                    MessageBox.Show("CTRL+U");
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
           if (m.Msg == Constants.WM_HOTKEY_MSG_ID) {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;

               if (modifier == Constants.NOMOD)
                    captureAll(key);
                else if (modifier == Constants.ALT)
                   captureAltModifier(key);
                else if (modifier == Constants.CTRL)
                   captureCtrlModifier(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_F3 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F3, this);
            ghk_F3.Register();

            ghk_F4 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F4, this);
            ghk_F4.Register();
            
            ghk_F8 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F8, this);
            ghk_F8.Register();

            ghk_F9 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F9, this);
            ghk_F9.Register();
            
            
            //ghk_F1 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F1, this);
            //ghk_F1.Register();
            
            //ghk_F2 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F2, this);
            //ghk_F2.Register();
            
            //ghk_F5 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F5, this);
            //ghk_F5.Register();

            //ghk_F7 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F7, this);
            //ghk_F7.Register();
            
            
            //ghk_F10 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F10, this);
            //ghk_F10.Register();

            //ghk_F11 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F11, this);
            //ghk_F11.Register();

            //// ## F12 doesn't work yet ##
            ////ghk_F12 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F12, this);
            ////ghk_F12.Register();

            //ghk_CTRL_DEL = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.Delete, this);
            //ghk_CTRL_DEL.Register();

            //ghk_CTRL_C = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.C, this);
            //ghk_CTRL_C.Register();

            //ghk_CTRL_U = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.U, this);
            //ghk_CTRL_U.Register();

            //ghk_ALT_F4 = new Hotkeys.GlobalHotkey(Constants.ALT, Keys.F4, this);
            //ghk_ALT_F4.Register();

        }

        private void unregisterGlobalHotkey()
        {
            ghk_F3.Unregister();
            ghk_F4.Unregister();
            ghk_F8.Unregister();
            ghk_F9.Unregister();

            //ghk_F1.Unregister();
            //ghk_F2.Unregister();
            //ghk_F5.Unregister();
            //ghk_F7.Unregister();
            
            //ghk_F10.Unregister();
            //ghk_F11.Unregister();
            ////ghk_F12.Unregister();

            //ghk_CTRL_DEL.Unregister();
            //ghk_CTRL_C.Unregister();
            //ghk_CTRL_U.Unregister();

            //ghk_ALT_F4.Unregister();
        }

        private void fillInDummyData()
        {
            for (int i = 1; i <= 150;i++ )
                cashierDataGridView.Rows.Add(i, "", "", "","", "", "");
        }

        private void setCustomerProfile()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            //DS.mySqlConnect();
            sqlCommand = "SELECT * FROM MASTER_CUSTOMER WHERE CUSTOMER_ID = " + selectedPelangganID;
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();

                    pelangganTextBox.Text = rdr.GetString("CUSTOMER_FULL_NAME");
                    isLoading = true;
                    customerComboBox.SelectedIndex = rdr.GetInt32("CUSTOMER_GROUP") - 1;
                    customerComboBox.Text = customerComboBox.Items[customerComboBox.SelectedIndex].ToString();
                    isLoading = false;
                }
            }
            rdr.Close();
        }

        private void refreshProductPrice()
        {
            double productPrice = 0;
            string productID = "";
            MySqlDataReader rdr;

            for (int i =0;i<cashierDataGridView.Rows.Count;i++)
            {              
                if (null != cashierDataGridView.Rows[i].Cells["productID"].Value)
                {
                    productID = cashierDataGridView.Rows[i].Cells["productID"].Value.ToString();
                    productPrice = getProductPriceValue(productID, customerComboBox.SelectedIndex);

                    cashierDataGridView.Rows[i].Cells["productPrice"].Value = productPrice;

                    if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM CUSTOMER_PRODUCT_DISC WHERE CUSTOMER_ID = " + selectedPelangganID + " AND PRODUCT_ID = '" + productID + "'")) > 0)
                    {
                        // DATA EXIST, LOAD DISC VALUE
                        using (rdr = DS.getData("SELECT * FROM CUSTOMER_PRODUCT_DISC WHERE CUSTOMER_ID = " + selectedPelangganID + " AND PRODUCT_ID = '" + productID + "'"))
                        {
                            if (rdr.HasRows)
                            {
                                rdr.Read();

                                cashierDataGridView.Rows[i].Cells["disc1"].Value = rdr.GetString("DISC_1");
                                disc1[i] = rdr.GetString("DISC_1");

                                cashierDataGridView.Rows[i].Cells["disc2"].Value = rdr.GetString("DISC_2");
                                disc2[i] = rdr.GetString("DISC_2");

                                cashierDataGridView.Rows[i].Cells["discRP"].Value = rdr.GetString("DISC_RP");
                                discRP[i] = rdr.GetString("DISC_RP");
                            }
                            
                            rdr.Close();
                        }
                    }
                    else
                    {
                        cashierDataGridView.Rows[i].Cells["disc1"].Value = 0;
                        disc1[i] = "0";

                        cashierDataGridView.Rows[i].Cells["disc2"].Value = 0;
                        disc2[i] = "0";

                        cashierDataGridView.Rows[i].Cells["discRP"].Value = 0;
                        discRP[i] = "0";
                    }

                    cashierDataGridView.Rows[i].Cells["jumlah"].Value = calculateSubTotal(i, productPrice);
                }
            }

            calculateTotal();
        }
        
        private bool dataValidated()
        {
            if (globalTotalValue <= 0)
            {
                errorLabel.Text = "NILAI TRANSAKSI 0";
                return false;
            }

            if (cashierDataGridView.Rows.Count <= 0)
            {
                errorLabel.Text = "TIDAK ADA BARANG";
                return false;
            }

            for (int i = 0; i < cashierDataGridView.Rows.Count; i++ )
            {
                if (
                    ((null == cashierDataGridView.Rows[i].Cells["qty"].Value) || 
                    (0 == Convert.ToDouble(cashierDataGridView.Rows[i].Cells["qty"].Value))
                    ) && null != cashierDataGridView.Rows[i].Cells["productID"].Value)
                {
                    errorLabel.Text = "JUMLAH PRODUK DI BARIS " + (i + 1) + " = 0";
                    return false;
                }

                if (
                    ((null == cashierDataGridView.Rows[i].Cells["jumlah"].Value) ||
                    (0 >= Convert.ToDouble(cashierDataGridView.Rows[i].Cells["jumlah"].Value))
                    ) && null != cashierDataGridView.Rows[i].Cells["productID"].Value)
                {
                    errorLabel.Text = "PEMBELIAN DI BARIS " + (i+1) + " TIDAK VALID";
                    return false;
                }
            }

            if (selectedPelangganID == 0)
                if (DialogResult.No == MessageBox.Show("PELANGGAN KOSONG, LANJUTKAN ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    return false;

            if (cashRadioButton.Checked)
            {
                double paymentAmount = 0;
                // CHECK PAYMENT AMOUNT FOR CASH PAYMENT
                if (bayarTextBox.Text.Length <= 0)
                {
                    errorLabel.Text = "JUMLAH PEMBAYARAN 0";
                    return false;
                }

                // CHECK PAYMENT AMOUNT MUST BE MORE OR EQUALS THAN THE BILL
                paymentAmount = Convert.ToDouble(bayarTextBox.Text);
                if (paymentAmount < globalTotalValue)
                {
                    errorLabel.Text = "JUMLAH PEMBAYARAN LEBIH KECIL DARI NOTA";
                    return false;
                }
            }
            else
            {
                // CHECK TEMPO
                if (tempoMaskedTextBox.Text.Length <= 0)
                {
                    errorLabel.Text = "LAMA TEMPO TIDAK BOLEH NOL";
                    return false;
                }
            }

            errorLabel.Text = "";
            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string salesInvoice = "0";
            
            string SODateTime = "";
            DateTime SODueDateTimeValue;
            string SODueDateTime = "";
            string salesDiscountFinal = "0";
            int salesTop = 1;
            int salesPaid = 0;
            MySqlException internalEX = null;

            double disc1 = 0;
            double disc2 = 0;
            double discRP = 0;
            string productID = "";
            int paymentMethod = 0;
            int creditID = 0;

            SODateTime = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            if (discJualMaskedTextBox.Text.Length > 0)
                salesDiscountFinal = discJualMaskedTextBox.Text;

            if (cashRadioButton.Checked)
            {
                salesTop = 1;
                salesPaid = 1;
                SODueDateTime = SODateTime;
                paymentMethod = paymentComboBox.SelectedIndex + 1;
            }
            else
            { 
                salesTop = 0;
                salesPaid = 0;
                SODueDateTimeValue = DateTime.Now;
                SODueDateTimeValue.AddDays(Convert.ToInt32(tempoMaskedTextBox.Text));
                SODueDateTimeValue = SODueDateTimeValue.AddDays(Convert.ToInt32(tempoMaskedTextBox.Text));
                SODueDateTime = String.Format(culture, "{0:dd-MM-yyyy}", SODueDateTimeValue);
            }

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                salesInvoice = getSalesInvoiceID();
                //pass thru to receipt generator
                selectedsalesinvoice = salesInvoice;
                // SAVE HEADER TABLE
                sqlCommand = "INSERT INTO SALES_HEADER (SALES_INVOICE, CUSTOMER_ID, SALES_DATE, SALES_TOTAL, SALES_DISCOUNT_FINAL, SALES_TOP, SALES_TOP_DATE, SALES_PAID, SALES_PAYMENT, SALES_PAYMENT_CHANGE) " +
                                    "VALUES " +
                                    "('" + salesInvoice + "', " + selectedPelangganID + ", STR_TO_DATE('" + SODateTime + "', '%d-%m-%Y'), " + gutil.validateDecimalNumericInput(globalTotalValue) + ", " + gutil.validateDecimalNumericInput(Convert.ToDouble(salesDiscountFinal)) + ", " + salesTop + ", STR_TO_DATE('" + SODueDateTime + "', '%d-%m-%Y'), " + salesPaid + ", " + gutil.validateDecimalNumericInput(bayarAmount) + ", " + gutil.validateDecimalNumericInput(sisaBayar) + ")";
                
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                // SAVE DETAIL TABLE
                for (int i = 0; i < cashierDataGridView.Rows.Count; i++)
                {
                    if (null != cashierDataGridView.Rows[i].Cells["productID"].Value)
                    {
                        disc1 = Convert.ToDouble(cashierDataGridView.Rows[i].Cells["disc1"].Value);
                        disc2 = Convert.ToDouble(cashierDataGridView.Rows[i].Cells["disc2"].Value);
                        discRP = Convert.ToDouble(cashierDataGridView.Rows[i].Cells["discRP"].Value);
                        productID = cashierDataGridView.Rows[i].Cells["productID"].Value.ToString();

                        sqlCommand = "INSERT INTO SALES_DETAIL (SALES_INVOICE, PRODUCT_ID, PRODUCT_SALES_PRICE, PRODUCT_QTY, PRODUCT_DISC1, PRODUCT_DISC2, PRODUCT_DISC_RP, SALES_SUBTOTAL) " +
                                            "VALUES " +
                                            "('" + salesInvoice + "', '" + productID + "', " + Convert.ToDouble(cashierDataGridView.Rows[i].Cells["productPrice"].Value) + ", " +
                                            gutil.validateDecimalNumericInput(Convert.ToDouble(cashierDataGridView.Rows[i].Cells["qty"].Value)) + ", " + gutil.validateDecimalNumericInput(disc1) + ", " + gutil.validateDecimalNumericInput(disc2) + ", " + gutil.validateDecimalNumericInput(discRP) + ", " + gutil.validateDecimalNumericInput(Convert.ToDouble(cashierDataGridView.Rows[i].Cells["jumlah"].Value)) + ")";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // REDUCE STOCK QTY AT MASTER PRODUCT
                        sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + Convert.ToDouble(cashierDataGridView.Rows[i].Cells["qty"].Value) +
                                            " WHERE PRODUCT_ID = '" + cashierDataGridView.Rows[i].Cells["productID"].Value.ToString() + "'";

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // SAVE OR UPDATE TO CUSTOMER_PRODUCT_DISC
                        if (selectedPelangganID != 0)
                        {
                            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM CUSTOMER_PRODUCT_DISC WHERE CUSTOMER_ID = " + selectedPelangganID + " AND PRODUCT_ID = '" + cashierDataGridView.Rows[i].Cells["productID"].Value.ToString() + "'"))>0)
                            {
                                // UPDATE VALUE
                                sqlCommand = "UPDATE CUSTOMER_PRODUCT_DISC SET DISC_1 = " + gutil.validateDecimalNumericInput(disc1) + ", DISC_2 = " + gutil.validateDecimalNumericInput(disc2) + ", DISC_RP = " + gutil.validateDecimalNumericInput(discRP) + " WHERE CUSTOMER_ID = " + selectedPelangganID + " AND PRODUCT_ID = '" + productID + "'";
                            }
                            else
                            {
                                // INSERT VALUE
                                sqlCommand = "INSERT INTO CUSTOMER_PRODUCT_DISC (CUSTOMER_ID, PRODUCT_ID, DISC_1, DISC_2 , DISC_RP) VALUES " +
                                                    "(" + selectedPelangganID + ", '" + productID + "', " + gutil.validateDecimalNumericInput(disc1) + ", " + gutil.validateDecimalNumericInput(disc2) + ", " + gutil.validateDecimalNumericInput(discRP) + ")";
                            }

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                        }

                    }
                }

                // SAVE TO CREDIT TABLE
                sqlCommand = "INSERT INTO CREDIT (SALES_INVOICE, CREDIT_DUE_DATE, CREDIT_NOMINAL, CREDIT_PAID) VALUES " +
                                    "('" + salesInvoice + "', STR_TO_DATE('" + SODueDateTime + "', '%d-%m-%Y'), " + gutil.validateDecimalNumericInput(globalTotalValue) + ", " + salesPaid + ")";

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;


                if (selectedPaymentMethod == 0)
                {
                    // PAYMENT IN CASH THEREFORE ADDING THE AMOUNT OF CASH IN THE CASH REGISTER
                    // ADD A NEW ENTRY ON THE DAILY JOURNAL TO KEEP TRACK THE ADDITIONAL CASH AMOUNT 
                    sqlCommand = "INSERT INTO DAILY_JOURNAL (ACCOUNT_ID, JOURNAL_DATETIME, JOURNAL_NOMINAL, JOURNAL_DESCRIPTION, USER_ID, PM_ID) " +
                                                   "VALUES (1, STR_TO_DATE('" + SODateTime + "', '%d-%m-%Y')" + ", " + gutil.validateDecimalNumericInput(globalTotalValue) + ", 'PEMBAYARAN " + salesInvoice + "', '" + gutil.getUserID() + "', 1)";

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;
                }


                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                try
                {
                    DS.rollBack(ref internalEX);
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
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }

        private void saveAndPrintOutInvoice()
        {
            if (DialogResult.Yes == MessageBox.Show("SAVE AND PRINT OUT ?", "WARNING", MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
            {
                totalPenjualanTextBox.Focus();
                if (saveData())
                {
                    PrintReceipt();
                    gutil.showSuccess(gutil.INS);

                    isLoading = true;
                    
                    //while (cashierDataGridView.Rows.Count > 0 )
                    //    cashierDataGridView.Rows.Remove(cashierDataGridView.Rows[0]);
                    cashierDataGridView.Rows.Clear();
                    isLoading = false;

                    salesQty.Clear();
                    disc1.Clear();
                    disc2.Clear();
                    discRP.Clear();
                    selectedPelangganID = 0;
                    globalTotalValue = 0;
                    discValue = 0;
                    totalLabel.Text = "Rp. 0";
                    gutil.ResetAllControls(this);
                }
            }
        }

        private string getNoFaktur()
        {
            string rsult = "";

            rsult = DS.getDataSingleValue("SELECT IFNULL(NO_FAKTUR, '') FROM SYS_CONFIG WHERE ID = 1").ToString();

            return rsult;
        }

        private string getSalesInvoiceID()
        {
            string salesInvoice = "";
            DateTime localDate = DateTime.Now;
            string maxSalesInvoice = "";
            double maxSalesInvoiceValue = 0;
            string salesInvPrefix;
            string sqlCommand = "";

            salesInvPrefix = getNoFaktur() + "-";//String.Format(culture, "{0:yyyyMMdd}", localDate);

            sqlCommand = "SELECT IFNULL(MAX(CONVERT(SUBSTRING(SALES_INVOICE, INSTR(SALES_INVOICE,'-')+1), UNSIGNED INTEGER)),'0') AS SALES_INVOICE FROM SALES_HEADER WHERE SALES_INVOICE LIKE '" + salesInvPrefix + "%'";

            maxSalesInvoice = DS.getDataSingleValue(sqlCommand).ToString();
            //if (maxSalesInvoice.Length > salesInvPrefix.Length)
            //{
            //    maxSalesInvoice = maxSalesInvoice.Substring(salesInvPrefix.Length);
            //    maxSalesInvoiceValue = Convert.ToInt32(maxSalesInvoice);
            //}
            //else
            //{
            //    maxSalesInvoiceValue = 0;
            //}

            maxSalesInvoiceValue = Convert.ToInt32(maxSalesInvoice);
            if (maxSalesInvoiceValue > 0)
            {
                maxSalesInvoiceValue += 1;
                maxSalesInvoice = maxSalesInvoiceValue.ToString();
            }
            else
            {
                maxSalesInvoice = "1";
            }

            //while (maxSalesInvoice.Length < 10)
            //    maxSalesInvoice = "0" + maxSalesInvoice;

            salesInvoice = salesInvPrefix + maxSalesInvoice;

            return salesInvoice;
        }

        private double getProductPriceValue(string productID, int customerType = 0)
        {
            double result = 0;
            string priceType = "";

            //DS.mySqlConnect();

            if (customerType == 0)
                priceType = "PRODUCT_RETAIL_PRICE";
            else if (customerType == 1)
                priceType = "PRODUCT_BULK_PRICE";
            else
                priceType = "PRODUCT_WHOLESALE_PRICE";

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(" + priceType + ", 0) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }
        
        private void cashierDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((cashierDataGridView.CurrentCell.OwningColumn.Name == "productID" || cashierDataGridView.CurrentCell.OwningColumn.Name == "productName") 
                && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if (
                (cashierDataGridView.CurrentCell.OwningColumn.Name == "qty" || cashierDataGridView.CurrentCell.OwningColumn.Name == "disc1" || cashierDataGridView.CurrentCell.OwningColumn.Name == "disc2" || cashierDataGridView.CurrentCell.OwningColumn.Name == "discRP")
                && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private double calculateSubTotal(int rowSelectedIndex, double productPrice)
        {
            double subTotal = 0;
            double productQty = 0;
            double hppValue = 0;
            double disc1Value = 0;
            double disc2Value = 0;
            double discRPValue = 0;

            try
            {
                productQty = Convert.ToDouble(salesQty[rowSelectedIndex]);

                if (productQty > 0)
                { 
                    hppValue = productPrice;

                    disc1Value = Convert.ToDouble(disc1[rowSelectedIndex]);
                    disc2Value = Convert.ToDouble(disc2[rowSelectedIndex]);
                    discRPValue = Convert.ToDouble(discRP[rowSelectedIndex]);

                    subTotal = Math.Round((hppValue * productQty), 2);

                    if (disc1Value > 0)
                        subTotal = Math.Round(subTotal - (subTotal * disc1Value / 100), 2);

                    if (disc2Value > 0)
                        subTotal = Math.Round(subTotal - (subTotal * disc2Value / 100), 2);

                    if (discRPValue > 0)
                        subTotal = Math.Round(subTotal - discRPValue, 2);
                }

            }
            catch (Exception ex)
            {
                subTotal = 0;
            }

            return subTotal;
        }

        private bool stockIsEnough(string productID, double qtyRequested)
        {
            bool result = false;

            if (productID.Length <= 0)
                result = true; // NO PRODUCT SELECTED YET
            else
            {
                double stockQty = 0;

                stockQty = Convert.ToDouble(DS.getDataSingleValue("SELECT (PRODUCT_STOCK_QTY - PRODUCT_LIMIT_STOCK) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

                if (stockQty >= qtyRequested)
                    result = true;
            }

            return result;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            int rowSelectedIndex = 0;
            string selectedProductID = "";
            double hpp = 0;
            double subTotal = 0;
            MySqlDataReader rdr;

            if (isLoading)  
                return;

            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;
            selectedIndex = dataGridViewComboBoxEditingControl.SelectedIndex;
            rowSelectedIndex = cashierDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = cashierDataGridView.Rows[rowSelectedIndex];

            DataGridViewComboBoxCell productIDComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productID"];
            DataGridViewComboBoxCell productNameComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productName"];

            selectedProductID = productIDComboCell.Items[selectedIndex].ToString();
            productIDComboCell.Value = productIDComboCell.Items[selectedIndex];
            productNameComboCell.Value = productNameComboCell.Items[selectedIndex];


            //selectedProductID = productComboHidden.Items[selectedIndex].ToString();//getProductID(selectedIndex);

            //if(cashierDataGridView.CurrentCell.OwningColumn.Name == "productID")
            //{
            //    selectedRow.Cells["productName"].Value = productNameHidden.Items[selectedIndex].ToString();
            //}
            //else
            //{
            //    selectedRow.Cells["productID"].Value = productComboHidden.Items[selectedIndex].ToString();
            //}

            hpp = getProductPriceValue(selectedProductID, customerComboBox.SelectedIndex);
            

            selectedRow.Cells["productPrice"].Value = hpp;

            if (null == selectedRow.Cells["qty"].Value)
                selectedRow.Cells["qty"].Value = 0;

            selectedRow.Cells["productId"].Value = selectedProductID;

            if (selectedPelangganID != 0)
            {
                if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM CUSTOMER_PRODUCT_DISC WHERE CUSTOMER_ID = " + selectedPelangganID + " AND PRODUCT_ID = '" + selectedProductID + "'")) > 0)
                {
                    // DATA EXIST, LOAD DISC VALUE
                    using (rdr = DS.getData("SELECT * FROM CUSTOMER_PRODUCT_DISC WHERE CUSTOMER_ID = " + selectedPelangganID + " AND PRODUCT_ID = '" + selectedProductID + "'"))
                    {
                        if (rdr.HasRows)
                        {
                            rdr.Read();

                            selectedRow.Cells["disc1"].Value = rdr.GetString("DISC_1");
                            disc1[rowSelectedIndex] = rdr.GetString("DISC_1");

                            selectedRow.Cells["disc2"].Value = rdr.GetString("DISC_2");
                            disc2[rowSelectedIndex] = rdr.GetString("DISC_2");

                            selectedRow.Cells["discRP"].Value = rdr.GetString("DISC_RP");
                            discRP[rowSelectedIndex] = rdr.GetString("DISC_RP");
                        }
                  
                        rdr.Close();
                    }
                }
                else
                {
                    selectedRow.Cells["disc1"].Value = 0;
                    disc1[rowSelectedIndex] = "0";

                    selectedRow.Cells["disc2"].Value = 0;
                    disc2[rowSelectedIndex] = "0";

                    selectedRow.Cells["discRP"].Value = 0;
                    discRP[rowSelectedIndex] = "0";
                }
            }

            subTotal = calculateSubTotal(rowSelectedIndex, hpp);

            calculateTotal();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double subTotal = 0;
            double productPrice = 0;
            string productID = "";
            string previousInput = "";
            string tempString = "";

            if (isLoading)
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = cashierDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = cashierDataGridView.Rows[rowSelectedIndex];

            //if (cashierDataGridView.CurrentCell.ColumnIndex != 3 && cashierDataGridView.CurrentCell.ColumnIndex != 4 && cashierDataGridView.CurrentCell.ColumnIndex != 5 && cashierDataGridView.CurrentCell.ColumnIndex != 6)
            if (cashierDataGridView.CurrentCell.OwningColumn.Name == "qty" && cashierDataGridView.CurrentCell.OwningColumn.Name == "disc1" && cashierDataGridView.CurrentCell.OwningColumn.Name == "disc2" && cashierDataGridView.CurrentCell.OwningColumn.Name == "discRP")
                return;

            if (dataGridViewTextBoxEditingControl.Text.Length <= 0)
            {
                // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING

                isLoading = true;
                // reset subTotal Value and recalculate total
                selectedRow.Cells["jumlah"].Value = 0;

                //if (detailRequestQtyApproved.Count >= rowSelectedIndex + 1)
                //    detailRequestQtyApproved[rowSelectedIndex] = "0";
                switch (cashierDataGridView.CurrentCell.OwningColumn.Name)
                {
                    case "qty":
                        salesQty[rowSelectedIndex] = "0";
                        break;
                    case "disc1":
                        disc1[rowSelectedIndex] = "0";
                        break;
                    case "disc2":
                        disc2[rowSelectedIndex] = "0";
                        break;
                    case "discRP":
                        discRP[rowSelectedIndex] = "0";
                        break;
                }

                dataGridViewTextBoxEditingControl.Text = "0";

                calculateTotal();

                dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;
                isLoading = false;
                return;
            }

            if (null != selectedRow.Cells["productID"].Value)
                productID = selectedRow.Cells["productID"].Value.ToString();

            switch (cashierDataGridView.CurrentCell.OwningColumn.Name)
            {
                case "qty":
                    previousInput = salesQty[rowSelectedIndex];
                    break;
                case "disc1":
                    previousInput = disc1[rowSelectedIndex];
                    break;
                case "disc2":
                    previousInput = disc2[rowSelectedIndex];
                    break;
                case "discRP":
                    previousInput = discRP[rowSelectedIndex];
                    break;
            }

            isLoading = true;
            if (previousInput == "0")
            {
                tempString = dataGridViewTextBoxEditingControl.Text;
                if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
                    dataGridViewTextBoxEditingControl.Text = tempString.Remove(tempString.IndexOf('0'), 1);
            }
            
                if (gutil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0 && dataGridViewTextBoxEditingControl.Text != ".")
                    )
                {
                    switch (cashierDataGridView.CurrentCell.OwningColumn.Name)
                    {
                        case "qty":                            
                            if (stockIsEnough(productID, Convert.ToDouble(dataGridViewTextBoxEditingControl.Text)))
                                salesQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                            else
                                dataGridViewTextBoxEditingControl.Text = salesQty[rowSelectedIndex];
                            break;
                        case "disc1":
                            disc1[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                            break;
                        case "disc2":
                            disc2[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                            break;
                        case "discRP":
                            discRP[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                            break;
                    }
            }
            else
            {
                dataGridViewTextBoxEditingControl.Text = previousInput;
            }

            productPrice = Convert.ToDouble(selectedRow.Cells["productPrice"].Value);

            subTotal = calculateSubTotal(rowSelectedIndex, productPrice);
            selectedRow.Cells["jumlah"].Value = subTotal;

            calculateTotal();
            dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;

            isLoading = false;
        }

        private void cashierForm_Shown(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void cashierForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void creditRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (creditRadioButton.Checked == true)
            {
                paymentComboBox.Visible = false;
                tempoMaskedTextBox.Visible = true;
                bayarTextBox.Enabled = false;  
                labelCaraBayar.Text = "Tempo            :";
            }
        }

        private void loadNoFaktur()
        {
            string noFakturValue;

            noFakturValue = DS.getDataSingleValue("SELECT NO_FAKTUR FROM SYS_CONFIG").ToString();

            noFakturLabel.Text = noFakturValue;
        }

        private void cashierForm_Load(object sender, EventArgs e)
        {
            loadNoFaktur();
            addColumnToDataGrid();

            customerComboBox.SelectedIndex = 0;
            customerComboBox.Text = customerComboBox.Items[0].ToString();

            cashierDataGridView.EditingControlShowing += cashierDataGridView_EditingControlShowing;

            gutil.reArrangeTabOrder(this);
            errorLabel.Text = "";
        }

        private void cashierForm_Activated(object sender, EventArgs e)
        {
            //if need something
            updateLabel();
            timer1.Start();
        }

        private void cashierForm_Deactivate(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabel();
        }

        private void addColumnToDataGrid()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DataGridViewTextBoxColumn F8Column = new DataGridViewTextBoxColumn();
            DataGridViewComboBoxColumn productIdColumn = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn productPriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn disc1Column = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn disc2Column = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn discRPColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            
            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY PRODUCT_NAME ASC";

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    productIdColumn.Items.Add(rdr.GetString("PRODUCT_ID"));
                }
            }

            rdr.Close();

            // F8 COLUMN
            F8Column.HeaderText = "F8";
            F8Column.Name = "F8";
            F8Column.Width = 44;
            F8Column.ReadOnly = true;
            cashierDataGridView.Columns.Add(F8Column);

            productIdColumn.HeaderText = "KODE PRODUK";
            productIdColumn.Name = "productID";
            productIdColumn.Width = 200;
            cashierDataGridView.Columns.Add(productIdColumn);

            // PRODUCT NAME COLUMN
            productNameCmb.HeaderText = "NAMA PRODUK";
            productNameCmb.Name = "productName";
            productNameCmb.Width = 320;
            cashierDataGridView.Columns.Add(productNameCmb);

            productPriceColumn.HeaderText = "HARGA";
            productPriceColumn.Name = "productPrice";
            productPriceColumn.Width = 200;
            productPriceColumn.ReadOnly = true;
            cashierDataGridView.Columns.Add(productPriceColumn);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            cashierDataGridView.Columns.Add(stockQtyColumn);

            disc1Column.HeaderText = "DISC 1 (%)";
            disc1Column.Name = "disc1";
            disc1Column.Width = 150;
            disc1Column.MaxInputLength = 5;
            cashierDataGridView.Columns.Add(disc1Column);

            disc2Column.HeaderText = "DISC 2 (%)";
            disc2Column.Name = "disc2";
            disc2Column.Width = 150;
            disc2Column.MaxInputLength = 5;
            cashierDataGridView.Columns.Add(disc2Column);

            discRPColumn.HeaderText = "DISC RP";
            discRPColumn.Name = "discRP";
            discRPColumn.Width = 150;
            cashierDataGridView.Columns.Add(discRPColumn);

            subTotalColumn.HeaderText = "JUMLAH";
            subTotalColumn.Name = "jumlah";
            subTotalColumn.Width = 200;
            subTotalColumn.ReadOnly = true;
            cashierDataGridView.Columns.Add(subTotalColumn);

        }

        private void deleteCurrentRow()
        {
            if (cashierDataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = cashierDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = cashierDataGridView.Rows[rowSelectedIndex];

                cashierDataGridView.Rows.Remove(selectedRow);
            }
        }

        private void cashierDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?", "WARNING", MessageBoxButtons.YesNo))
                {
                    deleteCurrentRow();
                    updateRowNumber();
                    calculateTotal();
                }
            }
        }

        private void calculateTotal()
        {
            double total = 0;
            double discJual = 0;
            double totalAfterDisc = 0;
            
            for (int i = 0; i < cashierDataGridView.Rows.Count; i++)
            {
                if ( null != cashierDataGridView.Rows[i].Cells["jumlah"].Value )
                    total = total + Convert.ToDouble(cashierDataGridView.Rows[i].Cells["jumlah"].Value);
            }

            globalTotalValue = total;
            totalAfterDisc = total;
            totalLabel.Text = total.ToString("c2", culture);

            totalPenjualanTextBox.Text = total.ToString("c2", culture);

            if (discJualMaskedTextBox.Text.Length > 0)
            {
                discJual = Convert.ToDouble(discJualMaskedTextBox.Text);
                totalAfterDisc = Math.Round(totalAfterDisc - discJual, 2);
            }

            totalAfterDiscTextBox.Text = totalAfterDisc.ToString("c2", culture);

            calculateChangeValue();
        }

        private void calculateChangeValue()
        {
            double totalAfterDisc = 0;
            if (bayarTextBox.Text.Length > 0)
            {
                bayarAmount = Convert.ToDouble(bayarTextBox.Text);
                totalAfterDisc = globalTotalValue - discValue;
                if (bayarAmount > totalAfterDisc)
                    sisaBayar = bayarAmount - totalAfterDisc;
                else
                    sisaBayar = 0;

                uangKembaliTextBox.Text = sisaBayar.ToString("C2", culture);
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void discJualMaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            double totalAfterDisc = 0;

            if (discJualMaskedTextBox.Text.Length > 0)
            {
                totalAfterDisc = globalTotalValue - Convert.ToDouble(discJualMaskedTextBox.Text);
                discValue = Convert.ToDouble(discJualMaskedTextBox.Text);
            }
            else
            { 
                totalAfterDisc = globalTotalValue;
                discValue = 0;
            }

            totalAfterDiscTextBox.Text = totalAfterDisc.ToString("C2", culture);
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            refreshProductPrice();
            
        }

        private void cashRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (cashRadioButton.Checked)
            {
                tempoMaskedTextBox.Visible = false;
                labelCaraBayar.Text = "Cara Bayar       :";
                paymentComboBox.Visible = true;
                paymentComboBox.SelectedIndex = 0;
                paymentComboBox.Text = paymentComboBox.Items[0].ToString();
                bayarTextBox.Enabled = true;
            }
        }

        private void bayarTextBox_TextChanged(object sender, EventArgs e)
        {
            calculateChangeValue();
        }

        private void paymentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPaymentMethod = paymentComboBox.SelectedIndex;
        }

        private void ChangePrinterButton_Click(object sender, EventArgs e)
        {
            SetPrinterForm displayedForm = new SetPrinterForm();
            displayedForm.ShowDialog(this);
        }

        private void loadInfoToko(int opt, out string namatoko, out string almt, out string telepon, out string email)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            namatoko = ""; almt = ""; telepon = ""; email = "";
            DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT IFNULL(BRANCH_ID,0) AS 'BRANCH_ID', IFNULL(HQ_IP4,'') AS 'IP', IFNULL(STORE_NAME,'') AS 'NAME', IFNULL(STORE_ADDRESS,'') AS 'ADDRESS', IFNULL(STORE_PHONE,'') AS 'PHONE', IFNULL(STORE_EMAIL,'') AS 'EMAIL' FROM SYS_CONFIG WHERE ID =  " + opt))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        if (!String.IsNullOrEmpty(rdr.GetString("NAME")))
                        {
                            namatoko = rdr.GetString("NAME");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("ADDRESS")))
                        {
                            almt = rdr.GetString("ADDRESS");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("PHONE")))
                        {
                            telepon = rdr.GetString("PHONE");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("EMAIL")))
                        {
                            email = rdr.GetString("EMAIL");
                        }
                    }
                }
            }
        }

        private void loadNamaUser(int user_id, out string nama)
        {
            nama = "";
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT USER_NAME AS 'NAME' FROM MASTER_USER WHERE ID="+user_id))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    nama = rdr.GetString("NAME");
                }
            }
        }

        private void PrintReceipt()
        {
            //pdoc = new PrintDocument();
            //pd.Document = pdoc;
            //pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            //    PrintPreviewDialog pp = new PrintPreviewDialog();
            //Font font = new Font("Courier New", 15);

            //cek paper mode
            int papermode = gutil.getPaper();
            int paperLength = 0;
            if (papermode == 0) //kertas POS
            {
                //width, height
                paperLength = calculatePageLength();
                PaperSize psize = new PaperSize("Custom", 320, paperLength);//820);
                printDocument1.DefaultPageSettings.PaperSize = psize;
                DialogResult result;
                printPreviewDialog1.Width = 512;
                printPreviewDialog1.Height = 768;
                result = printPreviewDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            } else
            {
                //kertas 1/2 kwarto atau kwarto using crystal report
                //preview laporan
                DS.mySqlConnect();
                string sqlCommandx = "SELECT SD.ID, SH.SALES_DATE AS 'DATE', SD.SALES_INVOICE AS 'INVOICE', MC.CUSTOMER_FULL_NAME AS 'CUSTOMER', M.PRODUCT_NAME AS 'PRODUCT', PRODUCT_QTY AS 'QTY', " +
                    "PRODUCT_SALES_PRICE AS 'PRICE', ROUND((PRODUCT_QTY * PRODUCT_SALES_PRICE) - SALES_SUBTOTAL, 2) AS 'POTONGAN', SALES_SUBTOTAL AS 'SUBTOTAL', SH.SALES_PAYMENT AS 'PAYMENT', SH.SALES_PAYMENT_CHANGE AS 'CHANGE' " +
                    "FROM SALES_HEADER SH, SALES_DETAIL SD, MASTER_PRODUCT M, MASTER_CUSTOMER MC WHERE SD.PRODUCT_ID = M.PRODUCT_ID AND SD.SALES_INVOICE = SH.SALES_INVOICE AND SH.CUSTOMER_ID = MC.CUSTOMER_ID AND SH.SALES_INVOICE='" + selectedsalesinvoice + "'" +
                    "UNION " +
                    "SELECT SD.ID, SH.SALES_DATE AS 'DATE', SD.SALES_INVOICE AS 'INVOICE', '' AS 'CUSTOMER', M.PRODUCT_NAME AS 'PRODUCT', PRODUCT_QTY AS 'QTY', PRODUCT_SALES_PRICE AS 'PRICE', " +
                    "ROUND((PRODUCT_QTY * PRODUCT_SALES_PRICE) - SALES_SUBTOTAL, 2) AS 'POTONGAN', SALES_SUBTOTAL AS 'SUBTOTAL', SH.SALES_PAYMENT AS 'PAYMENT', SH.SALES_PAYMENT_CHANGE AS 'CHANGE' " +
                    "FROM SALES_HEADER SH, SALES_DETAIL SD, MASTER_PRODUCT M WHERE SD.PRODUCT_ID = M.PRODUCT_ID AND SD.SALES_INVOICE = SH.SALES_INVOICE AND SH.CUSTOMER_ID = 0 AND SH.SALES_INVOICE='" + selectedsalesinvoice + "'";
                DS.writeXML(sqlCommandx, globalConstants.SalesReceiptXML);
                SalesReceiptForm displayedform = new SalesReceiptForm();
                displayedform.ShowDialog(this);
            }

           
        }
       
        private int calculatePageLength()
        {
            int startY = 10;
            int Offset = 15;
            int totalLengthPage = startY + Offset;
            string nm, almt, tlpn, email;

            loadInfoToko(2, out nm, out almt, out tlpn, out email);

            //set printing area
            Offset = Offset + 12;

            Offset = Offset + 10;

            if (!email.Equals(""))
                Offset = Offset + 10;

            Offset = Offset + 15;
            //end of header

            //start of content

            //1. PAYMENT METHOD
            Offset = Offset + 15;

            //2. CUSTOMER NAME
            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            //DETAIL PENJUALAN
            
            DS.mySqlConnect();
            MySqlDataReader rdr;
            using (rdr = DS.getData("SELECT S.ID, S.PRODUCT_ID AS 'P-ID', P.PRODUCT_NAME AS 'NAME', S.PRODUCT_QTY AS 'QTY',ROUND(S.SALES_SUBTOTAL/S.PRODUCT_QTY) AS 'PRICE' FROM sales_detail S, master_product P WHERE S.PRODUCT_ID=P.PRODUCT_ID AND S.SALES_INVOICE='" + selectedsalesinvoice + "'"))//+ "group by s.product_id") )
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                        Offset = Offset + 15;
                }
            }
            DS.mySqlClose();

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 25;
            //eNd of content

            //FOOTER

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;
            //end of footer

            totalLengthPage = totalLengthPage + Offset + 15;
            
            return totalLengthPage;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            String ucapan = "";
            string nm, almt, tlpn, email;

            //event printing

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int Offset = 15;
            //HEADER

            //set allignemnt
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //set printing area
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(startX, startY + Offset, 300, 20);

            loadInfoToko(2,out nm, out almt, out tlpn, out email);

            graphics.DrawString(nm, new Font("Courier New", 9),
                                new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            graphics.DrawString(almt,
                     new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 10;
            rect.Y = startY + Offset;
            graphics.DrawString(tlpn,
                     new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            if (!email.Equals(""))
            {
                Offset = Offset + 10;
                rect.Y = startY + Offset;
                graphics.DrawString(email,
                         new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            }

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            String underLine = "-----------------------------------";
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);
            //end of header

            //start of content
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();
            //load customer id
            string customer = "";
            string tgl="";
            string group = "";
            double total = 0;
            using (rdr = DS.getData("SELECT S.SALES_INVOICE AS 'INVOICE', C.CUSTOMER_FULL_NAME AS 'CUSTOMER',DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE',S.SALES_TOTAL AS 'TOTAL', IF(C.CUSTOMER_GROUP=1,'RETAIL',IF(C.CUSTOMER_GROUP=2,'GROSIR','PARTAI')) AS 'GROUP' FROM SALES_HEADER S,MASTER_CUSTOMER C WHERE S.CUSTOMER_ID = C.CUSTOMER_ID AND S.SALES_INVOICE = '" + selectedsalesinvoice + "'" +
                " UNION " +
                "SELECT S.SALES_INVOICE AS 'INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(S.SALES_DATE, '%d-%M-%Y') AS 'DATE', S.SALES_TOTAL AS 'TOTAL', 'RETAIL' AS 'GROUP' FROM SALES_HEADER S, MASTER_CUSTOMER C WHERE S.CUSTOMER_ID = 0 AND S.SALES_INVOICE = '" + selectedsalesinvoice + "'" +
                "ORDER BY DATE ASC"))
            {
                if (rdr.HasRows) 
                {
                    rdr.Read();
                    customer = rdr.GetString("CUSTOMER");
                    tgl = rdr.GetString("DATE");
                    total = rdr.GetDouble("TOTAL");
                    group = rdr.GetString("GROUP");
                }
            }
            DS.mySqlClose();

            //1. PAYMENT METHOD
            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            //SET TO LEFT MARGIN
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            if (creditRadioButton.Checked)
            {
                ucapan = "JUAL CREDIT KEPADA";
            } else
            {
                ucapan = "JUAL TUNAI KEPADA";
            }
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            //2. CUSTOMER NAME
            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "PELANGGAN : " + customer + " [" + group + "]";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = 300;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.Width = 300;
            ucapan = "BUKTI PEMBAYARAN";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            
            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "NO. NOTA : " + selectedsalesinvoice;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "TANGGAL  : "+ tgl;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            string nama = "";
            loadNamaUser(gutil.getUserID(), out nama);
            ucapan = "OPERATOR : " +  nama;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = 300;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            //DETAIL PENJUALAN
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            //read sales_detail

            DS.mySqlConnect();
            string product_id = "";
            string product_name = "";
            double total_qty = 0;
            double product_qty = 0;
            double product_price = 0;
            using (rdr = DS.getData("SELECT S.ID, S.PRODUCT_ID AS 'P-ID', P.PRODUCT_NAME AS 'NAME', S.PRODUCT_QTY AS 'QTY',ROUND(S.SALES_SUBTOTAL/S.PRODUCT_QTY) AS 'PRICE' FROM sales_detail S, master_product P WHERE S.PRODUCT_ID=P.PRODUCT_ID AND S.SALES_INVOICE='" + selectedsalesinvoice + "'"))//+ "group by s.product_id") )
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        product_id = rdr.GetString("P-ID");
                        product_name = rdr.GetString("NAME");
                        product_qty = rdr.GetDouble("QTY");
                        product_price = rdr.GetDouble("PRICE");
                        Offset = Offset + 15;
                        rect.Y = startY + Offset;
                        rect.X = startX + 15;
                        rect.Width = 280;
                        ucapan = product_id + " " + product_name + " X" + product_qty + " Rp." + product_price;
                        graphics.DrawString(ucapan, new Font("Courier New", 7),
                                 new SolidBrush(Color.Black), rect, sf);
                    }
                }
            }
            DS.mySqlClose();

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = 300;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 260;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "               JUMLAH  : Rp." + total;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 260;
            ucapan = "               TUNAI   : Rp." + bayarTextBox.Text;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 260;
            ucapan = "               KEMBALI : " + uangKembaliTextBox.Text;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            total_qty = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PRODUCT_QTY), 0) FROM SALES_DETAIL S, MASTER_PRODUCT P WHERE S.PRODUCT_ID = P.PRODUCT_ID AND S.SALES_INVOICE = '" + selectedsalesinvoice + "'"));

            Offset = Offset + 25;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "TOTAL BARANG : " + total_qty;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            //eNd of content

            //FOOTER

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = 300;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "TERIMA KASIH ATAS KUNJUNGAN ANDA";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "MAAF BARANG YANG SUDAH DIBELI";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "TIDAK DAPAT DITUKAR/ DIKEMBALIKKAN";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            //end of footer

        }

        private void tempoMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                tempoMaskedTextBox.SelectAll();
            });
        }

        private void discJualMaskedTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                discJualMaskedTextBox.SelectAll();
            });
        }

        private void bayarTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                bayarTextBox.SelectAll();
            });
        }
    }
}
