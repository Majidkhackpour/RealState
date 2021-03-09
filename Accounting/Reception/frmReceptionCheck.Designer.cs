
namespace Accounting.Reception
{
    partial class frmReceptionCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceptionCheck));
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.cmbSandouq = new System.Windows.Forms.ComboBox();
            this.SandouqBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtDate = new BPersianCalender.BPersianCalenderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.txtPoshtNomre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCheckNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new WindowsSerivces.CurrencyTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SandouqBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.cmbSandouq);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.txtDate);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txtBankName);
            this.grp.Controls.Add(this.txtPoshtNomre);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.txtCheckNo);
            this.grp.Controls.Add(this.label7);
            this.grp.Controls.Add(this.txtPrice);
            this.grp.Controls.Add(this.label16);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.txtDesc);
            this.grp.Controls.Add(this.label3);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(7, 24);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(389, 355);
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
            // cmbSandouq
            // 
            this.cmbSandouq.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSandouq.DataSource = this.SandouqBindingSource;
            this.cmbSandouq.DisplayMember = "Name";
            this.cmbSandouq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSandouq.FormattingEnabled = true;
            this.cmbSandouq.Location = new System.Drawing.Point(16, 179);
            this.cmbSandouq.Name = "cmbSandouq";
            this.cmbSandouq.Size = new System.Drawing.Size(283, 28);
            this.cmbSandouq.TabIndex = 5;
            this.cmbSandouq.ValueMember = "Guid";
            // 
            // SandouqBindingSource
            // 
            this.SandouqBindingSource.DataSource = typeof(EntityCache.Bussines.TafsilBussines);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(305, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "صندوق مقصد";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(16, 47);
            this.txtDate.Miladi = new System.DateTime(2020, 10, 25, 17, 11, 28, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.NowDateSelected = false;
            this.txtDate.ReadOnly = true;
            this.txtDate.SelectedDate = null;
            this.txtDate.Shamsi = null;
            this.txtDate.Size = new System.Drawing.Size(283, 27);
            this.txtDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(327, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "سررسید";
            // 
            // txtBankName
            // 
            this.txtBankName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBankName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBankName.Location = new System.Drawing.Point(16, 80);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(283, 27);
            this.txtBankName.TabIndex = 2;
            this.txtBankName.Enter += new System.EventHandler(this.txtBankName_Enter);
            this.txtBankName.Leave += new System.EventHandler(this.txtBankName_Leave);
            // 
            // txtPoshtNomre
            // 
            this.txtPoshtNomre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPoshtNomre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPoshtNomre.Location = new System.Drawing.Point(16, 146);
            this.txtPoshtNomre.Name = "txtPoshtNomre";
            this.txtPoshtNomre.Size = new System.Drawing.Size(283, 27);
            this.txtPoshtNomre.TabIndex = 4;
            this.txtPoshtNomre.Enter += new System.EventHandler(this.txtPoshtNomre_Enter);
            this.txtPoshtNomre.Leave += new System.EventHandler(this.txtPoshtNomre_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(319, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "پشت نمره";
            // 
            // txtCheckNo
            // 
            this.txtCheckNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCheckNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCheckNo.Location = new System.Drawing.Point(16, 113);
            this.txtCheckNo.Name = "txtCheckNo";
            this.txtCheckNo.Size = new System.Drawing.Size(283, 27);
            this.txtCheckNo.TabIndex = 3;
            this.txtCheckNo.Enter += new System.EventHandler(this.txtCheckNo_Enter);
            this.txtCheckNo.Leave += new System.EventHandler(this.txtCheckNo_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(319, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "شماره چک";
            // 
            // txtPrice
            // 
            this.txtPrice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrice.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrice.Location = new System.Drawing.Point(16, 13);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(283, 31);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(349, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 20);
            this.label16.TabIndex = 22;
            this.label16.Text = "مبلغ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(330, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "نام بانک";
            // 
            // txtDesc
            // 
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.Location = new System.Drawing.Point(16, 215);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(283, 130);
            this.txtDesc.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(325, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "توضیحات";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Accounting.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(12, 386);
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
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Accounting.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(246, 386);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // frmReceptionCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 429);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(401, 429);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(401, 429);
            this.Name = "frmReceptionCheck";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Load += new System.EventHandler(this.frmReceptionCheck_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReceptionCheck_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SandouqBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.TextBox txtCheckNo;
        private System.Windows.Forms.Label label7;
        private WindowsSerivces.CurrencyTextBox txtPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private BPersianCalender.BPersianCalenderTextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.TextBox txtPoshtNomre;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.ComboBox cmbSandouq;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource SandouqBindingSource;
    }
}