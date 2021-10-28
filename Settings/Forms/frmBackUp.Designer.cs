
namespace Settings.Forms
{
    partial class frmBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackUp));
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.chbBackUpSms = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chbOpen = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chbAuto = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtTime = new System.Windows.Forms.NumericUpDown();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnPath = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.panelEx4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.chbBackUpSms);
            this.panelEx4.Controls.Add(this.chbOpen);
            this.panelEx4.Controls.Add(this.chbAuto);
            this.panelEx4.Controls.Add(this.txtTime);
            this.panelEx4.Controls.Add(this.txtPath);
            this.panelEx4.Controls.Add(this.label26);
            this.panelEx4.Controls.Add(this.label27);
            this.panelEx4.Controls.Add(this.label28);
            this.panelEx4.Controls.Add(this.btnPath);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Location = new System.Drawing.Point(2, 29);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(601, 149);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx4.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx4.Style.BorderWidth = 2;
            this.panelEx4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 0;
            // 
            // chbBackUpSms
            // 
            this.chbBackUpSms.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbBackUpSms.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbBackUpSms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbBackUpSms.Location = new System.Drawing.Point(259, 112);
            this.chbBackUpSms.Name = "chbBackUpSms";
            this.chbBackUpSms.Size = new System.Drawing.Size(329, 23);
            this.chbBackUpSms.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbBackUpSms.TabIndex = 5;
            this.chbBackUpSms.Text = "ارسال پیامک به مدیر، پس از انجام عملیات پشتیبان گیری";
            // 
            // chbOpen
            // 
            this.chbOpen.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbOpen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbOpen.Location = new System.Drawing.Point(325, 83);
            this.chbOpen.Name = "chbOpen";
            this.chbOpen.Size = new System.Drawing.Size(263, 23);
            this.chbOpen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbOpen.TabIndex = 4;
            this.chbOpen.Text = "پشتیبان گیری در لحظه اجرای برنامه فعال باشد";
            // 
            // chbAuto
            // 
            this.chbAuto.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chbAuto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chbAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbAuto.Location = new System.Drawing.Point(325, 55);
            this.chbAuto.Name = "chbAuto";
            this.chbAuto.Size = new System.Drawing.Size(263, 23);
            this.chbAuto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chbAuto.TabIndex = 2;
            this.chbAuto.Text = "پشتیبان گیری خودکار فعال باشد";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(49, 51);
            this.txtTime.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(137, 27);
            this.txtTime.TabIndex = 3;
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(49, 18);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(408, 27);
            this.txtPath.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(8, 53);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 20);
            this.label26.TabIndex = 6;
            this.label26.Text = "دقیقه";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(192, 53);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(127, 20);
            this.label27.TabIndex = 6;
            this.label27.Text = "پشتیبان گیری خودکار هر";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Location = new System.Drawing.Point(463, 21);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(129, 20);
            this.label28.TabIndex = 8;
            this.label28.Text = "محل ذخیره فایل پشتیبان";
            // 
            // btnPath
            // 
            this.btnPath.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPath.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPath.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPath.Location = new System.Drawing.Point(8, 18);
            this.btnPath.Name = "btnPath";
            this.btnPath.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnPath.Size = new System.Drawing.Size(35, 27);
            this.btnPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnPath.TabIndex = 1;
            this.btnPath.Text = "...";
            this.btnPath.TextColor = System.Drawing.Color.White;
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
            this.btnFinish.Location = new System.Drawing.Point(428, 185);
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
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Settings.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(51, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 224);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panelEx4);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(607, 224);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(607, 224);
            this.Name = "frmBackUp";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmBackUp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBackUp_KeyDown);
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx4;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbBackUpSms;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbOpen;
        private DevComponents.DotNetBar.Controls.CheckBoxX chbAuto;
        private System.Windows.Forms.NumericUpDown txtTime;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private DevComponents.DotNetBar.ButtonX btnPath;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}