using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyalPetz_ADMIN
{
    public partial class groupAccessModuleForm : Form
    {
        private void fillInDummyData()
        {
            groupAccessDataGridView.Rows.Add("PENGATURAN LOKASI DATABASE", false);
            groupAccessDataGridView.Rows.Add("BACKUP/RESTORE DATABASE", false);
            groupAccessDataGridView.Rows.Add("TAMBAH USER", false);
            groupAccessDataGridView.Rows.Add("HAPUS USER", false);
            groupAccessDataGridView.Rows.Add("EDIT USER", false);
        }
            

        public groupAccessModuleForm()
        {
            InitializeComponent();
        }

        private void newGroupButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            dataGroupDetailForm displayForm = new dataGroupDetailForm(globalConstants.PENGATURAN_GRUP_AKSES);
            displayForm.ShowDialog();

            this.Show();
        }

        private void groupAccessModuleForm_Load(object sender, EventArgs e)
        {
            fillInDummyData();
        }
    }
}
