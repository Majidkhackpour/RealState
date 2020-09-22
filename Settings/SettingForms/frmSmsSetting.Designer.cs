namespace Settings.SettingForms
{
    partial class frmSmsSetting
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
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.txtOwnerText = new System.Windows.Forms.TextBox();
            this.txtMatchTextRahn = new System.Windows.Forms.TextBox();
            this.txtSayerText = new System.Windows.Forms.TextBox();
            this.chbSendAfterMatch = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chbSendSayer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnOwner_UserName = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn_Ejare = new DevComponents.DotNetBar.ButtonX();
            this.chbSendOwner = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSayer_UserName = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_Region = new DevComponents.DotNetBar.ButtonX();
            this.cmbPanel = new System.Windows.Forms.ComboBox();
            this.defBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRahn_Rahn = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_BuildingCode = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn_Region = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_DateSh = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn_DateSh = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_OwnerName = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn_SayerName = new DevComponents.DotNetBar.ButtonX();
            this.btnSayer_DateSh = new DevComponents.DotNetBar.ButtonX();
            this.btnSayer_SayerName = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddPanel = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnKharid_SayerName = new DevComponents.DotNetBar.ButtonX();
            this.btnKharid_DateSh = new DevComponents.DotNetBar.ButtonX();
            this.btnKharid_Region = new DevComponents.DotNetBar.ButtonX();
            this.btnKharid_Price = new DevComponents.DotNetBar.ButtonX();
            this.txtMatchTextKharid = new System.Windows.Forms.TextBox();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Settings.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(407, 537);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Settings.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(51, 537);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.txtOwnerText);
            this.grp.Controls.Add(this.txtMatchTextKharid);
            this.grp.Controls.Add(this.txtMatchTextRahn);
            this.grp.Controls.Add(this.txtSayerText);
            this.grp.Controls.Add(this.chbSendAfterMatch);
            this.grp.Controls.Add(this.chbSendSayer);
            this.grp.Controls.Add(this.btnOwner_UserName);
            this.grp.Controls.Add(this.btnRahn_Ejare);
            this.grp.Controls.Add(this.chbSendOwner);
            this.grp.Controls.Add(this.btnSayer_UserName);
            this.grp.Controls.Add(this.btnOwner_Region);
            this.grp.Controls.Add(this.btnKharid_Price);
            this.grp.Controls.Add(this.cmbPanel);
            this.grp.Controls.Add(this.btnRahn_Rahn);
            this.grp.Controls.Add(this.btnKharid_Region);
            this.grp.Controls.Add(this.btnOwner_BuildingCode);
            this.grp.Controls.Add(this.btnRahn_Region);
            this.grp.Controls.Add(this.btnKharid_DateSh);
            this.grp.Controls.Add(this.btnOwner_DateSh);
            this.grp.Controls.Add(this.btnRahn_DateSh);
            this.grp.Controls.Add(this.btnKharid_SayerName);
            this.grp.Controls.Add(this.btnOwner_OwnerName);
            this.grp.Controls.Add(this.btnRahn_SayerName);
            this.grp.Controls.Add(this.btnSayer_DateSh);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.btnSayer_SayerName);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.btnAddPanel);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label3);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(4, 7);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(600, 524);
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
            // txtOwnerText
            // 
            this.txtOwnerText.Location = new System.Drawing.Point(305, 76);
            this.txtOwnerText.Multiline = true;
            this.txtOwnerText.Name = "txtOwnerText";
            this.txtOwnerText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOwnerText.Size = new System.Drawing.Size(177, 178);
            this.txtOwnerText.TabIndex = 3;
            // 
            // txtMatchTextRahn
            // 
            this.txtMatchTextRahn.Location = new System.Drawing.Point(305, 285);
            this.txtMatchTextRahn.Multiline = true;
            this.txtMatchTextRahn.Name = "txtMatchTextRahn";
            this.txtMatchTextRahn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMatchTextRahn.Size = new System.Drawing.Size(177, 223);
            this.txtMatchTextRahn.TabIndex = 2;
            // 
            // txtSayerText
            // 
            this.txtSayerText.Location = new System.Drawing.Point(11, 78);
            this.txtSayerText.Multiline = true;
            this.txtSayerText.Name = "txtSayerText";
            this.txtSayerText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSayerText.Size = new System.Drawing.Size(177, 178);
            this.txtSayerText.TabIndex = 2;
            // 
            // chbSendAfterMatch
            // 
            this.chbSendAfterMatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSendAfterMatch.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbSendAfterMatch.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbSendAfterMatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbSendAfterMatch.Location = new System.Drawing.Point(225, 260);
            this.chbSendAfterMatch.Name = "chbSendAfterMatch";
            this.chbSendAfterMatch.Size = new System.Drawing.Size(363, 23);
            this.chbSendAfterMatch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbSendAfterMatch.TabIndex = 21;
            this.chbSendAfterMatch.Text = "ارسال پیامک به متقاضی، پس از تطابق فایل با شرایط تقاضا";
            // 
            // chbSendSayer
            // 
            this.chbSendSayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSendSayer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbSendSayer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbSendSayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbSendSayer.Location = new System.Drawing.Point(47, 44);
            this.chbSendSayer.Name = "chbSendSayer";
            this.chbSendSayer.Size = new System.Drawing.Size(263, 23);
            this.chbSendSayer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbSendSayer.TabIndex = 21;
            this.chbSendSayer.Text = "ارسال پیامک به متقاضی پس از ثبت تقاضا";
            // 
            // btnOwner_UserName
            // 
            this.btnOwner_UserName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_UserName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_UserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_UserName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_UserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_UserName.Location = new System.Drawing.Point(497, 234);
            this.btnOwner_UserName.Name = "btnOwner_UserName";
            this.btnOwner_UserName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOwner_UserName.Size = new System.Drawing.Size(79, 27);
            this.btnOwner_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOwner_UserName.TabIndex = 8;
            this.btnOwner_UserName.Text = "[مشاور]";
            this.btnOwner_UserName.TextColor = System.Drawing.Color.White;
            this.btnOwner_UserName.Click += new System.EventHandler(this.btnOwner_UserName_Click);
            // 
            // btnRahn_Ejare
            // 
            this.btnRahn_Ejare.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn_Ejare.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_Ejare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_Ejare.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_Ejare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_Ejare.Location = new System.Drawing.Point(497, 470);
            this.btnRahn_Ejare.Name = "btnRahn_Ejare";
            this.btnRahn_Ejare.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_Ejare.Size = new System.Drawing.Size(79, 27);
            this.btnRahn_Ejare.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_Ejare.TabIndex = 20;
            this.btnRahn_Ejare.Text = "[اجاره]";
            this.btnRahn_Ejare.TextColor = System.Drawing.Color.White;
            this.btnRahn_Ejare.Click += new System.EventHandler(this.btnRahn_Ejare_Click);
            // 
            // chbSendOwner
            // 
            this.chbSendOwner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSendOwner.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbSendOwner.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbSendOwner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbSendOwner.Location = new System.Drawing.Point(325, 44);
            this.chbSendOwner.Name = "chbSendOwner";
            this.chbSendOwner.Size = new System.Drawing.Size(263, 23);
            this.chbSendOwner.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbSendOwner.TabIndex = 2;
            this.chbSendOwner.Text = "ارسال پیامک به مالک، پس از تعریف ملک";
            // 
            // btnSayer_UserName
            // 
            this.btnSayer_UserName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSayer_UserName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSayer_UserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSayer_UserName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSayer_UserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSayer_UserName.Location = new System.Drawing.Point(203, 168);
            this.btnSayer_UserName.Name = "btnSayer_UserName";
            this.btnSayer_UserName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSayer_UserName.Size = new System.Drawing.Size(79, 27);
            this.btnSayer_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSayer_UserName.TabIndex = 20;
            this.btnSayer_UserName.Text = "[مشاور]";
            this.btnSayer_UserName.TextColor = System.Drawing.Color.White;
            this.btnSayer_UserName.Click += new System.EventHandler(this.btnSayer_UserName_Click);
            // 
            // btnOwner_Region
            // 
            this.btnOwner_Region.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_Region.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_Region.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_Region.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_Region.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_Region.Location = new System.Drawing.Point(497, 201);
            this.btnOwner_Region.Name = "btnOwner_Region";
            this.btnOwner_Region.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOwner_Region.Size = new System.Drawing.Size(79, 27);
            this.btnOwner_Region.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOwner_Region.TabIndex = 7;
            this.btnOwner_Region.Text = "[محدوده]";
            this.btnOwner_Region.TextColor = System.Drawing.Color.White;
            this.btnOwner_Region.Click += new System.EventHandler(this.btnOwner_Region_Click);
            // 
            // cmbPanel
            // 
            this.cmbPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPanel.DataSource = this.defBindingSource;
            this.cmbPanel.DisplayMember = "Sender";
            this.cmbPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPanel.FormattingEnabled = true;
            this.cmbPanel.Location = new System.Drawing.Point(63, 10);
            this.cmbPanel.Name = "cmbPanel";
            this.cmbPanel.Size = new System.Drawing.Size(417, 28);
            this.cmbPanel.TabIndex = 0;
            this.cmbPanel.ValueMember = "Guid";
            // 
            // defBindingSource
            // 
            this.defBindingSource.DataSource = typeof(EntityCache.Bussines.SmsPanelsBussines);
            // 
            // btnRahn_Rahn
            // 
            this.btnRahn_Rahn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn_Rahn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_Rahn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_Rahn.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_Rahn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_Rahn.Location = new System.Drawing.Point(497, 437);
            this.btnRahn_Rahn.Name = "btnRahn_Rahn";
            this.btnRahn_Rahn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_Rahn.Size = new System.Drawing.Size(79, 27);
            this.btnRahn_Rahn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_Rahn.TabIndex = 20;
            this.btnRahn_Rahn.Text = "[رهن]";
            this.btnRahn_Rahn.TextColor = System.Drawing.Color.White;
            this.btnRahn_Rahn.Click += new System.EventHandler(this.btnRahn_Rahn_Click);
            // 
            // btnOwner_BuildingCode
            // 
            this.btnOwner_BuildingCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_BuildingCode.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_BuildingCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_BuildingCode.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_BuildingCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_BuildingCode.Location = new System.Drawing.Point(497, 168);
            this.btnOwner_BuildingCode.Name = "btnOwner_BuildingCode";
            this.btnOwner_BuildingCode.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOwner_BuildingCode.Size = new System.Drawing.Size(79, 27);
            this.btnOwner_BuildingCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOwner_BuildingCode.TabIndex = 6;
            this.btnOwner_BuildingCode.Text = "[کدملک]";
            this.btnOwner_BuildingCode.TextColor = System.Drawing.Color.White;
            this.btnOwner_BuildingCode.Click += new System.EventHandler(this.btnOwner_BuildingCode_Click);
            // 
            // btnRahn_Region
            // 
            this.btnRahn_Region.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn_Region.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_Region.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_Region.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_Region.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_Region.Location = new System.Drawing.Point(497, 404);
            this.btnRahn_Region.Name = "btnRahn_Region";
            this.btnRahn_Region.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_Region.Size = new System.Drawing.Size(79, 27);
            this.btnRahn_Region.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_Region.TabIndex = 20;
            this.btnRahn_Region.Text = "[محدوده ملک]";
            this.btnRahn_Region.TextColor = System.Drawing.Color.White;
            this.btnRahn_Region.Click += new System.EventHandler(this.btnRahn_Region_Click);
            // 
            // btnOwner_DateSh
            // 
            this.btnOwner_DateSh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_DateSh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_DateSh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_DateSh.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_DateSh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_DateSh.Location = new System.Drawing.Point(497, 135);
            this.btnOwner_DateSh.Name = "btnOwner_DateSh";
            this.btnOwner_DateSh.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOwner_DateSh.Size = new System.Drawing.Size(79, 27);
            this.btnOwner_DateSh.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOwner_DateSh.TabIndex = 5;
            this.btnOwner_DateSh.Text = "[تاریخ ثبت]";
            this.btnOwner_DateSh.TextColor = System.Drawing.Color.White;
            this.btnOwner_DateSh.Click += new System.EventHandler(this.btnOwner_DateSh_Click);
            // 
            // btnRahn_DateSh
            // 
            this.btnRahn_DateSh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn_DateSh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_DateSh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_DateSh.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_DateSh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_DateSh.Location = new System.Drawing.Point(497, 371);
            this.btnRahn_DateSh.Name = "btnRahn_DateSh";
            this.btnRahn_DateSh.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_DateSh.Size = new System.Drawing.Size(79, 27);
            this.btnRahn_DateSh.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_DateSh.TabIndex = 20;
            this.btnRahn_DateSh.Text = "[تاریخ ارسال]";
            this.btnRahn_DateSh.TextColor = System.Drawing.Color.White;
            this.btnRahn_DateSh.Click += new System.EventHandler(this.btnRahn_DateSh_Click);
            // 
            // btnOwner_OwnerName
            // 
            this.btnOwner_OwnerName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_OwnerName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_OwnerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_OwnerName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_OwnerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_OwnerName.Location = new System.Drawing.Point(497, 102);
            this.btnOwner_OwnerName.Name = "btnOwner_OwnerName";
            this.btnOwner_OwnerName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOwner_OwnerName.Size = new System.Drawing.Size(79, 27);
            this.btnOwner_OwnerName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOwner_OwnerName.TabIndex = 4;
            this.btnOwner_OwnerName.Text = "[نام مالک]";
            this.btnOwner_OwnerName.TextColor = System.Drawing.Color.White;
            this.btnOwner_OwnerName.Click += new System.EventHandler(this.btnOwner_OwnerName_Click);
            // 
            // btnRahn_SayerName
            // 
            this.btnRahn_SayerName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn_SayerName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_SayerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_SayerName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_SayerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_SayerName.Location = new System.Drawing.Point(497, 338);
            this.btnRahn_SayerName.Name = "btnRahn_SayerName";
            this.btnRahn_SayerName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_SayerName.Size = new System.Drawing.Size(79, 27);
            this.btnRahn_SayerName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_SayerName.TabIndex = 20;
            this.btnRahn_SayerName.Text = "[نام متقاضی]";
            this.btnRahn_SayerName.TextColor = System.Drawing.Color.White;
            this.btnRahn_SayerName.Click += new System.EventHandler(this.btnRahn_SayerName_Click);
            // 
            // btnSayer_DateSh
            // 
            this.btnSayer_DateSh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSayer_DateSh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSayer_DateSh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSayer_DateSh.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSayer_DateSh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSayer_DateSh.Location = new System.Drawing.Point(203, 135);
            this.btnSayer_DateSh.Name = "btnSayer_DateSh";
            this.btnSayer_DateSh.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSayer_DateSh.Size = new System.Drawing.Size(79, 27);
            this.btnSayer_DateSh.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSayer_DateSh.TabIndex = 20;
            this.btnSayer_DateSh.Text = "[تاریخ ثبت]";
            this.btnSayer_DateSh.TextColor = System.Drawing.Color.White;
            this.btnSayer_DateSh.Click += new System.EventHandler(this.btnSayer_DateSh_Click);
            // 
            // btnSayer_SayerName
            // 
            this.btnSayer_SayerName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSayer_SayerName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSayer_SayerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSayer_SayerName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSayer_SayerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSayer_SayerName.Location = new System.Drawing.Point(203, 102);
            this.btnSayer_SayerName.Name = "btnSayer_SayerName";
            this.btnSayer_SayerName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSayer_SayerName.Size = new System.Drawing.Size(79, 27);
            this.btnSayer_SayerName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSayer_SayerName.TabIndex = 20;
            this.btnSayer_SayerName.Text = "[نام متقاضی]";
            this.btnSayer_SayerName.TextColor = System.Drawing.Color.White;
            this.btnSayer_SayerName.Click += new System.EventHandler(this.btnSayer_SayerName_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(488, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 47);
            this.label4.TabIndex = 7;
            this.label4.Text = "الگوی پیامک ارسالی رهن و اجاره";
            // 
            // btnAddPanel
            // 
            this.btnAddPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddPanel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddPanel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPanel.Location = new System.Drawing.Point(8, 11);
            this.btnAddPanel.Name = "btnAddPanel";
            this.btnAddPanel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnAddPanel.Size = new System.Drawing.Size(49, 27);
            this.btnAddPanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnAddPanel.TabIndex = 1;
            this.btnAddPanel.Text = "افزودن";
            this.btnAddPanel.TextColor = System.Drawing.Color.White;
            this.btnAddPanel.Click += new System.EventHandler(this.btnAddPanel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(194, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "الگوی پیامک ارسالی";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(510, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "پنل پیش فرض";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(488, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "الگوی پیامک ارسالی";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(194, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 47);
            this.label5.TabIndex = 7;
            this.label5.Text = "الگوی پیامک ارسالی خرید";
            // 
            // btnKharid_SayerName
            // 
            this.btnKharid_SayerName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKharid_SayerName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnKharid_SayerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKharid_SayerName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnKharid_SayerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKharid_SayerName.Location = new System.Drawing.Point(203, 338);
            this.btnKharid_SayerName.Name = "btnKharid_SayerName";
            this.btnKharid_SayerName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnKharid_SayerName.Size = new System.Drawing.Size(79, 27);
            this.btnKharid_SayerName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnKharid_SayerName.TabIndex = 20;
            this.btnKharid_SayerName.Text = "[نام متقاضی]";
            this.btnKharid_SayerName.TextColor = System.Drawing.Color.White;
            this.btnKharid_SayerName.Click += new System.EventHandler(this.btnKharid_SayerName_Click);
            // 
            // btnKharid_DateSh
            // 
            this.btnKharid_DateSh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKharid_DateSh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnKharid_DateSh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKharid_DateSh.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnKharid_DateSh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKharid_DateSh.Location = new System.Drawing.Point(203, 371);
            this.btnKharid_DateSh.Name = "btnKharid_DateSh";
            this.btnKharid_DateSh.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnKharid_DateSh.Size = new System.Drawing.Size(79, 27);
            this.btnKharid_DateSh.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnKharid_DateSh.TabIndex = 20;
            this.btnKharid_DateSh.Text = "[تاریخ ارسال]";
            this.btnKharid_DateSh.TextColor = System.Drawing.Color.White;
            this.btnKharid_DateSh.Click += new System.EventHandler(this.btnKharid_DateSh_Click);
            // 
            // btnKharid_Region
            // 
            this.btnKharid_Region.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKharid_Region.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnKharid_Region.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKharid_Region.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnKharid_Region.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKharid_Region.Location = new System.Drawing.Point(203, 404);
            this.btnKharid_Region.Name = "btnKharid_Region";
            this.btnKharid_Region.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnKharid_Region.Size = new System.Drawing.Size(79, 27);
            this.btnKharid_Region.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnKharid_Region.TabIndex = 20;
            this.btnKharid_Region.Text = "[محدوده ملک]";
            this.btnKharid_Region.TextColor = System.Drawing.Color.White;
            this.btnKharid_Region.Click += new System.EventHandler(this.btnKharid_Region_Click);
            // 
            // btnKharid_Price
            // 
            this.btnKharid_Price.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnKharid_Price.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnKharid_Price.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKharid_Price.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnKharid_Price.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKharid_Price.Location = new System.Drawing.Point(203, 437);
            this.btnKharid_Price.Name = "btnKharid_Price";
            this.btnKharid_Price.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnKharid_Price.Size = new System.Drawing.Size(79, 27);
            this.btnKharid_Price.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnKharid_Price.TabIndex = 20;
            this.btnKharid_Price.Text = "[قیمت]";
            this.btnKharid_Price.TextColor = System.Drawing.Color.White;
            this.btnKharid_Price.Click += new System.EventHandler(this.btnKharid_Price_Click);
            // 
            // txtMatchTextKharid
            // 
            this.txtMatchTextKharid.Location = new System.Drawing.Point(11, 285);
            this.txtMatchTextKharid.Multiline = true;
            this.txtMatchTextKharid.Name = "txtMatchTextKharid";
            this.txtMatchTextKharid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMatchTextKharid.Size = new System.Drawing.Size(177, 223);
            this.txtMatchTextKharid.TabIndex = 2;
            // 
            // frmSmsSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 571);
            this.ControlBox = false;
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(609, 571);
            this.Name = "frmSmsSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSmsSetting_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.ComboBox cmbPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSendOwner;
        private DevComponents.DotNetBar.ButtonX btnAddPanel;
        private System.Windows.Forms.TextBox txtOwnerText;
        private System.Windows.Forms.TextBox txtSayerText;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSendSayer;
        private DevComponents.DotNetBar.ButtonX btnOwner_UserName;
        private DevComponents.DotNetBar.ButtonX btnSayer_UserName;
        private DevComponents.DotNetBar.ButtonX btnOwner_Region;
        private DevComponents.DotNetBar.ButtonX btnOwner_BuildingCode;
        private DevComponents.DotNetBar.ButtonX btnOwner_DateSh;
        private DevComponents.DotNetBar.ButtonX btnOwner_OwnerName;
        private DevComponents.DotNetBar.ButtonX btnSayer_DateSh;
        private DevComponents.DotNetBar.ButtonX btnSayer_SayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatchTextRahn;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSendAfterMatch;
        private DevComponents.DotNetBar.ButtonX btnRahn_Ejare;
        private DevComponents.DotNetBar.ButtonX btnRahn_Rahn;
        private DevComponents.DotNetBar.ButtonX btnRahn_Region;
        private DevComponents.DotNetBar.ButtonX btnRahn_DateSh;
        private DevComponents.DotNetBar.ButtonX btnRahn_SayerName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource defBindingSource;
        private System.Windows.Forms.TextBox txtMatchTextKharid;
        private DevComponents.DotNetBar.ButtonX btnKharid_Price;
        private DevComponents.DotNetBar.ButtonX btnKharid_Region;
        private DevComponents.DotNetBar.ButtonX btnKharid_DateSh;
        private DevComponents.DotNetBar.ButtonX btnKharid_SayerName;
        private System.Windows.Forms.Label label5;
    }
}