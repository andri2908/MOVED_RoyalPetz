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

namespace AlphaSoft
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
            bool firstColumn = true;
            StringBuilder builder = new StringBuilder();
            string value = "";

            if (fileName.Length <= 0)
                return false;

            //localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);

            //fileName = "EXPORT_" + localDate + ".csv";

            //localDate = String.Format(culture, "{0:dd-MMM-yyyy}", DateTime.Now);

            if (globalFeatureList.EXPIRY_MODULE == 1)
            {
                sqlCommand = "SELECT MP.PRODUCT_ID, MP.PRODUCT_BARCODE, MP.PRODUCT_NAME, PE.PRODUCT_EXPIRY_DATE, PE.PRODUCT_AMOUNT, 0 AS PRODUCT_ACTUAL_QTY, '' AS DESCRIPTION FROM MASTER_PRODUCT MP, PRODUCT_EXPIRY PE WHERE MP.PRODUCT_ACTIVE = 1 PE.PRODUCT_ID = MP.PRODUCT_ID ORDER BY MP.ID";
            }
            else
                sqlCommand = "SELECT PRODUCT_ID, PRODUCT_BARCODE, PRODUCT_NAME, PRODUCT_STOCK_QTY, 0 AS PRODUCT_ACTUAL_QTY, '' AS DESCRIPTION FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY ID";

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

                    builder.Append("KODE PRODUK");
                    builder.Append(",");
                    builder.Append("BARCODE PRODUK");
                    builder.Append(",");
                    builder.Append("NAMA PRODUK");
                    builder.Append(",");
                    if (globalFeatureList.EXPIRY_MODULE == 1)
                    {
                        builder.Append("TGL EXPIRED");
                        builder.Append(",");
                    }
                    builder.Append("QTY PRODUK");
                    builder.Append(",");
                    builder.Append("QTY RIIL");
                    builder.Append(",");
                    builder.Append("DESCRIPTION");

                    line = builder.ToString();
                    sw.WriteLine(line);

                    while (rdr.Read())
                    {
                        builder.Clear();
                        firstColumn = true;
                        for (int index = 0; index < rdr.FieldCount; index++)
                        {
                            value = rdr.GetString(index);
                            // Add separator if this isn't the first value
                            if (!firstColumn)
                                builder.Append(',');
                            // Implement special handling for values that contain comma or quote
                            // Enclose in quotes and double up any double quotes
                            if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                                builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                            else
                                builder.Append(value);
                            //else
                            //    builder.AppendFormat("\'{0}\'", value);
                            firstColumn = false;
                        }
                        line = builder.ToString();
                        //line = rdr.GetString("PRODUCT_ID") + ";" + rdr.GetString("PRODUCT_BARCODE") + ";" + rdr.GetString("PRODUCT_NAME") + ";" + rdr.GetString("PRODUCT_STOCK_QTY") + ";0;";
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
