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

        private bool saveToCSV(string fileName)
        {
            //string fileName = "";
            //string localDate;
            string sqlCommand;
            string line = "";
            MySqlDataReader rdr;
            StreamWriter sw = null;

            if (fileName.Length <= 0)
                return false;

            //localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);

            //fileName = "EXPORT_" + localDate + ".csv";

            //localDate = String.Format(culture, "{0:dd-MMM-yyyy}", DateTime.Now);

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

                    //sw.WriteLine(localDate);

                    line = "KODE PRODUK, BARCODE PRODUK, NAMA PRODUK, QTY PRODUK, QTY RIIL, DESCRIPTION";
                    sw.WriteLine(line);

                    while (rdr.Read())
                    {
                        line = rdr.GetString("PRODUCT_ID") + "," + rdr.GetString("PRODUCT_BARCODE") + "," + rdr.GetString("PRODUCT_NAME") + "," + rdr.GetString("PRODUCT_STOCK_QTY") + ",0,";
                        sw.WriteLine(line);
                    }

                    sw.Close();
                }
            }

            return true;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            string localDate = "";
            string fileName = "";
            localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);
            fileName = "STOCKOPNAME_" + localDate + ".csv";

            saveFileDialog1.FileName = fileName;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "CSV File (.csv)|*.csv";
            saveFileDialog1.ShowDialog();

            gutil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "TRY TO EXPORT STOCK OPNAME TO CSV");

            if (saveToCSV(saveFileDialog1.FileName))
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_SATUAN, "STOCK OPNAME EXPORTED TO CSV[" + saveFileDialog1.FileName + "]");
                MessageBox.Show("SUCCESS");
            }        
        }

        private void exportStockOpnameForm_Load(object sender, EventArgs e)
        {
            newButton.Focus();
            gutil.reArrangeTabOrder(this);
        }
    }
}
