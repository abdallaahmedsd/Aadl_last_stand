using AADL.Lists;
using AADL.Regulators;
using AADLBusiness;
using AADLBusiness.Expert;
using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
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
        private void ResetOnDemand(object sender, EventArgs e)
        {
            ResetExpertInfo();
            _FillFormWithExpertInfo();
        }


        private void llblEditExpertInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePractitioner form = new frmAddUpdatePractitioner(_expert.PractitionerID,
              frmAddUpdatePractitioner.enRunSpecificTabPage.Judger);
            form.evPractitionerUpdated += ResetOnDemand;
            form.ShowDialog();
        }

        private void llblBlackList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo frmListInfo = new frmListInfo(clsBlackList.Find(_expert.PractitionerID, clsBlackList.enFindBy.PractitionerID).BlackListID
                    , ctrlListInfo.CreationMode.BlackList);

                frmListInfo.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());

                MessageBox.Show("لقد حدث عطل فني داخل النظام , اثناء محاولة استرجاع البيانات .", "فشل",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblWhiteList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmListInfo ListInfoForm = new frmListInfo((int)clsWhiteList.Find(_expert.PractitionerID,
              clsPractitioner.enPractitionerType.Judger).WhiteListID,
              ctrlListInfo.CreationMode.WhiteList);
                ListInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());

                MessageBox.Show("لقد حدث عطل فني داخل النظام , اثناء محاولة استرجاع البيانات .", "فشل",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblClosedList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

                try
                {
                    frmListInfo ListInfoForm = new frmListInfo((int)clsClosedList.Find(_expert.PractitionerID,
              clsPractitioner.enPractitionerType.Judger).ClosedListID,
              ctrlListInfo.CreationMode.ClosedList);
                    ListInfoForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception:" + ex.ToString());

                    MessageBox.Show("لقد حدث عطل فني داخل النظام , اثناء محاولة استرجاع البيانات .", "فشل",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
