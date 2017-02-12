using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace AlphaSoft
{
    public partial class sinkronisasiInformasiForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private string syncFileName = Application.StartupPath + "\\syncFile.sync";

        public sinkronisasiInformasiForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string fileName = "";
            openFileDialog1.Filter = "SQL File (.sql)|*.sql";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog1.FileName;
                    fileNameTextbox.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
       
        private void exportData(string fileName, Data_Access DAccess, bool isHQConnection = false)
        {
            //string localDate = "";
            //string strCmdText = "";
            //string ipServer;
            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            MySqlDataReader rdr;
            string sqlCommand = "";
            string insertStatement = "";
            StreamWriter sw = null;

            // EXPORT MASTER PRODUCT DATA
            string strCmdText = "USE `sys_pos`; " + "\n" +
                                        "DROP TABLE IF EXISTS `temp_master_product`;" + "\n" +
                                        "\n" +
                                        "CREATE TABLE `temp_master_product` (" + "\n" +
                                        "`ID` int(10) unsigned NOT NULL AUTO_INCREMENT," + "\n" +
                                        "`PRODUCT_ID` varchar(50) DEFAULT NULL," + "\n" +
                                        "`PRODUCT_BARCODE` varchar(15) DEFAULT NULL," + "\n" +
                                        "`PRODUCT_NAME` varchar(50) DEFAULT NULL," + "\n" +
                                        "`PRODUCT_DESCRIPTION` varchar(100) DEFAULT NULL," + "\n" +
                                        "`PRODUCT_BASE_PRICE` double DEFAULT NULL," + "\n" +
                                        "`PRODUCT_RETAIL_PRICE` double DEFAULT NULL," + "\n" +
                                        "`PRODUCT_BULK_PRICE` double DEFAULT NULL," + "\n" +
                                        "`PRODUCT_WHOLESALE_PRICE` double DEFAULT NULL," + "\n" +
                                        "`UNIT_ID` smallint(5) unsigned DEFAULT '0'," + "\n" +
                                        "`PRODUCT_IS_SERVICE` tinyint(3) unsigned DEFAULT NULL," + "\n" +
                                        "PRIMARY KEY(`ID`)," + "\n" +
                                        "UNIQUE KEY `PRODUCT_ID_UNIQUE` (`PRODUCT_ID`)" + "\n" +
                                        ") ENGINE = InnoDB AUTO_INCREMENT = 1 DEFAULT CHARSET = utf8;" + "\n" +
                                        "\n" +
                                        "DROP TABLE IF EXISTS `temp_product_category`;" + "\n" +
                                        "\n" +
                                        "CREATE TABLE `temp_product_category` (" + "\n" +
                                        "`PRODUCT_ID` varchar(50) NOT NULL," + "\n" +
                                        "`CATEGORY_ID` tinyint(3) unsigned NOT NULL," + "\n" +
                                        "PRIMARY KEY (`PRODUCT_ID`,`CATEGORY_ID`)" + "\n" +
                                        ") ENGINE = InnoDB DEFAULT CHARSET = utf8;" + "\n";


            //localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);
            //fileName = "SYNCINFO_PRODUCT_" + localDate + ".sql";

            sqlCommand = "SELECT PRODUCT_ID, IFNULL(PRODUCT_BARCODE, '') AS PRODUCT_BARCODE, IFNULL(PRODUCT_NAME, '') AS PRODUCT_NAME, IFNULL(PRODUCT_DESCRIPTION, '') AS PRODUCT_DESCRIPTION, PRODUCT_BASE_PRICE, PRODUCT_RETAIL_PRICE, PRODUCT_BULK_PRICE, PRODUCT_WHOLESALE_PRICE, UNIT_ID, PRODUCT_IS_SERVICE FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1";
            using (rdr = DAccess.getData(sqlCommand, isHQConnection))
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

                    sw.WriteLine(strCmdText);

                    while (rdr.Read())
                    {
                        insertStatement = "INSERT INTO TEMP_MASTER_PRODUCT (PRODUCT_ID, PRODUCT_BARCODE, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_BASE_PRICE, PRODUCT_RETAIL_PRICE, PRODUCT_BULK_PRICE, PRODUCT_WHOLESALE_PRICE, UNIT_ID, PRODUCT_IS_SERVICE) VALUES (" +
                                                 "'" + MySqlHelper.EscapeString(rdr.GetString("PRODUCT_ID")) + "', '" + MySqlHelper.EscapeString(rdr.GetString("PRODUCT_BARCODE")) + "', '" + MySqlHelper.EscapeString(rdr.GetString("PRODUCT_NAME")) + "', '" + MySqlHelper.EscapeString(rdr.GetString("PRODUCT_DESCRIPTION")) + "', " + rdr.GetString("PRODUCT_BASE_PRICE") + ", " + rdr.GetString("PRODUCT_RETAIL_PRICE") + ", " + rdr.GetString("PRODUCT_BULK_PRICE") + ", " + rdr.GetString("PRODUCT_WHOLESALE_PRICE") + ", " + rdr.GetString("UNIT_ID") + ", " + rdr.GetString("PRODUCT_IS_SERVICE") + ");";
                        sw.WriteLine(insertStatement);
                    }
                }
                rdr.Close();
            }
            sw.WriteLine("");

            // EXPORT MASTER KATEGORI DATA
            sw.WriteLine("");
            sw.WriteLine("DELETE FROM MASTER_CATEGORY;");
            sqlCommand = "SELECT CATEGORY_ID, CATEGORY_NAME, IFNULL(CATEGORY_DESCRIPTION, '') AS CATEGORY_DESCRIPTION FROM MASTER_CATEGORY WHERE CATEGORY_ACTIVE = 1";
            using (rdr = DAccess.getData(sqlCommand, isHQConnection))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        insertStatement = "INSERT INTO MASTER_CATEGORY (CATEGORY_ID, CATEGORY_NAME, CATEGORY_DESCRIPTION, CATEGORY_ACTIVE) VALUES (" +
                                                 rdr.GetString("CATEGORY_ID") + ", '" + MySqlHelper.EscapeString(rdr.GetString("CATEGORY_NAME")) + "', '" + MySqlHelper.EscapeString(rdr.GetString("CATEGORY_DESCRIPTION")) + "', 1);";
                        sw.WriteLine(insertStatement);
                    }
                }
                rdr.Close();
            }
            sw.WriteLine("");

            // EXPORT MASTER UNIT DATA
            sw.WriteLine("");
            sw.WriteLine("DELETE FROM MASTER_UNIT;");
            sqlCommand = "SELECT UNIT_ID, UNIT_NAME, IFNULL(UNIT_DESCRIPTION, '') AS UNIT_DESCRIPTION FROM MASTER_UNIT WHERE UNIT_ACTIVE = 1";
            using (rdr = DAccess.getData(sqlCommand, isHQConnection))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        insertStatement = "INSERT INTO MASTER_UNIT (UNIT_ID, UNIT_NAME, UNIT_DESCRIPTION, UNIT_ACTIVE) VALUES (" +
                                                 rdr.GetString("UNIT_ID") + ", '" + MySqlHelper.EscapeString(rdr.GetString("UNIT_NAME")) + "', '" + MySqlHelper.EscapeString(rdr.GetString("UNIT_DESCRIPTION")) + "', 1);";
                        sw.WriteLine(insertStatement);
                    }
                }
                rdr.Close();
            }
            sw.WriteLine("");

            // EXPORT MASTER UNIT KONVERSI DATA
            sw.WriteLine("");
            sw.WriteLine("DELETE FROM UNIT_CONVERT;");
            sqlCommand = "SELECT CONVERT_UNIT_ID_1, CONVERT_UNIT_ID_2, CONVERT_MULTIPLIER FROM UNIT_CONVERT";
            using (rdr = DAccess.getData(sqlCommand, isHQConnection))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        insertStatement = "INSERT INTO UNIT_CONVERT (CONVERT_UNIT_ID_1, CONVERT_UNIT_ID_2, CONVERT_MULTIPLIER) VALUES (" +
                                                 rdr.GetString("CONVERT_UNIT_ID_1") + ", " + rdr.GetString("CONVERT_UNIT_ID_2") + ", " + rdr.GetString("CONVERT_MULTIPLIER") + ");";
                        sw.WriteLine(insertStatement);
                    }
                }
                rdr.Close();
            }
            sw.WriteLine("");

            // EXPORT PRODUCT CATEGORY DATA
            sw.WriteLine("");
            sqlCommand = "SELECT PRODUCT_ID, CATEGORY_ID FROM PRODUCT_CATEGORY";
            using (rdr = DAccess.getData(sqlCommand, isHQConnection))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        insertStatement = "INSERT INTO TEMP_PRODUCT_CATEGORY (PRODUCT_ID, CATEGORY_ID) VALUES (" +
                                                 "'" + rdr.GetString("PRODUCT_ID") + "', " + rdr.GetString("CATEGORY_ID") + ");";
                        sw.WriteLine(insertStatement);
                    }
                }
                rdr.Close();
            }
            sw.WriteLine("");

            sw.Close();
            //ipServer = DS.getIPServer();
            ////strCmdText = "/C mysqldump -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos MASTER_PRODUCT > \"" + fileName + "\"";

            //proc.StartInfo.FileName = "CMD.exe";
            //proc.StartInfo.Arguments = "/C " + "mysqldump -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos > \"" + fileName + "\"";
            //proc.Exited += new EventHandler(ProcessExited);
            //proc.EnableRaisingEvents = true;
            //proc.Start();


            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }

        private void exportDataButton_Click(object sender, EventArgs e)
        {
            string localDate = "";
            string fileName = "";
            localDate = String.Format(culture, "{0:ddMMyyyy}", DateTime.Now);
            fileName = "SYNCINFO_PRODUCT_" + localDate + ".sql";

            saveFileDialog1.FileName = fileName;
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = "sql";
            saveFileDialog1.Filter = "SQL File (.sql)|*.sql";
            saveFileDialog1.ShowDialog();

            smallPleaseWait pleaseWait = new smallPleaseWait();
            pleaseWait.Show();

            //  ALlow main UI thread to properly display please wait form.
            Application.DoEvents();
            exportData(saveFileDialog1.FileName, DS);

            pleaseWait.Close();

            gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "EXPORTED FILE NAME = " + saveFileDialog1.FileName);
            MessageBox.Show("DONE");
        }

        private void sinkronisasiInformasiForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void sinkronisasiInformasiForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }

        private void ProcessExited(Object source, EventArgs e)
        {
            var proc = (System.Diagnostics.Process)source;
            gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "PROCESS EXITED");
            if (updateLocalData())
            {
                MessageBox.Show("DONE");
            }
            
        }

        private void syncInformation(string fileName)
        {
            string ipServer = "";
            //string strCmdText = "";
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            Directory.SetCurrentDirectory(Application.StartupPath);

            ipServer = DS.getIPServer();
            //strCmdText = "/C " + "mysql -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos < \"" + fileName + "\"";

            //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            proc.StartInfo.FileName = "CMD.exe";
            proc.StartInfo.Arguments = "/C " + "mysql -h " + ipServer + " -u SYS_POS_ADMIN -ppass123 sys_pos < \"" + fileName + "\"";
            proc.Exited += new EventHandler(ProcessExited);
            proc.EnableRaisingEvents = true;
            gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "SYNC INFORMATION PROCESS START");
            proc.Start();
            

        }

        private bool updateLocalData()
        {
            bool result = false;
            string sqlCommand = "";

            string productID;
            string productBarcode;
            string productName;
            string productDescription;
            string productBasePrice;
            string productRetailPrice;
            string productBulkPrice;
            string productWholesalePrice;
            string productService;
            string productUnitID;

            string categoryID;

            MySqlException internalEX = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();

            int i = 0;
            DS.beginTransaction();

            gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "UPDATE LOCAL DATA");
            sqlCommand = "SELECT PRODUCT_ID FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1";
            try
            {
                DS.mySqlConnect();

                using (rdr = DS.getData(sqlCommand))
                {
                    if (rdr.HasRows)
                    {
                        dt.Load(rdr);
                        rdr.Close();

                        dataGridView1.DataSource = dt;
                        i = 0;
                        // UPDATE CURRENT DATA IN LOCAL DATABASE    
                        gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "UPDATE CURRENT DATA IN LOCAL DATABASE");
                        while (i < dataGridView1.Rows.Count)
                        {
                            productID = dataGridView1.Rows[i].Cells["PRODUCT_ID"].Value.ToString();

                            productBasePrice = DS.getDataSingleValue("SELECT PRODUCT_BASE_PRICE FROM TEMP_MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'").ToString();
                            productRetailPrice = DS.getDataSingleValue("SELECT PRODUCT_RETAIL_PRICE FROM TEMP_MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'").ToString();
                            productBulkPrice = DS.getDataSingleValue("SELECT PRODUCT_BULK_PRICE FROM TEMP_MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'").ToString();
                            productWholesalePrice = DS.getDataSingleValue("SELECT PRODUCT_WHOLESALE_PRICE FROM TEMP_MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'").ToString();
                            productUnitID = DS.getDataSingleValue("SELECT UNIT_ID FROM TEMP_MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'").ToString();

                            sqlCommand = "UPDATE MASTER_PRODUCT SET " +
                                                "PRODUCT_BASE_PRICE = " + productBasePrice + ", PRODUCT_RETAIL_PRICE = " + productRetailPrice + ", PRODUCT_BULK_PRICE = " + productBulkPrice + ", PRODUCT_WHOLESALE_PRICE = " + productWholesalePrice + ", UNIT_ID = " + productUnitID + 
                                                " WHERE PRODUCT_ID = '" + productID + "'";

                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            //sqlCommand = "DELETE FROM TEMP_MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'";

                            //if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            //    throw internalEX; 

                            i++;
                        }
                        gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "FINISHED UPDATE CURRENT DATA IN LOCAL DATABASE");

                        dataGridView1.DataSource = null;
                        // INSERT NEW PRODUCT CATEGORY
                        sqlCommand = "SELECT * FROM TEMP_PRODUCT_CATEGORY WHERE CONCAT(PRODUCT_ID, '-', CATEGORY_ID) NOT IN (SELECT CONCAT(PRODUCT_ID, '-', CATEGORY_ID) FROM PRODUCT_CATEGORY)";
                        using (rdr = DS.getData(sqlCommand))
                        {
                            gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "INSERT NEW PRODUCT CATEGORY ["+Convert.ToInt32(rdr.HasRows)+"]");

                            if (rdr.HasRows)
                            {
                                dt2.Load(rdr);
                                rdr.Close();
                            
                                dataGridView1.DataSource = dt2;
                                i = 0;
                                while (i < dataGridView1.Rows.Count)
                                {
                                    productID = dataGridView1.Rows[i].Cells["PRODUCT_ID"].Value.ToString();
                                    categoryID = dataGridView1.Rows[i].Cells["CATEGORY_ID"].Value.ToString();

                                    sqlCommand = "INSERT INTO PRODUCT_CATEGORY (PRODUCT_ID, CATEGORY_ID) VALUES (" +
                                                        "'" + productID + "', " + categoryID + ")";

                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;

                                    i++;
                                }
                            }
                        }

                        dataGridView1.DataSource = null;
                        // INSERT NEW DATA
                        sqlCommand = "SELECT * FROM TEMP_MASTER_PRODUCT WHERE PRODUCT_ID NOT IN (SELECT PRODUCT_ID FROM MASTER_PRODUCT)";

                        using (rdr = DS.getData(sqlCommand))
                        {
                            gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "INSERT NEW PRODUCT DATA [" + Convert.ToInt32(rdr.HasRows) + "]");
                            if (rdr.HasRows)
                            {
                                dt3.Load(rdr);
                                rdr.Close();

                                dataGridView1.DataSource = dt3;
                                i = 0;
                                while (i < dataGridView1.Rows.Count)
                                {
                                    productID = MySqlHelper.EscapeString(dataGridView1.Rows[i].Cells["PRODUCT_ID"].Value.ToString());
                                    productBarcode = MySqlHelper.EscapeString(dataGridView1.Rows[i].Cells["PRODUCT_BARCODE"].Value.ToString());
                                    productName = MySqlHelper.EscapeString(dataGridView1.Rows[i].Cells["PRODUCT_NAME"].Value.ToString());
                                    productDescription = MySqlHelper.EscapeString(dataGridView1.Rows[i].Cells["PRODUCT_DESCRIPTION"].Value.ToString());
                                    productBasePrice = dataGridView1.Rows[i].Cells["PRODUCT_BASE_PRICE"].Value.ToString();
                                    productRetailPrice = dataGridView1.Rows[i].Cells["PRODUCT_RETAIL_PRICE"].Value.ToString();
                                    productBulkPrice = dataGridView1.Rows[i].Cells["PRODUCT_BULK_PRICE"].Value.ToString();
                                    productWholesalePrice = dataGridView1.Rows[i].Cells["PRODUCT_WHOLESALE_PRICE"].Value.ToString();
                                    productService = dataGridView1.Rows[i].Cells["PRODUCT_IS_SERVICE"].Value.ToString();
                                    productUnitID = dataGridView1.Rows[i].Cells["UNIT_ID"].Value.ToString();
                                    sqlCommand = "INSERT INTO MASTER_PRODUCT (PRODUCT_ID, PRODUCT_BARCODE, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_BASE_PRICE, PRODUCT_RETAIL_PRICE, PRODUCT_BULK_PRICE, PRODUCT_WHOLESALE_PRICE, UNIT_ID, PRODUCT_STOCK_QTY, PRODUCT_LIMIT_STOCK, PRODUCT_SHELVES, PRODUCT_ACTIVE, PRODUCT_IS_SERVICE) VALUES (" +
                                                        "'" + productID + "', '" + productBarcode + "', '" + productName + "', '" + productDescription + "', " + productBasePrice + ", " + productRetailPrice + ", " + productBulkPrice + ", " + productWholesalePrice + ", " + productUnitID + ", 0, 0, '--00', 1, " + productService + ")";

                                    if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                        throw internalEX;

                                    i++;
                                }
                            }
                        }

                        DS.commit();
                    }
                }

                result = true;
            }
            catch (Exception e)
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "EXCEPTION THROWN ["+e.Message+"]");

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

                gutil.showDBOPError(e, "ROLLBACK");
                result = false;
            }
            finally
            {
                DS.mySqlClose();
            }

            return result;
        }

        private void importFromFileButton_Click(object sender, EventArgs e)
        {
            if (fileNameTextbox.Text != "")
            {
                //this.Cursor = Cursors.WaitCursor;

                //restore database from file
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "SINKRONISASI INFORMASI, FILENAME [" + fileNameTextbox.Text + "]");
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();
                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();

                syncInformation(fileNameTextbox.Text);

                pleaseWait.Close();

                gutil.saveUserChangeLog(globalConstants.MENU_SINKRONISASI_INFORMASI, globalConstants.CHANGE_LOG_UPDATE, "SINKRONISASI INFORMASI DENGAN SERVER VIA USB EXPORT");
                
            }
            else
            {
                String errormessage = "Filename is blank." + Environment.NewLine + "Please find the appropriate file!";
                gutil.showError(errormessage);
            }
        }

        private bool syncToCentralHQ()
        {
            bool result = false;
            Data_Access DS_HQ = new Data_Access();

            // CREATE CONNECTION TO CENTRAL HQ DATABASE SERVER
            gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "TRY TO CREATE CONNECTION TO CENTRAL HQ");
            if (DS_HQ.HQ_mySQLConnect())
            {
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "CONNECTION TO CENTRAL HQ CREATED");

                // DUMP NECESSARY DATA TO LOCAL COPY
                exportData(syncFileName, DS_HQ, true);
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "CENTRAL HQ DATA EXPORTED");

                // CLOSE CONNECTION TO CENTRAL HQ DATABASE SERVER
                DS_HQ.mySqlClose();
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "CLOSE CONNECTION TO CENTRAL HQ");

                // INSERT TO LOCAL DATA
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "SYNC LOCAL INFORMATION WITH DATA FROM CENTRAL HQ [" + syncFileName + "]");
                syncInformation(syncFileName);
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "SYNC LOCAL INFORMATION FINISHED");

                result = true;
            }
            else
            {
                MessageBox.Show("KONEKSI KE PUSAT GAGAL");
                gutil.saveSystemDebugLog(globalConstants.MENU_SINKRONISASI_INFORMASI, "FAILED TO CONNECT TO CENTRAL HQ");

                result = false;
            }

            return result;
        }

        private void importFromServerButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("PASTIKAN TIDAK ADA KONEKSI AKTIF KE DATABASE LOKAL, SEMUA USER DIPASTIKAN LOG OUT", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();
                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();

                if (syncToCentralHQ())
                { 
                    gutil.saveUserChangeLog(globalConstants.MENU_SINKRONISASI_INFORMASI, globalConstants.CHANGE_LOG_UPDATE, "SINKRONISASI INFORMASI DENGAN SERVER VIA ONLINE CONNECTION");
                }
                pleaseWait.Close();
            }
        }
    }
}
