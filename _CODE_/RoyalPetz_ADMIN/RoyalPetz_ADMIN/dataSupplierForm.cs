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

namespace RoyalPetz_ADMIN
{
    public partial class dataSupplierForm : Form
    {
        private int selectedSupplierID = 0;

        private Data_Access DS = new Data_Access();

        public dataSupplierForm()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, EventArgs e)
        {          
            dataSupplierDetailForm displayedForm = new dataSupplierDetailForm(globalConstants.NEW_SUPPLIER);
            displayedForm.ShowDialog(this);
        }

        private void loadSupplierData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            if (namaSupplierTextbox.Text.Equals(""))
                return;

            sqlCommand = "SELECT SUPPLIER_ID, SUPPLIER_FULL_NAME AS 'NAMA SUPPLIER' FROM MASTER_SUPPLIER WHERE SUPPLIER_ACTIVE = 1 AND SUPPLIER_FULL_NAME LIKE '%" + namaSupplierTextbox.Text + "%'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataSupplierDataGridView.DataSource = dt;

                    dataSupplierDataGridView.Columns["SUPPLIER_ID"].Visible = false;
                    dataSupplierDataGridView.Columns["NAMA SUPPLIER"].Width = 300;                    
                }
            }
        }

        private void namaSupplierTextbox_TextChanged(object sender, EventArgs e)
        {
            loadSupplierData();
        }

        private void dataSupplierForm_Activated(object sender, EventArgs e)
        {
            loadSupplierData();
        }

        private void dataSupplierDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataSupplierDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataSupplierDataGridView.Rows.Count <= 0)
                return;

            int selectedrowindex = dataSupplierDataGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataSupplierDataGridView.Rows[selectedrowindex];
            selectedSupplierID = Convert.ToInt32(selectedRow.Cells["SUPPLIER_ID"].Value);

            dataSupplierDetailForm displayedForm = new dataSupplierDetailForm(globalConstants.EDIT_SUPPLIER, selectedSupplierID);
            displayedForm.ShowDialog(this);
        }
    }
}
