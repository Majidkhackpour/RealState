
namespace Settings.Forms
{
    partial class frmSandouq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSandouq));
            this.pnlSandouq = new DevComponents.DotNetBar.PanelEx();
            this.txtSTabdil = new System.Windows.Forms.NumericUpDown();
            this.txtSArzesh = new System.Windows.Forms.NumericUpDown();
            this.txtSNatCode = new System.Windows.Forms.TextBox();
            this.cmbSType = new System.Windows.Forms.ComboBox();
            this.txtSIdCode = new System.Windows.Forms.TextBox();
            this.txtSCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.pnlSandouq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTabdil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSArzesh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSandouq
            // 
            this.pnlSandouq.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlSandouq.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnlSandouq.Controls.Add(this.txtSTabdil);
            this.pnlSandouq.Controls.Add(this.txtSArzesh);
            this.pnlSandouq.Controls.Add(this.txtSNatCode);
            this.pnlSandouq.Controls.Add(this.cmbSType);
            this.pnlSandouq.Controls.Add(this.txtSIdCode);
            this.pnlSandouq.Controls.Add(this.txtSCode);
            this.pnlSandouq.Controls.Add(this.label9);
            this.pnlSandouq.Controls.Add(this.label10);
            this.pnlSandouq.Controls.Add(this.label14);
            this.pnlSandouq.Controls.Add(this.label15);
            this.pnlSandouq.Controls.Add(this.label16);
            this.pnlSandouq.Controls.Add(this.label17);
            this.pnlSandouq.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlSandouq.Location = new System.Drawing.Point(7, 12);
            this.pnlSandouq.Name = "pnlSandouq";
            this.pnlSandouq.Size = new System.Drawing.Size(535, 209);
            this.pnlSandouq.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnlSandouq.Style.BackColor1.Color = System.Drawing.Color.White;
            this.pnlSandouq.Style.BackColor2.Color = System.Drawing.Color.White;
            this.pnlSandouq.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnlSandouq.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.pnlSandouq.Style.BorderWidth = 2;
            this.pnlSandouq.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlSandouq.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlSandouq.Style.GradientAngle = 90;
            this.pnlSandouq.TabIndex = 0;
            // 
            // txtSTabdil
            // 
            this.txtSTabdil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSTabdil.Location = new System.Drawing.Point(9, 165);
            this.txtSTabdil.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSTabdil.Name = "txtSTabdil";
            this.txtSTabdil.Size = new System.Drawing.Size(129, 27);
            this.txtSTabdil.TabIndex = 5;
            // 
            // txtSArzesh
            // 
            this.txtSArzesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSArzesh.Location = new System.Drawing.Point(275, 165);
            this.txtSArzesh.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSArzesh.Name = "txtSArzesh";
            this.txtSArzesh.Size = new System.Drawing.Size(139, 27);
            this.txtSArzesh.TabIndex = 4;
            // 
            // txtSNatCode
            // 
            this.txtSNatCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSNatCode.Location = new System.Drawing.Point(9, 90);
            this.txtSNatCode.Name = "txtSNatCode";
            this.txtSNatCode.Size = new System.Drawing.Size(406, 27);
            this.txtSNatCode.TabIndex = 2;
            // 
            // cmbSType
            // 
            this.cmbSType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSType.FormattingEnabled = true;
            this.cmbSType.Location = new System.Drawing.Point(9, 54);
            this.cmbSType.Name = "cmbSType";
            this.cmbSType.Size = new System.Drawing.Size(406, 28);
            this.cmbSType.TabIndex = 1;
            // 
            // txtSIdCode
            // 
            this.txtSIdCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSIdCode.Location = new System.Drawing.Point(9, 126);
            this.txtSIdCode.Name = "txtSIdCode";
            this.txtSIdCode.Size = new System.Drawing.Size(406, 27);
            this.txtSIdCode.TabIndex = 3;
            // 
            // txtSCode
            // 
            this.txtSCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSCode.Location = new System.Drawing.Point(9, 18);
            this.txtSCode.Name = "txtSCode";
            this.txtSCode.Size = new System.Drawing.Size(406, 27);
            this.txtSCode.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(442, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "شماره شناسنامه";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(421, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "وضعیت کد اقتصادی";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(144, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 20);
            this.label14.TabIndex = 6;
            this.label14.Text = "درصد تبدیل رهن و اجاره";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(420, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "درصد ارزش افزوده";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(487, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 20);
            this.label16.TabIndex = 7;
            this.label16.Text = "کد ملی";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(461, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 20);
            this.label17.TabIndex = 8;
            this.label17.Text = "کد اقتصادی";
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Settings.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(390, 229);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 1;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
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
            this.btnCancel.Image = global::Settings.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(16, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmSandouq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.pnlSandouq);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(545, 270);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(545, 270);
            this.Name = "frmSandouq";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmSandouq_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSandouq_KeyDown);
            this.pnlSandouq.ResumeLayout(false);
            this.pnlSandouq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTabdil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSArzesh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnlSandouq;
        private System.Windows.Forms.NumericUpDown txtSTabdil;
        private System.Windows.Forms.NumericUpDown txtSArzesh;
        private System.Windows.Forms.TextBox txtSNatCode;
        private System.Windows.Forms.ComboBox cmbSType;
        private System.Windows.Forms.TextBox txtSIdCode;
        private System.Windows.Forms.TextBox txtSCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}