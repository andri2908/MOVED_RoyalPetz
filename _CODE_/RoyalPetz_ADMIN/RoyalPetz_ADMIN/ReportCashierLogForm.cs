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
using System.Globalization;

namespace RoyalPetz_ADMIN
{
    public partial class ReportCashierLogForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        private Data_Access DS = new Data_Access();
        
        public ReportCashierLogForm()
        {
            InitializeComponent();
        }

        
        private void ReportCashierLogForm_Load(object sender, EventArgs e)
        {

        }

        private void CariButton_Click(object sender, EventArgs e)
        {
            

        }
    }
}
