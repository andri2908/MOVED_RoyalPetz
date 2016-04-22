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
    public partial class messagingForm : Form
    {
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        
        public messagingForm()
        {
            InitializeComponent();
        }

        private bool pullDetailMessageAndSaveToTable(int moduleID, string sqlCommand)
        {
            MySqlDataReader rdr;
            string param1;
            string param2;
            bool newData = false;
            double jumlahPembayaran;
            string deskripsiPembayaran;

            string messageContent = "";
            string insertSQLCommand = "";
            string todayDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                using (rdr = DS.getData(sqlCommand))
                {
                    if (rdr.HasRows)
                    {
                        newData = true;
                        while (rdr.Read())
                        {
                            param1 = rdr.GetString("PARAM_1");
                            param2 = rdr.GetString("PARAM_2");

                            switch (moduleID)
                            {
                                case globalConstants.MENU_TRANSAKSI_PENJUALAN:
                                    messageContent = "SALES INVOICE [" + param1 + "] JATUH TEMPO TGL " + param2;
                                    break;

                                case globalConstants.MENU_PURCHASE_ORDER:
                                    messageContent = "PURCHASE ORDER [" + param1 + "] JATUH TEMPO TGL " + param2;
                                    break;

                                case globalConstants.MENU_PEMBAYARAN_PIUTANG:
                                    jumlahPembayaran = rdr.GetDouble("JUMLAH");
                                    deskripsiPembayaran = rdr.GetString("DESCRIPTION");

                                    messageContent = "PEMBAYARAN SALES INVOICE [" + param1 + "] [" + deskripsiPembayaran + "] SEBESAR " + jumlahPembayaran.ToString("C2", culture) + " JATUH TEMPO";
                                    break;

                                case globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER:
                                    jumlahPembayaran = rdr.GetDouble("JUMLAH");
                                    deskripsiPembayaran = rdr.GetString("DESCRIPTION");

                                    messageContent = "PEMBAYARAN PURCASE ORDER [" + param1 + "] [" + deskripsiPembayaran + "] SEBESAR " + jumlahPembayaran.ToString("C2", culture) + " JATUH TEMPO";
                                    break;

                                case globalConstants.MENU_REQUEST_ORDER:
                                    messageContent = "REQUEST ORDER [" + param1 + "] EXPIRED PADA TGL " + param2;
                                    break;

                                case globalConstants.MENU_PRODUK:
                                    messageContent = "PRODUCT_ID [" + param1 + "] SUDAH MENDEKATI LIMIT";
                                    break;
                            }

                            insertSQLCommand = "INSERT INTO MASTER_MESSAGE (STATUS, MODULE_ID, IDENTIFIER_NO, MSG_DATETIME_CREATED, MSG_CONTENT) " +
                                                         "VALUES " +
                                                         "(0, " + moduleID + ", '" + param1 + "', STR_TO_DATE('" + todayDate + "', '%d-%m-%Y'), '" + messageContent + "')";

                            DS.executeNonQueryCommand(insertSQLCommand);
                        }

                        DS.commit();
                    }
                }
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
                        gutil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gutil.showDBOPError(e, "INSERT");
            }
            finally
            {
                DS.mySqlClose();
            }
            return newData;
        }

        public bool pullMessageData()
        {
            int moduleID = 0;
            string sqlCommand = "";
            string dateToday = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(DateTime.Now));
            string roExpiredDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now.AddDays(7));
            bool newData = false;

            // PULL SALES INVOICE THAT'S DUE TODAY
            moduleID = globalConstants.MENU_TRANSAKSI_PENJUALAN;
            sqlCommand = "SELECT SALES_INVOICE AS 'PARAM_1', DATE_FORMAT(SALES_TOP_DATE, '%d-%M-%Y') AS 'PARAM_2' FROM SALES_HEADER WHERE SALES_PAID = 0 AND DATE_FORMAT(SALES_TOP_DATE, '%Y%m%d')  <= '" + dateToday + "' AND SALES_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            newData  |= pullDetailMessageAndSaveToTable(moduleID, sqlCommand);

            // PULL PURCHASE INVOICE THAT'S DUE TODAY
            moduleID = globalConstants.MENU_PURCHASE_ORDER;
            sqlCommand = "SELECT PURCHASE_INVOICE AS 'PARAM_1', DATE_FORMAT(PURCHASE_TERM_OF_PAYMENT_DATE, '%d-%M-%Y') AS 'PARAM_2' FROM PURCHASE_HEADER WHERE PURCHASE_PAID = 0 AND PURCHASE_RECEIVED = 1 AND DATE_FORMAT(PURCHASE_TERM_OF_PAYMENT_DATE, '%Y%m%d')  <= '" + dateToday + "'  AND PURCHASE_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            newData |= pullDetailMessageAndSaveToTable(moduleID, sqlCommand);

            // PULL PAYMENT CREDIT THAT'S DUE TODAY
            moduleID = globalConstants.MENU_PEMBAYARAN_PIUTANG;
            sqlCommand = "SELECT SH.SALES_INVOICE AS 'PARAM_1', DATE_FORMAT(PC.PAYMENT_DUE_DATE, '%d-%M-%Y') AS 'PARAM_2', PC.PAYMENT_NOMINAL AS 'JUMLAH', PC.PAYMENT_DESCRIPTION AS 'DESCRIPTION' FROM SALES_HEADER SH, CREDIT C, PAYMENT_CREDIT PC WHERE C.CREDIT_PAID = 0 AND PC.CREDIT_ID = C.CREDIT_ID AND C.SALES_INVOICE = SH.SALES_INVOICE AND PC.PAYMENT_CONFIRMED = 0 AND PC.PAYMENT_INVALID = 0 AND DATE_FORMAT(PC.PAYMENT_DUE_DATE, '%Y%m%d')  <= '" + dateToday + "'  AND SH.SALES_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            newData |= pullDetailMessageAndSaveToTable(moduleID, sqlCommand);

            // PULL PAYMENT DEBT THAT'S DUE TODAY
            moduleID = globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER;
            sqlCommand = "SELECT PH.PURCHASE_INVOICE AS 'PARAM_1', DATE_FORMAT(PD.PAYMENT_DUE_DATE, '%d-%M-%Y') AS 'PARAM_2', PD.PAYMENT_NOMINAL AS 'JUMLAH', PD.PAYMENT_DESCRIPTION AS 'DESCRIPTION' FROM PURCHASE_HEADER PH, DEBT D, PAYMENT_DEBT PD WHERE D.DEBT_PAID = 0 AND PD.DEBT_ID = D.DEBT_ID AND D.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PD.PAYMENT_CONFIRMED = 0 AND PD.PAYMENT_INVALID = 0 AND DATE_FORMAT(PD.PAYMENT_DUE_DATE, '%Y%m%d')  <= '" + dateToday + "'   AND PH.PURCHASE_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            newData |= pullDetailMessageAndSaveToTable(moduleID, sqlCommand);

            // PULL REQUEST ORDER THAT'LL EXPIRE NEXT WEEK OR EARLIER
            moduleID = globalConstants.MENU_REQUEST_ORDER;
            sqlCommand = "SELECT RO_INVOICE AS 'PARAM_1', DATE_FORMAT(RO_EXPIRED, '%d-%M-%Y') AS 'PARAM_2' FROM REQUEST_ORDER_HEADER WHERE RO_ACTIVE = 1 AND DATE_FORMAT(RO_EXPIRED, '%Y%m%d')  <= '" + roExpiredDate + "'  AND RO_INVOICE NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            newData |= pullDetailMessageAndSaveToTable(moduleID, sqlCommand);

            // PULL PRODUCT_ID THAT ALREADY HIT LIMIT STOCK
            moduleID = globalConstants.MENU_PRODUK;
            sqlCommand = "SELECT PRODUCT_ID AS 'PARAM_1', PRODUCT_LIMIT_STOCK AS 'PARAM_2' FROM  MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_IS_SERVICE = 0 AND PRODUCT_STOCK_QTY <= PRODUCT_LIMIT_STOCK AND PRODUCT_ID NOT IN (SELECT IDENTIFIER_NO FROM MASTER_MESSAGE WHERE MODULE_ID = " + moduleID + " AND STATUS = 0)";
            newData |= pullDetailMessageAndSaveToTable(moduleID, sqlCommand);

            return newData;                
        }

        private bool checkNewData()
        {
            bool newData = false;

            return newData;
        }

        private void loadMessageData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "SELECT MM.ID, M.MODULE_ID, M.MODULE_NAME, MM.IDENTIFIER_NO AS IDENTIFIER_NO, MSG_CONTENT AS MESSAGE FROM MASTER_MESSAGE MM, MASTER_MODULE M WHERE MM.STATUS = 0 AND MM.MODULE_ID = M.MODULE_ID ORDER BY MM.ID";

            using (rdr = DS.getData(sqlCommand))
            {
                messageDataGridView.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    messageDataGridView.DataSource = dt;
                    messageDataGridView.Columns["MODULE_ID"].Visible = false;
                    messageDataGridView.Columns["ID"].Visible = false;
                    messageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        private void displaySpecificForm(int moduleID, string identifierNo)
        {
            int productID = 0;
            switch (moduleID)
            {
                case globalConstants.MENU_TRANSAKSI_PENJUALAN:
                    pembayaranPiutangForm displayPiutangForm = new pembayaranPiutangForm(identifierNo);
                    displayPiutangForm.ShowDialog(this);
                    break;

                case globalConstants.MENU_PURCHASE_ORDER:
                    pembayaranHutangForm displayHutangForm = new pembayaranHutangForm(identifierNo);
                    displayHutangForm.ShowDialog(this);
                    break;

                case globalConstants.MENU_PEMBAYARAN_PIUTANG:
                    pembayaranPiutangForm displayPiutangFormConfirm = new pembayaranPiutangForm(identifierNo);
                    displayPiutangFormConfirm.ShowDialog(this);
                    break;

                case globalConstants.MENU_PEMBAYARAN_HUTANG_SUPPLIER:
                    pembayaranHutangForm displayHutangFormConfirm = new pembayaranHutangForm(identifierNo);
                    displayHutangFormConfirm.ShowDialog(this);
                    break;

                case globalConstants.MENU_REQUEST_ORDER:
                    dataMutasiBarangDetailForm displayedForm = new dataMutasiBarangDetailForm(globalConstants.CEK_DATA_MUTASI, identifierNo);
                    displayedForm.ShowDialog(this);
                    break;

                case globalConstants.MENU_PRODUK:
                    productID = Convert.ToInt32(DS.getDataSingleValue("SELECT ID FROM MASTER_PRODUCT WHERE PRODUCT_ID = '"+identifierNo+"'"));
                    dataProdukDetailForm displayProdukDetail = new dataProdukDetailForm(globalConstants.EDIT_PRODUK, productID);
                    displayProdukDetail.ShowDialog(this);
                    break;
            }
        }

        private void messagingForm_Load(object sender, EventArgs e)
        {
            pleaseWaitForm pleaseWait = new pleaseWaitForm();
            pleaseWait.Show();

            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();

            pullMessageData();

            pleaseWait.Close();


            loadMessageData();
        }
       
        private void setReadMenu_Click(object sender, EventArgs e)
        {
            string selectedID= "";
            string sqlCommand;
            string todayDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            if (messageDataGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = messageDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = messageDataGridView.Rows[rowSelectedIndex];

            selectedRow.DefaultCellStyle.BackColor = Color.Red;

            if (DialogResult.Yes == MessageBox.Show("SET TO READ ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                selectedID = selectedRow.Cells["ID"].Value.ToString();

                DS.beginTransaction();

                try
                {
                    DS.mySqlConnect();
                    sqlCommand = "UPDATE MASTER_MESSAGE SET STATUS = 1, MSG_DATETIME_READ = STR_TO_DATE('" + todayDate + "', '%d-%m-%Y'), MSG_READ_USER_ID = " + gutil.getUserID() + " WHERE ID = " + selectedID;

                    DS.executeNonQueryCommand(sqlCommand);
                    DS.commit();

                    loadMessageData();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("UPDATE FAILED ["+ex.Message+"]");
                }
            }
            else
                selectedRow.DefaultCellStyle.BackColor = Color.White;
        }

        private void setAllReadMenu_Click(object sender, EventArgs e)
        {
            string selectedID = "";
            string sqlCommand;
            string todayDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            if (messageDataGridView.Rows.Count <= 0)
                return;

            if (DialogResult.Yes == MessageBox.Show("SET ALL TO READ ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                DS.beginTransaction();

                try
                {
                    DS.mySqlConnect();

                    for (int i = 0; i < messageDataGridView.Rows.Count; i++)
                    {
                        selectedID = messageDataGridView.Rows[i].Cells["ID"].Value.ToString();

                        sqlCommand = "UPDATE MASTER_MESSAGE SET STATUS = 1, MSG_DATETIME_READ = STR_TO_DATE('" + todayDate + "', '%d-%m-%Y'), MSG_READ_USER_ID = " + gutil.getUserID() + " WHERE ID = " + selectedID;
                        DS.executeNonQueryCommand(sqlCommand);
                    }
                    DS.commit();
                    loadMessageData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("UPDATE FAILED [" + ex.Message + "]");
                }
            }

        }

        private void messageDataGridView_DoubleClick(object sender, EventArgs e)
        {
            string selectedID = "";
            string selectedIdentifier = "";
            int selectedModuleID = 0;
            string sqlCommand;
            string todayDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            if (messageDataGridView.Rows.Count <= 0)
                return;

            int rowSelectedIndex = messageDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = messageDataGridView.Rows[rowSelectedIndex];

            selectedRow.DefaultCellStyle.BackColor = Color.Red;

            if (DialogResult.Yes == MessageBox.Show("PROCESS MESSAGE ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                selectedID = selectedRow.Cells["ID"].Value.ToString();
                selectedIdentifier = selectedRow.Cells["IDENTIFIER_NO"].Value.ToString();
                selectedModuleID = Convert.ToInt32(selectedRow.Cells["MODULE_ID"].Value);

                displaySpecificForm(selectedModuleID, selectedIdentifier);

                DS.beginTransaction();

                try
                {
                    DS.mySqlConnect();
                    sqlCommand = "UPDATE MASTER_MESSAGE SET STATUS = 1, MSG_DATETIME_READ = STR_TO_DATE('" + todayDate + "', '%d-%m-%Y'), MSG_READ_USER_ID = " + gutil.getUserID() + " WHERE ID = " + selectedID;

                    DS.executeNonQueryCommand(sqlCommand);
                    DS.commit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("UPDATE FAILED [" + ex.Message + "]");
                }

                selectedRow.DefaultCellStyle.BackColor = Color.White;
                loadMessageData();
            }
            else
                selectedRow.DefaultCellStyle.BackColor = Color.White;

            
        }

        private void messageDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            string selectedID = "";
            string selectedIdentifier = "";
            int selectedModuleID = 0;
            string sqlCommand;
            string todayDate = String.Format(culture, "{0:dd-MM-yyyy}", DateTime.Now);

            if (messageDataGridView.Rows.Count <= 0)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                int rowSelectedIndex = messageDataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = messageDataGridView.Rows[rowSelectedIndex];

                selectedRow.DefaultCellStyle.BackColor = Color.Red;

                if (DialogResult.Yes == MessageBox.Show("PROCESS MESSAGE ? ", "KONFIRMASI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    selectedID = selectedRow.Cells["ID"].Value.ToString();
                    selectedIdentifier = selectedRow.Cells["IDENTIFIER_NO"].Value.ToString();
                    selectedModuleID = Convert.ToInt32(selectedRow.Cells["MODULE_ID"].Value);

                    displaySpecificForm(selectedModuleID, selectedIdentifier);

                    DS.beginTransaction();

                    try
                    {
                        DS.mySqlConnect();
                        sqlCommand = "UPDATE MASTER_MESSAGE SET STATUS = 1, MSG_DATETIME_READ = STR_TO_DATE('" + todayDate + "', '%d-%m-%Y'), MSG_READ_USER_ID = " + gutil.getUserID() + " WHERE ID = " + selectedID;

                        DS.executeNonQueryCommand(sqlCommand);
                        DS.commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("UPDATE FAILED [" + ex.Message + "]");
                    }
                    selectedRow.DefaultCellStyle.BackColor = Color.White;
                    loadMessageData();
                }
                else
                    selectedRow.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
