namespace Peoples
{
    partial class frmShowPeoples
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPeoples));
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuGardesh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendSMS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTell = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBank = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIpmortFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.مدیریتستونهاToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNatName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFatherName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddress = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trvGroup = new System.Windows.Forms.TreeView();
            this.contextMenuGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInsGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucPagger = new WindowsSerivces.Pagging.UC_FooterPaging();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNatCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgFatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAccountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.idCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuedFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.peopleBindingSource)).BeginInit();
            this.contextMenuGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.txtSearch.Location = new System.Drawing.Point(44, 61);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(701, 27);
            this.txtSearch.TabIndex = 55753;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            this.dgRadif,
            this.dgCode,
            this.dgName,
            this.dgNatCode,
            this.dgFatherName,
            this.dgAccount,
            this.dgAccountType,
            this.dgAddress,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.idCodeDataGridViewTextBoxColumn,
            this.placeBirthDataGridViewTextBoxColumn,
            this.dateBirthDataGridViewTextBoxColumn,
            this.issuedFromDataGridViewTextBoxColumn,
            this.postalCodeDataGridViewTextBoxColumn,
            this.groupGuidDataGridViewTextBoxColumn});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            this.DGrid.DataSource = this.peopleBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(4, 95);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(654, 500);
            this.DGrid.TabIndex = 55752;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            this.DGrid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DGrid_Scroll);
            this.DGrid.DoubleClick += new System.EventHandler(this.DGrid_DoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDelete,
            this.toolStripMenuItem1,
            this.mnuView,
            this.toolStripMenuItem2,
            this.mnuGardesh,
            this.mnuSendSMS,
            this.toolStripMenuItem3,
            this.mnuTell,
            this.mnuBank,
            this.mnuPrint,
            this.mnuIpmortFromExcel,
            this.toolStripMenuItem4,
            this.مدیریتستونهاToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(237, 292);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::Peoples.Properties.Resources.add_2_;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(236, 24);
            this.mnuAdd.Text = "افزودن شخص جدید (Ins)";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Peoples.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(236, 24);
            this.mnuEdit.Text = "ویرایش شخص جاری (F7)";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Peoples.Properties.Resources.delete_1_;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(236, 24);
            this.mnuDelete.Text = "حذف شخص جاری (Del)";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(233, 6);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Peoples.Properties.Resources.article_1_;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(236, 24);
            this.mnuView.Text = "مشاهده (F12)";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(233, 6);
            // 
            // mnuGardesh
            // 
            this.mnuGardesh.Image = global::Peoples.Properties.Resources.article_1_;
            this.mnuGardesh.Name = "mnuGardesh";
            this.mnuGardesh.Size = new System.Drawing.Size(236, 24);
            this.mnuGardesh.Text = "مشاهده گردش حساب";
            this.mnuGardesh.Click += new System.EventHandler(this.mnuGardesh_Click);
            // 
            // mnuSendSMS
            // 
            this.mnuSendSMS.Image = global::Peoples.Properties.Resources.button_send_sms;
            this.mnuSendSMS.Name = "mnuSendSMS";
            this.mnuSendSMS.Size = new System.Drawing.Size(236, 24);
            this.mnuSendSMS.Text = "ارسال پیامک";
            this.mnuSendSMS.Click += new System.EventHandler(this.mnuSendSMS_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(233, 6);
            // 
            // mnuTell
            // 
            this.mnuTell.Image = global::Peoples.Properties.Resources.basic_information;
            this.mnuTell.Name = "mnuTell";
            this.mnuTell.Size = new System.Drawing.Size(236, 24);
            this.mnuTell.Text = "مشاهده اطلاعات تماس";
            this.mnuTell.Click += new System.EventHandler(this.mnuTell_Click);
            // 
            // mnuBank
            // 
            this.mnuBank.Image = global::Peoples.Properties.Resources.basic_information;
            this.mnuBank.Name = "mnuBank";
            this.mnuBank.Size = new System.Drawing.Size(236, 24);
            this.mnuBank.Text = "مشاهده اطلاعات حساب های بانکی";
            this.mnuBank.Click += new System.EventHandler(this.mnuBank_Click);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = global::Peoples.Properties.Resources.printer;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(236, 24);
            this.mnuPrint.Text = "چاپ لیست اشخاص";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            // 
            // mnuIpmortFromExcel
            // 
            this.mnuIpmortFromExcel.Image = global::Peoples.Properties.Resources.tab_checkbox__;
            this.mnuIpmortFromExcel.Name = "mnuIpmortFromExcel";
            this.mnuIpmortFromExcel.Size = new System.Drawing.Size(236, 24);
            this.mnuIpmortFromExcel.Text = "دریافت داده از فایل اکسل";
            this.mnuIpmortFromExcel.Click += new System.EventHandler(this.mnuIpmortFromExcel_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(233, 6);
            // 
            // مدیریتستونهاToolStripMenuItem
            // 
            this.مدیریتستونهاToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCode,
            this.mnuName,
            this.mnuNatName,
            this.mnuFatherName,
            this.mnuAccount,
            this.mnuAddress});
            this.مدیریتستونهاToolStripMenuItem.Name = "مدیریتستونهاToolStripMenuItem";
            this.مدیریتستونهاToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.مدیریتستونهاToolStripMenuItem.Text = "مدیریت ستون ها";
            // 
            // mnuCode
            // 
            this.mnuCode.CheckOnClick = true;
            this.mnuCode.Name = "mnuCode";
            this.mnuCode.Size = new System.Drawing.Size(135, 24);
            this.mnuCode.Text = "کد شخص";
            this.mnuCode.CheckedChanged += new System.EventHandler(this.mnuCode_CheckedChanged);
            // 
            // mnuName
            // 
            this.mnuName.CheckOnClick = true;
            this.mnuName.Name = "mnuName";
            this.mnuName.Size = new System.Drawing.Size(135, 24);
            this.mnuName.Text = "عنوان";
            this.mnuName.CheckedChanged += new System.EventHandler(this.mnuName_CheckedChanged);
            // 
            // mnuNatName
            // 
            this.mnuNatName.CheckOnClick = true;
            this.mnuNatName.Name = "mnuNatName";
            this.mnuNatName.Size = new System.Drawing.Size(135, 24);
            this.mnuNatName.Text = "کد ملی";
            this.mnuNatName.CheckedChanged += new System.EventHandler(this.mnuNatName_CheckedChanged);
            // 
            // mnuFatherName
            // 
            this.mnuFatherName.CheckOnClick = true;
            this.mnuFatherName.Name = "mnuFatherName";
            this.mnuFatherName.Size = new System.Drawing.Size(135, 24);
            this.mnuFatherName.Text = "نام پدر";
            this.mnuFatherName.CheckedChanged += new System.EventHandler(this.mnuFatherName_CheckedChanged);
            // 
            // mnuAccount
            // 
            this.mnuAccount.CheckOnClick = true;
            this.mnuAccount.Name = "mnuAccount";
            this.mnuAccount.Size = new System.Drawing.Size(135, 24);
            this.mnuAccount.Text = "مانده حساب";
            this.mnuAccount.CheckedChanged += new System.EventHandler(this.mnuAccount_CheckedChanged);
            // 
            // mnuAddress
            // 
            this.mnuAddress.CheckOnClick = true;
            this.mnuAddress.Name = "mnuAddress";
            this.mnuAddress.Size = new System.Drawing.Size(135, 24);
            this.mnuAddress.Text = "آدرس";
            this.mnuAddress.CheckedChanged += new System.EventHandler(this.mnuAddress_CheckedChanged);
            // 
            // peopleBindingSource
            // 
            this.peopleBindingSource.DataSource = typeof(EntityCache.Bussines.PeoplesBussines);
            // 
            // trvGroup
            // 
            this.trvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvGroup.BackColor = System.Drawing.Color.White;
            this.trvGroup.ContextMenuStrip = this.contextMenuGroup;
            this.trvGroup.ForeColor = System.Drawing.Color.Black;
            this.trvGroup.Location = new System.Drawing.Point(660, 95);
            this.trvGroup.Name = "trvGroup";
            this.trvGroup.RightToLeftLayout = true;
            this.trvGroup.Size = new System.Drawing.Size(135, 500);
            this.trvGroup.TabIndex = 55759;
            this.trvGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvGroup_AfterSelect);
            // 
            // contextMenuGroup
            // 
            this.contextMenuGroup.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenuGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsGroup,
            this.mnuUpGroup,
            this.mnuDelGroup});
            this.contextMenuGroup.Name = "contextMenu";
            this.contextMenuGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuGroup.Size = new System.Drawing.Size(173, 76);
            // 
            // mnuInsGroup
            // 
            this.mnuInsGroup.Image = global::Peoples.Properties.Resources.add_2_;
            this.mnuInsGroup.Name = "mnuInsGroup";
            this.mnuInsGroup.Size = new System.Drawing.Size(172, 24);
            this.mnuInsGroup.Text = "افزودن گروه جدید ";
            this.mnuInsGroup.Click += new System.EventHandler(this.mnuInsGroup_Click);
            // 
            // mnuUpGroup
            // 
            this.mnuUpGroup.Image = global::Peoples.Properties.Resources.edit_1_;
            this.mnuUpGroup.Name = "mnuUpGroup";
            this.mnuUpGroup.Size = new System.Drawing.Size(172, 24);
            this.mnuUpGroup.Text = "ویرایش گروه جاری ";
            this.mnuUpGroup.Click += new System.EventHandler(this.mnuUpGroup_Click);
            // 
            // mnuDelGroup
            // 
            this.mnuDelGroup.Image = global::Peoples.Properties.Resources.delete_1_;
            this.mnuDelGroup.Name = "mnuDelGroup";
            this.mnuDelGroup.Size = new System.Drawing.Size(172, 24);
            this.mnuDelGroup.Text = "حذف گروه جاری ";
            this.mnuDelGroup.Click += new System.EventHandler(this.mnuDelGroup_Click);
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(EntityCache.Bussines.PeopleGroupBussines);
            // 
            // ucPagger
            // 
            this.ucPagger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPagger.BackColor = System.Drawing.Color.Transparent;
            this.ucPagger.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucPagger.Location = new System.Drawing.Point(4, 563);
            this.ucPagger.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPagger.Name = "ucPagger";
            this.ucPagger.PageIdx = 1;
            this.ucPagger.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucPagger.Size = new System.Drawing.Size(765, 32);
            this.ucPagger.TabIndex = 55760;
            // 
            // ucHeader
            // 
            this.ucHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ucHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucHeader.BackColor = System.Drawing.Color.White;
            this.ucHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ucHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucHeader.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucHeader.IsModified = false;
            this.ucHeader.Location = new System.Drawing.Point(-5, 25);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55761;
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 50;
            // 
            // dgCode
            // 
            this.dgCode.DataPropertyName = "Code";
            this.dgCode.HeaderText = "کد";
            this.dgCode.Name = "dgCode";
            this.dgCode.ReadOnly = true;
            this.dgCode.Width = 80;
            // 
            // dgName
            // 
            this.dgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgName.DataPropertyName = "Name";
            this.dgName.HeaderText = "عنوان";
            this.dgName.MinimumWidth = 150;
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            // 
            // dgNatCode
            // 
            this.dgNatCode.DataPropertyName = "NationalCode";
            this.dgNatCode.HeaderText = "کدملی";
            this.dgNatCode.Name = "dgNatCode";
            this.dgNatCode.ReadOnly = true;
            this.dgNatCode.Visible = false;
            // 
            // dgFatherName
            // 
            this.dgFatherName.DataPropertyName = "FatherName";
            this.dgFatherName.HeaderText = "نام پدر";
            this.dgFatherName.Name = "dgFatherName";
            this.dgFatherName.ReadOnly = true;
            this.dgFatherName.Visible = false;
            this.dgFatherName.Width = 150;
            // 
            // dgAccount
            // 
            this.dgAccount.DataPropertyName = "Account_";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dgAccount.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgAccount.HeaderText = "مانده حساب";
            this.dgAccount.Name = "dgAccount";
            this.dgAccount.ReadOnly = true;
            this.dgAccount.Visible = false;
            this.dgAccount.Width = 150;
            // 
            // dgAccountType
            // 
            this.dgAccountType.DataPropertyName = "AccountType";
            this.dgAccountType.HeaderText = "تشخیص";
            this.dgAccountType.Name = "dgAccountType";
            this.dgAccountType.ReadOnly = true;
            this.dgAccountType.Visible = false;
            // 
            // dgAddress
            // 
            this.dgAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgAddress.DataPropertyName = "Address";
            this.dgAddress.HeaderText = "آدرس";
            this.dgAddress.MinimumWidth = 100;
            this.dgAddress.Name = "dgAddress";
            this.dgAddress.ReadOnly = true;
            this.dgAddress.Visible = false;
            // 
            // dgGuid
            // 
            this.dgGuid.DataPropertyName = "Guid";
            this.dgGuid.HeaderText = "Guid";
            this.dgGuid.Name = "dgGuid";
            this.dgGuid.ReadOnly = true;
            this.dgGuid.Visible = false;
            // 
            // modifiedDataGridViewTextBoxColumn
            // 
            this.modifiedDataGridViewTextBoxColumn.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn.Name = "modifiedDataGridViewTextBoxColumn";
            this.modifiedDataGridViewTextBoxColumn.ReadOnly = true;
            this.modifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            this.statusDataGridViewCheckBoxColumn.ReadOnly = true;
            this.statusDataGridViewCheckBoxColumn.Visible = false;
            // 
            // idCodeDataGridViewTextBoxColumn
            // 
            this.idCodeDataGridViewTextBoxColumn.DataPropertyName = "IdCode";
            this.idCodeDataGridViewTextBoxColumn.HeaderText = "IdCode";
            this.idCodeDataGridViewTextBoxColumn.Name = "idCodeDataGridViewTextBoxColumn";
            this.idCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // placeBirthDataGridViewTextBoxColumn
            // 
            this.placeBirthDataGridViewTextBoxColumn.DataPropertyName = "PlaceBirth";
            this.placeBirthDataGridViewTextBoxColumn.HeaderText = "PlaceBirth";
            this.placeBirthDataGridViewTextBoxColumn.Name = "placeBirthDataGridViewTextBoxColumn";
            this.placeBirthDataGridViewTextBoxColumn.ReadOnly = true;
            this.placeBirthDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateBirthDataGridViewTextBoxColumn
            // 
            this.dateBirthDataGridViewTextBoxColumn.DataPropertyName = "DateBirth";
            this.dateBirthDataGridViewTextBoxColumn.HeaderText = "DateBirth";
            this.dateBirthDataGridViewTextBoxColumn.Name = "dateBirthDataGridViewTextBoxColumn";
            this.dateBirthDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateBirthDataGridViewTextBoxColumn.Visible = false;
            // 
            // issuedFromDataGridViewTextBoxColumn
            // 
            this.issuedFromDataGridViewTextBoxColumn.DataPropertyName = "IssuedFrom";
            this.issuedFromDataGridViewTextBoxColumn.HeaderText = "IssuedFrom";
            this.issuedFromDataGridViewTextBoxColumn.Name = "issuedFromDataGridViewTextBoxColumn";
            this.issuedFromDataGridViewTextBoxColumn.ReadOnly = true;
            this.issuedFromDataGridViewTextBoxColumn.Visible = false;
            // 
            // postalCodeDataGridViewTextBoxColumn
            // 
            this.postalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode";
            this.postalCodeDataGridViewTextBoxColumn.HeaderText = "PostalCode";
            this.postalCodeDataGridViewTextBoxColumn.Name = "postalCodeDataGridViewTextBoxColumn";
            this.postalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.postalCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // groupGuidDataGridViewTextBoxColumn
            // 
            this.groupGuidDataGridViewTextBoxColumn.DataPropertyName = "GroupGuid";
            this.groupGuidDataGridViewTextBoxColumn.HeaderText = "GroupGuid";
            this.groupGuidDataGridViewTextBoxColumn.Name = "groupGuidDataGridViewTextBoxColumn";
            this.groupGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmShowPeoples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.trvGroup);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.DGrid);
            this.Controls.Add(this.ucPagger);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowPeoples";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowPeoples_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowPeoples_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.peopleBindingSource)).EndInit();
            this.contextMenuGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.BindingSource peopleBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.TreeView trvGroup;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenuGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuInsGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuUpGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuDelGroup;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuTell;
        private System.Windows.Forms.ToolStripMenuItem mnuBank;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuGardesh;
        private System.Windows.Forms.ToolStripMenuItem mnuSendSMS;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuIpmortFromExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem مدیریتستونهاToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCode;
        private System.Windows.Forms.ToolStripMenuItem mnuName;
        private System.Windows.Forms.ToolStripMenuItem mnuNatName;
        private System.Windows.Forms.ToolStripMenuItem mnuFatherName;
        private System.Windows.Forms.ToolStripMenuItem mnuAccount;
        private System.Windows.Forms.ToolStripMenuItem mnuAddress;
        private WindowsSerivces.Pagging.UC_FooterPaging ucPagger;
        private WindowsSerivces.UC_Header ucHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNatCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgFatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAccountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuedFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupGuidDataGridViewTextBoxColumn;
    }
}