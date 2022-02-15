
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
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.btnSearchOwner = new DevComponents.DotNetBar.ButtonX();
            this.txttxtOwnerCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.ucSpecialDate = new Print.UcDate();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ucCancel = new WindowsSerivces.UcActionButton();
            this.ucAccept = new WindowsSerivces.UcActionButton();
            this.cmbZoncan = new System.Windows.Forms.ComboBox();
            this.UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.cmbZoncan);
            this.grp.Controls.Add(this.ucSpecialDate);
            this.grp.Controls.Add(this.buttonX1);
            this.grp.Controls.Add(this.btnSearchOwner);
            this.grp.Controls.Add(this.textBox1);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label4);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.txttxtOwnerCode);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.txtDesc);
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
            // txtDesc
            // 
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.Location = new System.Drawing.Point(17, 98);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(553, 152);
            this.txtDesc.TabIndex = 4;
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
            // btnSearchOwner
            // 
            this.btnSearchOwner.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearchOwner.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSearchOwner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSearchOwner.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSearchOwner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchOwner.Location = new System.Drawing.Point(342, 20);
            this.btnSearchOwner.Name = "btnSearchOwner";
            this.btnSearchOwner.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSearchOwner.Size = new System.Drawing.Size(34, 27);
            this.btnSearchOwner.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSearchOwner.TabIndex = 0;
            this.btnSearchOwner.Text = "...";
            this.btnSearchOwner.TextColor = System.Drawing.Color.White;
            // 
            // txttxtOwnerCode
            // 
            this.txttxtOwnerCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txttxtOwnerCode.Enabled = false;
            this.txttxtOwnerCode.Location = new System.Drawing.Point(382, 20);
            this.txttxtOwnerCode.Name = "txttxtOwnerCode";
            this.txttxtOwnerCode.ReadOnly = true;
            this.txttxtOwnerCode.Size = new System.Drawing.Size(188, 27);
            this.txttxtOwnerCode.TabIndex = 16;
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
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(382, 58);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(188, 27);
            this.textBox1.TabIndex = 16;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.buttonX1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX1.Location = new System.Drawing.Point(342, 58);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.buttonX1.Size = new System.Drawing.Size(34, 27);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "...";
            this.buttonX1.TextColor = System.Drawing.Color.White;
            // 
            // ucSpecialDate
            // 
            this.ucSpecialDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSpecialDate.DateSh = "1400/10/17";
            this.ucSpecialDate.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucSpecialDate.Location = new System.Drawing.Point(17, 12);
            this.ucSpecialDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSpecialDate.Name = "ucSpecialDate";
            this.ucSpecialDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucSpecialDate.Size = new System.Drawing.Size(246, 41);
            this.ucSpecialDate.TabIndex = 1;
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
            // 
            // cmbZoncan
            // 
            this.cmbZoncan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZoncan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbZoncan.DataSource = this.UserBindingSource;
            this.cmbZoncan.DisplayMember = "Name";
            this.cmbZoncan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoncan.FormattingEnabled = true;
            this.cmbZoncan.Location = new System.Drawing.Point(17, 58);
            this.cmbZoncan.Name = "cmbZoncan";
            this.cmbZoncan.Size = new System.Drawing.Size(246, 28);
            this.cmbZoncan.TabIndex = 3;
            this.cmbZoncan.ValueMember = "Guid";
            // 
            // UserBindingSource
            // 
            this.UserBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
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
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label1;
        private WindowsSerivces.UC_Header ucHeader;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnSearchOwner;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttxtOwnerCode;
        private System.Windows.Forms.Label label2;
        private Print.UcDate ucSpecialDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private WindowsSerivces.UcActionButton ucCancel;
        private WindowsSerivces.UcActionButton ucAccept;
        private System.Windows.Forms.ComboBox cmbZoncan;
        private System.Windows.Forms.BindingSource UserBindingSource;
    }
}