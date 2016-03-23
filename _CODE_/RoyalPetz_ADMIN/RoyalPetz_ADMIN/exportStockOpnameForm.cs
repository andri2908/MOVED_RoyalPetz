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
using System.IO;

namespace RoyalPetz_ADMIN
{
    public partial class exportStockOpnameForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");        

        public exportStockOpnameForm()
        {
            InitializeComponent();
        }

        private void exportToCSV_Click(object sender, EventArgs e)
        {
            //if (exportToCSV.Checked)
            //{
            //    exportToCSV.Checked = false;
            //    //exportToExcel.Checked = true;
            //}
            //else
            //{
            //    exportToCSV.Checked = true;
            // //   exportToExcel.Checked = false;
            //}
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

        private bool saveToCSV()
        {
            string fileName = "";
            string localDate;
            string sqlCommand;
            string line = "";
            MySqlDataReader rdr;
            StreamWriter sw = null;

            localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);

            fileName = "EXPORT_" + localDate + ".csv";

            sqlCommand = "SELECT * FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY ID";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    if (!File.Exists(fileName)) 
                        sw = File.CreateText(fileName);
                    else
                    { 
                        File.Delete(fileName);
                        sw = File.CreateText(fileName);
                    }

                    line = "KODE PRODUK, BARCODE PRODUK, NAMA PRODUK, QTY PRODUK, QTY RIIL";
                    sw.WriteLine(line);
                    while (rdr.Read())
                    {
                        line = rdr.GetString("PRODUCT_ID") + "," + rdr.GetString("PRODUCT_BARCODE") + "," + rdr.GetString("PRODUCT_NAME") + "," + rdr.GetString("PRODUCT_STOCK_QTY") + ",0";
                        sw.WriteLine(line);
                    }

                    sw.Close();
                }
            }

            return true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            //saveFileDialog1.ShowDialog();
            if (saveToCSV())
            {
                //gutil.showSuccess(gutil.INS);
                MessageBox.Show("SUCCESS");
            }        
        }

        private void exportStockOpnameForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }
    }
}
