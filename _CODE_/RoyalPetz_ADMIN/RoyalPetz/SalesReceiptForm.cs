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
using CrystalDecisions.ReportAppServer;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AlphaSoft
{
    public partial class SalesReceiptForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        private globalPrinterUtility gPrinter = new globalPrinterUtility();

        public SalesReceiptForm()
        {
            InitializeComponent();
        }

        private void loadNamaUser(int user_id, out string nama)
        {
            nama = "";
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            DS.mySqlConnect();
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT USER_NAME AS 'NAME' FROM MASTER_USER WHERE ID=" + user_id))
            {
                if (rdr.HasRows)
                {
                    rdr.Read();
                    nama = rdr.GetString("NAME");
                }
            }
        }

        private void testPaper()
        {
            //⁠⁠⁠System.Drawing.Printing.PrintDocument pDoc = new System.Drawing.Printing.PrintDocument();
            //CrystalDecisions.ReportAppServer.Controllers.PrintReportOptions rasPROpts = new CrystalDecisions.ReportAppServer.Controllers.PrintReportOptions();
            //CrystalDecisions.ReportAppServer.ReportDefModel.PrintOptions newOpts = new CrystalDecisions.ReportAppServer.ReportDefModel.PrintOptions();

            //newOpts.DissociatePageSizeAndPrinterPaperSize = false;

            //if (rdoCurrent.Checked)
            //{
            //    newOpts.PrinterName = cboCurrentPrinters.SelectedItem.ToString();

            //    newOpts.PaperSize = (CrPaperSizeEnum)cboCurrentPaperSizes.SelectedIndex;
            //    newOpts.PaperSource = (CrPaperSourceEnum)cboCurrentPaperTrays.SelectedIndex;
            //}
            //else
            //{
            //    pDoc.PrinterSettings.PrinterName = cboDefaultPrinters.Text;

            //    newOpts.PrinterName = cboDefaultPrinters.Text;
            //    newOpts.PaperSize = (CrPaperSizeEnum)cboDefaultPaperTrays.SelectedIndex;
            //    newOpts.PaperSource = (CrPaperSourceEnum)cboDefaultPaperTrays.SelectedIndex;
            //}

            //rptClientDoc.PrintOutputController.ModifyPrintOptions(newOpts);
            int i = 0;
            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            int rawKind = 0;
            for (i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "Half Kuarto")
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    // break;
                    // }
                    //}
                    //rawKind = GetPaperSizeID();
                    SalesReceipt1.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                    SalesReceipt1.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                    SalesReceipt1.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                    //crystalReportViewer1.ReportSource = SalesReceipt1;
                }
            }
        }
    

        private void SalesReceiptForm_Load(object sender, EventArgs e)
        {
            /*
            if (gutil.getPaper() == 2) // kuarto
            {
                SalesReceipt1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;                
            }
            */
            DataSet dsTempReport = new DataSet();
            try
            {
                string appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.SalesReceiptXML;
                dsTempReport.ReadXml(@appPath);

                //prepare report for preview
                SalesReceipt rptXMLReport = new SalesReceipt();
                
                CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2, txtReportHeader3, txtReportHeader4;
                txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                txtReportHeader3 = rptXMLReport.ReportDefinition.ReportObjects["UserLabel"] as TextObject;
                txtReportHeader4 = rptXMLReport.ReportDefinition.ReportObjects["BranchLabel"] as TextObject;
                //baca database untuk nama toko
                String nama, alamat, telepon, email, namauser;
                loadNamaUser(gutil.getUserID(), out namauser);
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
                txtReportHeader3.Text = namauser;
                string namacabang = "";
                int branch_id = gutil.loadbranchID(2, out namacabang);
                txtReportHeader4.Text = namacabang;
                rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);


                //System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
                //rptXMLReport.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                rptXMLReport.PrintOptions.PrinterName = gPrinter.getConfigPrinterName(2);
                rptXMLReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)gPrinter.getReportPaperSize(globalPrinterUtility.HALF_KUARTO_PAPER_SIZE);
                rptXMLReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
                
                //int i = 0;
                //int rawKind = 0;
                //for (i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
                //{
                //    if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "Half Kuarto")
                //    {
                //        rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                //        // break;
                //        // }
                //        //}
                //        //rawKind = GetPaperSizeID();
                //        
                //        
                //                                
                //    }
                //}

                crystalReportViewer1.ReportSource = rptXMLReport;
                crystalReportViewer1.Refresh();
                //crystalReportViewer1.PrintReport();

                rptXMLReport.PrintToPrinter(1, false, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalesReceiptForm_Activated(object sender, EventArgs e)
        {            
            //SalesReceipt1.PrintToPrinter(1, true, 0, 0);
            this.Close();
        }
    }
}
