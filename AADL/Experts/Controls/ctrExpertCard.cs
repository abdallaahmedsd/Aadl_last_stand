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

namespace AADL.Experts.Controls
{
    public partial class ctrExpertCard : UserControl
    {
        public ctrExpertCard()
        {
            InitializeComponent();
        }

        private clsExpert _expert;
        private int _ID;

        private void _FillFormWithExpertInfo()
        {
            lblExpertID.Text = _expert.ExpertID.ToString();
            lblFullName.Text = _expert.SelectedPersonInfo.FullName;
            lblSubscriptionType.Text = _expert.SubscriptionTypeInfo.SubscriptionName;
            lblSubscriptionWay.Text = _expert.SubscriptionWayInfo.SubscriptionName;
            lblCreatedByUserID.Text = _expert.UserInfo.UserName;
            lblIssueDate.Text = _expert.IssueDate.ToShortDateString();
            lblLastEditDate.Text = _expert.LastEditByUserInfo?.UserName ?? "لم يتم تعديله بعد";

            // Handle Expert Casess
            if (_expert.ExpertCasesPracticeIDNameDictionary != null && _expert.ExpertCasesPracticeIDNameDictionary.Count != 0)
            {
                int count = 0;
                foreach (var item in _expert.ExpertCasesPracticeIDNameDictionary.Values)
                {
                    lvCasestypes.Items.Add($"  {++count}- {item}");
                }
            }
            else
            {
                lvCasestypes.Items.Add("لا يوجد قضايا");
            }
        }

        public void LoadExpertInfo(int ID, clsExpert.enFindBy findBy)
        {
            _ID = ID;

            _expert = clsExpert.Find(ID, findBy);

            if (_expert == null)
            {
                MessageBox.Show($"لا يوجد خبير يحمل الرقم التعريفي ({_ID})", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetExpertInfo();
                return;
            }

            _FillFormWithExpertInfo();
        }

        public void ResetExpertInfo()
        {
            //Expert info
            _ID = -1;
            lblExpertID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblSubscriptionType.Text = "[????]";
            lblSubscriptionWay.Text = "[????]";

            //Edit and create.
            lblCreatedByUserID.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblLastEditDate.Text = "[????]";

            ////list view 
            lvCasestypes.Items.Clear();
            lvCasestypes.Columns.Clear();

            //Link label
            llblPersonInfo.Enabled = false;
            llblEditExpertInfo.Enabled = false;
            llblBlackList.Enabled = false;
            llblWhiteList.Enabled = false;
            llblClosedList.Enabled = false;
        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(_expert.PersonID);
            frm.ShowDialog();
        }
    }
}
