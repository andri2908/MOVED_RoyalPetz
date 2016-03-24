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

        private void saveButton_Click(object sender, EventArgs e)
        {
            //addto datagridview
            if (dataValidated())
            {
                String nmakun = NamaAkunTextbox.Text;
                String deskripsiakun = DeskripsiAkunTextbox.Text;
                Double nominalakun = 0;
                String TglTrans = "";
                //selectedDJID = 0;
                DateTime selectedDate = TanggalTransaksi.Value;
                String pembayaran = carabayarcombobox.GetItemText(carabayarcombobox.SelectedItem);
                int pm_id = Int32.Parse(carabayarcombobox.SelectedValue.ToString());
                //tryparse
                if (Double.TryParse(NominalTextbox.Text, out nominalakun))
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

                //must add function to update content
                bool newdata = true;
                for (int rows = 0; rows < TransaksiAccountGridView.Rows.Count; rows++)
                {
                    int tmp = Int32.Parse(TransaksiAccountGridView.Rows[rows].Cells[8].Value.ToString());
                    if (tmp == selectedDJID)
                    {
                        newdata = false;
                        //update content datagridview
                        TransaksiAccountGridView.Rows[rows].Cells[7].Value = deskripsiakun;
                        TransaksiAccountGridView.Rows[rows].Cells[6].Value = credit;
                        TransaksiAccountGridView.Rows[rows].Cells[5].Value = debet;
                        TransaksiAccountGridView.Rows[rows].Cells[4].Value = pembayaran;
                        TransaksiAccountGridView.Rows[rows].Cells[3].Value = pm_id;
                        TransaksiAccountGridView.Rows[rows].Cells[2].Value = nmakun;
                        TransaksiAccountGridView.Rows[rows].Cells[1].Value = selectedAccountID;
                        TransaksiAccountGridView.Rows[rows].Cells[0].Value = TglTrans;
                    }
                }

                if (newdata)
                {
                    TransaksiAccountGridView.Rows.Add(TglTrans, selectedAccountID, nmakun, pm_id, pembayaran, debet, credit, deskripsiakun, selectedDJID);
                }
                
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
            return true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //dataNomorAkun displayedForm = new dataNomorAkun(globalConstants.TAMBAH_HAPUS_JURNAL_HARIAN,this);
            //displayedForm.ShowDialog(this);
            //loadDeskripsi(selectedAccountID);
        }

        private void dataTransaksiJurnalHarianDetailForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
            TanggalTransaksi.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            loadtypeaccount();
        }

        private void dataTransaksiJurnalHarianDetailForm_Activated(object sender, EventArgs e)
        {
            //if need something
            errorLabel.Text = "";
            //TransaksiAccountGridView.Rows.Clear();
            //loadTransaksi();
        }

        private void kodeAkunTextbox_TextChanged(object sender, EventArgs e)
        {
          
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
            int branch_id = 0;
            String deskripsi = "";
            int user_id = 0;
            int pm_id = 0;
            String deskripsiakun = "";
            for (int rows = 0; rows < TransaksiAccountGridView.Rows.Count; rows++)
            {
                TglTrans = String.Format(culture, "{0:dd-MM-yyyy}", TransaksiAccountGridView.Rows[rows].Cells[0].Value.ToString());
                Account_ID = Int32.Parse(TransaksiAccountGridView.Rows[rows].Cells[1].Value.ToString());
                pm_id = Int32.Parse(TransaksiAccountGridView.Rows[rows].Cells[3].Value.ToString());
                Double debet, credit;
                if (Double.TryParse(TransaksiAccountGridView.Rows[rows].Cells[5].Value.ToString(), out debet))
                {
                }
                if (Double.TryParse(TransaksiAccountGridView.Rows[rows].Cells[6].Value.ToString(), out credit))
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
                deskripsiakun = TransaksiAccountGridView.Rows[rows].Cells[7].Value.ToString();
                user_id = selectedUserID;
                selectedDJID = 0;
                selectedDJID = Int32.Parse(TransaksiAccountGridView.Rows[rows].Cells[8].Value.ToString());
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
                                                "VALUES (" + Account_ID + ", STR_TO_DATE('" + TglTrans + "', '%d-%m-%Y')" + ", '" + NominalAkun + "', '" + branch_id + "', '" + deskripsiakun + "', '" + user_id + "', " + pm_id + ")";
                            options = gutil.INS;
                            break;
                        case globalConstants.EDIT_DJ:
                            sqlCommand = "UPDATE DAILY_JOURNAL SET " +
                                                "ACCOUNT_ID = " + Account_ID + ", " +
                                                "JOURNAL_DATETIME = " + "STR_TO_DATE('" + TglTrans + "', '%d-%m-%Y')" + ", " +
                                                "JOURNAL_NOMINAL = '" + NominalAkun + "', " +
                                                "BRANCH_ID = '" + branch_id + "', " +
                                                "JOURNAL_DESCRIPTION = '" + deskripsiakun + "', " +
                                                "USER_ID = '" + user_id + "', " +
                                                "PM_ID = '" + pm_id + "' " +
                                                "WHERE JOURNAL_ID = '" + selectedDJID + "'";
                            options = gutil.UPD;
                            break;
                    }

                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                        throw internalEX;

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

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT JOURNAL_ID as 'ID' FROM DAILY_JOURNAL WHERE JOURNAL_DATETIME = " + "STR_TO_DATE('" + datetimetrans + "', '%d-%m-%Y')"))
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

        private void loadTransaksi()
        {
            //if change check db if there any transaction 
            DateTime selectedDate = TanggalTransaksi.Value;
            String TglTrans = String.Format(culture, "{0:dd-MM-yyyy}", selectedDate);
            if (checkDataTransaksi(TglTrans))
            {
                //modeupdate
                //originModuleID = globalConstants.EDIT_DJ;
                //reset and load data
                //loadtypeaccount();
                TanggalTransaksi.Value = selectedDate;
                MySqlDataReader rdr;

                DS.mySqlConnect();

                using (rdr = DS.getData("SELECT JOURNAL_ID, ACCOUNT_ID, JOURNAL_NOMINAL, BRANCH_ID, JOURNAL_DESCRIPTION, USER_ID, PM_ID FROM DAILY_JOURNAL WHERE JOURNAL_DATETIME = " + "STR_TO_DATE('" + TglTrans + "', '%d-%m-%Y')"))
                {
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            //pasang ke datagridview
                            selectedDJID = rdr.GetInt32("JOURNAL_ID");
                            selectedAccountID = rdr.GetInt32("ACCOUNT_ID");
                            loadDeskripsi(selectedAccountID);
                            String nmakun = NamaAkunTextbox.Text;
                            int pm_id = rdr.GetInt32("PM_ID");
                            carabayarcombobox.SelectedValue = pm_id;
                            String deskripsiakun = rdr.GetString("JOURNAL_DESCRIPTION");
                            DeskripsiAkunTextbox.Text = deskripsiakun;
                            Double nominalakun = 0;
                            String pembayaran = carabayarcombobox.GetItemText(carabayarcombobox.SelectedItem);
                            nominalakun = rdr.GetDouble("JOURNAL_NOMINAL");
                            //check debet/credit
                            Double debet = nominalakun;
                            Double credit = 0;
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
                            TransaksiAccountGridView.Rows.Add(TglTrans, selectedAccountID, nmakun, pm_id, pembayaran, debet, credit, deskripsiakun, selectedDJID);
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
            String TglTrans = "";
            String deskripsi = "";
            int pm_id = 0;
            Double NominalAkun = 0;
            String deskripsiakun = "";

            int selectedrowindex = TransaksiAccountGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = TransaksiAccountGridView.Rows[selectedrowindex];
            selectedAccountID = Convert.ToInt32(selectedRow.Cells[1].Value);

                TglTrans = selectedRow.Cells[0].Value.ToString();
                selectedAccountID = Int32.Parse(selectedRow.Cells[1].Value.ToString());
                loadDeskripsi(selectedAccountID);
                if (Int32.TryParse(selectedRow.Cells[8].Value.ToString(), out selectedDJID))
                {
                    //if from db then DJ-ID not 0
                }
                pm_id = Int32.Parse(selectedRow.Cells[3].Value.ToString());
                carabayarcombobox.SelectedValue = pm_id;
                Double debet, credit;
                if (Double.TryParse(selectedRow.Cells[5].Value.ToString(), out debet))
                {
                }
                if (Double.TryParse(selectedRow.Cells[6].Value.ToString(), out credit))
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
                deskripsiakun = selectedRow.Cells[7].Value.ToString();
                DeskripsiAkunTextbox.Text = deskripsiakun;
                selectedDJID = Int32.Parse(selectedRow.Cells[8].Value.ToString());
            
       }

        private void commitButton_Click(object sender, EventArgs e)
        {
            if (saveDataTransaction())
            {
                gutil.showSuccess(options);
                gutil.ResetAllControls(this);
            }
        }
    }
}
