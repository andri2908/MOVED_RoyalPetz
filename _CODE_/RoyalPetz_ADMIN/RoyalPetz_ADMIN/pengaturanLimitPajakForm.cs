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
    public partial class pengaturanLimitPajakForm : Form
    {
        private globalUtilities gutil = new globalUtilities();
        public pengaturanLimitPajakForm()
        {
            InitializeComponent();
        }

        private void pengaturanLimitPajakForm_Load(object sender, EventArgs e)
        {
            Button[] arrButton = new Button[2];

            arrButton[0] = saveButton;
            arrButton[1] = resetbutton;
            gutil.reArrangeButtonPosition(arrButton, arrButton[0].Top, this.Width);

            gutil.reArrangeTabOrder(this);
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            gutil.ResetAllControls(this);
        }

        private void pengaturanLimitPajakForm_Activated(object sender, EventArgs e)
        {
            //if need something
        }
    }
}
