﻿using System;
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
    public partial class dataGroupForm : Form
    {
        private int originModuleID = 0;
        private int selectedGroupID;
        private dataUserDetailForm userDetailForm;

        Data_Access DS = new Data_Access();

        public dataGroupForm()
        {
            InitializeComponent();
        }

        public dataGroupForm(int moduleID)
        {
            InitializeComponent();
            
            if (moduleID > 50)
                newButton.Visible = false;
            
            originModuleID = moduleID;
        }

        public dataGroupForm(int moduleID, dataUserDetailForm parentForm)
        {
            InitializeComponent();

            if (moduleID > 50)
                newButton.Visible = false;

            originModuleID = moduleID;
            userDetailForm = parentForm;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            dataGroupDetailForm displayForm = new dataGroupDetailForm(globalConstants.NEW_GROUP_USER);
            displayForm.ShowDialog(this);
        }

        private void loadUserGroupData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;

            DS.mySqlConnect();

            sqlCommand = "SELECT GROUP_ID, GROUP_USER_NAME AS 'NAMA GROUP', GROUP_USER_DESCRIPTION AS 'DESKRIPSI GROUP' FROM MASTER_GROUP WHERE GROUP_USER_ACTIVE = 1 AND GROUP_USER_NAME LIKE '%"+namaGroupTextbox.Text+"%'";

            using (rdr = DS.getData(sqlCommand))
            {
                if (rdr.HasRows)
                {
                    dt.Load(rdr);
                    dataUserGroupGridView.DataSource = dt;

                    dataUserGroupGridView.Columns["GROUP_ID"].Visible = false;
                    dataUserGroupGridView.Columns["NAMA GROUP"].Width = 200;
                    dataUserGroupGridView.Columns["DESKRIPSI GROUP"].Width = 300;
                }
            }
        }

        private void displaySpecificForm()
        {
            switch (originModuleID)
            {
                case globalConstants.TAMBAH_HAPUS_GROUP_USER:
                    dataGroupDetailForm displayNewGroupForm = new dataGroupDetailForm(globalConstants.EDIT_GROUP_USER, selectedGroupID);
                    displayNewGroupForm.ShowDialog(this);
                    break;
                
                case globalConstants.PENGATURAN_GRUP_AKSES:
                    groupAccessModuleForm groupAccessForm = new groupAccessModuleForm(selectedGroupID);
                    groupAccessForm.ShowDialog(this);
                    break;

                case globalConstants.PENGATURAN_POTONGAN_HARGA:
                    pengaturanPotonganHargaForm pengaturanHargaForm = new pengaturanPotonganHargaForm();
                    pengaturanHargaForm.ShowDialog(this);
                    break;

                case globalConstants.TAMBAH_HAPUS_USER:
                    userDetailForm.setSelectedGroupID(selectedGroupID);
                    this.Close();
                    break;
            }
        }

        private void dataSalesDataGridView_DoubleClick(object sender, EventArgs e)
        {
            int selectedrowindex = dataUserGroupGridView.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = dataUserGroupGridView.Rows[selectedrowindex];
            selectedGroupID = Convert.ToInt32(selectedRow.Cells["GROUP_ID"].Value);

            displaySpecificForm();
        }

        private void dataGroupForm_Activated(object sender, EventArgs e)
        {
            //the codes below run when focus changed to this form               
            loadUserGroupData();            
        }

        private void namaGroupTextbox_TextChanged(object sender, EventArgs e)
        {
            loadUserGroupData();
        }
    }
}
