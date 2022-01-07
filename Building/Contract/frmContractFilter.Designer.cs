
namespace Building.Contract
{
    partial class frmContractFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContractFilter));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rbtnTamlik = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnSarqofli = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnPishForoush = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnSell = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.rbtnRahn = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.docTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AccTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.ucFilterDate1 = new Print.UcFilterDate();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSearchOwner = new DevComponents.DotNetBar.ButtonX();
            this.txttxtOwnerCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btBindingSource)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupPanel1);
            this.panel1.Controls.Add(this.ucFilterDate1);
            this.panel1.Controls.Add(this.groupPanel5);
            this.panel1.Location = new System.Drawing.Point(5, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 310);
            this.panel1.TabIndex = 3;
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.rbtnSarqofli);
            this.groupPanel5.Controls.Add(this.rbtnTamlik);
            this.groupPanel5.Controls.Add(this.rbtnPishForoush);
            this.groupPanel5.Controls.Add(this.rbtnSell);
            this.groupPanel5.Controls.Add(this.rbtnAll);
            this.groupPanel5.Controls.Add(this.rbtnRahn);
            this.groupPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel5.Location = new System.Drawing.Point(4, 196);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(499, 63);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel5.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 2;
            this.groupPanel5.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel5.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 2;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 2;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 2;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 15;
            this.groupPanel5.Text = "نوع قرارداد";
            // 
            // rbtnTamlik
            // 
            this.rbtnTamlik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnTamlik.AutoSize = true;
            this.rbtnTamlik.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnTamlik.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnTamlik.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnTamlik.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnTamlik.Location = new System.Drawing.Point(1, 6);
            this.rbtnTamlik.Name = "rbtnTamlik";
            this.rbtnTamlik.Size = new System.Drawing.Size(117, 22);
            this.rbtnTamlik.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnTamlik.TabIndex = 55781;
            this.rbtnTamlik.Text = "اجاره به شرط تملیک";
            // 
            // rbtnSarqofli
            // 
            this.rbtnSarqofli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnSarqofli.AutoSize = true;
            this.rbtnSarqofli.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnSarqofli.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnSarqofli.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnSarqofli.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSarqofli.Location = new System.Drawing.Point(121, 6);
            this.rbtnSarqofli.Name = "rbtnSarqofli";
            this.rbtnSarqofli.Size = new System.Drawing.Size(93, 22);
            this.rbtnSarqofli.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnSarqofli.TabIndex = 55785;
            this.rbtnSarqofli.Text = "انتقال سرقفلی";
            // 
            // rbtnPishForoush
            // 
            this.rbtnPishForoush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnPishForoush.AutoSize = true;
            this.rbtnPishForoush.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnPishForoush.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnPishForoush.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnPishForoush.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnPishForoush.Location = new System.Drawing.Point(214, 6);
            this.rbtnPishForoush.Name = "rbtnPishForoush";
            this.rbtnPishForoush.Size = new System.Drawing.Size(81, 22);
            this.rbtnPishForoush.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnPishForoush.TabIndex = 55782;
            this.rbtnPishForoush.Text = "پیش فروش";
            // 
            // rbtnSell
            // 
            this.rbtnSell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnSell.AutoSize = true;
            this.rbtnSell.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnSell.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnSell.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnSell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSell.Location = new System.Drawing.Point(299, 6);
            this.rbtnSell.Name = "rbtnSell";
            this.rbtnSell.Size = new System.Drawing.Size(73, 22);
            this.rbtnSell.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnSell.TabIndex = 55783;
            this.rbtnSell.Text = "مبایعه نامه";
            // 
            // rbtnAll
            // 
            this.rbtnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnAll.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnAll.Location = new System.Drawing.Point(444, 6);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(42, 22);
            this.rbtnAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnAll.TabIndex = 55784;
            this.rbtnAll.Text = "همه";
            // 
            // rbtnRahn
            // 
            this.rbtnRahn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnRahn.AutoSize = true;
            this.rbtnRahn.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.rbtnRahn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbtnRahn.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.rbtnRahn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnRahn.Location = new System.Drawing.Point(373, 6);
            this.rbtnRahn.Name = "rbtnRahn";
            this.rbtnRahn.Size = new System.Drawing.Size(68, 22);
            this.rbtnRahn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbtnRahn.TabIndex = 55785;
            this.rbtnRahn.Text = "اجاره نامه";
            // 
            // docTypeBindingSource
            // 
            this.docTypeBindingSource.DataSource = typeof(EntityCache.Bussines.DocumentTypeBussines);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // AccTypeBindingSource
            // 
            this.AccTypeBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingAccountTypeBussines);
            // 
            // btBindingSource
            // 
            this.btBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingTypeBussines);
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
            this.ucHeader.Location = new System.Drawing.Point(5, 13);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(510, 34);
            this.ucHeader.TabIndex = 55791;
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
            this.btnCancel.Image = global::Building.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(37, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55802;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Building.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(360, 367);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55801;
            this.btnFinish.Text = "اعمال فیلتر (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // ucFilterDate1
            // 
            this.ucFilterDate1.BackColor = System.Drawing.Color.Transparent;
            this.ucFilterDate1.Date1 = new System.DateTime(((long)(0)));
            this.ucFilterDate1.Date2 = new System.DateTime(((long)(0)));
            this.ucFilterDate1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFilterDate1.Location = new System.Drawing.Point(4, 5);
            this.ucFilterDate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFilterDate1.Name = "ucFilterDate1";
            this.ucFilterDate1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFilterDate1.Size = new System.Drawing.Size(499, 183);
            this.ucFilterDate1.TabIndex = 16;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnSearchOwner);
            this.groupPanel1.Controls.Add(this.txttxtOwnerCode);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(4, 265);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(499, 39);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 2;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 2;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 2;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 2;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 17;
            // 
            // btnSearchOwner
            // 
            this.btnSearchOwner.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchOwner.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearchOwner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchOwner.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchOwner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchOwner.Location = new System.Drawing.Point(3, 3);
            this.btnSearchOwner.Name = "btnSearchOwner";
            this.btnSearchOwner.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearchOwner.Size = new System.Drawing.Size(34, 27);
            this.btnSearchOwner.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearchOwner.TabIndex = 11;
            this.btnSearchOwner.Text = "...";
            this.btnSearchOwner.TextColor = System.Drawing.Color.White;
            this.btnSearchOwner.Click += new System.EventHandler(this.btnSearchOwner_Click);
            // 
            // txttxtOwnerCode
            // 
            this.txttxtOwnerCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttxtOwnerCode.Enabled = false;
            this.txttxtOwnerCode.Location = new System.Drawing.Point(43, 3);
            this.txttxtOwnerCode.Name = "txttxtOwnerCode";
            this.txttxtOwnerCode.ReadOnly = true;
            this.txttxtOwnerCode.Size = new System.Drawing.Size(377, 27);
            this.txttxtOwnerCode.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(426, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "طرف حساب";
            // 
            // frmContractFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 407);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(519, 407);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(519, 407);
            this.Name = "frmContractFilter";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuildingFilter_KeyDown);
            this.panel1.ResumeLayout(false);
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btBindingSource)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private WindowsSerivces.UC_Header ucHeader;
        private System.Windows.Forms.BindingSource docTypeBindingSource;
        private System.Windows.Forms.BindingSource AccTypeBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource btBindingSource;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnTamlik;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnPishForoush;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnSell;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnAll;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnRahn;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.CheckBoxX rbtnSarqofli;
        private Print.UcFilterDate ucFilterDate1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSearchOwner;
        private System.Windows.Forms.TextBox txttxtOwnerCode;
        private System.Windows.Forms.Label label1;
    }
}