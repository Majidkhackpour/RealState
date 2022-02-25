
namespace Settings.Forms
{
    partial class frmSms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSms));
            this.defBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlSms = new DevComponents.DotNetBar.PanelEx();
            this.txtOwnerText = new System.Windows.Forms.TextBox();
            this.txtMatchTextRahn = new System.Windows.Forms.TextBox();
            this.txtSayerText = new System.Windows.Forms.TextBox();
            this.chbSendAfterMatch = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chbSendSayer = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnOwner_UserName = new DevComponents.DotNetBar.ButtonX();
            this.btnAddress = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn_Ejare = new DevComponents.DotNetBar.ButtonX();
            this.chbSendOwner = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnSayer_UserName = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_Region = new DevComponents.DotNetBar.ButtonX();
            this.cmbPanel = new System.Windows.Forms.ComboBox();
            this.btnRahn_Rahn = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_BuildingCode = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_DateSh = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn_DateSh = new DevComponents.DotNetBar.ButtonX();
            this.btnOwner_OwnerName = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn_SayerName = new DevComponents.DotNetBar.ButtonX();
            this.btnSayer_DateSh = new DevComponents.DotNetBar.ButtonX();
            this.btnSayer_SayerName = new DevComponents.DotNetBar.ButtonX();
            this.btnAddPanel = new DevComponents.DotNetBar.ButtonX();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.defBindingSource)).BeginInit();
            this.pnlSms.SuspendLayout();
            this.SuspendLayout();
            // 
            // defBindingSource
            // 
            this.defBindingSource.DataSource = typeof(EntityCache.Bussines.SmsPanelsBussines);
            // 
            // pnlSms
            // 
            this.pnlSms.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlSms.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlSms.Controls.Add(this.txtOwnerText);
            this.pnlSms.Controls.Add(this.txtMatchTextRahn);
            this.pnlSms.Controls.Add(this.txtSayerText);
            this.pnlSms.Controls.Add(this.chbSendAfterMatch);
            this.pnlSms.Controls.Add(this.chbSendSayer);
            this.pnlSms.Controls.Add(this.btnOwner_UserName);
            this.pnlSms.Controls.Add(this.btnAddress);
            this.pnlSms.Controls.Add(this.btnRahn_Ejare);
            this.pnlSms.Controls.Add(this.chbSendOwner);
            this.pnlSms.Controls.Add(this.btnSayer_UserName);
            this.pnlSms.Controls.Add(this.btnOwner_Region);
            this.pnlSms.Controls.Add(this.cmbPanel);
            this.pnlSms.Controls.Add(this.btnRahn_Rahn);
            this.pnlSms.Controls.Add(this.btnOwner_BuildingCode);
            this.pnlSms.Controls.Add(this.btnOwner_DateSh);
            this.pnlSms.Controls.Add(this.btnRahn_DateSh);
            this.pnlSms.Controls.Add(this.btnOwner_OwnerName);
            this.pnlSms.Controls.Add(this.btnRahn_SayerName);
            this.pnlSms.Controls.Add(this.btnSayer_DateSh);
            this.pnlSms.Controls.Add(this.btnSayer_SayerName);
            this.pnlSms.Controls.Add(this.btnAddPanel);
            this.pnlSms.Controls.Add(this.label20);
            this.pnlSms.Controls.Add(this.label21);
            this.pnlSms.Controls.Add(this.label22);
            this.pnlSms.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlSms.Location = new System.Drawing.Point(6, 10);
            this.pnlSms.Name = "pnlSms";
            this.pnlSms.Size = new System.Drawing.Size(711, 524);
            this.pnlSms.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlSms.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlSms.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnlSms.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlSms.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.pnlSms.Style.BorderWidth = 2;
            this.pnlSms.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlSms.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlSms.Style.GradientAngle = 90;
            this.pnlSms.TabIndex = 8;
            // 
            // txtOwnerText
            // 
            this.txtOwnerText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOwnerText.Location = new System.Drawing.Point(416, 76);
            this.txtOwnerText.Multiline = true;
            this.txtOwnerText.Name = "txtOwnerText";
            this.txtOwnerText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOwnerText.Size = new System.Drawing.Size(177, 178);
            this.txtOwnerText.TabIndex = 3;
            // 
            // txtMatchTextRahn
            // 
            this.txtMatchTextRahn.Location = new System.Drawing.Point(108, 285);
            this.txtMatchTextRahn.Multiline = true;
            this.txtMatchTextRahn.Name = "txtMatchTextRahn";
            this.txtMatchTextRahn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMatchTextRahn.Size = new System.Drawing.Size(485, 223);
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
            this.chbSendAfterMatch.Location = new System.Drawing.Point(336, 260);
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
            this.chbSendSayer.Location = new System.Drawing.Point(31, 44);
            this.chbSendSayer.Name = "chbSendSayer";
            this.chbSendSayer.Size = new System.Drawing.Size(263, 23);
            this.chbSendSayer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbSendSayer.TabIndex = 21;
            this.chbSendSayer.Text = "ارسال پیامک به متقاضی پس از ثبت تقاضا";
            // 
            // btnOwner_UserName
            // 
            this.btnOwner_UserName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwner_UserName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_UserName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_UserName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_UserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_UserName.Location = new System.Drawing.Point(608, 234);
            this.btnOwner_UserName.Name = "btnOwner_UserName";
            this.btnOwner_UserName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOwner_UserName.Size = new System.Drawing.Size(79, 27);
            this.btnOwner_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOwner_UserName.TabIndex = 8;
            this.btnOwner_UserName.Text = "[مشاور]";
            this.btnOwner_UserName.TextColor = System.Drawing.Color.White;
            this.btnOwner_UserName.Click += new System.EventHandler(this.btnOwner_UserName_Click);
            // 
            // btnAddress
            // 
            this.btnAddress.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddress.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddress.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddress.Location = new System.Drawing.Point(11, 417);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnAddress.Size = new System.Drawing.Size(91, 27);
            this.btnAddress.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnAddress.TabIndex = 20;
            this.btnAddress.Text = "[آدرس مجموعه]";
            this.btnAddress.TextColor = System.Drawing.Color.White;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // btnRahn_Ejare
            // 
            this.btnRahn_Ejare.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn_Ejare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRahn_Ejare.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_Ejare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_Ejare.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_Ejare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_Ejare.Location = new System.Drawing.Point(11, 384);
            this.btnRahn_Ejare.Name = "btnRahn_Ejare";
            this.btnRahn_Ejare.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_Ejare.Size = new System.Drawing.Size(91, 27);
            this.btnRahn_Ejare.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_Ejare.TabIndex = 20;
            this.btnRahn_Ejare.Text = "[تلفن مجموعه]";
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
            this.chbSendOwner.Location = new System.Drawing.Point(436, 44);
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
            this.btnOwner_Region.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwner_Region.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_Region.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_Region.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_Region.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_Region.Location = new System.Drawing.Point(608, 201);
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
            this.cmbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPanel.DataSource = this.defBindingSource;
            this.cmbPanel.DisplayMember = "Sender";
            this.cmbPanel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPanel.FormattingEnabled = true;
            this.cmbPanel.Location = new System.Drawing.Point(63, 10);
            this.cmbPanel.Name = "cmbPanel";
            this.cmbPanel.Size = new System.Drawing.Size(528, 28);
            this.cmbPanel.TabIndex = 0;
            this.cmbPanel.ValueMember = "Guid";
            // 
            // btnRahn_Rahn
            // 
            this.btnRahn_Rahn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn_Rahn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRahn_Rahn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_Rahn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_Rahn.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_Rahn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_Rahn.Location = new System.Drawing.Point(11, 351);
            this.btnRahn_Rahn.Name = "btnRahn_Rahn";
            this.btnRahn_Rahn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_Rahn.Size = new System.Drawing.Size(91, 27);
            this.btnRahn_Rahn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_Rahn.TabIndex = 20;
            this.btnRahn_Rahn.Text = "[کانال تلگرام]";
            this.btnRahn_Rahn.TextColor = System.Drawing.Color.White;
            this.btnRahn_Rahn.Click += new System.EventHandler(this.btnRahn_Rahn_Click);
            // 
            // btnOwner_BuildingCode
            // 
            this.btnOwner_BuildingCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_BuildingCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwner_BuildingCode.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_BuildingCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_BuildingCode.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_BuildingCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_BuildingCode.Location = new System.Drawing.Point(608, 168);
            this.btnOwner_BuildingCode.Name = "btnOwner_BuildingCode";
            this.btnOwner_BuildingCode.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnOwner_BuildingCode.Size = new System.Drawing.Size(79, 27);
            this.btnOwner_BuildingCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnOwner_BuildingCode.TabIndex = 6;
            this.btnOwner_BuildingCode.Text = "[کدملک]";
            this.btnOwner_BuildingCode.TextColor = System.Drawing.Color.White;
            this.btnOwner_BuildingCode.Click += new System.EventHandler(this.btnOwner_BuildingCode_Click);
            // 
            // btnOwner_DateSh
            // 
            this.btnOwner_DateSh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_DateSh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwner_DateSh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_DateSh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_DateSh.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_DateSh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_DateSh.Location = new System.Drawing.Point(608, 135);
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
            this.btnRahn_DateSh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRahn_DateSh.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_DateSh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_DateSh.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_DateSh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_DateSh.Location = new System.Drawing.Point(11, 318);
            this.btnRahn_DateSh.Name = "btnRahn_DateSh";
            this.btnRahn_DateSh.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_DateSh.Size = new System.Drawing.Size(91, 27);
            this.btnRahn_DateSh.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn_DateSh.TabIndex = 20;
            this.btnRahn_DateSh.Text = "[تاریخ ارسال]";
            this.btnRahn_DateSh.TextColor = System.Drawing.Color.White;
            this.btnRahn_DateSh.Click += new System.EventHandler(this.btnRahn_DateSh_Click);
            // 
            // btnOwner_OwnerName
            // 
            this.btnOwner_OwnerName.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOwner_OwnerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOwner_OwnerName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnOwner_OwnerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOwner_OwnerName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOwner_OwnerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOwner_OwnerName.Location = new System.Drawing.Point(608, 102);
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
            this.btnRahn_SayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRahn_SayerName.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn_SayerName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn_SayerName.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn_SayerName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn_SayerName.Location = new System.Drawing.Point(11, 285);
            this.btnRahn_SayerName.Name = "btnRahn_SayerName";
            this.btnRahn_SayerName.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn_SayerName.Size = new System.Drawing.Size(91, 27);
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
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(194, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(104, 20);
            this.label20.TabIndex = 7;
            this.label20.Text = "الگوی پیامک ارسالی";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(621, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(82, 20);
            this.label21.TabIndex = 5;
            this.label21.Text = "پنل پیش فرض";
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(599, 79);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 20);
            this.label22.TabIndex = 7;
            this.label22.Text = "الگوی پیامک ارسالی";
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Settings.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(568, 543);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 9;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            this.btnCancel.Image = global::Settings.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(14, 543);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 584);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlSms);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(723, 584);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(723, 584);
            this.Name = "frmSms";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmSms_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSms_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.defBindingSource)).EndInit();
            this.pnlSms.ResumeLayout(false);
            this.pnlSms.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource defBindingSource;
        private DevComponents.DotNetBar.PanelEx pnlSms;
        private System.Windows.Forms.TextBox txtOwnerText;
        private System.Windows.Forms.TextBox txtMatchTextRahn;
        private System.Windows.Forms.TextBox txtSayerText;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSendAfterMatch;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSendSayer;
        private DevComponents.DotNetBar.ButtonX btnOwner_UserName;
        private DevComponents.DotNetBar.ButtonX btnRahn_Ejare;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbSendOwner;
        private DevComponents.DotNetBar.ButtonX btnSayer_UserName;
        private DevComponents.DotNetBar.ButtonX btnOwner_Region;
        private System.Windows.Forms.ComboBox cmbPanel;
        private DevComponents.DotNetBar.ButtonX btnRahn_Rahn;
        private DevComponents.DotNetBar.ButtonX btnOwner_BuildingCode;
        private DevComponents.DotNetBar.ButtonX btnOwner_DateSh;
        private DevComponents.DotNetBar.ButtonX btnRahn_DateSh;
        private DevComponents.DotNetBar.ButtonX btnOwner_OwnerName;
        private DevComponents.DotNetBar.ButtonX btnRahn_SayerName;
        private DevComponents.DotNetBar.ButtonX btnSayer_DateSh;
        private DevComponents.DotNetBar.ButtonX btnSayer_SayerName;
        private DevComponents.DotNetBar.ButtonX btnAddPanel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnAddress;
    }
}