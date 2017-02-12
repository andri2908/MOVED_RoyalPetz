using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace AlphaSoft
{
    public partial class SetPrinterForm : Form
    {
        public PrinterSettings ps = new PrinterSettings();
        private PrintDocument printdoc = new PrintDocument();
        private globalUtilities gutil = new globalUtilities();

        private int[] arrPaperSize = { globalUtilities.PAPER_HALF_KWARTO, globalUtilities.PAPER_FULL_KWARTO };

        public SetPrinterForm()
        {
            InitializeComponent();
            listAllPrinters();
        }

        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.PrinterlistBox.Items.Add(item.ToString());
            }
        }

        private void listPaper()
        {
            PrintDocument pd = new PrintDocument();
            //pd.PrinterSettings.PrinterName = // printer name
            pd.PrinterSettings.PrinterName = PrinterlistBox.SelectedItem.ToString();
            //comboBox1.DisplayMember = "PaperName";
            foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
            {
                //comboBox1.Items.Add(item);
            }

        }

        private void SetPrinterForm_Load(object sender, EventArgs e)
        {
            sizeComboBox.SelectedIndex = gutil.getPaper();
            PrinterlistBox.SelectedItem = PrinterlistBox.Items[0];
        }

        private void PrinterlistBox_SelectedValueChanged(object sender, EventArgs e)
        {            
            //listPaper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pname = this.PrinterlistBox.SelectedItem.ToString();

            gutil.setPaper(arrPaperSize[sizeComboBox.SelectedIndex]);
            gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_PRINTER, "PAPER SIZE CHANGED [" + sizeComboBox.SelectedIndex + "]");

            myPrinters.SetDefaultPrinter(pname);
            gutil.saveSystemDebugLog(globalConstants.MENU_PENGATURAN_PRINTER, "DEFAULT PRINTER CHANGED [" + pname + "]");

            MessageBox.Show("Pengaturan printer telah diubah!");
        }
    }
}
