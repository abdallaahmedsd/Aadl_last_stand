﻿namespace AADL.Regulators
{
    partial class frmRegulatorList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.cbPage = new System.Windows.Forms.ComboBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRegulators = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalRecordsCount = new System.Windows.Forms.Label();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRegulators = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activateRegulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deactivateRegulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteJudgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegulators)).BeginInit();
            this.cmsRegulators.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(-5, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1125, 42);
            this.label1.TabIndex = 144;
            this.label1.Text = "إدارة النظامين";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AADL.Properties.Resources.judge_512;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(469, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 143;
            this.pictureBox1.TabStop = false;
            // 
            // cbIsActive
            // 
            this.cbIsActive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "الكل",
            "نعم",
            "لا"});
            this.cbIsActive.Location = new System.Drawing.Point(331, 241);
            this.cbIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIsActive.Size = new System.Drawing.Size(98, 24);
            this.cbIsActive.TabIndex = 150;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFilterValue.Location = new System.Drawing.Point(331, 242);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilterValue.Multiline = true;
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFilterValue.Size = new System.Drawing.Size(214, 23);
            this.txtFilterValue.TabIndex = 146;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // cbPage
            // 
            this.cbPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbPage.FormattingEnabled = true;
            this.cbPage.Location = new System.Drawing.Point(691, 241);
            this.cbPage.Margin = new System.Windows.Forms.Padding(2);
            this.cbPage.Name = "cbPage";
            this.cbPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPage.Size = new System.Drawing.Size(98, 24);
            this.cbPage.TabIndex = 147;
            this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "لا شيء",
            "الرقم التعريفي",
            "الاسم",
            "رقم الهاتف",
            "البريد الالكتروني",
            "هل فعال ؟"});
            this.cbFilterBy.Location = new System.Drawing.Point(144, 241);
            this.cbFilterBy.Margin = new System.Windows.Forms.Padding(2);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbFilterBy.Size = new System.Drawing.Size(174, 24);
            this.cbFilterBy.TabIndex = 145;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(624, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 149;
            this.label3.Text = "الصفحة:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(38, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 148;
            this.label5.Text = "البحث بواسطة:";
            // 
            // dgvRegulators
            // 
            this.dgvRegulators.AllowUserToAddRows = false;
            this.dgvRegulators.AllowUserToDeleteRows = false;
            this.dgvRegulators.AllowUserToOrderColumns = true;
            this.dgvRegulators.AllowUserToResizeRows = false;
            this.dgvRegulators.BackgroundColor = System.Drawing.Color.White;
            this.dgvRegulators.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRegulators.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRegulators.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRegulators.ColumnHeadersHeight = 40;
            this.dgvRegulators.GridColor = System.Drawing.Color.DarkGray;
            this.dgvRegulators.Location = new System.Drawing.Point(32, 276);
            this.dgvRegulators.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRegulators.Name = "dgvRegulators";
            this.dgvRegulators.ReadOnly = true;
            this.dgvRegulators.RowHeadersWidth = 51;
            this.dgvRegulators.RowTemplate.Height = 25;
            this.dgvRegulators.Size = new System.Drawing.Size(1078, 363);
            this.dgvRegulators.StandardTab = true;
            this.dgvRegulators.TabIndex = 151;
            this.dgvRegulators.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegulators_CellDoubleClick);
            this.dgvRegulators.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegulators_CellMouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(38, 651);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 152;
            this.label2.Text = "# السجلات:";
            // 
            // lblTotalRecordsCount
            // 
            this.lblTotalRecordsCount.AutoSize = true;
            this.lblTotalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecordsCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTotalRecordsCount.Location = new System.Drawing.Point(140, 651);
            this.lblTotalRecordsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
            this.lblTotalRecordsCount.Size = new System.Drawing.Size(19, 20);
            this.lblTotalRecordsCount.TabIndex = 153;
            this.lblTotalRecordsCount.Text = "0";
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showInfoToolStripMenuItem.Image = global::AADL.Properties.Resources.show_info_32;
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.showInfoToolStripMenuItem.Text = "عرض المعلومات";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.showInfoToolStripMenuItem_Click);
            // 
            // cmsRegulators
            // 
            this.cmsRegulators.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsRegulators.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsRegulators.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.activateRegulatorToolStripMenuItem,
            this.deactivateRegulatorToolStripMenuItem,
            this.deleteJudgerToolStripMenuItem});
            this.cmsRegulators.Name = "cmsRegulators";
            this.cmsRegulators.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsRegulators.Size = new System.Drawing.Size(185, 108);
            this.cmsRegulators.Opening += new System.ComponentModel.CancelEventHandler(this.cmsRegulator_Opening);
            // 
            // activateRegulatorToolStripMenuItem
            // 
            this.activateRegulatorToolStripMenuItem.Image = global::AADL.Properties.Resources.activate_32_abdalla;
            this.activateRegulatorToolStripMenuItem.Name = "activateRegulatorToolStripMenuItem";
            this.activateRegulatorToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.activateRegulatorToolStripMenuItem.Text = "تفعيل الحساب";
            this.activateRegulatorToolStripMenuItem.Click += new System.EventHandler(this.activateRegulatorToolStripMenuItem_Click);
            // 
            // deactivateRegulatorToolStripMenuItem
            // 
            this.deactivateRegulatorToolStripMenuItem.Image = global::AADL.Properties.Resources.deactivate_32;
            this.deactivateRegulatorToolStripMenuItem.Name = "deactivateRegulatorToolStripMenuItem";
            this.deactivateRegulatorToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.deactivateRegulatorToolStripMenuItem.Text = "إلغاء تفعيل الحساب";
            this.deactivateRegulatorToolStripMenuItem.Click += new System.EventHandler(this.deactivateRegulatorToolStripMenuItem_Click);
            // 
            // deleteJudgerToolStripMenuItem
            // 
            this.deleteJudgerToolStripMenuItem.Image = global::AADL.Properties.Resources.delete_32;
            this.deleteJudgerToolStripMenuItem.Name = "deleteJudgerToolStripMenuItem";
            this.deleteJudgerToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.deleteJudgerToolStripMenuItem.Text = "حذف الحساب نهائيا";
            this.deleteJudgerToolStripMenuItem.Click += new System.EventHandler(this.deleteJudgerToolStripMenuItem_Click);
            // 
            // frmRegulatorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 690);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalRecordsCount);
            this.Controls.Add(this.dgvRegulators);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.cbPage);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmRegulatorList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.Text = "نافذة النظامين";
            this.Load += new System.EventHandler(this.frmRegulatorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegulators)).EndInit();
            this.cmsRegulators.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.ComboBox cbPage;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvRegulators;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalRecordsCount;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsRegulators;
        private System.Windows.Forms.ToolStripMenuItem activateRegulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deactivateRegulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteJudgerToolStripMenuItem;
    }
}