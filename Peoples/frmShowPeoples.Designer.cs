﻿namespace Peoples
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPeoples));
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nationalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatherNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuedFromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trvGroup = new System.Windows.Forms.TreeView();
            this.btnView = new DevComponents.DotNetBar.ButtonX();
            this.btnChangeStatus = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnInsert = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnGroups = new DevComponents.DotNetBar.ButtonX();
            this.btnInsGroup = new DevComponents.DotNetBar.ButtonItem();
            this.btnUpGroup = new DevComponents.DotNetBar.ButtonItem();
            this.btnDelGroup = new DevComponents.DotNetBar.ButtonItem();
            this.btnOther = new DevComponents.DotNetBar.ButtonX();
            this.btnTell = new DevComponents.DotNetBar.ButtonItem();
            this.btnBank = new DevComponents.DotNetBar.ButtonItem();
            this.btnSendSMS = new DevComponents.DotNetBar.ButtonItem();
            this.btnIpmortFromExcel = new DevComponents.DotNetBar.ButtonItem();
            this.btnExportToExcel = new DevComponents.DotNetBar.ButtonItem();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrint = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleBindingSource)).BeginInit();
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
            this.txtSearch.Location = new System.Drawing.Point(46, 35);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(701, 27);
            this.txtSearch.TabIndex = 55753;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(0, 538);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(799, 23);
            this.line1.TabIndex = 55751;
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
            this.codeDataGridViewTextBoxColumn,
            this.dgName,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.nationalCodeDataGridViewTextBoxColumn,
            this.idCodeDataGridViewTextBoxColumn,
            this.fatherNameDataGridViewTextBoxColumn,
            this.placeBirthDataGridViewTextBoxColumn,
            this.dateBirthDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.issuedFromDataGridViewTextBoxColumn,
            this.postalCodeDataGridViewTextBoxColumn,
            this.groupGuidDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.peopleBindingSource;
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
            this.DGrid.Size = new System.Drawing.Size(654, 468);
            this.DGrid.TabIndex = 55752;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            this.DGrid.DoubleClick += new System.EventHandler(this.DGrid_DoubleClick);
            this.DGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DGrid_KeyPress);
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 50;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "کد";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgName
            // 
            this.dgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgName.DataPropertyName = "Name";
            this.dgName.HeaderText = "عنوان";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
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
            // nationalCodeDataGridViewTextBoxColumn
            // 
            this.nationalCodeDataGridViewTextBoxColumn.DataPropertyName = "NationalCode";
            this.nationalCodeDataGridViewTextBoxColumn.HeaderText = "NationalCode";
            this.nationalCodeDataGridViewTextBoxColumn.Name = "nationalCodeDataGridViewTextBoxColumn";
            this.nationalCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.nationalCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // idCodeDataGridViewTextBoxColumn
            // 
            this.idCodeDataGridViewTextBoxColumn.DataPropertyName = "IdCode";
            this.idCodeDataGridViewTextBoxColumn.HeaderText = "IdCode";
            this.idCodeDataGridViewTextBoxColumn.Name = "idCodeDataGridViewTextBoxColumn";
            this.idCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // fatherNameDataGridViewTextBoxColumn
            // 
            this.fatherNameDataGridViewTextBoxColumn.DataPropertyName = "FatherName";
            this.fatherNameDataGridViewTextBoxColumn.HeaderText = "FatherName";
            this.fatherNameDataGridViewTextBoxColumn.Name = "fatherNameDataGridViewTextBoxColumn";
            this.fatherNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fatherNameDataGridViewTextBoxColumn.Visible = false;
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
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Visible = false;
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
            // peopleBindingSource
            // 
            this.peopleBindingSource.DataSource = typeof(EntityCache.Bussines.PeoplesBussines);
            // 
            // trvGroup
            // 
            this.trvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvGroup.BackColor = System.Drawing.Color.White;
            this.trvGroup.ForeColor = System.Drawing.Color.Black;
            this.trvGroup.Location = new System.Drawing.Point(660, 70);
            this.trvGroup.Name = "trvGroup";
            this.trvGroup.RightToLeftLayout = true;
            this.trvGroup.Size = new System.Drawing.Size(135, 468);
            this.trvGroup.TabIndex = 55759;
            this.trvGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvGroup_AfterSelect);
            // 
            // btnView
            // 
            this.btnView.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnView.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.Image = global::Peoples.Properties.Resources.article_1_;
            this.btnView.Location = new System.Drawing.Point(202, 559);
            this.btnView.Name = "btnView";
            this.btnView.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnView.Size = new System.Drawing.Size(125, 31);
            this.btnView.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnView.TabIndex = 55754;
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
            this.btnChangeStatus.Image = global::Peoples.Properties.Resources.refresh_round_symbol;
            this.btnChangeStatus.Location = new System.Drawing.Point(71, 559);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnChangeStatus.Size = new System.Drawing.Size(125, 31);
            this.btnChangeStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnChangeStatus.TabIndex = 55756;
            this.btnChangeStatus.Text = "غیرفعال (Ctrl+S)";
            this.btnChangeStatus.TextColor = System.Drawing.Color.Black;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = global::Peoples.Properties.Resources.delete_1_;
            this.btnDelete.Location = new System.Drawing.Point(333, 559);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelete.Size = new System.Drawing.Size(125, 31);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelete.TabIndex = 55755;
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
            this.btnInsert.Image = global::Peoples.Properties.Resources.add_1_;
            this.btnInsert.Location = new System.Drawing.Point(595, 559);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnInsert.Size = new System.Drawing.Size(125, 31);
            this.btnInsert.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnInsert.TabIndex = 55757;
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
            this.btnEdit.Image = global::Peoples.Properties.Resources.edit_1_;
            this.btnEdit.Location = new System.Drawing.Point(464, 559);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnEdit.Size = new System.Drawing.Size(125, 31);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnEdit.TabIndex = 55758;
            this.btnEdit.Text = "ویرایش (F7)";
            this.btnEdit.TextColor = System.Drawing.Color.Black;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGroups
            // 
            this.btnGroups.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroups.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGroups.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnGroups.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGroups.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.btnGroups.Location = new System.Drawing.Point(726, 559);
            this.btnGroups.Name = "btnGroups";
            this.btnGroups.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnGroups.Size = new System.Drawing.Size(69, 31);
            this.btnGroups.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnGroups.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnInsGroup,
            this.btnUpGroup,
            this.btnDelGroup});
            this.btnGroups.TabIndex = 55757;
            this.btnGroups.Text = "گروه ها";
            this.btnGroups.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnGroups.TextColor = System.Drawing.Color.Black;
            // 
            // btnInsGroup
            // 
            this.btnInsGroup.GlobalItem = false;
            this.btnInsGroup.Name = "btnInsGroup";
            this.btnInsGroup.Text = "افزودن گروه جدید";
            this.btnInsGroup.Click += new System.EventHandler(this.btnInsGroup_Click);
            // 
            // btnUpGroup
            // 
            this.btnUpGroup.GlobalItem = false;
            this.btnUpGroup.Name = "btnUpGroup";
            this.btnUpGroup.Text = "ویرایش گروه جاری";
            this.btnUpGroup.Click += new System.EventHandler(this.btnUpGroup_Click);
            // 
            // btnDelGroup
            // 
            this.btnDelGroup.GlobalItem = false;
            this.btnDelGroup.Name = "btnDelGroup";
            this.btnDelGroup.Text = "حذف گروه جاری";
            this.btnDelGroup.Click += new System.EventHandler(this.btnDelGroup_Click);
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
            this.btnTell,
            this.btnBank,
            this.btnSendSMS,
            this.btnIpmortFromExcel,
            this.btnExportToExcel,
            this.btnPrint});
            this.btnOther.TabIndex = 55756;
            this.btnOther.Text = "سایر";
            this.btnOther.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnOther.TextColor = System.Drawing.Color.Black;
            // 
            // btnTell
            // 
            this.btnTell.GlobalItem = false;
            this.btnTell.Name = "btnTell";
            this.btnTell.Text = "مشاهده اطلاعات تماس";
            this.btnTell.Click += new System.EventHandler(this.btnTell_Click);
            // 
            // btnBank
            // 
            this.btnBank.GlobalItem = false;
            this.btnBank.Name = "btnBank";
            this.btnBank.Text = "مشاهده اطلاعات حساب های بانکی";
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.GlobalItem = false;
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Text = "ارسال پیامک";
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // btnIpmortFromExcel
            // 
            this.btnIpmortFromExcel.Name = "btnIpmortFromExcel";
            this.btnIpmortFromExcel.Text = "دریافت داده ها از فایل اکسل";
            this.btnIpmortFromExcel.Click += new System.EventHandler(this.btnIpmortFromExcel_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Text = "ارسال داده ها به فایل اکسل";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSelect.Location = new System.Drawing.Point(217, 559);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSelect.Size = new System.Drawing.Size(414, 31);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSelect.TabIndex = 55760;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.TextColor = System.Drawing.Color.White;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(EntityCache.Bussines.PeopleGroupBussines);
            // 
            // btnPrint
            // 
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Text = "چاپ لیست اشخاص";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmShowPeoples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.trvGroup);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnGroups);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowPeoples";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowPeoples_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowPeoples_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnView;
        private DevComponents.DotNetBar.ButtonX btnChangeStatus;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.BindingSource peopleBindingSource;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnInsert;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.TreeView trvGroup;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatherNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuedFromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postalCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupGuidDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.ButtonX btnGroups;
        private DevComponents.DotNetBar.ButtonItem btnInsGroup;
        private DevComponents.DotNetBar.ButtonItem btnUpGroup;
        private DevComponents.DotNetBar.ButtonItem btnDelGroup;
        private DevComponents.DotNetBar.ButtonX btnOther;
        private DevComponents.DotNetBar.ButtonItem btnTell;
        private DevComponents.DotNetBar.ButtonItem btnBank;
        private DevComponents.DotNetBar.ButtonItem btnSendSMS;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonItem btnIpmortFromExcel;
        private DevComponents.DotNetBar.ButtonItem btnExportToExcel;
        private DevComponents.DotNetBar.ButtonItem btnPrint;
    }
}