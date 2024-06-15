using AADLBusiness.Judger;
using System.Windows.Forms;

namespace AADL.Judgers.Controls
{
    public partial class ctrJudgerCard : UserControl
    {
        public enum enWhichID { JudgerID = 1, PractitionerID, PersonID }
        private clsJudger _judger;
        private int _ID;
        public ctrJudgerCard()
        {
            InitializeComponent();
        }

        private void _FillFormWithJudgerInfo()
        {
            lblJudgerID.Text = _judger.JudgerID.ToString();
            lblFullName.Text = _judger.SelectedPersonInfo.FullName;
            lblSubscriptionType.Text = _judger.SubscriptionTypeInfo.SubscriptionName;
            lblSubscriptionWay.Text = _judger.SubscriptionWayInfo.SubscriptionName;
            lblCreatedByUserID.Text = _judger.UserInfo.UserName;
            lblIssueDate.Text = _judger.IssueDate.ToString();
            lblLastEditDate.Text = _judger.LastEditByUserInfo?.UserName ?? "لم يتم تعديله بعد";

            // Handle Judger Casess
            if (_judger.JudgeCasesPracticeIDNameDictionary != null && _judger.JudgeCasesPracticeIDNameDictionary.Count != 0)
            {
                int count = 0;
                foreach (var item in _judger.JudgeCasesPracticeIDNameDictionary.Values)
                {
                    lvCasestypes.Items.Add($"  {++count}- {item}");
                }
            }
            else
            {
                lvCasestypes.Items.Add("لا يوجد قضايا");
            }
        }

        public void LoadJudgerInfo(int ID, enWhichID whichID)
        {
            _ID = ID;

            switch(whichID)
            {
                case enWhichID.JudgerID:
                    _judger = clsJudger.FindByJudgerID(ID);
                    break;
                case enWhichID.PractitionerID:
                    _judger = clsJudger.FindByPractitionerID(ID);
                    break;
                case enWhichID.PersonID:
                    _judger = clsJudger.FindByPersonID(ID);
                    break;
                default:
                    _judger = null;
                    break;
            }

            if(_judger == null) 
            {
                MessageBox.Show($"لا يوجد محكم يحمل الرقم التعريفي ({_ID})", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetJudgerInfo();
                return;
            }

            _FillFormWithJudgerInfo();
        }

        public void ResetJudgerInfo()
        {
            //Judger info
            _ID = -1;
            lblJudgerID.Text = "[????]";
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
            llblEditJudgerInfo.Enabled = false;
            llblBlackList.Enabled = false;
            llblWhiteList.Enabled = false;
            llblClosedList.Enabled = false;
        }

        private void llblPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonInfo frm = new frmPersonInfo(_judger.PersonID);
            frm.ShowDialog();
        }
    }
}
