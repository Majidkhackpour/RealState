namespace User
{
    partial class frmAccessLevel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccessLevel));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DGPart = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.persianNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label76 = new System.Windows.Forms.Label();
            this.DGAccess = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.DGAccessValue = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGAccessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ckeckAllDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.propInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PropInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.ucHeader = new WindowsSerivces.UC_Header();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGPart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 73);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DGPart);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(795, 462);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 0;
            // 
            // DGPart
            // 
            this.DGPart.AllowUserToAddRows = false;
            this.DGPart.AllowUserToDeleteRows = false;
            this.DGPart.AllowUserToResizeColumns = false;
            this.DGPart.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DGPart.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGPart.AutoGenerateColumns = false;
            this.DGPart.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGPart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGPart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.persianNameDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.infoDataGridViewTextBoxColumn,
            this.checkedDataGridViewTextBoxColumn});
            this.DGPart.DataSource = this.ClassInfoBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGPart.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGPart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGPart.Location = new System.Drawing.Point(0, 0);
            this.DGPart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGPart.Name = "DGPart";
            this.DGPart.ReadOnly = true;
            this.DGPart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGPart.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGPart.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGPart.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DGPart.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGPart.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGPart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGPart.Size = new System.Drawing.Size(317, 462);
            this.DGPart.TabIndex = 55708;
            this.DGPart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGPart_CellContentClick);
            this.DGPart.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGPart_CellEnter);
            this.DGPart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGPart_CellValueChanged);
            // 
            // persianNameDataGridViewTextBoxColumn
            // 
            this.persianNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.persianNameDataGridViewTextBoxColumn.DataPropertyName = "PersianName";
            this.persianNameDataGridViewTextBoxColumn.HeaderText = "عنوان";
            this.persianNameDataGridViewTextBoxColumn.Name = "persianNameDataGridViewTextBoxColumn";
            this.persianNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // infoDataGridViewTextBoxColumn
            // 
            this.infoDataGridViewTextBoxColumn.DataPropertyName = "info";
            this.infoDataGridViewTextBoxColumn.HeaderText = "info";
            this.infoDataGridViewTextBoxColumn.Name = "infoDataGridViewTextBoxColumn";
            this.infoDataGridViewTextBoxColumn.ReadOnly = true;
            this.infoDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkedDataGridViewTextBoxColumn
            // 
            this.checkedDataGridViewTextBoxColumn.DataPropertyName = "Checked";
            this.checkedDataGridViewTextBoxColumn.HeaderText = "Checked";
            this.checkedDataGridViewTextBoxColumn.Name = "checkedDataGridViewTextBoxColumn";
            this.checkedDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkedDataGridViewTextBoxColumn.Visible = false;
            // 
            // ClassInfoBindingSource
            // 
            this.ClassInfoBindingSource.DataSource = typeof(User.AccessLevel.AccessLevelClass);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cmbUser);
            this.splitContainer2.Panel1.Controls.Add(this.label76);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.DGAccess);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(474, 462);
            this.splitContainer2.SplitterDistance = 89;
            this.splitContainer2.TabIndex = 0;
            // 
            // cmbUser
            // 
            this.cmbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUser.DataSource = this.UserBindingSource;
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(23, 23);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(393, 28);
            this.cmbUser.TabIndex = 25;
            this.cmbUser.ValueMember = "Guid";
            this.cmbUser.SelectedIndexChanged += new System.EventHandler(this.cmbUser_SelectedIndexChanged);
            // 
            // UserBindingSource
            // 
            this.UserBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // label76
            // 
            this.label76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Location = new System.Drawing.Point(435, 26);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(33, 20);
            this.label76.TabIndex = 26;
            this.label76.Text = "کاربر";
            // 
            // DGAccess
            // 
            this.DGAccess.AllowUserToAddRows = false;
            this.DGAccess.AllowUserToDeleteRows = false;
            this.DGAccess.AllowUserToResizeColumns = false;
            this.DGAccess.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGAccess.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGAccess.AutoGenerateColumns = false;
            this.DGAccess.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGAccess.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGAccess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGAccessValue,
            this.DGAccessName,
            this.nameDataGridViewTextBoxColumn1,
            this.ckeckAllDataGridViewTextBoxColumn,
            this.propInfoDataGridViewTextBoxColumn});
            this.DGAccess.DataSource = this.PropInfoBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGAccess.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGAccess.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGAccess.Location = new System.Drawing.Point(0, 0);
            this.DGAccess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGAccess.Name = "DGAccess";
            this.DGAccess.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGAccess.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGAccess.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DGAccess.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.DGAccess.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGAccess.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGAccess.Size = new System.Drawing.Size(474, 369);
            this.DGAccess.TabIndex = 55709;
            this.DGAccess.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGAccess_CellValueChanged);
            // 
            // DGAccessValue
            // 
            this.DGAccessValue.DataPropertyName = "Checked";
            this.DGAccessValue.HeaderText = "";
            this.DGAccessValue.Name = "DGAccessValue";
            this.DGAccessValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGAccessValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGAccessValue.Width = 30;
            // 
            // DGAccessName
            // 
            this.DGAccessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGAccessName.DataPropertyName = "PersianName";
            this.DGAccessName.HeaderText = "عنوان";
            this.DGAccessName.Name = "DGAccessName";
            this.DGAccessName.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.Visible = false;
            // 
            // ckeckAllDataGridViewTextBoxColumn
            // 
            this.ckeckAllDataGridViewTextBoxColumn.DataPropertyName = "CkeckAll";
            this.ckeckAllDataGridViewTextBoxColumn.HeaderText = "CkeckAll";
            this.ckeckAllDataGridViewTextBoxColumn.Name = "ckeckAllDataGridViewTextBoxColumn";
            this.ckeckAllDataGridViewTextBoxColumn.Visible = false;
            // 
            // propInfoDataGridViewTextBoxColumn
            // 
            this.propInfoDataGridViewTextBoxColumn.DataPropertyName = "propInfo";
            this.propInfoDataGridViewTextBoxColumn.HeaderText = "propInfo";
            this.propInfoDataGridViewTextBoxColumn.Name = "propInfoDataGridViewTextBoxColumn";
            this.propInfoDataGridViewTextBoxColumn.Visible = false;
            // 
            // PropInfoBindingSource
            // 
            this.PropInfoBindingSource.DataSource = typeof(User.AccessLevel.PropertyInfoClass);
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
            this.btnCancel.Image = global::User.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(25, 555);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 4;
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
            this.btnFinish.Image = global::User.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(656, 555);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            this.ucHeader.Location = new System.Drawing.Point(0, 30);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55757;
            // 
            // frmAccessLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmAccessLevel";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAccessLevel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccessLevel_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGPart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassInfoBindingSource)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PropInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGPart;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGAccess;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.BindingSource ClassInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn persianNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn infoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkedDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource UserBindingSource;
        private System.Windows.Forms.BindingSource PropInfoBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGAccessValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGAccessName;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ckeckAllDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn propInfoDataGridViewTextBoxColumn;
        private WindowsSerivces.UC_Header ucHeader;
    }
}