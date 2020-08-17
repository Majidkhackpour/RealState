namespace Building.Building
{
    partial class frmBuildingAdvanceSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuildingAdvanceSearch));
            this.fPnel = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbBuildingType = new System.Windows.Forms.ComboBox();
            this.bTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReqType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.chbSarasari = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chbDivar = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chbSystem = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSeach = new DevComponents.DotNetBar.ButtonX();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtRoomCount = new System.Windows.Forms.NumericUpDown();
            this.txtSMasahat = new System.Windows.Forms.NumericUpDown();
            this.txtSPrice2 = new System.Windows.Forms.NumericUpDown();
            this.txtFPrice2 = new System.Windows.Forms.NumericUpDown();
            this.txtFMasahat = new System.Windows.Forms.NumericUpDown();
            this.txtSPrice1 = new System.Windows.Forms.NumericUpDown();
            this.txtFPrice1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbBuildingAccountType = new System.Windows.Forms.ComboBox();
            this.batBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.lblSPrice2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSPrice1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFPrice1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bTypeBindingSource)).BeginInit();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMasahat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMasahat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPrice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPrice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.batBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // fPnel
            // 
            this.fPnel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fPnel.AutoScroll = true;
            this.fPnel.BackColor = System.Drawing.Color.Transparent;
            this.fPnel.Location = new System.Drawing.Point(2, 30);
            this.fPnel.Name = "fPnel";
            this.fPnel.Size = new System.Drawing.Size(585, 566);
            this.fPnel.TabIndex = 18;
            // 
            // cmbBuildingType
            // 
            this.cmbBuildingType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBuildingType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBuildingType.DataSource = this.bTypeBindingSource;
            this.cmbBuildingType.DisplayMember = "Name";
            this.cmbBuildingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuildingType.FormattingEnabled = true;
            this.cmbBuildingType.Location = new System.Drawing.Point(12, 80);
            this.cmbBuildingType.Name = "cmbBuildingType";
            this.cmbBuildingType.Size = new System.Drawing.Size(127, 28);
            this.cmbBuildingType.TabIndex = 22;
            this.cmbBuildingType.ValueMember = "Guid";
            // 
            // bTypeBindingSource
            // 
            this.bTypeBindingSource.DataSource = typeof(EntityCache.Bussines.DocumentTypeBussines);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(150, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "نوع ملک";
            // 
            // cmbReqType
            // 
            this.cmbReqType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReqType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbReqType.DisplayMember = "Name";
            this.cmbReqType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReqType.FormattingEnabled = true;
            this.cmbReqType.Location = new System.Drawing.Point(12, 46);
            this.cmbReqType.Name = "cmbReqType";
            this.cmbReqType.Size = new System.Drawing.Size(127, 28);
            this.cmbReqType.TabIndex = 23;
            this.cmbReqType.ValueMember = "Guid";
            this.cmbReqType.SelectedIndexChanged += new System.EventHandler(this.cmbReqType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(145, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "نوع تقاضا";
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.chbSarasari);
            this.grp.Controls.Add(this.chbDivar);
            this.grp.Controls.Add(this.chbSystem);
            this.grp.Controls.Add(this.btnSeach);
            this.grp.Controls.Add(this.txtCode);
            this.grp.Controls.Add(this.txtRoomCount);
            this.grp.Controls.Add(this.txtSMasahat);
            this.grp.Controls.Add(this.txtSPrice2);
            this.grp.Controls.Add(this.txtFPrice2);
            this.grp.Controls.Add(this.txtFMasahat);
            this.grp.Controls.Add(this.txtSPrice1);
            this.grp.Controls.Add(this.txtFPrice1);
            this.grp.Controls.Add(this.cmbReqType);
            this.grp.Controls.Add(this.label9);
            this.grp.Controls.Add(this.cmbBuildingAccountType);
            this.grp.Controls.Add(this.label7);
            this.grp.Controls.Add(this.lblSPrice2);
            this.grp.Controls.Add(this.cmbBuildingType);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label6);
            this.grp.Controls.Add(this.lblSPrice1);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.lblFPrice1);
            this.grp.Controls.Add(this.label1);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(593, 30);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(206, 566);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grp.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 29;
            // 
            // chbSarasari
            // 
            this.chbSarasari.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSarasari.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbSarasari.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbSarasari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbSarasari.Location = new System.Drawing.Point(3, 449);
            this.chbSarasari.Name = "chbSarasari";
            this.chbSarasari.Size = new System.Drawing.Size(192, 23);
            this.chbSarasari.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbSarasari.TabIndex = 55762;
            this.chbSarasari.Text = "جستجو در فایل های مسکن سراسری";
            // 
            // chbDivar
            // 
            this.chbDivar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbDivar.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbDivar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbDivar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbDivar.Location = new System.Drawing.Point(12, 420);
            this.chbDivar.Name = "chbDivar";
            this.chbDivar.Size = new System.Drawing.Size(183, 23);
            this.chbDivar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbDivar.TabIndex = 55762;
            this.chbDivar.Text = "جستجو در فایل های دیوار";
            // 
            // chbSystem
            // 
            this.chbSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSystem.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbSystem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbSystem.Location = new System.Drawing.Point(12, 391);
            this.chbSystem.Name = "chbSystem";
            this.chbSystem.Size = new System.Drawing.Size(183, 23);
            this.chbSystem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbSystem.TabIndex = 55762;
            this.chbSystem.Text = "جستجو در فال های سیستم";
            // 
            // btnSeach
            // 
            this.btnSeach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSeach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeach.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSeach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSeach.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSeach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeach.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSeach.Location = new System.Drawing.Point(15, 524);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSeach.Size = new System.Drawing.Size(172, 31);
            this.btnSeach.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSeach.TabIndex = 55761;
            this.btnSeach.Text = "جستجو";
            this.btnSeach.TextColor = System.Drawing.Color.White;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // txtCode
            // 
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCode.Location = new System.Drawing.Point(12, 15);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(127, 27);
            this.txtCode.TabIndex = 27;
            // 
            // txtRoomCount
            // 
            this.txtRoomCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoomCount.Location = new System.Drawing.Point(12, 214);
            this.txtRoomCount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtRoomCount.Name = "txtRoomCount";
            this.txtRoomCount.Size = new System.Drawing.Size(127, 27);
            this.txtRoomCount.TabIndex = 26;
            // 
            // txtSMasahat
            // 
            this.txtSMasahat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMasahat.Location = new System.Drawing.Point(12, 181);
            this.txtSMasahat.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSMasahat.Name = "txtSMasahat";
            this.txtSMasahat.Size = new System.Drawing.Size(127, 27);
            this.txtSMasahat.TabIndex = 26;
            // 
            // txtSPrice2
            // 
            this.txtSPrice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSPrice2.Location = new System.Drawing.Point(12, 346);
            this.txtSPrice2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSPrice2.Name = "txtSPrice2";
            this.txtSPrice2.Size = new System.Drawing.Size(127, 27);
            this.txtSPrice2.TabIndex = 26;
            // 
            // txtFPrice2
            // 
            this.txtFPrice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFPrice2.Location = new System.Drawing.Point(12, 280);
            this.txtFPrice2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtFPrice2.Name = "txtFPrice2";
            this.txtFPrice2.Size = new System.Drawing.Size(127, 27);
            this.txtFPrice2.TabIndex = 26;
            // 
            // txtFMasahat
            // 
            this.txtFMasahat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFMasahat.Location = new System.Drawing.Point(12, 148);
            this.txtFMasahat.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtFMasahat.Name = "txtFMasahat";
            this.txtFMasahat.Size = new System.Drawing.Size(127, 27);
            this.txtFMasahat.TabIndex = 26;
            // 
            // txtSPrice1
            // 
            this.txtSPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSPrice1.Location = new System.Drawing.Point(12, 313);
            this.txtSPrice1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSPrice1.Name = "txtSPrice1";
            this.txtSPrice1.Size = new System.Drawing.Size(127, 27);
            this.txtSPrice1.TabIndex = 26;
            // 
            // txtFPrice1
            // 
            this.txtFPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFPrice1.Location = new System.Drawing.Point(12, 247);
            this.txtFPrice1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtFPrice1.Name = "txtFPrice1";
            this.txtFPrice1.Size = new System.Drawing.Size(127, 27);
            this.txtFPrice1.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(142, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "تعداد اتاق";
            // 
            // cmbBuildingAccountType
            // 
            this.cmbBuildingAccountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBuildingAccountType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBuildingAccountType.DataSource = this.batBindingSource;
            this.cmbBuildingAccountType.DisplayMember = "Name";
            this.cmbBuildingAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuildingAccountType.FormattingEnabled = true;
            this.cmbBuildingAccountType.Location = new System.Drawing.Point(12, 114);
            this.cmbBuildingAccountType.Name = "cmbBuildingAccountType";
            this.cmbBuildingAccountType.Size = new System.Drawing.Size(127, 28);
            this.cmbBuildingAccountType.TabIndex = 22;
            this.cmbBuildingAccountType.ValueMember = "Guid";
            // 
            // batBindingSource
            // 
            this.batBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingAccountTypeBussines);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(183, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "تا";
            // 
            // lblSPrice2
            // 
            this.lblSPrice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSPrice2.AutoSize = true;
            this.lblSPrice2.BackColor = System.Drawing.Color.Transparent;
            this.lblSPrice2.Location = new System.Drawing.Point(183, 348);
            this.lblSPrice2.Name = "lblSPrice2";
            this.lblSPrice2.Size = new System.Drawing.Size(16, 20);
            this.lblSPrice2.TabIndex = 24;
            this.lblSPrice2.Text = "تا";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(183, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "تا";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(155, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "کد ملک";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(141, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 24;
            this.label6.Text = "مساحت از";
            // 
            // lblSPrice1
            // 
            this.lblSPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSPrice1.AutoSize = true;
            this.lblSPrice1.BackColor = System.Drawing.Color.Transparent;
            this.lblSPrice1.Location = new System.Drawing.Point(152, 315);
            this.lblSPrice1.Name = "lblSPrice1";
            this.lblSPrice1.Size = new System.Drawing.Size(47, 20);
            this.lblSPrice1.TabIndex = 24;
            this.lblSPrice1.Text = "اجاره از";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(158, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "کاربری";
            // 
            // lblFPrice1
            // 
            this.lblFPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFPrice1.AutoSize = true;
            this.lblFPrice1.BackColor = System.Drawing.Color.Transparent;
            this.lblFPrice1.Location = new System.Drawing.Point(157, 249);
            this.lblFPrice1.Name = "lblFPrice1";
            this.lblFPrice1.Size = new System.Drawing.Size(42, 20);
            this.lblFPrice1.TabIndex = 24;
            this.lblFPrice1.Text = "مبلغ از";
            // 
            // frmBuildingAdvanceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.fPnel);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmBuildingAdvanceSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBuildingAdvanceSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bTypeBindingSource)).EndInit();
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMasahat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFMasahat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSPrice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFPrice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.batBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel fPnel;
        private System.Windows.Forms.ComboBox cmbBuildingType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbReqType;
        private System.Windows.Forms.Label label5;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.Label lblFPrice1;
        private System.Windows.Forms.NumericUpDown txtFPrice2;
        private System.Windows.Forms.NumericUpDown txtFPrice1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBuildingAccountType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtSMasahat;
        private System.Windows.Forms.NumericUpDown txtFMasahat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.NumericUpDown txtRoomCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txtSPrice2;
        private System.Windows.Forms.NumericUpDown txtSPrice1;
        private System.Windows.Forms.Label lblSPrice2;
        private System.Windows.Forms.Label lblSPrice1;
        private DevComponents.DotNetBar.ButtonX btnSeach;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSarasari;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbDivar;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSystem;
        private System.Windows.Forms.BindingSource bTypeBindingSource;
        private System.Windows.Forms.BindingSource batBindingSource;
    }
}