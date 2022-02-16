
namespace Building.BuildingReview
{
    partial class frmBuildingReviewFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuildingReviewFilter));
            this.btnSearchCustomer = new DevComponents.DotNetBar.ButtonX();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.ucFilterDate1 = new Print.UcFilterDate();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucAccept = new WindowsSerivces.UcActionButton();
            this.ucCancel = new WindowsSerivces.UcActionButton();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).BeginInit();
            this.groupPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchCustomer.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearchCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchCustomer.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCustomer.Location = new System.Drawing.Point(13, 3);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearchCustomer.Size = new System.Drawing.Size(34, 27);
            this.btnSearchCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearchCustomer.TabIndex = 0;
            this.btnSearchCustomer.Text = "...";
            this.btnSearchCustomer.TextColor = System.Drawing.Color.White;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(53, 3);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(195, 27);
            this.txtCustomerName.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(273, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "بازدید کننده";
            // 
            // UserBindingSource
            // 
            this.UserBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // cmbUser
            // 
            this.cmbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUser.DataSource = this.UserBindingSource;
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(13, 34);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(236, 28);
            this.cmbUser.TabIndex = 1;
            this.cmbUser.ValueMember = "Guid";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(273, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "مامور بازدید";
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
            this.ucHeader.Location = new System.Drawing.Point(4, 26);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(364, 34);
            this.ucHeader.TabIndex = 55793;
            // 
            // ucFilterDate1
            // 
            this.ucFilterDate1.BackColor = System.Drawing.Color.Transparent;
            this.ucFilterDate1.Date1 = new System.DateTime(((long)(0)));
            this.ucFilterDate1.Date2 = new System.DateTime(((long)(0)));
            this.ucFilterDate1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFilterDate1.Location = new System.Drawing.Point(5, 62);
            this.ucFilterDate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFilterDate1.Name = "ucFilterDate1";
            this.ucFilterDate1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFilterDate1.Size = new System.Drawing.Size(360, 187);
            this.ucFilterDate1.TabIndex = 0;
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.txtCustomerName);
            this.groupPanel5.Controls.Add(this.label3);
            this.groupPanel5.Controls.Add(this.btnSearchCustomer);
            this.groupPanel5.Controls.Add(this.cmbUser);
            this.groupPanel5.Controls.Add(this.label5);
            this.groupPanel5.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel5.Location = new System.Drawing.Point(5, 257);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(360, 73);
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
            this.groupPanel5.TabIndex = 1;
            // 
            // ucAccept
            // 
            this.ucAccept.BackColor = System.Drawing.Color.Transparent;
            this.ucAccept.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucAccept.Location = new System.Drawing.Point(219, 340);
            this.ucAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAccept.Name = "ucAccept";
            this.ucAccept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucAccept.Size = new System.Drawing.Size(125, 31);
            this.ucAccept.TabIndex = 2;
            this.ucAccept.Title = "تایید (F5)";
            this.ucAccept.Type = Services.ButtonType.AcceptButton;
            this.ucAccept.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucAccept_OnClick);
            // 
            // ucCancel
            // 
            this.ucCancel.BackColor = System.Drawing.Color.Transparent;
            this.ucCancel.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucCancel.Location = new System.Drawing.Point(21, 338);
            this.ucCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCancel.Name = "ucCancel";
            this.ucCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucCancel.Size = new System.Drawing.Size(125, 31);
            this.ucCancel.TabIndex = 3;
            this.ucCancel.Title = "انصراف (Esc)";
            this.ucCancel.Type = Services.ButtonType.CancelButton;
            this.ucCancel.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucCancel_OnClick);
            // 
            // frmBuildingReviewFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 379);
            this.Controls.Add(this.ucCancel);
            this.Controls.Add(this.ucAccept);
            this.Controls.Add(this.groupPanel5);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.ucFilterDate1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuildingReviewFilter";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmBuildingReviewFilter_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuildingReviewFilter_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).EndInit();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSearchCustomer;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource UserBindingSource;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label5;
        private WindowsSerivces.UC_Header ucHeader;
        private Print.UcFilterDate ucFilterDate1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private WindowsSerivces.UcActionButton ucAccept;
        private WindowsSerivces.UcActionButton ucCancel;
    }
}