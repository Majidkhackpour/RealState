namespace User
{
    partial class frmForgetPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForgetPassword));
            this.rbtnQuestion = new System.Windows.Forms.RadioButton();
            this.rbtnMobile = new System.Windows.Forms.RadioButton();
            this.rbtnEmail = new System.Windows.Forms.RadioButton();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.grpQuestion = new DevComponents.DotNetBar.PanelEx();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.cmbQuestion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.grpMobile = new DevComponents.DotNetBar.PanelEx();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpEmail = new DevComponents.DotNetBar.PanelEx();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.grpQuestion.SuspendLayout();
            this.grpMobile.SuspendLayout();
            this.grpEmail.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnQuestion
            // 
            this.rbtnQuestion.AutoSize = true;
            this.rbtnQuestion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnQuestion.Location = new System.Drawing.Point(275, 71);
            this.rbtnQuestion.Name = "rbtnQuestion";
            this.rbtnQuestion.Size = new System.Drawing.Size(165, 24);
            this.rbtnQuestion.TabIndex = 0;
            this.rbtnQuestion.TabStop = true;
            this.rbtnQuestion.Text = "بازیابی از طریق سوال امنیتی";
            this.rbtnQuestion.UseVisualStyleBackColor = true;
            this.rbtnQuestion.CheckedChanged += new System.EventHandler(this.rbtnQuestion_CheckedChanged);
            // 
            // rbtnMobile
            // 
            this.rbtnMobile.AutoSize = true;
            this.rbtnMobile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnMobile.Location = new System.Drawing.Point(274, 105);
            this.rbtnMobile.Name = "rbtnMobile";
            this.rbtnMobile.Size = new System.Drawing.Size(166, 24);
            this.rbtnMobile.TabIndex = 1;
            this.rbtnMobile.TabStop = true;
            this.rbtnMobile.Text = "بازیابی از طریق شماره موبایل";
            this.rbtnMobile.UseVisualStyleBackColor = true;
            this.rbtnMobile.CheckedChanged += new System.EventHandler(this.rbtnMobile_CheckedChanged);
            // 
            // rbtnEmail
            // 
            this.rbtnEmail.AutoSize = true;
            this.rbtnEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnEmail.Location = new System.Drawing.Point(309, 138);
            this.rbtnEmail.Name = "rbtnEmail";
            this.rbtnEmail.Size = new System.Drawing.Size(131, 24);
            this.rbtnEmail.TabIndex = 2;
            this.rbtnEmail.TabStop = true;
            this.rbtnEmail.Text = "بازیابی از طریق ایمیل";
            this.rbtnEmail.UseVisualStyleBackColor = true;
            this.rbtnEmail.CheckedChanged += new System.EventHandler(this.rbtnEmail_CheckedChanged);
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(23, 171);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(407, 23);
            this.line1.TabIndex = 1;
            this.line1.Text = "line1";
            this.line1.Thickness = 2;
            // 
            // grpQuestion
            // 
            this.grpQuestion.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpQuestion.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grpQuestion.Controls.Add(this.txtAnswer);
            this.grpQuestion.Controls.Add(this.cmbQuestion);
            this.grpQuestion.Controls.Add(this.label5);
            this.grpQuestion.Controls.Add(this.label7);
            this.grpQuestion.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpQuestion.Location = new System.Drawing.Point(23, 200);
            this.grpQuestion.Name = "grpQuestion";
            this.grpQuestion.Size = new System.Drawing.Size(424, 95);
            this.grpQuestion.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grpQuestion.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grpQuestion.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grpQuestion.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grpQuestion.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grpQuestion.Style.BorderWidth = 2;
            this.grpQuestion.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpQuestion.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpQuestion.Style.GradientAngle = 90;
            this.grpQuestion.TabIndex = 10;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(24, 52);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(315, 27);
            this.txtAnswer.TabIndex = 8;
            // 
            // cmbQuestion
            // 
            this.cmbQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestion.FormattingEnabled = true;
            this.cmbQuestion.Location = new System.Drawing.Point(24, 13);
            this.cmbQuestion.Name = "cmbQuestion";
            this.cmbQuestion.Size = new System.Drawing.Size(315, 28);
            this.cmbQuestion.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(345, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "سوال امنیتی";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(353, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "پاسخ سوال";
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::User.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(316, 310);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 11;
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
            this.btnCancel.Image = global::User.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(23, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpMobile
            // 
            this.grpMobile.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpMobile.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grpMobile.Controls.Add(this.txtMobile);
            this.grpMobile.Controls.Add(this.label2);
            this.grpMobile.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpMobile.Location = new System.Drawing.Point(23, 200);
            this.grpMobile.Name = "grpMobile";
            this.grpMobile.Size = new System.Drawing.Size(424, 53);
            this.grpMobile.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grpMobile.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grpMobile.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grpMobile.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grpMobile.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grpMobile.Style.BorderWidth = 2;
            this.grpMobile.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpMobile.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpMobile.Style.GradientAngle = 90;
            this.grpMobile.TabIndex = 10;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(24, 11);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(315, 27);
            this.txtMobile.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(376, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "موبایل";
            // 
            // grpEmail
            // 
            this.grpEmail.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpEmail.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grpEmail.Controls.Add(this.txtEmail);
            this.grpEmail.Controls.Add(this.label1);
            this.grpEmail.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpEmail.Location = new System.Drawing.Point(23, 200);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(424, 53);
            this.grpEmail.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grpEmail.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grpEmail.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grpEmail.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grpEmail.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grpEmail.Style.BorderWidth = 2;
            this.grpEmail.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpEmail.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grpEmail.Style.GradientAngle = 90;
            this.grpEmail.TabIndex = 10;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(24, 11);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(315, 27);
            this.txtEmail.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(376, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "ایمیل";
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
            this.ucHeader.Location = new System.Drawing.Point(-11, 32);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(482, 34);
            this.ucHeader.TabIndex = 20;
            // 
            // frmForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 349);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.grpMobile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grpEmail);
            this.Controls.Add(this.grpQuestion);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.rbtnEmail);
            this.Controls.Add(this.rbtnMobile);
            this.Controls.Add(this.rbtnQuestion);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmForgetPassword";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmForgetPassword_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmForgetPassword_KeyDown);
            this.grpQuestion.ResumeLayout(false);
            this.grpQuestion.PerformLayout();
            this.grpMobile.ResumeLayout(false);
            this.grpMobile.PerformLayout();
            this.grpEmail.ResumeLayout(false);
            this.grpEmail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnQuestion;
        private System.Windows.Forms.RadioButton rbtnMobile;
        private System.Windows.Forms.RadioButton rbtnEmail;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.PanelEx grpQuestion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbQuestion;
        private System.Windows.Forms.TextBox txtAnswer;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.PanelEx grpMobile;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.PanelEx grpEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private WindowsSerivces.UC_Header ucHeader;
    }
}