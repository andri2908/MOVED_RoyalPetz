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
    public partial class dataReturPermintaanForm : Form
    {
        private int selectedSupplierID = 0;
        private double globalTotalValue = 0;
        private string previousInput = "";
        private int originModuleID = 0;
        private bool isLoading = false;

        private List<string> detailQty = new List<string>();
        private List<string> productPriceList = new List<string>();
        private List<string> subtotalList = new List<string>();

        private CultureInfo culture = new CultureInfo("id-ID");

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
        private globalUtilities GUTIL = new globalUtilities();
        private bool navKeyRegistered = false;
        private bool delKeyRegistered = false;

        barcodeForm displayBarcodeForm = null;
        dataProdukForm browseProdukForm = null;

        public dataReturPermintaanForm()
        {
            InitializeComponent();
        }

        public dataReturPermintaanForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void fillInSupplierCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT SUPPLIER_ID, SUPPLIER_FULL_NAME FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1";

            supplierCombo.Items.Clear();
            supplierHiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        supplierCombo.Items.Add(rdr.GetString("SUPPLIER_FULL_NAME"));
                        supplierHiddenCombo.Items.Add(rdr.GetString("SUPPLIER_ID"));
                    }
                }
            }
        }

        private void addColumnToDataGrid()
        {
            //MySqlDataReader rdr;
            //string sqlCommand = "";

            //DataGridViewComboBoxColumn productIdCmb = new DataGridViewComboBoxColumn();
            //DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();

            DataGridViewTextBoxColumn productIDColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();

            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn basePriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();

            //sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND (PRODUCT_STOCK_QTY - PRODUCT_LIMIT_STOCK > 0) ORDER BY PRODUCT_NAME ASC";

            ////productIDComboHidden.Items.Clear();
            ////productNameComboHidden.Items.Clear();

            //using (rdr = DS.getData(sqlCommand))
            //{
            //    while (rdr.Read())
            //    {
            //        productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
            //        productIdCmb.Items.Add(rdr.GetString("PRODUCT_ID"));
            //        //productIDComboHidden.Items.Add(rdr.GetString("PRODUCT_ID"));
            //        //productNameComboHidden.Items.Add(rdr.GetString("PRODUCT_NAME"));
            //    }
            //}

            //rdr.Close();

            productIDColumn.HeaderText = "KODE PRODUK";
            productIDColumn.Name = "productID";
            productIDColumn.Width = 200;
            productIDColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailReturDataGridView.Columns.Add(productIDColumn);

            productNameColumn.HeaderText = "NAMA PRODUK";
            productNameColumn.Name = "productName";
            productNameColumn.Width = 300;
            productNameColumn.ReadOnly = true;
            detailReturDataGridView.Columns.Add(productNameColumn);

            basePriceColumn.HeaderText = "HARGA POKOK";
            basePriceColumn.Name = "HPP";
            basePriceColumn.Width = 200;
            basePriceColumn.ReadOnly = true;
            detailReturDataGridView.Columns.Add(basePriceColumn);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            stockQtyColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailReturDataGridView.Columns.Add(stockQtyColumn);

            subTotalColumn.HeaderText = "SUBTOTAL";
            subTotalColumn.Name = "subTotal";
            subTotalColumn.Width = 200;
            subTotalColumn.ReadOnly = true;
            detailReturDataGridView.Columns.Add(subTotalColumn);

            descriptionColumn.HeaderText = "DESKRIPSI";
            descriptionColumn.Name = "description";
            descriptionColumn.Width = 200;
            descriptionColumn.MaxInputLength = 100;
            descriptionColumn.DefaultCellStyle.BackColor = Color.LightBlue;
            detailReturDataGridView.Columns.Add(descriptionColumn);

            detailQty.Add("0");
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
                        ReturDtPicker_1.Focus();

                        if (null == displayBarcodeForm || displayBarcodeForm.IsDisposed)
                        {
                            displayBarcodeForm = new barcodeForm(this, globalConstants.RETUR_PEMBELIAN);

                            displayBarcodeForm.Top = this.Top + 5;
                            displayBarcodeForm.Left = this.Left + 5;//(Screen.PrimaryScreen.Bounds.Width / 2) - (displayBarcodeForm.Width / 2);
                        }

                        displayBarcodeForm.Show();
                        displayBarcodeForm.WindowState = FormWindowState.Normal;
                    //detailReturDataGridView.Focus();
                    break;

                case Keys.F8:
                        detailReturDataGridView.Focus();
                        addNewRow();
                    break;

                case Keys.F9:
                        saveAndPrintButton.PerformClick();
                    break;

                case Keys.F11:
                        ReturDtPicker_1.Focus();

                        if (null == browseProdukForm || browseProdukForm.IsDisposed)
                            browseProdukForm = new dataProdukForm(originModuleID, this);

                        browseProdukForm.Show();
                        browseProdukForm.WindowState = FormWindowState.Normal;
                        //detailReturDataGridView.Focus();
                    break;

                case Keys.Delete:
                    if (detailReturDataGridView.ReadOnly == false)
                    {
                            if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?", "WARNING", MessageBoxButtons.YesNo))
                            {
                                deleteCurrentRow();
                                calculateTotal();
                            }
                    }
                    break;
            }
        }

        private void captureCtrlModifier(Keys key)
        {
            switch (key)
            {
                case Keys.Delete: // CTRL + DELETE
                    if (detailReturDataGridView.ReadOnly == false)
                    {
                        if (DialogResult.Yes == MessageBox.Show("DELETE CURRENT ROW?", "WARNING", MessageBoxButtons.YesNo))
                        {
                            deleteCurrentRow();
                            calculateTotal();
                        }
                    }
                    break;

                case Keys.Enter: // CTRL + ENTER
                        saveAndPrintButton.PerformClick();
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
            //ghk_F8.Unregister();
            ghk_F9.Unregister();
            ghk_F11.Unregister();

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

            for (int i = 0; i < detailReturDataGridView.Rows.Count && allowToAdd; i++)
            {
                if (null != detailReturDataGridView.Rows[i].Cells["productID"].Value)
                {
                    if (!GUTIL.isProductIDExist(detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString()))
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
                detailReturDataGridView.Rows.Add();
                detailQty.Add("0");
                newRowIndex = detailReturDataGridView.Rows.Count - 1;
            }
            else
            {
                DataGridViewRow selectedRow = detailReturDataGridView.Rows[newRowIndex];
                clearUpSomeRowContents(selectedRow, newRowIndex);
            }

            detailReturDataGridView.CurrentCell = detailReturDataGridView.Rows[newRowIndex].Cells["productID"];
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

            if (detailReturDataGridView.ReadOnly == true)
                return;

            detailReturDataGridView.Focus();

            // CHECK FOR EXISTING SELECTED ITEM
            for (i = 0; i < detailReturDataGridView.Rows.Count && !found && !foundEmptyRow; i++)
            {
                if (
                    null != detailReturDataGridView.Rows[i].Cells["productName"].Value && 
                    null != detailReturDataGridView.Rows[i].Cells["productID"].Value 
                    && GUTIL.isProductIDExist(detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString())
                    )               
               {
                    if (detailReturDataGridView.Rows[i].Cells["productName"].Value.ToString() == productName)
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
                    rowSelectedIndex = emptyRowIndex;
                }
                else
                {
                    detailReturDataGridView.Rows.Add();
                    detailQty.Add("0");
                    rowSelectedIndex = detailReturDataGridView.Rows.Count - 1;
                }
            }

            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];
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

            hpp = Convert.ToDouble(selectedRow.Cells["HPP"].Value);

            subTotal = Math.Round((hpp * currQty), 2);
            selectedRow.Cells["subTotal"].Value = subTotal;
            subtotalList[rowSelectedIndex] = subTotal.ToString();

            calculateTotal();

            detailReturDataGridView.CurrentCell = selectedRow.Cells["qty"];
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

            for (int i = 0; i < detailReturDataGridView.Rows.Count-1; i++)
            {
                total = total + Convert.ToDouble(subtotalList[i]);
            }

            globalTotalValue = total;
            totalLabel.Text = total.ToString("C0", culture);//"Rp. " + total.ToString();
        }

        private void setTextBoxCustomSource(TextBox textBox)
        {
            MySqlDataReader rdr;
            string sqlCommand = "";
            string[] arr = null;
            List<string> arrList = new List<string>();

            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND (PRODUCT_STOCK_QTY - PRODUCT_LIMIT_STOCK > 0) ORDER BY PRODUCT_NAME ASC";

            rdr = DS.getData(sqlCommand);

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    arrList.Add(rdr.GetString("PRODUCT_ID"));
                }
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                arr = arrList.ToArray();
                collection.AddRange(arr);

                textBox.AutoCompleteCustomSource = collection;
            }

            rdr.Close();
        }

        private void detailReturDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailReturDataGridView.CurrentCell.OwningColumn.Name == "productID") && e.Control is TextBox)
            {
                TextBox productIDTextBox = e.Control as TextBox;
                productIDTextBox.TextChanged -= TextBox_TextChanged;
                productIDTextBox.PreviewKeyDown += TextBox_previewKeyDown;
                productIDTextBox.CharacterCasing = CharacterCasing.Upper;
                productIDTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                productIDTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                setTextBoxCustomSource(productIDTextBox);
            }

            if (detailReturDataGridView.CurrentCell.OwningColumn.Name == "qty" && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
                textBox.PreviewKeyDown -= TextBox_previewKeyDown;
                textBox.AutoCompleteMode = AutoCompleteMode.None;
            }
        }

        private void clearUpSomeRowContents(DataGridViewRow selectedRow, int rowSelectedIndex)
        {
            isLoading = true;
            selectedRow.Cells["productName"].Value = "";
            selectedRow.Cells["hpp"].Value = "0";
            productPriceList[rowSelectedIndex] = "0";
            selectedRow.Cells["subTotal"].Value = "0";
            subtotalList[rowSelectedIndex] = "0";
            selectedRow.Cells["qty"].Value = "0";
            detailQty[rowSelectedIndex] = "0";

            calculateTotal();
            isLoading = false;
        }

        private void updateSomeRowContents(DataGridViewRow selectedRow, int rowSelectedIndex, string currentValue)
        {
            int numRow = 0;
            string selectedProductID = "";
            string selectedProductName = "";

            double hpp = 0;
            string currentProductID = "";
            string currentProductName = "";
            bool changed = false;

            numRow = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'"));

            if (numRow > 0)
            {
                selectedProductID = currentValue;

                if (null != selectedRow.Cells["productID"].Value)
                    currentProductID = selectedRow.Cells["productID"].Value.ToString();

                if (null != selectedRow.Cells["productName"].Value)
                    currentProductName = selectedRow.Cells["productName"].Value.ToString();

                selectedProductName = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_NAME,'') FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'").ToString();

                selectedRow.Cells["productId"].Value = selectedProductID;
                selectedRow.Cells["productName"].Value = selectedProductName;

                if (selectedProductID != currentProductID)
                    changed = true;

                if (selectedProductName != currentProductName)
                    changed = true;

                if (!changed)
                    return;

                hpp = getHPPValue(selectedProductID);
                GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PERMINTAAN, "updateSomeRowsContent, PRODUCT_BASE_PRICE [" + hpp + "]");
                selectedRow.Cells["hpp"].Value = hpp.ToString();
                productPriceList[rowSelectedIndex] = hpp.ToString();

                selectedRow.Cells["qty"].Value = 0;
                detailQty[rowSelectedIndex] = "0";

                selectedRow.Cells["subTotal"].Value = 0;
                subtotalList[rowSelectedIndex] = "0";

                GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PERMINTAAN, "updateSomeRowsContent, attempt to calculate total");

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

            if (detailReturDataGridView.CurrentCell.OwningColumn.Name != "productID")
                return;

            if (e.KeyCode == Keys.Enter)
            {
                currentValue = dataGridViewComboBoxEditingControl.Text;
                rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

                if (currentValue.Length > 0)
                {
                    updateSomeRowContents(selectedRow, rowSelectedIndex, currentValue);
                    detailReturDataGridView.CurrentCell = selectedRow.Cells["qty"];
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

            if (detailReturDataGridView.CurrentCell.OwningColumn.Name != "qty")
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            if (isLoading)
                return;

            if (dataGridViewTextBoxEditingControl.Text.Length <= 0)
            {
                // IF TEXTBOX IS EMPTY, DEFAULT THE VALUE TO 0 AND EXIT THE CHECKING
                isLoading = true;
                // reset subTotal Value and recalculate total
                selectedRow.Cells["subTotal"].Value = 0;
                subtotalList[rowSelectedIndex] = "0";

                if (detailQty.Count > rowSelectedIndex)
                    detailQty[rowSelectedIndex] = "0";
                dataGridViewTextBoxEditingControl.Text = "0";

                calculateTotal();

                dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;
                isLoading = false;

                return;
            }

            isLoading = true;
            if (detailQty.Count > rowSelectedIndex)
                previousInput = detailQty[rowSelectedIndex];
            else
                previousInput = "0";

            if (previousInput == "0")
            {
                tempString = dataGridViewTextBoxEditingControl.Text;
                if (tempString.IndexOf('0') == 0 && tempString.Length > 1 && tempString.IndexOf("0.") < 0)
                    dataGridViewTextBoxEditingControl.Text = tempString.Remove(tempString.IndexOf('0'), 1);
            }

            if (detailQty.Count < rowSelectedIndex + 1)
            {
                if (GUTIL.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    detailQty.Add(dataGridViewTextBoxEditingControl.Text);
                }
                else
                {
                    dataGridViewTextBoxEditingControl.Text = previousInput;
                }
            }
            else
            {
                if (GUTIL.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                        detailQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
                else
                {
                        dataGridViewTextBoxEditingControl.Text = detailQty[rowSelectedIndex];
                }
            }

            try
            {
                //changes on qty
                productQty = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);
                if (null != selectedRow.Cells["hpp"].Value)
                    hppValue = Convert.ToDouble(productPriceList[rowSelectedIndex]);

                subTotal = Math.Round((hppValue * productQty), 2);

                selectedRow.Cells["subTotal"].Value = subTotal.ToString();
                subtotalList[rowSelectedIndex] = subTotal.ToString();

                calculateTotal();
            }
            catch (Exception ex)
            {
                //dataGridViewTextBoxEditingControl.Text = previousInput;
            }

            dataGridViewTextBoxEditingControl.SelectionStart = dataGridViewTextBoxEditingControl.Text.Length;
            isLoading = false;
        }

        private void dataReturPermintaanForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            detailReturDataGridView.EditingControlShowing += detailReturDataGridView_EditingControlShowing;

            ReturDtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;           
          
            if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
            {
                fillInSupplierCombo();
            }
            else
            {
                supplierCombo.Visible = false;
                label2.Visible = false;
                label5.Visible = false;
            }

            addColumnToDataGrid();

            GUTIL.reArrangeTabOrder(this);

            detailQty.Add("0");
            productPriceList.Add("0");
            subtotalList.Add("0");
        }

        private void supplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSupplierID = Convert.ToInt32(supplierHiddenCombo.Items[supplierCombo.SelectedIndex]);
        }

        private bool isNoReturExist()
        {
            bool result = false;
            string noReturParam = MySqlHelper.EscapeString(noReturTextBox.Text);

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM RETURN_PURCHASE_HEADER WHERE RP_ID = '" + noReturParam + "'")) > 0)
                result = true;

            return result;
        }

        private void noReturTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isNoReturExist())
            {
                errorLabel.Text = "NO RETUR SUDAH ADA";
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
            if (noReturTextBox.Text.Length <= 0)
            {
                errorLabel.Text = "NO RETUR TIDAK BOLEH KOSONG";
                return false;
            }

            if (selectedSupplierID == 0 && originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
            {
                errorLabel.Text = "INPUT UNTUK SUPPLIER TIDAK VALID";
                return false;
            }

            if (globalTotalValue <= 0)
            {
                errorLabel.Text = "NILAI RETUR KOSONG";
                return false;
            }

            if (detailReturDataGridView.Rows.Count <= 0)
            {
                errorLabel.Text = "TIDAK ADA BARANG YANG DIRETUR";
                return false;
            }

            //for (i = 0; i < detailReturDataGridView.Rows.Count && dataExist; i++)
            //{
            //    if (null != detailReturDataGridView.Rows[i].Cells["productID"].Value)
            //        dataExist = GUTIL.isProductIDExist(detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString());
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

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string returID = "0";
            int supplierID = 0;
            string ReturDateTime = "";
            double returTotal = 0;
            double hppValue;
            double qtyValue;
            string descriptionValue;
            DateTime selectedReturDate;
            MySqlException internalEX = null;

            returID = noReturTextBox.Text;
            supplierID = selectedSupplierID;

            selectedReturDate = ReturDtPicker_1.Value;
            ReturDateTime = String.Format(culture, "{0:dd-MM-yyyy}", selectedReturDate);

            returTotal = globalTotalValue;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                // SAVE HEADER TABLE
                sqlCommand = "INSERT INTO RETURN_PURCHASE_HEADER (RP_ID, SUPPLIER_ID, RP_DATE, RP_TOTAL, RP_PROCESSED) VALUES " +
                                    "('" + returID + "', " + supplierID + ", STR_TO_DATE('" + ReturDateTime + "', '%d-%m-%Y'), " + returTotal + ", 1)";
                GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PEMBELIAN, "INSERT TO RETURN PURCHASE HEADER");                    
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                      throw internalEX;

                // SAVE DETAIL TABLE
                for (int i = 0; i < detailReturDataGridView.Rows.Count-1; i++)
                {
                    if (null != detailReturDataGridView.Rows[i].Cells["productID"].Value && GUTIL.isProductIDExist(detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString()))
                    { 
                       hppValue = Convert.ToDouble(productPriceList[i]);
                       qtyValue = Convert.ToDouble(detailQty[i]);
                      
                       try
                       {
                            descriptionValue = detailReturDataGridView.Rows[i].Cells["description"].Value.ToString();
                       }
                       catch(Exception ex)
                       {
                            descriptionValue = " ";
                       }
                       sqlCommand = "INSERT INTO RETURN_PURCHASE_DETAIL (RP_ID, PRODUCT_ID, PRODUCT_BASEPRICE, PRODUCT_QTY, RP_DESCRIPTION, RP_SUBTOTAL) VALUES " +
                                           "('" + returID + "', '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " +hppValue  + ", " + qtyValue + ", '" + MySqlHelper.EscapeString(descriptionValue) + "', " + Convert.ToDouble(subtotalList[i]) + ")";
                        GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PEMBELIAN, "INSERT TO RETURN PURCHASE DETAIL");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                           throw internalEX;

                       // UPDATE MASTER PRODUCT
                       sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + qtyValue + " WHERE PRODUCT_ID = '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "'";
                       GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PEMBELIAN, "UPDATE MASTER PRODUCT");
                       if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                         throw internalEX;
                    }
                }
              
                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PEMBELIAN, "EXCEPTION THROWN [" + e.Message + "]");
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        GUTIL.showDBOPError(ex, "ROLLBACK");
                    }
                }

                GUTIL.showDBOPError(e, "INSERT");
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

        private void printOutReturPermintaan()
        {
            string returNo = noReturTextBox.Text;
            string sqlCommandx = "";
            string moduleType = "RETUR PEMBELIAN";

            if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
                moduleType = "RETUR PEMBELIAN";
            else
                moduleType = "RETUR PERMINTAAN";

            sqlCommandx = "SELECT '"+ moduleType + "' AS MODULE_TYPE, RPH.RP_ID, IFNULL(MS.SUPPLIER_FULL_NAME, 'HQ PUSAT'), RPH.RP_DATE, RPH.RP_TOTAL, MP.PRODUCT_NAME, RPD.PRODUCT_BASEPRICE, RPD.PRODUCT_QTY, RPD.RP_DESCRIPTION, RPD.RP_SUBTOTAL " +
                                     "FROM RETURN_PURCHASE_HEADER RPH LEFT OUTER JOIN MASTER_SUPPLIER MS ON RPH.SUPPLIER_ID = MS.SUPPLIER_ID, MASTER_PRODUCT MP, RETURN_PURCHASE_DETAIL RPD " +
                                     "WHERE RPD.RP_ID = RPH.RP_ID AND RPD.PRODUCT_ID = MP.PRODUCT_ID AND RPH.RP_ID = '"+returNo+"'";
           
            DS.writeXML(sqlCommandx, globalConstants.returPermintaanXML);
            dataReturPermintaanPrintOutForm displayForm = new dataReturPermintaanPrintOutForm();
            displayForm.ShowDialog(this);
        }

        private void saveAndPrintButton_Click(object sender, EventArgs e)
        {
            GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PEMBELIAN, "ATTEMPT TO SAVE TO LOCAL DATA FIRST");
            if (saveData())
            {
                if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
                    GUTIL.saveUserChangeLog(globalConstants.MENU_RETUR_PEMBELIAN, globalConstants.CHANGE_LOG_INSERT, "CREATE NEW RETUR PEMBELIAN [" + noReturTextBox.Text + "] KE SUPPLIER [" + supplierCombo.Text + "]");
                else
                    GUTIL.saveUserChangeLog(globalConstants.MENU_RETUR_PERMINTAAN, globalConstants.CHANGE_LOG_INSERT, "CREATE NEW RETUR PERMINTAAN [" + noReturTextBox.Text + "]");

                printOutReturPermintaan();

                GUTIL.showSuccess(GUTIL.INS);
                GUTIL.ResetAllControls(this);
                detailReturDataGridView.Rows.Clear();
                globalTotalValue = 0;
                totalLabel.Text = globalTotalValue.ToString("C0", culture);
                ReturDtPicker_1.Value = DateTime.Now;
            }
        }

        private void supplierCombo_Validated(object sender, EventArgs e)
        {
            if (!supplierCombo.Items.Contains(supplierCombo.Text))
                supplierCombo.Focus();
        }

        private void detailReturDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            detailQty.Add("0");
            productPriceList.Add("0");
            subtotalList.Add("0");

            if (navKeyRegistered)
                unregisterNavigationKey();
        }

        private void deleteCurrentRow()
        {
            if (detailReturDataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];
                detailReturDataGridView.CurrentCell = selectedRow.Cells["productName"];

                if (null != selectedRow && rowSelectedIndex != detailReturDataGridView.Rows.Count - 1)
                {
                    for (int i = rowSelectedIndex; i < detailReturDataGridView.Rows.Count - 1; i++)
                    {
                        detailQty[i] = detailQty[i + 1];
                        productPriceList[i] = productPriceList[i + 1];
                        subtotalList[i] = subtotalList[i + 1];
                    }

                    isLoading = true;
                    detailReturDataGridView.Rows.Remove(selectedRow);
                    isLoading = false;
                }
            }
        }

        private void detailReturDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            { 
                if (DialogResult.Yes == MessageBox.Show("HAPUS BARIS ? ", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                { 
                    deleteCurrentRow();
                    calculateTotal();
                }
            }
        }

        private void dataReturPermintaanForm_Activated(object sender, EventArgs e)
        {
            registerGlobalHotkey();

            if (detailReturDataGridView.Focused)
                registerDelKey();
        }

        private void dataReturPermintaanForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();

            if (delKeyRegistered)
                unregisterDelKey();
        }

        private void detailReturDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var cell = detailReturDataGridView[e.ColumnIndex, e.RowIndex];
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[e.RowIndex];

            if (cell.OwningColumn.Name == "productID")
            {
                if (null != cell.Value)
                {
                    if (cell.Value.ToString().Length > 0)
                    {
                        updateSomeRowContents(selectedRow, e.RowIndex, cell.Value.ToString());
                    }
                    else
                    {
                        clearUpSomeRowContents(selectedRow, e.RowIndex);
                    }
                }
            }
        }

        private void detailReturDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (
               (detailReturDataGridView.Columns[e.ColumnIndex].Name == "hpp" ||
               detailReturDataGridView.Columns[e.ColumnIndex].Name == "qty" ||
               detailReturDataGridView.Columns[e.ColumnIndex].Name == "subTotal")
              && e.RowIndex != this.detailReturDataGridView.NewRowIndex && null != e.Value)
            {
                isLoading = true;
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString(globalUtilities.CELL_FORMATTING_NUMERIC_FORMAT);
                isLoading = false;
            }
        }

        private void detailReturDataGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterNavigationKey();

            registerDelKey();
        }

        private void detailReturDataGridView_Leave(object sender, EventArgs e)
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

    }
}
