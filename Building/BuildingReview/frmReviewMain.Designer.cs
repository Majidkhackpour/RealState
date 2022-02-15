
namespace Building.BuildingReview
{
    partial class frmReviewMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReviewMain));
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ucDate = new Print.UcDate();
            this.btnSearchCustomer = new DevComponents.DotNetBar.ButtonX();
            this.btnSearchBuilding = new DevComponents.DotNetBar.ButtonX();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBuildingCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.ucCancel = new WindowsSerivces.UcActionButton();
            this.ucAccept = new WindowsSerivces.UcActionButton();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.cmbUser);
            this.grp.Controls.Add(this.ucDate);
            this.grp.Controls.Add(this.btnSearchCustomer);
            this.grp.Controls.Add(this.btnSearchBuilding);
            this.grp.Controls.Add(this.txtCustomerName);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.txtBuildingCode);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.txtReport);
            this.grp.Controls.Add(this.label1);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(3, 62);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(656, 258);
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
            // cmbUser
            // 
            this.cmbUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUser.DataSource = this.UserBindingSource;
            this.cmbUser.DisplayMember = "Name";
            this.cmbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(17, 58);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(246, 28);
            this.cmbUser.TabIndex = 3;
            this.cmbUser.ValueMember = "Guid";
            // 
            // UserBindingSource
            // 
            this.UserBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // ucDate
            // 
            this.ucDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDate.BackColor = System.Drawing.Color.Transparent;
            this.ucDate.DateSh = "1400/10/17";
            this.ucDate.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucDate.Location = new System.Drawing.Point(17, 12);
            this.ucDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDate.Name = "ucDate";
            this.ucDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucDate.Size = new System.Drawing.Size(246, 41);
            this.ucDate.TabIndex = 1;
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchCustomer.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearchCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchCustomer.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCustomer.Location = new System.Drawing.Point(342, 58);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearchCustomer.Size = new System.Drawing.Size(34, 27);
            this.btnSearchCustomer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearchCustomer.TabIndex = 2;
            this.btnSearchCustomer.Text = "...";
            this.btnSearchCustomer.TextColor = System.Drawing.Color.White;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // btnSearchBuilding
            // 
            this.btnSearchBuilding.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchBuilding.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearchBuilding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchBuilding.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchBuilding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchBuilding.Location = new System.Drawing.Point(342, 20);
            this.btnSearchBuilding.Name = "btnSearchBuilding";
            this.btnSearchBuilding.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearchBuilding.Size = new System.Drawing.Size(34, 27);
            this.btnSearchBuilding.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearchBuilding.TabIndex = 0;
            this.btnSearchBuilding.Text = "...";
            this.btnSearchBuilding.TextColor = System.Drawing.Color.White;
            this.btnSearchBuilding.Click += new System.EventHandler(this.btnSearchBuilding_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(382, 58);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(188, 27);
            this.txtCustomerName.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(270, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "مامور بازدید";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(270, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "تاریخ بازدید";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(576, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "بازدید کننده";
            // 
            // txtBuildingCode
            // 
            this.txtBuildingCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuildingCode.Enabled = false;
            this.txtBuildingCode.Location = new System.Drawing.Point(382, 20);
            this.txtBuildingCode.Name = "txtBuildingCode";
            this.txtBuildingCode.ReadOnly = true;
            this.txtBuildingCode.Size = new System.Drawing.Size(188, 27);
            this.txtBuildingCode.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(599, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "کد ملک";
            // 
            // txtReport
            // 
            this.txtReport.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtReport.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtReport.Location = new System.Drawing.Point(17, 98);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Size = new System.Drawing.Size(553, 152);
            this.txtReport.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(599, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "گزارش";
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
            this.ucHeader.Location = new System.Drawing.Point(2, 20);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(667, 34);
            this.ucHeader.TabIndex = 25;
            // 
            // ucCancel
            // 
            this.ucCancel.BackColor = System.Drawing.Color.Transparent;
            this.ucCancel.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucCancel.Location = new System.Drawing.Point(20, 328);
            this.ucCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCancel.Name = "ucCancel";
            this.ucCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucCancel.Size = new System.Drawing.Size(125, 31);
            this.ucCancel.TabIndex = 2;
            this.ucCancel.Title = "انصراف (Esc)";
            this.ucCancel.Type = Services.ButtonType.CancelButton;
            this.ucCancel.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucCancel_OnClick);
            // 
            // ucAccept
            // 
            this.ucAccept.BackColor = System.Drawing.Color.Transparent;
            this.ucAccept.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucAccept.Location = new System.Drawing.Point(448, 328);
            this.ucAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAccept.Name = "ucAccept";
            this.ucAccept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucAccept.Size = new System.Drawing.Size(125, 31);
            this.ucAccept.TabIndex = 1;
            this.ucAccept.Title = "تایید (F5)";
            this.ucAccept.Type = Services.ButtonType.AcceptButton;
            this.ucAccept.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucAccept_OnClick);
            // 
            // frmReviewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 366);
            this.Controls.Add(this.ucCancel);
            this.Controls.Add(this.ucAccept);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.ucHeader);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReviewMain";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmReviewMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReviewMain_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.Label label1;
        private WindowsSerivces.UC_Header ucHeader;
        private DevComponents.DotNetBar.ButtonX btnSearchCustomer;
        private DevComponents.DotNetBar.ButtonX btnSearchBuilding;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBuildingCode;
        private System.Windows.Forms.Label label2;
        private Print.UcDate ucDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private WindowsSerivces.UcActionButton ucCancel;
        private WindowsSerivces.UcActionButton ucAccept;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.BindingSource UserBindingSource;
    }
}