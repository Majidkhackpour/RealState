namespace User
{
    partial class frmUserLogFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserLogFilter));
            this.groupPanel10 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label76 = new System.Windows.Forms.Label();
            this.txtDate1 = new BPersianCalender.BPersianCalenderTextBox();
            this.txtDate2 = new BPersianCalender.BPersianCalenderTextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel10
            // 
            this.groupPanel10.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel10.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel10.Controls.Add(this.cmbUser);
            this.groupPanel10.Controls.Add(this.label76);
            this.groupPanel10.Controls.Add(this.txtDate1);
            this.groupPanel10.Controls.Add(this.txtDate2);
            this.groupPanel10.Controls.Add(this.label84);
            this.groupPanel10.Controls.Add(this.label86);
            this.groupPanel10.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel10.Location = new System.Drawing.Point(20, 17);
            this.groupPanel10.Name = "groupPanel10";
            this.groupPanel10.Size = new System.Drawing.Size(276, 126);
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
            this.groupPanel10.TabIndex = 0;
            // 
            // cmbUser
            // 
            this.cmbUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUser.DataSource = this.userBindingSource;
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(3, 16);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(211, 28);
            this.cmbUser.TabIndex = 0;
            this.cmbUser.ValueMember = "Guid";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Location = new System.Drawing.Point(233, 19);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(33, 20);
            this.label76.TabIndex = 24;
            this.label76.Text = "کاربر";
            // 
            // txtDate1
            // 
            this.txtDate1.Location = new System.Drawing.Point(3, 50);
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
            this.txtDate2.Location = new System.Drawing.Point(3, 84);
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
            this.label84.Location = new System.Drawing.Point(242, 87);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(24, 20);
            this.label84.TabIndex = 64;
            this.label84.Text = "الی";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(220, 53);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(46, 20);
            this.label86.TabIndex = 60;
            this.label86.Text = "از تاریخ";
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::User.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(26, 154);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(211, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            this.btnCancel.Location = new System.Drawing.Point(26, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(211, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmUserLogFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 240);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.groupPanel10);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(318, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(318, 240);
            this.Name = "frmUserLogFilter";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmUserLogFilter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUserLogFilter_KeyDown);
            this.groupPanel10.ResumeLayout(false);
            this.groupPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel10;
        private BPersianCalender.BPersianCalenderTextBox txtDate1;
        private BPersianCalender.BPersianCalenderTextBox txtDate2;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label76;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.BindingSource userBindingSource;
    }
}