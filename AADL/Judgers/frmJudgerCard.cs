using AADL.Judgers.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADL.Judgers
{
    public partial class frmJudgerCard : Form
    {
        ctrJudgerCard.enWhichID _whichID;
        int _ID;
        public frmJudgerCard(int ID, ctrJudgerCard.enWhichID whichID)
        {
            InitializeComponent();
            _ID = ID;
            _whichID = whichID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmJudgerCard_Load(object sender, EventArgs e)
        {
            ctrJudgerCard1.LoadJudgerInfo(_ID, _whichID);
        }
    }
}
