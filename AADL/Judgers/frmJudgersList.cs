using AADLBusiness.Judger;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace AADL.Judgers
{
    public partial class frmJudgersList : Form
    {
        private enum enMode { add, update, delete }
        private enMode _mode = enMode.add;
        private ushort _pageNumber = 0;
        private DataTable _dtJudgers;

        public frmJudgersList()
        {
            InitializeComponent();
        }

        private void _FillDataGridView(DataTable dtJudgers)
        {
            if (dtJudgers != null)
            {
                dgvJudgers.DataSource = dtJudgers;

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvJudgers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Change the columns name

                dgvJudgers.Columns["JudgerID"].HeaderText = "الرقم التعريفي كمحكم";
                dgvJudgers.Columns["PractitionerID"].HeaderText = "الرقم التعريفي كمزوال";
                dgvJudgers.Columns["FullName"].HeaderText = "الاسم رباعي";
                dgvJudgers.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgvJudgers.Columns["Gender"].HeaderText = "النوع";
                dgvJudgers.Columns["CountryName"].HeaderText = "الدولة";
                dgvJudgers.Columns["CityName"].HeaderText = "المدينة";
                dgvJudgers.Columns["Address"].HeaderText = "العنوان";
                dgvJudgers.Columns["IsLawyer"].HeaderText = "هل محامي ؟";


                lblTotalRecordsCount.Text = dtJudgers.Rows.Count.ToString();
            }
        }

        private void _LoadRefreshJudgersPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            if (_mode == enMode.add || _mode == enMode.delete)
                _HandleNumberOfPages();

            // load Judgers data per page and save them in the DataTable "_dtJudgers"
            // in case the page number is equal to zero assign null to the DataTable "_dtJudgers"
            _dtJudgers = _pageNumber > 0 ? clsJudger.GetJudgersPerPage(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtJudgers);
        }

        private void _HandleNumberOfPages()
        {
            uint totalJudgersCount = (uint)clsJudger.Count();

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
                case "الرقم التعريفي كمحكم":
                    filterColumn = "JudgerID";
                    break;
                case "الرقم التعريفي كمزوال":
                    filterColumn = "PractitionerID";
                    break;
                case "الاسم":
                    filterColumn = "FullName";
                    break;
                case "رقم الهاتف":
                    filterColumn = "Phone";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtJudgers.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "JudgerID" || filterColumn == "PractitionerID")
                    //in this case we deal with integer not string.
                    _dtJudgers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtJudgers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvJudgers.Rows.Count.ToString();
        }

        private void btnAddJudger_Click(object sender, EventArgs e)
        {

        }

        private void frmJudgersList_Load(object sender, EventArgs e)
        {
            // Cusomize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvJudgers);

            _LoadRefreshJudgersPerPage();

            cbFilterBy.SelectedItem = "لا شيء";
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شيء");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtJudgers != null)
            {
                _dtJudgers.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvJudgers.Rows.Count.ToString();
            }
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Judgers data from the database and view it in the DataGridView
            _dtJudgers = clsJudger.GetJudgersPerPage(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtJudgers);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم التعريفي كمحكم" || cbFilterBy.Text == "الرقم التعريفي كمزاول")
                clsUtil.IsNumber(e);
        }

        // This function will supress the ContextMenuStrip from being shown incase the DataGridView is empty
        private void dgvJudgers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvJudgers.Rows.Count == 0 || dgvJudgers.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvJudgers.CurrentCell = dgvJudgers[e.ColumnIndex, e.RowIndex];
                    cmsJudgers.Show(Cursor.Position);
                }
            }
        }

        private void deactivateJudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد الغاء تفعيل الحساب رقم {judgerID} ؟", "تاكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsJudger.DeleteJudgerSoftlyByJudgerID(judgerID))
                {
                    MessageBox.Show($"تم الإلغاء تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshJudgersPerPage();
                }
                else
                    MessageBox.Show($"لم يتم الإلغاء تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteJudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            if (MessageBox.Show($"تحذير: سوف يتم حذف الحساب رقم ({judgerID}) و كل ما يتعلق به. هل ما زلت تريد حذف هذا الحساب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsJudger.DeleteJudgerPermanently(judgerID))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshJudgersPerPage();
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            frmJudgerCard frm = new frmJudgerCard(judgerID, Judgers.Controls.ctrJudgerCard.enWhichID.JudgerID);
            frm.ShowDialog();
        }

        private void dgvJudgers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            frmJudgerCard frm = new frmJudgerCard(judgerID, Judgers.Controls.ctrJudgerCard.enWhichID.JudgerID);
            frm.ShowDialog();
        }
    }
}
