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

namespace RoyalPetz_ADMIN
{
    public partial class pengaturanProdukForm : Form
    {
        private struct productPriceData
        {
            public string productInternalID;
            public string hargaEcer;
            public string hargaPartai;
            public string hargaGrosir;
        }

        private struct productLimitStokData
        {
            public string productInternalID;
            public string limitStok;
        }

        private struct productShelvesData
        {
            public string productInternalID;
            public string productKodeRak;
            public string productBarisRak;
        }

        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();
        private int originModuleID;
        private bool isStartEditing = false;

        List<productPriceData> productPriceDataValue = new List<productPriceData>();
        List<productLimitStokData> productLimitStokDataValue = new List<productLimitStokData>();
        List<productShelvesData> productShelvesDataValue = new List<productShelvesData>();

        public pengaturanProdukForm()
        {
            InitializeComponent();
        }

        public pengaturanProdukForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void loadDataHargaJual()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            
            productPriceData tempValuePrice;

            DS.mySqlConnect();

            if (namaProdukTextBox.Text.Equals(""))
                return;

            sqlCommand = "SELECT ID, PRODUCT_ID, PRODUCT_NAME, PRODUCT_BASE_PRICE, PRODUCT_RETAIL_PRICE, PRODUCT_BULK_PRICE, PRODUCT_WHOLESALE_PRICE FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_NAME LIKE '%" + namaProdukTextBox.Text + "%'";

            using (rdr = DS.getData(sqlCommand))
            {              
                while (rdr.Read())
                {
                    dataProdukDataGridView.Rows.Add(false, rdr.GetString("ID"), rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_BASE_PRICE"), rdr.GetString("PRODUCT_RETAIL_PRICE"), rdr.GetString("PRODUCT_BULK_PRICE"), rdr.GetString("PRODUCT_WHOLESALE_PRICE"));
            
                    tempValuePrice.productInternalID = rdr.GetString("ID");
                    tempValuePrice.hargaEcer = rdr.GetString("PRODUCT_RETAIL_PRICE");
                    tempValuePrice.hargaPartai = rdr.GetString("PRODUCT_BULK_PRICE");
                    tempValuePrice.hargaGrosir = rdr.GetString("PRODUCT_WHOLESALE_PRICE");

                    productPriceDataValue.Add(tempValuePrice);
                }
            }
        }

        private void loadDataLimitStok()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            productLimitStokData tempValueStok;
            
            DS.mySqlConnect();

            if (namaProdukTextBox.Text.Equals(""))
                return;

            sqlCommand = "SELECT ID, PRODUCT_ID, PRODUCT_NAME, PRODUCT_LIMIT_STOCK FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_NAME LIKE '%" + namaProdukTextBox.Text + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    dataProdukDataGridView.Rows.Add(false, rdr.GetString("ID"), rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), rdr.GetString("PRODUCT_LIMIT_STOCK"));

                    tempValueStok.productInternalID= rdr.GetString("ID");
                    tempValueStok.limitStok= rdr.GetString("PRODUCT_LIMIT_STOCK");

                    productLimitStokDataValue.Add(tempValueStok);
                }
            }
        }

        private void loadDataNoRak()
        {
            MySqlDataReader rdr;
            string sqlCommand;
            string kodeRak = "";
            string barisRak = "";
            productShelvesData tempValueShelves;

            DS.mySqlConnect();

            if (namaProdukTextBox.Text.Equals(""))
                return;

            sqlCommand = "SELECT ID, PRODUCT_ID, PRODUCT_NAME, PRODUCT_SHELVES FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 AND PRODUCT_NAME LIKE '%" + namaProdukTextBox.Text + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                while (rdr.Read())
                {
                    kodeRak = rdr.GetString("PRODUCT_SHELVES").Substring(0,2);
                    barisRak = rdr.GetString("PRODUCT_SHELVES").Substring(2);

                    dataProdukDataGridView.Rows.Add(false, rdr.GetString("ID"), rdr.GetString("PRODUCT_ID"), rdr.GetString("PRODUCT_NAME"), kodeRak, barisRak);

                    tempValueShelves.productInternalID = rdr.GetString("ID");
                    tempValueShelves.productKodeRak = kodeRak;
                    tempValueShelves.productBarisRak= barisRak;

                    productShelvesDataValue.Add(tempValueShelves);
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

            DataGridViewTextBoxColumn hPartaiColumn = new DataGridViewTextBoxColumn();
            hPartaiColumn.Name = "HARGA_PARTAI";
            hPartaiColumn.HeaderText = "HARGA JUAL PARTAI";
            hPartaiColumn.Width = 250;

            DataGridViewTextBoxColumn hGrosirColumn = new DataGridViewTextBoxColumn();
            hGrosirColumn.Name = "HARGA_GROSIR";
            hGrosirColumn.HeaderText = "HARGA JUAL GROSIR";
            hGrosirColumn.Width = 250;

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

            dataProdukDataGridView.Columns.Add(limitStokColumn);
        }

        private void setTableForPengaturanNomorRak()
        {
            this.Text = "PENGATURAN NOMOR RAK PRODUK";

            DataGridViewTextBoxColumn kodeRakColumn = new DataGridViewTextBoxColumn();
            kodeRakColumn.Name = "KODE_RAK";
            kodeRakColumn.HeaderText = "KODE RAK";
            kodeRakColumn.Width = 100;
            kodeRakColumn.MaxInputLength = 2;

            DataGridViewTextBoxColumn nomorRakColumn = new DataGridViewTextBoxColumn();
            nomorRakColumn.Name = "NOMOR_RAK";
            nomorRakColumn.HeaderText = "NOMOR BARIS RAK";
            nomorRakColumn.Width = 150;
            nomorRakColumn.MaxInputLength = 2;

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
            //errorLabel.Text = "";
            inisialisasiInterface();
            gutil.reArrangeTabOrder(this);
        }

        private void loadData()
        {
            dataProdukDataGridView.Rows.Clear();

            switch (originModuleID)
            {
                case globalConstants.PENGATURAN_HARGA_JUAL:
                    productPriceDataValue.Clear();
                    loadDataHargaJual();
                    break;

                case globalConstants.PENGATURAN_LIMIT_STOK:
                    productLimitStokDataValue.Clear();
                    loadDataLimitStok();
                    break;

                case globalConstants.PENGATURAN_NOMOR_RAK:
                    productShelvesDataValue.Clear();
                    loadDataNoRak();
                    break;
            }
        }

        private void namaProdukTextBox_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataProdukDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            bool valueIsChanged = false;
            if ( dataProdukDataGridView.SelectedCells.Count <= 0 )
                return;

            int selectedrowindex = dataProdukDataGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataProdukDataGridView.Rows[selectedrowindex];

            switch (originModuleID)
            {
                case globalConstants.PENGATURAN_HARGA_JUAL:
                    if ( !productPriceDataValue[selectedrowindex].hargaEcer.Equals(selectedRow.Cells["HARGA_ECER"].Value.ToString()) || 
                         !productPriceDataValue[selectedrowindex].hargaPartai.Equals(selectedRow.Cells["HARGA_PARTAI"].Value.ToString()) || 
                         !productPriceDataValue[selectedrowindex].hargaGrosir.Equals(selectedRow.Cells["HARGA_GROSIR"].Value.ToString())
                        )
                    {
                        valueIsChanged = true;
                    }
                    break;

                case globalConstants.PENGATURAN_LIMIT_STOK:
                    if ( !productLimitStokDataValue[selectedrowindex].limitStok.Equals(selectedRow.Cells["LIMIT_STOK"].Value.ToString()) )
                    {
                        valueIsChanged = true;
                    }
                    break;
                
                case globalConstants.PENGATURAN_NOMOR_RAK:
                    if ( !productShelvesDataValue[selectedrowindex].productKodeRak.Equals(selectedRow.Cells["KODE_RAK"].Value.ToString()) ||
                         !productShelvesDataValue[selectedrowindex].productBarisRak.Equals(selectedRow.Cells["NOMOR_RAK"].Value.ToString()) 
                        )
                    {
                        valueIsChanged = true;
                    }
                    break;
            }

            if (valueIsChanged)
            {
                selectedRow.Cells["CHANGED"].Value = true;
                namaProdukTextBox.ReadOnly = true;
                namaProdukTextBox.BackColor = Color.Red;
            }
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
                //errorLabel.Text = "";
                namaProdukTextBox.ReadOnly = false;
                namaProdukTextBox.BackColor = Color.White;

                loadData();

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
