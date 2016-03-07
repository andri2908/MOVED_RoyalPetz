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
    public partial class dataReturPermintaanForm : Form
    {
        private int selectedSupplierID = 0;
        private double globalTotalValue = 0;
        private string previousInput = "";
        private int originModuleID = 0;

        private List<string> detailQty = new List<string>();
        private CultureInfo culture = new CultureInfo("id-ID");

        private Data_Access DS = new Data_Access();
        private globalUtilities GUTIL = new globalUtilities();

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
            MySqlDataReader rdr;
            string sqlCommand = "";

            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn basePriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();

            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND (PRODUCT_STOCK_QTY - PRODUCT_LIMIT_STOCK > 0) ORDER BY PRODUCT_NAME ASC";

            productIDComboHidden.Items.Clear();
            productNameComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    productIDComboHidden.Items.Add(rdr.GetString("PRODUCT_ID"));
                    productNameComboHidden.Items.Add(rdr.GetString("PRODUCT_NAME"));
                }
            }

            rdr.Close();

            // PRODUCT NAME COLUMN
            productNameCmb.HeaderText = "NAMA PRODUK";
            productNameCmb.Name = "productName";
            productNameCmb.Width = 300;
            detailReturDataGridView.Columns.Add(productNameCmb);

            basePriceColumn.HeaderText = "HARGA POKOK";
            basePriceColumn.Name = "HPP";
            basePriceColumn.Width = 200;
            basePriceColumn.ReadOnly = true;
            detailReturDataGridView.Columns.Add(basePriceColumn);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
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
            detailReturDataGridView.Columns.Add(descriptionColumn);

            productIdColumn.HeaderText = "PRODUCT_ID";
            productIdColumn.Name = "productID";
            productIdColumn.Width = 200;
            productIdColumn.Visible = false;
            detailReturDataGridView.Columns.Add(productIdColumn);
        }

        private string getProductID(int selectedIndex)
        {
            string productID = "";
            productID = productIDComboHidden.Items[selectedIndex].ToString();
            return productID;
        }

        private double getHPPValue(string productID)
        {
            double result = 0;

            DS.mySqlConnect();

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(PRODUCT_BASE_PRICE, 0) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void calculateTotal()
        {
            double total = 0;

            for (int i = 0; i < detailReturDataGridView.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["subTotal"].Value);
            }

            globalTotalValue = total;
            totalLabel.Text = "Rp. " + total.ToString();
        }

        private void detailReturDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (detailReturDataGridView.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if ((detailReturDataGridView.CurrentCell.ColumnIndex == 2) && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            int rowSelectedIndex = 0;
            string selectedProductID = "";
            double hpp = 0;
            double productQty = 0;
            double subTotal = 0;

            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;

            selectedIndex = dataGridViewComboBoxEditingControl.SelectedIndex;
            selectedProductID = getProductID(selectedIndex);
            hpp = getHPPValue(selectedProductID);

            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            selectedRow.Cells["hpp"].Value = hpp;

            if (null == selectedRow.Cells["qty"].Value)
                selectedRow.Cells["qty"].Value = 0;

            selectedRow.Cells["productId"].Value = selectedProductID;

            if (null != selectedRow.Cells["qty"].Value)
            {
                productQty = Convert.ToDouble(selectedRow.Cells["qty"].Value);
                subTotal = Math.Round((hpp * productQty), 2);

                selectedRow.Cells["subTotal"].Value = subTotal;
            }

            calculateTotal();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double productQty = 0;
            double hppValue = 0;
            double subTotal = 0;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            previousInput = "";
            if (detailQty.Count < rowSelectedIndex + 1)
            {
                if (GUTIL.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL)
                    && (dataGridViewTextBoxEditingControl.Text.Length > 0))
                {
                    if (detailReturDataGridView.CurrentCell.ColumnIndex == 2)
                    {
                        detailQty.Add(dataGridViewTextBoxEditingControl.Text);
                    }
                    else
                    {
                        detailQty.Add(selectedRow.Cells["qty"].Value.ToString());
                    }
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
                hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);

                subTotal = Math.Round((hppValue * productQty), 2);

                selectedRow.Cells["subtotal"].Value = subTotal;

                calculateTotal();
            }
            catch (Exception ex)
            {
                //dataGridViewTextBoxEditingControl.Text = previousInput;
            }
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
        }

        private void supplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSupplierID = Convert.ToInt32(supplierHiddenCombo.Items[supplierCombo.SelectedIndex]);
        }

        private bool isNoReturExist()
        {
            bool result = false;

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM RETURN_PURCHASE_HEADER WHERE RP_ID = '" + noReturTextBox.Text + "'")) > 0)
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

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailReturDataGridView.Rows.Count - 1; i++)
                        {
                            hppValue = Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["HPP"].Value);
                            qtyValue = Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["qty"].Value);
                            try
                            {
                                descriptionValue = detailReturDataGridView.Rows[i].Cells["description"].Value.ToString();
                            }
                            catch(Exception ex)
                            {
                                descriptionValue = " ";
                            }
                            sqlCommand = "INSERT INTO RETURN_PURCHASE_DETAIL (RP_ID, PRODUCT_ID, PRODUCT_BASEPRICE, PRODUCT_QTY, RP_DESCRIPTION, RP_SUBTOTAL) VALUES " +
                                                "('" + returID + "', '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " +hppValue  + ", " + qtyValue + ", '" + descriptionValue + "', " + Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["subTotal"].Value) + ")";

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // UPDATE MASTER PRODUCT
                            sqlCommand = "UPDATE MASTER_PRODUCT SET PRODUCT_STOCK_QTY = PRODUCT_STOCK_QTY - " + qtyValue + " WHERE PRODUCT_ID = '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "'";

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
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }
        
        private void saveAndPrintButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                GUTIL.showSuccess(GUTIL.INS);
            }
        }

        private void supplierCombo_Validated(object sender, EventArgs e)
        {
            if (!supplierCombo.Items.Contains(supplierCombo.Text))
                supplierCombo.Focus();
        }
    }
}
