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
    public partial class ReportPurchaseSearchForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private CultureInfo culture = new CultureInfo("id-ID");
        private Data_Access DS = new Data_Access();
        private int originModuleID = 0;

        public ReportPurchaseSearchForm()
        {
            InitializeComponent();
        }

        public ReportPurchaseSearchForm(int moduleID)
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
            if (nonactivecheckbox.Checked)
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
                    nonactivecheckbox.Visible = true;
                    ErrorLabel.Visible = false;
                    dt.Load(rdr);                    
                    SupplierNameCombobox.DataSource = dt;
                    SupplierNameCombobox.ValueMember = "ID";
                    SupplierNameCombobox.DisplayMember = "NAME";
                    SupplierNameCombobox.SelectedIndex = 0;
                }
                else
                {
                    SupplierNameCombobox.Visible = false;
                    nonactivecheckbox.Visible = false;
                    ErrorLabel.Visible = true;
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
            if (nonactivecheckbox.Checked)
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
                    nonactivecheckbox.Visible = true;
                    ErrorLabel.Visible = false;
                    dt.Load(rdr);
                    ProductcomboBox.DataSource = dt;
                    ProductcomboBox.ValueMember = "ID";
                    ProductcomboBox.DisplayMember = "NAME";
                    ProductcomboBox.SelectedIndex = 0;
                } else
                {
                    ProductcomboBox.Visible = false;
                    nonactivecheckbox.Visible = false;
                    ErrorLabel.Visible = true;
                }
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
            string produk = "";
            if (ErrorLabel.Visible == true)
            {
                supplier = "AND PH.SUPPLIER_ID = '" + SupplierNameCombobox.SelectedValue + "' ";
                produk = "AND PD.PRODUCT_ID = '" + ProductcomboBox.SelectedValue + "' ";
            }
            switch (originModuleID)
            {
                case globalConstants.REPORT_PURCHASE_SUMMARY:
                    sqlCommandx = "SELECT PH.PURCHASE_DATETIME AS 'TGL', PH.PURCHASE_DATE_RECEIVED AS 'TERIMA', PURCHASE_INVOICE AS 'INVOICE', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', PH.PURCHASE_TOTAL AS 'TOTAL', IF(PH.PURCHASE_TERM_OF_PAYMENT>0,'KREDIT','TUNAI') AS 'TOP', PH.PURCHASE_TERM_OF_PAYMENT_DURATION AS 'HARI', IF(PH.PURCHASE_PAID>0,'LUNAS','BELUM LUNAS') AS 'STATUS' " +
                                        "FROM PURCHASE_HEADER PH, MASTER_SUPPLIER MS " +
                                        "WHERE PH.SUPPLIER_ID = MS.SUPPLIER_ID " + supplier + "AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  <= '" + dateTo + "' " +
                                        "ORDER BY TGL";
                    DS.writeXML(sqlCommandx, globalConstants.PurchaseSummaryXML);
                    ReportPurchaseSummaryForm displayedForm1 = new ReportPurchaseSummaryForm();
                    displayedForm1.ShowDialog(this);
                    break;
                case globalConstants.REPORT_PURCHASE_DETAILED:
                    sqlCommandx = "SELECT PH.PURCHASE_DATETIME AS 'TGL', PH.PURCHASE_DATE_RECEIVED AS 'TERIMA', PH.PURCHASE_INVOICE AS 'INVOICE', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', MP.PRODUCT_NAME AS 'PRODUK', PD.PRODUCT_PRICE AS 'HARGA', PD.PRODUCT_QTY AS 'QTY', PD.PURCHASE_SUBTOTAL AS 'SUBTOTAL' " +
                                        "FROM PURCHASE_HEADER PH, PURCHASE_DETAIL PD, MASTER_SUPPLIER MS, MASTER_PRODUCT MP " +
                                        "WHERE PD.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PH.SUPPLIER_ID = MS.SUPPLIER_ID " + supplier + "AND PD.PRODUCT_ID = MP.PRODUCT_ID AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  <= '" + dateTo + "' " +
                                        "ORDER BY TGL,INVOICE,PRODUK";
                    DS.writeXML(sqlCommandx, globalConstants.PurchaseDetailedXML);
                    ReportPurchaseDetailedForm displayedForm2 = new ReportPurchaseDetailedForm();
                    displayedForm2.ShowDialog(this);
                    break;
                case globalConstants.REPORT_PURCHASE_ByPRODUCT:
                    sqlCommandx = "SELECT DATE(PH.PURCHASE_DATETIME) AS 'TGL', PH.PURCHASE_DATE_RECEIVED AS 'TERIMA', PH.PURCHASE_INVOICE AS 'INVOICE', MS.SUPPLIER_FULL_NAME AS 'SUPPLIER', MP.PRODUCT_NAME AS 'PRODUK', PD.PRODUCT_PRICE AS 'HARGA', PD.PRODUCT_QTY AS 'QTY', PD.PURCHASE_SUBTOTAL AS 'SUBTOTAL' " +
                                        "FROM PURCHASE_HEADER PH, PURCHASE_DETAIL PD, MASTER_SUPPLIER MS, MASTER_PRODUCT MP " +
                                        "WHERE PD.PURCHASE_INVOICE = PH.PURCHASE_INVOICE AND PH.SUPPLIER_ID = MS.SUPPLIER_ID AND PD.PRODUCT_ID = MP.PRODUCT_ID " + produk + "AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(PH.PURCHASE_DATETIME, '%Y%m%d')  <= '" + dateTo + "' " +
                                        "ORDER BY TGL";
                    DS.writeXML(sqlCommandx, globalConstants.PurchasebyProductXML);
                    ReportPurchasebyProductForm displayedForm3 = new ReportPurchasebyProductForm();
                    displayedForm3.ShowDialog(this);
                    break;
            }
            }

        private void ReportPurchaseSearchForm_Load(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;

            datefromPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            datetoPicker.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            if (originModuleID != globalConstants.REPORT_PURCHASE_ByPRODUCT)
            {
                LabelOptions.Text = "Supplier";
                SupplierNameCombobox.Visible = true;
                ProductcomboBox.Visible = false;
                ErrorLabel.Visible = false;
                LoadSupplier();
            }
            else
            {
                LabelOptions.Text = "Produk";
                SupplierNameCombobox.Visible = false;
                ProductcomboBox.Visible = true;
                loadProduct();
            }
            gutil.reArrangeTabOrder(this);
        }
    }
}
