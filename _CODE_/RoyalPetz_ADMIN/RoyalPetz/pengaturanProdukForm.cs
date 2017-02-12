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

namespace AlphaSoft
{
    public partial class pengaturanProdukForm : Form
    {

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private int originModuleID;
        private bool isLoading = false;

        List<string> producthargaEcer = new List<string>();
        List<string> producthargaPartai = new List<string>();
        List<string> producthargaGrosir = new List<string>();

        List<string> productLimitStock = new List<string>();

        List<string> productKodeRak = new List<string>();
        List<string> productBarisRak = new List<string>();

        public pengaturanProdukForm()
        {
            InitializeComponent();
        }

        public pengaturanProdukForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void dataProdukDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_ECER" || dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_PARTAI" || dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_GROSIR" ||
                dataProdukDataGridView.CurrentCell.OwningColumn.Name == "LIMIT_STOK" || dataProdukDataGridView.CurrentCell.OwningColumn.Name == "KODE_RAK" || dataProdukDataGridView.CurrentCell.OwningColumn.Name == "NOMOR_RAK")
                    && e.Control is TextBox)
            {
                TextBox textBox = e.Control as TextBox;
                textBox.TextChanged += TextBox_TextChanged;

                if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "KODE_RAK")
                {
                    textBox.CharacterCasing = CharacterCasing.Upper;
                }
            }
            
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            int rowSelectedIndex = 0;
            string previousInput = "";
            
            if (isLoading)
                return;

            DataGridViewTextBoxEditingControl dataGridViewTextBoxEditingControl = sender as DataGridViewTextBoxEditingControl;

            rowSelectedIndex = dataProdukDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataProdukDataGridView.Rows[rowSelectedIndex];
            
            switch (originModuleID)
            {
                case globalConstants.PENGATURAN_HARGA_JUAL:
                    if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_ECER")
                        previousInput = producthargaEcer[rowSelectedIndex];
                    else if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_PARTAI")
                        previousInput = producthargaPartai[rowSelectedIndex];
                    else if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_GROSIR")
                        previousInput = producthargaGrosir[rowSelectedIndex];
                    break;

                case globalConstants.PENGATURAN_LIMIT_STOK:
                    previousInput = productLimitStock[rowSelectedIndex];
                    break;

                case globalConstants.PENGATURAN_NOMOR_RAK:
                    if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "NOMOR_RAK")
                        previousInput = productBarisRak[rowSelectedIndex];
                    break;
            }

            if (!gutil.matchRegEx(dataGridViewTextBoxEditingControl.Text, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL) && (dataGridViewTextBoxEditingControl.Text.Length > 0) && dataProdukDataGridView.CurrentCell.OwningColumn.Name != "KODE_RAK")
            {
                dataGridViewTextBoxEditingControl.Text = previousInput;
            }
            else
            {
                switch (originModuleID)
                {
                    case globalConstants.PENGATURAN_HARGA_JUAL:
                        if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_ECER")
                            producthargaEcer[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                        else if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_PARTAI")
                            producthargaPartai[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                        else if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "HARGA_GROSIR")
                            producthargaGrosir[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                        break;

                    case globalConstants.PENGATURAN_LIMIT_STOK:
                        productLimitStock[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                        break;

                    case globalConstants.PENGATURAN_NOMOR_RAK:
                        if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "KODE_RAK")
                            productKodeRak[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                        else if (dataProdukDataGridView.CurrentCell.OwningColumn.Name == "NOMOR_RAK")
                            productBarisRak[rowSelectedIndex] = dataGridViewTextBoxEditingControl.Text;
                        break;
                }
                if (!previousInput.Equals(dataGridViewTextBoxEditingControl.Text))
                { 
                    selectedRow.DefaultCellStyle.BackColor = Color.LightCoral;
                    selectedRow.Cells["CHANGED"].Value = true;
                }
            }
        }

        private void loadDataHargaJual()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            string namaProductParam = "";

            DS.mySqlConnect();

            if (namaProdukTextBox.Text.Equals(""))
                return;

            namaProductParam = MySqlHelper.EscapeString(namaProdukTextBox.Text);
            sqlCommand = "SELECT ID, PRODUCT_ID, PRODUCT_NAME, PRODUCT_BASE_PRICE, PRODUCT_RETAIL_PRICE, PRODUCT_BULK_PRICE, PRODUCT_WHOLESALE_PRICE FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_NAME LIKE '%" + namaProductParam + "%'";

            using (rdr = DS.getData(sqlCommand))
            {              
                while (rdr.Read())
                {
                    dataProdukDataGridView.Rows.Add(false, rdr.GetString("ID"), rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("PRODUCT_RETAIL_PRICE"), rdr.GetString("PRODUCT_BULK_PRICE"), rdr.GetString("PRODUCT_WHOLESALE_PRICE"));

                    producthargaEcer.Add(rdr.GetString("PRODUCT_RETAIL_PRICE"));
                    producthargaPartai.Add(rdr.GetString("PRODUCT_BULK_PRICE"));
                    producthargaGrosir.Add(rdr.GetString("PRODUCT_WHOLESALE_PRICE"));
                }
            }
        }

        private void loadDataLimitStok()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            string namaProductParam = "";
            
            DS.mySqlConnect();

            if (namaProdukTextBox.Text.Equals(""))
                return;

            namaProductParam = MySqlHelper.EscapeString(namaProdukTextBox.Text);

            sqlCommand = "SELECT ID, PRODUCT_ID, PRODUCT_NAME, PRODUCT_LIMIT_STOCK FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_NAME LIKE '%" + namaProductParam + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    dataProdukDataGridView.Rows.Add(false, rdr.GetString("ID"), rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_LIMIT_STOCK"));

                    productLimitStock.Add(rdr.GetString("PRODUCT_LIMIT_STOCK"));

                }
            }
        }

        private void loadDataNoRak()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            string kodeRak = "";
            string barisRak = "";
            string namaProductParam = "";

            DS.mySqlConnect();

            if (namaProdukTextBox.Text.Equals(""))
                return;

            namaProductParam = MySqlHelper.EscapeString(namaProdukTextBox.Text);

            sqlCommand = "SELECT ID, PRODUCT_ID, PRODUCT_NAME, PRODUCT_SHELVES FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_NAME LIKE '%" + namaProductParam + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    kodeRak = rdr.GetString("PRODUCT_SHELVES").Substring(0,2);
                    barisRak = rdr.GetString("PRODUCT_SHELVES").Substring(2);

                    dataProdukDataGridView.Rows.Add(false, rdr.GetString("ID"), rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), kodeRak, barisRak);

                    productKodeRak.Add(kodeRak);
                    productBarisRak.Add(barisRak);
                }            
            }
        }

        private void setTableForPengaturanHargaJual()
        {
            this.Text = "PENGATURAN HARGA JUAL PRODUK";

            DataGridViewTextBoxColumn hppColumn = new DataGridViewTextBoxColumn();
            hppColumn.Name = "HPP";
            hppColumn.HeaderText = "HARGA POKOK";
            hppColumn.Width = 250;
            hppColumn.ReadOnly = true;

            DataGridViewTextBoxColumn hepColumn = new DataGridViewTextBoxColumn();
            hepColumn.Name = "HARGA_ECER";
            hepColumn.HeaderText = "HARGA JUAL ECER";
            hepColumn.Width = 250;
            hepColumn.DefaultCellStyle.BackColor = Color.LightBlue;

            DataGridViewTextBoxColumn hPartaiColumn = new DataGridViewTextBoxColumn();
            hPartaiColumn.Name = "HARGA_PARTAI";
            hPartaiColumn.HeaderText = "HARGA JUAL GROSIR";
            hPartaiColumn.Width = 250;
            hPartaiColumn.DefaultCellStyle.BackColor = Color.LightBlue;

            DataGridViewTextBoxColumn hGrosirColumn = new DataGridViewTextBoxColumn();
            hGrosirColumn.Name = "HARGA_GROSIR";
            hGrosirColumn.HeaderText = "HARGA JUAL PARTAI";
            hGrosirColumn.Width = 250;
            hGrosirColumn.DefaultCellStyle.BackColor = Color.LightBlue;

            dataProdukDataGridView.Columns.Add(hppColumn);
            dataProdukDataGridView.Columns.Add(hepColumn);
            dataProdukDataGridView.Columns.Add(hPartaiColumn);
            dataProdukDataGridView.Columns.Add(hGrosirColumn);            
        }

        private void setTableForPengaturanLimitStok()
        {
            this.Text = "PENGATURAN LIMIT STOK PRODUK";

            DataGridViewTextBoxColumn limitStokColumn = new DataGridViewTextBoxColumn();
            limitStokColumn.Name = "LIMIT_STOK";
            limitStokColumn.HeaderText = "LIMIT STOK";
            limitStokColumn.Width = 200;
            limitStokColumn.DefaultCellStyle.BackColor = Color.LightBlue;

            dataProdukDataGridView.Columns.Add(limitStokColumn);
        }

        private void setTableForPengaturanNomorRak()
        {
            this.Text = "PENGATURAN NOMOR RAK PRODUK";

            DataGridViewTextBoxColumn kodeRakColumn = new DataGridViewTextBoxColumn();
            kodeRakColumn.Name = "KODE_RAK";
            kodeRakColumn.HeaderText = "KODE RAK";
            kodeRakColumn.Width = 200;
            kodeRakColumn.MaxInputLength = 2;
            kodeRakColumn.DefaultCellStyle.BackColor = Color.LightBlue;

            DataGridViewTextBoxColumn nomorRakColumn = new DataGridViewTextBoxColumn();
            nomorRakColumn.Name = "NOMOR_RAK";
            nomorRakColumn.HeaderText = "NOMOR BARIS RAK";
            nomorRakColumn.Width = 200;
            nomorRakColumn.MaxInputLength = 2;
            nomorRakColumn.DefaultCellStyle.BackColor = Color.LightBlue;

            dataProdukDataGridView.Columns.Add(kodeRakColumn);
            dataProdukDataGridView.Columns.Add(nomorRakColumn);
        }

        private void inisialisasiInterface()
        {
            switch(originModuleID)
            {
                case globalConstants.PENGATURAN_HARGA_JUAL:
                    setTableForPengaturanHargaJual();
                    break;
                
                case globalConstants.PENGATURAN_LIMIT_STOK:
                    setTableForPengaturanLimitStok();
                    break;

                case globalConstants.PENGATURAN_NOMOR_RAK:
                    setTableForPengaturanNomorRak();
                    break;
            }
        }

        private void pengaturanProdukForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";
            inisialisasiInterface();
            dataProdukDataGridView.EditingControlShowing += dataProdukDataGridView_EditingControlShowing;

            gutil.reArrangeTabOrder(this);
        }

        private void loadData()
        {
            dataProdukDataGridView.Rows.Clear();
           // saveButton.Enabled = false;

            isLoading = true;
            switch (originModuleID)
            {
                case globalConstants.PENGATURAN_HARGA_JUAL:
                    producthargaEcer.Clear();
                    producthargaPartai.Clear();
                    producthargaGrosir.Clear();

                    loadDataHargaJual();
                    break;

                case globalConstants.PENGATURAN_LIMIT_STOK:
                    productLimitStock.Clear();
                    loadDataLimitStok();
                    break;

                case globalConstants.PENGATURAN_NOMOR_RAK:
                    productBarisRak.Clear();
                    productKodeRak.Clear();
                    loadDataNoRak();
                    break;
            }
            isLoading = false;
        }

        private void namaProdukTextBox_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataProdukDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //bool valueIsChanged = false;
            //if ( dataProdukDataGridView.SelectedCells.Count <= 0 )
            //    return;

            //int selectedrowindex = dataProdukDataGridView.SelectedCells[0].RowIndex;
            //DataGridViewRow selectedRow = dataProdukDataGridView.Rows[selectedrowindex];

            //switch (originModuleID)
            //{
            //    case globalConstants.PENGATURAN_HARGA_JUAL:
            //        if (!producthargaEcer[selectedrowindex].Equals(selectedRow.Cells["HARGA_ECER"].Value.ToString()) ||
            //             !producthargaPartai[selectedrowindex].Equals(selectedRow.Cells["HARGA_PARTAI"].Value.ToString()) ||
            //             !producthargaGrosir[selectedrowindex].Equals(selectedRow.Cells["HARGA_GROSIR"].Value.ToString())
            //            )
            //        {
            //            valueIsChanged = true;
            //        }
            //        break;

            //    case globalConstants.PENGATURAN_LIMIT_STOK:
            //        if ( !productLimitStock[selectedrowindex].Equals(selectedRow.Cells["LIMIT_STOK"].Value.ToString()) )
            //        {
            //            valueIsChanged = true;
            //        }
            //        break;
                
            //    case globalConstants.PENGATURAN_NOMOR_RAK:
            //        if ( !productKodeRak[selectedrowindex].Equals(selectedRow.Cells["KODE_RAK"].Value.ToString()) ||
            //             !productBarisRak[selectedrowindex].Equals(selectedRow.Cells["NOMOR_RAK"].Value.ToString()) 
            //            )
            //        {
            //            valueIsChanged = true;
            //        }
            //        break;
            //}

            //if (valueIsChanged)
            //{
            //    selectedRow.Cells["CHANGED"].Value = true;
            //    namaProdukTextBox.ReadOnly = true;
            //    namaProdukTextBox.BackColor = Color.Red;
            //    saveButton.Enabled = true;
            //}
        }

        private bool dataValidated()
        {
            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            string kodeRakValue;
            string nomorRakValue;
            MySqlException internalEX = null;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.PENGATURAN_HARGA_JUAL:
                            for (int i = 0; i < dataProdukDataGridView.Rows.Count;i++ )
                            {
                                if (Convert.ToBoolean(dataProdukDataGridView.Rows[i].Cells["CHANGED"].Value))
                                {
                                    sqlCommand = "UPDATE MASTER_PRODUCT SET " +
                                                        "PRODUCT_RETAIL_PRICE = " + Convert.ToInt32(dataProdukDataGridView.Rows[i].Cells["HARGA_ECER"].Value) + ", " +
                                                        "PRODUCT_BULK_PRICE = " + Convert.ToInt32(dataProdukDataGridView.Rows[i].Cells["HARGA_PARTAI"].Value) + ", " +
                                                        "PRODUCT_WHOLESALE_PRICE = " + Convert.ToInt32(dataProdukDataGridView.Rows[i].Cells["HARGA_GROSIR"].Value) + " " +
                                                        "WHERE ID = " + Convert.ToInt32(dataProdukDataGridView.Rows[i].Cells["ID"].Value);

                                gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_HARGA, "UPDATE HARGA FOR ["+Convert.ToString(dataProdukDataGridView.Rows[i].Cells["kodeProduk"].Value) +"]");

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }
                            }
                            break;
                    case globalConstants.PENGATURAN_LIMIT_STOK:
                            for (int i = 0; i < dataProdukDataGridView.Rows.Count;i++ )
                            {
                                if (Convert.ToBoolean(dataProdukDataGridView.Rows[i].Cells["CHANGED"].Value))
                                {
                                    sqlCommand = "UPDATE MASTER_PRODUCT SET " +
                                                        "PRODUCT_LIMIT_STOCK = " + Convert.ToInt32(dataProdukDataGridView.Rows[i].Cells["LIMIT_STOK"].Value) + " " +
                                                        "WHERE ID = " + Convert.ToInt32(dataProdukDataGridView.Rows[i].Cells["ID"].Value);

                                gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_LIMIT_STOK, "UPDATE LIMIT STOK FOR [" + Convert.ToString(dataProdukDataGridView.Rows[i].Cells["kodeProduk"].Value) + "]");

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }
                            }
                        break;
                    case globalConstants.PENGATURAN_NOMOR_RAK:
                            for (int i = 0; i < dataProdukDataGridView.Rows.Count;i++ )
                            {
                                if (Convert.ToBoolean(dataProdukDataGridView.Rows[i].Cells["CHANGED"].Value))
                                {
                                    kodeRakValue = dataProdukDataGridView.Rows[i].Cells["KODE_RAK"].Value.ToString();
                                    while (kodeRakValue.Length < 2)
                                        kodeRakValue = "-" + kodeRakValue;

                                    nomorRakValue = dataProdukDataGridView.Rows[i].Cells["NOMOR_RAK"].Value.ToString();
                                    while (nomorRakValue.Length < 2)
                                        nomorRakValue = "0" + nomorRakValue;

                                    sqlCommand = "UPDATE MASTER_PRODUCT SET " +
                                                        "PRODUCT_SHELVES = '" + kodeRakValue + nomorRakValue + "' " +
                                                        "WHERE ID = " + Convert.ToInt32(dataProdukDataGridView.Rows[i].Cells["ID"].Value);

                                gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_NOMOR_RAK, "UPDATE NOMOR RAK FOR [" + Convert.ToString(dataProdukDataGridView.Rows[i].Cells["kodeProduk"].Value) + "]");

                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;
                                }
                            }
                        break;
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_HARGA, "EXCEPTION THROWN [" + e.Message + "]");

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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                //errorLabel.Text = "";
                namaProdukTextBox.ReadOnly = false;
                namaProdukTextBox.BackColor = Color.White;

                loadData();

                switch (originModuleID)
                {
                    case globalConstants.PENGATURAN_HARGA_JUAL:
                        gutil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_HARGA, globalConstants.CHANGE_LOG_UPDATE, "PENGATURAN HARGA JUAL, SEARCH TERM [" + namaProdukTextBox.Text + "]");
                        break;
                    case globalConstants.PENGATURAN_LIMIT_STOK:
                        gutil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_LIMIT_STOK, globalConstants.CHANGE_LOG_UPDATE, "PENGATURAN LIMIT STOK, SEARCH TERM [" + namaProdukTextBox.Text + "]");
                        break;
                    case globalConstants.PENGATURAN_NOMOR_RAK:
                        gutil.saveUserChangeLog(globalConstants.MENU_PENGATURAN_NOMOR_RAK, globalConstants.CHANGE_LOG_UPDATE, "PENGATURAN NOMOR RAK, SEARCH TERM [" + namaProdukTextBox.Text + "]");
                        break;
                }

                //MessageBox.Show("SUCCESS");
                gutil.showSuccess(gutil.UPD);
            }
        }

        private void pengaturanProdukForm_Activated(object sender, EventArgs e)
        {
            errorLabel.Text = "";
        }
    }
}
