namespace RealState.Note
{
    partial class frmShowNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowNotes));
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.noteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.noteStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSarresidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSabtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblUsers = new System.Windows.Forms.Label();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSarresidShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSabtShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Radif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeStatus = new DevComponents.DotNetBar.ButtonX();
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUsers
            // 
            this.cmbUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUsers.DataSource = this.userBindingSource;
            this.cmbUsers.DisplayMember = "Name";
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(3, 22);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(133, 28);
            this.cmbUsers.TabIndex = 55725;
            this.cmbUsers.ValueMember = "Guid";
            this.cmbUsers.SelectedIndexChanged += new System.EventHandler(this.cmbUsers_SelectedIndexChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(430, 22);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(133, 28);
            this.cmbStatus.TabIndex = 55722;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(565, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 55720;
            this.label1.Text = "وضعیت";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriority.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(615, 22);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(133, 28);
            this.cmbPriority.TabIndex = 55723;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(750, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 55721;
            this.label5.Text = "اولویت";
            // 
            // noteBindingSource
            // 
            this.noteBindingSource.DataSource = typeof(EntityCache.Bussines.NoteBussines);
            // 
            // noteStatusDataGridViewTextBoxColumn
            // 
            this.noteStatusDataGridViewTextBoxColumn.DataPropertyName = "NoteStatus";
            this.noteStatusDataGridViewTextBoxColumn.HeaderText = "NoteStatus";
            this.noteStatusDataGridViewTextBoxColumn.Name = "noteStatusDataGridViewTextBoxColumn";
            this.noteStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "Priority";
            this.priorityDataGridViewTextBoxColumn.HeaderText = "Priority";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            this.priorityDataGridViewTextBoxColumn.ReadOnly = true;
            this.priorityDataGridViewTextBoxColumn.Visible = false;
            // 
            // userGuidDataGridViewTextBoxColumn
            // 
            this.userGuidDataGridViewTextBoxColumn.DataPropertyName = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.HeaderText = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.Name = "userGuidDataGridViewTextBoxColumn";
            this.userGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.userGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateSarresidDataGridViewTextBoxColumn
            // 
            this.dateSarresidDataGridViewTextBoxColumn.DataPropertyName = "DateSarresid";
            this.dateSarresidDataGridViewTextBoxColumn.HeaderText = "DateSarresid";
            this.dateSarresidDataGridViewTextBoxColumn.Name = "dateSarresidDataGridViewTextBoxColumn";
            this.dateSarresidDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateSarresidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateSabtDataGridViewTextBoxColumn
            // 
            this.dateSabtDataGridViewTextBoxColumn.DataPropertyName = "DateSabt";
            this.dateSabtDataGridViewTextBoxColumn.HeaderText = "DateSabt";
            this.dateSabtDataGridViewTextBoxColumn.Name = "dateSabtDataGridViewTextBoxColumn";
            this.dateSabtDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateSabtDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            this.statusDataGridViewCheckBoxColumn.ReadOnly = true;
            this.statusDataGridViewCheckBoxColumn.Visible = false;
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblUsers.Location = new System.Drawing.Point(138, 25);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(33, 20);
            this.lblUsers.TabIndex = 55724;
            this.lblUsers.Text = "کاربر";
            // 
            // modifiedDataGridViewTextBoxColumn
            // 
            this.modifiedDataGridViewTextBoxColumn.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn.Name = "modifiedDataGridViewTextBoxColumn";
            this.modifiedDataGridViewTextBoxColumn.ReadOnly = true;
            this.modifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // dgUserName
            // 
            this.dgUserName.DataPropertyName = "UserName";
            this.dgUserName.HeaderText = "کاربر";
            this.dgUserName.Name = "dgUserName";
            this.dgUserName.ReadOnly = true;
            // 
            // dateSarresidShDataGridViewTextBoxColumn
            // 
            this.dateSarresidShDataGridViewTextBoxColumn.DataPropertyName = "DateSarresidSh";
            this.dateSarresidShDataGridViewTextBoxColumn.HeaderText = "سررسید";
            this.dateSarresidShDataGridViewTextBoxColumn.Name = "dateSarresidShDataGridViewTextBoxColumn";
            this.dateSarresidShDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "وضعیت";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priorityNameDataGridViewTextBoxColumn
            // 
            this.priorityNameDataGridViewTextBoxColumn.DataPropertyName = "PriorityName";
            this.priorityNameDataGridViewTextBoxColumn.HeaderText = "اولویت";
            this.priorityNameDataGridViewTextBoxColumn.Name = "priorityNameDataGridViewTextBoxColumn";
            this.priorityNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "عنوان";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateSabtShDataGridViewTextBoxColumn
            // 
            this.dateSabtShDataGridViewTextBoxColumn.DataPropertyName = "DateSabtSh";
            this.dateSabtShDataGridViewTextBoxColumn.HeaderText = "تاریخ ثبت";
            this.dateSabtShDataGridViewTextBoxColumn.Name = "dateSabtShDataGridViewTextBoxColumn";
            this.dateSabtShDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Radif
            // 
            this.Radif.HeaderText = "ردیف";
            this.Radif.Name = "Radif";
            this.Radif.ReadOnly = true;
            this.Radif.Width = 50;
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
            this.dateSabtShDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.priorityNameDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.dateSarresidShDataGridViewTextBoxColumn,
            this.dgUserName,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dateSabtDataGridViewTextBoxColumn,
            this.dateSarresidDataGridViewTextBoxColumn,
            this.userGuidDataGridViewTextBoxColumn,
            this.priorityDataGridViewTextBoxColumn,
            this.noteStatusDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.noteBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(3, 54);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
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
            this.DGrid.Size = new System.Drawing.Size(795, 482);
            this.DGrid.TabIndex = 55718;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // dgGuid
            // 
            this.dgGuid.DataPropertyName = "Guid";
            this.dgGuid.HeaderText = "Guid";
            this.dgGuid.Name = "dgGuid";
            this.dgGuid.ReadOnly = true;
            this.dgGuid.Visible = false;
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
            this.txtSearch.Location = new System.Drawing.Point(177, 23);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(245, 27);
            this.txtSearch.TabIndex = 55719;
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
            this.btnView.Image = global::RealState.Properties.Resources.article_1_;
            this.btnView.Location = new System.Drawing.Point(273, 564);
            this.btnView.Name = "btnView";
            this.btnView.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnView.Size = new System.Drawing.Size(125, 31);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnView.TabIndex = 55727;
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
            this.btnDelete.Image = global::RealState.Properties.Resources.delete_1_;
            this.btnDelete.Location = new System.Drawing.Point(404, 564);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelete.Size = new System.Drawing.Size(125, 31);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelete.TabIndex = 55728;
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
            this.btnChangeStatus.Location = new System.Drawing.Point(142, 564);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnChangeStatus.Size = new System.Drawing.Size(125, 31);
            this.btnChangeStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnChangeStatus.TabIndex = 55729;
            this.btnChangeStatus.Text = "تبدیل به خوانده شده";
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
            this.btnPrint.Location = new System.Drawing.Point(11, 564);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnPrint.Size = new System.Drawing.Size(125, 31);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnPrint.TabIndex = 55730;
            this.btnPrint.Text = "تبدیل به خوانده نشده";
            this.btnPrint.TextColor = System.Drawing.Color.Black;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Image = global::RealState.Properties.Resources.edit_1_;
            this.btnEdit.Location = new System.Drawing.Point(535, 564);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnEdit.Size = new System.Drawing.Size(125, 31);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnEdit.TabIndex = 55731;
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
            this.btnInsert.Image = global::RealState.Properties.Resources.add_1_;
            this.btnInsert.Location = new System.Drawing.Point(666, 564);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnInsert.Size = new System.Drawing.Size(125, 31);
            this.btnInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnInsert.TabIndex = 55732;
            this.btnInsert.Text = "افزودن (Ins)";
            this.btnInsert.TextColor = System.Drawing.Color.Black;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(1, 543);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(799, 23);
            this.line1.TabIndex = 55726;
            this.line1.Text = "line1";
            this.line1.Thickness = 2;
            // 
            // frmShowNotes
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
            this.Controls.Add(this.line1);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.DGrid);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowNotes";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowNotes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowNotes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource noteBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSarresidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSabtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSarresidShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSabtShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Radif;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.ButtonX btnView;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnChangeStatus;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private DevComponents.DotNetBar.Controls.Line line1;
    }
}