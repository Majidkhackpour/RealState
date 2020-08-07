namespace User
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.pnlExit = new DevComponents.DotNetBar.PanelEx();
            this.pnlOk = new DevComponents.DotNetBar.PanelEx();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecoveryPassword = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Yekan", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(236, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "نرم افزار جامع مدیریت مشاورین املاک آراد";
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.Color.Transparent;
            this.grp.Controls.Add(this.pnlExit);
            this.grp.Controls.Add(this.pnlOk);
            this.grp.Controls.Add(this.txtPass1);
            this.grp.Controls.Add(this.txtUserName);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label3);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(66, 141);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(463, 180);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Alpha = ((byte)(0));
            this.grp.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.grp.Style.BackColor2.Alpha = ((byte)(0));
            this.grp.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Black;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 4;
            // 
            // pnlExit
            // 
            this.pnlExit.CanvasColor = System.Drawing.Color.Transparent;
            this.pnlExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlExit.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlExit.Location = new System.Drawing.Point(19, 105);
            this.pnlExit.Name = "pnlExit";
            this.pnlExit.Size = new System.Drawing.Size(120, 47);
            this.pnlExit.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlExit.Style.BackColor1.Alpha = ((byte)(0));
            this.pnlExit.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.pnlExit.Style.BackColor2.Alpha = ((byte)(0));
            this.pnlExit.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.pnlExit.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlExit.Style.BorderColor.Color = System.Drawing.Color.Black;
            this.pnlExit.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlExit.Style.ForeColor.Color = System.Drawing.Color.Black;
            this.pnlExit.Style.GradientAngle = 90;
            this.pnlExit.TabIndex = 8;
            this.pnlExit.Text = "خروج";
            this.pnlExit.Click += new System.EventHandler(this.pnlExit_Click);
            this.pnlExit.MouseEnter += new System.EventHandler(this.pnlExit_MouseEnter);
            this.pnlExit.MouseLeave += new System.EventHandler(this.pnlExit_MouseLeave);
            // 
            // pnlOk
            // 
            this.pnlOk.CanvasColor = System.Drawing.Color.Transparent;
            this.pnlOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOk.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlOk.Location = new System.Drawing.Point(229, 105);
            this.pnlOk.Name = "pnlOk";
            this.pnlOk.Size = new System.Drawing.Size(120, 47);
            this.pnlOk.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlOk.Style.BackColor1.Alpha = ((byte)(0));
            this.pnlOk.Style.BackColor1.Color = System.Drawing.Color.Transparent;
            this.pnlOk.Style.BackColor2.Alpha = ((byte)(0));
            this.pnlOk.Style.BackColor2.Color = System.Drawing.Color.Transparent;
            this.pnlOk.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlOk.Style.BorderColor.Color = System.Drawing.Color.Black;
            this.pnlOk.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlOk.Style.ForeColor.Color = System.Drawing.Color.Black;
            this.pnlOk.Style.GradientAngle = 90;
            this.pnlOk.TabIndex = 8;
            this.pnlOk.Text = "ورود به سیستم";
            this.pnlOk.Click += new System.EventHandler(this.pnlOk_Click);
            this.pnlOk.MouseEnter += new System.EventHandler(this.pnlOk_MouseEnter);
            this.pnlOk.MouseLeave += new System.EventHandler(this.pnlOk_MouseLeave);
            // 
            // txtPass1
            // 
            this.txtPass1.Location = new System.Drawing.Point(19, 62);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.Size = new System.Drawing.Size(330, 27);
            this.txtPass1.TabIndex = 9;
            this.txtPass1.UseSystemPasswordChar = true;
            // 
            // txtUserName
            // 
            this.txtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtUserName.Location = new System.Drawing.Point(19, 26);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(330, 27);
            this.txtUserName.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(390, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "نام کاربری";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(397, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "رمز عبور";
            // 
            // lblRecoveryPassword
            // 
            this.lblRecoveryPassword.AutoSize = true;
            this.lblRecoveryPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblRecoveryPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecoveryPassword.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRecoveryPassword.Location = new System.Drawing.Point(190, 332);
            this.lblRecoveryPassword.Name = "lblRecoveryPassword";
            this.lblRecoveryPassword.Size = new System.Drawing.Size(184, 20);
            this.lblRecoveryPassword.TabIndex = 11;
            this.lblRecoveryPassword.Text = "رمز عبور خود را فراموش کرده ام...!";
            this.lblRecoveryPassword.Click += new System.EventHandler(this.lblRecoveryPassword_Click);
            this.lblRecoveryPassword.MouseEnter += new System.EventHandler(this.lblRecoveryPassword_MouseEnter);
            this.lblRecoveryPassword.MouseLeave += new System.EventHandler(this.lblRecoveryPassword_MouseLeave);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::User.Properties.Resources._400063700833_50757;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecoveryPassword);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.PanelEx pnlExit;
        private DevComponents.DotNetBar.PanelEx pnlOk;
        private System.Windows.Forms.Label lblRecoveryPassword;
    }
}