namespace User
{
    partial class frmShowUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowUsers));
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securityQuestionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerQuestionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeStatus = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(0, 538);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(799, 23);
            this.line1.TabIndex = 0;
            this.line1.Text = "line1";
            this.line1.Thickness = 2;
            // 
            // DGrid
            // 
            this.DGrid.AllowUserToAddRows = false;
            this.DGrid.AllowUserToDeleteRows = false;
            this.DGrid.AllowUserToResizeColumns = false;
            this.DGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGrid.AutoGenerateColumns = false;
            this.DGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Radif,
            this.dgName,
            this.emailDataGridViewTextBoxColumn,
            this.mobileDataGridViewTextBoxColumn,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.accessDataGridViewTextBoxColumn,
            this.securityQuestionDataGridViewTextBoxColumn,
            this.answerQuestionDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.UserBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(4, 70);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(795, 468);
            this.DGrid.TabIndex = 55707;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // Radif
            // 
            this.Radif.HeaderText = "ردیف";
            this.Radif.Name = "Radif";
            this.Radif.ReadOnly = true;
            this.Radif.Width = 50;
            // 
            // dgName
            // 
            this.dgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgName.DataPropertyName = "Name";
            this.dgName.HeaderText = "عنوان";
            this.dgName.Name = "dgName";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "ایمیل";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.Width = 200;
            // 
            // mobileDataGridViewTextBoxColumn
            // 
            this.mobileDataGridViewTextBoxColumn.DataPropertyName = "Mobile";
            this.mobileDataGridViewTextBoxColumn.HeaderText = "همراه";
            this.mobileDataGridViewTextBoxColumn.Name = "mobileDataGridViewTextBoxColumn";
            this.mobileDataGridViewTextBoxColumn.Width = 200;
            // 
            // dgGuid
            // 
            this.dgGuid.DataPropertyName = "Guid";
            this.dgGuid.HeaderText = "Guid";
            this.dgGuid.Name = "dgGuid";
            this.dgGuid.Visible = false;
            // 
            // modifiedDataGridViewTextBoxColumn
            // 
            this.modifiedDataGridViewTextBoxColumn.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn.Name = "modifiedDataGridViewTextBoxColumn";
            this.modifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            this.statusDataGridViewCheckBoxColumn.Visible = false;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.Visible = false;
            // 
            // accessDataGridViewTextBoxColumn
            // 
            this.accessDataGridViewTextBoxColumn.DataPropertyName = "Access";
            this.accessDataGridViewTextBoxColumn.HeaderText = "Access";
            this.accessDataGridViewTextBoxColumn.Name = "accessDataGridViewTextBoxColumn";
            this.accessDataGridViewTextBoxColumn.Visible = false;
            // 
            // securityQuestionDataGridViewTextBoxColumn
            // 
            this.securityQuestionDataGridViewTextBoxColumn.DataPropertyName = "SecurityQuestion";
            this.securityQuestionDataGridViewTextBoxColumn.HeaderText = "SecurityQuestion";
            this.securityQuestionDataGridViewTextBoxColumn.Name = "securityQuestionDataGridViewTextBoxColumn";
            this.securityQuestionDataGridViewTextBoxColumn.Visible = false;
            // 
            // answerQuestionDataGridViewTextBoxColumn
            // 
            this.answerQuestionDataGridViewTextBoxColumn.DataPropertyName = "AnswerQuestion";
            this.answerQuestionDataGridViewTextBoxColumn.HeaderText = "AnswerQuestion";
            this.answerQuestionDataGridViewTextBoxColumn.Name = "answerQuestionDataGridViewTextBoxColumn";
            this.answerQuestionDataGridViewTextBoxColumn.Visible = false;
            // 
            // UserBindingSource
            // 
            this.UserBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(46, 35);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(701, 27);
            this.txtSearch.TabIndex = 55708;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Image = global::User.Properties.Resources.article_1_;
            this.btnView.Location = new System.Drawing.Point(272, 559);
            this.btnView.Name = "btnView";
            this.btnView.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnView.Size = new System.Drawing.Size(125, 31);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnView.TabIndex = 55709;
            this.btnView.Text = "مشاهده (F12)";
            this.btnView.TextColor = System.Drawing.Color.Black;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = global::User.Properties.Resources.delete_1_;
            this.btnDelete.Location = new System.Drawing.Point(403, 559);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelete.Size = new System.Drawing.Size(125, 31);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelete.TabIndex = 55709;
            this.btnDelete.Text = "حذف (Del)";
            this.btnDelete.TextColor = System.Drawing.Color.Black;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChangeStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChangeStatus.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnChangeStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeStatus.Image = global::User.Properties.Resources.refresh_round_symbol;
            this.btnChangeStatus.Location = new System.Drawing.Point(141, 559);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnChangeStatus.Size = new System.Drawing.Size(125, 31);
            this.btnChangeStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnChangeStatus.TabIndex = 55709;
            this.btnChangeStatus.Text = "غیرفعال (Ctrl+S)";
            this.btnChangeStatus.TextColor = System.Drawing.Color.Black;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Image = global::User.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(10, 559);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnPrint.Size = new System.Drawing.Size(125, 31);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnPrint.TabIndex = 55709;
            this.btnPrint.Text = "گزارش (Ctrl+P)";
            this.btnPrint.TextColor = System.Drawing.Color.Black;
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Image = global::User.Properties.Resources.edit_1_;
            this.btnEdit.Location = new System.Drawing.Point(534, 559);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnEdit.Size = new System.Drawing.Size(125, 31);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnEdit.TabIndex = 55709;
            this.btnEdit.Text = "ویرایش (F7)";
            this.btnEdit.TextColor = System.Drawing.Color.Black;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Image = global::User.Properties.Resources.add_1_;
            this.btnInsert.Location = new System.Drawing.Point(665, 559);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnInsert.Size = new System.Drawing.Size(125, 31);
            this.btnInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnInsert.TabIndex = 55709;
            this.btnInsert.Text = "افزودن (Ins)";
            this.btnInsert.TextColor = System.Drawing.Color.Black;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // frmShowUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.DGrid);
            this.Controls.Add(this.line1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowUsers";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowUsers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowUsers_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnView;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnChangeStatus;
        private System.Windows.Forms.BindingSource UserBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn securityQuestionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerQuestionDataGridViewTextBoxColumn;
    }
}