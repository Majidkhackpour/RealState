
namespace Accounting.Hesab
{
    partial class frmKolMoein
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKolMoein));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DGridKol = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgKolGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hesabGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearchKol = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DGridMoein = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.codeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgMoeinGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoeinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearchMoein = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.ucHeader = new WindowsSerivces.UC_Header();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridKol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridMoein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoeinBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 56);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DGridKol);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchKol);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DGridMoein);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearchMoein);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(796, 537);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 0;
            // 
            // DGridKol
            // 
            this.DGridKol.AllowUserToAddRows = false;
            this.DGridKol.AllowUserToDeleteRows = false;
            this.DGridKol.AllowUserToResizeColumns = false;
            this.DGridKol.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DGridKol.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGridKol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridKol.AutoGenerateColumns = false;
            this.DGridKol.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGridKol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGridKol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridKol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.accountDataGridViewTextBoxColumn,
            this.Account,
            this.dgKolGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.hesabGroupDataGridViewTextBoxColumn});
            this.DGridKol.DataSource = this.KolBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGridKol.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGridKol.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGridKol.Location = new System.Drawing.Point(3, 50);
            this.DGridKol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGridKol.Name = "DGridKol";
            this.DGridKol.ReadOnly = true;
            this.DGridKol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGridKol.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGridKol.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGridKol.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGridKol.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGridKol.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGridKol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridKol.Size = new System.Drawing.Size(390, 483);
            this.DGridKol.TabIndex = 55747;
            this.DGridKol.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGrid_CellEnter);
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "کد حساب";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 79;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "عنوان حساب کل";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountDataGridViewTextBoxColumn
            // 
            this.accountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.accountDataGridViewTextBoxColumn.DataPropertyName = "Account_";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.accountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.accountDataGridViewTextBoxColumn.HeaderText = "مانده";
            this.accountDataGridViewTextBoxColumn.Name = "accountDataGridViewTextBoxColumn";
            this.accountDataGridViewTextBoxColumn.ReadOnly = true;
            this.accountDataGridViewTextBoxColumn.Width = 58;
            // 
            // Account
            // 
            this.Account.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Account.DataPropertyName = "Diagnosis";
            this.Account.HeaderText = "تشخیص";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Width = 74;
            // 
            // dgKolGuid
            // 
            this.dgKolGuid.DataPropertyName = "Guid";
            this.dgKolGuid.HeaderText = "Guid";
            this.dgKolGuid.Name = "dgKolGuid";
            this.dgKolGuid.ReadOnly = true;
            this.dgKolGuid.Visible = false;
            // 
            // modifiedDataGridViewTextBoxColumn
            // 
            this.modifiedDataGridViewTextBoxColumn.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn.Name = "modifiedDataGridViewTextBoxColumn";
            this.modifiedDataGridViewTextBoxColumn.ReadOnly = true;
            this.modifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // hesabGroupDataGridViewTextBoxColumn
            // 
            this.hesabGroupDataGridViewTextBoxColumn.DataPropertyName = "HesabGroup";
            this.hesabGroupDataGridViewTextBoxColumn.HeaderText = "HesabGroup";
            this.hesabGroupDataGridViewTextBoxColumn.Name = "hesabGroupDataGridViewTextBoxColumn";
            this.hesabGroupDataGridViewTextBoxColumn.ReadOnly = true;
            this.hesabGroupDataGridViewTextBoxColumn.Visible = false;
            // 
            // KolBindingSource
            // 
            this.KolBindingSource.DataSource = typeof(EntityCache.Bussines.KolBussines);
            // 
            // txtSearchKol
            // 
            this.txtSearchKol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSearchKol.Border.Class = "TextBoxBorder";
            this.txtSearchKol.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchKol.Location = new System.Drawing.Point(41, 9);
            this.txtSearchKol.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchKol.Name = "txtSearchKol";
            this.txtSearchKol.PreventEnterBeep = true;
            this.txtSearchKol.Size = new System.Drawing.Size(326, 27);
            this.txtSearchKol.TabIndex = 55746;
            this.txtSearchKol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchKol.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearchKol.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // DGridMoein
            // 
            this.DGridMoein.AllowUserToAddRows = false;
            this.DGridMoein.AllowUserToDeleteRows = false;
            this.DGridMoein.AllowUserToResizeColumns = false;
            this.DGridMoein.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.DGridMoein.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGridMoein.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridMoein.AutoGenerateColumns = false;
            this.DGridMoein.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGridMoein.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGridMoein.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridMoein.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.accountDataGridViewTextBoxColumn1,
            this.dgAccount,
            this.dgMoeinGuid,
            this.modifiedDataGridViewTextBoxColumn1,
            this.kolGuidDataGridViewTextBoxColumn,
            this.dateMDataGridViewTextBoxColumn});
            this.DGridMoein.DataSource = this.MoeinBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGridMoein.DefaultCellStyle = dataGridViewCellStyle10;
            this.DGridMoein.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGridMoein.Location = new System.Drawing.Point(3, 50);
            this.DGridMoein.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGridMoein.Name = "DGridMoein";
            this.DGridMoein.ReadOnly = true;
            this.DGridMoein.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGridMoein.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGridMoein.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGridMoein.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.DGridMoein.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGridMoein.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGridMoein.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridMoein.Size = new System.Drawing.Size(390, 483);
            this.DGridMoein.TabIndex = 55748;
            this.DGridMoein.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGridMoein_KeyDown);
            // 
            // codeDataGridViewTextBoxColumn1
            // 
            this.codeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codeDataGridViewTextBoxColumn1.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn1.HeaderText = "کد حساب";
            this.codeDataGridViewTextBoxColumn1.Name = "codeDataGridViewTextBoxColumn1";
            this.codeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn1.Width = 79;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "عنوان حساب معین";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // accountDataGridViewTextBoxColumn1
            // 
            this.accountDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.accountDataGridViewTextBoxColumn1.DataPropertyName = "Account_";
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.accountDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.accountDataGridViewTextBoxColumn1.HeaderText = "مانده";
            this.accountDataGridViewTextBoxColumn1.Name = "accountDataGridViewTextBoxColumn1";
            this.accountDataGridViewTextBoxColumn1.ReadOnly = true;
            this.accountDataGridViewTextBoxColumn1.Width = 58;
            // 
            // dgAccount
            // 
            this.dgAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAccount.DataPropertyName = "Diagnosis";
            this.dgAccount.HeaderText = "تشخیص";
            this.dgAccount.Name = "dgAccount";
            this.dgAccount.ReadOnly = true;
            this.dgAccount.Width = 74;
            // 
            // dgMoeinGuid
            // 
            this.dgMoeinGuid.DataPropertyName = "Guid";
            this.dgMoeinGuid.HeaderText = "Guid";
            this.dgMoeinGuid.Name = "dgMoeinGuid";
            this.dgMoeinGuid.ReadOnly = true;
            this.dgMoeinGuid.Visible = false;
            // 
            // modifiedDataGridViewTextBoxColumn1
            // 
            this.modifiedDataGridViewTextBoxColumn1.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn1.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn1.Name = "modifiedDataGridViewTextBoxColumn1";
            this.modifiedDataGridViewTextBoxColumn1.ReadOnly = true;
            this.modifiedDataGridViewTextBoxColumn1.Visible = false;
            // 
            // kolGuidDataGridViewTextBoxColumn
            // 
            this.kolGuidDataGridViewTextBoxColumn.DataPropertyName = "KolGuid";
            this.kolGuidDataGridViewTextBoxColumn.HeaderText = "KolGuid";
            this.kolGuidDataGridViewTextBoxColumn.Name = "kolGuidDataGridViewTextBoxColumn";
            this.kolGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.kolGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateMDataGridViewTextBoxColumn
            // 
            this.dateMDataGridViewTextBoxColumn.DataPropertyName = "DateM";
            this.dateMDataGridViewTextBoxColumn.HeaderText = "DateM";
            this.dateMDataGridViewTextBoxColumn.Name = "dateMDataGridViewTextBoxColumn";
            this.dateMDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateMDataGridViewTextBoxColumn.Visible = false;
            // 
            // MoeinBindingSource
            // 
            this.MoeinBindingSource.DataSource = typeof(EntityCache.Bussines.MoeinBussines);
            // 
            // txtSearchMoein
            // 
            this.txtSearchMoein.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSearchMoein.Border.Class = "TextBoxBorder";
            this.txtSearchMoein.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearchMoein.Location = new System.Drawing.Point(28, 9);
            this.txtSearchMoein.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchMoein.Name = "txtSearchMoein";
            this.txtSearchMoein.PreventEnterBeep = true;
            this.txtSearchMoein.Size = new System.Drawing.Size(346, 27);
            this.txtSearchMoein.TabIndex = 55746;
            this.txtSearchMoein.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchMoein.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearchMoein.TextChanged += new System.EventHandler(this.txtSearchMoein_TextChanged);
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
            this.ucHeader.Location = new System.Drawing.Point(-5, 22);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55755;
            // 
            // frmKolMoein
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmKolMoein";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKolMoein_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmKolMoein_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridKol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGridMoein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MoeinBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchKol;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearchMoein;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGridKol;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGridMoein;
        private System.Windows.Forms.BindingSource KolBindingSource;
        private System.Windows.Forms.BindingSource MoeinBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgKolGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hesabGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgMoeinGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn kolGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateMDataGridViewTextBoxColumn;
        private WindowsSerivces.UC_Header ucHeader;
    }
}