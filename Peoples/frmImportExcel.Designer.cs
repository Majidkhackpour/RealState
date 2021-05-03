namespace Peoples
{
    partial class frmImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportExcel));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.cmbSheet = new System.Windows.Forms.ComboBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtTell4 = new System.Windows.Forms.TextBox();
            this.txtIssuedFrom = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtIdCode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTell3 = new System.Windows.Forms.TextBox();
            this.txtDateBirth = new System.Windows.Forms.TextBox();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.txtNationalCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTell2 = new System.Windows.Forms.TextBox();
            this.txtPlaceBirth = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTell1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtGroup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbWithoutGroup = new System.Windows.Forms.ComboBox();
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbDuplicateCode = new System.Windows.Forms.ComboBox();
            this.cmbDuplicateName = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Peoples.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(24, 513);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Peoples.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(652, 513);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 3;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.DGrid);
            this.grp.Controls.Add(this.btnSearch);
            this.grp.Controls.Add(this.cmbSheet);
            this.grp.Controls.Add(this.txtPath);
            this.grp.Controls.Add(this.label7);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(6, 17);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(793, 171);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(18, 49);
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
            this.DGrid.Size = new System.Drawing.Size(760, 108);
            this.DGrid.TabIndex = 55753;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(248, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearch.Size = new System.Drawing.Size(30, 27);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "...";
            this.btnSearch.TextColor = System.Drawing.Color.White;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbSheet
            // 
            this.cmbSheet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSheet.DisplayMember = "Name";
            this.cmbSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSheet.FormattingEnabled = true;
            this.cmbSheet.Location = new System.Drawing.Point(18, 14);
            this.cmbSheet.Name = "cmbSheet";
            this.cmbSheet.Size = new System.Drawing.Size(224, 28);
            this.cmbSheet.TabIndex = 1;
            this.cmbSheet.ValueMember = "Guid";
            this.cmbSheet.SelectedIndexChanged += new System.EventHandler(this.cmbSheet_SelectedIndexChanged);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Enabled = false;
            this.txtPath.Location = new System.Drawing.Point(288, 14);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(393, 27);
            this.txtPath.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(687, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "آدرس فایل اکسل";
            // 
            // panelEx1
            // 
            this.panelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.txtTell4);
            this.panelEx1.Controls.Add(this.txtIssuedFrom);
            this.panelEx1.Controls.Add(this.txtAccount);
            this.panelEx1.Controls.Add(this.txtIdCode);
            this.panelEx1.Controls.Add(this.label17);
            this.panelEx1.Controls.Add(this.label9);
            this.panelEx1.Controls.Add(this.label16);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.txtTell3);
            this.panelEx1.Controls.Add(this.txtDateBirth);
            this.panelEx1.Controls.Add(this.txtPostalCode);
            this.panelEx1.Controls.Add(this.txtNationalCode);
            this.panelEx1.Controls.Add(this.label15);
            this.panelEx1.Controls.Add(this.label8);
            this.panelEx1.Controls.Add(this.label14);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.txtTell2);
            this.panelEx1.Controls.Add(this.txtPlaceBirth);
            this.panelEx1.Controls.Add(this.txtAddress);
            this.panelEx1.Controls.Add(this.txtName);
            this.panelEx1.Controls.Add(this.label13);
            this.panelEx1.Controls.Add(this.label6);
            this.panelEx1.Controls.Add(this.label12);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.txtTell1);
            this.panelEx1.Controls.Add(this.label11);
            this.panelEx1.Controls.Add(this.txtFatherName);
            this.panelEx1.Controls.Add(this.txtGroup);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.label10);
            this.panelEx1.Controls.Add(this.txtCode);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(6, 194);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(793, 171);
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
            // txtTell4
            // 
            this.txtTell4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTell4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTell4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTell4.Location = new System.Drawing.Point(24, 116);
            this.txtTell4.Name = "txtTell4";
            this.txtTell4.Size = new System.Drawing.Size(68, 27);
            this.txtTell4.TabIndex = 15;
            // 
            // txtIssuedFrom
            // 
            this.txtIssuedFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssuedFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtIssuedFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtIssuedFrom.Location = new System.Drawing.Point(24, 49);
            this.txtIssuedFrom.Name = "txtIssuedFrom";
            this.txtIssuedFrom.Size = new System.Drawing.Size(68, 27);
            this.txtIssuedFrom.TabIndex = 7;
            // 
            // txtAccount
            // 
            this.txtAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAccount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAccount.Location = new System.Drawing.Point(24, 83);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(68, 27);
            this.txtAccount.TabIndex = 11;
            // 
            // txtIdCode
            // 
            this.txtIdCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtIdCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtIdCode.Location = new System.Drawing.Point(24, 16);
            this.txtIdCode.Name = "txtIdCode";
            this.txtIdCode.Size = new System.Drawing.Size(68, 27);
            this.txtIdCode.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(141, 119);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 20);
            this.label17.TabIndex = 4;
            this.label17.Text = "تلفن 4";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(506, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "آدرس";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(102, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "مانده اول دوره";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(98, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "شماره شناسنامه";
            // 
            // txtTell3
            // 
            this.txtTell3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTell3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTell3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTell3.Location = new System.Drawing.Point(226, 116);
            this.txtTell3.Name = "txtTell3";
            this.txtTell3.Size = new System.Drawing.Size(68, 27);
            this.txtTell3.TabIndex = 14;
            // 
            // txtDateBirth
            // 
            this.txtDateBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateBirth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDateBirth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDateBirth.Location = new System.Drawing.Point(226, 49);
            this.txtDateBirth.Name = "txtDateBirth";
            this.txtDateBirth.Size = new System.Drawing.Size(68, 27);
            this.txtDateBirth.TabIndex = 6;
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostalCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPostalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPostalCode.Location = new System.Drawing.Point(226, 83);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(68, 27);
            this.txtPostalCode.TabIndex = 10;
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNationalCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNationalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNationalCode.Location = new System.Drawing.Point(226, 16);
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Size = new System.Drawing.Size(68, 27);
            this.txtNationalCode.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(314, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "تلفن 3";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(300, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "تاریخ تولد";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(710, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "گروه";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(315, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "کد ملی";
            // 
            // txtTell2
            // 
            this.txtTell2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTell2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTell2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTell2.Location = new System.Drawing.Point(418, 116);
            this.txtTell2.Name = "txtTell2";
            this.txtTell2.Size = new System.Drawing.Size(68, 27);
            this.txtTell2.TabIndex = 13;
            // 
            // txtPlaceBirth
            // 
            this.txtPlaceBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceBirth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPlaceBirth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPlaceBirth.Location = new System.Drawing.Point(418, 49);
            this.txtPlaceBirth.Name = "txtPlaceBirth";
            this.txtPlaceBirth.Size = new System.Drawing.Size(68, 27);
            this.txtPlaceBirth.TabIndex = 5;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAddress.Location = new System.Drawing.Point(418, 83);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(68, 27);
            this.txtAddress.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Location = new System.Drawing.Point(418, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(68, 27);
            this.txtName.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(503, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "تلفن 2";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(492, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "محل تولد";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(305, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "کد پستی";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(508, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "عنوان";
            // 
            // txtTell1
            // 
            this.txtTell1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTell1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTell1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTell1.Location = new System.Drawing.Point(613, 116);
            this.txtTell1.Name = "txtTell1";
            this.txtTell1.Size = new System.Drawing.Size(68, 27);
            this.txtTell1.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(699, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "تلفن 1";
            // 
            // txtFatherName
            // 
            this.txtFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFatherName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtFatherName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFatherName.Location = new System.Drawing.Point(613, 49);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(68, 27);
            this.txtFatherName.TabIndex = 4;
            // 
            // txtGroup
            // 
            this.txtGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtGroup.Location = new System.Drawing.Point(613, 83);
            this.txtGroup.Name = "txtGroup";
            this.txtGroup.Size = new System.Drawing.Size(68, 27);
            this.txtGroup.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(698, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "نام پدر";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(131, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "صادره از";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCode.Location = new System.Drawing.Point(613, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(68, 27);
            this.txtCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(687, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "کد شخص";
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.label19);
            this.panelEx2.Controls.Add(this.label21);
            this.panelEx2.Controls.Add(this.cmbWithoutGroup);
            this.panelEx2.Controls.Add(this.cmbDuplicateCode);
            this.panelEx2.Controls.Add(this.cmbDuplicateName);
            this.panelEx2.Controls.Add(this.label20);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(6, 371);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(793, 133);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx2.Style.BorderWidth = 2;
            this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(689, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "کنترل کد شخص";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(679, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(96, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "کنترل گروه شخص";
            // 
            // cmbWithoutGroup
            // 
            this.cmbWithoutGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWithoutGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWithoutGroup.DataSource = this.groupBindingSource;
            this.cmbWithoutGroup.DisplayMember = "Name";
            this.cmbWithoutGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWithoutGroup.FormattingEnabled = true;
            this.cmbWithoutGroup.Location = new System.Drawing.Point(24, 91);
            this.cmbWithoutGroup.Name = "cmbWithoutGroup";
            this.cmbWithoutGroup.Size = new System.Drawing.Size(641, 28);
            this.cmbWithoutGroup.TabIndex = 3;
            this.cmbWithoutGroup.ValueMember = "Guid";
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(EntityCache.Bussines.PeopleGroupBussines);
            // 
            // cmbDuplicateCode
            // 
            this.cmbDuplicateCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDuplicateCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDuplicateCode.DisplayMember = "Name";
            this.cmbDuplicateCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuplicateCode.FormattingEnabled = true;
            this.cmbDuplicateCode.Items.AddRange(new object[] {
            "عدم درج شخص بدون کد",
            "عدم درج شخص با کد تکراری",
            "پیشنهاد کد جدید"});
            this.cmbDuplicateCode.Location = new System.Drawing.Point(24, 14);
            this.cmbDuplicateCode.Name = "cmbDuplicateCode";
            this.cmbDuplicateCode.Size = new System.Drawing.Size(641, 28);
            this.cmbDuplicateCode.TabIndex = 1;
            this.cmbDuplicateCode.ValueMember = "Guid";
            // 
            // cmbDuplicateName
            // 
            this.cmbDuplicateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDuplicateName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbDuplicateName.DisplayMember = "Name";
            this.cmbDuplicateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuplicateName.FormattingEnabled = true;
            this.cmbDuplicateName.Items.AddRange(new object[] {
            "عدم درج شخص بدون نام",
            "عدم درج شخص با عنوان تکراری",
            "درج شخص بدون درنظر گرفتن تکراری بودن"});
            this.cmbDuplicateName.Location = new System.Drawing.Point(24, 51);
            this.cmbDuplicateName.Name = "cmbDuplicateName";
            this.cmbDuplicateName.Size = new System.Drawing.Size(641, 28);
            this.cmbDuplicateName.TabIndex = 2;
            this.cmbDuplicateName.ValueMember = "Guid";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(673, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(102, 20);
            this.label20.TabIndex = 4;
            this.label20.Text = "کنترل عنوان شخص";
            // 
            // frmImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportExcel";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmImportExcel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmImportExcel_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.ComboBox cmbSheet;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.TextBox txtPath;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTell4;
        private System.Windows.Forms.TextBox txtIssuedFrom;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtIdCode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTell3;
        private System.Windows.Forms.TextBox txtDateBirth;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.TextBox txtNationalCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTell2;
        private System.Windows.Forms.TextBox txtPlaceBirth;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTell1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCode;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbWithoutGroup;
        private System.Windows.Forms.ComboBox cmbDuplicateCode;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.ComboBox cmbDuplicateName;
        private System.Windows.Forms.Label label20;
    }
}