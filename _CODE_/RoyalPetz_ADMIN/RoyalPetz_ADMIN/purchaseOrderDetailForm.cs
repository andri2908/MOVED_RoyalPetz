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

namespace RoyalPetz_ADMIN
{
    public partial class purchaseOrderDetailForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();

        private bool isLoading = false;
        private double globalTotalValue = 0;
        private List<string> detailQty = new List<string>();
        private List<string> detailHpp = new List<string>();
        private List<string> subtotalList = new List<string>();

        private CultureInfo culture = new CultureInfo("id-ID");
        string previousInput = "";
        private bool forceUpOneLevel = false;

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

        int originModuleID = globalConstants.NEW_PURCHASE_ORDER;
        string selectedROInvoice = "";        
        private int selectedSupplierID = 0;
        private int selectedPOID = 0;
        private bool navKeyRegistered = false;
        private bool delKeyRegistered = false;

        // private string selectedPOInvoice = "";
        Button[] arrButton = new Button[2];

        barcodeForm displayBarcodeForm = null;
        dataProdukForm browseProdukForm = null;

        public purchaseOrderDetailForm()
        {
            InitializeComponent();
        }

        public purchaseOrderDetailForm(int moduleID, string roInvoice)
        {
            InitializeComponent();
            originModuleID = moduleID;
            selectedROInvoice = roInvoice;
        }

        public purchaseOrderDetailForm(int moduleID, int poID)
        {
            InitializeComponent();
            originModuleID = moduleID;
            selectedPOID = poID;
        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.F1:
                    penerimaanBarangHelpForm displayHelp = new penerimaanBarangHelpForm();
                    displayHelp.ShowDialog(this);
                    break;

                case Keys.F2:
                    if (detailPODataGridView.ReadOnly == false)
                    {
                        PODateTimePicker.Focus();
                        if (null == displayBarcodeForm || displayBarcodeForm.IsDisposed)
                        { 
                            displayBarcodeForm = new barcodeForm(this, globalConstants.NEW_PURCHASE_ORDER);

                            displayBarcodeForm.Top = this.Top + 5;
                            displayBarcodeForm.Left = this.Left + 5;//(Screen.PrimaryScreen.Bounds.Width / 2) - (displayBarcodeForm.Width / 2);
                        }

                        displayBarcodeForm.Show();
                        displayBarcodeForm.WindowState = FormWindowState.Normal;
                        //detailPODataGridView.Focus();
                    }
                    break;

                case Keys.F8:
                    if (detailPODataGridView.ReadOnly == false)
                    {
                        detailPODataGridView.Focus();
                        addNewRow();
                    }
                    break;

                case Keys.F9:
                    if (saveButton.Visible == true)
                        saveButton.PerformClick();
                    break;

                case Keys.F11:
                    if (detailPODataGridView.ReadOnly == false)
                    {
                        PODateTimePicker.Focus();
                        if (null == browseProdukForm || browseProdukForm.IsDisposed)
                                browseProdukForm = new dataProdukForm(globalConstants.NEW_PURCHASE_ORDER, this);

                        browseProdukForm.Show();
                        browseProdukForm.WindowState = FormWindowState.Normal;
                        //detailPODataGridView.Focus();
                    }
                    break;

                case Keys.Delete:
                    if (detailPODataGridView.Rows.Count > 1)
                        if (detailPODataGridView.ReadOnly == false)
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
                    if (detailPODataGridView.ReadOnly == false)
                    {
                        if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?", "WARNING", MessageBoxButtons.YesNo))
                        {
                            deleteCurrentRow();
                            calculateTotal();
                        }
                    }
                    break;

                case Keys.Enter: // CTRL + ENTER
                    if (saveButton.Visible == true)
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

            //ghk_F8 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F8, this);
            //ghk_F8.Register();

            ghk_F9 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F9, this);
            ghk_F9.Register();

            ghk_F11 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F11, this);
            ghk_F11.Register();

            //ghk_DEL = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Delete, this);
           // ghk_DEL.Register();

            //ghk_CTRL_DEL = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.Delete, this);
            //ghk_CTRL_DEL.Register();

            ghk_CTRL_ENTER = new Hotkeys.GlobalHotkey(Constants.CTRL, Keys.Enter, this);
            ghk_CTRL_ENTER.Register();

        }

        private void unregisterGlobalHotkey()
        {
            ghk_F1.Unregister();
            ghk_F2.Unregister();
            //ghk_F8.Unregister();
            ghk_F9.Unregister();
            ghk_F11.Unregister();

           // ghk_DEL.Unregister();

            //ghk_CTRL_DEL.Unregister();
            ghk_CTRL_ENTER.Unregister();
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

        private void registerDelKey()
        {
            ghk_DEL = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_DEL.Register();

            delKeyRegistered = true;
        }

        private void unregisterDelKey()
        {
            ghk_DEL.Unregister();

            delKeyRegistered = false;
        }

        public void addNewRow()
        {
            int newRowIndex = 0;
            bool allowToAdd = true;

            for (int i = 0; i < detailPODataGridView.Rows.Count && allowToAdd; i++)
            {
                if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                {
                    if (!gUtil.isProductIDExist(detailPODataGridView.Rows[i].Cells["productID"].Value.ToString()))
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
                detailPODataGridView.Rows.Add();
                detailHpp.Add("0");
                detailQty.Add("0");
                subtotalList.Add("0");
                newRowIndex = detailPODataGridView.Rows.Count - 1;
            }
            else
            {
                DataGridViewRow selectedRow = detailPODataGridView.Rows[newRowIndex];
                clearUpSomeRowContents(selectedRow, newRowIndex);
            }

            detailPODataGridView.CurrentCell = detailPODataGridView.Rows[newRowIndex].Cells["productID"];
        }

        public void addNewRowFromBarcode(string productID, string productName, int rowIndex = -1)
        {
            int i = 0;
            bool found = false;
            int rowSelectedIndex = 0;
            bool foundEmptyRow = false;
            int emptyRowIndex = 0;
            double currQty;
            double subTotal;
            double hpp;

            if (detailPODataGridView.ReadOnly == true)
                return;

            detailPODataGridView.AllowUserToAddRows = false;

            detailPODataGridView.Focus();

            if (rowIndex >= 0)
            {
                rowSelectedIndex = rowIndex;
            }
            else
            {
                // CHECK FOR EXISTING SELECTED ITEM
                for (i = 0; i < detailPODataGridView.Rows.Count && !found && !foundEmptyRow; i++)
                {
                    if (null != detailPODataGridView.Rows[i].Cells["productName"].Value &&
                        null != detailPODataGridView.Rows[i].Cells["productID"].Value && gUtil.isProductIDExist(detailPODataGridView.Rows[i].Cells["productID"].Value.ToString()))
                    {
                        if (detailPODataGridView.Rows[i].Cells["productName"].Value.ToString() == productName)
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
                        detailQty[emptyRowIndex] = "0";
                        detailHpp[emptyRowIndex] = "0";
                        subtotalList[emptyRowIndex] = "0";
                        rowSelectedIndex = emptyRowIndex;
                    }
                    else
                    {
                        detailPODataGridView.Rows.Add();
                        detailQty.Add("0");
                        detailHpp.Add("0");
                        subtotalList.Add("0");
                        rowSelectedIndex = detailPODataGridView.Rows.Count - 1;
                    }
                }
            }

            DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];
            updateSomeRowContents(selectedRow, rowSelectedIndex, productID);

            if (!found)
            {
                selectedRow.Cells["qty"].Value = 1;
                detailQty[rowSelectedIndex] = "1";
                currQty = 1;
            }
            else
            {
                currQty = Convert.ToDouble(detailQty[rowSelectedIndex]) + 1;

                selectedRow.Cells["qty"].Value = currQty;
                detailQty[rowSelectedIndex] = currQty.ToString();
            }

            hpp = Convert.ToDouble(detailHpp[rowSelectedIndex]);

            subTotal = Math.Round((hpp * currQty), 2);
            selectedRow.Cells["subTotal"].Value = subTotal.ToString();
            subtotalList[rowSelectedIndex] = subTotal.ToString();

            calculateTotal();

            detailPODataGridView.CurrentCell = selectedRow.Cells["qty"];
            detailPODataGridView.AllowUserToAddRows = true;
            detailPODataGridView.Select();
            detailPODataGridView.BeginEdit(true);

            detailPODataGridView.Focus();
        }

        private void fillInSupplierCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT SUPPLIER_ID, SUPPLIER_FULL_NAME FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    supplierCombo.Items.Clear();
                    supplierHiddenCombo.Items.Clear();

                    while (rdr.Read())
                    {
                        supplierCombo.Items.Add(rdr.GetString("SUPPLIER_FULL_NAME"));
                        supplierHiddenCombo.Items.Add(rdr.GetString("SUPPLIER_ID"));
                    }
                }
            }
        }

        private bool isPOInvoiceExist()
        {
            bool result = false;

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM PURCHASE_HEADER WHERE PURCHASE_INVOICE = '"+ MySqlHelper.EscapeString(POinvoiceTextBox.Text)+"'")) > 0)
                result = true;

            return result;
        }

        private void addDataGridColumn()
        {
            DataGridViewTextBoxColumn productIDTextBox = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productNameTextBox = new DataGridViewTextBoxColumn();

            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn basePriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn displaySubTotalColumn = new DataGridViewTextBoxColumn();

            productIDTextBox.HeaderText = "KODE PRODUK";
            productIDTextBox.Name = "productID";
            productIDTextBox.Width = 200;
            productIDTextBox.DefaultCellStyle.BackColor = Color.LightBlue;
            detailPODataGridView.Columns.Add(productIDTextBox);

            productNameTextBox.HeaderText = "NAMA PRODUK";
            productNameTextBox.Name = "productName";
            productNameTextBox.Width = 300;
            productNameTextBox.ReadOnly = true;
            detailPODataGridView.Columns.Add(productNameTextBox);

            basePriceColumn.HeaderText = "HARGA POKOK";
            basePriceColumn.Name = "HPP";
            basePriceColumn.Width = 200;
            basePriceColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailPODataGridView.Columns.Add(basePriceColumn);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            stockQtyColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailPODataGridView.Columns.Add(stockQtyColumn);

            subTotalColumn.HeaderText = "SUBTOTAL";
            subTotalColumn.Name = "subTotal";
            subTotalColumn.Width = 200;
            subTotalColumn.ReadOnly = true;
            detailPODataGridView.Columns.Add(subTotalColumn);
            
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

        private void detailPODataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {           
            if ((detailPODataGridView.CurrentCell.OwningColumn.Name == "HPP" || detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                //textBox.TextChanged += TextBox_TextChanged;
                textBox.PreviewKeyDown -= TextBox_previewKeyDown;
                textBox.AutoCompleteMode = AutoCompleteMode.None;
            }

            if ((detailPODataGridView.CurrentCell.OwningColumn.Name == "productID") && e.Control is TextBox)
            {
                TextBox productIDTextBox = e.Control as TextBox;
                //productIDTextBox.TextChanged -= TextBox_TextChanged;
                productIDTextBox.PreviewKeyDown -= TextBox_previewKeyDown;
                productIDTextBox.PreviewKeyDown += TextBox_previewKeyDown;

                productIDTextBox.KeyUp -= Textbox_KeyUp;
                productIDTextBox.KeyUp += Textbox_KeyUp;

                productIDTextBox.CharacterCasing = CharacterCasing.Upper;
                productIDTextBox.AutoCompleteMode = AutoCompleteMode.None;
                //productIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //setTextBoxCustomSource(productIDTextBox);
            }

            if ((detailPODataGridView.CurrentCell.OwningColumn.Name == "productName") && e.Control is TextBox)
            {
                TextBox productIDTextBox = e.Control as TextBox;
                //productIDTextBox.TextChanged -= TextBox_TextChanged;
                productIDTextBox.PreviewKeyDown -= productName_previewKeyDown;
                productIDTextBox.PreviewKeyDown += productName_previewKeyDown;

                productIDTextBox.KeyUp -= Textbox_KeyUp;
                productIDTextBox.KeyUp += Textbox_KeyUp;

                productIDTextBox.CharacterCasing = CharacterCasing.Upper;
                productIDTextBox.AutoCompleteMode = AutoCompleteMode.None;
                //productIDTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //productIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //setTextBoxCustomSource(productIDTextBox);
            }
        }

        private double getHPPValue(string productID)
        {
            double result = 0;

            //DS.mySqlConnect();

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(PRODUCT_BASE_PRICE, 0) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void calculateTotal()
        {
            double total = 0;

            for (int i = 0; i < detailPODataGridView.Rows.Count-1; i++)
            {
                total = total + Convert.ToDouble(subtotalList[i]);
            }

            globalTotalValue = total;
            totalLabel.Text = total.ToString("C0", culture);
        }

        private void clearUpSomeRowContents(DataGridViewRow selectedRow, int rowSelectedIndex)
        {
            isLoading = true;
            selectedRow.Cells["productName"].Value = "";
            selectedRow.Cells["HPP"].Value = "0";
            detailHpp[rowSelectedIndex] = "0";
            selectedRow.Cells["subTotal"].Value = "0";
            subtotalList[rowSelectedIndex] = "0";
            selectedRow.Cells["qty"].Value = "0";
            detailQty[rowSelectedIndex] = "0";

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
                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "updateSomeRowsContent, PRODUCT_BASE_PRICE [" + hpp + "]");
                selectedRow.Cells["HPP"].Value = hpp;
                detailHpp[rowSelectedIndex] = hpp.ToString();

                selectedRow.Cells["qty"].Value = 0;
                detailQty[rowSelectedIndex] = "0";

                selectedRow.Cells["subTotal"].Value = 0;
                subtotalList[rowSelectedIndex] = "0";

                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "updateSomeRowsContent, attempt to calculate total");

                calculateTotal();
            }
            else
            {
                clearUpSomeRowContents(selectedRow, rowSelectedIndex);
            }
        }

        private void Textbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (forceUpOneLevel)
            {
                int pos = detailPODataGridView.CurrentCell.RowIndex;
                detailPODataGridView.CurrentCell = detailPODataGridView.Rows[pos - 1].Cells["qty"];
                forceUpOneLevel = false;
            }
        }

        private void TextBox_previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string currentValue = "";
            int rowSelectedIndex = 0;
            DataGridViewTextBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            if (detailPODataGridView.CurrentCell.OwningColumn.Name != "productID")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                currentValue = dataGridViewComboBoxEditingControl.Text;
                rowSelectedIndex = detailPODataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];

                if (currentValue.Length > 0)
                {
                    //updateSomeRowContents(selectedRow, rowSelectedIndex, currentValue);
                    //detailPODataGridView.CurrentCell = selectedRow.Cells["qty"];
                    // CALL DATA PRODUK FORM WITH PARAMETER 
                    dataProdukForm browseProduk = new dataProdukForm(globalConstants.NEW_PURCHASE_ORDER, this, currentValue, "", rowSelectedIndex);
                    browseProduk.ShowDialog(this);

                    forceUpOneLevel = true;
                }
                else
                {
                    //clearUpSomeRowContents(selectedRow, rowSelectedIndex);
                }
            }
        }

        private void productName_previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string currentValue = "";
            int rowSelectedIndex = 0;
            DataGridViewTextBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            if (detailPODataGridView.CurrentCell.OwningColumn.Name != "productName")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                currentValue = dataGridViewComboBoxEditingControl.Text;
                rowSelectedIndex = detailPODataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];

                if (currentValue.Length > 0)
                {
                    //updateSomeRowContents(selectedRow, rowSelectedIndex, currentValue, false);
                    //detailPODataGridView.CurrentCell = selectedRow.Cells["qty"];
                    // CALL DATA PRODUK FORM WITH PARAMETER 
                    dataProdukForm browseProduk = new dataProdukForm(globalConstants.NEW_PURCHASE_ORDER, this, "", currentValue, rowSelectedIndex);
                    browseProduk.ShowDialog(this);
                    forceUpOneLevel = true;
                }
                else
                {
                    //clearUpSomeRowContents(selectedRow, rowSelectedIndex);
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

            if (detailPODataGridView.CurrentCell.OwningColumn.Name != "HPP" && detailPODataGridView.CurrentCell.OwningColumn.Name != "qty")
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailPODataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];

            if (dataGridViewTextBoxEditingControl.Text.Length <= 0)
            {
                // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
                isLoading = true;
                // reset subTotal Value and recalculate total
                selectedRow.Cells["subtotal"].Value = 0;
                subtotalList[rowSelectedIndex] = "0";

                if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                    detailQty[rowSelectedIndex] = "0";
                else
                    detailHpp[rowSelectedIndex] = "0";

                dataGridViewTextBoxEditingControl.Text = "0";

                calculateTotal();

                dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;

                isLoading = false;
                return;
            }

            if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                previousInput = detailQty[rowSelectedIndex];
            else
                previousInput = detailHpp[rowSelectedIndex];

            isLoading = true;
            if (previousInput == "0")
            {
                tempString = dataGridViewTextBoxEditingControl.Text;
                if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
                    dataGridViewTextBoxEditingControl.Text = tempString.Remove(tempString.IndexOf('0'), 1);
            }

            if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                && (dataGridViewTextBoxEditingControl.Text.Length > 0))
            {
                if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                {
                    detailQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
                else
                {
                    detailHpp[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
            }
            else
            {
                dataGridViewTextBoxEditingControl.Text = previousInput;
            }

            hppValue = Convert.ToDouble(detailHpp[rowSelectedIndex]);
            productQty = Convert.ToDouble(detailQty[rowSelectedIndex]);
            subTotal = Math.Round((hppValue * productQty), 2);

            selectedRow.Cells["subtotal"].Value = subTotal.ToString();
            subtotalList[rowSelectedIndex] = subTotal.ToString();

            calculateTotal();

            dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;
            isLoading = false;
        }

        private bool isPOSent()
        {
            bool result = false;

            if (1 == Convert.ToInt32(DS.getDataSingleValue("SELECT PURCHASE_SENT FROM PURCHASE_HEADER WHERE ID = " + selectedPOID)))
                result = true;

            return result;
        }

        private void purchaseOrderDetailForm_Load(object sender, EventArgs e)
        {           
            int userAccessOption = 0;

            errorLabel.Text = "";
            durationTextBox.Enabled = false;

            fillInSupplierCombo();
            PODateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            addDataGridColumn();
            termOfPaymentCombo.SelectedIndex = 0;

            isLoading = true;

            loadDataHeader();
            loadDataDetail();

            isLoading = false;

            if (originModuleID != globalConstants.NEW_PURCHASE_ORDER && originModuleID!= globalConstants.PURCHASE_ORDER_DARI_RO)
            { 
                POinvoiceTextBox.ReadOnly = true;

                if (isPOSent())
                {
                    saveButton.Visible = false;
                    PODateTimePicker.Enabled = false;
                    supplierCombo.Enabled = false;
                    termOfPaymentCombo.Enabled = false;
                    durationTextBox.ReadOnly = true;
                    detailPODataGridView.ReadOnly = true;
                    detailPODataGridView.AllowUserToAddRows = false;
                }

            }
            else
            {
                // NEW PO
                generateButton.Visible = false;
            }

            detailPODataGridView.EditingControlShowing += detailPODataGridView_EditingControlShowing;

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_PURCHASE_ORDER, gUtil.getUserGroupID());

            if (originModuleID == globalConstants.NEW_PURCHASE_ORDER || originModuleID == globalConstants.PURCHASE_ORDER_DARI_RO)
            {
                if (userAccessOption != 2 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }
            else if (originModuleID == globalConstants.EDIT_PURCHASE_ORDER)
            {
                if (userAccessOption != 4 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }

            arrButton[0] = saveButton;
            arrButton[1] = generateButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);

            detailHpp.Add("0");
            detailQty.Add("0");
            subtotalList.Add("0");
        }

        private void POinvoiceTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (isPOInvoiceExist())
            {
                errorLabel.Text = "NO PO SUDAH ADA";
            }
            else
            {
                errorLabel.Text = "";
            }
        }

        private bool dataValidated()
        {
            bool dataExist = true;
            int i = 0;

            if (POinvoiceTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NO PURCHASE TIDAK BOLEH KOSONG";
                return false;
            }

            if (globalTotalValue <= 0)
            {
                errorLabel.Text = "NILAI PURCHASE KOSONG";
                return false;
            }

            if (detailPODataGridView.Rows.Count <= 0)
            {
                errorLabel.Text = "TIDAK ADA PRODUCT YANG DIPILIH";
                return false;
            }

            //for (i = 0; i < detailPODataGridView.Rows.Count && dataExist; i++)
            //{
            //    if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
            //        dataExist = gUtil.isProductIDExist(detailPODataGridView.Rows[i].Cells["productID"].Value.ToString());
            //    else
            //        dataExist = false;
            //}
            //if (!dataExist)
            //{
            //    errorLabel.Text = "PRODUCT ID PADA BARIS [" + i + "] INVALID";
            //    return false;
            //}

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string POInvoice = "0";
            string roInvoice = "";
            int supplierID = 0;
            string PODateTime = "";
            //string PODueDateTime = "";
            double POTotal = 0;
            int termOfPaymentDuration = 0;
            int termOfPayment;
            int purchasePaid = 0;
            DateTime selectedPODate;
            //DateTime PODueDate;
            MySqlException internalEX = null;

            double currentTaxTotal = 0;
            double currentPurchaseTotal = 0;
            double taxLimitValue = 0;
            double parameterCalculation = 0;
            int taxLimitType = 0; // 0 - percentage, 1 - amount
            string purchaseDateValue = "";
            bool addToTaxTable = false;

            roInvoice = selectedROInvoice; //ROInvoiceTextBox.Text;
            POInvoice = POinvoiceTextBox.Text;
            supplierID = selectedSupplierID;

            selectedPODate = PODateTimePicker.Value;
            PODateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedPODate);

            termOfPayment = termOfPaymentCombo.SelectedIndex;
            termOfPaymentDuration = Convert.ToInt32(durationTextBox.Text);
            //PODueDate = selectedPODate.AddDays(termOfPaymentDuration);
            //PODueDateTime = String.Format(culture, "{0:dd-MM-yyyy}", PODueDate);

            if (termOfPayment == 0)
                purchasePaid = 1;

            POTotal = globalTotalValue;


            // TAX LIMIT CALCULATION
            // ----------------------------------------------------------------------
            purchaseDateValue = String.Format(culture, "{0:yyyyMMdd}", DateTime.Now);
            currentTaxTotal = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PURCHASE_TOTAL), 0) AS TOTAL FROM PURCHASE_HEADER_TAX WHERE DATE_FORMAT(PURCHASE_DATETIME, '%Y%m%d') = '" + purchaseDateValue + "'"));
            currentPurchaseTotal = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PURCHASE_TOTAL), 0) AS TOTAL FROM PURCHASE_HEADER WHERE DATE_FORMAT(PURCHASE_DATETIME, '%Y%m%d') = '" + purchaseDateValue + "'"));

            // CHECK WHETHER THE PARAMETER FOR TAX CALCULATION HAS BEEN SET
            taxLimitValue = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(PERSENTASE_PEMBELIAN, 0) FROM SYS_CONFIG_TAX WHERE ID = 1"));
            gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "CHECK IF TAX LIMIT SET FOR PERCENTAGE PURCHASE [" + taxLimitValue + "]");

            if (taxLimitValue == 0)
            {
                taxLimitType = 1;
                taxLimitValue = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(AVERAGE_PEMBELIAN_HARIAN, 0) FROM SYS_CONFIG_TAX WHERE ID = 1"));
                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "CHECK IF TAX LIMIT SET FOR AVERAGE DAILY PURCHASE [" + taxLimitValue + "]");

                if (taxLimitValue != 0)
                    addToTaxTable = true;
            }
            else
                addToTaxTable = true;

            // CHECK WHETHER THE PARAMETER HAS BEEN FULFILLED
            if (addToTaxTable)
            {
                if (taxLimitType == 0) // PERCENTAGE CALCULATION
                {
                    parameterCalculation = currentPurchaseTotal * taxLimitValue / 100;
                    gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "PERCENTAGE CALCULATION [" + parameterCalculation + "]");

                    if (currentTaxTotal > parameterCalculation)
                    { 
                        addToTaxTable = false;
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "CURRENT TAX TOTAL IS BIGGER THAN PARAMETER CALCULATION");
                    }
                }
                else // AMOUNT CALCULATION
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "AMOUNT CALCULATION [" + taxLimitValue + "]");
                    if (currentTaxTotal > taxLimitValue)
                    { 
                        addToTaxTable = false;
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "CURRENT TAX TOTAL IS BIGGER THAN AMOUNT CALCULATION");
                    }
                }
            }
            // ----------------------------------------------------------------------

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.PURCHASE_ORDER_DARI_RO:
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "PURCHASE HEADER FROM REQUEST ORDER");
                        // SAVE HEADER TABLE
                        sqlCommand = "INSERT INTO PURCHASE_HEADER (PURCHASE_INVOICE, SUPPLIER_ID, PURCHASE_DATETIME, PURCHASE_TOTAL, PURCHASE_TERM_OF_PAYMENT, PURCHASE_TERM_OF_PAYMENT_DURATION, PURCHASE_PAID) VALUES " +
                                            "('" + POInvoice + "', " + supplierID + ", STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(POTotal) + ", " + termOfPayment + ", " + termOfPaymentDuration + ", '" + purchasePaid + ")";

                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT PURCHASE HEADER DATA ["+ POInvoice + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        if (addToTaxTable)
                        {
                            sqlCommand = "INSERT INTO PURCHASE_HEADER_TAX (PURCHASE_INVOICE, SUPPLIER_ID, PURCHASE_DATETIME, PURCHASE_TOTAL, PURCHASE_TERM_OF_PAYMENT, PURCHASE_TERM_OF_PAYMENT_DURATION, PURCHASE_PAID) VALUES " +
                                                "('" + POInvoice + "', " + supplierID + ", STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(POTotal) + ", " + termOfPayment + ", " + termOfPaymentDuration + ", '" + purchasePaid + ")";

                            gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT PURCHASE HEADER TAX DATA [" + POInvoice + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailPODataGridView.Rows.Count-1; i++)
                        {
                            if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                            { 
                                sqlCommand = "INSERT INTO PURCHASE_DETAIL (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                    "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT DETAIL PURCHASE DATA [" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + "]");
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;

                                if (addToTaxTable)
                                {
                                    sqlCommand = "INSERT INTO PURCHASE_DETAIL_TAX (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                        "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                    gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT DETAIL PURCHASE DATA TAX");
                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }

                            }
                        }

                        // UPDATE REQUEST ORDER TABLE
                        sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET RO_ACTIVE = 0 WHERE RO_INVOICE = '" + roInvoice + "'";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "UPDATE REQUEST ORDER DATA IF COMES FROM REQUEST ORDER");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        break;

                    case globalConstants.NEW_PURCHASE_ORDER:
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "NEW PURCHASE HEADER");
                        // SAVE HEADER TABLE
                        sqlCommand = "INSERT INTO PURCHASE_HEADER (PURCHASE_INVOICE, SUPPLIER_ID, PURCHASE_DATETIME, PURCHASE_TOTAL, PURCHASE_TERM_OF_PAYMENT, PURCHASE_TERM_OF_PAYMENT_DURATION, PURCHASE_PAID) VALUES " +
                                            "('" + POInvoice + "', " + supplierID + ", STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(POTotal) + ", " + termOfPayment + ", " + termOfPaymentDuration + ", " + purchasePaid + ")";

                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT PURCHASE HEADER DATA ["+ POInvoice + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        if (addToTaxTable)
                        {
                            sqlCommand = "INSERT INTO PURCHASE_HEADER_TAX (PURCHASE_INVOICE, SUPPLIER_ID, PURCHASE_DATETIME, PURCHASE_TOTAL, PURCHASE_TERM_OF_PAYMENT, PURCHASE_TERM_OF_PAYMENT_DURATION, PURCHASE_PAID) VALUES " +
                                                "('" + POInvoice + "', " + supplierID + ", STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " + gUtil.validateDecimalNumericInput(POTotal) + ", " + termOfPayment + ", " + termOfPaymentDuration + ", " + purchasePaid + ")";
                            gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT PURCHASE HEADER TAX DATA [" + POInvoice + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailPODataGridView.Rows.Count-1; i++)
                        {
                            if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO PURCHASE_DETAIL (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                    "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT DETAIL PURCHASE DATA [" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + "]");
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;

                                if (addToTaxTable)
                                {
                                    sqlCommand = "INSERT INTO PURCHASE_DETAIL_TAX (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                        "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";

                                    gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT DETAIL PURCHASE TAX DATA");
                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }
                            }
                        }

                        break;

                    case globalConstants.EDIT_PURCHASE_ORDER:
                        // SAVE HEADER TABLE
                        sqlCommand = "UPDATE PURCHASE_HEADER " +
                                            "SET SUPPLIER_ID = " + supplierID + ", " +
                                            "PURCHASE_DATETIME = STR_TO_DATE('" + PODateTime + "', '%d-%m-%Y'), " +
                                            "PURCHASE_TOTAL = " + gUtil.validateDecimalNumericInput(POTotal) + ", " +
                                            "PURCHASE_TERM_OF_PAYMENT = " + termOfPayment + ", " + 
                                            "PURCHASE_TERM_OF_PAYMENT_DURATION = " + termOfPaymentDuration + ", " +
                                            "PURCHASE_PAID = " + purchasePaid +" " +
                                            "WHERE PURCHASE_INVOICE = '" +POInvoice+ "'";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "UPDATE PURCHASE HEADER DATA [" + POInvoice + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // DELETE DETAIL TABLE
                        sqlCommand = "DELETE FROM PURCHASE_DETAIL WHERE PURCHASE_INVOICE = '" + POInvoice + "'";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "DELETE PURCHASE DETAIL DATA IN ORDER TO UPDATE DETAIL DATA");

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // RE-INSERT DETAIL TABLE
                        for (int i = 0; i < detailPODataGridView.Rows.Count-1; i++)
                        {
                            if (null != detailPODataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO PURCHASE_DETAIL (PURCHASE_INVOICE, PRODUCT_ID, PRODUCT_PRICE, PRODUCT_QTY, PURCHASE_SUBTOTAL) VALUES " +
                                                    "('" + POInvoice + "', '" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + ", " + gUtil.validateDecimalNumericInput(Convert.ToDouble(detailPODataGridView.Rows[i].Cells["subTotal"].Value)) + ")";
                                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "INSERT DETAIL PURCHASE DATA [" + detailPODataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailPODataGridView.Rows[i].Cells["qty"].Value) + "]");
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        }

                        break;

                    case globalConstants.PRINTOUT_PURCHASE_ORDER:
                        // UPDATE PURCHASE ORDER TABLE
                        sqlCommand = "UPDATE PURCHASE_HEADER SET PURCHASE_SENT = 1 WHERE PURCHASE_INVOICE = '" + POInvoice + "'";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "UPDATE PURCHASE HEADER DATA TO INDICATE PO HAS BEEN PRINTED OUT, THEREFORE UNEDITABLE");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        //ATTEMPT TO UPDATE TAX TABLE
                        sqlCommand = "UPDATE PURCHASE_HEADER_TAX SET PURCHASE_SENT = 1 WHERE PURCHASE_INVOICE = '" + POInvoice + "'";
                        gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "UPDATE FLAG AT PURCHASE HEADER TAX");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;
                        break;
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "EXCEPTION THROWN ["+e.Message+"]");
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

                result  = saveDataTransaction();

                pleaseWait.Close();

                return result;
            }

            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "ATTEMPT TO SAVE DATA");
            if (saveData())
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "PURCHASE ORDER SAVED");
                switch (originModuleID)
                {
                    case globalConstants.NEW_PURCHASE_ORDER:
                        gUtil.saveUserChangeLog(globalConstants.MENU_PURCHASE_ORDER, globalConstants.CHANGE_LOG_INSERT, "CREATE NEW PURCHASE ORDER [" + POinvoiceTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_PURCHASE_ORDER:
                        gUtil.saveUserChangeLog(globalConstants.MENU_PURCHASE_ORDER, globalConstants.CHANGE_LOG_UPDATE, "UPDATE PURCHASE ORDER [" + POinvoiceTextBox.Text + "]");
                        break;
                }

                errorLabel.Text = "";
                generateButton.Visible = true;

                saveButton.Visible = false;
                PODateTimePicker.Enabled = false;
                supplierCombo.Enabled = false;
                termOfPaymentCombo.Enabled = false;
                durationTextBox.ReadOnly = true;
                detailPODataGridView.ReadOnly = true;
                detailPODataGridView.AllowUserToAddRows = false;

                gUtil.showSuccess(gUtil.INS);
                gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);
            }
        }

        private void loadDataPOHeader()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            
            sqlCommand = "SELECT ID, PURCHASE_INVOICE, PURCHASE_DATETIME, " +
                                "PURCHASE_TERM_OF_PAYMENT, " +
                                "PURCHASE_TERM_OF_PAYMENT_DURATION, " +
                                "M.SUPPLIER_FULL_NAME, PURCHASE_TOTAL " + //IFNULL(RO_INVOICE,'') AS RO_INVOICE " +
                                "FROM PURCHASE_HEADER P, MASTER_SUPPLIER M " +
                                "WHERE P.SUPPLIER_ID = M.SUPPLIER_ID AND P.ID = " + selectedPOID;

            using (rdr=DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        POinvoiceTextBox.Text = rdr.GetString("PURCHASE_INVOICE");
                        PODateTimePicker.Value = rdr.GetDateTime("PURCHASE_DATETIME");

                        supplierCombo.Text = rdr.GetString("SUPPLIER_FULL_NAME");
                        termOfPaymentCombo.SelectedIndex = rdr.GetInt32("PURCHASE_TERM_OF_PAYMENT");
                        durationTextBox.Text = rdr.GetString("PURCHASE_TERM_OF_PAYMENT_DURATION");//Convert.ToInt32((rdr.GetDateTime("PURCHASE_TERM_OF_PAYMENT_DATE") - rdr.GetDateTime("PURCHASE_DATETIME")).TotalDays).ToString();
                        totalLabel.Text = rdr.GetString("PURCHASE_TOTAL");
                        globalTotalValue = rdr.GetDouble("PURCHASE_TOTAL");

                        if (rdr.GetInt32("PURCHASE_TERM_OF_PAYMENT") == 1)
                            durationTextBox.Enabled = true;
                    }
                }
            }
        }

        private void loadDataHeader()
        {
            switch (originModuleID)
            {
                case globalConstants.PURCHASE_ORDER_DARI_RO:
        //            ROInvoiceTextBox.Text = selectedROInvoice;
                    break;

                case globalConstants.EDIT_PURCHASE_ORDER:
                    loadDataPOHeader();
                    break;
            }
        }

        private void loadDataRODetail()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT RO.*, M.PRODUCT_NAME FROM REQUEST_ORDER_DETAIL RO, MASTER_PRODUCT M WHERE RO_INVOICE = '" + selectedROInvoice + "' AND RO.PRODUCT_ID = M.PRODUCT_ID";
            
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while(rdr.Read())
                    {
                        detailPODataGridView.Rows.Add(rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("RO_QTY"), rdr.GetString("RO_SUBTOTAL"));
                        detailHpp[detailPODataGridView.Rows.Count - 2] = rdr.GetString("PRODUCT_BASE_PRICE");
                        detailQty[detailPODataGridView.Rows.Count - 2] = rdr.GetString("RO_QTY");
                        subtotalList[detailPODataGridView.Rows.Count - 2] = rdr.GetString("RO_SUBTOTAL");
                    }

                    calculateTotal();
                }
            }

        }

        private void loadDataPODetail()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT PO.*, M.PRODUCT_NAME FROM PURCHASE_DETAIL PO, MASTER_PRODUCT M WHERE PURCHASE_INVOICE = '" + POinvoiceTextBox.Text + "' AND PO.PRODUCT_ID = M.PRODUCT_ID";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        detailPODataGridView.Rows.Add(rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_PRICE"), rdr.GetString("PRODUCT_QTY"), rdr.GetString("PURCHASE_SUBTOTAL"));
                        detailHpp[detailPODataGridView.Rows.Count - 2] = rdr.GetString("PRODUCT_PRICE");
                        detailQty[detailPODataGridView.Rows.Count - 2] = rdr.GetString("PRODUCT_QTY");
                        subtotalList[detailPODataGridView.Rows.Count - 2] = rdr.GetString("PURCHASE_SUBTOTAL");
                    }

                    calculateTotal();
                }
            }
        }

        private void loadDataDetail()
        {
            switch (originModuleID)
            {
                case globalConstants.PURCHASE_ORDER_DARI_RO:
                    loadDataRODetail();
                    break;

                case globalConstants.EDIT_PURCHASE_ORDER:
                    loadDataPODetail();
                    break;
            }
        }

        private void deleteCurrentRow()
        {
            if (detailPODataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailPODataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];
                detailPODataGridView.CurrentCell = selectedRow.Cells["productName"];

                if (null != selectedRow && rowSelectedIndex != detailPODataGridView.Rows.Count - 1)
                {
                    for (int i = rowSelectedIndex; i < detailPODataGridView.Rows.Count - 1; i++)
                    {
                        detailQty[i] = detailQty[i + 1];
                        detailHpp[i] = detailHpp[i + 1];
                        subtotalList[i] = subtotalList[i + 1];
                    }

                    isLoading = true;
                    detailPODataGridView.Rows.Remove(selectedRow);
                    gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "deleteCurrentRow [" + rowSelectedIndex + "]");
                    isLoading = false;
                }
            }
        }

        private void supplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSupplierID = Convert.ToInt32(supplierHiddenCombo.Items[supplierCombo.SelectedIndex]);
        }

        private void printOutPurchaseOrder()
        {
            string PONo = POinvoiceTextBox.Text;

            string sqlCommandx = "SELECT PH.PURCHASE_DATETIME AS 'TGL', PH.PURCHASE_DATE_RECEIVED AS 'TERIMA', PH.PURCHASE_INVOICE AS 'INVOICE', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', MP.PRODUCT_NAME AS 'PRODUK', PD.PRODUCT_PRICE AS 'HARGA', PD.PRODUCT_QTY AS 'QTY', PD.PURCHASE_SUBTOTAL AS 'SUBTOTAL' " +
                                        "FROM PURCHASE_HEADER PH, PURCHASE_DETAIL PD, MASTER_SUPPLIER MS, MASTER_PRODUCT MP " +
                                        "WHERE PH.PURCHASE_INVOICE = '" + PONo + "' AND PH.SUPPLIER_ID = MS.SUPPLIER_ID AND PD.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PD.PRODUCT_ID = MP.PRODUCT_ID";

            DS.writeXML(sqlCommandx, globalConstants.purchaseOrderXML);
            purchaseOrderPrintOutForm displayForm = new purchaseOrderPrintOutForm();
            displayForm.ShowDialog(this);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            originModuleID = globalConstants.PRINTOUT_PURCHASE_ORDER;

            if (saveData())
            {
                gUtil.saveUserChangeLog(globalConstants.MENU_PURCHASE_ORDER, globalConstants.CHANGE_LOG_INSERT, "PRINT OUT PURCHASE ORDER [" + POinvoiceTextBox.Text + "]");

                saveButton.Visible = false;
                POinvoiceTextBox.ReadOnly = true;
                PODateTimePicker.Enabled = false;
                supplierCombo.Enabled = false;
                termOfPaymentCombo.Enabled = false;
                durationTextBox.ReadOnly = true;
                detailPODataGridView.ReadOnly = true;
                detailPODataGridView.AllowUserToAddRows = false;

                printOutPurchaseOrder();

                gUtil.showSuccess(gUtil.INS);
            }
        }

        private void supplierCombo_Validated(object sender, EventArgs e)
        {
            if (!supplierCombo.Items.Contains(supplierCombo.Text))
                supplierCombo.Focus();
        }

        private void termOfPaymentCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (termOfPaymentCombo.SelectedIndex == 0)
                durationTextBox.Enabled = false;
            else
                durationTextBox.Enabled = true;
        }

        private void detailPODataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            detailQty.Add("0");
            detailHpp.Add("0");
            subtotalList.Add("0");
        }

        private void durationTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                durationTextBox.SelectAll();
            });
        }

        private void purchaseOrderDetailForm_Activated(object sender, EventArgs e)
        {
            registerGlobalHotkey();

            if (detailPODataGridView.Focused)
                registerDelKey();
        }

        private void purchaseOrderDetailForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();

            if (delKeyRegistered)
                unregisterDelKey();
        }

        private void detailPODataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (
              (detailPODataGridView.Columns[e.ColumnIndex].Name == "qty" ||
              detailPODataGridView.Columns[e.ColumnIndex].Name == "HPP" ||
              detailPODataGridView.Columns[e.ColumnIndex].Name == "subTotal")
             && e.RowIndex != this.detailPODataGridView.NewRowIndex && null != e.Value)
            {
                isLoading = true;
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString(globalUtilities.CELL_FORMATTING_NUMERIC_FORMAT);
                isLoading = false;
            }
        }

        private void detailPODataGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterNavigationKey();

            registerDelKey();
        }

        private void detailPODataGridView_Leave(object sender, EventArgs e)
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

        private void detailPODataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            detailPODataGridView.SuspendLayout();

            if (navKeyRegistered)
            {
                unregisterNavigationKey();
            }

            if (!delKeyRegistered)
                registerDelKey();
        }

        private void detailPODataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            detailPODataGridView.ResumeLayout();
        }

        private void detailPODataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var cell = detailPODataGridView[e.ColumnIndex, e.RowIndex];
            int rowSelectedIndex = 0;

            double subTotal = 0;
            double productQty = 0;
            double hppValue = 0;
            string tempString;
            string cellValue = "";
            string columnName = "";

            columnName = cell.OwningColumn.Name;
            gUtil.saveSystemDebugLog(globalConstants.MENU_PURCHASE_ORDER, "PURCHASE ORDER : detailPODataGridView_CellValueChanged [" + columnName + "]");

            rowSelectedIndex = e.RowIndex;
            DataGridViewRow selectedRow = detailPODataGridView.Rows[rowSelectedIndex];

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
            else if (columnName == "HPP" && columnName == "qty")
            {
                if (cellValue.Length <= 0)
                {
                    // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
                    // reset subTotal Value and recalculate total
                    selectedRow.Cells["subtotal"].Value = 0;
                    subtotalList[rowSelectedIndex] = "0";

                    if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                        detailQty[rowSelectedIndex] = "0";
                    else
                        detailHpp[rowSelectedIndex] = "0";

                    selectedRow.Cells[columnName].Value = "0";

                    calculateTotal();

                    return;
                }

                if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                    previousInput = detailQty[rowSelectedIndex];
                else
                    previousInput = detailHpp[rowSelectedIndex];

                isLoading = true;
                if (previousInput == "0")
                {
                    tempString = cellValue;
                    if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
                        selectedRow.Cells[columnName].Value = tempString.Remove(tempString.IndexOf('0'), 1);
                }

                if (gUtil.matchRegEx(cellValue, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (cellValue.Length > 0))
                {
                    if (detailPODataGridView.CurrentCell.OwningColumn.Name == "qty")
                    {
                        detailQty[rowSelectedIndex] = cellValue;
                    }
                    else
                    {
                        detailHpp[rowSelectedIndex] = cellValue;
                    }
                }
                else
                {
                    selectedRow.Cells[columnName].Value = previousInput;
                }

                hppValue = Convert.ToDouble(detailHpp[rowSelectedIndex]);
                productQty = Convert.ToDouble(detailQty[rowSelectedIndex]);
                subTotal = Math.Round((hppValue * productQty), 2);

                selectedRow.Cells["subtotal"].Value = subTotal.ToString();
                subtotalList[rowSelectedIndex] = subTotal.ToString();

                calculateTotal();
            }
        }

        private void detailPODataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (detailPODataGridView.IsCurrentCellDirty)
            {
                detailPODataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
