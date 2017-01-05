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
    public partial class SupplierHistoryForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        Data_Access DS = new Data_Access();
        private string kodeproduk = "";
        dataSupplierDetailForm viewSupplierForm = null;

        public SupplierHistoryForm()
        {
            InitializeComponent();
        }
        public SupplierHistoryForm(string productID)
        {
            InitializeComponent();
            kodeproduk = productID;
        }

        private void loadSupplierHistory()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            sqlCommand = "SELECT M.SUPPLIER_ID AS ID, IFNULL(M.SUPPLIER_FULL_NAME,'') AS SUPPLIER, H.LAST_SUPPLY AS 'TANGGAL' FROM MASTER_SUPPLIER M, SUPPLIER_HISTORY H WHERE M.SUPPLIER_ID = H.SUPPLIER_ID AND H.PRODUCT_ID = '" + kodeproduk + "' ORDER BY TANGGAL DESC";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);

                    supplierHistoryGridView.DataSource = dt;
                    supplierHistoryGridView.Columns["ID"].Visible = false;
                    supplierHistoryGridView.Columns["SUPPLIER"].Width = 390;
                    supplierHistoryGridView.Columns["TANGGAL"].Width = 125;
                }
            }
        }

        private void SupplierHistoryForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
            loadSupplierHistory();
        }

        private void supplierHistoryGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //view supplier dataif (null == editSupplierForm || editSupplierForm.IsDisposed)

            int selectedrowindex = supplierHistoryGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = supplierHistoryGridView.Rows[selectedrowindex];
            int selectedSupplierID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            viewSupplierForm = new dataSupplierDetailForm(globalConstants.VIEW_SUPPLIER, selectedSupplierID);

            viewSupplierForm.Show();
            viewSupplierForm.WindowState = FormWindowState.Normal;
        }
    }
}
