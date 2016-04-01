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

using System.IO;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace RoyalPetz_ADMIN
{
    public partial class ReportUserForm : Form
    {
        private Data_Access DS = new Data_Access();

        public ReportUserForm()
        {
            InitializeComponent();
        }

        private void loadnamatoko(int opt, out string NamaToko)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            //string NamaToko, AlamatToko, TeleponToko, EmailToko;
            DS.mySqlConnect();
            NamaToko = "";
            //1 load default 2 setting user
            using (rdr = DS.getData("SELECT IFNULL(STORE_NAME,'') AS 'NAME', IFNULL(STORE_ADDRESS,'') AS 'ADDRESS', IFNULL(STORE_PHONE,'') AS 'PHONE', IFNULL(STORE_EMAIL,'') AS 'EMAIL' FROM SYS_CONFIG WHERE ID =  " + opt))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {                       
                        if (!String.IsNullOrEmpty(rdr.GetString("NAME")))
                        {
                            NamaToko = rdr.GetString("NAME");
                        }
                    }
                }

            }
            //return NamaToko;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DS.mySqlConnect();
            String sqlcmd = "SELECT U.USER_NAME AS 'USER', U.USER_FULL_NAME AS 'NAMA', U.USER_PHONE AS 'TELEPON', G.GROUP_USER_NAME AS 'GROUP' FROM MASTER_USER U, MASTER_GROUP G WHERE U.GROUP_ID = G.GROUP_ID AND U.ID="+textBox1.Text;
            DS.writeXML(sqlcmd); //done writing XML report

            // create temp dataset to read xml information
            DataSet dsTempReport = new DataSet();

            try
            {
                // using ReadXml method of DataSet read XML data from books.xml file
                string appPath = Directory.GetCurrentDirectory() + "\\dataset.xml";
                dsTempReport.ReadXml(@appPath);

                // copy XML data from temp dataset to our typed data set
                //dsReport.Tables[0].Merge(dsTempReport.Tables[0]);

                //prepare report for preview
                ReportUser rptXMLReport = new ReportUser();
                CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader;
                txtReportHeader = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                //baca database untuk nama toko
                string nama = "";
                loadnamatoko(2,out nama);
                txtReportHeader.Text = nama+" POS SYSTEM";
                //rptXMLReport.SetDataSource(dsTempReport);
                rptXMLReport.Database.Tables[0].SetDataSource(dsTempReport.Tables[0]);
                crystalReportViewer1.DisplayGroupTree = false;
                crystalReportViewer1.ReportSource = rptXMLReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReportUserForm_Load(object sender, EventArgs e)
        {
            //on load
            
        }
    }
}
