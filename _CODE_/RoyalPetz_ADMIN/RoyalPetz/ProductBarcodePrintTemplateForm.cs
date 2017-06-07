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

namespace AlphaSoft
{
    public partial class ProductBarcodePrintTemplateForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();

        public ProductBarcodePrintTemplateForm()
        {
            InitializeComponent();

            DataSet dsTempReport = new DataSet();
            try
            {
                string appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.ProductBarcodeXML;
                dsTempReport.ReadXml(@appPath);
                //prepare report for preview                
                ProductBarcodePrintTemplate rptXMLReport = new ProductBarcodePrintTemplate();
                rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);

                globalPrinterUtility gPrinter = new globalPrinterUtility();
                rptXMLReport.PrintOptions.PrinterName = gPrinter.getConfigPrinterName(2);
                rptXMLReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)gPrinter.getReportPaperSize(globalPrinterUtility.LETTER_PAPER_SIZE);
                rptXMLReport.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;

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
