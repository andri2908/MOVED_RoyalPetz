using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace AlphaSoft
{
    public partial class ReportProductForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private int originModuleID = 0;
        private Data_Access DS = new Data_Access();

        public ReportProductForm()
        {
            InitializeComponent();
        }

        public ReportProductForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void createAgingStockXML()
        {
            string sqlCommandx;

            sqlCommandx = "SELECT MP.PRODUCT_NAME, PE.PRODUCT_EXPIRY_DATE, PE.PRODUCT_AMOUNT FROM " +
                                     "MASTER_PRODUCT MP, PRODUCT_EXPIRY PE " +
                                     "WHERE PE.PRODUCT_ID = MP.PRODUCT_ID AND PE.PRODUCT_AMOUNT > 0 ORDER BY PE.PRODUCT_EXPIRY_DATE ASC";
            DS.writeXML(sqlCommandx, globalConstants.StockAgingXML);
        }

        private void ReportProductForm_Load(object sender, EventArgs e)
        {
            DataSet dsTempReport = new DataSet();
            string appPath;
            if (originModuleID == globalConstants.REPORT_STOCK_AGING)
            {
                createAgingStockXML();
                try
                {
                    appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.StockAgingXML;
                    dsTempReport.ReadXml(@appPath);

                    //prepare report for preview
                    ReportProductAging rptXMLReport = new ReportProductAging();
                    CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2;
                    txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                    txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                    //baca database untuk nama toko
                    String nama, alamat, telepon, email;
                    if (!gutil.loadinfotoko(2, out nama, out alamat, out telepon, out email))
                    {
                        //reset default optsi = 1
                        if (!gutil.loadinfotoko(1, out nama, out alamat, out telepon, out email))
                        {
                            nama = "TOKO DEFAULT";
                            alamat = "ALAMAT DEFAULT";
                            telepon = "0271-XXXXXXX";
                            email = "A@B.COM";
                        }
                    }
                    txtReportHeader1.Text = nama;
                    txtReportHeader2.Text = alamat + Environment.NewLine + telepon + Environment.NewLine + email;
                    //rptXMLReport.SetDataSource(dsTempReport);
                    rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);
                    crystalReportViewer1.ReportSource = rptXMLReport;
                    crystalReportViewer1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.ProductXML;
                    dsTempReport.ReadXml(@appPath);

                    //prepare report for preview
                    ReportProduct rptXMLReport = new ReportProduct();
                    CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2;
                    txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                    txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                    //baca database untuk nama toko
                    String nama, alamat, telepon, email;
                    if (!gutil.loadinfotoko(2, out nama, out alamat, out telepon, out email))
                    {
                        //reset default optsi = 1
                        if (!gutil.loadinfotoko(1, out nama, out alamat, out telepon, out email))
                        {
                            nama = "TOKO DEFAULT";
                            alamat = "ALAMAT DEFAULT";
                            telepon = "0271-XXXXXXX";
                            email = "A@B.COM";
                        }
                    }
                    txtReportHeader1.Text = nama;
                    txtReportHeader2.Text = alamat + Environment.NewLine + telepon + Environment.NewLine + email;
                    //rptXMLReport.SetDataSource(dsTempReport);
                    rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);
                    crystalReportViewer1.ReportSource = rptXMLReport;
                    crystalReportViewer1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
