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
    public partial class dataReturPenjualanStokAdjustmentForm : Form
    {
        private Data_Access DS = new Data_Access();
        private int selectedCustomerID;
        private string selectedProductID;

        private globalUtilities gutil = new globalUtilities();
        private List<string> returnQty = new List<string>();
        private List<string> returnPrice = new List<string>();

        public dataReturPenjualanStokAdjustmentForm()
        {
            InitializeComponent();
        }

        private void fillInPelangganCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT * FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    pelangganCombo.Items.Clear();
                    pelangganComboHidden.Items.Clear();
                    while (rdr.Read())
                    {
                        pelangganCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        pelangganComboHidden.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void addDataGridColumn()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DataGridViewComboBoxColumn productIdCmb = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn retailPriceColumn = new DataGridViewTextBoxColumn();
            
            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY PRODUCT_NAME ASC";

            //productComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productIdCmb.Items.Add(rdr.GetString("PRODUCT_ID"));
                    productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    //productComboHidden.Items.Add(rdr.GetString("PRODUCT_ID"));
                }
            }

            rdr.Close();

            productIdCmb.HeaderText = "KODE PRODUK";
            productIdCmb.Name = "productID";
            productIdCmb.Width = 200;
            dataProdukDataGridView.Columns.Add(productIdCmb);

            productNameCmb.HeaderText = "NAMA PRODUK";
            productNameCmb.Name = "productName";
            productNameCmb.Width = 300;
            dataProdukDataGridView.Columns.Add(productNameCmb);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            dataProdukDataGridView.Columns.Add(stockQtyColumn);

            retailPriceColumn.HeaderText = "RETAIL PRICE";
            retailPriceColumn.Name = "productPrice";
            retailPriceColumn.Width = 100;
            dataProdukDataGridView.Columns.Add(retailPriceColumn);

        }

        private void dataReturPenjualanStokAdjustmentForm_Load(object sender, EventArgs e)
        {
            rsDateTimePicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            errorLabel.Text = "";

            gutil.reArrangeTabOrder(this);
        }

        private void pelangganCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomerID = Convert.ToInt32(pelangganComboHidden.Items[pelangganCombo.SelectedIndex]);
        }

        private bool noReturExist()
        {
            bool result = false;

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM RETURN_SALES_HEADER WHERE RS_INVOICE = '" + noreturtextbox.Text + "'")) > 0)
                result = true;

            return result;
        }

        private void noreturtextbox_TextChanged(object sender, EventArgs e)
        {
            if (noReturExist())
            {
                errorLabel.Text = "NO RETUR SUDAH ADA";
                noreturtextbox.Focus();
            }
            else
                errorLabel.Text = "";
        }

        private void dataProdukDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            returnQty.Add("0");
            dataProdukDataGridView.Rows[e.RowIndex].Cells["qty"].Value = "0";
        }

        private void cashierDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((dataProdukDataGridView.CurrentCell.OwningColumn.Name == "productID" || dataProdukDataGridView.CurrentCell.OwningColumn.Name == "productName")  && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if ((dataProdukDataGridView.CurrentCell.OwningColumn.Name == "qty" || dataProdukDataGridView.CurrentCell.OwningColumn.Name == "productPrice") && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private string getProductID(int selectedIndex)
        {
            string productID = "";
            productID = productComboHidden.Items[selectedIndex].ToString();
            return productID;
        }

        private double getProductPriceValue(string productID)
        {
            double result = 0;
            string priceType = "";

            DS.mySqlConnect();

            priceType = "PRODUCT_RETAIL_PRICE";
        
            result = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(" + priceType + ", 0) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            int rowSelectedIndex = 0;
            string selectedProductID = "";
            double hpp = 0;

            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;

            selectedIndex = dataGridViewComboBoxEditingControl.SelectedIndex;
            rowSelectedIndex = dataProdukDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataProdukDataGridView.Rows[rowSelectedIndex];

            DataGridViewComboBoxCell productIDComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productID"];
            DataGridViewComboBoxCell productNameComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productName"];

            selectedProductID = productIDComboCell.Items[selectedIndex].ToString();
            productIDComboCell.Value = productIDComboCell.Items[selectedIndex];
            productNameComboCell.Value = productNameComboCell.Items[selectedIndex];

            hpp = getProductPriceValue(selectedProductID);
            
            selectedRow.Cells["productPrice"].Value = hpp;

            if (null == selectedRow.Cells["qty"].Value)
                selectedRow.Cells["qty"].Value = 0;

            
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            //int rowSelectedIndex = 0;
            //double subTotal = 0;
            //double productPrice = 0;
            //string productID = "";

            //if (isLoading)
            //    return;

            //DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            //rowSelectedIndex = cashierDataGridView.SelectedCells[0].RowIndex;
            //DataGridViewRow selectedRow = cashierDataGridView.Rows[rowSelectedIndex];

            //if (cashierDataGridView.CurrentCell.ColumnIndex != 3 && cashierDataGridView.CurrentCell.ColumnIndex != 4 && cashierDataGridView.CurrentCell.ColumnIndex != 5 && cashierDataGridView.CurrentCell.ColumnIndex != 6)
            //    return;

            //if (null != selectedRow.Cells["productID"].Value)
            //    productID = selectedRow.Cells["productID"].Value.ToString();

            //if (gutil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
            //    && (dataGridViewTextBoxEditingControl.Text.Length > 0)
            //    )
            //{
            //    switch (cashierDataGridView.CurrentCell.ColumnIndex)
            //    {
            //        case 3:
            //            if (stockIsEnough(productID, Convert.ToDouble(dataGridViewTextBoxEditingControl.Text)))
            //                salesQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
            //            else
            //                dataGridViewTextBoxEditingControl.Text = salesQty[rowSelectedIndex];
            //            break;
            //        case 4:
            //            disc1[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
            //            break;
            //        case 5:
            //            disc2[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
            //            break;
            //        case 6:
            //            discRP[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
            //            break;
            //    }
            //}
            //else
            //{
            //    switch (cashierDataGridView.CurrentCell.ColumnIndex)
            //    {
            //        case 3:
            //            dataGridViewTextBoxEditingControl.Text = salesQty[rowSelectedIndex];
            //            break;
            //        case 4:
            //            dataGridViewTextBoxEditingControl.Text = disc1[rowSelectedIndex];
            //            break;
            //        case 5:
            //            dataGridViewTextBoxEditingControl.Text = disc2[rowSelectedIndex];
            //            break;
            //        case 6:
            //            dataGridViewTextBoxEditingControl.Text = discRP[rowSelectedIndex];
            //            break;
            //    }
            //}

            //productPrice = Convert.ToDouble(selectedRow.Cells["productPrice"].Value);

            //subTotal = calculateSubTotal(rowSelectedIndex, productPrice);
            //selectedRow.Cells["jumlah"].Value = subTotal;

            //calculateTotal();
        }


    }
}
