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

using Hotkeys;

namespace AlphaSoft
{
    public partial class dataSatuanForm : Form
    {
        private globalUtilities gutil = new globalUtilities();

        private int originModuleID = 0;
        private int selectedUnitID = 0;
        private dataProdukDetailForm parentForm;

        Data_Access DS = new Data_Access();

        dataSatuanDetailForm displaySatuanDetailForm = null;
        dataSatuanDetailForm editSatuanDetailForm = null;

        private Hotkeys.GlobalHotkey ghk_UP;
        private Hotkeys.GlobalHotkey ghk_DOWN;
        private Hotkeys.GlobalHotkey ghk_ESC;

        private bool navKeyRegistered = false;

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

        private void captureAll(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;
                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int modifier = (int)m.LParam & 0xFFFF;

                if (modifier == Constants.NOMOD)
                    captureAll(key);
            }

            base.WndProc(ref m);
        }

        private void registerGlobalHotkey()
        {
            ghk_UP = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Up, this);
            ghk_UP.Register();

            ghk_DOWN = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Down, this);
            ghk_DOWN.Register();

            ghk_ESC = new Hotkeys.GlobalHotkey(Constants.NOMOD, Keys.Escape, this);
            ghk_ESC.Register();

            navKeyRegistered = true;
        }

        private void unregisterGlobalHotkey()
        {
            ghk_UP.Unregister();
            ghk_DOWN.Unregister();
            ghk_ESC.Unregister();

            navKeyRegistered = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (null == displaySatuanDetailForm || displaySatuanDetailForm.IsDisposed)
                    displaySatuanDetailForm = new dataSatuanDetailForm(globalConstants.NEW_UNIT);

            displaySatuanDetailForm.Show();
            displaySatuanDetailForm.WindowState = FormWindowState.Normal;
        }

        private void loadUnitData(int options=0)
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();
            string sqlCommand;
            string unitNameParam = "";
            
            unitNameParam = MySqlHelper.EscapeString(unitNameTextBox.Text);
            DS.mySqlConnect();
            if (options == 1)
            {
                sqlCommand = "SELECT UNIT_ID, UNIT_NAME AS 'NAMA UNIT', UNIT_DESCRIPTION AS 'DESKRIPSI UNIT' FROM MASTER_UNIT";
            }
            else            {

                if (unitNameTextBox.Text.Equals(""))
                    return;
                if (satuannonactiveoption.Checked == true)
                {
                    sqlCommand = "SELECT UNIT_ID, UNIT_NAME AS 'NAMA UNIT', UNIT_DESCRIPTION AS 'DESKRIPSI UNIT' FROM MASTER_UNIT WHERE UNIT_NAME LIKE '%" + unitNameParam + "%'";
                }
                else
                {
                    sqlCommand = "SELECT UNIT_ID, UNIT_NAME AS 'NAMA UNIT', UNIT_DESCRIPTION AS 'DESKRIPSI UNIT' FROM MASTER_UNIT WHERE UNIT_ACTIVE = 1 AND UNIT_NAME LIKE '%" + unitNameParam + "%'";
                }
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

            registerGlobalHotkey();
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
                    if (null == editSatuanDetailForm || editSatuanDetailForm.IsDisposed)
                            editSatuanDetailForm = new dataSatuanDetailForm(globalConstants.EDIT_UNIT, selectedUnitID);

                    editSatuanDetailForm.Show();
                    editSatuanDetailForm.WindowState = FormWindowState.Normal;
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
            unitNameTextBox.Select();
        }

        private void dataUnitGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataUnitGridView.Rows.Count > 0)
                if (e.KeyCode == Keys.Enter)
                    displaySpecificForm();
        }

        private void dataSatuanForm_Deactivate(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataUnitGridView_Enter(object sender, EventArgs e)
        {
            if (navKeyRegistered)
                unregisterGlobalHotkey();
        }

        private void dataUnitGridView_Leave(object sender, EventArgs e)
        {
            if (!navKeyRegistered)
                registerGlobalHotkey();
        }

        private void unitNameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                dataUnitGridView.Select();
            }
        }

        private void AllButton_Click(object sender, EventArgs e)
        {
            loadUnitData(1);
        }
    }
}
