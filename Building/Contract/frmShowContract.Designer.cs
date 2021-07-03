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
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstSideName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondSideName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DischargeDateSh = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuChangeTemp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowStandard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintFirstSide = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintSecondSide = new System.Windows.Forms.ToolStripMenuItem();
            this.conBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucHeader = new WindowsSerivces.UC_Header();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conBindingSource)).BeginInit();
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
            this.txtSearch.Location = new System.Drawing.Point(46, 69);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(701, 27);
            this.txtSearch.TabIndex = 55770;
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
            this.DateSh,
            this.dgCode,
            this.FirstSideName,
            this.SecondSideName,
            this.DischargeDateSh,
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
            this.DGrid.ContextMenuStrip = this.contextMenu;
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
            this.DGrid.Location = new System.Drawing.Point(4, 108);
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
            this.DGrid.Size = new System.Drawing.Size(795, 477);
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
            this.DateSh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateSh.DataPropertyName = "DateSh";
            this.DateSh.HeaderText = "تاریخ ثبت";
            this.DateSh.Name = "DateSh";
            this.DateSh.ReadOnly = true;
            this.DateSh.Width = 74;
            // 
            // dgCode
            // 
            this.dgCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCode.DataPropertyName = "Code";
            this.dgCode.HeaderText = "کد قرارداد";
            this.dgCode.Name = "dgCode";
            this.dgCode.ReadOnly = true;
            this.dgCode.Width = 80;
            // 
            // FirstSideName
            // 
            this.FirstSideName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirstSideName.DataPropertyName = "FirstSideName";
            this.FirstSideName.HeaderText = "طرف اول/فروشنده/موجر";
            this.FirstSideName.Name = "FirstSideName";
            this.FirstSideName.ReadOnly = true;
            // 
            // SecondSideName
            // 
            this.SecondSideName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SecondSideName.DataPropertyName = "SecondSideName";
            this.SecondSideName.HeaderText = "طرف دوم/خریدار/مستاجر";
            this.SecondSideName.Name = "SecondSideName";
            this.SecondSideName.ReadOnly = true;
            // 
            // DischargeDateSh
            // 
            this.DischargeDateSh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DischargeDateSh.DataPropertyName = "DischargeDateSh";
            this.DischargeDateSh.HeaderText = "تاریخ تحویل";
            this.DischargeDateSh.Name = "DischargeDateSh";
            this.DischargeDateSh.ReadOnly = true;
            this.DischargeDateSh.Width = 84;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "کاربر ثبت کننده";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 99;
            // 
            // isTempDataGridViewCheckBoxColumn
            // 
            this.isTempDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isTempDataGridViewCheckBoxColumn.DataPropertyName = "IsTemp";
            this.isTempDataGridViewCheckBoxColumn.HeaderText = "موقت";
            this.isTempDataGridViewCheckBoxColumn.Name = "isTempDataGridViewCheckBoxColumn";
            this.isTempDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isTempDataGridViewCheckBoxColumn.Width = 43;
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
            this.mnuChangeTemp,
            this.toolStripMenuItem3,
            this.mnuShowStandard,
            this.mnuPrint,
            this.mnuPrintFirstSide,
            this.mnuPrintSecondSide});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(327, 260);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::Building.Properties.Resources.add_2_;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(326, 24);
            this.mnuAdd.Text = "افزودن قولنامه جدید (Ins)";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Building.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(326, 24);
            this.mnuEdit.Text = "ویرایش قولنامه جاری (F7)";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Building.Properties.Resources.delete_1_;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(326, 24);
            this.mnuDelete.Text = "حذف قولنامه جاری (Del)";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(323, 6);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Building.Properties.Resources.article_1_;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(326, 24);
            this.mnuView.Text = "مشاهده (F12)";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(323, 6);
            // 
            // mnuChangeTemp
            // 
            this.mnuChangeTemp.Image = global::Building.Properties.Resources.profile;
            this.mnuChangeTemp.Name = "mnuChangeTemp";
            this.mnuChangeTemp.Size = new System.Drawing.Size(326, 24);
            this.mnuChangeTemp.Text = "نهایی کردن و بستن قولنامه";
            this.mnuChangeTemp.Click += new System.EventHandler(this.mnuChangeTemp_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(323, 6);
            // 
            // mnuShowStandard
            // 
            this.mnuShowStandard.Image = global::Building.Properties.Resources.list;
            this.mnuShowStandard.Name = "mnuShowStandard";
            this.mnuShowStandard.Size = new System.Drawing.Size(326, 24);
            this.mnuShowStandard.Text = "چاپ قولنامه جاری در فرمت استاندارد اتحادیه املاک";
            this.mnuShowStandard.Click += new System.EventHandler(this.mnuShowStandard_Click);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = global::Building.Properties.Resources.printer;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(326, 24);
            this.mnuPrint.Text = "چاپ لیست قولنامه ها";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            // 
            // mnuPrintFirstSide
            // 
            this.mnuPrintFirstSide.Image = global::Building.Properties.Resources.list;
            this.mnuPrintFirstSide.Name = "mnuPrintFirstSide";
            this.mnuPrintFirstSide.Size = new System.Drawing.Size(326, 24);
            this.mnuPrintFirstSide.Text = "چاپ فاکتور رسمی طرف اول قولنامه";
            this.mnuPrintFirstSide.Click += new System.EventHandler(this.mnuPrintFirstSide_Click);
            // 
            // mnuPrintSecondSide
            // 
            this.mnuPrintSecondSide.Image = global::Building.Properties.Resources.list;
            this.mnuPrintSecondSide.Name = "mnuPrintSecondSide";
            this.mnuPrintSecondSide.Size = new System.Drawing.Size(326, 24);
            this.mnuPrintSecondSide.Text = "چاپ فاکتور رسمی طرف دوم قولنامه";
            this.mnuPrintSecondSide.Click += new System.EventHandler(this.mnuPrintSecondSide_Click);
            // 
            // conBindingSource
            // 
            this.conBindingSource.DataSource = typeof(EntityCache.Bussines.ContractBussines);
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
            this.ucHeader.Location = new System.Drawing.Point(0, 26);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55771;
            // 
            // frmShowContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowContract";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowContract_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowContract_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.conBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.BindingSource conBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuShowStandard;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeTemp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstSideName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondSideName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DischargeDateSh;
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
        private WindowsSerivces.UC_Header ucHeader;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintFirstSide;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintSecondSide;
    }
}