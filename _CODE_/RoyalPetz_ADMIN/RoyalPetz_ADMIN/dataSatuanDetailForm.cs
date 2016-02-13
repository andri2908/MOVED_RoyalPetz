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
    public partial class dataSatuanDetailForm : Form
    {
        private int originModuleID = 0;
        private int selectedUnitID = 0;

        private Data_Access DS = new Data_Access();

        public dataSatuanDetailForm()
        {
            InitializeComponent();
        }

        public dataSatuanDetailForm(int moduleID)
        {
            InitializeComponent();

            originModuleID = moduleID;
        }

        public dataSatuanDetailForm(int moduleID, int unitID)
        {
            InitializeComponent();

            originModuleID = moduleID;
            selectedUnitID = unitID;
        }

        private void loadUnitData()
        {
            MySqlDataReader rdr;
            DataTable dt = new DataTable();

            DS.mySqlConnect();

            using (rdr = DS.getData("SELECT * FROM MASTER_UNIT WHERE UNIT_ID = " + selectedUnitID))
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        unitNameTextBox.Text = rdr.GetString("UNIT_NAME");
                        unitDescriptionTextBox.Text = rdr.GetString("UNIT_DESCRIPTION");

                        if (rdr.GetString("UNIT_ACTIVE").Equals("1"))
                            nonAktifCheckbox.Checked = false;
                        else
                            nonAktifCheckbox.Checked = true;
                    }
                }
            }
        }

        private void dataSatuanDetailForm_Load(object sender, EventArgs e)
        {
            errorLabel.Text = "";

            loadUnitData();
        }

        private bool dataValidated()
        {
            return true;
        }

        private bool saveDataTransaction()
        {
            bool result = false;
            string sqlCommand = "";

            string unitName = unitNameTextBox.Text.Trim();
            string unitDesc = unitDescriptionTextBox.Text.Trim();
            byte unitStatus = 0;

            if (nonAktifCheckbox.Checked)
                unitStatus = 0;
            else
                unitStatus = 1;

            DS.beginTransaction();

            try
            {
                DS.mySqlConnect();

                switch (originModuleID)
                {
                    case globalConstants.NEW_UNIT:
                        sqlCommand = "INSERT INTO MASTER_UNIT (UNIT_NAME, UNIT_DESCRIPTION, UNIT_ACTIVE) VALUES ('" + unitName+ "', '" + unitDesc+ "', " + unitStatus+ ")";
                        break;
                    case globalConstants.EDIT_UNIT:
                        sqlCommand = "UPDATE MASTER_UNIT SET UNIT_NAME = '" + unitName + "', UNIT_DESCRIPTION = '" + unitDesc + "', UNIT_ACTIVE = " + unitStatus + " WHERE UNIT_ID = " + selectedUnitID;
                        break;
                }

                DS.executeNonQueryCommand(sqlCommand);

                DS.commit();
            }
            catch (Exception e)
            {
                try
                {
                    //myTrans.Rollback();
                }
                catch (MySqlException ex)
                {
                    if (DS.getMyTransConnection() != null)
                    {
                        MessageBox.Show("An exception of type " + ex.GetType() +
                                          " was encountered while attempting to roll back the transaction.");
                    }
                }

                MessageBox.Show("An exception of type " + e.GetType() +
                                  " was encountered while inserting the data.");
                MessageBox.Show("Neither record was written to database.");
            }
            finally
            {
                DS.mySqlClose();
                result = true;
            }

            return result;
        }

        private bool saveData()
        {
            if (dataValidated())
            {
                return saveDataTransaction();
            }

            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("SUCCESS");
            }
        }
    }
}
