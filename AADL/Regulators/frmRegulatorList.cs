using AADL.Judgers;
using AADLBusiness;
using AADLBusiness.Judger;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADL.Regulators
{
    public partial class frmRegulatorList : Form
    {
        private enum enMode { add, update, delete }
        private enMode _mode = enMode.add;
        private ushort _pageNumber = 0;
        private DataTable _dtRegulators;
        public frmRegulatorList()
        {
            InitializeComponent();
        }
        private void _FillDataGridView(DataTable dtRegulators)
        {
            if (dtRegulators != null && dtRegulators.Rows.Count > 0)
            {
                dgvRegulators.DataSource = dtRegulators;

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvRegulators.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Change the columns name

                dgvRegulators.Columns["RegulatorID"].HeaderText = "الرقم التعريفي";
                dgvRegulators.Columns["MembershipNumber"].HeaderText = "رقم العضوية";
                dgvRegulators.Columns["FullName"].HeaderText = "الاسم رباعي";
                dgvRegulators.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgvRegulators.Columns["Email"].HeaderText = "رقم الهاتف";
                dgvRegulators.Columns["Gender"].HeaderText = "النوع";
                dgvRegulators.Columns["CountryName"].HeaderText = "الدولة";
                dgvRegulators.Columns["CityName"].HeaderText = "المدينة";
                dgvRegulators.Columns["IsActive"].HeaderText = "هل فعال ؟";


                lblTotalRecordsCount.Text = dtRegulators.Rows.Count.ToString();
            }
        }
        private void _LoadRefreshRegulatorsPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            if (_mode == enMode.add || _mode == enMode.delete)
                _HandleNumberOfPages();

            // load Judgers data per page and save them in the DataTable "_dtJudgers"
            // in case the page number is equal to zero assign null to the DataTable "_dtJudgers"
            _dtRegulators = _pageNumber > 0 ? clsRegulator.GetRegulatorsPerPage(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtRegulators);
        }
        private void _HandleNumberOfPages()
        {
            uint totalJudgersCount = (uint)clsRegulator.Count();

            // Calculate the number of pages depending on "totalJudgersCount"
            uint numberOfPages = totalJudgersCount > 0 ? (uint)Math.Ceiling((double)totalJudgersCount / clsUtil.RowsPerPage) : 0;

            cbPage.Items.Clear();

            if (numberOfPages == 0)
            {
                cbPage.Items.Add(0);
                cbPage.Enabled = false;
            }
            else
            {
                for (int i = 1; i <= numberOfPages; i++)
                    cbPage.Items.Add(i);

                cbPage.Enabled = true;
            }

            // Select the first page to to load its data if any
            cbPage.SelectedIndex = 0;
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;
        }
        private void _Filter()
        {
            string filterColumn = string.Empty;
            string filterValue = txtFilterValue.Text.Trim();

            // Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "لا شيء":
                    filterColumn = "None";
                    break;
                case "الرقم التعريفي":
                    filterColumn = "RegulatorID";
                    break;
                case "الاسم":
                    filterColumn = "FullName";
                    break;
                case "رقم الهاتف":
                    filterColumn = "Phone";
                    break;
                case "البريد الالكتروني":
                    filterColumn = "Email";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtRegulators.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "RegulatorID")
                    //in this case we deal with integer not string.
                    _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
        }
        private void frmRegulatorList_Load(object sender, EventArgs e)
        {

            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvRegulators);

            _LoadRefreshRegulatorsPerPage();

            cbFilterBy.SelectedItem = "لا شيء";
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شيء" && cbFilterBy.Text != "هل فعال ؟");

            cbIsActive.Visible = cbFilterBy.Text == "هل فعال ؟";

            if (cbIsActive.Visible)
                cbIsActive.SelectedItem = "الكل";

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtRegulators != null)
            {
                _dtRegulators.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
            }
        }
        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Judgers data from the database and view it in the DataGridView
            _dtRegulators = clsRegulator.GetRegulatorsPerPage(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtRegulators);

            // Reset the filter
            cbFilterBy.SelectedItem = "لا شيء";
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم التعريفي"|| cbFilterBy.Text == "الهاتف")
                clsUtil.IsNumber(e);
        }  
  
        // This function will supress the ContextMenuStrip from being shown in-case the DataGridView is empty
        private void dgvRegulators_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvRegulators.Rows.Count == 0 || dgvRegulators.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvRegulators.CurrentCell = dgvRegulators[e.ColumnIndex, e.RowIndex];
                    cmsRegulators.Show(Cursor.Position);
                }
            }
        }
        private void dgvRegulators_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

            frmRegulatorInfo frm = new frmRegulatorInfo(RegulatorID);
            frm.ShowDialog();
        }

        private void cmsRegulator_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isActive = (bool)dgvRegulators.CurrentRow.Cells["IsActive"].Value;

            if (isActive)
            {
                activateRegulatorToolStripMenuItem.Enabled = false;
                deactivateRegulatorToolStripMenuItem.Enabled = true;
            }
            else
            {
                activateRegulatorToolStripMenuItem.Enabled = true;
                deactivateRegulatorToolStripMenuItem.Enabled = false;
            }
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterColumn = "IsActive";
            string filterValue = string.Empty;

            // Map Selected Filter to real Column name 
            switch (cbIsActive.Text)
            {
                case "الكل":
                    filterValue = string.Empty;
                    break;
                case "نعم":
                    filterValue = "1";
                    break;
                case "لا":
                    filterValue = "0";
                    break;
                default:
                    filterValue = string.Empty;
                    break;
            }

            if (filterValue == string.Empty)
                _dtRegulators.DefaultView.RowFilter = filterValue;
            else
                _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

            frmRegulatorInfo frm = new frmRegulatorInfo(RegulatorID);
            frm.ShowDialog();
        }

        private void activateRegulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

                if (MessageBox.Show($"هل انت متاكد انك تريد تريد تفعيل الحساب رقم {RegulatorID} ؟", "تاكيد التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (clsRegulator.ActivateByRegulatorID(RegulatorID))
                    {
                        MessageBox.Show($"تم تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _mode = enMode.delete;
                        _LoadRefreshRegulatorsPerPage();
                    }
       
            
                    else
                        MessageBox.Show($"لم يتم تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }

        }

        private void deactivateRegulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
                int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

                if (MessageBox.Show($"هل انت متاكد انك تريد تريد الغاء تفعيل الحساب رقم {RegulatorID} ؟", "تاكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (clsRegulator.DeactivateByRegulatorID(RegulatorID))
                    {
                        MessageBox.Show($"تم الإلغاء تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _mode = enMode.delete;
                        _LoadRefreshRegulatorsPerPage();
                    }
                    else
                        MessageBox.Show($"لم يتم الإلغاء تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void deleteJudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

            if (MessageBox.Show($"تحذير: سوف يتم حذف الحساب رقم ({RegulatorID}) و كل ما يتعلق به. هل ما زلت تريد حذف هذا الحساب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsRegulator.DeleteRegulatorPermanently(RegulatorID))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshRegulatorsPerPage();
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام.الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   
    }

}
