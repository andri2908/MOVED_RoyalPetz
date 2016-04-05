﻿using System;
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
    public partial class ReportSupplierForm : Form
    {
        private globalUtilities gutil = new globalUtilities();

        public ReportSupplierForm()
        {
            InitializeComponent();
        }

        private void ReportSupplierForm_Load(object sender, EventArgs e)
        {
            DataSet dsTempReport = new DataSet();
            try
            {
                string appPath = Directory.GetCurrentDirectory() + "\\" + globalConstants.SupplierXML;
                dsTempReport.ReadXml(@appPath);

                //prepare report for preview
                ReportSupplier rptXMLReport = new ReportSupplier();
                CrystalDecisions.CrystalReports.Engine.TextObject txtReportHeader1, txtReportHeader2, txtReportHeader3;
                txtReportHeader1 = rptXMLReport.ReportDefinition.ReportObjects["NamaTokoLabel"] as TextObject;
                txtReportHeader2 = rptXMLReport.ReportDefinition.ReportObjects["InfoTokoLabel"] as TextObject;
                txtReportHeader3 = rptXMLReport.ReportDefinition.ReportObjects["JudulLabel"] as TextObject;
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
                txtReportHeader3.Text = "LAPORAN DAFTAR PEMASOK/ SUPPLIER";
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
