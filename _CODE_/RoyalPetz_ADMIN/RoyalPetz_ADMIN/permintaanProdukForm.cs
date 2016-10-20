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
using Hotkeys;

namespace RoyalPetz_ADMIN
{
    public partial class permintaanProdukForm : Form
    {
        private int originModuleID = 0;
        private int selectedBranchFromID = 0;
        private int selectedBranchToID = 0;
        private string previousInput = "";
        private double globalTotalValue = 0;
        private bool isLoading = false;

        private int selectedROID = 0;
        private string selectedROInvoice = "";
        private bool navKeyRegistered = false;
        private bool delKeyRegistered = false;

        private Hotkeys.GlobalHotkey ghk_F1;
        private Hotkeys.GlobalHotkey ghk_F2;
        private Hotkeys.GlobalHotkey ghk_F8;
        private Hotkeys.GlobalHotkey ghk_F9;
        private Hotkeys.GlobalHotkey ghk_F11;
        private Hotkeys.GlobalHotkey ghk_DEL;

        private Hotkeys.GlobalHotkey ghk_CTRL_DEL;
        private Hotkeys.GlobalHotkey ghk_CTRL_ENTER;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        private Data_Access DS = new Data_Access();

        private List<string> detailRequestQty = new List<string>();
        private List<string> productPriceList = new List<string>();
        private List<string> subtotalList = new List<string>();

        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Button[] arrButton = new Button[3];

        barcodeForm displayBarcodeForm = null;
        dataProdukForm browseProdukForm = null;

        public permintaanProdukForm()
        {
            InitializeComponent();
        }

        public permintaanProdukForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        public permintaanProdukForm(int moduleID, int roID)
        {
            InitializeComponent();
            originModuleID = moduleID;
            selectedROID = roID;
        }

        private void captureAll(Keys key)
        {
            int rowcount = 0;
            switch (key)
            {
                case Keys.F1:
                    penerimaanBarangHelpForm displayHelp = new penerimaanBarangHelpForm();
                    displayHelp.ShowDialog(this);
                    break;

                case Keys.F2:
                    if (null == displayBarcodeForm || displayBarcodeForm.IsDisposed)
                    { 
                        displayBarcodeForm = new barcodeForm(this, globalConstants.NEW_REQUEST_ORDER);

                        displayBarcodeForm.Top = this.Top + 5;
                        displayBarcodeForm.Left = this.Left + 5;//(Screen.PrimaryScreen.Bounds.Width / 2) - (displayBarcodeForm.Width / 2);
                    }

                    displayBarcodeForm.Show();
                    displayBarcodeForm.WindowState = FormWindowState.Normal;
                    break;

                case Keys.F8:
                    //detailRequestOrderDataGridView.Focus();
                    rowcount = detailRequestOrderDataGridView.RowCount;
                    detailRequestOrderDataGridView.CurrentCell = detailRequestOrderDataGridView.Rows[rowcount - 1].Cells["productID"];
                    //addNewRow();
                    break;

                case Keys.F9:
                    saveButton.PerformClick();
                    break;

                case Keys.F11:
                    if (null == browseProdukForm || browseProdukForm.IsDisposed)
                        browseProdukForm = new dataProdukForm(globalConstants.NEW_REQUEST_ORDER, this);

                    browseProdukForm.Show();
                    browseProdukForm.WindowState = FormWindowState.Normal;
                    break;

                case Keys.Delete:
                    if (detailRequestOrderDataGridView.Rows.Count > 1)
                        if (detailRequestOrderDataGridView.ReadOnly == false)
                        {
                            if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?", "WARNING", MessageBoxButtons.YesNo))
                            {
                                deleteCurrentRow();
                                calculateTotal();
                            }
                        }
                    break;

                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;

                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        private void captureCtrlModifier(Keys key)
        {
            switch (key)
            {
                case Keys.Delete: // CTRL + DELETE
                    if (detailRequestOrderDataGridView.ReadOnly == false)
                    {
                        if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?", "WARNING", MessageBoxButtons.YesNo))
                        {
                            deleteCurrentRow();
                            calculateTotal();
                        }
                    }
                    break;

                case Keys.Enter: // CTRL + ENTER
                    saveButton.PerformClick();
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
                //else if (modifier == Constants.ALT)
                //    captureAltModifier(key);
                else if (modifier == Constants.CTRL)
                    captureCtrlModifier(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_F1 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F1, this);
            ghk_F1.Register();

            ghk_F2 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F2, this);
            ghk_F2.Register();

            ghk_F8 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F8, this);
            ghk_F8.Register();

            ghk_F9 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F9, this);
            ghk_F9.Register();

            ghk_F11 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F11, this);
            ghk_F11.Register();

            //ghk_DEL = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Delete, this);
            //ghk_DEL.Register();

            //ghk_CTRL_DEL = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.Delete, this);
            //ghk_CTRL_DEL.Register();

            ghk_CTRL_ENTER = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.Enter, this);
            ghk_CTRL_ENTER.Register();

            registerNavigationKey();
        }

        private void unregisterGlobalHotkey()
        {
            ghk_F1.Unregister();
            ghk_F2.Unregister();
            ghk_F8.Unregister();
            ghk_F9.Unregister();
            ghk_F11.Unregister();
            //ghk_DEL.Unregister();

            //ghk_CTRL_DEL.Unregister();
            ghk_CTRL_ENTER.Unregister();

            unregisterNavigationKey();
        }

        private void registerDelKey()
        {
            ghk_DEL = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Delete, this);
            ghk_DEL.Register();

            delKeyRegistered = true;
        }

        private void unregisterDelKey()
        {
            ghk_DEL.Unregister();

            delKeyRegistered = false;
        }

        private void registerNavigationKey()
        {
            ghk_UP = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_UP.Register();

            ghk_DOWN = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Down, this);
            ghk_DOWN.Register();

            navKeyRegistered = true;
        }

        private void unregisterNavigationKey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();

            navKeyRegistered = false;
        }

        public void addNewRow()
        {
            int newRowIndex = 0;
            bool allowToAdd = true;

            for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count && allowToAdd; i++)
            {
                if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                {
                    if (!gUtil.isProductIDExist(detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString()))
                    {
                        allowToAdd = false;
                        newRowIndex = i;
                    }
                }
                else
                {
                    allowToAdd = false;
                    newRowIndex = i;
                }
            }

            if (allowToAdd)
            {
                detailRequestOrderDataGridView.Rows.Add();
                detailRequestQty.Add("0");
                newRowIndex = detailRequestOrderDataGridView.Rows.Count - 1;
            }
            else
            {
                DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[newRowIndex];
                clearUpSomeRowContents(selectedRow, newRowIndex);
            }

            detailRequestOrderDataGridView.CurrentCell = detailRequestOrderDataGridView.Rows[newRowIndex].Cells["productID"];
        }

        public void addNewRowFromBarcode(string productID, string productName)
        {
            int i = 0;
            bool found = false;
            int rowSelectedIndex = 0;
            bool foundEmptyRow = false;
            int emptyRowIndex = 0;
            double currQty;
            double subTotal;
            double hpp;

            if (detailRequestOrderDataGridView.ReadOnly == true)
                return;

            detailRequestOrderDataGridView.Focus();

            // CHECK FOR EXISTING SELECTED ITEM
            for (i = 0; i < detailRequestOrderDataGridView.Rows.Count && !found && !foundEmptyRow; i++)
            {
                if (null != detailRequestOrderDataGridView.Rows[i].Cells["productName"].Value &&
                     null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value &&
                     gUtil.isProductIDExist(detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString()))
                {
                    if (detailRequestOrderDataGridView.Rows[i].Cells["productName"].Value.ToString() == productName)
                    {
                        found = true;
                        rowSelectedIndex = i;
                    }
                }
                else
                {
                    foundEmptyRow = true;
                    emptyRowIndex = i;
                }
            }

            if (!found)
            {
                if (foundEmptyRow)
                {
                    detailRequestQty[emptyRowIndex] = "0";
                    rowSelectedIndex = emptyRowIndex;
                }
                else
                {
                    detailRequestOrderDataGridView.Rows.Add();
                    detailRequestQty.Add("0");
                    rowSelectedIndex = detailRequestOrderDataGridView.Rows.Count - 1;
                }
            }

            DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];
            updateSomeRowContents(selectedRow, rowSelectedIndex, productID);

            if (!found)
            {
                selectedRow.Cells["qty"].Value = 1;
                detailRequestQty[rowSelectedIndex] = "1";
                currQty = 1;
            }
            else
            {
                currQty = Convert.ToDouble(detailRequestQty[rowSelectedIndex]) + 1;

                selectedRow.Cells["qty"].Value = currQty;
                detailRequestQty[rowSelectedIndex] = currQty.ToString();
            }

            hpp = Convert.ToDouble(selectedRow.Cells["HPP"].Value);

            subTotal = Math.Round((hpp * currQty), 2);
            selectedRow.Cells["subTotal"].Value = subTotal;

            calculateTotal();

            detailRequestOrderDataGridView.CurrentCell = selectedRow.Cells["qty"];
        }

        private void loadDataHeaderRO()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DS.mySqlConnect();

            sqlCommand = "SELECT * FROM REQUEST_ORDER_HEADER WHERE ID = " + selectedROID;

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        ROinvoiceTextBox.Text = rdr.GetString("RO_INVOICE");
                        RODateTimePicker.Value = rdr.GetDateTime("RO_DATETIME");
                        
                        //branchFromCombo.Text = getBranchName(rdr.GetInt32("RO_BRANCH_ID_FROM"));
                        selectedBranchFromID = rdr.GetInt32("RO_BRANCH_ID_FROM");
                        
                        //branchToCombo.Text = getBranchName(rdr.GetInt32("RO_BRANCH_ID_TO"));
                        selectedBranchToID = rdr.GetInt32("RO_BRANCH_ID_TO");
                        
                        durationTextBox.Text = Convert.ToInt32((rdr.GetDateTime("RO_EXPIRED") - rdr.GetDateTime("RO_DATETIME")).TotalDays).ToString();
                        totalLabel.Text = rdr.GetDouble("RO_TOTAL").ToString("C", culture);
                        globalTotalValue = rdr.GetDouble("RO_TOTAL");
                    }

                    rdr.Close();
                }
            }
        }

        private void loadDataDetailRO()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";
            string productName = "";

            sqlCommand = "SELECT R.*, M.PRODUCT_NAME FROM REQUEST_ORDER_DETAIL R, MASTER_PRODUCT M WHERE R.RO_INVOICE = '" + selectedROInvoice + "' AND R.PRODUCT_ID = M.PRODUCT_ID";

            using (rdr = DS.getData(sqlCommand))
            {
                detailRequestOrderDataGridView.Rows.Clear();
                while (rdr.Read())
                {
                    productName = rdr.GetString("PRODUCT_NAME");
                    detailRequestOrderDataGridView.Rows.Add(rdr.GetString("PRODUCT_ID"), productName, rdr.GetString("RO_QTY"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("RO_SUBTOTAL"));
                    subtotalList[detailRequestOrderDataGridView.Rows.Count - 1] = rdr.GetString("RO_SUBTOTAL");
                    productPriceList[detailRequestOrderDataGridView.Rows.Count - 1] = rdr.GetString("PRODUCT_BASE_PRICE");
                    detailRequestQty[detailRequestOrderDataGridView.Rows.Count - 1] = rdr.GetString("RO_QTY");
                }

                rdr.Close();
            }
        }

        private void calculateTotal()
        {
            double total = 0;

            for (int i = 0; i<detailRequestOrderDataGridView.Rows.Count;i++)
            {
                if (null != detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value)
                    total = total + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value);
            }

            globalTotalValue = total;
            totalLabel.Text = total.ToString("C2", culture);
        }

        private void setTextBoxCustomSource(TextBox textBox)
        {
            MySqlDataReader rdr;
            string sqlCommand = "";
            string[] arr = null;
            List<string> arrList = new List<string>();

            sqlCommand = "SELECT PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1";
            rdr = DS.getData(sqlCommand);

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    arrList.Add(rdr.GetString("PRODUCT_NAME"));
                }
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                arr = arrList.ToArray();
                collection.AddRange(arr);

                textBox.AutoCompleteCustomSource = collection;
            }

            rdr.Close();
        }

        private void detailRequestOrderDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailRequestOrderDataGridView.CurrentCell.OwningColumn.Name == "productID") && e.Control is TextBox)
            {
                TextBox productIDTextBox = e.Control as TextBox;
                //productIDTextBox.TextChanged -= TextBox_TextChanged;
                productIDTextBox.PreviewKeyDown += TextBox_previewKeyDown;
                productIDTextBox.CharacterCasing = CharacterCasing.Upper;
                productIDTextBox.AutoCompleteMode = AutoCompleteMode.None;
                //productIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //setTextBoxCustomSource(productIDTextBox);
            }

            if ((detailRequestOrderDataGridView.CurrentCell.OwningColumn.Name == "productName") && e.Control is TextBox)
            {
                TextBox productIDTextBox = e.Control as TextBox;
                //productIDTextBox.TextChanged -= TextBox_TextChanged;
                productIDTextBox.PreviewKeyDown += productName_previewKeyDown;
                productIDTextBox.CharacterCasing = CharacterCasing.Upper;
                productIDTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                productIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                setTextBoxCustomSource(productIDTextBox);
            }

            if (detailRequestOrderDataGridView.CurrentCell.OwningColumn.Name == "qty" && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                //textBox.TextChanged += TextBox_TextChanged;
                textBox.PreviewKeyDown -= TextBox_previewKeyDown;
                textBox.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void clearUpSomeRowContents(DataGridViewRow selectedRow, int rowSelectedIndex)
        {
            isLoading = true;
            selectedRow.Cells["productName"].Value = "";
            selectedRow.Cells["HPP"].Value = "0";
            selectedRow.Cells["subTotal"].Value = "0";
            selectedRow.Cells["qty"].Value = "0";

            detailRequestQty[rowSelectedIndex] = "0";
            calculateTotal();
            isLoading = false;
        }

        private void updateSomeRowContents(DataGridViewRow selectedRow, int rowSelectedIndex, string currentValue, bool isProductID = true)
        {
            int numRow = 0;
            string selectedProductID = "";
            string selectedProductName = "";

            double hpp = 0;
            string currentProductID = "";
            string currentProductName = "";
            bool changed = false;

            //numRow = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'"));

            if (isProductID)
                numRow = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'"));
            else
                numRow = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_NAME = '" + currentValue + "'"));

            if (numRow > 0)
            {
                if (isProductID)
                {
                    selectedProductID = currentValue;
                    selectedProductName = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_NAME,'') FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'").ToString();
                }
                else
                {
                    selectedProductName = currentValue;
                    selectedProductID = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_ID,'') FROM MASTER_PRODUCT WHERE PRODUCT_NAME = '" + currentValue + "'").ToString();
                }

                if (null != selectedRow.Cells["productID"].Value)
                    currentProductID = selectedRow.Cells["productID"].Value.ToString();

                if (null != selectedRow.Cells["productName"].Value)
                    currentProductName = selectedRow.Cells["productName"].Value.ToString();

                selectedRow.Cells["productId"].Value = selectedProductID;
                selectedRow.Cells["productName"].Value = selectedProductName;

                if (selectedProductID != currentProductID)
                    changed = true;

                if (selectedProductName != currentProductName)
                    changed = true;

                if (!changed)
                    return;

                hpp = getHPPValue(selectedProductID);
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "updateSomeRowsContent, PRODUCT_BASE_PRICE [" + hpp + "]");
                selectedRow.Cells["HPP"].Value = hpp.ToString();

                selectedRow.Cells["qty"].Value = 0;
                detailRequestQty[rowSelectedIndex] = "0";

                selectedRow.Cells["subTotal"].Value = 0;

                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "updateSomeRowsContent, attempt to calculate total");

                calculateTotal();
            }
            else
            {
                clearUpSomeRowContents(selectedRow, rowSelectedIndex);
            }
        }

        private void TextBox_previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string currentValue = "";
            int rowSelectedIndex = 0;
            DataGridViewTextBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            if (detailRequestOrderDataGridView.CurrentCell.OwningColumn.Name != "productID")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                currentValue = dataGridViewComboBoxEditingControl.Text;
                rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

                if (currentValue.Length > 0)
                {
                    updateSomeRowContents(selectedRow, rowSelectedIndex, currentValue);
                    detailRequestOrderDataGridView.CurrentCell = selectedRow.Cells["qty"];
                }
                else
                {
                    clearUpSomeRowContents(selectedRow, rowSelectedIndex);
                }
            }
        }

        private void productName_previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string currentValue = "";
            int rowSelectedIndex = 0;
            DataGridViewTextBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            if (detailRequestOrderDataGridView.CurrentCell.OwningColumn.Name != "productName")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                currentValue = dataGridViewComboBoxEditingControl.Text;
                rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

                if (currentValue.Length > 0)
                {
                    updateSomeRowContents(selectedRow, rowSelectedIndex, currentValue, false);
                    detailRequestOrderDataGridView.CurrentCell = selectedRow.Cells["qty"];
                }
                else
                {
                    clearUpSomeRowContents(selectedRow, rowSelectedIndex);
                }
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double productQty = 0;
            double hppValue = 0;
            double subTotal = 0;
            string tempString = "";

            if (isLoading)
                return;

            if (detailRequestOrderDataGridView.CurrentCell.OwningColumn.Name != "qty")
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;
            
            rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

            if (dataGridViewTextBoxEditingControl.Text.Length <= 0)
            {
                // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
                isLoading = true;
                // reset subTotal Value and recalculate total
                selectedRow.Cells["subTotal"].Value = 0;

                if (detailRequestQty.Count >= rowSelectedIndex + 1)
                    detailRequestQty[rowSelectedIndex] = "0";

                dataGridViewTextBoxEditingControl.Text = "0";

                calculateTotal();

                dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;

                isLoading = false;
                return;
            }

            if (detailRequestQty.Count >= rowSelectedIndex + 1)
                previousInput = detailRequestQty[rowSelectedIndex];
            else
                previousInput = "0";

            isLoading = true;
            if (previousInput == "0")
            {
                tempString = dataGridViewTextBoxEditingControl.Text;
                if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
                    dataGridViewTextBoxEditingControl.Text = tempString.Remove(tempString.IndexOf('0'), 1);
            }

            if ( detailRequestQty.Count < rowSelectedIndex+1 )
            {
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    detailRequestQty.Add(dataGridViewTextBoxEditingControl.Text);
                }
                else
                {
                    dataGridViewTextBoxEditingControl.Text = previousInput;
                }
            }
            else
            {
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL) 
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    detailRequestQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
                else
                {
                    dataGridViewTextBoxEditingControl.Text = detailRequestQty[rowSelectedIndex];
                }
            }

            try
            {
                productQty = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);

                if (null != selectedRow.Cells["hpp"].Value)
                {
                    hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);
                    subTotal = Math.Round((hppValue * productQty), 2);

                    selectedRow.Cells["subTotal"].Value = subTotal;
                }

                calculateTotal();
            }
            catch (Exception ex)
            {
                //dataGridViewTextBoxEditingControl.Text = previousInput;
            }

            dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;
            isLoading = false;
        }

        private bool exportDataRO(string exportedFileName= "")
        {
            bool result = false;

            string sqlCommand = "";
            MySqlException internalEX = null;
            string roInvoice = "";
            int branchIDFrom = 0;
            int branchIDTo = 0;
            string roDateTime = "";
            double roTotal = 0;
            string roDateExpired = "";
            DateTime selectedRODate;
            DateTime expiredRODate;

            string selectedDate = RODateTimePicker.Value.ToShortDateString();
            selectedRODate = RODateTimePicker.Value;
            expiredRODate = selectedRODate.AddDays(Convert.ToDouble(durationTextBox.Text));

            roInvoice = ROinvoiceTextBox.Text;
            branchIDFrom = selectedBranchFromID;
            branchIDTo = selectedBranchToID;

            roDateTime = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(selectedDate));
            roDateExpired = String.Format(culture, "{0:dd-MM-yyyy}", expiredRODate);
            roTotal = globalTotalValue;


            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                if (exportedFileName.Length > 0)
                { 
                    //WRITE RO INVOICE
                    using (StreamWriter outputFile = new StreamWriter(exportedFileName))
                    {
                        outputFile.WriteLine(roInvoice);
                    }

                    // WRITE HEADER TABLE SQL
                    sqlCommand = "INSERT INTO REQUEST_ORDER_HEADER (RO_INVOICE, RO_BRANCH_ID_FROM, RO_BRANCH_ID_TO, RO_DATETIME, RO_TOTAL, RO_EXPIRED, RO_ACTIVE) VALUES " +
                                        "('" + roInvoice + "', " + branchIDFrom + ", " + branchIDTo + ", STR_TO_DATE('" + roDateTime + "', '%d-%m-%Y'), " + roTotal + ", STR_TO_DATE('" + roDateExpired + "', '%d-%m-%Y'), 1)";

                    gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : ATTEMPT TO WRITE HEADER DATA TO FILE");
                    using (StreamWriter outputFile = new StreamWriter(exportedFileName, true))
                    {
                        outputFile.WriteLine(sqlCommand);
                    }

                    // WRITE DETAIL TABLE SQL
                    gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : ATTEMPT TO WRITE DETAIL DATA TO FILE");
                    for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count; i++)
                    {
                        if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                        {
                            sqlCommand = "INSERT INTO REQUEST_ORDER_DETAIL (RO_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, RO_QTY, RO_SUBTOTAL) VALUES " +
                                                "('" + roInvoice + "', '" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value) + ")";

                            using (StreamWriter outputFile = new StreamWriter(exportedFileName, true))
                            {
                                outputFile.WriteLine(sqlCommand);
                            }

                        }
                    }
                }

                sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET RO_EXPORTED = 1 WHERE RO_INVOICE = '" + roInvoice + "'";
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : UPDATE FLAG FOR REQUEST ORDER");
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DS.commit();

                result = true;
            }
            catch (Exception e)
            {
                result = false;
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : EXCEPTION THROWN ["+e.Message+"]");
                try
                {
                    if (System.IO.File.Exists(exportedFileName))
                        System.IO.File.Delete(exportedFileName);

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
            }

            return result;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            string exportedFileName = "";
            string roInvoice = "";

            gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : ATTEMPT TO SAVE TO LOCAL DATA");
            if (saveData())
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : REQUEST ORDER SAVED TO LOCAL DATA");
                string selectedDate = RODateTimePicker.Value.ToShortDateString();
                roInvoice = ROinvoiceTextBox.Text;

                exportedFileName = "RO_" + roInvoice + "_" + String.Format(culture, "{0:ddMMyyyy}", Convert.ToDateTime(selectedDate)) + ".exp";

                saveFileDialog1.FileName = exportedFileName;
                saveFileDialog1.Filter = "Export File (.exp)|*.exp";

                //saveFileDialog1.ShowDialog();

                if (DialogResult.OK == saveFileDialog1.ShowDialog())
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : ATTEMPT TO EXPORT DATA TO ["+ saveFileDialog1.FileName + "]");
                    if (exportDataRO(saveFileDialog1.FileName))
                    {
                        gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXPORT DATA : REQUEST ORDER EXPORTED");
                        gUtil.saveUserChangeLog(globalConstants.MENU_REQUEST_ORDER, globalConstants.CHANGE_LOG_INSERT, "EXPORT REQUEST ORDER [" + ROinvoiceTextBox.Text + "] TO FILE");
                        gUtil.ResetAllControls(this);
                        originModuleID = globalConstants.NEW_REQUEST_ORDER;
                        detailRequestOrderDataGridView.Rows.Clear();
                        totalLabel.Text = "Rp. 0";

                        selectedBranchFromID = 0;
                        selectedBranchToID = 0;

                        gUtil.showSuccess(gUtil.UPD);

                        ROinvoiceTextBox.ReadOnly = false;
                        ROinvoiceTextBox.Focus();
                    }
                }
            }
        }

        private double getHPPValue(string productID)
        {
            double result = 0;
            
            result = Convert.ToDouble(DS.getDataSingleValue("SELECT PRODUCT_BASE_PRICE FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void addColumnToDataGrid()
        {
            DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn basePriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();

            productIdColumn.HeaderText = "KODE PRODUK";
            productIdColumn.Name = "productID";
            productIdColumn.Width = 200;
            productIdColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailRequestOrderDataGridView.Columns.Add(productIdColumn);

            productNameColumn.HeaderText = "NAMA PRODUK";
            productNameColumn.Name = "productName";
            productNameColumn.Width = 300;
            productNameColumn.ReadOnly = true;
            detailRequestOrderDataGridView.Columns.Add(productNameColumn);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            stockQtyColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailRequestOrderDataGridView.Columns.Add(stockQtyColumn);

            //detailRequestOrderDataGridView.Columns["qty"].DefaultCellStyle.Format = "0,.###";
            //detailRequestOrderDataGridView.Columns["qty"].DefaultCellStyle.Format = "#,#";
            detailRequestOrderDataGridView.Columns["qty"].DefaultCellStyle.Format = "#,0.##";

            basePriceColumn.HeaderText = "HARGA POKOK";
            basePriceColumn.Name = "HPP";
            basePriceColumn.Width = 200;
            basePriceColumn.ReadOnly = true;
            detailRequestOrderDataGridView.Columns.Add(basePriceColumn);

            subTotalColumn.HeaderText = "SUBTOTAL";
            subTotalColumn.Name = "subTotal";
            subTotalColumn.Width = 200;
            subTotalColumn.ReadOnly = true;
            detailRequestOrderDataGridView.Columns.Add(subTotalColumn);

            //this.maskedTextBox = new MaskedTextBox();
            //this.maskedTextBox.Visible = false;
            //this.detailRequestOrderDataGridView.Controls.Add(this.maskedTextBox);

            //this.detailRequestOrderDataGridView.CellBeginEdit += new DataGridViewCellCancelEventHandler(dataGridView1_CellBeginEdit);
            //this.detailRequestOrderDataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            //this.detailRequestOrderDataGridView.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
        }
        
        private void permintaanProdukForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            RODateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            addColumnToDataGrid();

            // ALL REQUEST WILL GO TO PUSAT 
            selectedBranchFromID = 0; // SET BRANCH_FROM TO PUSAT 
            selectedBranchToID = getCurrentBranchID(); // SET BRANCH_TO TO CURRENT BRANCH

            detailRequestOrderDataGridView.EditingControlShowing += detailRequestOrderDataGridView_EditingControlShowing;

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_REQUEST_ORDER, gUtil.getUserGroupID());

            if (originModuleID == globalConstants.NEW_REQUEST_ORDER)
            {
                if (userAccessOption != 2 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }
            else if (originModuleID == globalConstants.EDIT_REQUEST_ORDER)
            {
                if (userAccessOption != 4 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }

            arrButton[0] = saveButton;
            arrButton[1] = generateButton;
            arrButton[2] = exportButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);

            subtotalList.Add("0");
            productPriceList.Add("0");
            detailRequestQty.Add("0");
        }

        private bool invoiceExist()
        {
            bool result = false;

            DS.mySqlConnect();

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM REQUEST_ORDER_HEADER WHERE RO_INVOICE = '" + ROinvoiceTextBox.Text + "'")) > 0)
                result = true;

            return result;
        }

        private void ROinvoiceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            ROinvoiceTextBox.Text = ROinvoiceTextBox.Text.Trim();
            if (invoiceExist())
            {
                errorLabel.Text = "NO PERMINTAAN SUDAH ADA";
                //ROinvoiceTextBox.BackColor = Color.Red;
                ROinvoiceTextBox.Focus();
            }
            else
            {
                errorLabel.Text = "";
               // ROinvoiceTextBox.BackColor = Color.White;
            }
        }

        private void fillInBranchFromCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME FROM MASTER_BRANCH WHERE BRANCH_ACTIVE = 1 ORDER BY BRANCH_NAME ASC";

            branchFromCombo.Items.Clear();
            branchFromComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    branchFromCombo.Items.Add(rdr.GetString("BRANCH_NAME"));
                    branchFromComboHidden.Items.Add(rdr.GetString("BRANCH_ID"));
                }
            }

            rdr.Close();
        }
        
        private void fillInBranchToCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME FROM MASTER_BRANCH WHERE BRANCH_ACTIVE = 1 AND BRANCH_ID <> " + selectedBranchFromID + " ORDER BY BRANCH_NAME ASC";

            branchToCombo.Text = "";
            branchToCombo.Items.Clear();
            branchToComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    branchToCombo.Items.Add(rdr.GetString("BRANCH_NAME"));
                    branchToComboHidden.Items.Add(rdr.GetString("BRANCH_ID"));
                }
            }

            rdr.Close();
        }

        private void branchFromCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = branchFromCombo.SelectedIndex;

            if (!isLoading)
                selectedBranchFromID = Convert.ToInt32(branchFromComboHidden.Items[selectedIndex]);

            fillInBranchToCombo();
        }

        private void branchToCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                selectedBranchToID = Convert.ToInt32(branchToComboHidden.Items[branchToCombo.SelectedIndex].ToString());
        }

        private bool dataValidated()
        {
            int i = 0;
            //bool dataExist = true;

            if (selectedBranchToID == 0)
            {
                errorLabel.Text = "SYSTEM BRANCH ID BELUM DIISI";
                return false;
            }

            if (ROinvoiceTextBox.Text.Equals(""))
            {
                errorLabel.Text = "NO PERMINTAAN TIDAK BOLEH KOSONG";
                return false;
            }

            if (detailRequestOrderDataGridView.Rows.Count <= 0)
            {
                errorLabel.Text = "TIDAK ADA BARANG YANG DIMINTA";
                return false;
            }

            //for (i = 0; i < detailRequestOrderDataGridView.Rows.Count && dataExist; i++)
            //{
            //    if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
            //        dataExist = gUtil.isProductIDExist(detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString());
            //    else
            //        dataExist = false;
            //}
            //if (!dataExist)
            //{
            //    i = i + 1;
            //    errorLabel.Text = "PRODUCT ID PADA BARIS [" + i + "] INVALID";
            //    return false;
            //}

            return true;
        }

        private int getCurrentBranchID()
        {
            int result = 0;

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(BRANCH_ID, 0) FROM SYS_CONFIG WHERE ID = 2"));

            return result;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string roInvoice = "";
            int branchIDFrom = 0;
            int branchIDTo = 0;
            string roDateTime = "";
            double roTotal = 0;
            string roDateExpired = "";
            DateTime selectedRODate;
            DateTime expiredRODate;

            string selectedDate = RODateTimePicker.Value.ToShortDateString();
            selectedRODate = RODateTimePicker.Value;
            expiredRODate = selectedRODate.AddDays(Convert.ToDouble(durationTextBox.Text));

            roInvoice = ROinvoiceTextBox.Text;
            branchIDFrom = selectedBranchFromID;
            branchIDTo = selectedBranchToID;

            roDateTime = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(selectedDate));
            roDateExpired = String.Format(culture, "{0:dd-MM-yyyy}", expiredRODate);
            roTotal = globalTotalValue;
            
            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch(originModuleID)
                {
                    case globalConstants.NEW_REQUEST_ORDER:
                        // SAVE HEADER TABLE
                        sqlCommand = "INSERT INTO REQUEST_ORDER_HEADER (RO_INVOICE, RO_BRANCH_ID_FROM, RO_BRANCH_ID_TO, RO_DATETIME, RO_TOTAL, RO_EXPIRED, RO_ACTIVE) VALUES " +
                                            "('" + roInvoice + "', " + branchIDFrom + ", " + branchIDTo + ", STR_TO_DATE('" + roDateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(roTotal) + ", STR_TO_DATE('" + roDateExpired + "', '%d-%m-%Y'), 1)";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "INSERT NEW REQUEST ORDER [" + roInvoice + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count-1; i++)
                        {
                            if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO REQUEST_ORDER_DETAIL (RO_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, RO_QTY, RO_SUBTOTAL) VALUES " +
                                                    "('" + roInvoice + "', '" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "INSERT DETAIL REQUEST ORDER [" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "]");
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }
                        break;

                    case globalConstants.EDIT_REQUEST_ORDER:
                        // UPDATE HEADER TABLE
                        sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET " +
                                            "RO_BRANCH_ID_FROM = " + branchIDFrom + ", " +
                                            "RO_BRANCH_ID_TO = " + branchIDTo + ", " +
                                            "RO_DATETIME = STR_TO_DATE('" + roDateTime + "', '%d-%m-%Y'), " +
                                            "RO_TOTAL = " + gUtil.validateDecimalNumericInput(roTotal) + ", " +
                                            "RO_EXPIRED = STR_TO_DATE('" + roDateExpired + "', '%d-%m-%Y') " +
                                            "WHERE RO_INVOICE = '" + roInvoice + "'";

                        gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EDIT REQUEST ORDER [" + roInvoice + "]");

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // DELETE DETAIL TABLE
                        sqlCommand = "DELETE FROM REQUEST_ORDER_DETAIL WHERE RO_INVOICE = '" + roInvoice + "'";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "DELETE DETAIL REQUEST ORDER [" + roInvoice + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // RE-INSERT DETAIL TABLE
                        for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count-1; i++)
                        {
                            if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO REQUEST_ORDER_DETAIL (RO_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, RO_QTY, RO_SUBTOTAL) VALUES " +
                                                    "('" + roInvoice + "', '" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "INSERT NEW DETAIL REQUEST ORDER [" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "]");
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }
                        break;
                }
                
                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXCEPTION THROWN [" + e.Message + "]");
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
            isLoading = true;
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
            isLoading = false;
            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "ATTEMPT TO SAVE");
            if (saveData())
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "DATA SAVED SUCCESSFULLY");

                switch (originModuleID)
                {
                    case globalConstants.NEW_REQUEST_ORDER:
                        gUtil.saveUserChangeLog(globalConstants.MENU_REQUEST_ORDER, globalConstants.CHANGE_LOG_INSERT, "CREATE NEW REQUEST ORDER [" + ROinvoiceTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_REQUEST_ORDER:
                        gUtil.saveUserChangeLog(globalConstants.MENU_REQUEST_ORDER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE REQUEST ORDER [" + ROinvoiceTextBox.Text + "]");
                        break;
                }
                gUtil.ResetAllControls(this);
                originModuleID = globalConstants.NEW_REQUEST_ORDER;
                detailRequestOrderDataGridView.Rows.Clear();
                totalLabel.Text = "Rp. 0";

                if (originModuleID == globalConstants.NEW_REQUEST_ORDER)
                    gUtil.showSuccess(gUtil.INS);
                else if (originModuleID == globalConstants.EDIT_REQUEST_ORDER)
                    gUtil.showSuccess(gUtil.UPD);
                
                ROinvoiceTextBox.Focus();
            }
        }

        private void deleteCurrentRow()
        {
            if (detailRequestOrderDataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];
                detailRequestOrderDataGridView.CurrentCell = selectedRow.Cells["productName"];

                if (null != selectedRow && rowSelectedIndex != detailRequestOrderDataGridView.Rows.Count - 1)
                {
                    for (int i = rowSelectedIndex; i < detailRequestOrderDataGridView.Rows.Count - 1; i++)
                    {
                        detailRequestQty[i] = detailRequestQty[i + 1];
                        productPriceList[i] = productPriceList[i + 1];
                        subtotalList[i] = subtotalList[i + 1];
                    }

                    isLoading = true;
                    detailRequestOrderDataGridView.Rows.Remove(selectedRow);
                    gUtil.saveSystemDebugLog(globalConstants.MENU_PENERIMAAN_BARANG, "deleteCurrentRow [" + rowSelectedIndex + "]");
                    isLoading = false;
                }
            }
        }

        private void detailRequestOrderDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?","WARNING", MessageBoxButtons.YesNo))
                {
                    deleteCurrentRow();
                    calculateTotal();
                }
            }
        }

        private bool isExportedRO()
        {
            bool result = false;

            if (0!=Convert.ToInt32(DS.getDataSingleValue("SELECT RO_EXPORTED FROM REQUEST_ORDER_HEADER WHERE RO_INVOICE = '"+ROinvoiceTextBox.Text+"'")))
            {
                result = true;
            }

            return result;
        }

        private void permintaanProdukForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";

            deactivateButton.Visible = false;

            if (originModuleID == globalConstants.EDIT_REQUEST_ORDER)
            {
                isLoading = true;

                loadDataHeaderRO();
                selectedROInvoice = ROinvoiceTextBox.Text;
                ROinvoiceTextBox.ReadOnly = true;

                loadDataDetailRO();

                if (isExportedRO())
                {
                    ROinvoiceTextBox.ReadOnly = true;
                    RODateTimePicker.Enabled = false;
                    branchFromCombo.Enabled = false;
                    branchToCombo.Enabled = false;
                    durationTextBox.ReadOnly = true;
                    detailRequestOrderDataGridView.ReadOnly = true;
                    detailRequestOrderDataGridView.AllowUserToAddRows = false;
                    saveButton.Visible = false;
                    deactivateButton.Visible = true;
                }

                gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

                isLoading = false;
            }

            registerGlobalHotkey();

            if (detailRequestOrderDataGridView.Focused)
                registerDelKey();
        }

        private bool insertDataToHQ(Data_Access DAccess)
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string roInvoice = "";
            int branchIDFrom = 0;
            int branchIDTo = 0;
            string roDateTime = "";
            double roTotal = 0;
            string roDateExpired = "";
            DateTime selectedRODate;
            DateTime expiredRODate;
            string messageContent = "";

            string selectedDate = RODateTimePicker.Value.ToShortDateString();
            selectedRODate = RODateTimePicker.Value;
            expiredRODate = selectedRODate.AddDays(Convert.ToDouble(durationTextBox.Text));

            roInvoice = ROinvoiceTextBox.Text;
            branchIDFrom = selectedBranchFromID;
            branchIDTo = selectedBranchToID;

            roDateTime = String.Format(culture, "{0:dd-MM-yyyy}", Convert.ToDateTime(selectedDate));
            roDateExpired = String.Format(culture, "{0:dd-MM-yyyy}", expiredRODate);
            roTotal = globalTotalValue;

            DAccess.beginTransaction(Data_Access.HQ_SERVER);

            try
            {
                //DAccess.mySqlConnect();

                // SAVE HEADER TABLE
                sqlCommand = "INSERT INTO REQUEST_ORDER_HEADER (RO_INVOICE, RO_BRANCH_ID_FROM, RO_BRANCH_ID_TO, RO_DATETIME, RO_TOTAL, RO_EXPIRED, RO_ACTIVE) VALUES " +
                                    "('" + roInvoice + "', " + branchIDFrom + ", " + branchIDTo + ", STR_TO_DATE('" + roDateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(roTotal) + ", STR_TO_DATE('" + roDateExpired + "', '%d-%m-%Y'), 1)";

                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "INSERT REQUEST ORDER ["+roInvoice+"] TO HQ");
                if (!DAccess.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                // SAVE DETAIL TABLE
                for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count; i++)
                {
                    if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                    {
                        sqlCommand = "INSERT INTO REQUEST_ORDER_DETAIL (RO_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, RO_QTY, RO_SUBTOTAL) VALUES " +
                                            "('" + roInvoice + "', '" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                        gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "INSERT DETAIL REQUEST ORDER [" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value) + "] TO HQ");
                        if (!DAccess.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;
                    }
                }

                // INSERT INTO HQ MESSAGING TABLE 
                messageContent = "REQUEST ORDER [" + roInvoice + "] EXPIRED PADA TGL " + roDateExpired;

                sqlCommand = "INSERT INTO MASTER_MESSAGE (STATUS, MODULE_ID, IDENTIFIER_NO, MSG_DATETIME_CREATED, MSG_CONTENT) " +
                                        "VALUES " +
                                        "(0, " + globalConstants.MENU_REQUEST_ORDER + ", '" + roInvoice + "', STR_TO_DATE('" + roDateTime + "', '%d-%m-%Y'), '" + messageContent + "')";

                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "INSERT TO HQ MESSAGING TABLE");
                if (!DAccess.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;

                DAccess.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "EXCEPTION THROWN ["+e.Message+"]");
                try
                {
                    DAccess.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DAccess.getMyTransConnection() != null)
                    {
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gUtil.showDBOPError(e, "INSERT");
                result = false;
            }
            finally
            {
                DAccess.mySqlClose();
            }

            return result;
        }

        private bool sendRequestToHQ()
        {
            bool result = false;
            //Data_Access DS_HQ = new Data_Access();

            gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "ATTEMPT TO SAVE TO LOCAL DATABASE");
            if (saveData()) // SAVE TO LOCAL DATABASE FIRST
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "REQUEST ORDER SAVED TO LOCAL DATABASE");
                // CREATE CONNECTION TO CENTRAL HQ DATABASE SERVER
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "ATTEMPT TO CONNECT TO HQ");
                if (DS.HQ_mySQLConnect())
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "CONNECTION TO HQ CREATED");
                    // SEND REQUEST DATA TO HQ
                    gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "ATTEMPT TO INSERT DATA TO HQ");
                    if (insertDataToHQ(DS))
                    {
                        gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "REQUEST ORDER SENT TO HQ SUCCESSFULLY");
                        result = true;
                    }
                    else
                    {
                        gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "REQUEST ORDER FAILED TO SENT TO HQ");
                        MessageBox.Show("FAIL TO INSERT DATA TO HQ");
                        result = false;
                    }
                    // CLOSE CONNECTION TO CENTRAL HQ DATABASE SERVER
                    DS.HQ_mySqlClose();
                }
                else
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "FAILED TO CREATE CONNECTION TO HQ");
                    MessageBox.Show("FAIL TO CONNECT");
                    result = false;
                }
            }

            return result;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "ATTEMPT TO SAVE AND SEND DATA TO HQ");
            if (sendRequestToHQ())
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "REQUEST ORDER SENT TO HQ");
                gUtil.showSuccess(gUtil.INS);
                exportDataRO();
                gUtil.saveUserChangeLog(globalConstants.MENU_REQUEST_ORDER, globalConstants.CHANGE_LOG_INSERT, "SEND REQUEST ORDER [" + ROinvoiceTextBox.Text + "] TO GUDANG PUSAT");

                gUtil.ResetAllControls(this);
                originModuleID = globalConstants.NEW_REQUEST_ORDER;
                detailRequestOrderDataGridView.Rows.Clear();
                totalLabel.Text = "Rp. 0";

                selectedBranchFromID = 0;
                selectedBranchToID = 0;

                gUtil.showSuccess(gUtil.UPD);

                ROinvoiceTextBox.ReadOnly = false;
                ROinvoiceTextBox.Focus();
            }
            else
                MessageBox.Show("KONEKSI KE PUSAT GAGAL");
        }

        private void branchFromCombo_Validated(object sender, EventArgs e)
        {
            if (!branchFromCombo.Items.Contains(branchFromCombo.Text))
                branchFromCombo.Focus();
        }

        private void branchToCombo_Validated(object sender, EventArgs e)
        {
            if (!branchToCombo.Items.Contains(branchToCombo.Text))
                branchToCombo.Focus();
        }

        private bool setNonActiveRO()
        {
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            string roInvoice = "";
            roInvoice = ROinvoiceTextBox.Text;
          
            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET RO_ACTIVE = 0 WHERE RO_INVOICE = '" + roInvoice + "'";

                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                    throw internalEX;
          
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

        private void deactivateButton_Click(object sender, EventArgs e)
        {
            if (setNonActiveRO())
            {
                MessageBox.Show("SUCCESS");
                deactivateButton.Visible = false;
            }
        }

        private void durationTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                durationTextBox.SelectAll();
            });
        }

        private void permintaanProdukForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();

            if (delKeyRegistered)
                unregisterDelKey();
        }

        private void detailRequestOrderDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //var cell = detailRequestOrderDataGridView[e.ColumnIndex, e.RowIndex];
            //DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[e.RowIndex];

            //if (isLoading == true)
            //    return;

            //if (cell.OwningColumn.Name == "productID")
            //{
            //    if (null != cell.Value)
            //    {
            //        if (cell.Value.ToString().Length > 0)
            //        {
            //            updateSomeRowContents(selectedRow, e.RowIndex, cell.Value.ToString());
            //        }
            //        else
            //        {
            //            clearUpSomeRowContents(selectedRow, e.RowIndex);
            //        }
            //    }
            //}

        }

        private void detailRequestOrderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (
              (detailRequestOrderDataGridView.Columns[e.ColumnIndex].Name == "qty" ||
              detailRequestOrderDataGridView.Columns[e.ColumnIndex].Name == "HPP" ||
              detailRequestOrderDataGridView.Columns[e.ColumnIndex].Name == "subTotal")
             && e.RowIndex != this.detailRequestOrderDataGridView.NewRowIndex && null != e.Value)
            {
                isLoading = true;
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString(globalUtilities.CELL_FORMATTING_NUMERIC_FORMAT);
                isLoading = false;
            }
        }

        private void detailRequestOrderDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            subtotalList.Add("0");
            productPriceList.Add("0");
            detailRequestQty.Add("0");

            if (navKeyRegistered)
                unregisterNavigationKey();
        }

        private void detailRequestOrderDataGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterNavigationKey();

            registerDelKey();
        }

        private void detailRequestOrderDataGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerNavigationKey();

            unregisterDelKey();
        }

        private void genericControl_Enter(object sender, EventArgs e)
        {
            unregisterNavigationKey();
        }

        private void genericControl_Leave(object sender, EventArgs e)
        {
            registerNavigationKey();
        }

        private void detailRequestOrderDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            detailRequestOrderDataGridView.SuspendLayout();

            if (navKeyRegistered)
            {
                unregisterNavigationKey();
            }

            if (!delKeyRegistered)
                registerDelKey();

        }

        private void detailRequestOrderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            detailRequestOrderDataGridView.ResumeLayout();
        }

        private void detailRequestOrderDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var cell = detailRequestOrderDataGridView[e.ColumnIndex, e.RowIndex];
            int rowSelectedIndex = 0;

            double subTotal = 0;
            double productQty = 0;
            double hppValue = 0;
            string tempString;
            string cellValue = "";
            string columnName = "";

            columnName = cell.OwningColumn.Name;
            gUtil.saveSystemDebugLog(globalConstants.MENU_REQUEST_ORDER, "REQUEST ORDER : detailRequestOrderDataGridView_CellValueChanged [" + columnName + "]");

            rowSelectedIndex = e.RowIndex;
            DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

            if (null != selectedRow.Cells[columnName].Value)
                cellValue = selectedRow.Cells[columnName].Value.ToString();
            else
                cellValue = "";

            if (columnName == "productName")
            {
                if (cellValue.Length > 0)
                {
                    updateSomeRowContents(selectedRow, rowSelectedIndex, cellValue, false);
                    //int pos = cashierDataGridView.CurrentCell.RowIndex;

                    //if (pos > 0)
                    //    cashierDataGridView.CurrentCell = cashierDataGridView.Rows[pos - 1].Cells["qty"];

                    //forceUpOneLevel = true;
                }
            }
            else if (columnName == "qty")
            { 
                if (cellValue.Length <= 0)
                {
                    // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
                    isLoading = true;
                    // reset subTotal Value and recalculate total
                    selectedRow.Cells["subTotal"].Value = 0;

                    if (detailRequestQty.Count >= rowSelectedIndex + 1)
                        detailRequestQty[rowSelectedIndex] = "0";

                    selectedRow.Cells["qty"].Value = "0";

                    calculateTotal();

                    return;
                }

                if (detailRequestQty.Count >= rowSelectedIndex + 1)
                    previousInput = detailRequestQty[rowSelectedIndex];
                else
                    previousInput = "0";

                isLoading = true;
                if (previousInput == "0")
                {
                    tempString = cellValue;
                    if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
                        selectedRow.Cells["qty"].Value = tempString.Remove(tempString.IndexOf('0'), 1);
                }

                if (detailRequestQty.Count < rowSelectedIndex + 1)
                {
                    if (gUtil.matchRegEx(cellValue, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                        && (cellValue.Length > 0))
                    {
                        detailRequestQty.Add(cellValue);
                    }
                    else
                    {
                        selectedRow.Cells["qty"].Value = previousInput;
                    }
                }
                else
                {
                    if (gUtil.matchRegEx(cellValue, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                        && (cellValue.Length > 0))
                    {
                        detailRequestQty[rowSelectedIndex] = cellValue;
                    }
                    else
                    {
                        selectedRow.Cells["qty"].Value = detailRequestQty[rowSelectedIndex];
                    }
                }

                try
                {
                    productQty = Convert.ToDouble(cellValue);

                    if (null != selectedRow.Cells["hpp"].Value)
                    {
                        hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);
                        subTotal = Math.Round((hppValue * productQty), 2);

                        selectedRow.Cells["subTotal"].Value = subTotal;
                    }

                    calculateTotal();
                }
                catch (Exception ex)
                {
                    //dataGridViewTextBoxEditingControl.Text = previousInput;
                }
            }
        }

        private void detailRequestOrderDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (detailRequestOrderDataGridView.IsCurrentCellDirty)
            {
                detailRequestOrderDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
