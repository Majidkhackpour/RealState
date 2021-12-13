
namespace Building.UserControls.Contract.Public
{
    partial class UcContractVisitor
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
            this.bazaryabBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupPanel11 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.txtBazaryabPrice = new WindowsSerivces.CurrencyTextBox();
            this.cmbBazaryab = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bazaryabBindingSource)).BeginInit();
            this.groupPanel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // bazaryabBindingSource
            // 
            this.bazaryabBindingSource.DataSource = typeof(EntityCache.Bussines.AdvisorBussines);
            // 
            // groupPanel11
            // 
            this.groupPanel11.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel11.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel11.Controls.Add(this.txtPercent);
            this.groupPanel11.Controls.Add(this.txtBazaryabPrice);
            this.groupPanel11.Controls.Add(this.cmbBazaryab);
            this.groupPanel11.Controls.Add(this.label18);
            this.groupPanel11.Controls.Add(this.label42);
            this.groupPanel11.Controls.Add(this.label2);
            this.groupPanel11.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel11.Location = new System.Drawing.Point(0, 0);
            this.groupPanel11.Name = "groupPanel11";
            this.groupPanel11.Size = new System.Drawing.Size(363, 106);
            // 
            // 
            // 
            this.groupPanel11.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel11.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel11.Style.BackColorGradientAngle = 90;
            this.groupPanel11.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderBottomWidth = 2;
            this.groupPanel11.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel11.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel11.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderLeftWidth = 2;
            this.groupPanel11.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderRightWidth = 2;
            this.groupPanel11.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel11.Style.BorderTopWidth = 2;
            this.groupPanel11.Style.CornerDiameter = 4;
            this.groupPanel11.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel11.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel11.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel11.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel11.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel11.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel11.TabIndex = 5;
            this.groupPanel11.Text = "پورسانت مشاور";
            // 
            // txtPercent
            // 
            this.txtPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercent.Location = new System.Drawing.Point(216, 44);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(63, 27);
            this.txtPercent.TabIndex = 62;
            this.txtPercent.TextChanged += new System.EventHandler(this.txtPercent_TextChanged);
            // 
            // txtBazaryabPrice
            // 
            this.txtBazaryabPrice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtBazaryabPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBazaryabPrice.BackColor = System.Drawing.Color.White;
            this.txtBazaryabPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBazaryabPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBazaryabPrice.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtBazaryabPrice.Location = new System.Drawing.Point(3, 43);
            this.txtBazaryabPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBazaryabPrice.Name = "txtBazaryabPrice";
            this.txtBazaryabPrice.Size = new System.Drawing.Size(198, 31);
            this.txtBazaryabPrice.TabIndex = 61;
            this.txtBazaryabPrice.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBazaryabPrice.OnTextChanged += new System.Action(this.txtBazaryabPrice_OnTextChanged);
            // 
            // cmbBazaryab
            // 
            this.cmbBazaryab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBazaryab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBazaryab.DataSource = this.bazaryabBindingSource;
            this.cmbBazaryab.DisplayMember = "Name";
            this.cmbBazaryab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBazaryab.FormattingEnabled = true;
            this.cmbBazaryab.Location = new System.Drawing.Point(3, 10);
            this.cmbBazaryab.Name = "cmbBazaryab";
            this.cmbBazaryab.Size = new System.Drawing.Size(276, 28);
            this.cmbBazaryab.TabIndex = 23;
            this.cmbBazaryab.ValueMember = "Guid";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(278, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 20);
            this.label18.TabIndex = 24;
            this.label18.Text = "انتخاب مشاور:";
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.Location = new System.Drawing.Point(279, 47);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(78, 20);
            this.label42.TabIndex = 59;
            this.label42.Text = "مبلغ بازاریابی:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(200, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.TabIndex = 63;
            this.label2.Text = "%";
            // 
            // UcContractVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel11);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcContractVisitor";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(363, 106);
            ((System.ComponentModel.ISupportInitialize)(this.bazaryabBindingSource)).EndInit();
            this.groupPanel11.ResumeLayout(false);
            this.groupPanel11.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bazaryabBindingSource;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel11;
        private WindowsSerivces.CurrencyTextBox txtBazaryabPrice;
        private System.Windows.Forms.ComboBox cmbBazaryab;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label label2;
    }
}
