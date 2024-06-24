using AADLBusiness.Expert;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADL.Experts
{
    public partial class frmExpertCard : Form
    {
        private int _ID;
        private clsExpert.enFindBy _findBy;
        public frmExpertCard(int ID, clsExpert.enFindBy findBy)
        {
            InitializeComponent();
            _ID = ID;
            _findBy = findBy;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmExpertCard_Load(object sender, EventArgs e)
        {
            ctrExpertCard1.LoadExpertInfo(_ID, _findBy);
        }
    }
}
