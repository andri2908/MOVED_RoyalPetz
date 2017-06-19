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

namespace AlphaSoft
{
    public partial class ReportStockInOutSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();
        private int originModuleID = 0;

        public ReportStockInOutSearchForm()
        {
            InitializeComponent();
        }

        public ReportStockInOutSearchForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void LoadSupplier()
        {
            SupplierNameCombobox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox1.Checked)
            {
                SQLcommand = "SELECT SUPPLIER_ID AS 'ID', SUPPLIER_FULL_NAME AS 'NAME' FROM MASTER_SUPPLIER ORDER BY NAME ASC";
            }
            else
            {
                SQLcommand = "SELECT SUPPLIER_ID AS 'ID', SUPPLIER_FULL_NAME AS 'NAME' FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1 ORDER BY NAME ASC";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    SupplierNameCombobox.Visible = true;
                    nonactivecheckbox1.Visible = true;
                    ErrorLabel1.Visible = false;
                    dt.Load(rdr);
                    SupplierNameCombobox.DataSource = dt;
                    SupplierNameCombobox.ValueMember = "ID";
                    SupplierNameCombobox.DisplayMember = "NAME";
                    SupplierNameCombobox.SelectedIndex = 0;
                }
                else
                {
                    SupplierNameCombobox.Visible = false;
                    nonactivecheckbox1.Visible = false;
                    ErrorLabel1.Visible = true;
                }
            }
        }

        private void LoadCustomer()
        {
            ErrorLabel1.Visible = false;
            CustomercomboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox1.Checked)
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER ORDER BY NAME ASC";
            }
            else
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1 ORDER BY NAME ASC";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                dt.Load(rdr);

                DataRow workRow = dt.NewRow();
                workRow["ID"] = "0";
                workRow["NAME"] = "P-UMUM";

                dt.Rows.Add(workRow);

                CustomercomboBox.DataSource = dt;
                CustomercomboBox.ValueMember = "ID";
                CustomercomboBox.DisplayMember = "NAME";
            }
            CustomercomboBox.SelectedIndex = CustomercomboBox.FindStringExact("P-UMUM");
        }

        private void loadProduct()
        {
            ProductcomboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";

            if (originModuleID == globalConstants.REPORT_STOCK_PECAH_BARANG) // read internal id, instead of kode product
            {
                if (nonactivecheckbox2.Checked)
                {
                    SQLcommand = "SELECT ID AS 'ID', PRODUCT_NAME AS 'NAME' FROM MASTER_PRODUCT ORDER BY NAME ASC";
                }
                else
                {
                    SQLcommand = "SELECT ID AS 'ID', PRODUCT_NAME AS 'NAME' FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY NAME ASC";
                }
            }
            else
            { 
                if (nonactivecheckbox2.Checked)
                {
                    SQLcommand = "SELECT PRODUCT_ID AS 'ID', PRODUCT_NAME AS 'NAME' FROM MASTER_PRODUCT ORDER BY NAME ASC";
                }
                else
                {
                    SQLcommand = "SELECT PRODUCT_ID AS 'ID', PRODUCT_NAME AS 'NAME' FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1 ORDER BY NAME ASC";
                }
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    ProductcomboBox.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    ErrorLabel2.Visible = false;
                    dt.Load(rdr);
                    ProductcomboBox.DataSource = dt;
                    ProductcomboBox.ValueMember = "ID";
                    ProductcomboBox.DisplayMember = "NAME";
                    ProductcomboBox.SelectedIndex = 0;
                }
                else
                {
                    ProductcomboBox.Visible = false;
                    nonactivecheckbox2.Visible = false;
                    ErrorLabel2.Visible = true;

                }
            }
        }

        private void loadTags()
        {
            TagsComboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox2.Checked)
            {
                SQLcommand = "SELECT CATEGORY_ID AS 'ID', CATEGORY_NAME AS 'NAME' FROM MASTER_CATEGORY ORDER BY NAME ASC";
            }
            else
            {
                SQLcommand = "SELECT CATEGORY_ID AS 'ID', CATEGORY_NAME AS 'NAME' FROM MASTER_CATEGORY WHERE CATEGORY_ACTIVE = 1 ORDER BY NAME ASC";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    TagsComboBox.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    ErrorLabel2.Visible = false;
                    dt.Load(rdr);

                    //DataRow workRow = dt.NewRow();
                    //workRow["ID"] = "0";
                    //workRow["NAME"] = "SEMUA";
                    //dt.Rows.Add(workRow);

                    TagsComboBox.DataSource = dt;
                    TagsComboBox.ValueMember = "ID";
                    TagsComboBox.DisplayMember = "NAME";
                    TagsComboBox.SelectedIndex = 0;
                }
                else
                {
                    TagsComboBox.Visible = false;
                    nonactivecheckbox2.Visible = false;
                    ErrorLabel2.Visible = true;
                }
            }
        }

        private void ReportStockInOutSearchForm_Load(object sender, EventArgs e)
        {
            ErrorLabel1.Visible = false;
            ErrorLabel2.Visible = false;
            gutil.reArrangeTabOrder(this);

            datefromPicker.Format = DateTimePickerFormat.Custom;
            datefromPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            datetoPicker.Format = DateTimePickerFormat.Custom;
            datetoPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            //LabelOptions1.Text = "Supplier";
            //SupplierNameCombobox.Visible = true;
            //LabelOptions2.Text = "Produk";

            switch (originModuleID)
            {
                case globalConstants.REPORT_PURCHASE_RETURN:
                    LabelOptions1.Text = "Supplier";
                    checkBox1.Visible = true;
                    SupplierNameCombobox.Visible = true;
                    CustomercomboBox.Visible = false;
                    nonactivecheckbox1.Visible = true;
                    checkBox2.Visible = true;
                    ProductcomboBox.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    LoadSupplier();
                    loadProduct();
                    break;
                case globalConstants.REPORT_SALES_RETURN:
                    LabelOptions1.Text = "Pelanggan";
                    checkBox1.Visible = true;
                    SupplierNameCombobox.Visible = false;
                    CustomercomboBox.Visible = true;
                    nonactivecheckbox1.Visible = true;
                    checkBox2.Visible = true;
                    ProductcomboBox.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    LoadCustomer();
                    loadProduct();
                    break;
                case globalConstants.REPORT_REQUEST_RETURN:
                    checkBox1.Visible = false;
                    nonactivecheckbox1.Visible = false;
                    LabelOptions1.Visible = false;
                    SupplierNameCombobox.Visible= false;
                    CustomercomboBox.Visible = false;
                    checkBox2.Visible = true;
                    ProductcomboBox.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    loadProduct();
                    break;
                case globalConstants.REPORT_PRODUCT_MUTATION:
                    checkBox1.Visible = false;
                    nonactivecheckbox1.Visible = false;
                    LabelOptions1.Visible = false;
                    SupplierNameCombobox.Visible = false;
                    CustomercomboBox.Visible = false;
                    checkBox2.Visible = true;
                    ProductcomboBox.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    loadProduct();
                    break;
                case globalConstants.REPORT_STOCK_DEVIATION:
                    checkBox1.Visible = false;
                    nonactivecheckbox1.Visible = false;
                    LabelOptions1.Visible = false;
                    SupplierNameCombobox.Visible = false;
                    CustomercomboBox.Visible = false;
                    checkBox2.Visible = true;
                    ProductcomboBox.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    loadProduct();
                    break;
                case globalConstants.REPORT_STOCK:
                    checkBox1.Visible = false;
                    nonactivecheckbox1.Visible = false;
                    LabelOptions1.Visible = false;
                    SupplierNameCombobox.Visible = false;
                    CustomercomboBox.Visible = false;
                    ProductcomboBox.Visible = false;
                    checkBox2.Visible = true;
                    ProductcomboBox.Visible = false;
                    nonactivecheckbox2.Visible = true;
                    LabelOptions2.Text = "Kategori";
                    groupBox1.Text = "Kriteria Pencarian Stock Berdasar Kategori";
                    label1.Visible = false;
                    label2.Visible = false;
                    datetoPicker.Visible = false;
                    datefromPicker.Visible = false;
                    loadTags();
                    break;
                case globalConstants.REPORT_STOCK_PECAH_BARANG:
                    checkBox1.Visible = false;
                    nonactivecheckbox1.Visible = false;
                    LabelOptions1.Visible = false;
                    SupplierNameCombobox.Visible = false;
                    CustomercomboBox.Visible = false;
                    ProductcomboBox.Visible = true;
                    checkBox2.Visible = true;
                    nonactivecheckbox2.Visible = true;
                    LabelOptions2.Text = "Produk";
                    groupBox1.Text = "Kriteria Pencarian Stock Pecah Barang";
                    label1.Visible = true;
                    label2.Visible = true;
                    datetoPicker.Visible = true;
                    datefromPicker.Visible = true;
                    loadProduct();
                    break;
            }
         
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;
            int cust_id = 0;
            int supplier_id = 0;
            int tags_id = 0;
            string prod_id = "";
            bool result;
            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));
            DS.mySqlConnect();
            string sqlCommandx = "";
            string supplier = " ";
            string customer = " ";
            string produk = " ";
            string tags = " ";

            if (checkBox1.Checked == false)
            {
                switch (originModuleID)
                {
                    case globalConstants.REPORT_PURCHASE_RETURN:
                        result = int.TryParse(SupplierNameCombobox.SelectedValue.ToString(), out supplier_id);
                        supplier = "AND RH.SUPPLIER_ID";
                        supplier = " = " + supplier_id + " "; 
                        break;
                    case globalConstants.REPORT_SALES_RETURN:
                        result = int.TryParse(CustomercomboBox.SelectedValue.ToString(), out cust_id);
                        if ( cust_id > 0)
                        {
                            customer = "AND RH.CUSTOMER_ID";
                            customer = " = " + cust_id + " ";
                        }
                        break;
                }
            }

            if (checkBox2.Checked == false)
            {
                switch (originModuleID)
                {
                    case globalConstants.REPORT_STOCK:
                    case globalConstants.REPORT_STOCK_EXPIRY:
                        result = int.TryParse(TagsComboBox.SelectedValue.ToString(), out tags_id);
                        if (tags_id > 0)
                        {
                            tags = "AND PC.CATEGORY_ID";
                            tags += " = " + tags_id + " ";
                        }
                        break;
                    case globalConstants.REPORT_STOCK_PECAH_BARANG:
                        produk = "AND MP.ID";
                        produk = produk + " = '" + ProductcomboBox.SelectedValue + "' ";
                        break;
                    default :
                        produk = "AND PA.PRODUCT_ID";
                        //switch (originModuleID)
                        //{
                        //    case globalConstants.REPORT_PURCHASE_RETURN:
                        //        produk = "AND RD.PRODUCT_ID";
                        //        break;
                        //    case globalConstants.REPORT_SALES_RETURN:
                        //        produk = "AND RD.PRODUCT_ID";
                        //        break;
                        //    case globalConstants.REPORT_REQUEST_RETURN:
                        //        produk = "AND RD.PRODUCT_ID";
                        //        break;
                        //    case globalConstants.REPORT_PRODUCT_MUTATION:
                        //        produk = "AND MD.PRODUCT_ID";
                        //        break;
                        //    case globalConstants.REPORT_STOCK_DEVIATION:
                        //        produk = "AND PA.PRODUCT_ID";
                        //        break;
                        //}
                        produk = produk + " = '" + ProductcomboBox.SelectedValue + "' ";
                        break;
                }
            }

            switch (originModuleID)
            {
                case globalConstants.REPORT_PURCHASE_RETURN:
                    sqlCommandx = "SELECT RH.RP_ID AS 'ID', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', RH.RP_DATE AS 'TANGGAL', RH.RP_TOTAL AS 'TOTAL', IF(RH.RP_PROCESSED=1,'SUDAH DIPROSES','BELUM DIPROSES') AS 'STATUS', " +
                                    "MP.PRODUCT_NAME AS 'PRODUK', RD.PRODUCT_BASEPRICE AS 'HARGA', RD.PRODUCT_QTY AS 'QTY', RD.RP_DESCRIPTION AS 'DESKRIPSI', RD.RP_SUBTOTAL AS 'SUBTOTAL' " +
                                    "FROM RETURN_PURCHASE_HEADER RH, MASTER_SUPPLIER MS, RETURN_PURCHASE_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RH.SUPPLIER_ID = MS.SUPPLIER_ID AND RH.RP_ID = RD.RP_ID AND RD.PRODUCT_ID = MP.PRODUCT_ID " + produk + supplier + 
                                    "AND DATE_FORMAT(RH.RP_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(RH.RP_DATE, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY RD.ID";
                    DS.writeXML(sqlCommandx, globalConstants.PurchaseReturnXML);
                    ReportPurchaseReturnForm displayedForm1 = new ReportPurchaseReturnForm();
                    displayedForm1.ShowDialog(this);
                    break;
                case globalConstants.REPORT_SALES_RETURN:
                    sqlCommandx = "SELECT RH.RS_INVOICE AS 'INVOICE', RH.SALES_INVOICE AS 'NOTAJUAL', MC.CUSTOMER_FULL_NAME AS 'CUSTOMER', RH.RS_DATETIME AS 'TANGGAL', " +
                                    "RH.RS_TOTAL AS 'TOTAL', MP.PRODUCT_NAME AS 'PRODUK', RD.PRODUCT_SALES_PRICE AS 'HARGAJUAL', RD.PRODUCT_SALES_QTY AS 'JMLJUAL', " +
                                    "RD.PRODUCT_RETURN_QTY AS 'JMLRETUR', RD.RS_DESCRIPTION AS 'DESKRIPSI', RD.RS_SUBTOTAL AS 'SUBTOTAL' " +
                                    "FROM RETURN_SALES_HEADER RH, MASTER_CUSTOMER MC, RETURN_SALES_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RH.CUSTOMER_ID = MC.CUSTOMER_ID AND RH.RS_INVOICE = RD.RS_INVOICE AND RD.PRODUCT_ID = MP.PRODUCT_ID " + produk + customer +
                                    "AND DATE_FORMAT(RH.RS_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(RH.RS_DATETIME, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY RD.ID UNION " +
                                    "SELECT RH.RS_INVOICE AS 'INVOICE', RH.SALES_INVOICE AS 'NOTAJUAL', 'P-UMUM' AS 'CUSTOMER', RH.RS_DATETIME AS 'TANGGAL', " +
                                    "RH.RS_TOTAL AS 'TOTAL', MP.PRODUCT_NAME AS 'PRODUK', RD.PRODUCT_SALES_PRICE AS 'HARGAJUAL', RD.PRODUCT_SALES_QTY AS 'JMLJUAL', " +
                                    "RD.PRODUCT_RETURN_QTY AS 'JMLRETUR', RD.RS_DESCRIPTION AS 'DESKRIPSI', RD.RS_SUBTOTAL AS 'SUBTOTAL' " +
                                    "FROM RETURN_SALES_HEADER RH, RETURN_SALES_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RH.CUSTOMER_ID = 0 AND RH.RS_INVOICE = RD.RS_INVOICE AND RD.PRODUCT_ID = MP.PRODUCT_ID " + produk + 
                                    "AND DATE_FORMAT(RH.RS_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(RH.RS_DATETIME, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY RD.ID";
                    DS.writeXML(sqlCommandx, globalConstants.SalesReturnXML);
                    ReportSalesReturnForm displayedForm2 = new ReportSalesReturnForm();
                    displayedForm2.ShowDialog(this);
                    break;
                case globalConstants.REPORT_REQUEST_RETURN:
                    sqlCommandx = "SELECT RH.RP_ID AS 'ID', RH.RP_DATE AS 'TANGGAL', RH.RP_TOTAL AS 'TOTAL', IF(RH.RP_PROCESSED=1,'SUDAH DIPROSES','BELUM DIPROSES') AS 'STATUS', " +
                                    "MP.PRODUCT_NAME AS 'PRODUK', RD.PRODUCT_BASEPRICE AS 'HARGA', RD.PRODUCT_QTY AS 'QTY', RD.RP_DESCRIPTION AS 'DESKRIPSI', RD.RP_SUBTOTAL AS 'SUBTOTAL' " +
                                    "FROM RETURN_PURCHASE_HEADER RH, RETURN_PURCHASE_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RH.SUPPLIER_ID = 0 AND RH.RP_ID = RD.RP_ID AND RD.PRODUCT_ID = MP.PRODUCT_ID " + produk +
                                    "AND DATE_FORMAT(RH.RP_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(RH.RP_DATE, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY RD.ID";
                    DS.writeXML(sqlCommandx, globalConstants.RequestReturnXML);
                    ReportRequestReturnForm displayedForm3 = new ReportRequestReturnForm();
                    displayedForm3.ShowDialog(this);
                    break;
                case globalConstants.REPORT_PRODUCT_MUTATION:
                    sqlCommandx = "SELECT MH.PM_INVOICE AS 'INVOICE', MH.PM_DATETIME AS 'TANGGAL', 'PUSAT' AS 'DARI', MB.BRANCH_NAME AS 'KE', MH.PM_TOTAL AS 'TOTAL', " +
                                    "IF(MH.PM_RECEIVED = 1, 'DITERIMA', 'BELUM DITERIMA') AS 'STATUS', MP.PRODUCT_NAME AS 'PRODUK', MD.PRODUCT_BASE_PRICE AS 'HPP', " +
                                    "MD.PRODUCT_QTY AS 'QTY', MD.PM_SUBTOTAL AS 'SUBTOTAL' " +
                                    "FROM PRODUCTS_MUTATION_HEADER MH, MASTER_BRANCH MB, PRODUCTS_MUTATION_DETAIL MD, MASTER_PRODUCT MP " +
                                    "WHERE MH.BRANCH_ID_TO = MB.BRANCH_ID AND MH.PM_INVOICE = MD.PM_INVOICE AND MD.PRODUCT_ID = MP.PRODUCT_ID " + produk +
                                    "AND DATE_FORMAT(MH.PM_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(MH.PM_DATETIME, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY MD.ID";
                    DS.writeXML(sqlCommandx, globalConstants.ProductMutationXML);
                    ReportProductMutationForm displayedForm4 = new ReportProductMutationForm();
                    displayedForm4.ShowDialog(this);
                    break;
                case globalConstants.REPORT_STOCK_DEVIATION:
                    sqlCommandx = "SELECT PA.PRODUCT_ADJUSTMENT_DATE AS 'DATE', MP.PRODUCT_ID AS 'ID', MP.PRODUCT_NAME AS 'NAMA PRODUK', MP.PRODUCT_DESCRIPTION AS 'DESKRIPSI', " +
                                    "MP.PRODUCT_BRAND AS 'MERK', MP.PRODUCT_SHELVES AS 'NOMOR RAK', (PA.PRODUCT_NEW_STOCK_QTY - PA.PRODUCT_OLD_STOCK_QTY) AS 'STOK', MU.UNIT_NAME AS 'SATUAN', " +
                                    "IF((PA.PRODUCT_NEW_STOCK_QTY - PA.PRODUCT_OLD_STOCK_QTY) > 0, 'POSITIVE', 'NEGATIVE') AS 'DEVIASI' " +
                                    "FROM PRODUCT_ADJUSTMENT PA, MASTER_PRODUCT MP, MASTER_UNIT MU " +
                                    "WHERE PA.PRODUCT_ID = MP.PRODUCT_ID AND MP.UNIT_ID = MU.UNIT_ID " + produk +
                                    "AND DATE_FORMAT(PA.PRODUCT_ADJUSTMENT_DATE, '%Y%m%d') >= '" + dateFrom +"' AND DATE_FORMAT(PA.PRODUCT_ADJUSTMENT_DATE, '%Y%m%d') <= '" + dateTo+ "' " +
                                    "GROUP BY PA.ID " +
                                    "ORDER BY DEVIASI ASC";
                    DS.writeXML(sqlCommandx, globalConstants.ProductDeviationXML);
                    ReportStockDeviationForm displayedForm5 = new ReportStockDeviationForm();
                    displayedForm5.ShowDialog(this);
                    break;
                case globalConstants.REPORT_STOCK:
                        sqlCommandx = "SELECT MP.PRODUCT_NAME, MP.PRODUCT_STOCK_QTY, MU.UNIT_NAME, MC.CATEGORY_NAME " +
                                        "FROM MASTER_PRODUCT MP, PRODUCT_CATEGORY PC, MASTER_CATEGORY MC, MASTER_UNIT MU " +
                                        "WHERE MP.PRODUCT_IS_SERVICE = 0 AND MP.PRODUCT_ACTIVE = 1 AND MP.UNIT_ID = MU.UNIT_ID " +
                                        "AND MP.PRODUCT_ID = PC.PRODUCT_ID AND PC.CATEGORY_ID = MC.CATEGORY_ID " + tags;
                        DS.writeXML(sqlCommandx, globalConstants.StockXML);
                        ReportStockForm displayedForm6 = new ReportStockForm();
                        displayedForm6.ShowDialog(this);
                    break;
                case globalConstants.REPORT_STOCK_EXPIRY:
                    sqlCommandx = "SELECT MP.PRODUCT_NAME, PE.PRODUCT_AMOUNT, PE.PRODUCT_EXPIRY_DATE, MU.UNIT_NAME, MC.CATEGORY_NAME " +
                                        "FROM MASTER_PRODUCT MP, PRODUCT_CATEGORY PC, MASTER_CATEGORY MC, MASTER_UNIT MU, PRODUCT_EXPIRY PE " +
                                        "WHERE PE.PRODUCT_ID = MP.PRODUCT_ID AND MP.PRODUCT_IS_SERVICE = 0 AND MP.PRODUCT_ACTIVE = 1 AND MP.UNIT_ID = MU.UNIT_ID " +
                                        "AND MP.PRODUCT_ID = PC.PRODUCT_ID AND PC.CATEGORY_ID = MC.CATEGORY_ID " + tags;
                    DS.writeXML(sqlCommandx, globalConstants.StockExpiryXML);
                    ReportStockForm displayedForm6Expiry = new ReportStockForm(globalConstants.REPORT_STOCK_EXPIRY);
                    displayedForm6Expiry.ShowDialog(this);
                    break;
                case globalConstants.REPORT_STOCK_PECAH_BARANG:
                    sqlCommandx = "SELECT PL.PL_DATETIME AS 'TGL', MP.PRODUCT_NAME AS 'PRODUK ASAL', PL.PRODUCT_QTY AS 'QTY ASAL', MP2.PRODUCT_NAME AS 'PRODUK BARU', " +
                                            "PL.NEW_PRODUCT_QTY - PL.TOTAL_LOSS AS 'QTY BARU' " +
                                            "FROM PRODUCT_LOSS PL LEFT OUTER JOIN MASTER_PRODUCT MP ON(PL.PRODUCT_ID = MP.ID) " +
                                            "LEFT OUTER JOIN MASTER_PRODUCT MP2 ON (PL.NEW_PRODUCT_ID = MP2.ID) " +
                                            "WHERE PL.PRODUCT_ID <> 0 AND PL.NEW_PRODUCT_ID <> 0 " +
                                            "AND DATE_FORMAT(PL.PL_DATETIME, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(PL.PL_DATETIME, '%Y%m%d') <= '" + dateTo + "' " + produk;
                    DS.writeXML(sqlCommandx, globalConstants.stockPecahBarangXML);
                    ReportStockPecahBarangForm displayedForm6PecahBarang = new ReportStockPecahBarangForm();
                    displayedForm6PecahBarang.ShowDialog(this);
                    break;
            }
        }

        private void nonactivecheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.REPORT_SALES_RETURN)
            {
                LoadCustomer();
            }
            else
            {
                LoadSupplier();
            }
        }

        private void nonactivecheckbox2_CheckedChanged(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.REPORT_STOCK)
            {
                loadTags();
            } else
            {
                loadProduct();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                //CustomercomboBox.Enabled = true;
                //SupplierNameCombobox.Enabled = true;
                if (originModuleID == globalConstants.REPORT_SALES_RETURN)
                {
                    CustomercomboBox.Enabled = true;
                }
                else
                {
                    SupplierNameCombobox.Enabled = true;
                }
            }
            else
            {
                //CustomercomboBox.Enabled = true;
                //SupplierNameCombobox.Enabled = true;
                if (originModuleID == globalConstants.REPORT_SALES_RETURN)
                {
                    CustomercomboBox.Enabled = false;
                }
                else
                {
                    SupplierNameCombobox.Enabled = false;
                }
            }         
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                if (originModuleID == globalConstants.REPORT_STOCK)
                {
                    TagsComboBox.Enabled = true;
                }
                else
                {
                    ProductcomboBox.Enabled = true;
                }                
            }
            else
            {
                if (originModuleID == globalConstants.REPORT_STOCK)
                {
                    TagsComboBox.Enabled = false;
                }
                else
                {
                    ProductcomboBox.Enabled = false;
                }                
            }
        }

    }
}
