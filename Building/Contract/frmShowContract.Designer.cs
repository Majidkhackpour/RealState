namespace Building.Contract
{
    partial class frmShowContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowContract));
            this.btnOther = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeTemp = new DevComponents.DotNetBar.ButtonItem();
            this.btnShowStandard = new DevComponents.DotNetBar.ButtonItem();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeStatus = new DevComponents.DotNetBar.ButtonX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isTempDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.secondSideGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstSideGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minorPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sarResidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dischargeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setDocDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setDocPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sarQofliDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOther
            // 
            this.btnOther.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOther.BackColor = System.Drawing.Color.Silver;
            this.btnOther.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOther.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOther.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOther.Location = new System.Drawing.Point(4, 559);
            this.btnOther.Name = "btnOther";
            this.btnOther.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOther.Size = new System.Drawing.Size(61, 31);
            this.btnOther.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOther.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnChangeTemp,
            this.btnShowStandard});
            this.btnOther.TabIndex = 55776;
            this.btnOther.Text = "سایر";
            this.btnOther.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOther.TextColor = System.Drawing.Color.Black;
            // 
            // btnChangeTemp
            // 
            this.btnChangeTemp.Name = "btnChangeTemp";
            this.btnChangeTemp.Text = "نهایی کردن و بستن قرارداد";
            this.btnChangeTemp.Click += new System.EventHandler(this.btnChangeTemp_Click);
            // 
            // btnShowStandard
            // 
            this.btnShowStandard.Name = "btnShowStandard";
            this.btnShowStandard.Text = "مشاهده قرارداد در قالب استاندارد";
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Image = global::Building.Properties.Resources.article_1_;
            this.btnView.Location = new System.Drawing.Point(202, 559);
            this.btnView.Name = "btnView";
            this.btnView.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnView.Size = new System.Drawing.Size(125, 31);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnView.TabIndex = 55771;
            this.btnView.Text = "مشاهده (F12)";
            this.btnView.TextColor = System.Drawing.Color.Black;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChangeStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChangeStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChangeStatus.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnChangeStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeStatus.Image = global::Building.Properties.Resources.refresh_round_symbol;
            this.btnChangeStatus.Location = new System.Drawing.Point(71, 559);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnChangeStatus.Size = new System.Drawing.Size(125, 31);
            this.btnChangeStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnChangeStatus.TabIndex = 55773;
            this.btnChangeStatus.Text = "غیرفعال (Ctrl+S)";
            this.btnChangeStatus.TextColor = System.Drawing.Color.Black;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
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
            this.txtSearch.TabIndex = 55770;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = global::Building.Properties.Resources.delete_1_;
            this.btnDelete.Location = new System.Drawing.Point(333, 559);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelete.Size = new System.Drawing.Size(125, 31);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelete.TabIndex = 55772;
            this.btnDelete.Text = "حذف (Del)";
            this.btnDelete.TextColor = System.Drawing.Color.Black;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInsert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInsert.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Image = global::Building.Properties.Resources.add_1_;
            this.btnInsert.Location = new System.Drawing.Point(595, 559);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnInsert.Size = new System.Drawing.Size(125, 31);
            this.btnInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnInsert.TabIndex = 55774;
            this.btnInsert.Text = "افزودن (Ins)";
            this.btnInsert.TextColor = System.Drawing.Color.Black;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Image = global::Building.Properties.Resources.edit_1_;
            this.btnEdit.Location = new System.Drawing.Point(464, 559);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnEdit.Size = new System.Drawing.Size(125, 31);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnEdit.TabIndex = 55775;
            this.btnEdit.Text = "ویرایش (F7)";
            this.btnEdit.TextColor = System.Drawing.Color.Black;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(0, 538);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(799, 23);
            this.line1.TabIndex = 55768;
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
            this.dgRadif,
            this.DateSh,
            this.dgCode,
            this.fNameDataGridViewTextBoxColumn,
            this.sNameDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.isTempDataGridViewCheckBoxColumn,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.secondSideGuidDataGridViewTextBoxColumn,
            this.firstSideGuidDataGridViewTextBoxColumn,
            this.userGuidDataGridViewTextBoxColumn,
            this.termDataGridViewTextBoxColumn,
            this.fromDateDataGridViewTextBoxColumn,
            this.totalPriceDataGridViewTextBoxColumn,
            this.minorPriceDataGridViewTextBoxColumn,
            this.checkNoDataGridViewTextBoxColumn,
            this.bankNameDataGridViewTextBoxColumn,
            this.shobeDataGridViewTextBoxColumn,
            this.sarResidDataGridViewTextBoxColumn,
            this.dischargeDateDataGridViewTextBoxColumn,
            this.setDocDateDataGridViewTextBoxColumn,
            this.setDocPlaceDataGridViewTextBoxColumn,
            this.sarQofliDataGridViewTextBoxColumn,
            this.delayDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.conBindingSource;
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
            this.DGrid.Size = new System.Drawing.Size(795, 468);
            this.DGrid.TabIndex = 55769;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 50;
            // 
            // DateSh
            // 
            this.DateSh.DataPropertyName = "DateSh";
            this.DateSh.HeaderText = "تاریخ ثبت";
            this.DateSh.Name = "DateSh";
            this.DateSh.ReadOnly = true;
            // 
            // dgCode
            // 
            this.dgCode.DataPropertyName = "Code";
            this.dgCode.HeaderText = "کد قرارداد";
            this.dgCode.Name = "dgCode";
            this.dgCode.ReadOnly = true;
            // 
            // fNameDataGridViewTextBoxColumn
            // 
            this.fNameDataGridViewTextBoxColumn.DataPropertyName = "fName";
            this.fNameDataGridViewTextBoxColumn.HeaderText = "طرف اول/فروشنده/موجر";
            this.fNameDataGridViewTextBoxColumn.Name = "fNameDataGridViewTextBoxColumn";
            this.fNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // sNameDataGridViewTextBoxColumn
            // 
            this.sNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sNameDataGridViewTextBoxColumn.DataPropertyName = "sName";
            this.sNameDataGridViewTextBoxColumn.HeaderText = "طرف دوم/خریدار/مستاجر";
            this.sNameDataGridViewTextBoxColumn.Name = "sNameDataGridViewTextBoxColumn";
            this.sNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "کاربر ثبت کننده";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // isTempDataGridViewCheckBoxColumn
            // 
            this.isTempDataGridViewCheckBoxColumn.DataPropertyName = "IsTemp";
            this.isTempDataGridViewCheckBoxColumn.HeaderText = "موقت";
            this.isTempDataGridViewCheckBoxColumn.Name = "isTempDataGridViewCheckBoxColumn";
            this.isTempDataGridViewCheckBoxColumn.ReadOnly = true;
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
            // secondSideGuidDataGridViewTextBoxColumn
            // 
            this.secondSideGuidDataGridViewTextBoxColumn.DataPropertyName = "SecondSideGuid";
            this.secondSideGuidDataGridViewTextBoxColumn.HeaderText = "SecondSideGuid";
            this.secondSideGuidDataGridViewTextBoxColumn.Name = "secondSideGuidDataGridViewTextBoxColumn";
            this.secondSideGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.secondSideGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // firstSideGuidDataGridViewTextBoxColumn
            // 
            this.firstSideGuidDataGridViewTextBoxColumn.DataPropertyName = "FirstSideGuid";
            this.firstSideGuidDataGridViewTextBoxColumn.HeaderText = "FirstSideGuid";
            this.firstSideGuidDataGridViewTextBoxColumn.Name = "firstSideGuidDataGridViewTextBoxColumn";
            this.firstSideGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstSideGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // userGuidDataGridViewTextBoxColumn
            // 
            this.userGuidDataGridViewTextBoxColumn.DataPropertyName = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.HeaderText = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.Name = "userGuidDataGridViewTextBoxColumn";
            this.userGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.userGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // termDataGridViewTextBoxColumn
            // 
            this.termDataGridViewTextBoxColumn.DataPropertyName = "Term";
            this.termDataGridViewTextBoxColumn.HeaderText = "Term";
            this.termDataGridViewTextBoxColumn.Name = "termDataGridViewTextBoxColumn";
            this.termDataGridViewTextBoxColumn.ReadOnly = true;
            this.termDataGridViewTextBoxColumn.Visible = false;
            // 
            // fromDateDataGridViewTextBoxColumn
            // 
            this.fromDateDataGridViewTextBoxColumn.DataPropertyName = "FromDate";
            this.fromDateDataGridViewTextBoxColumn.HeaderText = "FromDate";
            this.fromDateDataGridViewTextBoxColumn.Name = "fromDateDataGridViewTextBoxColumn";
            this.fromDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.fromDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            this.totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.HeaderText = "TotalPrice";
            this.totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            this.totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // minorPriceDataGridViewTextBoxColumn
            // 
            this.minorPriceDataGridViewTextBoxColumn.DataPropertyName = "MinorPrice";
            this.minorPriceDataGridViewTextBoxColumn.HeaderText = "MinorPrice";
            this.minorPriceDataGridViewTextBoxColumn.Name = "minorPriceDataGridViewTextBoxColumn";
            this.minorPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.minorPriceDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkNoDataGridViewTextBoxColumn
            // 
            this.checkNoDataGridViewTextBoxColumn.DataPropertyName = "CheckNo";
            this.checkNoDataGridViewTextBoxColumn.HeaderText = "CheckNo";
            this.checkNoDataGridViewTextBoxColumn.Name = "checkNoDataGridViewTextBoxColumn";
            this.checkNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkNoDataGridViewTextBoxColumn.Visible = false;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "BankName";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // shobeDataGridViewTextBoxColumn
            // 
            this.shobeDataGridViewTextBoxColumn.DataPropertyName = "Shobe";
            this.shobeDataGridViewTextBoxColumn.HeaderText = "Shobe";
            this.shobeDataGridViewTextBoxColumn.Name = "shobeDataGridViewTextBoxColumn";
            this.shobeDataGridViewTextBoxColumn.ReadOnly = true;
            this.shobeDataGridViewTextBoxColumn.Visible = false;
            // 
            // sarResidDataGridViewTextBoxColumn
            // 
            this.sarResidDataGridViewTextBoxColumn.DataPropertyName = "SarResid";
            this.sarResidDataGridViewTextBoxColumn.HeaderText = "SarResid";
            this.sarResidDataGridViewTextBoxColumn.Name = "sarResidDataGridViewTextBoxColumn";
            this.sarResidDataGridViewTextBoxColumn.ReadOnly = true;
            this.sarResidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dischargeDateDataGridViewTextBoxColumn
            // 
            this.dischargeDateDataGridViewTextBoxColumn.DataPropertyName = "DischargeDate";
            this.dischargeDateDataGridViewTextBoxColumn.HeaderText = "DischargeDate";
            this.dischargeDateDataGridViewTextBoxColumn.Name = "dischargeDateDataGridViewTextBoxColumn";
            this.dischargeDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dischargeDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // setDocDateDataGridViewTextBoxColumn
            // 
            this.setDocDateDataGridViewTextBoxColumn.DataPropertyName = "SetDocDate";
            this.setDocDateDataGridViewTextBoxColumn.HeaderText = "SetDocDate";
            this.setDocDateDataGridViewTextBoxColumn.Name = "setDocDateDataGridViewTextBoxColumn";
            this.setDocDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.setDocDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // setDocPlaceDataGridViewTextBoxColumn
            // 
            this.setDocPlaceDataGridViewTextBoxColumn.DataPropertyName = "SetDocPlace";
            this.setDocPlaceDataGridViewTextBoxColumn.HeaderText = "SetDocPlace";
            this.setDocPlaceDataGridViewTextBoxColumn.Name = "setDocPlaceDataGridViewTextBoxColumn";
            this.setDocPlaceDataGridViewTextBoxColumn.ReadOnly = true;
            this.setDocPlaceDataGridViewTextBoxColumn.Visible = false;
            // 
            // sarQofliDataGridViewTextBoxColumn
            // 
            this.sarQofliDataGridViewTextBoxColumn.DataPropertyName = "SarQofli";
            this.sarQofliDataGridViewTextBoxColumn.HeaderText = "SarQofli";
            this.sarQofliDataGridViewTextBoxColumn.Name = "sarQofliDataGridViewTextBoxColumn";
            this.sarQofliDataGridViewTextBoxColumn.ReadOnly = true;
            this.sarQofliDataGridViewTextBoxColumn.Visible = false;
            // 
            // delayDataGridViewTextBoxColumn
            // 
            this.delayDataGridViewTextBoxColumn.DataPropertyName = "Delay";
            this.delayDataGridViewTextBoxColumn.HeaderText = "Delay";
            this.delayDataGridViewTextBoxColumn.Name = "delayDataGridViewTextBoxColumn";
            this.delayDataGridViewTextBoxColumn.ReadOnly = true;
            this.delayDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // conBindingSource
            // 
            this.conBindingSource.DataSource = typeof(EntityCache.Bussines.ContractBussines);
            // 
            // frmShowContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowContract";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowContract_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowContract_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnOther;
        private DevComponents.DotNetBar.ButtonItem btnChangeTemp;
        private DevComponents.DotNetBar.ButtonItem btnShowStandard;
        private DevComponents.DotNetBar.ButtonX btnView;
        private DevComponents.DotNetBar.ButtonX btnChangeStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.BindingSource conBindingSource;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn fNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isTempDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondSideGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstSideGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn termDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minorPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sarResidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dischargeDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setDocDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn setDocPlaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sarQofliDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}