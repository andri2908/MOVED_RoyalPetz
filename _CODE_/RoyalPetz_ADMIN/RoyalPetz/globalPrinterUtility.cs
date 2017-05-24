using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace AlphaSoft
{
    class globalPrinterUtility
    {
        public const string HALF_KUARTO_PAPER_SIZE = "HALF_KUARTO";
        public const string LETTER_PAPER_SIZE = "Letter";

        public PrinterSettings ps = new PrinterSettings();
        private PrintDocument printdoc = new PrintDocument();
        private Data_Access DS = new Data_Access();

        public int getReportPaperSize(string paperSizeName = LETTER_PAPER_SIZE)
        {
            int i = 0;
            PrintDocument doctoprint = new PrintDocument();
            int rawKind = 0;
            for (i = 0; i <= doctoprint.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                //if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == "Half Kuarto")
                if (doctoprint.PrinterSettings.PaperSizes[i].PaperName == paperSizeName)
                {
                    rawKind = Convert.ToInt32(doctoprint.PrinterSettings.PaperSizes[i].GetType().GetField("kind", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes[i]));
                    break;
                }
            }

            return rawKind;
        }

        public int getListOfPrinter(ref List<string> printerName)
        {
            int numOfPrinter = 0;

            String namaprinter = "";
            System.Drawing.Printing.PrintDocument doctoprint = new System.Drawing.Printing.PrintDocument();
            int i = 0;
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                namaprinter = item.ToString();
                printerName.Add(namaprinter);
                i++;
            }

            numOfPrinter = i;

            return numOfPrinter;
        }

        public string getConfigPrinterName(int printerType = 1)
        {
            string printerName = "";
            string sqlCommand = "";

            if (Convert.ToInt32(DS.getDataSingleValue("SELECT COUNT(1) FROM SYS_CONFIG")) > 1)
            {
                if (printerType == 1) // POS RECEIPT PRINTER
                {
                    sqlCommand = "SELECT IFNULL(POS_RECEIPT_PRINTER, '') FROM SYS_CONFIG WHERE ID = 2";
                }
                else // KUARTO RECEIPT PRINTER
                {
                    sqlCommand = "SELECT IFNULL(KUARTO_PRINTER, '') FROM SYS_CONFIG WHERE ID = 2";
                }

                printerName = DS.getDataSingleValue(sqlCommand).ToString();
            }

            return printerName;
        }

    }
}
