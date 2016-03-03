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
    public partial class pengaturanPotonganHargaForm : Form
    {
        private globalUtilities gutil= new globalUtilities();
        public pengaturanPotonganHargaForm()
        {
            InitializeComponent();
        }

        private void fillInDummydata()
        {
            kodeGroupTextbox.Text = "GROSIR";
            namaGroupTextbox.Text = "GROSIR";
            deskripsiTextbox.Text = "GROUP GROSIR";
            namaProdukTextbox.Text = "ITEM";

            pengaturanKategoriDataGridView.Rows.Add("item 1", "0");
            pengaturanKategoriDataGridView.Rows.Add("item 2", "10");
            pengaturanKategoriDataGridView.Rows.Add("item 3", "20");
            pengaturanKategoriDataGridView.Rows.Add("item 4", "0");
        }

        private void pengaturanPotonganHargaForm_Load(object sender, EventArgs e)
        {
            //fillInDummydata();
            gutil.reArrangeTabOrder(this);
        }

        private void pengaturanPotonganHargaForm_Activated(object sender, EventArgs e)
        {
            fillInDummydata();
        }
    }
}
