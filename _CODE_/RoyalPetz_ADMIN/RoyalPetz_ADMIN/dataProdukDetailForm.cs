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

using System.Text.RegularExpressions;
using Hotkeys;

namespace RoyalPetz_ADMIN
{
    public partial class dataProdukDetailForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gUtil = new globalUtilities();

        private int originModuleID = 0;
        private int selectedInternalProductID = 0;
        private string productID = "";
        private int selectedUnitID;
        private string photoFileName = "";
        private List<int> currentSelectedKategoriID = new List<int>();
        
        private string stokAwalText = "";
        private string limitStokText = "";
        private string hppValueText = "";
        private string hargaEcerValueText = "";
        private string hargaPartaiText = "";
        private string hargaGrosirValueText = "";
        private string selectedPhoto = "";
        private int options = 0;
        private bool isLoading = false;
        private stokPecahBarangForm parentForm;

        dataKategoriProdukForm selectKategoriForm = null;
        dataSatuanForm selectSatuanForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;

        public dataProdukDetailForm()
        {
            InitializeComponent();
        }

        public dataProdukDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
        }

        public dataProdukDetailForm(int moduleID, stokPecahBarangForm thisParentForm)
        {
            InitializeComponent();

            originModuleID = moduleID;
            parentForm = thisParentForm;
        }

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;
                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;

                if (modifier == Constants.NOMOD)
                    captureAll(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_UP = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_UP.Register();

            ghk_DOWN = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Down, this);
            ghk_DOWN.Register();
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
        }

        public void setSelectedUnitID(int unitID)
        {
            selectedUnitID = unitID;

            loadUnitIDInformation();
        }

        public void addSelectedKategoriID(int kategoriID, bool immediatelyLoad = true)
        {
            bool exist = false;
            for (int i = 0; ((i<currentSelectedKategoriID.Count) && (exist == false));i++)
            {
                if (currentSelectedKategoriID[i] == kategoriID)
                    exist = true;
            }

            if (!exist)
                currentSelectedKategoriID.Add(kategoriID);

            if (immediatelyLoad == true)
                loadKategoriIDInformation();
        }

        private bool checkRegEx(string textToCheck)
        {
            if (gUtil.matchRegEx(textToCheck, globalUtilities.REGEX_NUMBER_WITH_2_DECIMAL))
                return true;

            return false;            
        }

        public dataProdukDetailForm(int moduleID, int productID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedInternalProductID = productID;
        }

        private void stokAwalTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString = "";

            if (isLoading)
                return;
            
            isLoading = true;
            if (stokAwalTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                stokAwalText = "0";
                stokAwalTextBox.Text = "0";

                stokAwalTextBox.SelectionStart = stokAwalTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (stokAwalTextBox.Text.IndexOf('0') == 0 && stokAwalTextBox.Text.Length > 1 && stokAwalTextBox.Text.IndexOf("0.") < 0 )
            {
                tempString = stokAwalTextBox.Text;
                stokAwalTextBox.Text = tempString.Remove(0, 1);
            }

            if (checkRegEx(stokAwalTextBox.Text))
                stokAwalText = stokAwalTextBox.Text;
            else
                stokAwalTextBox.Text = stokAwalText;

            stokAwalTextBox.SelectionStart = stokAwalTextBox.Text.Length;

            isLoading = false;
        }

        private void limitStokTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            isLoading = true;
            if (limitStokTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                limitStokText = "0";
                limitStokTextBox.Text = "0";

                limitStokTextBox.SelectionStart = limitStokTextBox.Text.Length;

                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (limitStokTextBox.Text.IndexOf('0') == 0 && limitStokTextBox.Text.Length > 1 && limitStokTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = limitStokTextBox.Text;
                limitStokTextBox.Text = tempString.Remove(0, 1);
            }

            if (checkRegEx(limitStokTextBox.Text))
                limitStokText = limitStokTextBox.Text;
            else
                limitStokTextBox.Text = limitStokText;

            limitStokTextBox.SelectionStart = limitStokTextBox.Text.Length;

            isLoading = false;
        }

        private void hppTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            isLoading = true;
            if (hppTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                hppValueText = "0";
                hppTextBox.Text = "0";

                hppTextBox.SelectionStart = hppTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (hppTextBox.Text.IndexOf('0') == 0 && hppTextBox.Text.Length > 1 && hppTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = hppTextBox.Text;
                hppTextBox.Text = tempString.Remove(0, 1);
            }

            if (checkRegEx(hppTextBox.Text))
                hppValueText = hppTextBox.Text;
            else
                hppTextBox.Text = hppValueText;

            hppTextBox.SelectionStart = hppTextBox.Text.Length;
            isLoading = false;
        }

        private void hargaEcerTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            isLoading = true;
            if (hargaEcerTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                hargaEcerValueText = "0";
                hargaEcerTextBox.Text = "0";

                hargaEcerTextBox.SelectionStart = hargaEcerTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (hargaEcerTextBox.Text.IndexOf('0') == 0 && hargaEcerTextBox.Text.Length > 1 && hargaEcerTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = hargaEcerTextBox.Text;
                hargaEcerTextBox.Text = tempString.Remove(0, 1);
            }

            if (checkRegEx(hargaEcerTextBox.Text))
                hargaEcerValueText = hargaEcerTextBox.Text;
            else
                hargaEcerTextBox.Text = hargaEcerValueText;

            hargaEcerTextBox.SelectionStart = hargaEcerTextBox.Text.Length;
            isLoading = false;
        }

        private void hargaPartaiTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            isLoading = true;
            if (hargaPartaiTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                hargaPartaiText = "0";
                hargaPartaiTextBox.Text = "0";

                hargaPartaiTextBox.SelectionStart = hargaPartaiTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (hargaPartaiTextBox.Text.IndexOf('0') == 0 && hargaPartaiTextBox.Text.Length > 1 && hargaPartaiTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = hargaPartaiTextBox.Text;
                hargaPartaiTextBox.Text = tempString.Remove(0, 1);
            }

            if (checkRegEx(hargaPartaiTextBox.Text))
                hargaPartaiText = hargaPartaiTextBox.Text;
            else
                hargaPartaiTextBox.Text = hargaPartaiText;

            hargaPartaiTextBox.SelectionStart = hargaPartaiTextBox.Text.Length;
            isLoading = false;
        }

        private void hargaGrosirTextBox_TextChanged(object sender, EventArgs e)
        {
            string tempString;

            if (isLoading)
                return;

            isLoading = true;
            if (hargaGrosirTextBox.Text.Length == 0)
            {
                // IF TEXTBOX IS EMPTY, SET THE VALUE TO 0 AND EXIT THE CHECKING
                hargaGrosirValueText = "0";
                hargaGrosirTextBox.Text = "0";

                hargaGrosirTextBox.SelectionStart = hargaGrosirTextBox.Text.Length;
                isLoading = false;

                return;
            }
            // CHECKING TO PREVENT PREFIX "0" IN A NUMERIC INPUT WHILE ALLOWING A DECIMAL VALUE STARTED WITH "0"
            else if (hargaGrosirTextBox.Text.IndexOf('0') == 0 && hargaGrosirTextBox.Text.Length > 1 && hargaGrosirTextBox.Text.IndexOf("0.") < 0)
            {
                tempString = hargaGrosirTextBox.Text;
                hargaGrosirTextBox.Text = tempString.Remove(0, 1);
            }

            if (checkRegEx(hargaGrosirTextBox.Text))
                hargaGrosirValueText = hargaGrosirTextBox.Text;
            else
                hargaGrosirTextBox.Text = hargaGrosirValueText;

            hargaGrosirTextBox.SelectionStart = hargaGrosirTextBox.Text.Length;
            isLoading = false;
        }

        private void loadProdukData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string productShelves = "";
            string fileName = "";

            DS.mySqlConnect();

            // LOAD PRODUCT DATA
            using (rdr = DS.getData("SELECT * FROM MASTER_PRODUCT WHERE ID =  " + selectedInternalProductID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        kodeProdukTextBox.Text = rdr.GetString("PRODUCT_ID");
                        barcodeTextBox.Text = rdr.GetString("PRODUCT_BARCODE");
                        namaProdukTextBox.Text = rdr.GetString("PRODUCT_NAME");
                        produkDescTextBox.Text = rdr.GetString("PRODUCT_DESCRIPTION");
                        hppTextBox.Text = rdr.GetString("PRODUCT_BASE_PRICE");
                        hargaEcerTextBox.Text = rdr.GetString("PRODUCT_RETAIL_PRICE");
                        hargaPartaiTextBox.Text = rdr.GetString("PRODUCT_BULK_PRICE");
                        hargaGrosirTextBox.Text = rdr.GetString("PRODUCT_WHOLESALE_PRICE"); ;
                        merkTextBox.Text = rdr.GetString("PRODUCT_BRAND");
                        stokAwalTextBox.Text = rdr.GetString("PRODUCT_STOCK_QTY");
                        limitStokTextBox.Text = rdr.GetString("PRODUCT_LIMIT_STOCK");

                        productShelves = rdr.GetString("PRODUCT_SHELVES");

                        noRakBarisTextBox.Text = productShelves.Substring(0, 2);
                        noRakKolomTextBox.Text = productShelves.Substring(2); 

                        selectedUnitID = rdr.GetInt32("UNIT_ID");
                        if (rdr.GetString("PRODUCT_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                        
                        if (rdr.GetString("PRODUCT_IS_SERVICE").Equals("1"))
                        { 
                            produkJasaCheckbox.Checked = true;
                            stokAwalTextBox.Enabled = false;
                            limitStokTextBox.Enabled = false;
                        }
                        else
                        { 
                            produkJasaCheckbox.Checked = false;
                            stokAwalTextBox.Enabled = true;
                            limitStokTextBox.Enabled = true;
                        }

                        fileName = rdr.GetString("PRODUCT_PHOTO_1").Trim();

                        if (!fileName.Equals(""))
                        {
                            try
                            {
                                panelImage.BackgroundImageLayout = ImageLayout.Stretch;
                                panelImage.BackgroundImage = Image.FromFile("PRODUCT_PHOTO/" + fileName);

                                selectedPhoto = "PRODUCT_PHOTO/" + fileName;
                                photoFileName = fileName;
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
        }

        private void loadProductCategoryData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            if (kodeProdukTextBox.Text.Equals(""))
                return;

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM PRODUCT_CATEGORY WHERE PRODUCT_ID =  '" + kodeProdukTextBox.Text +"'"))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        addSelectedKategoriID(rdr.GetInt32("CATEGORY_ID"), false);
                    }
                }
            }

            rdr.Close();
            loadKategoriIDInformation();
        }

        private void loadUnitIDInformation()
        {
            string sqlCommand;
            string unitName = "";
            DS.mySqlConnect();

            if (selectedUnitID == 0)
                return;

            sqlCommand = "SELECT IFNULL(UNIT_NAME, '') FROM MASTER_UNIT WHERE UNIT_ID = " + selectedUnitID;
            unitName = DS.getDataSingleValue(sqlCommand).ToString();

            unitTextBox.Text = unitName;
        }

        private void loadKategoriIDInformation()
        {
            string sqlCommand;
            string kategoriName = "";

            DS.mySqlConnect();

            produkKategoriTextBox.Text = "";

            for (int i = 0;i<currentSelectedKategoriID.Count;i++)
            {
                sqlCommand = "SELECT IFNULL(CATEGORY_NAME, '') FROM MASTER_CATEGORY WHERE CATEGORY_ID = " + currentSelectedKategoriID[i];

                if (!kategoriName.Equals(""))
                    kategoriName = kategoriName + ", ";

                kategoriName = kategoriName + DS.getDataSingleValue(sqlCommand).ToString();
            }

            produkKategoriTextBox.Text = kategoriName;
        }

        private void clearUpProductCategory()
        {
            produkKategoriTextBox.Clear();
            currentSelectedKategoriID.Clear();
        }

        private void searchUnitButton_Click(object sender, EventArgs e)
        {
            if (null == selectSatuanForm || selectSatuanForm.IsDisposed)
                selectSatuanForm = new dataSatuanForm(globalConstants.PRODUK_DETAIL_FORM, this);

            selectSatuanForm.Show();
            selectSatuanForm.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileName = openFileDialog1.FileName;
                    panelImage.BackgroundImageLayout = ImageLayout.Stretch;
                    panelImage.BackgroundImage = Image.FromFile(fileName);

                    selectedPhoto = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void searchKategoriButton_Click(object sender, EventArgs e)
        {
            if (null == selectKategoriForm || selectKategoriForm.IsDisposed)
            {
                selectKategoriForm = new dataKategoriProdukForm(globalConstants.PRODUK_DETAIL_FORM, this);
            }

            selectKategoriForm.Show();
            selectKategoriForm.WindowState = FormWindowState.Normal;
        }

        private bool dataValidated()
        {
            if (namaProdukTextBox.Text.Equals(""))
            {
                errorLabel.Text = "NAMA PRODUK TIDAK BOLEH KOSONG";
                return false;
            }

            if (hppTextBox.Text.Length <= 0 || Convert.ToInt32(hppTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA POKOK TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (hargaEcerTextBox.Text.Length <= 0 || Convert.ToInt32(hargaEcerTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA ECER TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (hargaGrosirTextBox.Text.Length <= 0 || Convert.ToInt32(hargaGrosirTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA PARTAI TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (hargaPartaiTextBox.Text.Length <= 0 || Convert.ToInt32(hargaPartaiTextBox.Text) == 0)
            {
                errorLabel.Text = "HARGA GROSIR TIDAK BOLEH 0 / KOSONG";
                return false;
            }

            if (unitTextBox.Text.Equals(""))
            {
                errorLabel.Text = "UNIT TIDAK BOLEH KOSONG";
                return false;
            }

            if (barcodeTextBox.Text.Length > 0 && (barcodeExist()) && (originModuleID == globalConstants.NEW_PRODUK))
            {
                errorLabel.Text = "BARCODE SUDAH ADA";
                return false;
            }

            string kodeProdukValue = MySqlHelper.EscapeString(kodeProdukTextBox.Text);
            if (kodeProdukValue.Length <= 0)
            {
                errorLabel.Text = "PRODUK ID TIDAK BOLEH KOSONG";
                return false;
            }

            if ((productIDExist(kodeProdukValue)) && (originModuleID != globalConstants.EDIT_PRODUK))
            {
                errorLabel.Text = "PRODUK ID SUDAH ADA";
                return false;
            }

            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";
            string noRakBaris = "";
            string noRakKolom = "";
            MySqlException internalEX = null;

            productID = MySqlHelper.EscapeString(kodeProdukTextBox.Text);
            string produkBarcode = barcodeTextBox.Text;
            if (produkBarcode.Equals(""))
                produkBarcode = "0";

            string produkName = MySqlHelper.EscapeString(namaProdukTextBox.Text.Trim());

            string produkDesc = produkDescTextBox.Text.Trim();
            if (produkDesc.Equals(""))
                produkDesc = " ";
            else
                produkDesc = MySqlHelper.EscapeString(produkDesc);

            string produkHargaPokok = hppTextBox.Text;
            string produkHargaEcer = hargaEcerTextBox.Text;
            string produkHargaPartai = hargaPartaiTextBox.Text;
            string produkHargaGrosir = hargaGrosirTextBox.Text;

            string produkBrand = merkTextBox.Text.Trim();
            if (produkBrand.Equals(""))
                produkBrand = " ";
            else
                produkBrand = MySqlHelper.EscapeString(produkBrand);

            string produkQty = stokAwalTextBox.Text;
            if (produkQty.Equals(""))
                produkQty = "0";

            string limitStock = limitStokTextBox.Text;
            if (limitStock.Equals(""))
                limitStock = "0";

            noRakBaris = MySqlHelper.EscapeString(noRakBarisTextBox.Text);
            noRakKolom= noRakKolomTextBox.Text;
            
            while (noRakBaris.Length < 2)
                noRakBaris = "-" + noRakBaris;

            while (noRakKolom.Length < 2)
                noRakKolom = "0" + noRakKolom;

            string produkShelves = noRakBaris + noRakKolom;

            byte produkSvc = 0;
            if (produkJasaCheckbox.Checked)
                produkSvc = 1;
            else
                produkSvc = 0;

            byte produkStatus = 0;
            if (nonAktifCheckbox.Checked)
                produkStatus = 0;
            else
                produkStatus = 1;

            string produkPhoto = " ";
            if (!selectedPhoto.Equals(""))
                produkPhoto = productID + ".jpg";

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.EDIT_PRODUK:
                            // UPDATE MASTER_PRODUK TABLE
                            sqlCommand = "UPDATE MASTER_PRODUCT SET " +
                                                "PRODUCT_BARCODE = '" + produkBarcode + "', " +
                                                "PRODUCT_NAME =  '" + produkName + "', " +
                                                "PRODUCT_DESCRIPTION =  '" + produkDesc + "', " +
                                                "PRODUCT_BASE_PRICE = " + produkHargaPokok + ", " +
                                                "PRODUCT_RETAIL_PRICE = " + produkHargaEcer + ", " +
                                                "PRODUCT_BULK_PRICE =  " + produkHargaPartai + ", " +
                                                "PRODUCT_WHOLESALE_PRICE = " + produkHargaGrosir + ", " +
                                                "PRODUCT_PHOTO_1 = '" + produkPhoto + "', " +
                                                "UNIT_ID = " + selectedUnitID + ", " +
                                                "PRODUCT_STOCK_QTY = " + produkQty + ", " +
                                                "PRODUCT_LIMIT_STOCK = " + limitStock + ", " +
                                                "PRODUCT_SHELVES = '" + produkShelves + "', " +
                                                "PRODUCT_ACTIVE = " + produkStatus + ", " +
                                                "PRODUCT_BRAND = '" + produkBrand + "', " +
                                                "PRODUCT_IS_SERVICE = " + produkSvc + " " +
                                                "WHERE PRODUCT_ID = '" + productID + "'";

                        gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "UPDATE CURRENT PRODUCT DATA [" + productID + "]");
                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // UPDATE PRODUCT_CATEGORY TABLE
                            gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "UPDATE PRODUCT CATEGORY FOR [" + productID + "]");

                            // delete the content first, and insert the new data based on the currentSelectedKategoryID LIST
                            sqlCommand = "DELETE FROM PRODUCT_CATEGORY WHERE PRODUCT_ID = '" + productID + "'";
                            gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "DELETE CURRENT PRODUCT CATEGORY FOR [" + productID + "]");
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;

                            // SAVE TO PRODUCT_CATEGORY TABLE
                            gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "INSERT PRODUCT CATEGORY FOR [" + productID + "]");

                            for (int i = 0; i < currentSelectedKategoriID.Count(); i++)
                            {
                                sqlCommand = "INSERT INTO PRODUCT_CATEGORY (PRODUCT_ID, CATEGORY_ID) VALUES ('" + productID + "', " + currentSelectedKategoriID[i] + ")";
                                if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                    throw internalEX;
                            }
                        break;

                    default: // NEW PRODUK
                        // SAVE TO MASTER_PRODUK TABLE
                        sqlCommand = "INSERT INTO MASTER_PRODUCT " +
                                            "(PRODUCT_ID, PRODUCT_BARCODE, PRODUCT_NAME, PRODUCT_DESCRIPTION, PRODUCT_BASE_PRICE, PRODUCT_RETAIL_PRICE, PRODUCT_BULK_PRICE, PRODUCT_WHOLESALE_PRICE, PRODUCT_PHOTO_1, UNIT_ID, PRODUCT_STOCK_QTY, PRODUCT_LIMIT_STOCK, PRODUCT_SHELVES, PRODUCT_ACTIVE, PRODUCT_BRAND, PRODUCT_IS_SERVICE) " +
                                            "VALUES " +
                                            "('" + productID + "', '" + produkBarcode + "', '" + produkName + "', '" + produkDesc + "', " + produkHargaPokok + ", " + produkHargaEcer + ", " + produkHargaPartai + ", " + produkHargaGrosir + ", '" + produkPhoto + "', " + selectedUnitID + ", " + produkQty + ", " + limitStock + ", '" + produkShelves + "', " + produkStatus + ", '" + produkBrand + "', " + produkSvc + ")";

                        gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "INSERT NEW PRODUCT [" + productID + "]");

                        if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                            throw internalEX;

                        // SAVE TO PRODUCT_CATEGORY TABLE
                        gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "INSERT PRODUCT CATEGORY FOR [" + productID + "]");

                        for (int i = 0; i < currentSelectedKategoriID.Count(); i++)
                        {
                            sqlCommand = "INSERT INTO PRODUCT_CATEGORY (PRODUCT_ID, CATEGORY_ID) VALUES ('" + productID + "', " + currentSelectedKategoriID[i] + ")";
                            if (!DS.executeNonQueryCommand(sqlCommand, ref internalEX))
                                throw internalEX;
                        }
                        break;
                    
                }

                if (!selectedPhoto.Equals("PRODUCT_PHOTO/" + produkPhoto) && !selectedPhoto.Equals(""))// && result == true)
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "SET PRODUCT IMAGE [" + selectedPhoto + "]");

                    panelImage.BackgroundImage = null;
                    System.IO.File.Copy(selectedPhoto, "PRODUCT_PHOTO/" + produkPhoto + "_temp");
                    gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "COPY SELECTED IMAGE TO PRODUCT_PHOTO FOLDER");

                    if (System.IO.File.Exists("PRODUCT_PHOTO/" + produkPhoto))
                    {
                        gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "DELETE CURRENT PRODUCT IMAGE [" + productID + "]");

                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        System.IO.File.Delete("PRODUCT_PHOTO/" + produkPhoto);
                    }

                    System.IO.File.Move("PRODUCT_PHOTO/" + produkPhoto + "_temp", "PRODUCT_PHOTO/" + produkPhoto);
                    panelImage.BackgroundImage = Image.FromFile("PRODUCT_PHOTO/" + produkPhoto);

                    gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "RENAME AND SET NEW PRODUCT IMAGE");
                }

                DS.commit();
                result = true;
            }
            catch (Exception e)
            {
                gUtil.saveSystemDebugLog(globalConstants.MENU_TAMBAH_PRODUK, "EXCEPTION THROWN [" + e.Message+ "]");
                try
                {
                    DS.rollBack();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        gUtil.showDBOPError(ex, "ROLLBACK");
                    }
                }

                gUtil.showDBOPError(e, "ROLLBACK");
                result = false;
            }
            finally
            {
               
                DS.mySqlClose();
            }

            return result;
        }

        private bool saveData()
        {
            bool result = false; 
            if (dataValidated())
            {
                smallPleaseWait pleaseWait = new smallPleaseWait();
                pleaseWait.Show();

                //  ALlow main UI thread to properly display please wait form.
                Application.DoEvents();
                result = saveDataTransaction();

                pleaseWait.Close();

                return result;
            }

            return false;
        }

        private int getInternalProductID(string productID)
        {
            int result;
            DS.mySqlConnect();

            result = Convert.ToInt32(DS.getDataSingleValue("SELECT ID FROM MASTER_PRODUCT WHERE PRODUCT_ID = '" + productID + "'"));

            return result;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int internalProductID;
            if (saveData())
            {
                gUtil.showSuccess(options);

                if (originModuleID == globalConstants.STOK_PECAH_BARANG)
                {
                    internalProductID = getInternalProductID(productID);
                    parentForm.setNewSelectedProductID(internalProductID);

                    this.Close();
                }

                switch (originModuleID)
                {
                    case globalConstants.NEW_PRODUK:
                        gUtil.saveUserChangeLog(globalConstants.MENU_PRODUK, globalConstants.CHANGE_LOG_INSERT, "INSERT NEW PRODUK [" + namaProdukTextBox.Text + "]");
                        break;
                    case globalConstants.EDIT_PRODUK:
                        if (nonAktifCheckbox.Checked == true)
                            gUtil.saveUserChangeLog(globalConstants.MENU_PRODUK, globalConstants.CHANGE_LOG_UPDATE, "UPDATE PRODUK [" + namaProdukTextBox.Text + "] STATUS PRODUK NON-AKTIF");
                        else
                            gUtil.saveUserChangeLog(globalConstants.MENU_PRODUK, globalConstants.CHANGE_LOG_UPDATE, "UPDATE PRODUK [" + namaProdukTextBox.Text + "] STATUS PRODUK AKTIF");
                        break;
                }

                gUtil.ResetAllControls(this);

                stokAwalTextBox.Text = "0";
                limitStokTextBox.Text = "0";
                hppTextBox.Text = "0";
                hargaEcerTextBox.Text = "0";
                hargaGrosirTextBox.Text = "0";
                hargaPartaiTextBox.Text = "0";

                selectedPhoto = "";
                panelImage.BackgroundImage = null;
                
                errorLabel.Text = "";
                
                originModuleID = globalConstants.NEW_PRODUK;
                options = gUtil.INS;
                kodeProdukTextBox.Enabled = true;
            }
            if (originModuleID== globalConstants.NEW_PRODUK)
            {
                kodeProdukTextBox.Select();
            } else
            {
                barcodeTextBox.Select();
            }
        }

        private bool productIDExist(string productID)
        {
            bool result = false;

            if (!DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_ID = '"+ productID + "'").ToString().Equals("0"))
            {
                result = true;
            }

            return result;
        }

        private bool barcodeExist()
        {
            bool result = false;

            if (!DS.getDataSingleValue("SELECT COUNT(1) FROM MASTER_PRODUCT WHERE PRODUCT_BARCODE = '" + barcodeTextBox.Text + "'").ToString().Equals("0"))
            {
                result = true;
            }

            return result;
        }

        private void kodeProdukTextBox_TextChanged(object sender, EventArgs e)
        {
            string kodeProdukValue;

            if (isLoading)
                return;

            if (kodeProdukTextBox.Text.IndexOf('\'') >= 0)
                kodeProdukTextBox.Text = kodeProdukTextBox.Text.Remove(kodeProdukTextBox.Text.IndexOf('\''), 1);

            kodeProdukValue = MySqlHelper.EscapeString(gUtil.allTrim(kodeProdukTextBox.Text));

            if ((productIDExist(kodeProdukValue)) && (originModuleID != globalConstants.EDIT_PRODUK))
            {
                errorLabel.Text = "PRODUK ID SUDAH ADA";
                kodeProdukTextBox.Focus();
                //kodeProdukTextBox.BackColor = Color.Red;
            }
            else
            {
                errorLabel.Text = "";
                //kodeProdukTextBox.BackColor = Color.White;
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gUtil.ResetAllControls(this);

            stokAwalTextBox.Text = "0";
            limitStokTextBox.Text = "0";
            hppTextBox.Text = "0";
            hargaEcerTextBox.Text = "0";
            hargaGrosirTextBox.Text = "0";
            hargaPartaiTextBox.Text = "0";

            selectedPhoto = "";
            panelImage.BackgroundImage = null;
            
            errorLabel.Text = "";
            
            currentSelectedKategoriID.Clear();
            originModuleID = globalConstants.NEW_PRODUK;
            options = gUtil.INS;
            kodeProdukTextBox.Enabled = true;
        }

        private void barcodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            barcodeTextBox.Text = gUtil.allTrim(barcodeTextBox.Text);

            if (barcodeTextBox.Text.Length > 0 && (barcodeExist()) && (originModuleID == globalConstants.NEW_PRODUK))
            {
                errorLabel.Text = "BARCODE SUDAH ADA";
                barcodeTextBox.Focus();
                barcodeTextBox.BackColor = Color.Red;
            }
            else
            {
                errorLabel.Text = "";
                barcodeTextBox.BackColor = Color.White;
            }
        }

        private void dataProdukDetailForm_Load(object sender, EventArgs e)
        {
            int userAccessOption = 0;
            Button[] arrButton = new Button[2];

            errorLabel.Text = "";

            isLoading = true;
            loadProdukData();

            loadUnitIDInformation();

            loadProductCategoryData();

            loadKategoriIDInformation();

            switch (originModuleID)
            {
                case globalConstants.NEW_PRODUK:
                case globalConstants.STOK_PECAH_BARANG:
                    options = gUtil.INS;
                    kodeProdukTextBox.Enabled = true;
                    break;
                case globalConstants.EDIT_PRODUK:
                    options = gUtil.UPD;
                    kodeProdukTextBox.Enabled = false;
                    break;
            }
            isLoading = false;

            userAccessOption = DS.getUserAccessRight(globalConstants.MENU_TAMBAH_PRODUK, gUtil.getUserGroupID());

            if (originModuleID == globalConstants.NEW_PRODUK)
            {
                if (userAccessOption != 2 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }
            else if (originModuleID == globalConstants.EDIT_PRODUK)
            {
                if (userAccessOption != 4 && userAccessOption != 6)
                {
                    gUtil.setReadOnlyAllControls(this);
                }
            }

            arrButton[0] = saveButton;
            arrButton[1] = resetbutton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);
        }

        private void namaProdukTextBox_TextChanged(object sender, EventArgs e)
        {
            if (namaProdukTextBox.Text.IndexOf('\'') >= 0)
                namaProdukTextBox.Text = namaProdukTextBox.Text.Remove(namaProdukTextBox.Text.IndexOf('\''), 1);
        }

        private void produkDescTextBox_TextChanged(object sender, EventArgs e)
        {
            if (produkDescTextBox.Text.IndexOf('\'') >= 0)
                produkDescTextBox.Text = produkDescTextBox.Text.Remove(produkDescTextBox.Text.IndexOf('\''), 1);
        }

        private void noRakKolomTextBox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate
            {
                noRakKolomTextBox.SelectAll();
            });
            //noRakKolomTextBox.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //PRINT BARCODE
            string sqlCommandx = "SELECT PRODUCT_ID AS 'ID', CONCAT('*',PRODUCT_BARCODE,'*') AS 'BARCODE1', PRODUCT_BARCODE AS 'BARCODE2', PRODUCT_NAME AS 'NAME', PRODUCT_BRAND AS ' BRAND', PRODUCT_RETAIL_PRICE AS 'PRICE'" +
                                    " FROM master_product" +
                                    " WHERE PRODUCT_ID = '" + kodeProdukTextBox.Text + "'";
            DS.writeXML(sqlCommandx, globalConstants.PrintBarcodeXML);
            PrintBarcodeForm displayedForm = new PrintBarcodeForm();
            displayedForm.ShowDialog(this);
        }

        private void dataProdukDetailForm_Activated(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void dataProdukDetailForm_Deactivate(object sender, EventArgs e)
        {
            unregisterGlobalHotkey();
        }

        private void produkJasaCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (produkJasaCheckbox.Checked)
            {
                // PRODUCT IS SERVICE
                stokAwalTextBox.Enabled = false;
                limitStokTextBox.Enabled = false;
            }
            else
            {
                stokAwalTextBox.Enabled = true;
                limitStokTextBox.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearUpProductCategory();
        }
    }
}
