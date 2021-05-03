
namespace User.Advisor
{
    partial class frmAdvisorMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvisorMain));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.txtAccount_ = new WindowsSerivces.CurrencyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMobile2 = new System.Windows.Forms.TextBox();
            this.txtMobile1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::User.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(28, 421);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::User.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(328, 421);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.txtAddress);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.cmbAccount);
            this.grp.Controls.Add(this.txtAccount_);
            this.grp.Controls.Add(this.label6);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.txtMobile2);
            this.grp.Controls.Add(this.txtMobile1);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.txtName);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.label1);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(6, 73);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(463, 326);
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
            // txtAddress
            // 
            this.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAddress.Location = new System.Drawing.Point(22, 184);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(330, 126);
            this.txtAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(412, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "آدرس";
            // 
            // cmbAccount
            // 
            this.cmbAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAccount.DisplayMember = "Name";
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(22, 149);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(330, 28);
            this.cmbAccount.TabIndex = 4;
            this.cmbAccount.ValueMember = "Guid";
            // 
            // txtAccount_
            // 
            this.txtAccount_.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtAccount_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccount_.BackColor = System.Drawing.Color.White;
            this.txtAccount_.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAccount_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtAccount_.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAccount_.Location = new System.Drawing.Point(22, 114);
            this.txtAccount_.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccount_.Name = "txtAccount_";
            this.txtAccount_.Size = new System.Drawing.Size(330, 31);
            this.txtAccount_.TabIndex = 3;
            this.txtAccount_.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(402, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "تشخیص";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(371, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "مانئه اول دوره";
            // 
            // txtMobile2
            // 
            this.txtMobile2.Location = new System.Drawing.Point(22, 83);
            this.txtMobile2.Name = "txtMobile2";
            this.txtMobile2.Size = new System.Drawing.Size(330, 27);
            this.txtMobile2.TabIndex = 2;
            this.txtMobile2.Enter += new System.EventHandler(this.txtMobile2_Enter);
            this.txtMobile2.Leave += new System.EventHandler(this.txtMobile2_Leave);
            // 
            // txtMobile1
            // 
            this.txtMobile1.Location = new System.Drawing.Point(22, 50);
            this.txtMobile1.Name = "txtMobile1";
            this.txtMobile1.Size = new System.Drawing.Size(330, 27);
            this.txtMobile1.TabIndex = 1;
            this.txtMobile1.Enter += new System.EventHandler(this.txtMobile1_Enter);
            this.txtMobile1.Leave += new System.EventHandler(this.txtMobile1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(371, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "شماره همراه 2";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(22, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(330, 27);
            this.txtName.TabIndex = 0;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(371, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "شماره همراه 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(356, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "نام و نام خانوادگی";
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
            this.ucHeader.Location = new System.Drawing.Point(3, 25);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(482, 34);
            this.ucHeader.TabIndex = 8;
            // 
            // frmAdvisorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 470);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(479, 470);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(479, 470);
            this.Name = "frmAdvisorMain";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmAdvisorMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAdvisorMain_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.TextBox txtMobile1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMobile2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbAccount;
        private WindowsSerivces.CurrencyTextBox txtAccount_;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private WindowsSerivces.UC_Header ucHeader;
    }
}