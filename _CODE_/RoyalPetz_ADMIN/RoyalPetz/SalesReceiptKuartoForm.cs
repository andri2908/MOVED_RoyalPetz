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
    public partial class SalesReceiptKuartoForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        public SalesReceiptKuartoForm()
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

        private void SalesReceiptKuartoForm_Load(object sender, EventArgs e)
        {

            DataSet dsTempReport = new DataSet();
            try
            {
                string appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.SalesReceiptXML;
                dsTempReport.ReadXml(@appPath);

                //prepare report for preview
                SalesReceiptKuarto rptXMLReport = new SalesReceiptKuarto();
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
