namespace Building.BuildingRequest
{
    partial class frmShowRequest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowRequest));
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSell1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSell2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVam = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgRahn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRahn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEjare1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgEjare2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMasahat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMasahat2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPeopleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgRoomCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askerGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasOwnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentalAutorityGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingTypeGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingConditionGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSendSms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowBuilding = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.reqBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucHeader = new WindowsSerivces.UC_Header();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reqBindingSource)).BeginInit();
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
            this.txtSearch.Location = new System.Drawing.Point(46, 59);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(701, 27);
            this.txtSearch.TabIndex = 55761;
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
            this.dgName,
            this.dgUserName,
            this.dgSell1,
            this.dgSell2,
            this.dgVam,
            this.dgRahn1,
            this.dgRahn2,
            this.dgEjare1,
            this.dgEjare2,
            this.dgMasahat1,
            this.dgMasahat2,
            this.dgPeopleCount,
            this.dgRoomCount,
            this.dgDesc,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.askerGuidDataGridViewTextBoxColumn,
            this.userGuidDataGridViewTextBoxColumn,
            this.hasOwnerDataGridViewTextBoxColumn,
            this.shortDateDataGridViewTextBoxColumn,
            this.rentalAutorityGuidDataGridViewTextBoxColumn,
            this.cityGuidDataGridViewTextBoxColumn,
            this.buildingTypeGuidDataGridViewTextBoxColumn,
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn,
            this.buildingConditionGuidDataGridViewTextBoxColumn});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            this.DGrid.DataSource = this.reqBindingSource;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle9;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(4, 96);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(795, 492);
            this.DGrid.TabIndex = 55760;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 50;
            // 
            // dgName
            // 
            this.dgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgName.DataPropertyName = "AskerName";
            this.dgName.HeaderText = "متقاضی";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            this.dgName.Width = 70;
            // 
            // dgUserName
            // 
            this.dgUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgUserName.DataPropertyName = "UserName";
            this.dgUserName.HeaderText = "مشاور";
            this.dgUserName.Name = "dgUserName";
            this.dgUserName.ReadOnly = true;
            this.dgUserName.Width = 64;
            // 
            // dgSell1
            // 
            this.dgSell1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgSell1.DataPropertyName = "SellPrice1";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dgSell1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgSell1.HeaderText = "خرید از";
            this.dgSell1.Name = "dgSell1";
            this.dgSell1.ReadOnly = true;
            this.dgSell1.Visible = false;
            // 
            // dgSell2
            // 
            this.dgSell2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgSell2.DataPropertyName = "SellPrice2";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dgSell2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgSell2.HeaderText = "الی";
            this.dgSell2.Name = "dgSell2";
            this.dgSell2.ReadOnly = true;
            this.dgSell2.Visible = false;
            // 
            // dgVam
            // 
            this.dgVam.DataPropertyName = "HasVam";
            this.dgVam.HeaderText = "وام";
            this.dgVam.Name = "dgVam";
            this.dgVam.ReadOnly = true;
            this.dgVam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgVam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgVam.Visible = false;
            // 
            // dgRahn1
            // 
            this.dgRahn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgRahn1.DataPropertyName = "RahnPrice1";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.dgRahn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgRahn1.HeaderText = "رهن از";
            this.dgRahn1.Name = "dgRahn1";
            this.dgRahn1.ReadOnly = true;
            this.dgRahn1.Visible = false;
            // 
            // dgRahn2
            // 
            this.dgRahn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgRahn2.DataPropertyName = "RahnPrice2";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.dgRahn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgRahn2.HeaderText = "الی";
            this.dgRahn2.Name = "dgRahn2";
            this.dgRahn2.ReadOnly = true;
            this.dgRahn2.Visible = false;
            // 
            // dgEjare1
            // 
            this.dgEjare1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgEjare1.DataPropertyName = "EjarePrice1";
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.dgEjare1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgEjare1.HeaderText = "اجاره از";
            this.dgEjare1.Name = "dgEjare1";
            this.dgEjare1.ReadOnly = true;
            this.dgEjare1.Visible = false;
            // 
            // dgEjare2
            // 
            this.dgEjare2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgEjare2.DataPropertyName = "EjarePrice2";
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.dgEjare2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgEjare2.HeaderText = "الی";
            this.dgEjare2.Name = "dgEjare2";
            this.dgEjare2.ReadOnly = true;
            this.dgEjare2.Visible = false;
            // 
            // dgMasahat1
            // 
            this.dgMasahat1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgMasahat1.DataPropertyName = "Masahat1";
            this.dgMasahat1.HeaderText = "مساحت از";
            this.dgMasahat1.Name = "dgMasahat1";
            this.dgMasahat1.ReadOnly = true;
            this.dgMasahat1.Visible = false;
            // 
            // dgMasahat2
            // 
            this.dgMasahat2.DataPropertyName = "Masahat2";
            this.dgMasahat2.HeaderText = "الی";
            this.dgMasahat2.Name = "dgMasahat2";
            this.dgMasahat2.ReadOnly = true;
            this.dgMasahat2.Visible = false;
            // 
            // dgPeopleCount
            // 
            this.dgPeopleCount.DataPropertyName = "PeopleCount";
            this.dgPeopleCount.HeaderText = "تعداد افراد";
            this.dgPeopleCount.Name = "dgPeopleCount";
            this.dgPeopleCount.ReadOnly = true;
            this.dgPeopleCount.Visible = false;
            // 
            // dgRoomCount
            // 
            this.dgRoomCount.DataPropertyName = "RoomCount";
            this.dgRoomCount.HeaderText = "تعداد اتاق";
            this.dgRoomCount.Name = "dgRoomCount";
            this.dgRoomCount.ReadOnly = true;
            this.dgRoomCount.Visible = false;
            // 
            // dgDesc
            // 
            this.dgDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgDesc.DataPropertyName = "ShortDesc";
            this.dgDesc.HeaderText = "توضیحات";
            this.dgDesc.Name = "dgDesc";
            this.dgDesc.ReadOnly = true;
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
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.HeaderText = "CreateDate";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.createDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // askerGuidDataGridViewTextBoxColumn
            // 
            this.askerGuidDataGridViewTextBoxColumn.DataPropertyName = "AskerGuid";
            this.askerGuidDataGridViewTextBoxColumn.HeaderText = "AskerGuid";
            this.askerGuidDataGridViewTextBoxColumn.Name = "askerGuidDataGridViewTextBoxColumn";
            this.askerGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.askerGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // userGuidDataGridViewTextBoxColumn
            // 
            this.userGuidDataGridViewTextBoxColumn.DataPropertyName = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.HeaderText = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.Name = "userGuidDataGridViewTextBoxColumn";
            this.userGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.userGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // hasOwnerDataGridViewTextBoxColumn
            // 
            this.hasOwnerDataGridViewTextBoxColumn.DataPropertyName = "HasOwner";
            this.hasOwnerDataGridViewTextBoxColumn.HeaderText = "HasOwner";
            this.hasOwnerDataGridViewTextBoxColumn.Name = "hasOwnerDataGridViewTextBoxColumn";
            this.hasOwnerDataGridViewTextBoxColumn.ReadOnly = true;
            this.hasOwnerDataGridViewTextBoxColumn.Visible = false;
            // 
            // shortDateDataGridViewTextBoxColumn
            // 
            this.shortDateDataGridViewTextBoxColumn.DataPropertyName = "ShortDate";
            this.shortDateDataGridViewTextBoxColumn.HeaderText = "ShortDate";
            this.shortDateDataGridViewTextBoxColumn.Name = "shortDateDataGridViewTextBoxColumn";
            this.shortDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.shortDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // rentalAutorityGuidDataGridViewTextBoxColumn
            // 
            this.rentalAutorityGuidDataGridViewTextBoxColumn.DataPropertyName = "RentalAutorityGuid";
            this.rentalAutorityGuidDataGridViewTextBoxColumn.HeaderText = "RentalAutorityGuid";
            this.rentalAutorityGuidDataGridViewTextBoxColumn.Name = "rentalAutorityGuidDataGridViewTextBoxColumn";
            this.rentalAutorityGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.rentalAutorityGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // cityGuidDataGridViewTextBoxColumn
            // 
            this.cityGuidDataGridViewTextBoxColumn.DataPropertyName = "CityGuid";
            this.cityGuidDataGridViewTextBoxColumn.HeaderText = "CityGuid";
            this.cityGuidDataGridViewTextBoxColumn.Name = "cityGuidDataGridViewTextBoxColumn";
            this.cityGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buildingTypeGuidDataGridViewTextBoxColumn
            // 
            this.buildingTypeGuidDataGridViewTextBoxColumn.DataPropertyName = "BuildingTypeGuid";
            this.buildingTypeGuidDataGridViewTextBoxColumn.HeaderText = "BuildingTypeGuid";
            this.buildingTypeGuidDataGridViewTextBoxColumn.Name = "buildingTypeGuidDataGridViewTextBoxColumn";
            this.buildingTypeGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingTypeGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buildingAccountTypeGuidDataGridViewTextBoxColumn
            // 
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn.DataPropertyName = "BuildingAccountTypeGuid";
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn.HeaderText = "BuildingAccountTypeGuid";
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn.Name = "buildingAccountTypeGuidDataGridViewTextBoxColumn";
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buildingConditionGuidDataGridViewTextBoxColumn
            // 
            this.buildingConditionGuidDataGridViewTextBoxColumn.DataPropertyName = "BuildingConditionGuid";
            this.buildingConditionGuidDataGridViewTextBoxColumn.HeaderText = "BuildingConditionGuid";
            this.buildingConditionGuidDataGridViewTextBoxColumn.Name = "buildingConditionGuidDataGridViewTextBoxColumn";
            this.buildingConditionGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingConditionGuidDataGridViewTextBoxColumn.Visible = false;
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
            this.mnuSendSms,
            this.mnuShowBuilding,
            this.toolStripMenuItem3,
            this.mnuPrint});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(225, 212);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::Building.Properties.Resources.add_2_;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(224, 24);
            this.mnuAdd.Text = "افزودن تقاضای جدید (Ins)";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Building.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(224, 24);
            this.mnuEdit.Text = "ویرایش تقاضای جاری (F7)";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Building.Properties.Resources.delete_1_;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(224, 24);
            this.mnuDelete.Text = "حذف تقاضای جاری (Del)";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Building.Properties.Resources.article_1_;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(224, 24);
            this.mnuView.Text = "مشاهده (F12)";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuSendSms
            // 
            this.mnuSendSms.Image = global::Building.Properties.Resources.profile;
            this.mnuSendSms.Name = "mnuSendSms";
            this.mnuSendSms.Size = new System.Drawing.Size(224, 24);
            this.mnuSendSms.Text = "ارسال پیامک به متقاضی";
            // 
            // mnuShowBuilding
            // 
            this.mnuShowBuilding.Image = global::Building.Properties.Resources.list;
            this.mnuShowBuilding.Name = "mnuShowBuilding";
            this.mnuShowBuilding.Size = new System.Drawing.Size(224, 24);
            this.mnuShowBuilding.Text = "نمایش فایل های مطابق با تقاضا";
            this.mnuShowBuilding.Click += new System.EventHandler(this.mnuShowBuilding_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = global::Building.Properties.Resources.printer;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(224, 24);
            this.mnuPrint.Text = "چاپ لیست تقاضاها";
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            // 
            // reqBindingSource
            // 
            this.reqBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingRequestBussines);
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
            this.ucHeader.Location = new System.Drawing.Point(-7, 18);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55762;
            // 
            // frmShowRequest
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
            this.Name = "frmShowRequest";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowRequest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowRequest_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reqBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.BindingSource reqBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuSendSms;
        private System.Windows.Forms.ToolStripMenuItem mnuShowBuilding;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSell1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSell2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgVam;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRahn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRahn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEjare1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgEjare2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMasahat1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMasahat2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPeopleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRoomCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn askerGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasOwnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentalAutorityGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingTypeGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingAccountTypeGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingConditionGuidDataGridViewTextBoxColumn;
        private WindowsSerivces.UC_Header ucHeader;
    }
}