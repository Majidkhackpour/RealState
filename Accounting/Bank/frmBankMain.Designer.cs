
namespace Accounting.Bank
{
    partial class frmBankMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBankMain));
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHesabNumber = new System.Windows.Forms.TextBox();
            this.txtCodeShobe = new System.Windows.Forms.TextBox();
            this.txtShobe = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.txtAccount_ = new WindowsSerivces.CurrencyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grp.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.cmbAccount);
            this.grp.Controls.Add(this.txtAccount_);
            this.grp.Controls.Add(this.label6);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.txtCode);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txtDesc);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.txtHesabNumber);
            this.grp.Controls.Add(this.txtCodeShobe);
            this.grp.Controls.Add(this.txtShobe);
            this.grp.Controls.Add(this.txtName);
            this.grp.Controls.Add(this.label7);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(8, 30);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(463, 437);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(385, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "شماره حساب";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(407, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "کد شعبه";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(422, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "شعبه";
            // 
            // txtCode
            // 
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCode.Location = new System.Drawing.Point(15, 14);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(365, 27);
            this.txtCode.TabIndex = 0;
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(435, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "کد";
            // 
            // txtDesc
            // 
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.Location = new System.Drawing.Point(15, 267);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(364, 158);
            this.txtDesc.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(402, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "توضیحات";
            // 
            // txtHesabNumber
            // 
            this.txtHesabNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtHesabNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtHesabNumber.Location = new System.Drawing.Point(15, 157);
            this.txtHesabNumber.Name = "txtHesabNumber";
            this.txtHesabNumber.Size = new System.Drawing.Size(364, 27);
            this.txtHesabNumber.TabIndex = 4;
            this.txtHesabNumber.Enter += new System.EventHandler(this.txtHesabNumber_Enter);
            this.txtHesabNumber.Leave += new System.EventHandler(this.txtHesabNumber_Leave);
            // 
            // txtCodeShobe
            // 
            this.txtCodeShobe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCodeShobe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCodeShobe.Location = new System.Drawing.Point(16, 121);
            this.txtCodeShobe.Name = "txtCodeShobe";
            this.txtCodeShobe.Size = new System.Drawing.Size(364, 27);
            this.txtCodeShobe.TabIndex = 3;
            this.txtCodeShobe.Enter += new System.EventHandler(this.txtCodeShobe_Enter);
            this.txtCodeShobe.Leave += new System.EventHandler(this.txtCodeShobe_Leave);
            // 
            // txtShobe
            // 
            this.txtShobe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtShobe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShobe.Location = new System.Drawing.Point(16, 86);
            this.txtShobe.Name = "txtShobe";
            this.txtShobe.Size = new System.Drawing.Size(364, 27);
            this.txtShobe.TabIndex = 2;
            this.txtShobe.Enter += new System.EventHandler(this.txtShobe_Enter);
            this.txtShobe.Leave += new System.EventHandler(this.txtShobe_Leave);
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Location = new System.Drawing.Point(15, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(364, 27);
            this.txtName.TabIndex = 1;
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(419, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "عنوان";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Accounting.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(23, 478);
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
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Accounting.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(262, 478);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // cmbAccount
            // 
            this.cmbAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAccount.DisplayMember = "Name";
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(15, 229);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(365, 28);
            this.cmbAccount.TabIndex = 6;
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
            this.txtAccount_.Location = new System.Drawing.Point(15, 192);
            this.txtAccount_.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccount_.Name = "txtAccount_";
            this.txtAccount_.Size = new System.Drawing.Size(346, 31);
            this.txtAccount_.TabIndex = 5;
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
            this.label6.Location = new System.Drawing.Point(408, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "تشخیص";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(377, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "مانئه اول دوره";
            // 
            // frmBankMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 520);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankMain";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Load += new System.EventHandler(this.frmBankMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBankMain_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHesabNumber;
        private System.Windows.Forms.TextBox txtCodeShobe;
        private System.Windows.Forms.TextBox txtShobe;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.ComboBox cmbAccount;
        private WindowsSerivces.CurrencyTextBox txtAccount_;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}