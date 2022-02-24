
namespace Building.Tools
{
    partial class frmCommitionCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommitionCalculator));
            this.ucAccept = new WindowsSerivces.UcActionButton();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.rbtnSell = new System.Windows.Forms.RadioButton();
            this.rbtnRahn = new System.Windows.Forms.RadioButton();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtPrice2 = new WindowsSerivces.CurrencyTextBox();
            this.lblPrice2 = new System.Windows.Forms.Label();
            this.txtPrice1 = new WindowsSerivces.CurrencyTextBox();
            this.lblPrice1 = new System.Windows.Forms.Label();
            this.ucCommition1 = new Building.UserControls.Contract.Public.UcCommition();
            this.grp.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucAccept
            // 
            this.ucAccept.BackColor = System.Drawing.Color.Transparent;
            this.ucAccept.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucAccept.Location = new System.Drawing.Point(36, 535);
            this.ucAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAccept.Name = "ucAccept";
            this.ucAccept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucAccept.Size = new System.Drawing.Size(346, 31);
            this.ucAccept.TabIndex = 3;
            this.ucAccept.Title = "محاسبه کمیسیون (F5)";
            this.ucAccept.Type = Services.ButtonType.None;
            this.ucAccept.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucAccept_OnClick);
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
            this.ucHeader.Location = new System.Drawing.Point(-3, 23);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(431, 34);
            this.ucHeader.TabIndex = 34;
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.rbtnSell);
            this.grp.Controls.Add(this.rbtnRahn);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(4, 63);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(419, 44);
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
            // rbtnSell
            // 
            this.rbtnSell.AutoSize = true;
            this.rbtnSell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnSell.Location = new System.Drawing.Point(139, 9);
            this.rbtnSell.Name = "rbtnSell";
            this.rbtnSell.Size = new System.Drawing.Size(59, 24);
            this.rbtnSell.TabIndex = 1;
            this.rbtnSell.TabStop = true;
            this.rbtnSell.Text = "فروش";
            this.rbtnSell.UseVisualStyleBackColor = true;
            this.rbtnSell.CheckedChanged += new System.EventHandler(this.rbtnSell_CheckedChanged);
            // 
            // rbtnRahn
            // 
            this.rbtnRahn.AutoSize = true;
            this.rbtnRahn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnRahn.Location = new System.Drawing.Point(316, 9);
            this.rbtnRahn.Name = "rbtnRahn";
            this.rbtnRahn.Size = new System.Drawing.Size(86, 24);
            this.rbtnRahn.TabIndex = 0;
            this.rbtnRahn.TabStop = true;
            this.rbtnRahn.Text = "رهن و اجاره";
            this.rbtnRahn.UseVisualStyleBackColor = true;
            this.rbtnRahn.CheckedChanged += new System.EventHandler(this.rbtnRahn_CheckedChanged);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.txtPrice2);
            this.panelEx1.Controls.Add(this.lblPrice2);
            this.panelEx1.Controls.Add(this.txtPrice1);
            this.panelEx1.Controls.Add(this.lblPrice1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Location = new System.Drawing.Point(4, 113);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(419, 81);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx1.Style.BorderWidth = 2;
            this.panelEx1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // txtPrice2
            // 
            this.txtPrice2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtPrice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice2.BackColor = System.Drawing.Color.White;
            this.txtPrice2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPrice2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrice2.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrice2.Location = new System.Drawing.Point(17, 43);
            this.txtPrice2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(301, 31);
            this.txtPrice2.TabIndex = 1;
            this.txtPrice2.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblPrice2
            // 
            this.lblPrice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice2.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice2.Location = new System.Drawing.Point(325, 47);
            this.lblPrice2.Name = "lblPrice2";
            this.lblPrice2.Size = new System.Drawing.Size(81, 20);
            this.lblPrice2.TabIndex = 61;
            this.lblPrice2.Text = "مبلغ اجاره:";
            // 
            // txtPrice1
            // 
            this.txtPrice1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice1.BackColor = System.Drawing.Color.White;
            this.txtPrice1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPrice1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtPrice1.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPrice1.Location = new System.Drawing.Point(17, 8);
            this.txtPrice1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(301, 31);
            this.txtPrice1.TabIndex = 0;
            this.txtPrice1.TextDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblPrice1
            // 
            this.lblPrice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice1.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice1.Location = new System.Drawing.Point(325, 12);
            this.lblPrice1.Name = "lblPrice1";
            this.lblPrice1.Size = new System.Drawing.Size(81, 20);
            this.lblPrice1.TabIndex = 61;
            this.lblPrice1.Text = "مبلغ رهن:";
            // 
            // ucCommition1
            // 
            this.ucCommition1.Avarez = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucCommition1.BackColor = System.Drawing.Color.Transparent;
            this.ucCommition1.Discount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucCommition1.EnableBabat = true;
            this.ucCommition1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucCommition1.Location = new System.Drawing.Point(4, 197);
            this.ucCommition1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCommition1.Name = "ucCommition1";
            this.ucCommition1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucCommition1.Size = new System.Drawing.Size(419, 331);
            this.ucCommition1.TabIndex = 2;
            this.ucCommition1.Tax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucCommition1.Title = "کمیسیون محاسبه شده";
            this.ucCommition1.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // frmCommitionCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 574);
            this.Controls.Add(this.ucCommition1);
            this.Controls.Add(this.ucAccept);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommitionCalculator";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommitionCalculator_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private WindowsSerivces.UcActionButton ucAccept;
        private WindowsSerivces.UC_Header ucHeader;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.RadioButton rbtnSell;
        private System.Windows.Forms.RadioButton rbtnRahn;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private WindowsSerivces.CurrencyTextBox txtPrice2;
        private System.Windows.Forms.Label lblPrice2;
        private WindowsSerivces.CurrencyTextBox txtPrice1;
        private System.Windows.Forms.Label lblPrice1;
        private UserControls.Contract.Public.UcCommition ucCommition1;
    }
}