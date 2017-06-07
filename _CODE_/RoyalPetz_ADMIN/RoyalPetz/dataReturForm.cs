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
using System.Drawing.Printing;

using Hotkeys;

namespace AlphaSoft
{
    public partial class dataReturForm : Form
    {
        private int originModuleID = 0;
        private globalUtilities gUtil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private CultureInfo culture = new CultureInfo("id-ID");
        private int supplierID = 0;
        private string returID = "";

        dataReturPermintaanForm returPembelianForm = null;
        dataReturPermintaanForm returMutasiForm = null;
        dataInvoiceForm returPenjualanForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private Hotkeys.GlobalHotkey ghk_ESC;
        private bool navKeyRegistered = false;

        public dataReturForm()
        {
            InitializeComponent();
        }

        public dataReturForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
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
                case Keys.Escape:
                    this.Close();
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

            ghk_ESC = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Escape, this);
            ghk_ESC.Register();

            navKeyRegistered = true;
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
            ghk_ESC.Unregister();

            navKeyRegistered = false;
        }

        public void fillInSupplierCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT SUPPLIER_ID, SUPPLIER_FULL_NAME FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1 ORDER BY SUPPLIER_FULL_NAME ASC";

            supplierCombo.Items.Clear();
            supplierHiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        supplierCombo.Items.Add(rdr.GetString("SUPPLIER_FULL_NAME"));
                        supplierHiddenCombo.Items.Add(rdr.GetString("SUPPLIER_ID"));
                    }
                }
            }
        }

        public void fillInCustomerCombo()
        {
            MySqlDataReader rdr;
            string sqlCommand;

            sqlCommand = "SELECT CUSTOMER_ID, CUSTOMER_FULL_NAME FROM MASTER_CUSTOMER WHERE CUSTOMER_ACTIVE = 1";

            supplierCombo.Items.Clear();
            supplierHiddenCombo.Items.Clear();

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        supplierCombo.Items.Add(rdr.GetString("CUSTOMER_FULL_NAME"));
                        supplierHiddenCombo.Items.Add(rdr.GetString("CUSTOMER_ID"));
                    }
                }
            }
        }

        private void loadReturPermintaanData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;
            string noReturParam = "";

            DS.mySqlConnect();

            sqlCommand = "SELECT ID, RP_ID AS 'NO RETUR', DATE_FORMAT(RP_DATE, '%d-%M-%Y')  AS 'TANGGAL RETUR', " +
                                "'HQ PUSAT' AS 'NAMA SUPPLIER', RP_TOTAL AS 'TOTAL' " +
                                "FROM RETURN_PURCHASE_HEADER " +
                                "WHERE 1=1";

            if (!showAllCheckBox.Checked)
            {
                if (noPOInvoiceTextBox.Text.Length > 0)
                {
                    noReturParam = MySqlHelper.EscapeString(noPOInvoiceTextBox.Text);
                    sqlCommand = sqlCommand + " AND RP_ID LIKE '%" + noReturParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));
                sqlCommand = sqlCommand + " AND DATE_FORMAT(RP_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(RP_DATE, '%Y%m%d')  <= '" + dateTo + "'";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataPurchaseOrder.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPurchaseOrder.DataSource = dt;

                    dataPurchaseOrder.Columns["ID"].Visible = false;

                    dataPurchaseOrder.Columns["NO RETUR"].Width = 200;
                    dataPurchaseOrder.Columns["TANGGAL RETUR"].Width = 200;
                    dataPurchaseOrder.Columns["NAMA SUPPLIER"].Width = 200;
                    dataPurchaseOrder.Columns["TOTAL"].Width = 200;

                    dataPurchaseOrder.Columns["TOTAL"].DefaultCellStyle.FormatProvider = culture;
                    dataPurchaseOrder.Columns["TOTAL"].DefaultCellStyle.Format = "C2";

                }

                rdr.Close();
            }
        }

        private void loadReturPembelianData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;
            string noReturParam = "";

            DS.mySqlConnect();

            sqlCommand = "SELECT RPH.ID, RPH.RP_ID AS 'NO RETUR', DATE_FORMAT(RPH.RP_DATE, '%d-%M-%Y')  AS 'TANGGAL RETUR', " +
                                "M.SUPPLIER_FULL_NAME AS 'NAMA SUPPLIER', RPH.RP_TOTAL AS 'TOTAL' " +
                                "FROM RETURN_PURCHASE_HEADER RPH, MASTER_SUPPLIER M " +
                                "WHERE RPH.SUPPLIER_ID = M.SUPPLIER_ID AND RPH.SUPPLIER_ID <> 0 ";

            if (!showAllCheckBox.Checked)
            {
                if (noPOInvoiceTextBox.Text.Length > 0)
                {
                    noReturParam = MySqlHelper.EscapeString(noPOInvoiceTextBox.Text);
                    sqlCommand = sqlCommand + " AND RPH.RP_ID LIKE '%" + noReturParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));
                sqlCommand = sqlCommand + " AND DATE_FORMAT(RPH.RP_DATE, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(RPH.RP_DATE, '%Y%m%d')  <= '" + dateTo + "'";

                if (supplierCombo.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + " AND RPH.SUPPLIER_ID = " + supplierID;
                }
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataPurchaseOrder.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPurchaseOrder.DataSource = dt;

                    dataPurchaseOrder.Columns["ID"].Visible = false;
                    dataPurchaseOrder.Columns["NO RETUR"].Width = 200;
                    dataPurchaseOrder.Columns["TANGGAL RETUR"].Width = 200;
                    dataPurchaseOrder.Columns["NAMA SUPPLIER"].Width = 200;
                    dataPurchaseOrder.Columns["TOTAL"].Width = 200;
                }

                rdr.Close();
            }
        }

        private void loadReturPenjualanData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand = "";
            string dateFrom, dateTo;
            string noReturParam = "";

            DS.mySqlConnect();

            sqlCommand = "SELECT RSH.ID, RSH.RS_INVOICE AS 'NO RETUR', DATE_FORMAT(RSH.RS_DATETIME, '%d-%M-%Y')  AS 'TANGGAL RETUR', " +
                                "IFNULL(M.CUSTOMER_FULL_NAME, '') AS 'NAMA CUSTOMER', RSH.RS_TOTAL AS 'TOTAL' " +
                                "FROM RETURN_SALES_HEADER RSH LEFT OUTER JOIN MASTER_CUSTOMER M ON RSH.CUSTOMER_ID = M.CUSTOMER_ID " +
                                "WHERE 1=1";

            if (!showAllCheckBox.Checked)
            {
                if (noPOInvoiceTextBox.Text.Length > 0)
                {
                    noReturParam = MySqlHelper.EscapeString(noPOInvoiceTextBox.Text);
                    sqlCommand = sqlCommand + " AND RSH.RS_INVOICE LIKE '%" + noReturParam + "%'";
                }

                dateFrom = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_1.Value));
                dateTo = String.Format(culture, "{0:yyyyMMdd}", Convert.ToDateTime(PODtPicker_2.Value));
                sqlCommand = sqlCommand + " AND DATE_FORMAT(RSH.RS_DATETIME, '%Y%m%d')  >= '" + dateFrom + "' AND DATE_FORMAT(RSH.RS_DATETIME, '%Y%m%d')  <= '" + dateTo + "'";

                if (supplierCombo.Text.Length > 0)
                {
                    sqlCommand = sqlCommand + " AND RSH.CUSTOMER_ID = " + supplierID;
                }
            }

            using (rdr = DS.getData(sqlCommand))
            {
                dataPurchaseOrder.DataSource = null;
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataPurchaseOrder.DataSource = dt;

                    dataPurchaseOrder.Columns["ID"].Visible = false;
                    dataPurchaseOrder.Columns["NO RETUR"].Width = 200;
                    dataPurchaseOrder.Columns["TANGGAL RETUR"].Width = 200;
                    dataPurchaseOrder.Columns["NAMA CUSTOMER"].Width = 200;
                    dataPurchaseOrder.Columns["TOTAL"].Width = 200;
                }

                rdr.Close();
            }
        }

        private void dataReturForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];

            PODtPicker_1.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;
            PODtPicker_2.CustomFormat = globalUtilities.CUSTOM_DATE_FORMAT;

            if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
            {
                label3.Text = "SUPPLIER";
                fillInSupplierCombo();
            }
            else if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_PUSAT)
            {
                label3.Visible = false;
                supplierCombo.Visible = false;
            }
            else if (originModuleID == globalConstants.RETUR_PENJUALAN)
            {
                label3.Text = "PELANGGAN";
                fillInCustomerCombo();
                labelPrintOut.Visible = true;
                comboPrintOut.Visible = true;
                comboPrintOut.SelectedIndex = 0;
                comboPrintOut.Text = comboPrintOut.Items[comboPrintOut.SelectedIndex].ToString();
            }

            arrButton[0] = displayButton;
            arrButton[1] = newButton;
            gUtil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gUtil.reArrangeTabOrder(this);

            noPOInvoiceTextBox.Select();
        }

        private void displayButton_Click(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
            {
                loadReturPembelianData();
            }
            else if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_PUSAT)
            {
                loadReturPermintaanData();
            }
            else if (originModuleID == globalConstants.RETUR_PENJUALAN)
            {
                loadReturPenjualanData();
            }
        }

        private void printOutReturPembelian(string noRetur)
        {
            string returNo = noRetur;
            string sqlCommandx = "";
            
            sqlCommandx = "SELECT 'RETUR PEMBELIAN' AS MODULE_TYPE, RPH.RP_ID AS 'NO_RETUR', IFNULL(MS.SUPPLIER_FULL_NAME, 'HQ PUSAT') AS 'NAME', RPH.RP_DATE AS 'RETUR_DATE', RPH.RP_TOTAL AS 'RETUR_TOTAL', MP.PRODUCT_NAME AS 'PRODUCT_NAME', RPD.PRODUCT_BASEPRICE AS 'PRICE', RPD.PRODUCT_QTY AS 'QTY', RPD.RP_DESCRIPTION AS 'DESC', RPD.RP_SUBTOTAL AS 'SUBTOTAL' " +
                                     "FROM RETURN_PURCHASE_HEADER RPH LEFT OUTER JOIN MASTER_SUPPLIER MS ON RPH.SUPPLIER_ID = MS.SUPPLIER_ID, MASTER_PRODUCT MP, RETURN_PURCHASE_DETAIL RPD " +
                                     "WHERE RPD.RP_ID = RPH.RP_ID AND RPD.PRODUCT_ID = MP.PRODUCT_ID AND RPH.RP_ID = '" + returNo + "'";

            DS.writeXML(sqlCommandx, globalConstants.returPermintaanXML);
            dataReturPermintaanPrintOutForm displayForm = new dataReturPermintaanPrintOutForm();
            displayForm.ShowDialog(this);
        }

        private void printOutReturPermintaan(string noRetur)
        {
            string returNo = noRetur;
            string sqlCommandx = "";

            sqlCommandx = "SELECT 'RETUR PERMINTAAN' AS MODULE_TYPE, RPH.RP_ID AS 'NO_RETUR', IFNULL(MS.SUPPLIER_FULL_NAME, 'HQ PUSAT') AS 'NAME', RPH.RP_DATE AS 'RETUR_DATE', RPH.RP_TOTAL AS 'RETUR_TOTAL', MP.PRODUCT_NAME AS 'PRODUCT_NAME', RPD.PRODUCT_BASEPRICE AS 'PRICE', RPD.PRODUCT_QTY AS 'QTY', RPD.RP_DESCRIPTION AS 'DESC', RPD.RP_SUBTOTAL AS 'SUBTOTAL' " +
                                     "FROM RETURN_PURCHASE_HEADER RPH LEFT OUTER JOIN MASTER_SUPPLIER MS ON RPH.SUPPLIER_ID = MS.SUPPLIER_ID, MASTER_PRODUCT MP, RETURN_PURCHASE_DETAIL RPD " +
                                     "WHERE RPD.RP_ID = RPH.RP_ID AND RPD.PRODUCT_ID = MP.PRODUCT_ID AND RPH.RP_ID = '" + returNo + "'";

            DS.writeXML(sqlCommandx, globalConstants.returPermintaanXML);
            dataReturPermintaanPrintOutForm displayForm = new dataReturPermintaanPrintOutForm();
            displayForm.ShowDialog(this);
        }

        private void printOutReturPenjualan(string noRetur)
        {
            string returNo = noRetur;
            string sqlCommandx = "";

            sqlCommandx = "SELECT 'RETUR PENJUALAN' AS MODULE_TYPE, RSH.RS_INVOICE AS 'NO_RETUR', IFNULL(MC.CUSTOMER_FULL_NAME, '') AS 'NAME', RSH.RS_DATETIME AS 'RETUR_DATE', RSH.RS_TOTAL AS 'RETUR_TOTAL', MP.PRODUCT_NAME AS 'PRODUCT_NAME', RSD.PRODUCT_SALES_PRICE AS 'PRICE', RSD.PRODUCT_RETURN_QTY AS 'QTY', RSD.RS_DESCRIPTION AS 'DESC', RSD.RS_SUBTOTAL AS 'SUBTOTAL' " +
                                     "FROM RETURN_SALES_HEADER RSH LEFT OUTER JOIN MASTER_CUSTOMER MC ON RSH.CUSTOMER_ID = MC.CUSTOMER_ID, MASTER_PRODUCT MP, RETURN_SALES_DETAIL RSD " +
                                     "WHERE RSD.RS_INVOICE = RSH.RS_INVOICE AND RSD.PRODUCT_ID = MP.PRODUCT_ID AND RSH.RS_INVOICE = '" + returNo + "'";

            DS.writeXML(sqlCommandx, globalConstants.returPermintaanXML);
            dataReturPermintaanPrintOutForm displayForm = new dataReturPermintaanPrintOutForm();
            displayForm.ShowDialog(this);
        }

        private void printOutSelectedRetur(string noRetur)
        {
            if (DialogResult.Yes == MessageBox.Show("PRINT OUT RETUR ?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            { 
                if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
                {
                    printOutReturPembelian(noRetur);
                }
                else if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_PUSAT)
                {
                    printOutReturPermintaan(noRetur);
                }
                else if (originModuleID == globalConstants.RETUR_PENJUALAN)
                {
                    if (comboPrintOut.SelectedIndex == 0)
                        printReceipt(noRetur);
                    else
                        printOutReturPenjualan(noRetur);
                }
            }
        }

        private void supplierCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            supplierID = Convert.ToInt32(supplierHiddenCombo.Items[supplierCombo.SelectedIndex].ToString());
        }

        private void dataPurchaseOrder_DoubleClick(object sender, EventArgs e)
        {
            string selectedNoRetur;

            if (dataPurchaseOrder.Rows.Count <= 0)
                return;

            int rowSelectedIndex = (dataPurchaseOrder.SelectedCells[0].RowIndex);
            DataGridViewRow selectedRow = dataPurchaseOrder.Rows[rowSelectedIndex];
            selectedNoRetur = selectedRow.Cells["NO RETUR"].Value.ToString();

            printOutSelectedRetur(selectedNoRetur);
        }

        private void dataPurchaseOrder_KeyDown(object sender, KeyEventArgs e)
        {
            string selectedNoRetur;
            if (e.KeyCode == Keys.Enter)
            {
                if (dataPurchaseOrder.Rows.Count <= 0)
                    return;

                int rowSelectedIndex = (dataPurchaseOrder.SelectedCells[0].RowIndex);
                DataGridViewRow selectedRow = dataPurchaseOrder.Rows[rowSelectedIndex];
                selectedNoRetur = selectedRow.Cells["NO RETUR"].Value.ToString();

                printOutSelectedRetur(selectedNoRetur);
            }
        }

        private void loadInfoToko(int opt, out string namatoko, out string almt, out string telepon, out string email)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            namatoko = ""; almt = ""; telepon = ""; email = "";
            //DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT IFNULL(BRANCH_ID,0) AS 'BRANCH_ID', IFNULL(HQ_IP4,'') AS 'IP', IFNULL(STORE_NAME,'') AS 'NAME', IFNULL(STORE_ADDRESS,'') AS 'ADDRESS', IFNULL(STORE_PHONE,'') AS 'PHONE', IFNULL(STORE_EMAIL,'') AS 'EMAIL' FROM SYS_CONFIG WHERE ID =  " + opt))
            {
                if (rdr.HasRows)
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN, "loadInfoToko");
                    while (rdr.Read())
                    {
                        if (!String.IsNullOrEmpty(rdr.GetString("NAME")))
                        {
                            namatoko = rdr.GetString("NAME");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("ADDRESS")))
                        {
                            almt = rdr.GetString("ADDRESS");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("PHONE")))
                        {
                            telepon = rdr.GetString("PHONE");
                        }
                        if (!String.IsNullOrEmpty(rdr.GetString("EMAIL")))
                        {
                            email = rdr.GetString("EMAIL");
                        }
                    }
                }
            }
        }

        private void loadNamaUser(int user_id, out string nama)
        {
            nama = "";
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            //DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT USER_NAME AS 'NAME' FROM MASTER_USER WHERE ID=" + user_id))
            {
                if (rdr.HasRows)
                {
                    gUtil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN, "CASHIER FORM : loadNamaUser");

                    rdr.Read();
                    nama = rdr.GetString("NAME");
                }
            }
        }

        private int calculatePageLength(string returID)
        {
            string nm, almt, tlpn, email;
            //event printing

            int startY = 5;
            int Offset = 15;
            int offset_plus = 3;
            string sqlCommand = "";
            int totalLengthPage = startY + Offset; ;

            String ucapan = "";

            //event printing

            gUtil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN, "printDocument1_PrintPage, print POS size receipt");

            int startX = 5;
            int colxwidth = 93; //31x3
            int totrowwidth = 310; //310/10=31
            int totrowheight = 20;
            string customer = "";
            string tgl = "";
            string group = "";
            double total = 0;
            string paymentDesc = "";
            double totalPayment = 0;
            string soInvoice = "";

            //HEADER

            loadInfoToko(2, out nm, out almt, out tlpn, out email);

            Offset = Offset + 12;

            Offset = Offset + 10;

            if (!email.Equals(""))
            {
                Offset = Offset + 10;
            }

            Offset = Offset + 13;
            //end of header


            Offset = Offset + 12;

            //2. CUSTOMER NAME
            Offset = Offset + 12;

            Offset = Offset + 13;

            Offset = Offset + 12;

            Offset = Offset + 15 + offset_plus;

            Offset = Offset + 15 + offset_plus;

            Offset = Offset + 12;

            Offset = Offset + 12;

            Offset = Offset + 12;

            Offset = Offset + 13;

            MySqlDataReader rdr;
            string product_desc = "";
            //sqlCommand = "SELECT DATE_FORMAT(PC.PAYMENT_DATE, '%d-%M-%Y') AS 'PAYMENT_DATE', PC.PAYMENT_NOMINAL, PC.PAYMENT_DESCRIPTION FROM PAYMENT_CREDIT PC, CREDIT C WHERE PC.PAYMENT_CONFIRMED = 1 AND PC.CREDIT_ID = C.CREDIT_ID AND C.SALES_INVOICE = '" + selectedSOInvoice + "'";
            sqlCommand = "SELECT RD.PRODUCT_ID, MP.PRODUCT_NAME, RD.PRODUCT_SALES_PRICE, RD.PRODUCT_RETURN_QTY, RD.RS_DESCRIPTION, RD.RS_SUBTOTAL " +
                                    "FROM RETURN_SALES_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RD.RS_INVOICE = '" + returID + "' AND RD.PRODUCT_ID = MP.PRODUCT_ID";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        product_desc = rdr.GetString("RS_DESCRIPTION");
                        Offset = Offset + 15;
                        if (product_desc.Length > 0)
                        {
                            Offset = Offset + 15;
                        }
                    }
                }
            }

            Offset = Offset + 13;

            Offset = Offset + 15;

            Offset = Offset + 25 + offset_plus;
            //eNd of content

            //FOOTER

            Offset = Offset + 13;

            Offset = Offset + 15;

            Offset = Offset + 15;

            Offset = Offset + 15;
            //end of footer

            totalLengthPage = totalLengthPage + Offset + 15;

            gUtil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN, "calculatePageLength, totalLengthPage [" + totalLengthPage + "]");
            return totalLengthPage;
        }

        private void printReceipt(string noRetur)
        {
            int paperLength;
            returID = noRetur;
            paperLength = calculatePageLength(noRetur);
            PaperSize psize = new PaperSize("Custom", 320, paperLength);//820);
            printDocument1.DefaultPageSettings.PaperSize = psize;
            DialogResult result;
            printPreviewDialog1.Width = 512;
            printPreviewDialog1.Height = 768;
            result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            String ucapan = "";
            string nm, almt, tlpn, email;

            //event printing

            gUtil.saveSystemDebugLog(globalConstants.MENU_RETUR_PENJUALAN, "printDocument1_PrintPage, print POS size receipt");

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 5;
            int colxwidth = 93; //31x3
            int totrowwidth = 310; //310/10=31
            int totrowheight = 20;
            int startY = 5;
            int Offset = 15;
            int offset_plus = 3;
            string sqlCommand = "";
            string customer = "";
            string tgl = "";
            string group = "";
            double total = 0;
            string soInvoice = "";

            //HEADER

            //set allignemnt
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            //set whole printing area
            System.Drawing.RectangleF rect = new System.Drawing.RectangleF(startX, startY + Offset, totrowwidth, totrowheight);
            //set right print area
            System.Drawing.RectangleF rectright = new System.Drawing.RectangleF(totrowwidth - colxwidth - startX, startY + Offset, colxwidth, totrowheight);
            //set middle print area
            System.Drawing.RectangleF rectcenter = new System.Drawing.RectangleF((startX + (totrowwidth / 2) - colxwidth - startX), startY + Offset, (totrowwidth / 2) - startX, totrowheight);

            loadInfoToko(2, out nm, out almt, out tlpn, out email);

            graphics.DrawString(nm, new Font("Courier New", 9),
                                new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            graphics.DrawString(almt,
                     new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 10;
            rect.Y = startY + Offset;
            graphics.DrawString(tlpn,
                     new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            if (!email.Equals(""))
            {
                Offset = Offset + 10;
                rect.Y = startY + Offset;
                graphics.DrawString(email,
                         new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            }

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            String underLine = "-------------------------------------";  //37 character
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);
            //end of header

            //start of content
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();
            //load customer id
            sqlCommand = "SELECT RS.RS_INVOICE, IFNULL(RS.SALES_INVOICE, '') AS 'INVOICE', C.CUSTOMER_FULL_NAME AS 'CUSTOMER',DATE_FORMAT(RS.RS_DATETIME, '%d-%M-%Y') AS 'DATE',RS.RS_TOTAL AS 'TOTAL', IF(C.CUSTOMER_GROUP=1,'RETAIL',IF(C.CUSTOMER_GROUP=2,'GROSIR','PARTAI')) AS 'GROUP' FROM RETURN_SALES_HEADER RS,MASTER_CUSTOMER C WHERE RS.CUSTOMER_ID = C.CUSTOMER_ID AND RS.RS_INVOICE = '" + returID + "'" +
                " UNION " +
                "SELECT RS.RS_INVOICE, IFNULL(RS.SALES_INVOICE, '') AS 'INVOICE', 'P-UMUM' AS 'CUSTOMER', DATE_FORMAT(RS.RS_DATETIME, '%d-%M-%Y') AS 'DATE', RS.RS_TOTAL AS 'TOTAL', 'RETAIL' AS 'GROUP' FROM RETURN_SALES_HEADER RS WHERE RS.CUSTOMER_ID = 0 AND RS.RS_INVOICE = '" + returID + "'" +
                "ORDER BY DATE ASC";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    customer = rdr.GetString("CUSTOMER");
                    tgl = rdr.GetString("DATE");
                    total = rdr.GetDouble("TOTAL");
                    group = rdr.GetString("GROUP");
                    soInvoice = rdr.GetString("INVOICE");
                }
            }
            DS.mySqlClose();

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            //SET TO LEFT MARGIN
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "RETUR PENJUALAN   ";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            //2. CUSTOMER NAME
            Offset = Offset + 12;
            rect.Y = startY + Offset;
            ucapan = "PELANGGAN : " + customer + " [" + group + "]";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            rect.Width = totrowwidth;
            ucapan = "BUKTI RETUR     ";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15 + offset_plus;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "NO. RETUR " + returID;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15 + offset_plus;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "NO. INVOICE " + soInvoice;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            ucapan = "TOTAL    : " + total.ToString("C2", culture);
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            ucapan = "TANGGAL  : " + tgl;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 12;
            rect.Y = startY + Offset;
            string nama = "";
            loadNamaUser(gUtil.getUserID(), out nama);
            ucapan = "OPERATOR : " + nama;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            // JUMLAH TOTAL INVOICE
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;

            // DISPLAY DETAIL FOR RETUR
            string product_id = "";
            string product_name = "";
            double product_qty = 0;
            double product_price = 0;
            string product_desc = "";
            double total_qty = 0;

            //sqlCommand = "SELECT DATE_FORMAT(PC.PAYMENT_DATE, '%d-%M-%Y') AS 'PAYMENT_DATE', PC.PAYMENT_NOMINAL, PC.PAYMENT_DESCRIPTION FROM PAYMENT_CREDIT PC, CREDIT C WHERE PC.PAYMENT_CONFIRMED = 1 AND PC.CREDIT_ID = C.CREDIT_ID AND C.SALES_INVOICE = '" + selectedSOInvoice + "'";
            sqlCommand = "SELECT RD.PRODUCT_ID, MP.PRODUCT_NAME, RD.PRODUCT_SALES_PRICE, RD.PRODUCT_RETURN_QTY, RD.RS_DESCRIPTION, RD.RS_SUBTOTAL " +
                                    "FROM RETURN_SALES_DETAIL RD, MASTER_PRODUCT MP " +
                                    "WHERE RD.RS_INVOICE = '" + returID + "' AND RD.PRODUCT_ID = MP.PRODUCT_ID";
            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        product_id = rdr.GetString("PRODUCT_ID");
                        product_name = rdr.GetString("PRODUCT_NAME");
                        product_qty = rdr.GetDouble("PRODUCT_RETURN_QTY");
                        product_price = rdr.GetDouble("PRODUCT_SALES_PRICE");
                        product_desc = rdr.GetString("RS_DESCRIPTION");
                        Offset = Offset + 15;
                        rect.Y = startY + Offset;
                        rect.X = startX + 15;
                        rect.Width = 280;
                        sf.LineAlignment = StringAlignment.Near;
                        sf.Alignment = StringAlignment.Near;
                        ucapan = product_qty + " X [" + product_id + "] " + product_name;
                        if (ucapan.Length > 30)
                        {
                            ucapan = ucapan.Substring(0, 30); //maximum 30 character
                        }
                        //
                        graphics.DrawString(ucapan, new Font("Courier New", 7),
                                 new SolidBrush(Color.Black), rect, sf);

                        rectright.Y = Offset - startY;
                        sf.LineAlignment = StringAlignment.Far;
                        sf.Alignment = StringAlignment.Far;
                        ucapan = "@ " + product_price.ToString("C2", culture);//" Rp." + product_price;
                        graphics.DrawString(ucapan, new Font("Courier New", 7),
                                 new SolidBrush(Color.Black), rectright, sf);

                        if (product_desc.Length > 0)
                        {
                            Offset = Offset + 15;
                            rect.Y = startY + Offset;
                            rect.X = startX + 15;
                            rect.Width = 280;
                            sf.LineAlignment = StringAlignment.Near;
                            sf.Alignment = StringAlignment.Near;
                            ucapan = product_desc;
                            if (ucapan.Length > 30)
                            {
                                ucapan = ucapan.Substring(0, 30); //maximum 30 character
                            }
                            //
                            graphics.DrawString(ucapan, new Font("Courier New", 7),
                                     new SolidBrush(Color.Black), rect, sf);
                        }
                    }
                }
            }


            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 260;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "               JUMLAH  :";
            rectcenter.Y = rect.Y;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rectcenter, sf);
            sf.LineAlignment = StringAlignment.Far;
            sf.Alignment = StringAlignment.Far;
            ucapan = total.ToString("C2", culture);
            rectright.Y = Offset - startY + 1;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rectright, sf);

            total_qty = Convert.ToDouble(DS.getDataSingleValue("SELECT IFNULL(SUM(PRODUCT_RETURN_QTY), 0) FROM RETURN_SALES_DETAIL RD, MASTER_PRODUCT MP WHERE RD.PRODUCT_ID = MP.PRODUCT_ID AND RD.RS_INVOICE = '" + returID + "'"));

            Offset = Offset + 25 + offset_plus;
            rect.Y = startY + Offset;
            rect.X = startX + 15;
            rect.Width = 280;
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;
            ucapan = "TOTAL BARANG : " + total_qty;
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            //eNd of content

            //FOOTER

            Offset = Offset + 13;
            rect.Y = startY + Offset;
            rect.X = startX;
            rect.Width = totrowwidth;
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            graphics.DrawString(underLine, new Font("Courier New", 9),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "TERIMA KASIH ATAS KUNJUNGAN ANDA";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "MAAF BARANG YANG SUDAH DIBELI";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);

            Offset = Offset + 15;
            rect.Y = startY + Offset;
            ucapan = "TIDAK DAPAT DITUKAR/ DIKEMBALIKKAN";
            graphics.DrawString(ucapan, new Font("Courier New", 7),
                     new SolidBrush(Color.Black), rect, sf);
            //end of footer
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER)
            {
                if (null == returPembelianForm || returPembelianForm.IsDisposed)
                        returPembelianForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_SUPPLIER);

                returPembelianForm.Show();
                returPembelianForm.WindowState = FormWindowState.Normal;
            }
            else if (originModuleID == globalConstants.RETUR_PEMBELIAN_KE_PUSAT)
            {
                if (null == returMutasiForm || returMutasiForm.IsDisposed)
                        returMutasiForm = new dataReturPermintaanForm(globalConstants.RETUR_PEMBELIAN_KE_PUSAT);

                returMutasiForm.Show();
                returMutasiForm.WindowState = FormWindowState.Normal;
            }
            else if (originModuleID == globalConstants.RETUR_PENJUALAN)
            {
                if (null == returPenjualanForm || returPenjualanForm.IsDisposed)
                        returPenjualanForm = new dataInvoiceForm(globalConstants.RETUR_PENJUALAN);

                returPenjualanForm.Show();
                returPenjualanForm.WindowState = FormWindowState.Normal;
            }
        }

        private void genericControl_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void genericControl_Leave(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void dataReturForm_Activated(object sender, EventArgs e)
        {
            registerGlobalHotkey();
        }

        private void dataReturForm_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataPurchaseOrder_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataPurchaseOrder_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }
    }
}
