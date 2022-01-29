
namespace Building.UserControls
{
    partial class UcBuildingType
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.BuildingAccountTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBView = new System.Windows.Forms.ComboBox();
            this.BuildingTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label43 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWindow = new System.Windows.Forms.ComboBox();
            this.WindowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingAccountTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cmbWindow);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cmbAccountType);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.cmbBView);
            this.groupPanel1.Controls.Add(this.label43);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(636, 47);
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
            this.groupPanel1.TabIndex = 9;
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAccountType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAccountType.DataSource = this.BuildingAccountTypeBindingSource;
            this.cmbAccountType.DisplayMember = "Name";
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(214, 6);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(145, 28);
            this.cmbAccountType.TabIndex = 65;
            this.cmbAccountType.ValueMember = "Guid";
            // 
            // BuildingAccountTypeBindingSource
            // 
            this.BuildingAccountTypeBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingAccountTypeBussines);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(365, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "کاربری:";
            // 
            // cmbBView
            // 
            this.cmbBView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBView.DataSource = this.BuildingTypeBindingSource;
            this.cmbBView.DisplayMember = "Name";
            this.cmbBView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBView.FormattingEnabled = true;
            this.cmbBView.Location = new System.Drawing.Point(423, 6);
            this.cmbBView.Name = "cmbBView";
            this.cmbBView.Size = new System.Drawing.Size(145, 28);
            this.cmbBView.TabIndex = 65;
            this.cmbBView.ValueMember = "Guid";
            // 
            // BuildingTypeBindingSource
            // 
            this.BuildingTypeBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingTypeBussines);
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Location = new System.Drawing.Point(574, 9);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(53, 20);
            this.label43.TabIndex = 66;
            this.label43.Text = "نوع ملک:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "پنجره:";
            // 
            // cmbWindow
            // 
            this.cmbWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWindow.DataSource = this.WindowBindingSource;
            this.cmbWindow.DisplayMember = "Name";
            this.cmbWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWindow.FormattingEnabled = true;
            this.cmbWindow.Location = new System.Drawing.Point(9, 6);
            this.cmbWindow.Name = "cmbWindow";
            this.cmbWindow.Size = new System.Drawing.Size(145, 28);
            this.cmbWindow.TabIndex = 65;
            this.cmbWindow.ValueMember = "Guid";
            // 
            // WindowBindingSource
            // 
            this.WindowBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingWindowBussines);
            // 
            // UcBuildingType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(636, 47);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingAccountTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ComboBox cmbBView;
        private System.Windows.Forms.BindingSource BuildingTypeBindingSource;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.BindingSource BuildingAccountTypeBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWindow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource WindowBindingSource;
    }
}
