using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;

namespace RoyalPetz_ADMIN
{
    class globalUtilities
    {
        public const string REGEX_NUMBER_WITH_2_DECIMAL = @"^[0-9]*\.?\d{0,2}$";
        public const string REGEX_NUMBER_ONLY = @"^[0-9]*$";
        public const string CUSTOM_DATE_FORMAT = "dd MMM yyyy";
        public int INS = 1;
        public int UPD = 2;

        public string allTrim(string valueToTrim)
        {
            string temp = "";

            temp = valueToTrim.Replace(" ", "");

            return temp;
        }

        public bool matchRegEx(string textToMatch, string regExValue)
        {
            Regex r = new Regex(regExValue); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(textToMatch);

            return m.Success;
        }

        public void ClearControls(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is MaskedTextBox)
                {
                    MaskedTextBox maskedtextBox = (MaskedTextBox)control;
                    maskedtextBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }

        public void ResetAllControls(Control form)
        {
            String typectrl = "";
            ClearControls(form); //if controls are not nested
            for (int i = 0; i <= form.Controls.Count - 1; i++) //if controls are nested
            {

                typectrl = "" + form.Controls[i].GetType();
                //MessageBox.Show(typectrl);
                if ((typectrl.Equals("System.Windows.Forms.Panel")) || (typectrl.Equals("System.Windows.Forms.TableLayoutPanel")))
                {
                    Control ctrl = form.Controls[i];
                    //MessageBox.Show("" + ctrl.Controls.Count);
                    //ClearControls(ctrl);
                   ResetAllControls(ctrl);
                }
            }

        }
        public void reArrangeTabOrder(Control form)
        {
            TabOrderManager.TabScheme scheme;
            scheme = TabOrderManager.TabScheme.DownFirst;
            TabOrderManager tom = new TabOrderManager(form);
            tom.SetTabOrder(scheme);

        }

        public void showError(string errormessage)
        {
            String errorcaption = "POS Error Message";
            DialogResult res1 = MessageBox.Show(errormessage, errorcaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void showDBOPError(Exception ex, string dbOp)
        {
            String errorcaption = "POS Error Message";
            string displayedErrorMessage;
            
            displayedErrorMessage = "An exception of type " + ex.GetType() + " and message [" + ex.Message +"] was encountered while " + dbOp +" the data.";

            DialogResult res1 = MessageBox.Show(displayedErrorMessage, errorcaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void showSuccess(int options)
        {
            String successcaption = "POS Success Message";
            String successmessage = "";
            if (options == INS) //insert success
            {
                successmessage = "Saving data to table success!";
            }
            else
            {
                if (options == UPD)
                {
                    successmessage = "Update data to table success!";

                }
            }

            DialogResult res1 = MessageBox.Show(successmessage, successcaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
