﻿using System;
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
    public partial class dataProdukForm : Form
    {
        private int moduleID = 0;

        public dataProdukForm()
        {
            InitializeComponent();
        }

        public dataProdukForm(int originModuleID)
        {
            InitializeComponent();

            moduleID = originModuleID;

            // accessed from other form other than Master -> Data Produk
            // it means that this form is only displayed for browsing / searching purpose only
            newButton.Visible = false;
        }

        private void displaySpecificForm()
        {
            switch (moduleID)
            {
                case 1: // STOK PECAH PRODUK
                    stokPecahBarangForm displaystokPecahBarangForm = new stokPecahBarangForm();
                    displaystokPecahBarangForm.ShowDialog();
                    break;
                default: // MASTER DATA PRODUK
                    dataProdukDetailForm displayForm = new dataProdukDetailForm();
                    displayForm.ShowDialog();
                    break;
            }   
        }


        private void newButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataProdukDetailForm displayForm = new dataProdukDetailForm();
            displayForm.ShowDialog();

            this.Show();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tagProdukDataGridView_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();

            displaySpecificForm();
            
            this.Show();
        }

        private void tagProdukDataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // Enter
            {
                this.Hide();

                displaySpecificForm();

                this.Show();
            }
        }


    }
}
