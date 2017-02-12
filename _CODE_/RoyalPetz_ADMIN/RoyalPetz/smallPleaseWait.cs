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
    public partial class smallPleaseWait : Form
    {
        public smallPleaseWait()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text + ".";

            if (label1.Text.Length > 20)
                label1.Text = "PLEASE WAIT";
        }

        private void smallPleaseWait_Activated(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void smallPleaseWait_Deactivate(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
