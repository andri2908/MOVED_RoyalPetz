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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace AlphaSoft
{
    public partial class ReportTopSalesGlobalForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private int originmoduleID = 0;
        private string dateTo, dateFrom;
        public ReportTopSalesGlobalForm()
        {
            InitializeComponent();
        }

        public ReportTopSalesGlobalForm(int moduleID)
        {
            InitializeComponent();
            originmoduleID = moduleID;
            dateTo = ""; dateFrom = "";
        }

        public void setDateReport(string dateToF, string dateFromF)
        {
            dateTo = dateToF;
            dateFrom = dateFromF;
        }

        private void ReportTopSalesGlobalForm_Load(object sender, EventArgs e)
        {
            DataSet dsTempReport = new DataSet();
            if (originmoduleID == globalConstants.REPORT_TOPSALES_GLOBAL)
            {
                try
                {
                    string appPath = "";
                    appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.TopSalesGlobalXML;
                    dsTempReport.ReadXml(@appPath);
                    //prepare report for preview
                    ReportTopSalesGlobal rptXMLReport = new ReportTopSalesGlobal();
                    CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2, txtReportHeader3;
                    txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                    txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                    txtReportHeader3 = rptXMLReport.ReportDefinition.ReportObjects["TitleLabel"] as TextObject;
                    //baca database untuk nama toko
                    String nama, alamat, telepon, email;
                    if (!gutil.loadinfotoko(2, out nama, out alamat, out telepon, out email))
                    {
                        //reset default opsi = 1
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
                    txtReportHeader3.Text = "GLOBAL";
                    rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);
                    crystalReportViewer1.ReportSource = rptXMLReport;
                    crystalReportViewer1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else
            {
                try
                {
                    string appPath = "";
                    appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.TopSalesbyDateXML;
                    dsTempReport.ReadXml(@appPath);
                    //prepare report for preview
                    ReportTopSalesGlobal rptXMLReport = new ReportTopSalesGlobal();
                    CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2, txtReportHeader3;
                    txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                    txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                    txtReportHeader3 = rptXMLReport.ReportDefinition.ReportObjects["TitleLabel"] as TextObject;
                    //baca database untuk nama toko
                    String nama, alamat, telepon, email;
                    if (!gutil.loadinfotoko(2, out nama, out alamat, out telepon, out email))
                    {
                        //reset default opsi = 1
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
                    dateTo = dateTo.Substring(0, 4) + "/" + dateTo.Substring(4, 2) + "/" + dateTo.Substring(6, 2);
                    dateFrom = dateFrom.Substring(0, 4) + "/" + dateFrom.Substring(4, 2) + "/" + dateFrom.Substring(6, 2);
                    txtReportHeader3.Text = "DARI TANGGAL " + dateFrom + " SAMPAI TANGGAL " + dateTo;
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
