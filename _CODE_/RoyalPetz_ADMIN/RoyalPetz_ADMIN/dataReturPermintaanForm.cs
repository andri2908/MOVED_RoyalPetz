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
        private bool isLoading = false;

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

            DataGridViewComboBoxColumn productIdCmb = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn basePriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();

            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND (PRODUCT_STOCK_QTY - PRODUCT_LIMIT_STOCK > 0) ORDER BY PRODUCT_NAME ASC";

            //productIDComboHidden.Items.Clear();
            //productNameComboHidden.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    productNameCmb.Items.Add(rdr.GetString("PRODUCT_NAME"));
                    productIdCmb.Items.Add(rdr.GetString("PRODUCT_ID"));
                    //productIDComboHidden.Items.Add(rdr.GetString("PRODUCT_ID"));
                    //productNameComboHidden.Items.Add(rdr.GetString("PRODUCT_NAME"));
                }
            }

            rdr.Close();

            productIdCmb.HeaderText = "KODE PRODUK";
            productIdCmb.Name = "productID";
            productIdCmb.Width = 200;
            productIdCmb.DefaultCellStyle.BackColor = Color.LightBlue;
            detailReturDataGridView.Columns.Add(productIdCmb);

            productNameCmb.HeaderText = "NAMA PRODUK";
            productNameCmb.Name = "productName";
            productNameCmb.Width = 300;
            productNameCmb.DefaultCellStyle.BackColor = Color.LightBlue;
            detailReturDataGridView.Columns.Add(productNameCmb);

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

            for (int i = 0; i < detailReturDataGridView.Rows.Count; i++)
            {
                total = total + Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["subTotal"].Value);
            }

            globalTotalValue = total;
            totalLabel.Text = total.ToString("C2", culture);//"Rp. " + total.ToString();
        }

        private void detailReturDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((detailReturDataGridView.CurrentCell.OwningColumn.Name == "productID" || detailReturDataGridView.CurrentCell.OwningColumn.Name == "productName") && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if ((detailReturDataGridView.CurrentCell.OwningColumn.Name == "qty") && e.Control is TextBox)
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
            rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

            DataGridViewComboBoxCell productIDComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productID"];
            DataGridViewComboBoxCell productNameComboCell = (DataGridViewComboBoxCell)selectedRow.Cells["productName"];

            if (selectedIndex < 0)
                return;

            selectedProductID = productIDComboCell.Items[selectedIndex].ToString();
            productIDComboCell.Value = productIDComboCell.Items[selectedIndex];
            productNameComboCell.Value = productNameComboCell.Items[selectedIndex];

            hpp = getHPPValue(selectedProductID);

            selectedRow.Cells["hpp"].Value = hpp;

            if (null == selectedRow.Cells["qty"].Value)
                selectedRow.Cells["qty"].Value = 0;

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
                    //if (detailReturDataGridView.CurrentCell.ColumnIndex == 2)
                    //{
                    //    detailQty.Add(dataGridViewTextBoxEditingControl.Text);
                    //}
                    //else
                    //{
                    //    detailQty.Add(selectedRow.Cells["qty"].Value.ToString());
                    //}
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
                    hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);

                subTotal = Math.Round((hppValue * productQty), 2);

                selectedRow.Cells["subTotal"].Value = subTotal;

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
            bool dataExist = false;

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

            for (int i = 0; i < detailReturDataGridView.Rows.Count && !dataExist; i++)
            {
                if (null != detailReturDataGridView.Rows[i].Cells["productID"].Value)
                    dataExist = true;
            }
            if (!dataExist)
            {
                errorLabel.Text = "TIDAK ADA PRODUK YANG DIPILIH";
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
                GUTIL.saveSystemDebugLog(globalConstants.MENU_RETUR_PEMBELIAN, "INSERT TO RETURN PURCHASE HEADER");                    
                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                      throw internalEX;

                // SAVE DETAIL TABLE
                for (int i = 0; i < detailReturDataGridView.Rows.Count; i++)
                {
                    if (null != detailReturDataGridView.Rows[i].Cells["productID"].Value)
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
                                           "('" + returID + "', '" + detailReturDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " +hppValue  + ", " + qtyValue + ", '" + MySqlHelper.EscapeString(descriptionValue) + "', " + Convert.ToDouble(detailReturDataGridView.Rows[i].Cells["subTotal"].Value) + ")";
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
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
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

                GUTIL.showSuccess(GUTIL.INS);
                GUTIL.ResetAllControls(this);
                detailReturDataGridView.Rows.Clear();
                globalTotalValue = 0;
                totalLabel.Text = globalTotalValue.ToString("C", culture);
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
        }

        private void deleteCurrentRow()
        {
            if (detailReturDataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailReturDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailReturDataGridView.Rows[rowSelectedIndex];

                detailReturDataGridView.Rows.Remove(selectedRow);
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
    }
}
