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

namespace RoyalPetz_ADMIN
{
    public partial class ReportStockForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private int originModuleID = 0;

        public ReportStockForm()
        {
            InitializeComponent();
        }

        public ReportStockForm(int moduleID)
        {
            InitializeComponent();
            originModuleID = moduleID;
        }

        private void ReportStockForm_Load(object sender, EventArgs e)
        {
            //on load
            DataSet dsTempReport = new DataSet();
            try
            {
                string appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.StockXML;
                dsTempReport.ReadXml(@appPath);
                CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2;

                //prepare report for preview
                if (originModuleID == globalConstants.REPORT_STOCK_EXPIRY)
                { 
                    ReportStockExpiry rptXMLReportExpiry = new ReportStockExpiry();
                    txtReportHeader1 = rptXMLReportExpiry.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                    txtReportHeader2 = rptXMLReportExpiry.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                    rptXMLReportExpiry.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);
                    crystalReportViewer1.ReportSource = rptXMLReportExpiry;
                }
                else
                { 
                    ReportStock rptXMLReport = new ReportStock();
                    txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                    txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                    rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);
                    crystalReportViewer1.ReportSource = rptXMLReport;
                }

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

                //crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
