
namespace Accounting.Pardakht
{
    partial class frmShowPardakht
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPardakht));
            this.PardakhtBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.dgNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tafsilNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumNaqdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumHavaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCheckShakhsiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumCheckMoshtariDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tafsilGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moeinGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moeinNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sanadNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countNaqdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countHavaleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCheckMoshtariDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countCheckShakhsiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.naqdDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.havaleDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkShDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkMDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PardakhtBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PardakhtBindingSource
            // 
            this.PardakhtBindingSource.DataSource = typeof(EntityCache.Bussines.PardakhtBussines);
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
            this.dgNumber,
            this.dateShDataGridViewTextBoxColumn,
            this.tafsilNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.sumNaqdDataGridViewTextBoxColumn,
            this.sumHavaleDataGridViewTextBoxColumn,
            this.sumCheckShakhsiDataGridViewTextBoxColumn,
            this.sumCheckMoshtariDataGridViewTextBoxColumn,
            this.dgSum,
            this.userNameDataGridViewTextBoxColumn,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.tafsilGuidDataGridViewTextBoxColumn,
            this.moeinGuidDataGridViewTextBoxColumn,
            this.moeinNameDataGridViewTextBoxColumn,
            this.dateMDataGridViewTextBoxColumn,
            this.userGuidDataGridViewTextBoxColumn,
            this.sanadNumberDataGridViewTextBoxColumn,
            this.countNaqdDataGridViewTextBoxColumn,
            this.countHavaleDataGridViewTextBoxColumn,
            this.countCheckMoshtariDataGridViewTextBoxColumn,
            this.countCheckShakhsiDataGridViewTextBoxColumn,
            this.naqdDescDataGridViewTextBoxColumn,
            this.havaleDescDataGridViewTextBoxColumn,
            this.checkShDescDataGridViewTextBoxColumn,
            this.checkMDescDataGridViewTextBoxColumn});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            this.DGrid.DataSource = this.PardakhtBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(3, 66);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(793, 528);
            this.DGrid.TabIndex = 55757;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDelete,
            this.toolStripMenuItem1,
            this.mnuView});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(215, 106);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(214, 24);
            this.mnuAdd.Text = "افزودن پرداخت جدید (Ins)";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Accounting.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(214, 24);
            this.mnuEdit.Text = "ویرایش پرداخت جاری (F7)";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Accounting.Properties.Resources.delete_1_;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(214, 24);
            this.mnuDelete.Text = "حذف پرداخت جاری (Del)";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Accounting.Properties.Resources.article_1_;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(214, 24);
            this.mnuView.Text = "مشاهده (F12)";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
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
            this.txtSearch.Location = new System.Drawing.Point(149, 26);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(476, 27);
            this.txtSearch.TabIndex = 55756;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgNumber
            // 
            this.dgNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgNumber.DataPropertyName = "Number";
            this.dgNumber.HeaderText = "شماره";
            this.dgNumber.Name = "dgNumber";
            this.dgNumber.ReadOnly = true;
            this.dgNumber.Width = 63;
            // 
            // dateShDataGridViewTextBoxColumn
            // 
            this.dateShDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateShDataGridViewTextBoxColumn.DataPropertyName = "DateSh";
            this.dateShDataGridViewTextBoxColumn.HeaderText = "تاریخ";
            this.dateShDataGridViewTextBoxColumn.Name = "dateShDataGridViewTextBoxColumn";
            this.dateShDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateShDataGridViewTextBoxColumn.Width = 58;
            // 
            // tafsilNameDataGridViewTextBoxColumn
            // 
            this.tafsilNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tafsilNameDataGridViewTextBoxColumn.DataPropertyName = "TafsilName";
            this.tafsilNameDataGridViewTextBoxColumn.HeaderText = "طرف حساب";
            this.tafsilNameDataGridViewTextBoxColumn.Name = "tafsilNameDataGridViewTextBoxColumn";
            this.tafsilNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "شرح";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumNaqdDataGridViewTextBoxColumn
            // 
            this.sumNaqdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sumNaqdDataGridViewTextBoxColumn.DataPropertyName = "SumNaqd";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.sumNaqdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.sumNaqdDataGridViewTextBoxColumn.HeaderText = "جمع نقد";
            this.sumNaqdDataGridViewTextBoxColumn.Name = "sumNaqdDataGridViewTextBoxColumn";
            this.sumNaqdDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumNaqdDataGridViewTextBoxColumn.Width = 73;
            // 
            // sumHavaleDataGridViewTextBoxColumn
            // 
            this.sumHavaleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sumHavaleDataGridViewTextBoxColumn.DataPropertyName = "SumHavale";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.sumHavaleDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.sumHavaleDataGridViewTextBoxColumn.HeaderText = "جمع حواله";
            this.sumHavaleDataGridViewTextBoxColumn.Name = "sumHavaleDataGridViewTextBoxColumn";
            this.sumHavaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumHavaleDataGridViewTextBoxColumn.Width = 84;
            // 
            // sumCheckShakhsiDataGridViewTextBoxColumn
            // 
            this.sumCheckShakhsiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sumCheckShakhsiDataGridViewTextBoxColumn.DataPropertyName = "SumCheckShakhsi";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.sumCheckShakhsiDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.sumCheckShakhsiDataGridViewTextBoxColumn.HeaderText = "جمع چک شخصی";
            this.sumCheckShakhsiDataGridViewTextBoxColumn.Name = "sumCheckShakhsiDataGridViewTextBoxColumn";
            this.sumCheckShakhsiDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumCheckShakhsiDataGridViewTextBoxColumn.Width = 112;
            // 
            // sumCheckMoshtariDataGridViewTextBoxColumn
            // 
            this.sumCheckMoshtariDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sumCheckMoshtariDataGridViewTextBoxColumn.DataPropertyName = "SumCheckMoshtari";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.sumCheckMoshtariDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.sumCheckMoshtariDataGridViewTextBoxColumn.HeaderText = "جمع چک مشتری";
            this.sumCheckMoshtariDataGridViewTextBoxColumn.Name = "sumCheckMoshtariDataGridViewTextBoxColumn";
            this.sumCheckMoshtariDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumCheckMoshtariDataGridViewTextBoxColumn.Width = 112;
            // 
            // dgSum
            // 
            this.dgSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgSum.DataPropertyName = "Sum";
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.dgSum.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgSum.HeaderText = "جمع کل";
            this.dgSum.Name = "dgSum";
            this.dgSum.ReadOnly = true;
            this.dgSum.Width = 71;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "کاربر";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 58;
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
            // tafsilGuidDataGridViewTextBoxColumn
            // 
            this.tafsilGuidDataGridViewTextBoxColumn.DataPropertyName = "TafsilGuid";
            this.tafsilGuidDataGridViewTextBoxColumn.HeaderText = "TafsilGuid";
            this.tafsilGuidDataGridViewTextBoxColumn.Name = "tafsilGuidDataGridViewTextBoxColumn";
            this.tafsilGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.tafsilGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // moeinGuidDataGridViewTextBoxColumn
            // 
            this.moeinGuidDataGridViewTextBoxColumn.DataPropertyName = "MoeinGuid";
            this.moeinGuidDataGridViewTextBoxColumn.HeaderText = "MoeinGuid";
            this.moeinGuidDataGridViewTextBoxColumn.Name = "moeinGuidDataGridViewTextBoxColumn";
            this.moeinGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.moeinGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // moeinNameDataGridViewTextBoxColumn
            // 
            this.moeinNameDataGridViewTextBoxColumn.DataPropertyName = "MoeinName";
            this.moeinNameDataGridViewTextBoxColumn.HeaderText = "MoeinName";
            this.moeinNameDataGridViewTextBoxColumn.Name = "moeinNameDataGridViewTextBoxColumn";
            this.moeinNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.moeinNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateMDataGridViewTextBoxColumn
            // 
            this.dateMDataGridViewTextBoxColumn.DataPropertyName = "DateM";
            this.dateMDataGridViewTextBoxColumn.HeaderText = "DateM";
            this.dateMDataGridViewTextBoxColumn.Name = "dateMDataGridViewTextBoxColumn";
            this.dateMDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateMDataGridViewTextBoxColumn.Visible = false;
            // 
            // userGuidDataGridViewTextBoxColumn
            // 
            this.userGuidDataGridViewTextBoxColumn.DataPropertyName = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.HeaderText = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.Name = "userGuidDataGridViewTextBoxColumn";
            this.userGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.userGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // sanadNumberDataGridViewTextBoxColumn
            // 
            this.sanadNumberDataGridViewTextBoxColumn.DataPropertyName = "SanadNumber";
            this.sanadNumberDataGridViewTextBoxColumn.HeaderText = "SanadNumber";
            this.sanadNumberDataGridViewTextBoxColumn.Name = "sanadNumberDataGridViewTextBoxColumn";
            this.sanadNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.sanadNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // countNaqdDataGridViewTextBoxColumn
            // 
            this.countNaqdDataGridViewTextBoxColumn.DataPropertyName = "CountNaqd";
            this.countNaqdDataGridViewTextBoxColumn.HeaderText = "CountNaqd";
            this.countNaqdDataGridViewTextBoxColumn.Name = "countNaqdDataGridViewTextBoxColumn";
            this.countNaqdDataGridViewTextBoxColumn.ReadOnly = true;
            this.countNaqdDataGridViewTextBoxColumn.Visible = false;
            // 
            // countHavaleDataGridViewTextBoxColumn
            // 
            this.countHavaleDataGridViewTextBoxColumn.DataPropertyName = "CountHavale";
            this.countHavaleDataGridViewTextBoxColumn.HeaderText = "CountHavale";
            this.countHavaleDataGridViewTextBoxColumn.Name = "countHavaleDataGridViewTextBoxColumn";
            this.countHavaleDataGridViewTextBoxColumn.ReadOnly = true;
            this.countHavaleDataGridViewTextBoxColumn.Visible = false;
            // 
            // countCheckMoshtariDataGridViewTextBoxColumn
            // 
            this.countCheckMoshtariDataGridViewTextBoxColumn.DataPropertyName = "CountCheckMoshtari";
            this.countCheckMoshtariDataGridViewTextBoxColumn.HeaderText = "CountCheckMoshtari";
            this.countCheckMoshtariDataGridViewTextBoxColumn.Name = "countCheckMoshtariDataGridViewTextBoxColumn";
            this.countCheckMoshtariDataGridViewTextBoxColumn.ReadOnly = true;
            this.countCheckMoshtariDataGridViewTextBoxColumn.Visible = false;
            // 
            // countCheckShakhsiDataGridViewTextBoxColumn
            // 
            this.countCheckShakhsiDataGridViewTextBoxColumn.DataPropertyName = "CountCheckShakhsi";
            this.countCheckShakhsiDataGridViewTextBoxColumn.HeaderText = "CountCheckShakhsi";
            this.countCheckShakhsiDataGridViewTextBoxColumn.Name = "countCheckShakhsiDataGridViewTextBoxColumn";
            this.countCheckShakhsiDataGridViewTextBoxColumn.ReadOnly = true;
            this.countCheckShakhsiDataGridViewTextBoxColumn.Visible = false;
            // 
            // naqdDescDataGridViewTextBoxColumn
            // 
            this.naqdDescDataGridViewTextBoxColumn.DataPropertyName = "NaqdDesc";
            this.naqdDescDataGridViewTextBoxColumn.HeaderText = "NaqdDesc";
            this.naqdDescDataGridViewTextBoxColumn.Name = "naqdDescDataGridViewTextBoxColumn";
            this.naqdDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.naqdDescDataGridViewTextBoxColumn.Visible = false;
            // 
            // havaleDescDataGridViewTextBoxColumn
            // 
            this.havaleDescDataGridViewTextBoxColumn.DataPropertyName = "HavaleDesc";
            this.havaleDescDataGridViewTextBoxColumn.HeaderText = "HavaleDesc";
            this.havaleDescDataGridViewTextBoxColumn.Name = "havaleDescDataGridViewTextBoxColumn";
            this.havaleDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.havaleDescDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkShDescDataGridViewTextBoxColumn
            // 
            this.checkShDescDataGridViewTextBoxColumn.DataPropertyName = "CheckShDesc";
            this.checkShDescDataGridViewTextBoxColumn.HeaderText = "CheckShDesc";
            this.checkShDescDataGridViewTextBoxColumn.Name = "checkShDescDataGridViewTextBoxColumn";
            this.checkShDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkShDescDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkMDescDataGridViewTextBoxColumn
            // 
            this.checkMDescDataGridViewTextBoxColumn.DataPropertyName = "CheckMDesc";
            this.checkMDescDataGridViewTextBoxColumn.HeaderText = "CheckMDesc";
            this.checkMDescDataGridViewTextBoxColumn.Name = "checkMDescDataGridViewTextBoxColumn";
            this.checkMDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkMDescDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmShowPardakht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.DGrid);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowPardakht";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowPardakht_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowPardakht_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PardakhtBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource PardakhtBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tafsilNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumNaqdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumHavaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCheckShakhsiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumCheckMoshtariDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tafsilGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moeinGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moeinNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sanadNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countNaqdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countHavaleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCheckMoshtariDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countCheckShakhsiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn naqdDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn havaleDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkShDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkMDescDataGridViewTextBoxColumn;
    }
}