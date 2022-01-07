
namespace Building.UserControls.Contract.Rahn
{
    partial class UcContractRahn_3
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
            this.grpPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtTerm = new System.Windows.Forms.NumericUpDown();
            this.ucDischargeDate = new Print.UcDate();
            this.ucFromDate = new Print.UcDate();
            this.label1 = new System.Windows.Forms.Label();
            this.lblContractDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.grpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerm)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPanel
            // 
            this.grpPanel.BackColor = System.Drawing.Color.Transparent;
            this.grpPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpPanel.Controls.Add(this.txtTerm);
            this.grpPanel.Controls.Add(this.ucDischargeDate);
            this.grpPanel.Controls.Add(this.ucFromDate);
            this.grpPanel.Controls.Add(this.label12);
            this.grpPanel.Controls.Add(this.label9);
            this.grpPanel.Controls.Add(this.label1);
            this.grpPanel.Controls.Add(this.lblToDate);
            this.grpPanel.Controls.Add(this.lblContractDate);
            this.grpPanel.Controls.Add(this.label11);
            this.grpPanel.Controls.Add(this.label10);
            this.grpPanel.Controls.Add(this.label8);
            this.grpPanel.Controls.Add(this.label7);
            this.grpPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Location = new System.Drawing.Point(0, 0);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpPanel.Size = new System.Drawing.Size(848, 108);
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
            this.grpPanel.TabIndex = 3;
            this.grpPanel.Text = "ماده 3 -مدت اجاره";
            // 
            // txtTerm
            // 
            this.txtTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerm.Location = new System.Drawing.Point(229, 10);
            this.txtTerm.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(68, 27);
            this.txtTerm.TabIndex = 13;
            this.txtTerm.ValueChanged += new System.EventHandler(this.txtTerm_ValueChanged);
            // 
            // ucDischargeDate
            // 
            this.ucDischargeDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDischargeDate.DateSh = "0/0/0";
            this.ucDischargeDate.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucDischargeDate.Location = new System.Drawing.Point(270, 38);
            this.ucDischargeDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDischargeDate.Name = "ucDischargeDate";
            this.ucDischargeDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucDischargeDate.Size = new System.Drawing.Size(246, 41);
            this.ucDischargeDate.TabIndex = 12;
            // 
            // ucFromDate
            // 
            this.ucFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFromDate.DateSh = "0/0/0";
            this.ucFromDate.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFromDate.Location = new System.Drawing.Point(355, 0);
            this.ucFromDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFromDate.Name = "ucFromDate";
            this.ucFromDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFromDate.Size = new System.Drawing.Size(246, 41);
            this.ucFromDate.TabIndex = 12;
            this.ucFromDate.OnDateChanged += new System.Action<string>(this.ucFromDate_OnDateChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(303, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "به مدت";
            // 
            // lblContractDate
            // 
            this.lblContractDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContractDate.AutoSize = true;
            this.lblContractDate.BackColor = System.Drawing.Color.Transparent;
            this.lblContractDate.Location = new System.Drawing.Point(625, 50);
            this.lblContractDate.Name = "lblContractDate";
            this.lblContractDate.Size = new System.Drawing.Size(85, 20);
            this.lblContractDate.TabIndex = 11;
            this.lblContractDate.Text = "1400/12/29";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(211, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 20);
            this.label11.TabIndex = 11;
            this.label11.Text = "می باشد.";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(521, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "و تاریخ تحویل ملک";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(716, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "3-2 تاریخ عقد قرارداد";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(606, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(231, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "3-1 مدت اجاره روز/ماه/سال شمسی، از تاریخ";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(153, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "ماه، الی تاریخ";
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Location = new System.Drawing.Point(62, 12);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(85, 20);
            this.lblToDate.TabIndex = 11;
            this.lblToDate.Text = "1400/12/29";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(7, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 20);
            this.label12.TabIndex = 11;
            this.label12.Text = "می باشد.";
            // 
            // UcContractRahn_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPanel);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcContractRahn_3";
            this.Size = new System.Drawing.Size(848, 108);
            this.grpPanel.ResumeLayout(false);
            this.grpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTerm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel grpPanel;
        private System.Windows.Forms.NumericUpDown txtTerm;
        private Print.UcDate ucDischargeDate;
        private Print.UcDate ucFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblContractDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblToDate;
    }
}
