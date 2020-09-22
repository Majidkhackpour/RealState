namespace Settings
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.lblBackUp = new System.Windows.Forms.Label();
            this.lblRobot = new System.Windows.Forms.Label();
            this.lblTelegram = new System.Windows.Forms.Label();
            this.lblSms = new System.Windows.Forms.Label();
            this.lblSandouq = new System.Windows.Forms.Label();
            this.lblEconomyUnit = new System.Windows.Forms.Label();
            this.pnlContent = new DevComponents.DotNetBar.PanelEx();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnCancel);
            this.panelEx1.Controls.Add(this.lblBackUp);
            this.panelEx1.Controls.Add(this.lblRobot);
            this.panelEx1.Controls.Add(this.lblTelegram);
            this.panelEx1.Controls.Add(this.lblSms);
            this.panelEx1.Controls.Add(this.lblSandouq);
            this.panelEx1.Controls.Add(this.lblEconomyUnit);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(619, 14);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(175, 571);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.Gray;
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Settings.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(25, 521);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            // 
            // lblBackUp
            // 
            this.lblBackUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBackUp.AutoSize = true;
            this.lblBackUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBackUp.Location = new System.Drawing.Point(38, 181);
            this.lblBackUp.Name = "lblBackUp";
            this.lblBackUp.Size = new System.Drawing.Size(116, 20);
            this.lblBackUp.TabIndex = 5;
            this.lblBackUp.Text = "تنظیمات پشتیبان گیری";
            this.lblBackUp.Click += new System.EventHandler(this.lblBackUp_Click);
            this.lblBackUp.MouseEnter += new System.EventHandler(this.lblBackUp_MouseEnter);
            this.lblBackUp.MouseLeave += new System.EventHandler(this.lblBackUp_MouseLeave);
            // 
            // lblRobot
            // 
            this.lblRobot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRobot.AutoSize = true;
            this.lblRobot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRobot.Location = new System.Drawing.Point(9, 147);
            this.lblRobot.Name = "lblRobot";
            this.lblRobot.Size = new System.Drawing.Size(145, 20);
            this.lblRobot.TabIndex = 5;
            this.lblRobot.Text = "تنظیمات ربات دیوار و شیپور";
            this.lblRobot.Click += new System.EventHandler(this.lblRobot_Click);
            this.lblRobot.MouseEnter += new System.EventHandler(this.lblRobot_MouseEnter);
            this.lblRobot.MouseLeave += new System.EventHandler(this.lblRobot_MouseLeave);
            // 
            // lblTelegram
            // 
            this.lblTelegram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTelegram.AutoSize = true;
            this.lblTelegram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTelegram.Location = new System.Drawing.Point(72, 113);
            this.lblTelegram.Name = "lblTelegram";
            this.lblTelegram.Size = new System.Drawing.Size(82, 20);
            this.lblTelegram.TabIndex = 5;
            this.lblTelegram.Text = "تنظیمات تلگرام";
            this.lblTelegram.Click += new System.EventHandler(this.lblTelegram_Click);
            this.lblTelegram.MouseEnter += new System.EventHandler(this.lblTelegram_MouseEnter);
            this.lblTelegram.MouseLeave += new System.EventHandler(this.lblTelegram_MouseLeave);
            // 
            // lblSms
            // 
            this.lblSms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSms.AutoSize = true;
            this.lblSms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSms.Location = new System.Drawing.Point(52, 79);
            this.lblSms.Name = "lblSms";
            this.lblSms.Size = new System.Drawing.Size(102, 20);
            this.lblSms.TabIndex = 5;
            this.lblSms.Text = "تنظیمات پیام رسانی";
            this.lblSms.Click += new System.EventHandler(this.lblSms_Click);
            this.lblSms.MouseEnter += new System.EventHandler(this.lblSms_MouseEnter);
            this.lblSms.MouseLeave += new System.EventHandler(this.lblSms_MouseLeave);
            // 
            // lblSandouq
            // 
            this.lblSandouq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSandouq.AutoSize = true;
            this.lblSandouq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSandouq.Location = new System.Drawing.Point(32, 45);
            this.lblSandouq.Name = "lblSandouq";
            this.lblSandouq.Size = new System.Drawing.Size(122, 20);
            this.lblSandouq.TabIndex = 5;
            this.lblSandouq.Text = "تنظیمات صندوق مکانیزه";
            this.lblSandouq.Click += new System.EventHandler(this.lblSandouq_Click);
            this.lblSandouq.MouseEnter += new System.EventHandler(this.lblSandouq_MouseEnter);
            this.lblSandouq.MouseLeave += new System.EventHandler(this.lblSandouq_MouseLeave);
            // 
            // lblEconomyUnit
            // 
            this.lblEconomyUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEconomyUnit.AutoSize = true;
            this.lblEconomyUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEconomyUnit.Location = new System.Drawing.Point(35, 11);
            this.lblEconomyUnit.Name = "lblEconomyUnit";
            this.lblEconomyUnit.Size = new System.Drawing.Size(119, 20);
            this.lblEconomyUnit.TabIndex = 5;
            this.lblEconomyUnit.Text = "تنظیمات واحد اقتصادی";
            this.lblEconomyUnit.Click += new System.EventHandler(this.lblEconomyUnit_Click);
            this.lblEconomyUnit.MouseEnter += new System.EventHandler(this.lblEconomyUnit_MouseEnter);
            this.lblEconomyUnit.MouseLeave += new System.EventHandler(this.lblEconomyUnit_MouseLeave);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlContent.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlContent.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlContent.Location = new System.Drawing.Point(4, 14);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(609, 571);
            this.pnlContent.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlContent.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlContent.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnlContent.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlContent.Style.BorderColor.Color = System.Drawing.Color.White;
            this.pnlContent.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlContent.Style.GradientAngle = 90;
            this.pnlContent.TabIndex = 15;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmSettings";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSettings_KeyDown);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.Label lblBackUp;
        private System.Windows.Forms.Label lblRobot;
        private System.Windows.Forms.Label lblTelegram;
        private System.Windows.Forms.Label lblSms;
        private System.Windows.Forms.Label lblSandouq;
        private System.Windows.Forms.Label lblEconomyUnit;
        private DevComponents.DotNetBar.PanelEx pnlContent;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}