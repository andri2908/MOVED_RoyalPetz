using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaSoft
{
    public partial class newMessageForm : Form
    {
        Form parentForm = null;

        public newMessageForm(Form originForm)
        {
            InitializeComponent();
            parentForm = originForm;
        }

        private void closeForm()
        {
            adminForm originForm;
            this.Hide();

            messagingForm newMessagingForm = new messagingForm();
            newMessagingForm.ShowDialog(this);

            originForm = (adminForm)parentForm;
            originForm.setNewMessageFormExist(false);

            this.Close();
        }

        private void newMessageForm_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            closeForm();
        }

        private void newMessageForm_DoubleClick(object sender, EventArgs e)
        {
            closeForm();
        }
    }
}
