
using DevComponents.DotNetBar;

namespace Building.Buildings
{
    partial class frmBuildingDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuildingDetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.optionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildinGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverDeliveryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingOptionGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hardSerialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildingOptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpOwner = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label42 = new System.Windows.Forms.Label();
            this.lblOwnerAddress = new System.Windows.Forms.Label();
            this.lblTell4 = new System.Windows.Forms.Label();
            this.lblTell3 = new System.Windows.Forms.Label();
            this.lblTell2 = new System.Windows.Forms.Label();
            this.lblTell1 = new System.Windows.Forms.Label();
            this.lblOwnerName = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblPrice2 = new System.Windows.Forms.Label();
            this.lblPrice1 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.exPanel = new DevComponents.DotNetBar.ExpandablePanel();
            this.fPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingOptionBindingSource)).BeginInit();
            this.grpOwner.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.exPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupPanel3);
            this.panel1.Controls.Add(this.groupPanel4);
            this.panel1.Controls.Add(this.grpOwner);
            this.panel1.Controls.Add(this.groupPanel1);
            this.panel1.Controls.Add(this.groupPanel2);
            this.panel1.Location = new System.Drawing.Point(4, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(792, 649);
            this.panel1.TabIndex = 2;
            // 
            // groupPanel3
            // 
            this.groupPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.txtShortDesc);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(269, 671);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(503, 223);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel3.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 2;
            this.groupPanel3.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel3.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 2;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 2;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 2;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 27;
            this.groupPanel3.Text = "توضیحات تکمیلی";
            // 
            // txtShortDesc
            // 
            this.txtShortDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShortDesc.Location = new System.Drawing.Point(0, 0);
            this.txtShortDesc.Multiline = true;
            this.txtShortDesc.Name = "txtShortDesc";
            this.txtShortDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShortDesc.Size = new System.Drawing.Size(497, 195);
            this.txtShortDesc.TabIndex = 5;
            // 
            // groupPanel4
            // 
            this.groupPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.DGrid);
            this.groupPanel4.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel4.Location = new System.Drawing.Point(266, 453);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(506, 212);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel4.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 2;
            this.groupPanel4.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel4.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 2;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 2;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 2;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 17;
            this.groupPanel4.Text = "امکانات و تجهیزات";
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
            this.optionNameDataGridViewTextBoxColumn,
            this.guidDataGridViewTextBoxColumn,
            this.buildinGuidDataGridViewTextBoxColumn,
            this.modifiedDataGridViewTextBoxColumn,
            this.serverStatusDataGridViewTextBoxColumn,
            this.serverDeliveryDateDataGridViewTextBoxColumn,
            this.buildingOptionGuidDataGridViewTextBoxColumn,
            this.hardSerialDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.BuildingOptionBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(0, 0);
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
            this.DGrid.Size = new System.Drawing.Size(500, 184);
            this.DGrid.TabIndex = 55732;
            // 
            // optionNameDataGridViewTextBoxColumn
            // 
            this.optionNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.optionNameDataGridViewTextBoxColumn.DataPropertyName = "OptionName";
            this.optionNameDataGridViewTextBoxColumn.HeaderText = "عنوان";
            this.optionNameDataGridViewTextBoxColumn.Name = "optionNameDataGridViewTextBoxColumn";
            this.optionNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            this.guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            this.guidDataGridViewTextBoxColumn.HeaderText = "Guid";
            this.guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            this.guidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buildinGuidDataGridViewTextBoxColumn
            // 
            this.buildinGuidDataGridViewTextBoxColumn.DataPropertyName = "BuildinGuid";
            this.buildinGuidDataGridViewTextBoxColumn.HeaderText = "BuildinGuid";
            this.buildinGuidDataGridViewTextBoxColumn.Name = "buildinGuidDataGridViewTextBoxColumn";
            this.buildinGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // modifiedDataGridViewTextBoxColumn
            // 
            this.modifiedDataGridViewTextBoxColumn.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn.Name = "modifiedDataGridViewTextBoxColumn";
            this.modifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // serverStatusDataGridViewTextBoxColumn
            // 
            this.serverStatusDataGridViewTextBoxColumn.DataPropertyName = "ServerStatus";
            this.serverStatusDataGridViewTextBoxColumn.HeaderText = "ServerStatus";
            this.serverStatusDataGridViewTextBoxColumn.Name = "serverStatusDataGridViewTextBoxColumn";
            this.serverStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // serverDeliveryDateDataGridViewTextBoxColumn
            // 
            this.serverDeliveryDateDataGridViewTextBoxColumn.DataPropertyName = "ServerDeliveryDate";
            this.serverDeliveryDateDataGridViewTextBoxColumn.HeaderText = "ServerDeliveryDate";
            this.serverDeliveryDateDataGridViewTextBoxColumn.Name = "serverDeliveryDateDataGridViewTextBoxColumn";
            this.serverDeliveryDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // buildingOptionGuidDataGridViewTextBoxColumn
            // 
            this.buildingOptionGuidDataGridViewTextBoxColumn.DataPropertyName = "BuildingOptionGuid";
            this.buildingOptionGuidDataGridViewTextBoxColumn.HeaderText = "BuildingOptionGuid";
            this.buildingOptionGuidDataGridViewTextBoxColumn.Name = "buildingOptionGuidDataGridViewTextBoxColumn";
            this.buildingOptionGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // hardSerialDataGridViewTextBoxColumn
            // 
            this.hardSerialDataGridViewTextBoxColumn.DataPropertyName = "HardSerial";
            this.hardSerialDataGridViewTextBoxColumn.HeaderText = "HardSerial";
            this.hardSerialDataGridViewTextBoxColumn.Name = "hardSerialDataGridViewTextBoxColumn";
            this.hardSerialDataGridViewTextBoxColumn.ReadOnly = true;
            this.hardSerialDataGridViewTextBoxColumn.Visible = false;
            // 
            // BuildingOptionBindingSource
            // 
            this.BuildingOptionBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingRelatedOptionsBussines);
            // 
            // grpOwner
            // 
            this.grpOwner.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpOwner.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpOwner.Controls.Add(this.label42);
            this.grpOwner.Controls.Add(this.lblOwnerAddress);
            this.grpOwner.Controls.Add(this.lblTell4);
            this.grpOwner.Controls.Add(this.lblTell3);
            this.grpOwner.Controls.Add(this.lblTell2);
            this.grpOwner.Controls.Add(this.lblTell1);
            this.grpOwner.Controls.Add(this.lblOwnerName);
            this.grpOwner.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpOwner.Location = new System.Drawing.Point(13, 454);
            this.grpOwner.Name = "grpOwner";
            this.grpOwner.Size = new System.Drawing.Size(251, 440);
            // 
            // 
            // 
            this.grpOwner.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.grpOwner.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.grpOwner.Style.BackColorGradientAngle = 90;
            this.grpOwner.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpOwner.Style.BorderBottomWidth = 2;
            this.grpOwner.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.grpOwner.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.grpOwner.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpOwner.Style.BorderLeftWidth = 2;
            this.grpOwner.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpOwner.Style.BorderRightWidth = 2;
            this.grpOwner.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpOwner.Style.BorderTopWidth = 2;
            this.grpOwner.Style.CornerDiameter = 4;
            this.grpOwner.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpOwner.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpOwner.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grpOwner.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpOwner.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpOwner.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpOwner.TabIndex = 16;
            this.grpOwner.Text = "مشخصات مالک";
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Location = new System.Drawing.Point(162, 150);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(68, 20);
            this.label42.TabIndex = 20;
            this.label42.Text = "آدرس مالک:";
            // 
            // lblOwnerAddress
            // 
            this.lblOwnerAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOwnerAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerAddress.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOwnerAddress.Location = new System.Drawing.Point(7, 170);
            this.lblOwnerAddress.Name = "lblOwnerAddress";
            this.lblOwnerAddress.Size = new System.Drawing.Size(235, 235);
            this.lblOwnerAddress.TabIndex = 24;
            // 
            // lblTell4
            // 
            this.lblTell4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTell4.BackColor = System.Drawing.Color.Transparent;
            this.lblTell4.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTell4.Location = new System.Drawing.Point(-5, 119);
            this.lblTell4.Name = "lblTell4";
            this.lblTell4.Size = new System.Drawing.Size(247, 29);
            this.lblTell4.TabIndex = 24;
            // 
            // lblTell3
            // 
            this.lblTell3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTell3.BackColor = System.Drawing.Color.Transparent;
            this.lblTell3.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTell3.Location = new System.Drawing.Point(-5, 90);
            this.lblTell3.Name = "lblTell3";
            this.lblTell3.Size = new System.Drawing.Size(247, 29);
            this.lblTell3.TabIndex = 24;
            // 
            // lblTell2
            // 
            this.lblTell2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTell2.BackColor = System.Drawing.Color.Transparent;
            this.lblTell2.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTell2.Location = new System.Drawing.Point(-5, 61);
            this.lblTell2.Name = "lblTell2";
            this.lblTell2.Size = new System.Drawing.Size(247, 29);
            this.lblTell2.TabIndex = 24;
            // 
            // lblTell1
            // 
            this.lblTell1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTell1.BackColor = System.Drawing.Color.Transparent;
            this.lblTell1.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTell1.Location = new System.Drawing.Point(-5, 32);
            this.lblTell1.Name = "lblTell1";
            this.lblTell1.Size = new System.Drawing.Size(247, 29);
            this.lblTell1.TabIndex = 24;
            // 
            // lblOwnerName
            // 
            this.lblOwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOwnerName.BackColor = System.Drawing.Color.Transparent;
            this.lblOwnerName.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOwnerName.Location = new System.Drawing.Point(-5, 3);
            this.lblOwnerName.Name = "lblOwnerName";
            this.lblOwnerName.Size = new System.Drawing.Size(243, 29);
            this.lblOwnerName.TabIndex = 24;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.pnlContent);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Enabled = false;
            this.groupPanel1.Location = new System.Drawing.Point(10, 147);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(758, 300);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 2;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 2;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 2;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 2;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 15;
            this.groupPanel1.Text = "مشخصات کلی ملک";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(752, 272);
            this.pnlContent.TabIndex = 1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.lblCode);
            this.groupPanel2.Controls.Add(this.lblPrice2);
            this.groupPanel2.Controls.Add(this.lblPrice1);
            this.groupPanel2.Controls.Add(this.lblAddress);
            this.groupPanel2.Controls.Add(this.lblTitle);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(10, 3);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(759, 138);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 2;
            this.groupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel2.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 2;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 2;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 2;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 14;
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCode.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCode.Location = new System.Drawing.Point(7, 11);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(146, 30);
            this.lblCode.TabIndex = 13;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPrice2
            // 
            this.lblPrice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice2.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice2.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrice2.Location = new System.Drawing.Point(12, 98);
            this.lblPrice2.Name = "lblPrice2";
            this.lblPrice2.Size = new System.Drawing.Size(737, 30);
            this.lblPrice2.TabIndex = 13;
            // 
            // lblPrice1
            // 
            this.lblPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice1.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice1.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPrice1.Location = new System.Drawing.Point(12, 68);
            this.lblPrice1.Name = "lblPrice1";
            this.lblPrice1.Size = new System.Drawing.Size(737, 30);
            this.lblPrice1.TabIndex = 13;
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblAddress.Location = new System.Drawing.Point(3, 46);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(729, 26);
            this.lblAddress.TabIndex = 14;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(156, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(576, 42);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exPanel
            // 
            this.exPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exPanel.AnimationTime = 500;
            this.exPanel.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.LeftToRight;
            this.exPanel.Controls.Add(this.fPanel);
            this.exPanel.Controls.Add(this.picBox);
            this.exPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.exPanel.Expanded = false;
            this.exPanel.ExpandedBounds = new System.Drawing.Rectangle(430, 21, 365, 637);
            this.exPanel.Location = new System.Drawing.Point(807, 21);
            this.exPanel.Name = "exPanel";
            this.exPanel.Size = new System.Drawing.Size(26, 637);
            this.exPanel.Style.BackColor1.Color = System.Drawing.Color.White;
            this.exPanel.Style.BackColor2.Color = System.Drawing.Color.White;
            this.exPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.exPanel.TabIndex = 27;
            this.exPanel.TitleStyle.BackColor1.Color = System.Drawing.Color.White;
            this.exPanel.TitleStyle.BackColor2.Color = System.Drawing.Color.White;
            this.exPanel.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.exPanel.TitleText = "گالری تصاویر";
            // 
            // fPanel
            // 
            this.fPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fPanel.BackColor = System.Drawing.Color.Transparent;
            this.fPanel.Location = new System.Drawing.Point(8, 378);
            this.fPanel.Name = "fPanel";
            this.fPanel.Size = new System.Drawing.Size(0, 257);
            this.fPanel.TabIndex = 5;
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.Transparent;
            this.picBox.Location = new System.Drawing.Point(8, 29);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(343, 343);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 4;
            this.picBox.TabStop = false;
            // 
            // frmBuildingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 679);
            this.Controls.Add(this.exPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(838, 679);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(838, 679);
            this.Name = "frmBuildingDetail";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmBuildingDetail_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuildingDetail_KeyDown);
            this.panel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingOptionBindingSource)).EndInit();
            this.grpOwner.ResumeLayout(false);
            this.grpOwner.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.exPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblPrice2;
        private System.Windows.Forms.Label lblPrice1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTitle;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel grpOwner;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label lblOwnerAddress;
        private System.Windows.Forms.Label lblTell4;
        private System.Windows.Forms.Label lblTell3;
        private System.Windows.Forms.Label lblTell2;
        private System.Windows.Forms.Label lblTell1;
        private System.Windows.Forms.Label lblOwnerName;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.BindingSource BuildingOptionBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn optionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildinGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverDeliveryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingOptionGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hardSerialDataGridViewTextBoxColumn;
        private ExpandablePanel exPanel;
        private System.Windows.Forms.FlowLayoutPanel fPanel;
        private System.Windows.Forms.PictureBox picBox;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.TextBox txtShortDesc;
    }
}