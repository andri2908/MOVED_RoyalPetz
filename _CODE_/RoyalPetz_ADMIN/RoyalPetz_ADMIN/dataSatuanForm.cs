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
    public partial class dataSatuanForm : Form
    {
        private globalUtilities gutil = new globalUtilities();

        private int originModuleID = 0;
        private int selectedUnitID = 0;
        private dataProdukDetailForm parentForm;

        Data_Access DS = new Data_Access();

        public dataSatuanForm()
        {
            InitializeComponent();
        }

        public dataSatuanForm(int moduleID, dataProdukDetailForm thisForm)
        {
            InitializeComponent();
            originModuleID = moduleID;
            parentForm = thisForm;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataSatuanDetailForm displayedForm = new dataSatuanDetailForm(globalConstants.NEW_UNIT);
            displayedForm.ShowDialog(this);
        }

        private void loadUnitData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            if (unitNameTextBox.Text.Equals(""))
                return;

            DS.mySqlConnect();
            if (satuannonactiveoption.Checked == true)
            {
                sqlCommand = "SELECT UNIT_ID, UNIT_NAME AS 'NAMA UNIT', UNIT_DESCRIPTION AS 'DESKRIPSI UNIT' FROM MASTER_UNIT WHERE UNIT_NAME LIKE '%" + unitNameTextBox.Text + "%'";
            }
            else
            {
                sqlCommand = "SELECT UNIT_ID, UNIT_NAME AS 'NAMA UNIT', UNIT_DESCRIPTION AS 'DESKRIPSI UNIT' FROM MASTER_UNIT WHERE UNIT_ACTIVE = 1 AND UNIT_NAME LIKE '%" + unitNameTextBox.Text + "%'";
            }

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);

                    dataUnitGridView.DataSource = dt;

                    dataUnitGridView.Columns["UNIT_ID"].Visible = false;
                    dataUnitGridView.Columns["NAMA UNIT"].Width = 200;
                    dataUnitGridView.Columns["DESKRIPSI UNIT"].Width = 300;
                }
            }
        }

        private void dataSatuanForm_Activated(object sender, EventArgs e)
        {
            //loadUnitData();
            if (!unitNameTextBox.Text.Equals(""))
            {
                loadUnitData();
            }
        }
        
        private void unitNameTextBox_TextChanged(object sender, EventArgs e)
        {
            //loadUnitData();
            if (!unitNameTextBox.Text.Equals(""))
            {
                loadUnitData();
            }
        }

        private void displaySpecificForm()
        {
            int selectedrowindex = dataUnitGridView.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataUnitGridView.Rows[selectedrowindex];
            selectedUnitID = Convert.ToInt32(selectedRow.Cells["UNIT_ID"].Value);

            switch (originModuleID)
            {
                case globalConstants.PRODUK_DETAIL_FORM:
                    parentForm.setSelectedUnitID(selectedUnitID);
                    this.Close();
                    break;

                default:                    
                    dataSatuanDetailForm displayedForm = new dataSatuanDetailForm(globalConstants.EDIT_UNIT, selectedUnitID);
                    displayedForm.ShowDialog(this);
                    break;
            }
        }

        private void dataUnitGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataUnitGridView.Rows.Count > 0)
                displaySpecificForm();
        }

        private void satuannonactiveoption_CheckedChanged(object sender, EventArgs e)
        {
            dataUnitGridView.DataSource = null;
            if (!unitNameTextBox.Text.Equals(""))
            {
                loadUnitData();
            }
        }

        private void dataSatuanForm_Load(object sender, EventArgs e)
        {
            gutil.reArrangeTabOrder(this);
        }
    }
}
