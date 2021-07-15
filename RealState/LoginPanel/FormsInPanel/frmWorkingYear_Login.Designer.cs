
using DevComponents.DotNetBar.Controls;

namespace RealState.LoginPanel.FormsInPanel
{
    partial class frmWorkingYear_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkingYear_Login));
            this.cmbWorkingYear = new System.Windows.Forms.ComboBox();
            this.workingYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pnlOk = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblOk = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblEdit = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.lblRestore = new System.Windows.Forms.Label();
            this.button1 = new DevComponents.DotNetBar.Controls.Line();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCpuSerial = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSoftwareSerial = new System.Windows.Forms.Label();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.lblRecoveryPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workingYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.pnlOk.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbWorkingYear
            // 
            this.cmbWorkingYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWorkingYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbWorkingYear.DataSource = this.workingYearBindingSource;
            this.cmbWorkingYear.DisplayMember = "DbName";
            this.cmbWorkingYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkingYear.FormattingEnabled = true;
            this.cmbWorkingYear.Location = new System.Drawing.Point(39, 12);
            this.cmbWorkingYear.Name = "cmbWorkingYear";
            this.cmbWorkingYear.Size = new System.Drawing.Size(306, 28);
            this.cmbWorkingYear.TabIndex = 0;
            this.cmbWorkingYear.ValueMember = "Guid";
            this.cmbWorkingYear.SelectedIndexChanged += new System.EventHandler(this.cmbWorkingYear_SelectedIndexChanged);
            // 
            // workingYearBindingSource
            // 
            this.workingYearBindingSource.DataSource = typeof(Settings.WorkingYear.WorkingYear);
            // 
            // cmbUserName
            // 
            this.cmbUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUserName.DataSource = this.userBindingSource;
            this.cmbUserName.DisplayMember = "UserName";
            this.cmbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserName.Enabled = false;
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(39, 61);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(306, 28);
            this.cmbUserName.TabIndex = 1;
            this.cmbUserName.ValueMember = "Guid";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPassword.Border.Class = "TextBoxBorder";
            this.txtPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(39, 108);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PreventEnterBeep = true;
            this.txtPassword.Size = new System.Drawing.Size(306, 27);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WatermarkText = "لطفا رمزعبور خود را وارد نمایید";
            // 
            // pnlOk
            // 
            this.pnlOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOk.CanvasColor = System.Drawing.Color.Transparent;
            this.pnlOk.Controls.Add(this.lblOk);
            this.pnlOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlOk.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnlOk.Location = new System.Drawing.Point(39, 169);
            this.pnlOk.Name = "pnlOk";
            this.pnlOk.Size = new System.Drawing.Size(306, 39);
            // 
            // 
            // 
            this.pnlOk.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.pnlOk.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.pnlOk.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.pnlOk.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.pnlOk.Style.CornerDiameter = 15;
            this.pnlOk.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            // 
            // 
            // 
            this.pnlOk.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlOk.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlOk.TabIndex = 55713;
            // 
            // lblOk
            // 
            this.lblOk.BackColor = System.Drawing.Color.Transparent;
            this.lblOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOk.Font = new System.Drawing.Font("B Yekan", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblOk.ForeColor = System.Drawing.Color.White;
            this.lblOk.Location = new System.Drawing.Point(0, 0);
            this.lblOk.Name = "lblOk";
            this.lblOk.Size = new System.Drawing.Size(306, 39);
            this.lblOk.TabIndex = 0;
            this.lblOk.Text = "ورود به سیستم";
            this.lblOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOk.Click += new System.EventHandler(this.lblOk_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel1.Controls.Add(this.lblExit);
            this.groupPanel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(39, 214);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(306, 39);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.groupPanel1.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.groupPanel1.Style.CornerDiameter = 15;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 55714;
            // 
            // lblExit
            // 
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExit.Font = new System.Drawing.Font("B Yekan", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(0, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(306, 39);
            this.lblExit.TabIndex = 0;
            this.lblExit.Text = "خـــــــــــــروج";
            this.lblExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblCreate
            // 
            this.lblCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreate.AutoSize = true;
            this.lblCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCreate.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.lblCreate.Location = new System.Drawing.Point(238, 275);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(105, 20);
            this.lblCreate.TabIndex = 55715;
            this.lblCreate.Text = "ایجاد واحد اقتصادی";
            this.lblCreate.Click += new System.EventHandler(this.lblCreate_Click);
            this.lblCreate.MouseEnter += new System.EventHandler(this.lblCreate_MouseEnter);
            this.lblCreate.MouseLeave += new System.EventHandler(this.lblCreate_MouseLeave);
            // 
            // lblEdit
            // 
            this.lblEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEdit.AutoSize = true;
            this.lblEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEdit.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.lblEdit.Location = new System.Drawing.Point(185, 275);
            this.lblEdit.Name = "lblEdit";
            this.lblEdit.Size = new System.Drawing.Size(48, 20);
            this.lblEdit.TabIndex = 55715;
            this.lblEdit.Text = "ویرایش";
            this.lblEdit.Click += new System.EventHandler(this.lblEdit_Click);
            this.lblEdit.MouseEnter += new System.EventHandler(this.lblEdit_MouseEnter);
            this.lblEdit.MouseLeave += new System.EventHandler(this.lblEdit_MouseLeave);
            // 
            // lblDelete
            // 
            this.lblDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelete.AutoSize = true;
            this.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDelete.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.lblDelete.Location = new System.Drawing.Point(147, 275);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(33, 20);
            this.lblDelete.TabIndex = 55715;
            this.lblDelete.Text = "حذف";
            this.lblDelete.Click += new System.EventHandler(this.lblDelete_Click);
            this.lblDelete.MouseEnter += new System.EventHandler(this.lblDelete_MouseEnter);
            this.lblDelete.MouseLeave += new System.EventHandler(this.lblDelete_MouseLeave);
            // 
            // lblRestore
            // 
            this.lblRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestore.AutoSize = true;
            this.lblRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRestore.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.lblRestore.Location = new System.Drawing.Point(47, 275);
            this.lblRestore.Name = "lblRestore";
            this.lblRestore.Size = new System.Drawing.Size(96, 20);
            this.lblRestore.TabIndex = 55715;
            this.lblRestore.Text = "بازگردانی اطلاعاتی";
            this.lblRestore.Click += new System.EventHandler(this.lblRestore_Click);
            this.lblRestore.MouseEnter += new System.EventHandler(this.lblRestore_MouseEnter);
            this.lblRestore.MouseLeave += new System.EventHandler(this.lblRestore_MouseLeave);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.button1.Location = new System.Drawing.Point(231, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 11);
            this.button1.TabIndex = 55716;
            this.button1.VerticalLine = true;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.line1.Location = new System.Drawing.Point(177, 280);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(10, 11);
            this.line1.TabIndex = 55717;
            this.line1.VerticalLine = true;
            // 
            // line2
            // 
            this.line2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.line2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.line2.Location = new System.Drawing.Point(140, 280);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(10, 11);
            this.line2.TabIndex = 55718;
            this.line2.VerticalLine = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.label2.Location = new System.Drawing.Point(277, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 55715;
            this.label2.Text = "شناسه فنی:";
            // 
            // lblCpuSerial
            // 
            this.lblCpuSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCpuSerial.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCpuSerial.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCpuSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.lblCpuSerial.Location = new System.Drawing.Point(47, 307);
            this.lblCpuSerial.Name = "lblCpuSerial";
            this.lblCpuSerial.Size = new System.Drawing.Size(197, 20);
            this.lblCpuSerial.TabIndex = 55715;
            this.lblCpuSerial.Text = "----";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(250, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 55715;
            this.label4.Text = "سریال نرم افزار:";
            // 
            // lblSoftwareSerial
            // 
            this.lblSoftwareSerial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoftwareSerial.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSoftwareSerial.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSoftwareSerial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.lblSoftwareSerial.Location = new System.Drawing.Point(47, 327);
            this.lblSoftwareSerial.Name = "lblSoftwareSerial";
            this.lblSoftwareSerial.Size = new System.Drawing.Size(197, 20);
            this.lblSoftwareSerial.TabIndex = 55715;
            this.lblSoftwareSerial.Text = "----";
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.Location = new System.Drawing.Point(39, 26);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(306, 23);
            this.prgBar.Step = 1;
            this.prgBar.TabIndex = 55719;
            // 
            // lblRecoveryPassword
            // 
            this.lblRecoveryPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecoveryPassword.AutoSize = true;
            this.lblRecoveryPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblRecoveryPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRecoveryPassword.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRecoveryPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.lblRecoveryPassword.Location = new System.Drawing.Point(100, 139);
            this.lblRecoveryPassword.Name = "lblRecoveryPassword";
            this.lblRecoveryPassword.Size = new System.Drawing.Size(184, 20);
            this.lblRecoveryPassword.TabIndex = 55720;
            this.lblRecoveryPassword.Text = "رمز عبور خود را فراموش کرده ام...!";
            this.lblRecoveryPassword.Click += new System.EventHandler(this.lblRecoveryPassword_Click);
            this.lblRecoveryPassword.MouseEnter += new System.EventHandler(this.lblRecoveryPassword_MouseEnter);
            this.lblRecoveryPassword.MouseLeave += new System.EventHandler(this.lblRecoveryPassword_MouseLeave);
            // 
            // frmWorkingYear_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 360);
            this.ControlBox = false;
            this.Controls.Add(this.lblRecoveryPassword);
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblDelete);
            this.Controls.Add(this.lblEdit);
            this.Controls.Add(this.lblRestore);
            this.Controls.Add(this.lblSoftwareSerial);
            this.Controls.Add(this.lblCpuSerial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.pnlOk);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.cmbUserName);
            this.Controls.Add(this.cmbWorkingYear);
            this.Controls.Add(this.prgBar);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWorkingYear_Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWorkingYear_Login_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmWorkingYear_Login_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.workingYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.pnlOk.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbWorkingYear;
        private System.Windows.Forms.ComboBox cmbUserName;
        private TextBoxX txtPassword;
        private GroupPanel pnlOk;
        private System.Windows.Forms.Label lblOk;
        private GroupPanel groupPanel1;
        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblEdit;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Label lblRestore;
        private Line button1;
        private Line line1;
        private Line line2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCpuSerial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSoftwareSerial;
        private System.Windows.Forms.BindingSource workingYearBindingSource;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label lblRecoveryPassword;
    }
}