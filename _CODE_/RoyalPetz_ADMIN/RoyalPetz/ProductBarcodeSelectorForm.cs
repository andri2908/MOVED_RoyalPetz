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
using System.Reflection;
using System.Xml.Serialization;
using System.IO;

namespace AlphaSoft
{
    public partial class ProductBarcodeSelectorForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private globalPrinterUtility gPrinter = new globalPrinterUtility();
        //private Hotkeys.GlobalHotkey ghk_F1;
        private Hotkeys.GlobalHotkey ghk_F11;
        private Hotkeys.GlobalHotkey ghk_DEL;

        private CultureInfo culture = new CultureInfo("id-ID");
        private int numberLabel = 4;
        private int numberProduct = 12;

        dataProdukForm browseProdukForm = null;

        public ProductBarcodeSelectorForm()
        {
            InitializeComponent();
        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                //case Keys.F1:
                //    cashierHelpForm displayHelp = new cashierHelpForm();
                //    displayHelp.ShowDialog(this);
                //    break;
               
                case Keys.F11:
                        if (null == browseProdukForm || browseProdukForm.IsDisposed)
                            browseProdukForm = new dataProdukForm(globalConstants.PRODUCT_BC, this);
                        browseProdukForm.Show();
                        browseProdukForm.WindowState = FormWindowState.Normal;
                    break;

                case Keys.Delete:
                    //clear
                    int currentrowindex = 0;
                    currentrowindex = ProductBCGridView.SelectedCells[0].RowIndex;
                    clearrow(currentrowindex);
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
            //ghk_F1 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F1, this);
            //ghk_F1.Register();

            ghk_F11 = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.F11, this);
            ghk_F11.Register();

            ghk_DEL = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Delete, this);
            ghk_DEL.Register();       
        }

        private void unregisterGlobalHotkey()
        {           
            //ghk_F1.Unregister();
            ghk_F11.Unregister();
            ghk_DEL.Unregister();          
        }

        private void clearrow(int rowSelectedIndex = 0)
        {
            DataGridViewRow selectedRow = ProductBCGridView.Rows[rowSelectedIndex];
            selectedRow.Cells["productID"].Value = "";
            selectedRow.Cells["productName"].Value = "";
            selectedRow.Cells["productPrice"].Value = "";
            selectedRow.Cells["productBarcode"].Value = "";
        }

        private void addFixRow()
        {
            int newRowIndex = 0;

            for (int a = 0; a < numberProduct; a = a + 1)
            {
                ProductBCGridView.Rows.Add();
            }
                
            //newRowIndex = ProductBCGridView.Rows.Count - 1;
            ProductBCGridView.Focus();
            ProductBCGridView.CurrentCell = ProductBCGridView.Rows[newRowIndex].Cells["productID"];            
        }

        private double getProductPriceValue(string productID, int customerType = 0, bool hppValue = false)
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
            if (hppValue)
                priceType = "PRODUCT_BASE_PRICE";

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(" + priceType + ", 0) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private bool productIDValid(string productID)
        {
            bool result = false;
            if (0 < Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'")))
                result = true;
            return result;
        }

        private void updateSomeRowContents(DataGridViewRow selectedRow, int rowSelectedIndex, string currentValue, bool isProductID = true)
        {
            int numRow = 0;
            string selectedProductID = "";
            string selectedProductName = "";
            string selectedProductBC = "";
            double retailprice = 0;

            string currentProductID = "";
            string currentProductName = "";
            bool changed = false;

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
                    selectedProductBC = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_BARCODE,'') FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'").ToString();
                }
                else
                {
                    selectedProductName = currentValue;
                    selectedProductID = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_ID,'') FROM MASTER_PRODUCT WHERE PRODUCT_NAME = '" + currentValue + "'").ToString();
                    selectedProductBC = DS.getDataSingleValue("SELECT IFNULL(PRODUCT_BARCODE,'') FROM MASTER_PRODUCT WHERE PRODUCT_NAME = '" + currentValue + "'").ToString();
                }

                if (null != selectedRow.Cells["productID"].Value)
                    currentProductID = selectedRow.Cells["productID"].Value.ToString();

                if (null != selectedRow.Cells["productName"].Value)
                    currentProductName = selectedRow.Cells["productName"].Value.ToString();
                                
                selectedRow.Cells["productId"].Value = selectedProductID;
                selectedRow.Cells["productName"].Value = selectedProductName;
                selectedRow.Cells["productBarcode"].Value = selectedProductBC;

                retailprice = getProductPriceValue(selectedProductID, 0, false);
                //selectedRow.Cells["productPrice"].Value = retailprice;
                selectedRow.Cells["productPrice"].Value = retailprice.ToString("C0", culture);
                //ProductBCGridView.Rows[rowSelectedIndex].Cells["productId"].Value = selectedProductID;
                //ProductBCGridView.Rows[rowSelectedIndex].Cells["productName"].Value = selectedProductName;
                //ProductBCGridView.Rows[rowSelectedIndex].Cells["productBarcode"].Value = selectedProductBC;
                //ProductBCGridView.Rows[rowSelectedIndex].Cells["productPrice"].Value = retailprice;

                if (selectedProductID != currentProductID)
                    changed = true;

                if (selectedProductName != currentProductName)
                    changed = true;

                if (!changed)
                    return;         
            }
        }

        public void addNewRowFromBarcode(string productID, string productName, int rowIndex = -1)
        {
            int i = 0;
            bool found = false;
            bool foundEmptyRow = false;
            int emptyRowIndex = 0;
            int rowSelectedIndex = 0;
            
            ProductBCGridView.AllowUserToAddRows = false;
            ProductBCGridView.Focus();

            //if (rowIndex >= 0)
            //{
            //    rowSelectedIndex = rowIndex;
            //}
            //else
            //{
            //    // CHECK FOR EXISTING SELECTED ITEM
            //    for (i = 0; i < ProductBCGridView.Rows.Count && !found && !foundEmptyRow; i++)
            //    {
            //        if (null != ProductBCGridView.Rows[i].Cells["productName"].Value && null != ProductBCGridView.Rows[i].Cells["productID"].Value && productIDValid(ProductBCGridView.Rows[i].Cells["productID"].Value.ToString()))
            //        {
            //            if (ProductBCGridView.Rows[i].Cells["productName"].Value.ToString() == productName)
            //            {
            //                found = true;
            //                rowSelectedIndex = i;
            //            }
            //        }
            //        else
            //        {
            //            foundEmptyRow = true;
            //            emptyRowIndex = i;
            //        }
            //    }
            //    if (!found)
            //    {
            //        if (!foundEmptyRow)
            //        {
            //            //addNewRow(false);
            //            rowSelectedIndex = rowIndex + 1;
            //        }
            //        else
            //        {
            //            rowSelectedIndex = emptyRowIndex;
            //        }
            //    }
            //}
            if (rowIndex >= 0)
            {
                rowSelectedIndex = rowIndex;
            }
            else
            {
                rowSelectedIndex = ProductBCGridView.SelectedCells[0].RowIndex;
            }

            DataGridViewRow selectedRow = ProductBCGridView.Rows[rowSelectedIndex];
            updateSomeRowContents(selectedRow, rowSelectedIndex, productID);         
        }

        private void addColumnToDataGrid()
        {           
            DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productNameColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productRetailColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productBarcodeColumn = new DataGridViewTextBoxColumn();
            
            productIdColumn.HeaderText = "KODE PRODUK";
            productIdColumn.Name = "productID";
            productIdColumn.Width = 250;
            productIdColumn.ReadOnly = false;
            productIdColumn.Visible = true;
            ProductBCGridView.Columns.Add(productIdColumn);

            // PRODUCT Barcode
            productBarcodeColumn.HeaderText = "BARCODE";
            productBarcodeColumn.Name = "productBarcode";
            productBarcodeColumn.Width = 350;
            productBarcodeColumn.ReadOnly = true;
            productBarcodeColumn.Visible = true;
            ProductBCGridView.Columns.Add(productBarcodeColumn);
            
            // PRODUCT NAME COLUMN
            productNameColumn.HeaderText = "NAMA PRODUK";
            productNameColumn.Name = "productName";
            productNameColumn.Width = 400;
            //productNameColumn.ReadOnly = true;
            ProductBCGridView.Columns.Add(productNameColumn);

            // PRODUCT RETAIL PRICE
            productRetailColumn.HeaderText = "HARGA PRODUK";
            productRetailColumn.Name = "productPrice";
            productRetailColumn.Width = 300;
            productRetailColumn.ReadOnly = true;
            ProductBCGridView.Columns.Add(productRetailColumn);            
        }

        private void Combobox_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                int pos = ProductBCGridView.CurrentCell.RowIndex;

                if (pos > 0)
                    ProductBCGridView.CurrentCell = ProductBCGridView.Rows[pos - 1].Cells["productID"];
                
            }
        }

        private void cashierDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // +=
            if ((ProductBCGridView.CurrentCell.OwningColumn.Name == "productID")
                && e.Control is TextBox)
            {
                TextBox productIDTextBox = e.Control as TextBox;
                productIDTextBox.CharacterCasing = CharacterCasing.Upper;
                productIDTextBox.PreviewKeyDown -= Combobox_previewKeyDown;
                productIDTextBox.PreviewKeyDown += Combobox_previewKeyDown;
                productIDTextBox.AutoCompleteMode = AutoCompleteMode.None;
                productIDTextBox.KeyUp += Combobox_KeyUp;
            }

            if ((ProductBCGridView.CurrentCell.OwningColumn.Name == "productName")
                && e.Control is TextBox)
            {
                TextBox productNameTextBox = e.Control as TextBox;
                productNameTextBox.CharacterCasing = CharacterCasing.Upper;
                productNameTextBox.PreviewKeyDown -= productName_previewKeyDown;
                productNameTextBox.PreviewKeyDown += productName_previewKeyDown;
                productNameTextBox.AutoCompleteMode = AutoCompleteMode.None;//SuggestAppend;
                productNameTextBox.KeyUp += Combobox_KeyUp;
            }

            if ((ProductBCGridView.CurrentCell.OwningColumn.Name == "productPrice")
               && e.Control is TextBox)
            {
                TextBox productRetailTextBox = e.Control as TextBox;
                productRetailTextBox.CharacterCasing = CharacterCasing.Upper;
                productRetailTextBox.AutoCompleteMode = AutoCompleteMode.None;
                productRetailTextBox.KeyUp += Combobox_KeyUp;
            }

            if ((ProductBCGridView.CurrentCell.OwningColumn.Name == "productBarcode")
               && e.Control is TextBox)
            {
                TextBox productBarcodeTextBox = e.Control as TextBox;
                productBarcodeTextBox.CharacterCasing = CharacterCasing.Upper;
                productBarcodeTextBox.AutoCompleteMode = AutoCompleteMode.None;
                productBarcodeTextBox.KeyUp += Combobox_KeyUp;
            }
        }

        private void Combobox_previewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string currentValue = "";
            int rowSelectedIndex = 0;

            DataGridViewTextBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            if (ProductBCGridView.CurrentCell.OwningColumn.Name != "productID")
                return;
           
            if (e.KeyCode == Keys.Enter)
            {
                currentValue = dataGridViewComboBoxEditingControl.Text;
                rowSelectedIndex = ProductBCGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = ProductBCGridView.Rows[rowSelectedIndex];

                if (currentValue.Length > 0)
                {
                    string sqlCommand = "";
                    string productName = "";
                    sqlCommand = "SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'";

                    if (Convert.ToInt32(DS.getDataSingleValue(sqlCommand)) > 0)
                    {
                        sqlCommand = "SELECT PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + currentValue + "'";

                        productName = DS.getDataSingleValue(sqlCommand).ToString();

                        addNewRowFromBarcode(currentValue, productName, rowSelectedIndex);
                    }
                    else
                    {
                        // CALL DATA PRODUK FORM WITH PARAMETER 
                        dataProdukForm browseProduk = new dataProdukForm(globalConstants.PRODUCT_BC, this, currentValue, "", rowSelectedIndex);
                        browseProduk.ShowDialog(this);
                    }
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

            if (ProductBCGridView.CurrentCell.OwningColumn.Name != "productName")
                return;
           
            if (e.KeyCode == Keys.Enter)
            {
                currentValue = dataGridViewComboBoxEditingControl.Text;
                rowSelectedIndex = ProductBCGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = ProductBCGridView.Rows[rowSelectedIndex];

                if (currentValue.Length > 0)
                {
                    // CALL DATA PRODUK FORM WITH PARAMETER 
                    dataProdukForm browseProduk = new dataProdukForm(globalConstants.PRODUCT_BC, this, currentValue, "", rowSelectedIndex);
                    browseProduk.ShowDialog(this);
                }
                else
                {
                    //clearUpSomeRowContents(selectedRow, rowSelectedIndex);
                }
            }
        }

        private void ProductBarcodeSelectorForm_Load(object sender, EventArgs e)
        {
            registerGlobalHotkey();
            ProductBCGridView.EditingControlShowing += cashierDataGridView_EditingControlShowing;
            addColumnToDataGrid();
            addFixRow();
            gutil.reArrangeTabOrder(this);
        }

        private void PrintBarcodeButton_Click(object sender, EventArgs e)
        {
            Barcodes barcodeDetails = new Barcodes();
            DataTable dataTable = barcodeDetails._Barcodes;

            int blank_labels = 0;
            string selectedProductID = "";
            string selectedProductName = "";
            string selectedProductBC = "";
            string selectedProductPrice = "";

            for (int a = 0; a < numberProduct; a++)
            {
                selectedProductID = "";
                selectedProductName = "";
                selectedProductBC = "";
                selectedProductPrice = "";

                if (ProductBCGridView.Rows[a].Cells["productID"].Value != null)
                    selectedProductID = ProductBCGridView.Rows[a].Cells["productID"].Value.ToString();
                if (ProductBCGridView.Rows[a].Cells["productName"].Value != null)
                    selectedProductName = ProductBCGridView.Rows[a].Cells["productName"].Value.ToString();
                if (ProductBCGridView.Rows[a].Cells["productBarcode"].Value != null)
                    selectedProductBC = "*" + ProductBCGridView.Rows[a].Cells["productBarcode"].Value.ToString() + "*";
                if (ProductBCGridView.Rows[a].Cells["productPrice"].Value != null)
                {
                    //selectedProductPrice = "Rp." + ProductBCGridView.Rows[a].Cells["productPrice"].Value.ToString() + ",-";
                    //double tmp = Convert.ToDouble(ProductBCGridView.Rows[a].Cells["productPrice"].Value.ToString());                 
                    //selectedProductPrice = tmp.ToString("C0", culture);
                    selectedProductPrice = ProductBCGridView.Rows[a].Cells["productPrice"].Value.ToString();
                }

                for (int i = 0; i < numberLabel; i++)
                {
                    DataRow drow = dataTable.NewRow();
                    string P_name = "";
                    if (blank_labels <= i)
                    {
                        drow["Barcode"] += selectedProductBC;
                        drow["ProductID"] = selectedProductID;
                        drow["ProductName"] = selectedProductName;
                        drow["RetailPrice"] = selectedProductPrice;
                    }
                    dataTable.Rows.Add(drow);
                }
            }

            //var data = new MyClass { Field1 = "test1", Field2 = "test2" };
            var serializer = new XmlSerializer(typeof(Barcodes));
            string appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.ProductBarcodeXML;
            using (var stream = new StreamWriter(appPath))
                serializer.Serialize(stream, barcodeDetails);

            //need to pass array of record
            ProductBarcodePrintTemplateForm displayedForm = new ProductBarcodePrintTemplateForm();
            displayedForm.ShowDialog(this);
        }

        private void ProductBCGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ProductBCGridView.IsCurrentCellDirty)
            {
                ProductBCGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
