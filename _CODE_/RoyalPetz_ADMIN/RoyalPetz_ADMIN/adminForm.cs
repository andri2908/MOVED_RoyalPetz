using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace RoyalPetz_ADMIN
{
    public partial class adminForm : Form
    {
        private DateTime localDate = DateTime.Now;
        private CultureInfo culture = new CultureInfo("id-ID");

        public adminForm()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void updateLabel()
        {
            localDate = DateTime.Now;
            timeStampStatusLabel.Text = String.Format(culture, "{0:dddd, dd-MM-yyyy - HH:mm:ss}", localDate);
        }

        private void adminForm_Load(object sender, EventArgs e)
        {
            updateLabel();
            timer1.Start();
        }

        private void adminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateLabel();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void jenisProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            tagProdukForm displayedForm = new tagProdukForm();
            displayedForm.ShowDialog();

            this.Show();
        }

        private void dataProdukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukForm displayedForm = new dataProdukForm();
            displayedForm.ShowDialog();

            this.Show();
        }
    }
}
