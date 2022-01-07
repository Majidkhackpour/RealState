
namespace Building.UserControls.Contract.Sarqofli
{
    partial class UcContractSarqofli_4
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
            this.txtSetDocPlace = new System.Windows.Forms.TextBox();
            this.txtSetDocNo = new System.Windows.Forms.NumericUpDown();
            this.ucSetDocDate = new Print.UcDate();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetDocNo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPanel
            // 
            this.grpPanel.BackColor = System.Drawing.Color.Transparent;
            this.grpPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpPanel.Controls.Add(this.txtSetDocPlace);
            this.grpPanel.Controls.Add(this.txtSetDocNo);
            this.grpPanel.Controls.Add(this.ucSetDocDate);
            this.grpPanel.Controls.Add(this.label2);
            this.grpPanel.Controls.Add(this.label1);
            this.grpPanel.Controls.Add(this.label6);
            this.grpPanel.Controls.Add(this.label5);
            this.grpPanel.Controls.Add(this.label3);
            this.grpPanel.Controls.Add(this.label7);
            this.grpPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Location = new System.Drawing.Point(0, 0);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpPanel.Size = new System.Drawing.Size(848, 177);
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
            this.grpPanel.Text = "ماده 4 - شرایط مربوط به تنظیم سند";
            // 
            // txtSetDocPlace
            // 
            this.txtSetDocPlace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSetDocPlace.Location = new System.Drawing.Point(3, 15);
            this.txtSetDocPlace.Name = "txtSetDocPlace";
            this.txtSetDocPlace.Size = new System.Drawing.Size(139, 27);
            this.txtSetDocPlace.TabIndex = 21;
            // 
            // txtSetDocNo
            // 
            this.txtSetDocNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSetDocNo.Location = new System.Drawing.Point(201, 15);
            this.txtSetDocNo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSetDocNo.Name = "txtSetDocNo";
            this.txtSetDocNo.Size = new System.Drawing.Size(68, 27);
            this.txtSetDocNo.TabIndex = 13;
            // 
            // ucSetDocDate
            // 
            this.ucSetDocDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSetDocDate.DateSh = "1400/10/5";
            this.ucSetDocDate.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucSetDocDate.Location = new System.Drawing.Point(411, 6);
            this.ucSetDocDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSetDocDate.Name = "ucSetDocDate";
            this.ucSetDocDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucSetDocDate.Size = new System.Drawing.Size(246, 41);
            this.ucSetDocDate.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(148, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "واقع در";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(275, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "در دفترخانه رسمی شماره";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(3, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(830, 42);
            this.label6.TabIndex = 11;
            this.label6.Text = "4-3 عدم ارائه مستندات و مدارک لازم جهت تنظیم سند از طرف انتقال دهنده  و عدم پرداخ" +
    "ت ثمن معامله توسط انتقال گیرنده  در حکم حضور است و سردفتر در موارد مذکور، مجاز ب" +
    "ه صدور گواهی عدم حضور می باشد.";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(196, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(637, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "4-2 درصورت عدم حضور هریک از طرفین در دفترخانه اسناد رسمی برای تنظیم سند، گواهی عد" +
    "م حضور در دفترخانه صادر میگردد.";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(171, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(662, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "حاضر شده و ضمن انجام کلیه تعهدات و شرایط مندرج در این قرارداد، نسبت به تنظیم سند " +
    "رسمی مورد معامله به نام خریدار اقدام نمایند.";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(664, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(169, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "4-1 طرفین متعهد شدند در تاریخ";
            // 
            // UcContractSarqofli_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPanel);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcContractSarqofli_4";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(848, 177);
            this.grpPanel.ResumeLayout(false);
            this.grpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSetDocNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel grpPanel;
        private System.Windows.Forms.TextBox txtSetDocPlace;
        private System.Windows.Forms.NumericUpDown txtSetDocNo;
        private Print.UcDate ucSetDocDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}
