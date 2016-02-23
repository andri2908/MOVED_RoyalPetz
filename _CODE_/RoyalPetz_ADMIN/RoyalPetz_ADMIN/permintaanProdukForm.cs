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

        private Data_Access DS = new Data_Access();
        private List<string> detailRequestQty = new List<string>();
        
        private globalUtilities gUtil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");

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

        private string getBranchName(int branchID)
        {
            string result = "";

            Data_Access tempDS = new Data_Access();
            result = tempDS.getDataSingleValue("SELECT ifnull(BRANCH_NAME, '') FROM MASTER_BRANCH WHERE BRANCH_ID = " + branchID).ToString();
            tempDS.mySqlClose();
            
            return result;
        }

        private string getProductName(int productID)
        {
            string result = "";

            result = DS.getDataSingleValue("SELECT ifnull(PRODUCT_NAME, '') FROM MASTER_PRODUCT WHERE PRODUCT_ID = " + productID).ToString();

            return result;
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
                        totalLabel.Text = "Rp. " + rdr.GetString("RO_TOTAL");
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
                while (rdr.Read())
                {
                    productName = rdr.GetString("PRODUCT_NAME");
                    detailRequestOrderDataGridView.Rows.Add(productName, rdr.GetString("RO_QTY"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("RO_SUBTOTAL"), rdr.GetString("PRODUCT_ID"));
                }

                rdr.Close();
            }
        }

        private string getProductID(int selectedIndex)
        {
            string productID = "";
            productID = productIDComboHidden.Items[selectedIndex].ToString();
            return productID;
        }

        private void calculateTotal()
        {
            double total = 0;

            for (int i = 0; i<detailRequestOrderDataGridView.Rows.Count;i++)
            {
                total = total + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value);
            }

            globalTotalValue = total;
            totalLabel.Text = "Rp. " + total.ToString();
        }

        private void detailRequestOrderDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (detailRequestOrderDataGridView.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }

            if (detailRequestOrderDataGridView.CurrentCell.ColumnIndex == 1 && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            double productQty = 0;
            double hppValue = 0;
            double subTotal = 0;

            if (isLoading)
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;
            
            rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

            previousInput = "";
            if ( detailRequestQty.Count < rowSelectedIndex+1 )
            {
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
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
                if (gUtil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
                {
                    detailRequestQty[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                }
                else
                {
                    dataGridViewTextBoxEditingControl.Text = detailRequestQty[rowSelectedIndex];
                }
            }

            productQty = Convert.ToDouble(dataGridViewTextBoxEditingControl.Text);

            if (null != selectedRow.Cells["hpp"].Value)
            {
                hppValue = Convert.ToDouble(selectedRow.Cells["hpp"].Value);
                subTotal = Math.Round((hppValue * productQty), 2);

                selectedRow.Cells["subTotal"].Value = subTotal;
            }
  
            calculateTotal();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            int rowSelectedIndex = 0;
            string selectedProductID = "";
            double hpp = 0;
            double productQty = 0;
            double subTotal = 0;

            if (isLoading)
                return;

            DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;

            selectedIndex = dataGridViewComboBoxEditingControl.SelectedIndex;
            selectedProductID = getProductID(selectedIndex);
            hpp = getHPPValue(selectedProductID);

            rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];

            selectedRow.Cells["hpp"].Value = hpp;
            selectedRow.Cells["productId"].Value = selectedProductID;

            if (null != selectedRow.Cells["qty"].Value)
            {
                productQty = Convert.ToDouble(selectedRow.Cells["qty"].Value);
                subTotal = Math.Round((hpp * productQty),2);
 
                selectedRow.Cells["subTotal"].Value = subTotal;
            }

            calculateTotal();
        }
        
        private void exportButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            MessageBox.Show(saveFileDialog1.FileName);
        }

        private double getHPPValue(string productID)
        {
            double result = 0;

            DS.mySqlConnect();

            result = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(PRODUCT_BASE_PRICE, 0) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void fillInProductNameCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            DataGridViewComboBoxColumn productNameCmb = new DataGridViewComboBoxColumn();
            DataGridViewTextBoxColumn stockQtyColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn basePriceColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn subTotalColumn = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn productIdColumn = new DataGridViewTextBoxColumn();

            sqlCommand = "SELECT PRODUCT_ID, PRODUCT_NAME FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY PRODUCT_NAME ASC";

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
            detailRequestOrderDataGridView.Columns.Add(productNameCmb);

            stockQtyColumn.HeaderText = "QTY";
            stockQtyColumn.Name = "qty";
            stockQtyColumn.Width = 100;
            detailRequestOrderDataGridView.Columns.Add(stockQtyColumn);

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

            productIdColumn.HeaderText = "PRODUCT_ID";
            productIdColumn.Name = "productID";
            productIdColumn.Width = 200;
            productIdColumn.Visible = false;
            detailRequestOrderDataGridView.Columns.Add(productIdColumn);

        }

        private void permintaanProdukForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            fillInBranchFromCombo();
            fillInProductNameCombo();

            detailRequestOrderDataGridView.EditingControlShowing += detailRequestOrderDataGridView_EditingControlShowing;

            if (originModuleID == globalConstants.EDIT_REQUEST_ORDER)
            {
                isLoading = true;

                loadDataHeaderRO();
                selectedROInvoice = ROinvoiceTextBox.Text;
                ROinvoiceTextBox.ReadOnly = true;

                branchFromCombo.Text = getBranchName(selectedBranchFromID);
                branchToCombo.Text = getBranchName(selectedBranchToID);

                loadDataDetailRO();
                
                isLoading = false;
            }
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
            }
            else
            {
                errorLabel.Text = "";
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

        private void detailRequestOrderDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void branchToCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
                selectedBranchToID = Convert.ToInt32(branchToComboHidden.Items[branchToCombo.SelectedIndex].ToString());
        }

        private void detailRequestOrderDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private bool dataValidated()
        {
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

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

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
                                            "('" + roInvoice + "', " + branchIDFrom + ", " + branchIDTo + ", STR_TO_DATE('" + roDateTime + "', '%d-%m-%Y'), " + roTotal + ", STR_TO_DATE('" + roDateExpired + "', '%d-%m-%Y'), 1)";
                        DS.executeNonQueryCommand(sqlCommand);

                        // SAVE DETAIL TABLE
                        for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count; i++)
                        {
                            if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO REQUEST_ORDER_DETAIL (RO_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, RO_QTY, RO_SUBTOTAL) VALUES " +
                                                    "('" + roInvoice + "', '" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value) + ")";

                                DS.executeNonQueryCommand(sqlCommand);
                            }
                        }
                        break;

                    case globalConstants.EDIT_REQUEST_ORDER:
                        // UPDATE HEADER TABLE
                        sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET " +
                                            "RO_BRANCH_ID_FROM = " + branchIDFrom + ", " +
                                            "RO_BRANCH_ID_TO = " + branchIDTo + ", " +
                                            "RO_DATETIME = STR_TO_DATE('" + roDateTime + "', '%d-%m-%Y'), " +
                                            "RO_TOTAL = " + roTotal + ", " +
                                            "RO_EXPIRED = STR_TO_DATE('" + roDateExpired + "', '%d-%m-%Y') " +
                                            "WHERE RO_INVOICE = '" + roInvoice + "'";
                    
                        DS.executeNonQueryCommand(sqlCommand);

                        // DELETE DETAIL TABLE
                        sqlCommand = "DELETE FROM REQUEST_ORDER_DETAIL WHERE RO_INVOICE = '" + roInvoice + "'";
                        DS.executeNonQueryCommand(sqlCommand);

                        // RE-INSERT DETAIL TABLE
                        for (int i = 0; i < detailRequestOrderDataGridView.Rows.Count; i++)
                        {
                            if (null != detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value)
                            {
                                sqlCommand = "INSERT INTO REQUEST_ORDER_DETAIL (RO_INVOICE, PRODUCT_ID, PRODUCT_BASE_PRICE, RO_QTY, RO_SUBTOTAL) VALUES " +
                                                    "('" + roInvoice + "', '" + detailRequestOrderDataGridView.Rows[i].Cells["productID"].Value.ToString() + "', " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["hpp"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["qty"].Value) + ", " + Convert.ToDouble(detailRequestOrderDataGridView.Rows[i].Cells["subTotal"].Value) + ")";

                                DS.executeNonQueryCommand(sqlCommand);
                            }
                        }
                        break;
                }

                
                DS.commit();
            }
            catch (Exception e)
            {
                try
                {
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
                result = true;
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("SUCCESS");
            }
        }

        private void ROinvoiceTextBox_Validated(object sender, EventArgs e)
        {
            
        }

        private void detailRequestOrderDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
          //  if (e.GetHashCode() == Keys.Delete)
        }

        private void deleteCurrentRow()
        {
            if (detailRequestOrderDataGridView.SelectedCells.Count > 0)
            {
                int rowSelectedIndex = detailRequestOrderDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = detailRequestOrderDataGridView.Rows[rowSelectedIndex];    

                detailRequestOrderDataGridView.Rows.Remove(selectedRow);
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
    }
}
