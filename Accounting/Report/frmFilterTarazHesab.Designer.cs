
namespace Accounting.Report
{
    partial class frmFilterTarazHesab
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterTarazHesab));
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.groupPanel10 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnBetween = new System.Windows.Forms.RadioButton();
            this.rbtnToday = new System.Windows.Forms.RadioButton();
            this.txtDate1 = new BPersianCalender.BPersianCalenderTextBox();
            this.txtDate2 = new BPersianCalender.BPersianCalenderTextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFPrice1 = new System.Windows.Forms.Label();
            this.txtCode1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode2 = new System.Windows.Forms.NumericUpDown();
            this.btnSearchTafsil1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchTafsil2 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode2)).BeginInit();
            this.SuspendLayout();
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
            this.ucHeader.Location = new System.Drawing.Point(0, 22);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(668, 34);
            this.ucHeader.TabIndex = 55760;
            // 
            // groupPanel10
            // 
            this.groupPanel10.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel10.Controls.Add(this.btnSearchTafsil2);
            this.groupPanel10.Controls.Add(this.btnSearchTafsil1);
            this.groupPanel10.Controls.Add(this.lblFPrice1);
            this.groupPanel10.Controls.Add(this.txtCode1);
            this.groupPanel10.Controls.Add(this.label3);
            this.groupPanel10.Controls.Add(this.txtCode2);
            this.groupPanel10.Controls.Add(this.line2);
            this.groupPanel10.Controls.Add(this.rbtnAll);
            this.groupPanel10.Controls.Add(this.rbtnBetween);
            this.groupPanel10.Controls.Add(this.rbtnToday);
            this.groupPanel10.Controls.Add(this.txtDate1);
            this.groupPanel10.Controls.Add(this.txtDate2);
            this.groupPanel10.Controls.Add(this.label84);
            this.groupPanel10.Controls.Add(this.label1);
            this.groupPanel10.Controls.Add(this.label86);
            this.groupPanel10.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel10.Location = new System.Drawing.Point(2, 56);
            this.groupPanel10.Name = "groupPanel10";
            this.groupPanel10.Size = new System.Drawing.Size(659, 169);
            // 
            // 
            // 
            this.groupPanel10.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel10.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel10.Style.BackColorGradientAngle = 90;
            this.groupPanel10.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderBottomWidth = 2;
            this.groupPanel10.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel10.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel10.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderLeftWidth = 2;
            this.groupPanel10.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderRightWidth = 2;
            this.groupPanel10.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel10.Style.BorderTopWidth = 2;
            this.groupPanel10.Style.CornerDiameter = 4;
            this.groupPanel10.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel10.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel10.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel10.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel10.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel10.TabIndex = 55759;
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAll.Location = new System.Drawing.Point(550, 86);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(95, 24);
            this.rbtnAll.TabIndex = 6;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "کلیه گردش ها";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // rbtnBetween
            // 
            this.rbtnBetween.AutoSize = true;
            this.rbtnBetween.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBetween.Location = new System.Drawing.Point(573, 44);
            this.rbtnBetween.Name = "rbtnBetween";
            this.rbtnBetween.Size = new System.Drawing.Size(72, 24);
            this.rbtnBetween.TabIndex = 6;
            this.rbtnBetween.TabStop = true;
            this.rbtnBetween.Text = "بین تاریخ";
            this.rbtnBetween.UseVisualStyleBackColor = true;
            this.rbtnBetween.CheckedChanged += new System.EventHandler(this.rbtnBetween_CheckedChanged);
            // 
            // rbtnToday
            // 
            this.rbtnToday.AutoSize = true;
            this.rbtnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnToday.Location = new System.Drawing.Point(557, 4);
            this.rbtnToday.Name = "rbtnToday";
            this.rbtnToday.Size = new System.Drawing.Size(88, 24);
            this.rbtnToday.TabIndex = 6;
            this.rbtnToday.TabStop = true;
            this.rbtnToday.Text = "کارکرد امروز";
            this.rbtnToday.UseVisualStyleBackColor = true;
            this.rbtnToday.CheckedChanged += new System.EventHandler(this.rbtnToday_CheckedChanged);
            // 
            // txtDate1
            // 
            this.txtDate1.Location = new System.Drawing.Point(272, 41);
            this.txtDate1.Miladi = new System.DateTime(2020, 10, 23, 15, 57, 17, 0);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.NowDateSelected = false;
            this.txtDate1.ReadOnly = true;
            this.txtDate1.SelectedDate = null;
            this.txtDate1.Shamsi = null;
            this.txtDate1.Size = new System.Drawing.Size(211, 27);
            this.txtDate1.TabIndex = 1;
            // 
            // txtDate2
            // 
            this.txtDate2.Location = new System.Drawing.Point(3, 41);
            this.txtDate2.Miladi = new System.DateTime(2020, 10, 1, 0, 0, 0, 0);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.NowDateSelected = false;
            this.txtDate2.ReadOnly = true;
            this.txtDate2.SelectedDate = null;
            this.txtDate2.Shamsi = null;
            this.txtDate2.Size = new System.Drawing.Size(211, 27);
            this.txtDate2.TabIndex = 2;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Location = new System.Drawing.Point(242, 44);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(24, 20);
            this.label84.TabIndex = 64;
            this.label84.Text = "الی";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(489, 44);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(46, 20);
            this.label86.TabIndex = 60;
            this.label86.Text = "از تاریخ";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Accounting.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(8, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(211, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55762;
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
            this.btnFinish.Location = new System.Drawing.Point(277, 231);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(211, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55761;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // line2
            // 
            this.line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line2.ForeColor = System.Drawing.Color.Teal;
            this.line2.Location = new System.Drawing.Point(10, 116);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(635, 10);
            this.line2.TabIndex = 65;
            this.line2.Text = "line1";
            this.line2.Thickness = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(559, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "انتخاب حساب";
            // 
            // lblFPrice1
            // 
            this.lblFPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFPrice1.AutoSize = true;
            this.lblFPrice1.BackColor = System.Drawing.Color.Transparent;
            this.lblFPrice1.Location = new System.Drawing.Point(499, 131);
            this.lblFPrice1.Name = "lblFPrice1";
            this.lblFPrice1.Size = new System.Drawing.Size(34, 20);
            this.lblFPrice1.TabIndex = 55779;
            this.lblFPrice1.Text = "از کد";
            // 
            // txtCode1
            // 
            this.txtCode1.Location = new System.Drawing.Point(306, 129);
            this.txtCode1.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtCode1.Name = "txtCode1";
            this.txtCode1.Size = new System.Drawing.Size(177, 27);
            this.txtCode1.TabIndex = 55774;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(242, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 20);
            this.label3.TabIndex = 55778;
            this.label3.Text = "تا";
            // 
            // txtCode2
            // 
            this.txtCode2.Location = new System.Drawing.Point(37, 129);
            this.txtCode2.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.txtCode2.Name = "txtCode2";
            this.txtCode2.Size = new System.Drawing.Size(177, 27);
            this.txtCode2.TabIndex = 55776;
            // 
            // btnSearchTafsil1
            // 
            this.btnSearchTafsil1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchTafsil1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSearchTafsil1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchTafsil1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchTafsil1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchTafsil1.Location = new System.Drawing.Point(272, 129);
            this.btnSearchTafsil1.Name = "btnSearchTafsil1";
            this.btnSearchTafsil1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearchTafsil1.Size = new System.Drawing.Size(28, 27);
            this.btnSearchTafsil1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearchTafsil1.TabIndex = 55763;
            this.btnSearchTafsil1.Text = "...";
            this.btnSearchTafsil1.TextColor = System.Drawing.Color.Black;
            this.btnSearchTafsil1.Click += new System.EventHandler(this.btnSearchTafsil1_Click);
            // 
            // btnSearchTafsil2
            // 
            this.btnSearchTafsil2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchTafsil2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSearchTafsil2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchTafsil2.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchTafsil2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchTafsil2.Location = new System.Drawing.Point(3, 129);
            this.btnSearchTafsil2.Name = "btnSearchTafsil2";
            this.btnSearchTafsil2.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearchTafsil2.Size = new System.Drawing.Size(28, 27);
            this.btnSearchTafsil2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearchTafsil2.TabIndex = 55780;
            this.btnSearchTafsil2.Text = "...";
            this.btnSearchTafsil2.TextColor = System.Drawing.Color.Black;
            this.btnSearchTafsil2.Click += new System.EventHandler(this.btnSearchTafsil2_Click);
            // 
            // frmFilterTarazHesab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.groupPanel10);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(669, 270);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(669, 270);
            this.Name = "frmFilterTarazHesab";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFilterTarazHesab_KeyDown);
            this.groupPanel10.ResumeLayout(false);
            this.groupPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsSerivces.UC_Header ucHeader;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel10;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.RadioButton rbtnBetween;
        private System.Windows.Forms.RadioButton rbtnToday;
        private BPersianCalender.BPersianCalenderTextBox txtDate1;
        private BPersianCalender.BPersianCalenderTextBox txtDate2;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label86;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.Controls.Line line2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFPrice1;
        private System.Windows.Forms.NumericUpDown txtCode1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtCode2;
        private DevComponents.DotNetBar.ButtonX btnSearchTafsil2;
        private DevComponents.DotNetBar.ButtonX btnSearchTafsil1;
    }
}