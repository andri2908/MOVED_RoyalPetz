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
    public partial class pengaturanKategoriProdukForm : Form
    {
        public pengaturanKategoriProdukForm()
        {
            InitializeComponent();
        }

        private void fillInDummydata()
        {
            kodeKategoriTextbox.Text = "PROMO";
            namaKategoriTextbox.Text = "PROMOSI";
            deskripsiTextbox.Text = "PROMOSI";
            namaProdukTextbox.Text = "ITEM";

            pengaturanKategoriDataGridView.Rows.Add("item 1", false);
            pengaturanKategoriDataGridView.Rows.Add("item 2", true);
            pengaturanKategoriDataGridView.Rows.Add("item 3", false);
            pengaturanKategoriDataGridView.Rows.Add("item 4", true);
        }

        private void pengaturanKategoriProdukForm_Load(object sender, EventArgs e)
        {
            fillInDummydata();
        }
    }
}
