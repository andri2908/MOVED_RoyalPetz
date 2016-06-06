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

namespace RoyalPetz_ADMIN
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
                SQLcommand = "SELECT SUPPLIER_ID AS 'ID', SUPPLIER_FULL_NAME AS 'NAME' FROM MASTER_SUPPLIER";
            }
            else
            {
                SQLcommand = "SELECT SUPPLIER_ID AS 'ID', SUPPLIER_FULL_NAME AS 'NAME' FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1";
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
            CustomercomboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox1.Checked)
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER";
            }
            else
            {
                SQLcommand = "SELECT CUSTOMER_ID AS 'ID', CUSTOMER_FULL_NAME AS 'NAME' FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    CustomercomboBox.Visible = true;
                    nonactivecheckbox1.Visible = true;
                    ErrorLabel1.Visible = false;
                    dt.Load(rdr);
                    CustomercomboBox.DataSource = dt;
                    CustomercomboBox.ValueMember = "ID";
                    CustomercomboBox.DisplayMember = "NAME";
                    CustomercomboBox.SelectedIndex = 0;
                }
                else
                {
                    CustomercomboBox.Visible = false;
                    nonactivecheckbox1.Visible = false;
                    ErrorLabel1.Visible = true;
                }
            }
        }
        private void loadProduct()
        {
            ProductcomboBox.DataSource = null;
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            string SQLcommand = "";
            if (nonactivecheckbox2.Checked)
            {
                SQLcommand = "SELECT PRODUCT_ID AS 'ID', PRODUCT_NAME AS 'NAME' FROM MASTER_PRODUCT";
            }
            else
            {
                SQLcommand = "SELECT PRODUCT_ID AS 'ID', PRODUCT_NAME AS 'NAME' FROM MASTER_PRODUCT WHERE PRODUCT_ACTIVE = 1";
            }

            using (rdr = DS.getData(SQLcommand))
            {
                if (rdr.HasRows)
                {
                    SupplierNameCombobox.Visible = true;
                    nonactivecheckbox1.Visible = true;
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
                    nonactivecheckbox1.Visible = false;
                    ErrorLabel2.Visible = true;
                }
            }
        }
        private void ReportStockInOutSearchForm_Load(object sender, EventArgs e)
        {
            ErrorLabel1.Visible = false;
            ErrorLabel2.Visible = false;
            gutil.reArrangeTabOrder(this);

            LabelOptions1.Text = "Supplier";
            SupplierNameCombobox.Visible = true;
            //LabelOptions2.Text = "Produk";

            switch (originModuleID)
            {
                case globalConstants.REPORT_PURCHASE_RETURN:
                    checkBox1.Enabled = true;
                    SupplierNameCombobox.Enabled = true;
                    nonactivecheckbox1.Enabled = true;
                    checkBox2.Enabled = true;
                    ProductcomboBox.Enabled = true;
                    nonactivecheckbox2.Enabled = true;
                    LoadSupplier();
                    loadProduct();
                    break;
                case globalConstants.REPORT_SALES_RETURN:
                    LabelOptions1.Text = "Pelanggan";
                    checkBox1.Enabled = true;
                    SupplierNameCombobox.Visible = false;
                    CustomercomboBox.Visible = true;
                    nonactivecheckbox1.Enabled = true;
                    checkBox2.Enabled = true;
                    ProductcomboBox.Enabled = true;
                    nonactivecheckbox2.Enabled = true;
                    LoadCustomer();
                    loadProduct();
                    break;
                case globalConstants.REPORT_REQUEST_RETURN:
                    checkBox1.Enabled = false;
                    SupplierNameCombobox.Enabled = false;
                    nonactivecheckbox1.Enabled = false;
                    checkBox2.Enabled = true;
                    ProductcomboBox.Enabled = true;
                    nonactivecheckbox2.Enabled = true;
                    loadProduct();
                    break;
                case globalConstants.REPORT_PRODUCT_MUTATION:
                    checkBox1.Enabled = false;
                    SupplierNameCombobox.Enabled = false;
                    nonactivecheckbox1.Enabled = false;
                    checkBox2.Enabled = true;
                    ProductcomboBox.Enabled = true;
                    nonactivecheckbox2.Enabled = true;
                    loadProduct();
                    break;
                case globalConstants.REPORT_STOCK_DEVIATION:
                    checkBox1.Enabled = false;
                    SupplierNameCombobox.Enabled = false;
                    nonactivecheckbox1.Enabled = false;
                    checkBox2.Enabled = true;
                    ProductcomboBox.Enabled = true;
                    nonactivecheckbox2.Enabled = true;
                    loadProduct();
                    break;
            }
         
        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            string dateFrom, dateTo;
            int cust_id = 0;
            string prod_id = "";
            bool result;
            dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datefromPicker.Value));
            dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(datetoPicker.Value));
            DS.mySqlConnect();
            string sqlCommandx = "";
            string supplier = "";
            string customer = "";
            string produk = "";
            if (ErrorLabel1.Visible == false && checkBox1.Checked == true)
            {
                switch (originModuleID)
                {
                    case globalConstants.REPORT_PURCHASE_RETURN:
                        supplier = "AND RH.SUPPLIER_ID";
                        supplier = " = " + SupplierNameCombobox.SelectedValue;
                        break;
                    case globalConstants.REPORT_SALES_RETURN:
                        customer = "AND RH.CUSTOMER_ID";
                        customer = " = " + CustomercomboBox.SelectedValue;
                        break;
                }
            }
            if (ErrorLabel2.Visible == false && checkBox2.Checked == true)
            {
                switch (originModuleID)
                {
                    case globalConstants.REPORT_PURCHASE_RETURN:
                        produk = "AND RD.PRODUCT_ID";
                        break;
                    case globalConstants.REPORT_SALES_RETURN:
                        produk = "AND RD.PRODUCT_ID";
                        break;
                    case globalConstants.REPORT_REQUEST_RETURN:
                        produk = "AND RD.PRODUCT_ID";
                        break;
                    case globalConstants.REPORT_PRODUCT_MUTATION:
                        produk = "AND MD.PRODUCT_ID";
                        break;
                    case globalConstants.REPORT_STOCK_DEVIATION:
                        produk = "AND PA.PRODUCT_ID";
                        break;
                }
                produk = produk + " = '" + ProductcomboBox.SelectedValue + "' ";
            }
            switch (originModuleID)
            {
                case globalConstants.REPORT_PURCHASE_RETURN:
                    sqlCommandx = "SELECT RH.RP_ID AS 'ID', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', RH.RP_DATE AS 'TANGGAL', RH.RP_TOTAL AS 'TOTAL', IF(RH.RP_PROCESSED=1,'SUDAH DIPROSES','BELUM DIPROSES') AS 'STATUS', " +
                                    "MP.PRODUCT_NAME AS 'PRODUK', RD.PRODUCT_BASEPRICE AS 'HARGA', RD.PRODUCT_QTY AS 'QTY', RD.RP_DESCRIPTION AS 'DESKRIPSI', RD.RP_SUBTOTAL AS 'SUBTOTAL' " +
                                    "FROM RETURN_PURCHASE_HEADER RH, MASTER_SUPPLIER MS, RETURN_PURCHASE_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RH.SUPPLIER_ID = MS.SUPPLIER_ID AND RH.RP_ID = RD.RP_ID AND RD.PRODUCT_ID = MP.PRODUCT_ID " + produk + supplier + " " +
                                    "AND DATE_FORMAT(RH.RP_DATE, '%Y%m%d') >= '" + dateFrom + "' AND DATE_FORMAT(RH.RP_DATE, '%Y%m%d') <= '" + dateTo + "' " +
                                    "GROUP BY RD.ID";
                    DS.writeXML(sqlCommandx, globalConstants.PurchaseReturnXML);
                    ReportPurchaseReturnForm displayedForm1 = new ReportPurchaseReturnForm();
                    displayedForm1.ShowDialog(this);
                    break;
                case globalConstants.REPORT_SALES_RETURN:
                    sqlCommandx = "SELECT RH.RS_INVOICE AS 'INVOICE', RH.SALES_INVOICE AS 'NOTAJUAL', MC.CUSTOMER_FULL_NAME 'CUSTOMER', RH.RS_DATETIME AS 'TANGGAL', " +
                                    "RH.RS_TOTAL AS 'TOTAL', MP.PRODUCT_NAME AS 'PRODUK', RD.PRODUCT_SALES_PRICE AS 'HARGAJUAL', RD.PRODUCT_SALES_QTY AS 'JMLJUAL', " +
                                    "RD.PRODUCT_RETURN_QTY AS 'JMLRETUR', RD.RS_DESCRIPTION AS 'DESKRIPSI', RD.RS_SUBTOTAL AS 'SUBTOTAL' " +
                                    "FROM RETURN_SALES_HEADER RH, MASTER_CUSTOMER MC, RETURN_SALES_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RH.CUSTOMER_ID = MC.CUSTOMER_ID AND RH.RS_INVOICE = RD.RS_INVOICE AND RD.PRODUCT_ID = MP.PRODUCT_ID " + produk + customer + " " +
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
            }
        }

        private void nonactivecheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            LoadSupplier();
        }

        private void nonactivecheckbox2_CheckedChanged(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                SupplierNameCombobox.Enabled = true;
            }
            else
            {
                SupplierNameCombobox.Enabled = false;
            }         
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                ProductcomboBox.Enabled = true;
            }
            else
            {
                ProductcomboBox.Enabled = false;
            }
        }

    }
}
