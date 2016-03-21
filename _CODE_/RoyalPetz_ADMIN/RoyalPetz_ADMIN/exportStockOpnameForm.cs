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
    public partial class exportStockOpnameForm : Form
    {
        private globalUtilities gutil = new globalUtilities();

        public exportStockOpnameForm()
        {
            InitializeComponent();
        }

        private void exportToCSV_Click(object sender, EventArgs e)
        {
            if (exportToCSV.Checked)
            {
                exportToCSV.Checked = false;
                //exportToExcel.Checked = true;
            }
            else
            {
                exportToCSV.Checked = true;
             //   exportToExcel.Checked = false;
            }
        }

        private void exportToExcel_Click(object sender, EventArgs e)
        {
            //if (exportToExcel.Checked)
            //{
            //    exportToCSV.Checked = true;
            //    exportToExcel.Checked = false;
            //}
            //else
            //{
            //    exportToCSV.Checked = false;
            //    exportToExcel.Checked = true;
            //}
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            MessageBox.Show(saveFileDialog1.FileName);
        }

        private void exportStockOpnameForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }
    }
}
