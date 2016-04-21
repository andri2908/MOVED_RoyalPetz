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
    public partial class dataMutasiBarangForm : Form
    {
        private int originModuleID = 0;
        private string selectedROID;
        private int selectedBranchFromID = 0;
        private int selectedBranchToID = 0;
        private string selectedPMID;
        private CultureInfo culture = new CultureInfo("id-ID");
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private Form parentForm;

        public dataMutasiBarangForm()
        {
            InitializeComponent();
        }

        public dataMutasiBarangForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;

            if (moduleID != globalConstants.CEK_DATA_MUTASI)
                newButton.Visible = false;
        }

        public dataMutasiBarangForm(int moduleID, Form originForm)
        {
            InitializeComponent();
            originModuleID = moduleID;
            parentForm = originForm;

            if (moduleID != globalConstants.CEK_DATA_MUTASI)
                newButton.Visible = false;
        }

        private void displaySpecificForm(string PMInvoice = "")
        {
            int subModuleID;
            switch (originModuleID)
            {
                case globalConstants.CEK_DATA_MUTASI:
                    if (!PMInvoice.Equals(""))
                        subModuleID = globalConstants.VIEW_PRODUCT_MUTATION;
                    else
                        subModuleID = globalConstants.MUTASI_BARANG;

                        dataMutasiBarangDetailForm displayedForm = new dataMutasiBarangDetailForm(subModuleID, PMInvoice);
                        displayedForm.ShowDialog(this);
                    break;

                case globalConstants.PENERIMAAN_BARANG:
                    if (null != parentForm)
                    {
                        penerimaanBarangForm originForm = (penerimaanBarangForm)parentForm;
                        originForm.setSelectedMutasi(PMInvoice);
                    }
                    this.Close();
                    //penerimaanBarangForm penerimaanBarangDisplayedForm = new penerimaanBarangForm(globalConstants.PENERIMAAN_BARANG_DARI_MUTASI, selectedROID);
                    //penerimaanBarangDisplayedForm.ShowDialog(this);
                    break;
            }

            loadROdata();
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataRequestOrderGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = dataRequestOrderGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataRequestOrderGridView.Rows[rowSelectedIndex];
            selectedROID = selectedRow.Cells["NO MUTASI"].Value.ToString();

            displaySpecificForm(selectedROID);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            displaySpecificForm();
        }

        private void loadROdata()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string dateFrom;
            string dateTo;
            string noMutasiParam = "";

            DS.mySqlConnect();

            //sqlCommand = "SELECT ID, PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM_DATETIME,'%d-%M-%Y') AS 'TGL MUTASI', M1.BRANCH_NAME AS 'ASAL MUTASI', M2.BRANCH_NAME AS 'TUJUAN MUTASI', PM_TOTAL AS 'TOTAL', RO_INVOICE AS 'NO PERMINTAAN' " +
            //                    "FROM PRODUCTS_MUTATION_HEADER LEFT OUTER JOIN MASTER_BRANCH M1 ON (BRANCH_ID_FROM = M1.BRANCH_ID) " +
            //                    "LEFT OUTER JOIN MASTER_BRANCH M2 ON (BRANCH_ID_TO = M2.BRANCH_ID) " +
            //                    "WHERE 1 = 1 AND PM_RECEIVED = 0";
            sqlCommand = "SELECT ID, PM_INVOICE AS 'NO MUTASI', DATE_FORMAT(PM_DATETIME,'%d-%M-%Y') AS 'TGL MUTASI', M2.BRANCH_NAME AS 'TUJUAN MUTASI', PM_TOTAL AS 'TOTAL', RO_INVOICE AS 'NO PERMINTAAN' " +
                                "FROM PRODUCTS_MUTATION_HEADER PH,  MASTER_BRANCH M2 " +//LEFT OUTER JOIN MASTER_BRANCH M2 ON (BRANCH_ID_TO = M2.BRANCH_ID) " +
                                "WHERE 1 = 1 AND PH.BRANCH_ID_TO = M2.BRANCH_ID AND PM_RECEIVED = 0";

            if (!showAllCheckBox.Checked)
            {
                if (noMutasiTextBox.Text.Length > 0)
                {
                    noMutasiParam = MySqlHelper.EscapeString(noMutasiTextBox.Text);
                    sqlCommand = sqlCommand + " AND PM_INVOICE LIKE '%" + noMutasiParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PMDtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PMDtPicker_2.Value));
                sqlCommand = sqlCommand + " AND DATE_FORMAT(PM_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PM_DATETIME, '%Y%m%d')  <= '" + dateTo + "'";

                //if (branchFromCombo.Text.Length > 0)
                //{
                //    sqlCommand = sqlCommand + " AND BRANCH_ID_FROM = " + selectedBranchFromID;
                //}

                if (branchToCombo.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + " AND BRANCH_ID_TO = " + selectedBranchToID;
                }
            }
                
            sqlCommand = sqlCommand + " ORDER BY PM_DATETIME ASC";                                

            using (rdr = DS.getData(sqlCommand))
            {
                dataRequestOrderGridView.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataRequestOrderGridView.DataSource = dt;

                    dataRequestOrderGridView.Columns["ID"].Visible = false;

                    dataRequestOrderGridView.Columns["NO MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["TGL MUTASI"].Width = 200;
                    //dataRequestOrderGridView.Columns["ASAL MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["TUJUAN MUTASI"].Width = 200;
                    dataRequestOrderGridView.Columns["TOTAL"].Width = 200;
                    dataRequestOrderGridView.Columns["NO PERMINTAAN"].Width = 200;
                }

                rdr.Close();
            }


        }

        private void dataMutasiBarangForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[3];

            PMDtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PMDtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            fillInBranchCombo(branchToCombo, branchToComboHidden);

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_TAMBAH_MUTASI_BARANG, gutil.getUserGroupID());

            if (userAccessOption == 2 || userAccessOption == 6)
            { 
                newButton.Visible = true;
                importButton.Visible = true;
            }
            else
            {
                newButton.Visible = false;
                importButton.Visible = false;
            }

            if (originModuleID == globalConstants.PENERIMAAN_BARANG)
            { 
                newButton.Visible = false;
                showAllCheckBox.Visible = false;
            }

            arrButton[0] = displayButton;
            arrButton[1] = newButton;
            arrButton[2] = importButton;
            gutil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gutil.reArrangeTabOrder(this);
        }

        private void dataMutasiBarangForm_Deactivate(object sender, EventArgs e)
        {

        }

        private void dataMutasiBarangForm_Activated(object sender, EventArgs e)
        {
            loadROdata();
            //fillInBranchCombo(branchFromCombo, branchFromComboHidden);
            //fillInBranchCombo(branchToCombo, branchToComboHidden);
        }

        private void dataRequestOrderGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dataRequestOrderGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (dataRequestOrderGridView.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = dataRequestOrderGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataRequestOrderGridView.Rows[rowSelectedIndex];
                selectedROID = selectedRow.Cells["NO MUTASI"].Value.ToString();

                displaySpecificForm(selectedROID);
            }
        }

        private void fillInBranchCombo(ComboBox visibleCombo, ComboBox hiddenCombo)
        {
            MySqlDataReader rdr;
            string sqlCommand = "";

            sqlCommand = "SELECT BRANCH_ID, BRANCH_NAME FROM MASTER_BRANCH WHERE BRANCH_ACTIVE = 1 ORDER BY BRANCH_NAME ASC";

            visibleCombo.Items.Clear();
            hiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    visibleCombo.Items.Add(rdr.GetString("BRANCH_NAME"));
                    hiddenCombo.Items.Add(rdr.GetString("BRANCH_ID"));
                }
            }

            rdr.Close();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            loadROdata();
        }

        private void branchFromCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchFromID = Convert.ToInt32(branchFromComboHidden.Items[branchFromCombo.SelectedIndex]);
        }

        private void branchToCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBranchToID = Convert.ToInt32(branchToComboHidden.Items[branchToCombo.SelectedIndex]);
        }

        private bool noPMExist(string roInvoiceValue)
        {
            bool result = false;

            if (0 < Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM PRODUCTS_MUTATION_HEADER WHERE PM_INVOICE = '" + roInvoiceValue + "'")))
                result = true;

            return result;
        }

        private int getBranchID()
        {
            int result = 0;
            int dataCount = 0;

            dataCount = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM SYS_CONFIG"));
            if (dataCount > 1)
            {
                result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(BRANCH_ID, 0) FROM SYS_CONFIG WHERE ID = 2"));
            }
            else
                MessageBox.Show("DATA CABANG BELUM DISET");

            return result;
        }

        private bool loadImportedDataPM(string fileName)
        {
            bool result = false;
            string sqlCommand = "";
            string pmInvoice = "";
            //bool checkForRO = true;
            //int lastPos = 0;
            //int prevPos = 0;
            //int firstPos = 0;
            string roInvoice = "";
            string tempString = "";
            int importedBranchID = 0;
            int storedBranchID = 0;
            MySqlException internalEX = null;

            DS.beginTransaction();
            
            try
            {
                DS.mySqlConnect();

                System.IO.StreamReader file = new System.IO.StreamReader(fileName);

                pmInvoice = file.ReadLine();
                roInvoice = file.ReadLine();
                tempString = file.ReadLine(); ;
                if (int.TryParse(tempString, out importedBranchID))
                {
                    storedBranchID = getBranchID();
                    if (storedBranchID != importedBranchID)
                    {
                        file.Close();
                        throw new Exception("INFORMASI BRANCH ID TIDAK SESUAI");
                    }
                }
                else
                {
                    //MessageBox.Show("INFORMASI BRANCH ID TIDAK DITEMUKAN");

                    file.Close();
                    throw new Exception("INFORMASI BRANCH ID TIDAK DITEMUKAN");
                }

                if (!noPMExist(pmInvoice))
                {
                    while ((sqlCommand = file.ReadLine()) != null)
                    {
                        //if (checkForRO)
                        //{
                        //    tempString = sqlCommand;
                        //    // GET RO_INVOICE
                        //    if (sqlCommand.LastIndexOf("RO_INVOICE") > 0) 
                        //    {
                        //        lastPos = sqlCommand.LastIndexOf("',");
                        //        prevPos = sqlCommand.LastIndexOf(", '", lastPos - 1);
                        //        roInvoice = sqlCommand.Substring(prevPos+3, lastPos - prevPos-3);
                        //    }

                        //    // GET BRANCH_ID
                        //    if (sqlCommand.IndexOf("BRANCH_ID_TO") > 0)
                        //    {
                        //        firstPos = tempString.IndexOf("('");
                        //        tempString = tempString.Substring(firstPos);

                        //        firstPos = tempString.IndexOf(",");
                        //        tempString = tempString.Substring(firstPos+1);

                        //        firstPos = tempString.IndexOf(",");
                        //        tempString = tempString.Substring(firstPos + 1);

                        //        firstPos = tempString.IndexOf(",");
                        //        tempString = tempString.Substring(1, firstPos-1);

                        //        if (int.TryParse(tempString, out importedBranchID))
                        //        {
                        //            storedBranchID = getBranchID();

                        //            if (storedBranchID != importedBranchID)
                        //            {
                        //                //MessageBox.Show("INFORMASI BRANCH ID TIDAK SESUAI");

                        //                file.Close();
                        //                throw new Exception("INFORMASI BRANCH ID TIDAK SESUAI");
                        //            }
                        //        }
                        //        else
                        //        {
                        //            //MessageBox.Show("INFORMASI BRANCH ID TIDAK DITEMUKAN");

                        //            file.Close();
                        //            throw new Exception("INFORMASI BRANCH ID TIDAK DITEMUKAN");
                        //        }
                        //    }

                        //}
                        //checkForRO = false;
                        if (DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;
                    }

                    file.Close();

                    if (roInvoice.Length > 0)
                    {
                        sqlCommand = "UPDATE REQUEST_ORDER_HEADER SET RO_ACTIVE = 0 WHERE RO_INVOICE = '" + roInvoice + "'";
                        if (DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;
                    }

                    DS.commit();

                    result = true;
                }
                else
                {
                    file.Close();
                    //MessageBox.Show("NOMOR MUTASI SUDAH ADA");
                    throw new Exception("NOMOR MUTASI SUDAH ADA");    
                }

            }
            catch (Exception e)
            {
                result = false;
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

                MessageBox.Show(e.Message);
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            string importFileName = "";

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Export File (.exp)|*.exp";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    importFileName = openFileDialog1.FileName;
                    if (loadImportedDataPM(importFileName))
                    {
                        loadROdata();
                    }
                    else
                        MessageBox.Show("ERROR LOADING FILE");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }


    }
}
