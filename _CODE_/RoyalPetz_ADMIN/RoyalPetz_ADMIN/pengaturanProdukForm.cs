using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalPetz_ADMIN
{
    public partial class pengaturanProdukForm : Form
    {
        private int originModuleID;

        public pengaturanProdukForm()
        {
            InitializeComponent();
        }

        public pengaturanProdukForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void setTableForPengaturanHargaJual()
        {
            this.Text = "PENGATURAN HARGA JUAL PRODUK";

            DataGridViewColumn hppColumn = new DataGridViewColumn();
            hppColumn.HeaderText = "HARGA POKOK";
            hppColumn.Width = 250;

            DataGridViewColumn hepColumn = new DataGridViewColumn();
            hepColumn.HeaderText = "HARGA JUAL ECER";
            hepColumn.Width = 250;

            dataProdukDataGridView.Columns.Add(hppColumn);
            dataProdukDataGridView.Columns.Add(hepColumn);            
        }

        private void setTableForPengaturanLimitStok()
        {
            this.Text = "PENGATURAN LIMIT STOK PRODUK";

            DataGridViewColumn limitStokColumn = new DataGridViewColumn();
            limitStokColumn.HeaderText = "LIMIT STOK";
            limitStokColumn.Width = 200;

            dataProdukDataGridView.Columns.Add(limitStokColumn);
        }

        private void setTableForPengaturanNomorRak()
        {
            this.Text = "PENGATURAN NOMOR RAK PRODUK";

            DataGridViewColumn kodeRakColumn = new DataGridViewColumn();
            kodeRakColumn.HeaderText = "KODE RAK";
            kodeRakColumn.Width = 100;

            DataGridViewColumn nomorRakColumn = new DataGridViewColumn();
            nomorRakColumn.HeaderText = "NOMOR RAK";
            nomorRakColumn.Width = 150;

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
            inisialisasiInterface();
        }
    }
}
