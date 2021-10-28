
namespace Settings.Forms
{
    partial class frmWhatsApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWhatsApp));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.pnlTelegram = new DevComponents.DotNetBar.PanelEx();
            this.btnWhatsAppManager = new DevComponents.DotNetBar.ButtonX();
            this.btnWhatsAppCustomer = new DevComponents.DotNetBar.ButtonX();
            this.txtWhatsAppManagerText = new System.Windows.Forms.TextBox();
            this.txtWhatsAppCustomerText = new System.Windows.Forms.TextBox();
            this.txtWhatsAppNumber = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtWhatsAppToken = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.pnlTelegram.SuspendLayout();
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
            this.btnCancel.Image = global::Settings.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(14, 575);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlTelegram
            // 
            this.pnlTelegram.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlTelegram.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlTelegram.Controls.Add(this.btnWhatsAppManager);
            this.pnlTelegram.Controls.Add(this.btnWhatsAppCustomer);
            this.pnlTelegram.Controls.Add(this.txtWhatsAppManagerText);
            this.pnlTelegram.Controls.Add(this.txtWhatsAppCustomerText);
            this.pnlTelegram.Controls.Add(this.txtWhatsAppNumber);
            this.pnlTelegram.Controls.Add(this.label35);
            this.pnlTelegram.Controls.Add(this.txtWhatsAppToken);
            this.pnlTelegram.Controls.Add(this.label37);
            this.pnlTelegram.Controls.Add(this.label36);
            this.pnlTelegram.Controls.Add(this.label34);
            this.pnlTelegram.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlTelegram.Location = new System.Drawing.Point(7, 12);
            this.pnlTelegram.Name = "pnlTelegram";
            this.pnlTelegram.Size = new System.Drawing.Size(714, 554);
            this.pnlTelegram.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlTelegram.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlTelegram.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnlTelegram.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlTelegram.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.pnlTelegram.Style.BorderWidth = 2;
            this.pnlTelegram.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlTelegram.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlTelegram.Style.GradientAngle = 90;
            this.pnlTelegram.TabIndex = 14;
            // 
            // btnWhatsAppManager
            // 
            this.btnWhatsAppManager.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnWhatsAppManager.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnWhatsAppManager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWhatsAppManager.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnWhatsAppManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhatsAppManager.Location = new System.Drawing.Point(7, 513);
            this.btnWhatsAppManager.Name = "btnWhatsAppManager";
            this.btnWhatsAppManager.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnWhatsAppManager.Size = new System.Drawing.Size(346, 27);
            this.btnWhatsAppManager.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnWhatsAppManager.TabIndex = 33;
            this.btnWhatsAppManager.Text = "اصلاح الگوی پیام ارسالی برای مدیریت";
            this.btnWhatsAppManager.TextColor = System.Drawing.Color.White;
            this.btnWhatsAppManager.Click += new System.EventHandler(this.btnWhatsAppManager_Click);
            // 
            // btnWhatsAppCustomer
            // 
            this.btnWhatsAppCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnWhatsAppCustomer.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnWhatsAppCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnWhatsAppCustomer.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnWhatsAppCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWhatsAppCustomer.Location = new System.Drawing.Point(359, 513);
            this.btnWhatsAppCustomer.Name = "btnWhatsAppCustomer";
            this.btnWhatsAppCustomer.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnWhatsAppCustomer.Size = new System.Drawing.Size(346, 27);
            this.btnWhatsAppCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnWhatsAppCustomer.TabIndex = 34;
            this.btnWhatsAppCustomer.Text = "اطلاح الگوی پیام ارسال برای مشتریان";
            this.btnWhatsAppCustomer.TextColor = System.Drawing.Color.White;
            this.btnWhatsAppCustomer.Click += new System.EventHandler(this.btnWhatsAppCustomer_Click);
            // 
            // txtWhatsAppManagerText
            // 
            this.txtWhatsAppManagerText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhatsAppManagerText.Location = new System.Drawing.Point(7, 62);
            this.txtWhatsAppManagerText.Multiline = true;
            this.txtWhatsAppManagerText.Name = "txtWhatsAppManagerText";
            this.txtWhatsAppManagerText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWhatsAppManagerText.Size = new System.Drawing.Size(349, 445);
            this.txtWhatsAppManagerText.TabIndex = 31;
            // 
            // txtWhatsAppCustomerText
            // 
            this.txtWhatsAppCustomerText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhatsAppCustomerText.Location = new System.Drawing.Point(359, 62);
            this.txtWhatsAppCustomerText.Multiline = true;
            this.txtWhatsAppCustomerText.Name = "txtWhatsAppCustomerText";
            this.txtWhatsAppCustomerText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWhatsAppCustomerText.Size = new System.Drawing.Size(349, 445);
            this.txtWhatsAppCustomerText.TabIndex = 32;
            // 
            // txtWhatsAppNumber
            // 
            this.txtWhatsAppNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhatsAppNumber.Location = new System.Drawing.Point(7, 10);
            this.txtWhatsAppNumber.Name = "txtWhatsAppNumber";
            this.txtWhatsAppNumber.Size = new System.Drawing.Size(243, 27);
            this.txtWhatsAppNumber.TabIndex = 25;
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Location = new System.Drawing.Point(260, 13);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(100, 20);
            this.label35.TabIndex = 27;
            this.label35.Text = "شماره ارسال کننده";
            // 
            // txtWhatsAppToken
            // 
            this.txtWhatsAppToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWhatsAppToken.Location = new System.Drawing.Point(363, 10);
            this.txtWhatsAppToken.Name = "txtWhatsAppToken";
            this.txtWhatsAppToken.Size = new System.Drawing.Size(243, 27);
            this.txtWhatsAppToken.TabIndex = 26;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Location = new System.Drawing.Point(261, 39);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(99, 20);
            this.label37.TabIndex = 28;
            this.label37.Text = "الگوی متن مدیریت";
            // 
            // label36
            // 
            this.label36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Location = new System.Drawing.Point(612, 39);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(103, 20);
            this.label36.TabIndex = 29;
            this.label36.Text = "الگوی متن مشتریان";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Location = new System.Drawing.Point(612, 13);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(100, 20);
            this.label34.TabIndex = 30;
            this.label34.Text = "توکن ارتباط با ربات";
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
            this.btnFinish.Location = new System.Drawing.Point(587, 575);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 15;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // frmWhatsApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 613);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pnlTelegram);
            this.Controls.Add(this.btnFinish);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWhatsApp";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmWhatsApp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmWhatsApp_KeyDown);
            this.pnlTelegram.ResumeLayout(false);
            this.pnlTelegram.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.PanelEx pnlTelegram;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnWhatsAppManager;
        private DevComponents.DotNetBar.ButtonX btnWhatsAppCustomer;
        private System.Windows.Forms.TextBox txtWhatsAppManagerText;
        private System.Windows.Forms.TextBox txtWhatsAppCustomerText;
        private System.Windows.Forms.TextBox txtWhatsAppNumber;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtWhatsAppToken;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label34;
    }
}