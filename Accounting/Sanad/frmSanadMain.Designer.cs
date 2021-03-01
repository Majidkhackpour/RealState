
namespace Accounting.Sanad
{
    partial class frmSanadMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanadMain));
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.txtNumber = new System.Windows.Forms.NumericUpDown();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtDate = new BPersianCalender.BPersianCalenderTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.SanadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSumCredit = new System.Windows.Forms.Label();
            this.lblSumDebit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.txtCredit = new WindowsSerivces.CurrencyTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDebit = new WindowsSerivces.CurrencyTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSaveArticle = new DevComponents.DotNetBar.ButtonX();
            this.btnTafsilSearch = new DevComponents.DotNetBar.ButtonX();
            this.btnMoeinSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtTafsilName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMoeinName = new System.Windows.Forms.TextBox();
            this.txtRowDesc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMoeinCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMoeinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTafsilCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTafsilName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.masterGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moeinGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tafsilGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SanadBindingSource)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.txtNumber);
            this.grp.Controls.Add(this.cmbType);
            this.grp.Controls.Add(this.txtDate);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txtDesc);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.label7);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(6, 24);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(786, 86);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grp.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 0;
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumber.Location = new System.Drawing.Point(294, 10);
            this.txtNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(145, 27);
            this.txtNumber.TabIndex = 0;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbType.DisplayMember = "Name";
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(16, 9);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(212, 28);
            this.cmbType.TabIndex = 1;
            this.cmbType.ValueMember = "Guid";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.Location = new System.Drawing.Point(523, 12);
            this.txtDate.Miladi = new System.DateTime(2020, 10, 25, 17, 11, 28, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.NowDateSelected = false;
            this.txtDate.ReadOnly = true;
            this.txtDate.SelectedDate = null;
            this.txtDate.Shamsi = null;
            this.txtDate.Size = new System.Drawing.Size(194, 27);
            this.txtDate.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(234, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "نوع سند";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(744, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "تاریخ";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.Location = new System.Drawing.Point(16, 44);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(701, 27);
            this.txtDesc.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(723, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "شرح سند";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(445, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "شماره سند";
            // 
            // panelEx1
            // 
            this.panelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.DGrid);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(6, 277);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(786, 214);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
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
            this.dgMoeinCode,
            this.dgMoeinName,
            this.dgTafsilCode,
            this.dgTafsilName,
            this.dgDesc,
            this.dgDebit,
            this.dgCredit,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.masterGuidDataGridViewTextBoxColumn,
            this.moeinGuidDataGridViewTextBoxColumn,
            this.tafsilGuidDataGridViewTextBoxColumn});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            this.DGrid.DataSource = this.SanadBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(8, 10);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.MultiSelect = false;
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(770, 190);
            this.DGrid.TabIndex = 0;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(198, 74);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Accounting.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(197, 24);
            this.mnuEdit.Text = "ویرایش سطر جاری (F7)";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Accounting.Properties.Resources.delete_1_;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(197, 24);
            this.mnuDelete.Text = "حذف سطر جاری (Del)";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // SanadBindingSource
            // 
            this.SanadBindingSource.DataSource = typeof(EntityCache.Bussines.SanadDetailBussines);
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.label5);
            this.panelEx2.Controls.Add(this.lblSumCredit);
            this.panelEx2.Controls.Add(this.lblSumDebit);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(6, 497);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(786, 55);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx2.Style.BorderWidth = 2;
            this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 55762;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(313, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "جمع بستانکار:";
            // 
            // lblSumCredit
            // 
            this.lblSumCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumCredit.BackColor = System.Drawing.Color.Transparent;
            this.lblSumCredit.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumCredit.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblSumCredit.Location = new System.Drawing.Point(24, 14);
            this.lblSumCredit.Name = "lblSumCredit";
            this.lblSumCredit.Size = new System.Drawing.Size(284, 24);
            this.lblSumCredit.TabIndex = 5;
            this.lblSumCredit.Text = "00 ریال";
            // 
            // lblSumDebit
            // 
            this.lblSumDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumDebit.BackColor = System.Drawing.Color.Transparent;
            this.lblSumDebit.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumDebit.ForeColor = System.Drawing.Color.Red;
            this.lblSumDebit.Location = new System.Drawing.Point(403, 14);
            this.lblSumDebit.Name = "lblSumDebit";
            this.lblSumDebit.Size = new System.Drawing.Size(284, 24);
            this.lblSumDebit.TabIndex = 5;
            this.lblSumDebit.Text = "00 ریال";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(693, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "جمع بدهکار:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Accounting.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(44, 558);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Accounting.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(611, 558);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // panelEx3
            // 
            this.panelEx3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.txtCredit);
            this.panelEx3.Controls.Add(this.label10);
            this.panelEx3.Controls.Add(this.txtDebit);
            this.panelEx3.Controls.Add(this.label16);
            this.panelEx3.Controls.Add(this.btnSaveArticle);
            this.panelEx3.Controls.Add(this.btnTafsilSearch);
            this.panelEx3.Controls.Add(this.btnMoeinSearch);
            this.panelEx3.Controls.Add(this.txtTafsilName);
            this.panelEx3.Controls.Add(this.label8);
            this.panelEx3.Controls.Add(this.txtMoeinName);
            this.panelEx3.Controls.Add(this.txtRowDesc);
            this.panelEx3.Controls.Add(this.label9);
            this.panelEx3.Controls.Add(this.label6);
            this.panelEx3.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx3.Location = new System.Drawing.Point(6, 116);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(786, 155);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx3.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx3.Style.BorderWidth = 2;
            this.panelEx3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 1;
            // 
            // txtCredit
            // 
            this.txtCredit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredit.BackColor = System.Drawing.Color.White;
            this.txtCredit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtCredit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCredit.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCredit.Location = new System.Drawing.Point(16, 74);
            this.txtCredit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(272, 31);
            this.txtCredit.TabIndex = 4;
            this.txtCredit.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(305, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "بستانکار";
            // 
            // txtDebit
            // 
            this.txtDebit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebit.BackColor = System.Drawing.Color.White;
            this.txtDebit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtDebit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDebit.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDebit.Location = new System.Drawing.Point(445, 74);
            this.txtDebit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(272, 31);
            this.txtDebit.TabIndex = 3;
            this.txtDebit.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(734, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 20);
            this.label16.TabIndex = 20;
            this.label16.Text = "بدهکار";
            // 
            // btnSaveArticle
            // 
            this.btnSaveArticle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveArticle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveArticle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaveArticle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveArticle.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSaveArticle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveArticle.Location = new System.Drawing.Point(16, 113);
            this.btnSaveArticle.Name = "btnSaveArticle";
            this.btnSaveArticle.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSaveArticle.Size = new System.Drawing.Size(147, 27);
            this.btnSaveArticle.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSaveArticle.TabIndex = 5;
            this.btnSaveArticle.Text = "ثبت در سند (F1)";
            this.btnSaveArticle.TextColor = System.Drawing.Color.White;
            this.btnSaveArticle.Click += new System.EventHandler(this.btnSaveArticle_Click);
            // 
            // btnTafsilSearch
            // 
            this.btnTafsilSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTafsilSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTafsilSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTafsilSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTafsilSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTafsilSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTafsilSearch.Location = new System.Drawing.Point(179, 8);
            this.btnTafsilSearch.Name = "btnTafsilSearch";
            this.btnTafsilSearch.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnTafsilSearch.Size = new System.Drawing.Size(30, 27);
            this.btnTafsilSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnTafsilSearch.TabIndex = 1;
            this.btnTafsilSearch.Text = "...";
            this.btnTafsilSearch.TextColor = System.Drawing.Color.White;
            this.btnTafsilSearch.Click += new System.EventHandler(this.btnTafsilSearch_Click);
            // 
            // btnMoeinSearch
            // 
            this.btnMoeinSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoeinSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoeinSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnMoeinSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMoeinSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMoeinSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoeinSearch.Location = new System.Drawing.Point(487, 8);
            this.btnMoeinSearch.Name = "btnMoeinSearch";
            this.btnMoeinSearch.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnMoeinSearch.Size = new System.Drawing.Size(30, 27);
            this.btnMoeinSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnMoeinSearch.TabIndex = 0;
            this.btnMoeinSearch.Text = "...";
            this.btnMoeinSearch.TextColor = System.Drawing.Color.White;
            this.btnMoeinSearch.Click += new System.EventHandler(this.btnMoeinSearch_Click);
            // 
            // txtTafsilName
            // 
            this.txtTafsilName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTafsilName.Enabled = false;
            this.txtTafsilName.Location = new System.Drawing.Point(215, 8);
            this.txtTafsilName.Name = "txtTafsilName";
            this.txtTafsilName.ReadOnly = true;
            this.txtTafsilName.Size = new System.Drawing.Size(139, 27);
            this.txtTafsilName.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(360, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "شناسایی حساب تفصیلی";
            // 
            // txtMoeinName
            // 
            this.txtMoeinName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoeinName.Enabled = false;
            this.txtMoeinName.Location = new System.Drawing.Point(523, 8);
            this.txtMoeinName.Name = "txtMoeinName";
            this.txtMoeinName.ReadOnly = true;
            this.txtMoeinName.Size = new System.Drawing.Size(139, 27);
            this.txtMoeinName.TabIndex = 13;
            // 
            // txtRowDesc
            // 
            this.txtRowDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRowDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRowDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRowDesc.Location = new System.Drawing.Point(16, 41);
            this.txtRowDesc.Name = "txtRowDesc";
            this.txtRowDesc.Size = new System.Drawing.Size(701, 27);
            this.txtRowDesc.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(723, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "شرح سطر";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(669, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "شناسایی حساب معین";
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 40;
            // 
            // dgMoeinCode
            // 
            this.dgMoeinCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgMoeinCode.DataPropertyName = "MoeinCode";
            this.dgMoeinCode.HeaderText = "کد معین";
            this.dgMoeinCode.Name = "dgMoeinCode";
            this.dgMoeinCode.ReadOnly = true;
            this.dgMoeinCode.Width = 73;
            // 
            // dgMoeinName
            // 
            this.dgMoeinName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgMoeinName.DataPropertyName = "MoeinName";
            this.dgMoeinName.HeaderText = "عنوان حساب معین";
            this.dgMoeinName.Name = "dgMoeinName";
            this.dgMoeinName.ReadOnly = true;
            this.dgMoeinName.Width = 122;
            // 
            // dgTafsilCode
            // 
            this.dgTafsilCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgTafsilCode.DataPropertyName = "TafsilCode";
            this.dgTafsilCode.HeaderText = "کد تفصیلی";
            this.dgTafsilCode.Name = "dgTafsilCode";
            this.dgTafsilCode.ReadOnly = true;
            this.dgTafsilCode.Width = 85;
            // 
            // dgTafsilName
            // 
            this.dgTafsilName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgTafsilName.DataPropertyName = "TafsilName";
            this.dgTafsilName.HeaderText = "عنوان حساب تفصیلی";
            this.dgTafsilName.Name = "dgTafsilName";
            this.dgTafsilName.ReadOnly = true;
            this.dgTafsilName.Width = 134;
            // 
            // dgDesc
            // 
            this.dgDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgDesc.DataPropertyName = "Description";
            this.dgDesc.HeaderText = "شرح سطر";
            this.dgDesc.Name = "dgDesc";
            this.dgDesc.ReadOnly = true;
            // 
            // dgDebit
            // 
            this.dgDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDebit.DataPropertyName = "Debit";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dgDebit.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgDebit.HeaderText = "بدهکار";
            this.dgDebit.Name = "dgDebit";
            this.dgDebit.ReadOnly = true;
            this.dgDebit.Width = 67;
            // 
            // dgCredit
            // 
            this.dgCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCredit.DataPropertyName = "Credit";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dgCredit.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgCredit.HeaderText = "بستانکار";
            this.dgCredit.Name = "dgCredit";
            this.dgCredit.ReadOnly = true;
            this.dgCredit.Width = 75;
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
            // masterGuidDataGridViewTextBoxColumn
            // 
            this.masterGuidDataGridViewTextBoxColumn.DataPropertyName = "MasterGuid";
            this.masterGuidDataGridViewTextBoxColumn.HeaderText = "MasterGuid";
            this.masterGuidDataGridViewTextBoxColumn.Name = "masterGuidDataGridViewTextBoxColumn";
            this.masterGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.masterGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // moeinGuidDataGridViewTextBoxColumn
            // 
            this.moeinGuidDataGridViewTextBoxColumn.DataPropertyName = "MoeinGuid";
            this.moeinGuidDataGridViewTextBoxColumn.HeaderText = "MoeinGuid";
            this.moeinGuidDataGridViewTextBoxColumn.Name = "moeinGuidDataGridViewTextBoxColumn";
            this.moeinGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.moeinGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // tafsilGuidDataGridViewTextBoxColumn
            // 
            this.tafsilGuidDataGridViewTextBoxColumn.DataPropertyName = "TafsilGuid";
            this.tafsilGuidDataGridViewTextBoxColumn.HeaderText = "TafsilGuid";
            this.tafsilGuidDataGridViewTextBoxColumn.Name = "tafsilGuidDataGridViewTextBoxColumn";
            this.tafsilGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.tafsilGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmSanadMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmSanadMain";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSanadMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSanadMain_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SanadBindingSource)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.panelEx3.ResumeLayout(false);
            this.panelEx3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private BPersianCalender.BPersianCalenderTextBox txtDate;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.NumericUpDown txtNumber;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSumCredit;
        private System.Windows.Forms.Label lblSumDebit;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.BindingSource SanadBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private DevComponents.DotNetBar.PanelEx panelEx3;
        private DevComponents.DotNetBar.ButtonX btnTafsilSearch;
        private DevComponents.DotNetBar.ButtonX btnMoeinSearch;
        private System.Windows.Forms.TextBox txtTafsilName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMoeinName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRowDesc;
        private System.Windows.Forms.Label label9;
        private WindowsSerivces.CurrencyTextBox txtCredit;
        private System.Windows.Forms.Label label10;
        private WindowsSerivces.CurrencyTextBox txtDebit;
        private System.Windows.Forms.Label label16;
        private DevComponents.DotNetBar.ButtonX btnSaveArticle;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMoeinCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMoeinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTafsilCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTafsilName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn masterGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moeinGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tafsilGuidDataGridViewTextBoxColumn;
    }
}