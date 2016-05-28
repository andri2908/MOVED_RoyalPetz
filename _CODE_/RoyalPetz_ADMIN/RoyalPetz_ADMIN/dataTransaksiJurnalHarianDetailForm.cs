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
    public partial class dataTransaksiJurnalHarianDetailForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private int selectedDJID=0;
        private int selectedAccountID = 0;
        private int selectedTipeAkun = 0;
        private int selectedUserID = 0;
        private int options = 0;
        private Data_Access DS = new Data_Access();
        private Data_Access DS_2 = new Data_Access();
        private int originModuleID = 0;
        private bool upd_mode = false;
        int selectedrowindex = -1;
        public dataTransaksiJurnalHarianDetailForm()
        {
            InitializeComponent();
        }
        public dataTransaksiJurnalHarianDetailForm(int moduleID, int UserID)
        {
            selectedUserID = UserID;
            //originModuleID = moduleID;

            InitializeComponent();
        }

        private void loadtypeaccount()
        {
            carabayarcombobox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT PM_ID as 'ID', PM_NAME AS 'NAME' FROM PAYMENT_METHOD"))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    carabayarcombobox.DataSource = dt;
                    carabayarcombobox.ValueMember = "ID";
                    carabayarcombobox.DisplayMember = "NAME";
                }
            }
            carabayarcombobox.SelectedValue = 1;
        }

        private void LoadBranchInfo()
        {
            branchCombobox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT BRANCH_ID AS 'ID', BRANCH_NAME AS 'NAME' FROM MASTER_BRANCH WHERE BRANCH_ACTIVE=1"))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    DataRow workRow = dt.NewRow();
                    workRow["ID"] = "0";
                    workRow["NAME"] = "PUSAT";
                    dt.Rows.Add(workRow);
                    branchCombobox.DataSource = dt;
                    branchCombobox.ValueMember = "ID";
                    branchCombobox.DisplayMember = "NAME";
                }
            }
            //branchCombobox.Items.Add(new { Text = "PUSAT", Value = "0" });
            branchCombobox.SelectedValue = branchCombobox.Items.Count;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //addto datagridview
            if (dataValidated())
            {
                if (selectedrowindex == -1)
                {
                    upd_mode = false;
                }
                String nmakun = NamaAkunTextbox.Text;
                String deskripsiakun = DeskripsiAkunTextbox.Text;
                Double nominalakun = 0;
                String TglTrans = "";
                string jamTrans = "";
                //selectedDJID = 0;
                DateTime selectedDate = TanggalTransaksi.Value;
                String pembayaran = carabayarcombobox.GetItemText(carabayarcombobox.SelectedItem);
                String cabang = branchCombobox.GetItemText(branchCombobox.SelectedItem);
                int pm_id = Int32.Parse(carabayarcombobox.SelectedValue.ToString());
                int branch_id = Int32.Parse(branchCombobox.SelectedValue.ToString());
                //tryparse
                if (Double.TryParse(gutil.allTrim(NominalTextbox.Text), out nominalakun))
                {
                }
                else
                {
                    errorLabel.Text = "NOMINAL TIDAK BOLEH MENGANDUNG HURUF";
                }
                //check debet/credit
                if (nominalakun < 0) //memastikan input positif
                {
                    nominalakun = -nominalakun;
                }
                Double debet = nominalakun;
                Double credit = 0;
                if (selectedTipeAkun == 2) //credit
                {           
                    credit = -1 * nominalakun;
                    debet = 0;
                }
               
                TglTrans = String.Format(culture, "{0:dd-MM-yyyy}", selectedDate);
                jamTrans = String.Format(culture, "{0:HH:mm}", DateTime.Now);

                TglTrans = TglTrans + " " + jamTrans;
                //must add function to update content
                //bool newdata = true;
                //for (int rows = 0; rows < transaksiaccountgridview.rows.count; rows++)
                //{
                //    int tmp = int32.parse(transaksiaccountgridview.rows[rows].cells[8].value.tostring());
                //    if (tmp == selecteddjid)
                //    {
                //        //newdata = false;
                //        //update content datagridview
                //        transaksiaccountgridview.rows[rows].cells[7].value = deskripsiakun;
                //        transaksiaccountgridview.rows[rows].cells[6].value = credit;
                //        transaksiaccountgridview.rows[rows].cells[5].value = debet;
                //        transaksiaccountgridview.rows[rows].cells[4].value = pembayaran;
                //        transaksiaccountgridview.rows[rows].cells[3].value = pm_id;
                //        transaksiaccountgridview.rows[rows].cells[2].value = nmakun;
                //        transaksiaccountgridview.rows[rows].cells[1].value = selectedaccountid;
                //        transaksiaccountgridview.rows[rows].cells[0].value = tgltrans;
                //    }
                //}

                if (upd_mode == false)
                {
                    TransaksiAccountGridView.Rows.Add(selectedDJID, TglTrans, selectedAccountID, nmakun, branch_id, cabang, pm_id, pembayaran, debet, credit, deskripsiakun);
                } else
                {
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[10].Value = deskripsiakun;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[9].Value = credit;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[8].Value = debet;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[7].Value = pembayaran;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[6].Value = pm_id;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[5].Value = cabang;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[4].Value = branch_id;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[3].Value = nmakun;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[2].Value = selectedAccountID;
                    TransaksiAccountGridView.Rows[selectedrowindex].Cells[1].Value = TglTrans;
                }

                selectedrowindex = -1;
                saveButton.Text = "TAMBAH";

            }
        }

        public void addSelectedAccountID(int AccountID)
        {
            selectedAccountID = AccountID;
            //kodeAkunTextbox.Text = selectedAccountID.ToString();
        }

        private void loadDeskripsi(int accountID)
        {
            DeskripsiAkunTextbox.Text = "";

            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS_2.mySqlConnect();

            using (rdr = DS_2.getData("SELECT ACCOUNT_ID as 'ID', ACCOUNT_TYPE_ID AS 'TIPE', ACCOUNT_NAME AS 'NAME' FROM MASTER_ACCOUNT WHERE ACCOUNT_ID = '"+ selectedAccountID +"'"))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        NamaAkunTextbox.Text = rdr.GetString("NAME");
                        selectedTipeAkun = rdr.GetInt32("TIPE");
                    }
                }
            }
        }

        private bool dataAkunValidated()
        {
            if (NamaAkunTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "KODE AKUN TIDAK BOLEH KOSONG";
                return false;
            }

            return true;
        }

        private bool dataValidated()
        {
            if (NamaAkunTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "KODE AKUN TIDAK BOLEH KOSONG";
                return false;
            }
            if (DeskripsiAkunTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "DESKRIPSI TRANSAKSI TIDAK BOLEH KOSONG";
                return false;
            }
            if (NominalTextbox.Text.Trim().Equals(""))
            {
                errorLabel.Text = "NOMINAL TIDAK BOLEH KOSONG";
                return false;
            }

            //if (0 == getBranchID())
            //{
            //    errorLabel.Text = "BRANCH ID BELUM DI SET";
            //    return false;
            //}

            return true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            dataNomorAkun displayedForm = new dataNomorAkun(globalConstants.TAMBAH_HAPUS_JURNAL_HARIAN, this);
            displayedForm.ShowDialog(this);
            loadDeskripsi(selectedAccountID);
        }

        private void dataTransaksiJurnalHarianDetailForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
            TanggalTransaksi.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            loadtypeaccount();
            LoadBranchInfo();
            loadTransaksi();
        }

        private void dataTransaksiJurnalHarianDetailForm_Activated(object sender, EventArgs e)
        {
            //if need something
            errorLabel.Text = "";
            //TransaksiAccountGridView.Rows.Clear();
            //loadTransaksi();
        }

        private bool saveDataTransaction()
        {
            //commit to database
            bool result = false;
            string sqlCommand = "";
            MySqlException internalEX = null;

            int Account_ID = 0;
            String TglTrans = "";
            Double NominalAkun = 0;
            int branch_id = getBranchID();
            String deskripsi = "";
            int user_id = 0;
            int pm_id = 0;
            String deskripsiakun = "";

            //branch_id = getBranchID();

            for (int rows = 0; rows < TransaksiAccountGridView.Rows.Count; rows++)
            {
                TglTrans = String.Format(culture, "{0:dd-MM-yyyy HH:mm}", TransaksiAccountGridView.Rows[rows].Cells[1].Value.ToString());
                Account_ID = Int32.Parse(TransaksiAccountGridView.Rows[rows].Cells[2].Value.ToString());
                pm_id = Int32.Parse(TransaksiAccountGridView.Rows[rows].Cells[6].Value.ToString());
                Double debet, credit;
                if (Double.TryParse(TransaksiAccountGridView.Rows[rows].Cells[8].Value.ToString(), out debet))
                {
                }
                if (Double.TryParse(TransaksiAccountGridView.Rows[rows].Cells[9].Value.ToString(), out credit))
                {
                }
                if (debet == 0)
                {
                    //credit
                    NominalAkun = credit;
                }
                else
                {
                    NominalAkun = debet;
                }
                deskripsiakun = TransaksiAccountGridView.Rows[rows].Cells[10].Value.ToString();
                user_id = selectedUserID;
                selectedDJID = 0;
                selectedDJID = Int32.Parse(TransaksiAccountGridView.Rows[rows].Cells[0].Value.ToString());
                originModuleID = globalConstants.NEW_DJ;
                if (selectedDJID > 0)
                {
                    originModuleID = globalConstants.EDIT_DJ;
                }

                //for (int col = 0; col < TransaksiAccountGridView.Rows[rows].Cells.Count; col++)
                //{
                // string value = TransaksiAccountGridView.Rows[rows].Cells[col].Value.ToString();
                //}

                DS.beginTransaction();

                try
                {
                    DS.mySqlConnect();

                    switch (originModuleID)
                    {
                        case globalConstants.NEW_DJ:
                            sqlCommand = "INSERT INTO DAILY_JOURNAL (ACCOUNT_ID, JOURNAL_DATETIME, JOURNAL_NOMINAL, BRANCH_ID, JOURNAL_DESCRIPTION, USER_ID, PM_ID) " +
                                                "VALUES (" + Account_ID + ", STR_TO_DATE('" + TglTrans + "', '%d-%m-%Y %H:%i')" + ", '" + NominalAkun + "', '" + branch_id + "', '" + deskripsiakun + "', '" + user_id + "', " + pm_id + ")";
                            options = gutil.INS;
                            gutil.saveSystemDebugLog(globalConstants.MENU_TRANSAKSI_HARIAN, "INSERT NEW DATA TO DAILY JOURNAL TABLE ["+ Account_ID +", " + NominalAkun + "]");
                            break;
                        case globalConstants.EDIT_DJ:
                            sqlCommand = "UPDATE DAILY_JOURNAL SET " +
                                                "ACCOUNT_ID = " + Account_ID + ", " +
                                                "JOURNAL_DATETIME = " + "STR_TO_DATE('" + TglTrans + "', '%d-%m-%Y %H:%i')" + ", " +
                                                "JOURNAL_NOMINAL = '" + NominalAkun + "', " +
                                                "BRANCH_ID = '" + branch_id + "', " +
                                                "JOURNAL_DESCRIPTION = '" + deskripsiakun + "', " +
                                                "USER_ID = '" + user_id + "', " +
                                                "PM_ID = '" + pm_id + "' " +
                                                "WHERE JOURNAL_ID = '" + selectedDJID + "'";
                            options = gutil.UPD;
                            gutil.saveSystemDebugLog(globalConstants.MENU_TRANSAKSI_HARIAN, "UPDATE DATA ON DAILY JOURNAL TABLE [" + selectedDJID + "]");
                            break;
                    }

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

                    DS.commit();
                    result = true;
                }
                catch (Exception e)
                {
                    gutil.saveSystemDebugLog(globalConstants.MENU_TRANSAKSI_HARIAN, "EXCEPTION THROWN [" + e.Message + "]");
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
                    result = false;
                }
                finally
                {
                    DS.mySqlClose();
                }

            }

            return result;

        }

        private bool checkDataTransaksi(String datetimetrans)
        {
            MySqlDataReader rdr;
            string sqlCommand;
            DS.mySqlConnect();

            sqlCommand = "SELECT JOURNAL_ID as 'ID' FROM DAILY_JOURNAL WHERE journal_datetime >= STR_TO_DATE('"+datetimetrans+ " 00:00:00', '%d-%m-%Y %k:%i:%s') AND journal_datetime <= STR_TO_DATE('" + datetimetrans + " 23:59:59', '%d-%m-%Y %k:%i:%s')";
            //"SELECT JOURNAL_ID as 'ID' FROM DAILY_JOURNAL WHERE JOURNAL_DATETIME LIKE " + "STR_TO_DATE('" + datetimetrans + "', '%d-%m-%Y%')";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private int getBranchID()
        {
            int result = 0;
            int numOfRows = 0;

            numOfRows = Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM SYS_CONFIG WHERE ID = 2"));

            if (numOfRows > 0)
                result = Convert.ToInt32(DS.getDataSingleValue("SELECT IFNULL(BRANCH_ID, 0) FROM SYS_CONFIG WHERE ID = 2"));

            return result;
        }

        private void loadTransaksi()
        {
            //if change check db if there any transaction 
            DateTime selectedDate = TanggalTransaksi.Value;
            String TglTrans = String.Format(culture, "{0:dd-MM-yyyy}", selectedDate);
            int branch_id = 0;
            String cabang = "";
            string sqlCommand;
            String nmakun;
            String deskripsiakun;
            Double nominalakun;
            String pembayaran;
            int pm_id;
            Double debet;
            Double credit;
            if (checkDataTransaksi(TglTrans))
            {
                //modeupdate
                //originModuleID = globalConstants.EDIT_DJ;
                //reset and load data
                //loadtypeaccount();
                TanggalTransaksi.Value = selectedDate;
                MySqlDataReader rdr;

                //DS.mySqlConnect();
                sqlCommand = "SELECT JOURNAL_ID, ACCOUNT_ID, JOURNAL_NOMINAL, IFNULL(BRANCH_ID, 0) AS BRANCH_ID, JOURNAL_DESCRIPTION, USER_ID, PM_ID FROM DAILY_JOURNAL WHERE JOURNAL_DATETIME >= STR_TO_DATE('"+TglTrans+ " 00:00:00', '%d-%m-%Y %k:%i:%s') AND JOURNAL_DATETIME <= STR_TO_DATE('" + TglTrans + " 23:59:59', '%d-%m-%Y %k:%i:%s')";
                    //SELECT JOURNAL_ID as 'ID' FROM DAILY_JOURNAL WHERE 
                using (rdr = DS.getData(sqlCommand))
                {
                    if (rdr.HasRows)
                    {
                        gutil.saveSystemDebugLog(globalConstants.MENU_TRANSAKSI_HARIAN, "LOAD DATA TRANSAKSI");

                        while (rdr.Read())
                        {
                            //pasang ke datagridview
                            selectedDJID = rdr.GetInt32("JOURNAL_ID");
                            selectedAccountID = rdr.GetInt32("ACCOUNT_ID");
                            loadDeskripsi(selectedAccountID);
                            nmakun = NamaAkunTextbox.Text;
                            pm_id = rdr.GetInt32("PM_ID");
                            carabayarcombobox.SelectedValue = pm_id;
                            deskripsiakun = rdr.GetString("JOURNAL_DESCRIPTION");
                            DeskripsiAkunTextbox.Text = deskripsiakun;
                            nominalakun = 0;
                            pembayaran = carabayarcombobox.GetItemText(carabayarcombobox.SelectedItem);

                            branch_id = rdr.GetInt32("BRANCH_ID");
                            if (branch_id != 0)
                            {
                                branchCombobox.SelectedValue = branch_id;
                                cabang = branchCombobox.GetItemText(branchCombobox.SelectedItem);
                            }

                            nominalakun = rdr.GetDouble("JOURNAL_NOMINAL");

                            //check debet/credit
                            debet = nominalakun;
                            credit = 0;
                            if (selectedTipeAkun == 2) //credit
                            {
                                credit = nominalakun;
                                debet = 0;
                            }
                            if (debet>0)
                            {
                                NominalTextbox.Text = debet.ToString();
                            } else
                            {
                                nominalakun = -nominalakun;
                                NominalTextbox.Text = nominalakun.ToString();
                            }
                            TransaksiAccountGridView.Rows.Add(selectedDJID, TglTrans, selectedAccountID, nmakun, branch_id, cabang, pm_id, pembayaran, debet, credit, deskripsiakun);
                        }
                    }
                }
            }
            else
            {
                //modeinsert
                //originModuleID = globalConstants.NEW_DJ;
            }
        }

        private void TanggalTransaksi_ValueChanged(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
            TransaksiAccountGridView.Rows.Clear();
            loadTransaksi();
        }

        private bool CheckDJID(int djidinput)
        {
            MySqlDataReader rdr;

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT JOURNAL_ID as 'ID' FROM DAILY_JOURNAL WHERE JOURNAL_ID =" + djidinput))
            {
                if (rdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void TransaksiAccountGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //mode update cell
            saveButton.Text = "UBAH";
            String TglTrans = "";
            String deskripsi = "";
            int pm_id = 0;
            int branch_id = 0;
            Double NominalAkun = 0;
            String deskripsiakun = "";
            upd_mode = true;
            //selectedrowindex = TransaksiAccountGridView.SelectedCells[0].RowIndex;
            selectedrowindex = TransaksiAccountGridView.CurrentCell.RowIndex;

            DataGridViewRow selectedRow = TransaksiAccountGridView.Rows[selectedrowindex];
            selectedAccountID = Convert.ToInt32(selectedRow.Cells[2].Value);

                TglTrans = selectedRow.Cells[1].Value.ToString();
                selectedAccountID = Int32.Parse(selectedRow.Cells[2].Value.ToString());
                loadDeskripsi(selectedAccountID);
                if (Int32.TryParse(selectedRow.Cells[0].Value.ToString(), out selectedDJID))
                {
                    //if from db then DJ-ID not 0
                }
                pm_id = Int32.Parse(selectedRow.Cells[6].Value.ToString());
                carabayarcombobox.SelectedValue = pm_id;
                branch_id = Int32.Parse(selectedRow.Cells[4].Value.ToString());
                branchCombobox.SelectedValue = branch_id;
                Double debet, credit;
                if (Double.TryParse(selectedRow.Cells[8].Value.ToString(), out debet))
                {
                }
                if (Double.TryParse(selectedRow.Cells[9].Value.ToString(), out credit))
                {
                }
                if (debet == 0)
                {
                    //credit
                    NominalAkun = -credit;
                }
                else
                {
                    NominalAkun = debet;
                }
                NominalTextbox.Text = NominalAkun.ToString();
                deskripsiakun = selectedRow.Cells[10].Value.ToString();
                DeskripsiAkunTextbox.Text = deskripsiakun;
                //selectedDJID = Int32.Parse(selectedRow.Cells[0].Value.ToString());
            
       }

        private void commitButton_Click(object sender, EventArgs e)
        {
            gutil.saveSystemDebugLog(globalConstants.MENU_TRANSAKSI_HARIAN, "ATTEMPT TO SAVE DATA TRANSAKSI JURNAL HARIAN");
            if (saveDataTransaction())
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_TRANSAKSI_HARIAN, "DATA TRANSAKSI JURNAL HARIAN SAVED");
                gutil.saveUserChangeLog(globalConstants.MENU_TRANSAKSI_HARIAN, globalConstants.CHANGE_LOG_INSERT, "NEW DATA TRANSAKSI HARIAN");

                gutil.showSuccess(options);
                gutil.ResetAllControls(this);
                TransaksiAccountGridView.Rows.Clear();
                TransaksiAccountGridView.Refresh();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void NominalTextbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                NominalTextbox.SelectAll();
            });
        }
    }
}
