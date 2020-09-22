namespace Settings.SettingForms
{
    partial class frmTelegramSetting
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
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnMasahat = new DevComponents.DotNetBar.ButtonX();
            this.btnRahn = new DevComponents.DotNetBar.ButtonX();
            this.btnRegion = new DevComponents.DotNetBar.ButtonX();
            this.btnConType = new DevComponents.DotNetBar.ButtonX();
            this.btnCode = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnType = new DevComponents.DotNetBar.ButtonX();
            this.btnAccType = new DevComponents.DotNetBar.ButtonX();
            this.btnSell = new DevComponents.DotNetBar.ButtonX();
            this.btnEjare = new DevComponents.DotNetBar.ButtonX();
            this.btnZirBana = new DevComponents.DotNetBar.ButtonX();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDocType = new DevComponents.DotNetBar.ButtonX();
            this.btnSide = new DevComponents.DotNetBar.ButtonX();
            this.btnTarakom = new DevComponents.DotNetBar.ButtonX();
            this.btnTabaqeNo = new DevComponents.DotNetBar.ButtonX();
            this.btnTabaqeCount = new DevComponents.DotNetBar.ButtonX();
            this.btnRoomCount = new DevComponents.DotNetBar.ButtonX();
            this.btnSaleSakht = new DevComponents.DotNetBar.ButtonX();
            this.btnTejari = new DevComponents.DotNetBar.ButtonX();
            this.btnChannel = new DevComponents.DotNetBar.ButtonX();
            this.grp.SuspendLayout();
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
            this.btnFinish.Location = new System.Drawing.Point(408, 538);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 1;
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
            this.btnCancel.Location = new System.Drawing.Point(52, 538);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.txtChannel);
            this.grp.Controls.Add(this.txtToken);
            this.grp.Controls.Add(this.txtText);
            this.grp.Controls.Add(this.btnZirBana);
            this.grp.Controls.Add(this.btnChannel);
            this.grp.Controls.Add(this.btnMasahat);
            this.grp.Controls.Add(this.btnTejari);
            this.grp.Controls.Add(this.btnEjare);
            this.grp.Controls.Add(this.btnSaleSakht);
            this.grp.Controls.Add(this.btnRahn);
            this.grp.Controls.Add(this.btnRoomCount);
            this.grp.Controls.Add(this.btnSell);
            this.grp.Controls.Add(this.btnTabaqeCount);
            this.grp.Controls.Add(this.btnRegion);
            this.grp.Controls.Add(this.btnTabaqeNo);
            this.grp.Controls.Add(this.btnAccType);
            this.grp.Controls.Add(this.btnTarakom);
            this.grp.Controls.Add(this.btnConType);
            this.grp.Controls.Add(this.btnSide);
            this.grp.Controls.Add(this.btnType);
            this.grp.Controls.Add(this.btnDocType);
            this.grp.Controls.Add(this.btnCode);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label3);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(5, 8);
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
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(197, 80);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(285, 427);
            this.txtText.TabIndex = 22;
            // 
            // btnMasahat
            // 
            this.btnMasahat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMasahat.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnMasahat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMasahat.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMasahat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasahat.Location = new System.Drawing.Point(112, 212);
            this.btnMasahat.Name = "btnMasahat";
            this.btnMasahat.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnMasahat.Size = new System.Drawing.Size(79, 27);
            this.btnMasahat.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnMasahat.TabIndex = 10;
            this.btnMasahat.Text = "[مساحت]";
            this.btnMasahat.TextColor = System.Drawing.Color.White;
            this.btnMasahat.Click += new System.EventHandler(this.btnMasahat_Click);
            // 
            // btnRahn
            // 
            this.btnRahn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRahn.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRahn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRahn.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRahn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRahn.Location = new System.Drawing.Point(112, 179);
            this.btnRahn.Name = "btnRahn";
            this.btnRahn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRahn.Size = new System.Drawing.Size(79, 27);
            this.btnRahn.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRahn.TabIndex = 8;
            this.btnRahn.Text = "[ق رهن]";
            this.btnRahn.TextColor = System.Drawing.Color.White;
            this.btnRahn.Click += new System.EventHandler(this.btnRahn_Click);
            // 
            // btnRegion
            // 
            this.btnRegion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRegion.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRegion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegion.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRegion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegion.Location = new System.Drawing.Point(112, 146);
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRegion.Size = new System.Drawing.Size(79, 27);
            this.btnRegion.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRegion.TabIndex = 6;
            this.btnRegion.Text = "[محدوده]";
            this.btnRegion.TextColor = System.Drawing.Color.White;
            this.btnRegion.Click += new System.EventHandler(this.btnRegion_Click);
            // 
            // btnConType
            // 
            this.btnConType.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConType.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnConType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConType.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnConType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConType.Location = new System.Drawing.Point(112, 113);
            this.btnConType.Name = "btnConType";
            this.btnConType.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnConType.Size = new System.Drawing.Size(79, 27);
            this.btnConType.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnConType.TabIndex = 4;
            this.btnConType.Text = "[نوع معامله]";
            this.btnConType.TextColor = System.Drawing.Color.White;
            this.btnConType.Click += new System.EventHandler(this.btnConType_Click);
            // 
            // btnCode
            // 
            this.btnCode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCode.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCode.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCode.Location = new System.Drawing.Point(112, 80);
            this.btnCode.Name = "btnCode";
            this.btnCode.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCode.Size = new System.Drawing.Size(79, 27);
            this.btnCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCode.TabIndex = 2;
            this.btnCode.Text = "[کد ملک]";
            this.btnCode.TextColor = System.Drawing.Color.White;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(492, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "توکن ارتباط با ربات";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(491, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "الگوی پست ارسالی";
            // 
            // btnType
            // 
            this.btnType.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnType.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnType.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnType.Location = new System.Drawing.Point(27, 80);
            this.btnType.Name = "btnType";
            this.btnType.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnType.Size = new System.Drawing.Size(79, 27);
            this.btnType.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnType.TabIndex = 3;
            this.btnType.Text = "[نوع ملک]";
            this.btnType.TextColor = System.Drawing.Color.White;
            this.btnType.Click += new System.EventHandler(this.btnType_Click);
            // 
            // btnAccType
            // 
            this.btnAccType.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAccType.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAccType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAccType.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAccType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccType.Location = new System.Drawing.Point(27, 113);
            this.btnAccType.Name = "btnAccType";
            this.btnAccType.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnAccType.Size = new System.Drawing.Size(79, 27);
            this.btnAccType.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnAccType.TabIndex = 5;
            this.btnAccType.Text = "[نوع کاربری]";
            this.btnAccType.TextColor = System.Drawing.Color.White;
            this.btnAccType.Click += new System.EventHandler(this.btnAccType_Click);
            // 
            // btnSell
            // 
            this.btnSell.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSell.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSell.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSell.Location = new System.Drawing.Point(27, 146);
            this.btnSell.Name = "btnSell";
            this.btnSell.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSell.Size = new System.Drawing.Size(79, 27);
            this.btnSell.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSell.TabIndex = 7;
            this.btnSell.Text = "[ق فروش]";
            this.btnSell.TextColor = System.Drawing.Color.White;
            this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
            // 
            // btnEjare
            // 
            this.btnEjare.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEjare.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEjare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEjare.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEjare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEjare.Location = new System.Drawing.Point(27, 179);
            this.btnEjare.Name = "btnEjare";
            this.btnEjare.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnEjare.Size = new System.Drawing.Size(79, 27);
            this.btnEjare.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnEjare.TabIndex = 9;
            this.btnEjare.Text = "[ق اجاره]";
            this.btnEjare.TextColor = System.Drawing.Color.White;
            this.btnEjare.Click += new System.EventHandler(this.btnEjare_Click);
            // 
            // btnZirBana
            // 
            this.btnZirBana.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnZirBana.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnZirBana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnZirBana.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnZirBana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnZirBana.Location = new System.Drawing.Point(27, 212);
            this.btnZirBana.Name = "btnZirBana";
            this.btnZirBana.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnZirBana.Size = new System.Drawing.Size(79, 27);
            this.btnZirBana.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnZirBana.TabIndex = 11;
            this.btnZirBana.Text = "[زیربنا]";
            this.btnZirBana.TextColor = System.Drawing.Color.White;
            this.btnZirBana.Click += new System.EventHandler(this.btnZirBana_Click);
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(11, 43);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(471, 27);
            this.txtChannel.TabIndex = 1;
            this.txtChannel.Enter += new System.EventHandler(this.txtChannel_Enter);
            this.txtChannel.Leave += new System.EventHandler(this.txtChannel_Leave);
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(11, 10);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(471, 27);
            this.txtToken.TabIndex = 0;
            this.txtToken.Enter += new System.EventHandler(this.txtToken_Enter);
            this.txtToken.Leave += new System.EventHandler(this.txtToken_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(526, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "آدرس کانال";
            // 
            // btnDocType
            // 
            this.btnDocType.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDocType.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDocType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDocType.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDocType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDocType.Location = new System.Drawing.Point(112, 245);
            this.btnDocType.Name = "btnDocType";
            this.btnDocType.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDocType.Size = new System.Drawing.Size(79, 27);
            this.btnDocType.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDocType.TabIndex = 12;
            this.btnDocType.Text = "[نوع سند]";
            this.btnDocType.TextColor = System.Drawing.Color.White;
            this.btnDocType.Click += new System.EventHandler(this.btnDocType_Click);
            // 
            // btnSide
            // 
            this.btnSide.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSide.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSide.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSide.Location = new System.Drawing.Point(27, 245);
            this.btnSide.Name = "btnSide";
            this.btnSide.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSide.Size = new System.Drawing.Size(79, 27);
            this.btnSide.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSide.TabIndex = 13;
            this.btnSide.Text = "[جهت]";
            this.btnSide.TextColor = System.Drawing.Color.White;
            this.btnSide.Click += new System.EventHandler(this.btnSide_Click);
            // 
            // btnTarakom
            // 
            this.btnTarakom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTarakom.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTarakom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTarakom.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTarakom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTarakom.Location = new System.Drawing.Point(112, 278);
            this.btnTarakom.Name = "btnTarakom";
            this.btnTarakom.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnTarakom.Size = new System.Drawing.Size(79, 27);
            this.btnTarakom.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnTarakom.TabIndex = 14;
            this.btnTarakom.Text = "[تراکم]";
            this.btnTarakom.TextColor = System.Drawing.Color.White;
            this.btnTarakom.Click += new System.EventHandler(this.btnTarakom_Click);
            // 
            // btnTabaqeNo
            // 
            this.btnTabaqeNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTabaqeNo.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTabaqeNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTabaqeNo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTabaqeNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabaqeNo.Location = new System.Drawing.Point(27, 278);
            this.btnTabaqeNo.Name = "btnTabaqeNo";
            this.btnTabaqeNo.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnTabaqeNo.Size = new System.Drawing.Size(79, 27);
            this.btnTabaqeNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnTabaqeNo.TabIndex = 15;
            this.btnTabaqeNo.Text = "[ش طبقه]";
            this.btnTabaqeNo.TextColor = System.Drawing.Color.White;
            this.btnTabaqeNo.Click += new System.EventHandler(this.btnTabaqeNo_Click);
            // 
            // btnTabaqeCount
            // 
            this.btnTabaqeCount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTabaqeCount.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTabaqeCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTabaqeCount.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTabaqeCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabaqeCount.Location = new System.Drawing.Point(112, 311);
            this.btnTabaqeCount.Name = "btnTabaqeCount";
            this.btnTabaqeCount.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnTabaqeCount.Size = new System.Drawing.Size(79, 27);
            this.btnTabaqeCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnTabaqeCount.TabIndex = 16;
            this.btnTabaqeCount.Text = "[تعداد طبقات]";
            this.btnTabaqeCount.TextColor = System.Drawing.Color.White;
            this.btnTabaqeCount.Click += new System.EventHandler(this.btnTabaqeCount_Click);
            // 
            // btnRoomCount
            // 
            this.btnRoomCount.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRoomCount.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRoomCount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRoomCount.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRoomCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoomCount.Location = new System.Drawing.Point(27, 311);
            this.btnRoomCount.Name = "btnRoomCount";
            this.btnRoomCount.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRoomCount.Size = new System.Drawing.Size(79, 27);
            this.btnRoomCount.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRoomCount.TabIndex = 17;
            this.btnRoomCount.Text = "[تعداد اتاق]";
            this.btnRoomCount.TextColor = System.Drawing.Color.White;
            this.btnRoomCount.Click += new System.EventHandler(this.btnRoomCount_Click);
            // 
            // btnSaleSakht
            // 
            this.btnSaleSakht.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaleSakht.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSaleSakht.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaleSakht.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSaleSakht.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaleSakht.Location = new System.Drawing.Point(112, 344);
            this.btnSaleSakht.Name = "btnSaleSakht";
            this.btnSaleSakht.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSaleSakht.Size = new System.Drawing.Size(79, 27);
            this.btnSaleSakht.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSaleSakht.TabIndex = 18;
            this.btnSaleSakht.Text = "[سال ساخت]";
            this.btnSaleSakht.TextColor = System.Drawing.Color.White;
            this.btnSaleSakht.Click += new System.EventHandler(this.btnSaleSakht_Click);
            // 
            // btnTejari
            // 
            this.btnTejari.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTejari.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTejari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTejari.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTejari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTejari.Location = new System.Drawing.Point(27, 344);
            this.btnTejari.Name = "btnTejari";
            this.btnTejari.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnTejari.Size = new System.Drawing.Size(79, 27);
            this.btnTejari.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnTejari.TabIndex = 19;
            this.btnTejari.Text = "[متراژ تجاری]";
            this.btnTejari.TextColor = System.Drawing.Color.White;
            this.btnTejari.Click += new System.EventHandler(this.btnTejari_Click);
            // 
            // btnChannel
            // 
            this.btnChannel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChannel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChannel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnChannel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChannel.Location = new System.Drawing.Point(27, 377);
            this.btnChannel.Name = "btnChannel";
            this.btnChannel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnChannel.Size = new System.Drawing.Size(164, 27);
            this.btnChannel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnChannel.TabIndex = 20;
            this.btnChannel.Text = "[آدرس کانال]";
            this.btnChannel.TextColor = System.Drawing.Color.White;
            this.btnChannel.Click += new System.EventHandler(this.btnChannel_Click);
            // 
            // frmTelegramSetting
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
            this.Name = "frmTelegramSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmTelegramSetting_Load);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.TextBox txtText;
        private DevComponents.DotNetBar.ButtonX btnMasahat;
        private DevComponents.DotNetBar.ButtonX btnRahn;
        private DevComponents.DotNetBar.ButtonX btnRegion;
        private DevComponents.DotNetBar.ButtonX btnConType;
        private DevComponents.DotNetBar.ButtonX btnCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnZirBana;
        private DevComponents.DotNetBar.ButtonX btnEjare;
        private DevComponents.DotNetBar.ButtonX btnSell;
        private DevComponents.DotNetBar.ButtonX btnAccType;
        private DevComponents.DotNetBar.ButtonX btnType;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnChannel;
        private DevComponents.DotNetBar.ButtonX btnTejari;
        private DevComponents.DotNetBar.ButtonX btnSaleSakht;
        private DevComponents.DotNetBar.ButtonX btnRoomCount;
        private DevComponents.DotNetBar.ButtonX btnTabaqeCount;
        private DevComponents.DotNetBar.ButtonX btnTabaqeNo;
        private DevComponents.DotNetBar.ButtonX btnTarakom;
        private DevComponents.DotNetBar.ButtonX btnSide;
        private DevComponents.DotNetBar.ButtonX btnDocType;
    }
}