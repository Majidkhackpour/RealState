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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowRequest));
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeStatus = new DevComponents.DotNetBar.ButtonX();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.reqBindingSource = new System.Windows.Forms.BindingSource();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askerGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPrice1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPrice2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasVamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rahnPrice1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rahnPrice2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ejarePrice1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ejarePrice2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peopleCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasOwnerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentalAutorityGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingTypeGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masahat1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.masahat2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingConditionGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOther = new DevComponents.DotNetBar.ButtonX();
            this.btnSendSms = new DevComponents.DotNetBar.ButtonItem();
            this.btnShowBuilding = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.reqBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.SuspendLayout();
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
            this.btnView.TabIndex = 55762;
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
            this.btnChangeStatus.TabIndex = 55764;
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
            this.txtSearch.TabIndex = 55761;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // reqBindingSource
            // 
            this.reqBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingRequestBussines);
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
            this.btnDelete.TabIndex = 55763;
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
            this.btnInsert.TabIndex = 55765;
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
            this.btnEdit.TabIndex = 55766;
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
            this.line1.TabIndex = 55759;
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
            this.dgName,
            this.userNameDataGridViewTextBoxColumn,
            this.shortDescDataGridViewTextBoxColumn,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.createDateDataGridViewTextBoxColumn,
            this.askerGuidDataGridViewTextBoxColumn,
            this.userGuidDataGridViewTextBoxColumn,
            this.sellPrice1DataGridViewTextBoxColumn,
            this.sellPrice2DataGridViewTextBoxColumn,
            this.hasVamDataGridViewTextBoxColumn,
            this.rahnPrice1DataGridViewTextBoxColumn,
            this.rahnPrice2DataGridViewTextBoxColumn,
            this.ejarePrice1DataGridViewTextBoxColumn,
            this.ejarePrice2DataGridViewTextBoxColumn,
            this.peopleCountDataGridViewTextBoxColumn,
            this.hasOwnerDataGridViewTextBoxColumn,
            this.shortDateDataGridViewTextBoxColumn,
            this.rentalAutorityGuidDataGridViewTextBoxColumn,
            this.cityGuidDataGridViewTextBoxColumn,
            this.buildingTypeGuidDataGridViewTextBoxColumn,
            this.masahat1DataGridViewTextBoxColumn,
            this.masahat2DataGridViewTextBoxColumn,
            this.roomCountDataGridViewTextBoxColumn,
            this.buildingAccountTypeGuidDataGridViewTextBoxColumn,
            this.buildingConditionGuidDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.reqBindingSource;
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
            this.dgName.DataPropertyName = "AskerName";
            this.dgName.HeaderText = "متقاضی";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            this.dgName.Width = 200;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "مشاور";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // shortDescDataGridViewTextBoxColumn
            // 
            this.shortDescDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.shortDescDataGridViewTextBoxColumn.DataPropertyName = "ShortDesc";
            this.shortDescDataGridViewTextBoxColumn.HeaderText = "توضیحات";
            this.shortDescDataGridViewTextBoxColumn.Name = "shortDescDataGridViewTextBoxColumn";
            this.shortDescDataGridViewTextBoxColumn.ReadOnly = true;
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
            // sellPrice1DataGridViewTextBoxColumn
            // 
            this.sellPrice1DataGridViewTextBoxColumn.DataPropertyName = "SellPrice1";
            this.sellPrice1DataGridViewTextBoxColumn.HeaderText = "SellPrice1";
            this.sellPrice1DataGridViewTextBoxColumn.Name = "sellPrice1DataGridViewTextBoxColumn";
            this.sellPrice1DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPrice1DataGridViewTextBoxColumn.Visible = false;
            // 
            // sellPrice2DataGridViewTextBoxColumn
            // 
            this.sellPrice2DataGridViewTextBoxColumn.DataPropertyName = "SellPrice2";
            this.sellPrice2DataGridViewTextBoxColumn.HeaderText = "SellPrice2";
            this.sellPrice2DataGridViewTextBoxColumn.Name = "sellPrice2DataGridViewTextBoxColumn";
            this.sellPrice2DataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPrice2DataGridViewTextBoxColumn.Visible = false;
            // 
            // hasVamDataGridViewTextBoxColumn
            // 
            this.hasVamDataGridViewTextBoxColumn.DataPropertyName = "HasVam";
            this.hasVamDataGridViewTextBoxColumn.HeaderText = "HasVam";
            this.hasVamDataGridViewTextBoxColumn.Name = "hasVamDataGridViewTextBoxColumn";
            this.hasVamDataGridViewTextBoxColumn.ReadOnly = true;
            this.hasVamDataGridViewTextBoxColumn.Visible = false;
            // 
            // rahnPrice1DataGridViewTextBoxColumn
            // 
            this.rahnPrice1DataGridViewTextBoxColumn.DataPropertyName = "RahnPrice1";
            this.rahnPrice1DataGridViewTextBoxColumn.HeaderText = "RahnPrice1";
            this.rahnPrice1DataGridViewTextBoxColumn.Name = "rahnPrice1DataGridViewTextBoxColumn";
            this.rahnPrice1DataGridViewTextBoxColumn.ReadOnly = true;
            this.rahnPrice1DataGridViewTextBoxColumn.Visible = false;
            // 
            // rahnPrice2DataGridViewTextBoxColumn
            // 
            this.rahnPrice2DataGridViewTextBoxColumn.DataPropertyName = "RahnPrice2";
            this.rahnPrice2DataGridViewTextBoxColumn.HeaderText = "RahnPrice2";
            this.rahnPrice2DataGridViewTextBoxColumn.Name = "rahnPrice2DataGridViewTextBoxColumn";
            this.rahnPrice2DataGridViewTextBoxColumn.ReadOnly = true;
            this.rahnPrice2DataGridViewTextBoxColumn.Visible = false;
            // 
            // ejarePrice1DataGridViewTextBoxColumn
            // 
            this.ejarePrice1DataGridViewTextBoxColumn.DataPropertyName = "EjarePrice1";
            this.ejarePrice1DataGridViewTextBoxColumn.HeaderText = "EjarePrice1";
            this.ejarePrice1DataGridViewTextBoxColumn.Name = "ejarePrice1DataGridViewTextBoxColumn";
            this.ejarePrice1DataGridViewTextBoxColumn.ReadOnly = true;
            this.ejarePrice1DataGridViewTextBoxColumn.Visible = false;
            // 
            // ejarePrice2DataGridViewTextBoxColumn
            // 
            this.ejarePrice2DataGridViewTextBoxColumn.DataPropertyName = "EjarePrice2";
            this.ejarePrice2DataGridViewTextBoxColumn.HeaderText = "EjarePrice2";
            this.ejarePrice2DataGridViewTextBoxColumn.Name = "ejarePrice2DataGridViewTextBoxColumn";
            this.ejarePrice2DataGridViewTextBoxColumn.ReadOnly = true;
            this.ejarePrice2DataGridViewTextBoxColumn.Visible = false;
            // 
            // peopleCountDataGridViewTextBoxColumn
            // 
            this.peopleCountDataGridViewTextBoxColumn.DataPropertyName = "PeopleCount";
            this.peopleCountDataGridViewTextBoxColumn.HeaderText = "PeopleCount";
            this.peopleCountDataGridViewTextBoxColumn.Name = "peopleCountDataGridViewTextBoxColumn";
            this.peopleCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.peopleCountDataGridViewTextBoxColumn.Visible = false;
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
            // masahat1DataGridViewTextBoxColumn
            // 
            this.masahat1DataGridViewTextBoxColumn.DataPropertyName = "Masahat1";
            this.masahat1DataGridViewTextBoxColumn.HeaderText = "Masahat1";
            this.masahat1DataGridViewTextBoxColumn.Name = "masahat1DataGridViewTextBoxColumn";
            this.masahat1DataGridViewTextBoxColumn.ReadOnly = true;
            this.masahat1DataGridViewTextBoxColumn.Visible = false;
            // 
            // masahat2DataGridViewTextBoxColumn
            // 
            this.masahat2DataGridViewTextBoxColumn.DataPropertyName = "Masahat2";
            this.masahat2DataGridViewTextBoxColumn.HeaderText = "Masahat2";
            this.masahat2DataGridViewTextBoxColumn.Name = "masahat2DataGridViewTextBoxColumn";
            this.masahat2DataGridViewTextBoxColumn.ReadOnly = true;
            this.masahat2DataGridViewTextBoxColumn.Visible = false;
            // 
            // roomCountDataGridViewTextBoxColumn
            // 
            this.roomCountDataGridViewTextBoxColumn.DataPropertyName = "RoomCount";
            this.roomCountDataGridViewTextBoxColumn.HeaderText = "RoomCount";
            this.roomCountDataGridViewTextBoxColumn.Name = "roomCountDataGridViewTextBoxColumn";
            this.roomCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.roomCountDataGridViewTextBoxColumn.Visible = false;
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
            this.btnSendSms,
            this.btnShowBuilding});
            this.btnOther.TabIndex = 55767;
            this.btnOther.Text = "سایر";
            this.btnOther.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOther.TextColor = System.Drawing.Color.Black;
            // 
            // btnSendSms
            // 
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.Text = "ارسال پیامک به متقاضی";
            // 
            // btnShowBuilding
            // 
            this.btnShowBuilding.Name = "btnShowBuilding";
            this.btnShowBuilding.Text = "نمایش فایل های مطابق با درخواست";
            this.btnShowBuilding.Click += new System.EventHandler(this.btnShowBuilding_Click);
            // 
            // frmShowRequest
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
            this.Name = "frmShowRequest";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowRequest_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowRequest_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.reqBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnView;
        private DevComponents.DotNetBar.ButtonX btnChangeStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.BindingSource reqBindingSource;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn askerGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPrice1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPrice2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasVamDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rahnPrice1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rahnPrice2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ejarePrice1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ejarePrice2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn peopleCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasOwnerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentalAutorityGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingTypeGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masahat1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masahat2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingAccountTypeGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingConditionGuidDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.ButtonX btnOther;
        private DevComponents.DotNetBar.ButtonItem btnSendSms;
        private DevComponents.DotNetBar.ButtonItem btnShowBuilding;
    }
}