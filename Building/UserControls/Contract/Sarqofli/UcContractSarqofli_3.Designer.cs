
namespace Building.UserControls.Contract.Sarqofli
{
    partial class UcContractSarqofli_3
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
            this.txtNaqd = new WindowsSerivces.CurrencyTextBox();
            this.txtPrice = new WindowsSerivces.CurrencyTextBox();
            this.lblToman = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucContractCheck1 = new Building.UserControls.Contract.Public.UcContractCheck();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPanel.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNaqd
            // 
            this.txtNaqd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtNaqd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNaqd.BackColor = System.Drawing.Color.White;
            this.txtNaqd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtNaqd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtNaqd.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNaqd.Location = new System.Drawing.Point(489, 39);
            this.txtNaqd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNaqd.Name = "txtNaqd";
            this.txtNaqd.Size = new System.Drawing.Size(285, 31);
            this.txtNaqd.TabIndex = 18;
            this.txtNaqd.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPrice
            // 
            this.txtPrice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrice.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrice.Location = new System.Drawing.Point(489, 5);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(162, 31);
            this.txtPrice.TabIndex = 18;
            this.txtPrice.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrice.OnTextChanged += new System.Action(this.txtPrice_OnTextChanged);
            // 
            // lblToman
            // 
            this.lblToman.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToman.BackColor = System.Drawing.Color.Transparent;
            this.lblToman.Location = new System.Drawing.Point(178, 9);
            this.lblToman.Name = "lblToman";
            this.lblToman.Size = new System.Drawing.Size(236, 20);
            this.lblToman.TabIndex = 10;
            this.lblToman.Text = "ریال به حروف";
            this.lblToman.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(417, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "ریال، معادل";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(290, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "ریال به صورت نقد و الباقی به صورت:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(-85, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(264, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "تومان تعیین گردید که به شرح زیر پرداخت خواهد شد";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(784, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "3-2 مبلغ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(651, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "3-1 قیمت مورد معامله به طور مقطوع";
            // 
            // grpPanel
            // 
            this.grpPanel.BackColor = System.Drawing.Color.Transparent;
            this.grpPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpPanel.Controls.Add(this.groupPanel1);
            this.grpPanel.Controls.Add(this.txtNaqd);
            this.grpPanel.Controls.Add(this.txtPrice);
            this.grpPanel.Controls.Add(this.lblToman);
            this.grpPanel.Controls.Add(this.label3);
            this.grpPanel.Controls.Add(this.label1);
            this.grpPanel.Controls.Add(this.label6);
            this.grpPanel.Controls.Add(this.label7);
            this.grpPanel.Controls.Add(this.label4);
            this.grpPanel.Controls.Add(this.label2);
            this.grpPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Location = new System.Drawing.Point(0, 0);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpPanel.Size = new System.Drawing.Size(848, 245);
            // 
            // 
            // 
            this.grpPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.grpPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.grpPanel.Style.BackColorGradientAngle = 90;
            this.grpPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderBottomWidth = 2;
            this.grpPanel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.grpPanel.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.grpPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderLeftWidth = 2;
            this.grpPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderRightWidth = 2;
            this.grpPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderTopWidth = 2;
            this.grpPanel.Style.CornerDiameter = 4;
            this.grpPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpPanel.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grpPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpPanel.TabIndex = 2;
            this.grpPanel.Text = "ماده 3 - قیمت معامله";
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ucContractCheck1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(422, 73);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(413, 141);
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
            this.groupPanel1.TabIndex = 55750;
            this.groupPanel1.Text = "چک";
            // 
            // ucContractCheck1
            // 
            this.ucContractCheck1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractCheck1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractCheck1.BankName = "";
            this.ucContractCheck1.CheckNo = "";
            this.ucContractCheck1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractCheck1.Location = new System.Drawing.Point(13, 3);
            this.ucContractCheck1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractCheck1.Name = "ucContractCheck1";
            this.ucContractCheck1.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractCheck1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractCheck1.Sarresid = null;
            this.ucContractCheck1.Shobe = "";
            this.ucContractCheck1.Size = new System.Drawing.Size(390, 105);
            this.ucContractCheck1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(41, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "باقی مانده مبلغ در زمان تنظیم سند در دفتر اسناد رسمی پرداخت خواهد شد.";
            // 
            // UcContractSarqofli_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPanel);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcContractSarqofli_3";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(848, 245);
            this.grpPanel.ResumeLayout(false);
            this.grpPanel.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private WindowsSerivces.CurrencyTextBox txtNaqd;
        private WindowsSerivces.CurrencyTextBox txtPrice;
        private System.Windows.Forms.Label lblToman;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.GroupPanel grpPanel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private Public.UcContractCheck ucContractCheck1;
        private System.Windows.Forms.Label label1;
    }
}
