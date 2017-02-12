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

namespace AlphaSoft
{
    public partial class XMLGeneratorForm : Form
    {
        private Data_Access DS = new Data_Access();
        private globalUtilities gutil = new globalUtilities();

        public XMLGeneratorForm()
        {
            InitializeComponent();
        }

        private void XMLGeneratorForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DS.mySqlConnect();
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Error no SQL Command");
            } else
            {
                String sqlcmd = textBox1.Text;
                if (textBox2.Text.Equals(""))
                {
                    DS.writeXML(sqlcmd); //done writing XML report
                }
                else
                {
                    DS.writeXML(sqlcmd, textBox2.Text);
                }
            }
        }
    }
}
