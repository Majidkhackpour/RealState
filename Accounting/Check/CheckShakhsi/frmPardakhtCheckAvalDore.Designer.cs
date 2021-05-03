
namespace Accounting.Check.CheckShakhsi
{
    partial class frmPardakhtCheckAvalDore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPardakhtCheckAvalDore));
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.btnTafsilSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtTafsilName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDate = new BPersianCalender.BPersianCalenderTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new WindowsSerivces.CurrencyTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbCheckBook = new System.Windows.Forms.ComboBox();
            this.CheckBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCheckPage = new System.Windows.Forms.ComboBox();
            this.CheckPageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.btnTafsilSearch);
            this.grp.Controls.Add(this.txtTafsilName);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.txtDate);
            this.grp.Controls.Add(this.label7);
            this.grp.Controls.Add(this.txtPrice);
            this.grp.Controls.Add(this.label16);
            this.grp.Controls.Add(this.cmbCheckBook);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.cmbCheckPage);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txtDesc);
            this.grp.Controls.Add(this.label3);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(7, 68);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(389, 329);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grp.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 4;
            // 
            // btnTafsilSearch
            // 
            this.btnTafsilSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTafsilSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTafsilSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTafsilSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTafsilSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTafsilSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTafsilSearch.Location = new System.Drawing.Point(15, 81);
            this.btnTafsilSearch.Name = "btnTafsilSearch";
            this.btnTafsilSearch.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnTafsilSearch.Size = new System.Drawing.Size(30, 27);
            this.btnTafsilSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnTafsilSearch.TabIndex = 31;
            this.btnTafsilSearch.Text = "...";
            this.btnTafsilSearch.TextColor = System.Drawing.Color.White;
            this.btnTafsilSearch.Click += new System.EventHandler(this.btnTafsilSearch_Click);
            // 
            // txtTafsilName
            // 
            this.txtTafsilName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTafsilName.Enabled = false;
            this.txtTafsilName.Location = new System.Drawing.Point(51, 81);
            this.txtTafsilName.Name = "txtTafsilName";
            this.txtTafsilName.ReadOnly = true;
            this.txtTafsilName.Size = new System.Drawing.Size(247, 27);
            this.txtTafsilName.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(336, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "گیرنده";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(15, 114);
            this.txtDate.Miladi = new System.DateTime(2020, 10, 25, 17, 11, 28, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.NowDateSelected = false;
            this.txtDate.ReadOnly = true;
            this.txtDate.SelectedDate = null;
            this.txtDate.Shamsi = null;
            this.txtDate.Size = new System.Drawing.Size(283, 27);
            this.txtDate.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(326, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "سررسید";
            // 
            // txtPrice
            // 
            this.txtPrice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrice.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrice.Location = new System.Drawing.Point(15, 148);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(283, 31);
            this.txtPrice.TabIndex = 3;
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
            this.label16.Location = new System.Drawing.Point(348, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 20);
            this.label16.TabIndex = 22;
            this.label16.Text = "مبلغ";
            // 
            // cmbCheckBook
            // 
            this.cmbCheckBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCheckBook.DataSource = this.CheckBookBindingSource;
            this.cmbCheckBook.DisplayMember = "Name";
            this.cmbCheckBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckBook.FormattingEnabled = true;
            this.cmbCheckBook.Location = new System.Drawing.Point(15, 12);
            this.cmbCheckBook.Name = "cmbCheckBook";
            this.cmbCheckBook.Size = new System.Drawing.Size(283, 28);
            this.cmbCheckBook.TabIndex = 1;
            this.cmbCheckBook.ValueMember = "Guid";
            this.cmbCheckBook.SelectedIndexChanged += new System.EventHandler(this.cmbCheckBook_SelectedIndexChanged);
            // 
            // CheckBookBindingSource
            // 
            this.CheckBookBindingSource.DataSource = typeof(EntityCache.Bussines.DasteCheckBussines);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(316, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "دسته چک";
            // 
            // cmbCheckPage
            // 
            this.cmbCheckPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbCheckPage.DataSource = this.CheckPageBindingSource;
            this.cmbCheckPage.DisplayMember = "Number";
            this.cmbCheckPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckPage.FormattingEnabled = true;
            this.cmbCheckPage.Location = new System.Drawing.Point(15, 47);
            this.cmbCheckPage.Name = "cmbCheckPage";
            this.cmbCheckPage.Size = new System.Drawing.Size(283, 28);
            this.cmbCheckPage.TabIndex = 1;
            this.cmbCheckPage.ValueMember = "Guid";
            // 
            // CheckPageBindingSource
            // 
            this.CheckPageBindingSource.DataSource = typeof(EntityCache.Bussines.CheckPageBussines);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(316, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "سریال چک";
            // 
            // txtDesc
            // 
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.Location = new System.Drawing.Point(15, 185);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(283, 130);
            this.txtDesc.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(324, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "توضیحات";
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
            this.btnCancel.Image = global::Accounting.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(22, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 6;
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
            this.btnFinish.Image = global::Accounting.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(250, 406);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            this.ucHeader.Location = new System.Drawing.Point(-4, 26);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(413, 34);
            this.ucHeader.TabIndex = 10;
            // 
            // frmPardakhtCheckAvalDore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 449);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(405, 449);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(405, 449);
            this.Name = "frmPardakhtCheckAvalDore";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmPardakhtCheckAvalDore_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPardakhtCheckAvalDore_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx grp;
        private BPersianCalender.BPersianCalenderTextBox txtDate;
        private System.Windows.Forms.Label label7;
        private WindowsSerivces.CurrencyTextBox txtPrice;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbCheckBook;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCheckPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnTafsilSearch;
        private System.Windows.Forms.TextBox txtTafsilName;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.BindingSource CheckBookBindingSource;
        private System.Windows.Forms.BindingSource CheckPageBindingSource;
        private WindowsSerivces.UC_Header ucHeader;
    }
}