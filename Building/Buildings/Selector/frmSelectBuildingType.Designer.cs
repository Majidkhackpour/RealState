
using System;
using System.Threading.Tasks;
using WindowsSerivces;

namespace Building.Buildings.Selector
{
    partial class frmSelectBuildingType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectBuildingType));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucMosharekat = new WindowsSerivces.UcButton();
            this.ucMoaveze = new WindowsSerivces.UcButton();
            this.ucPishForoush = new WindowsSerivces.UcButton();
            this.ucFullRahn = new WindowsSerivces.UcButton();
            this.ucRahnEjare = new WindowsSerivces.UcButton();
            this.ucForoush = new WindowsSerivces.UcButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.ucMosharekat);
            this.groupPanel1.Controls.Add(this.ucMoaveze);
            this.groupPanel1.Controls.Add(this.ucPishForoush);
            this.groupPanel1.Controls.Add(this.ucFullRahn);
            this.groupPanel1.Controls.Add(this.ucRahnEjare);
            this.groupPanel1.Controls.Add(this.ucForoush);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(5, 34);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(308, 332);
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
            this.groupPanel1.TabIndex = 2;
            // 
            // ucMosharekat
            // 
            this.ucMosharekat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMosharekat.BackColor = System.Drawing.Color.Transparent;
            this.ucMosharekat.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucMosharekat.IsSelect = false;
            this.ucMosharekat.Location = new System.Drawing.Point(4, 276);
            this.ucMosharekat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucMosharekat.Name = "ucMosharekat";
            this.ucMosharekat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucMosharekat.Size = new System.Drawing.Size(294, 44);
            this.ucMosharekat.TabIndex = 1;
            this.ucMosharekat.Title = "مشارکت در ساخت";
            this.ucMosharekat.OnClick += new System.Func<WindowsSerivces.UcButton, System.Threading.Tasks.Task>(this.ucMosharekat_OnClick);
            // 
            // ucMoaveze
            // 
            this.ucMoaveze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMoaveze.BackColor = System.Drawing.Color.Transparent;
            this.ucMoaveze.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucMoaveze.IsSelect = false;
            this.ucMoaveze.Location = new System.Drawing.Point(4, 222);
            this.ucMoaveze.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucMoaveze.Name = "ucMoaveze";
            this.ucMoaveze.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucMoaveze.Size = new System.Drawing.Size(294, 44);
            this.ucMoaveze.TabIndex = 1;
            this.ucMoaveze.Title = "معاوضه";
            this.ucMoaveze.OnClick += new System.Func<WindowsSerivces.UcButton, System.Threading.Tasks.Task>(this.ucMoaveze_OnClick);
            // 
            // ucPishForoush
            // 
            this.ucPishForoush.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPishForoush.BackColor = System.Drawing.Color.Transparent;
            this.ucPishForoush.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucPishForoush.IsSelect = false;
            this.ucPishForoush.Location = new System.Drawing.Point(4, 168);
            this.ucPishForoush.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPishForoush.Name = "ucPishForoush";
            this.ucPishForoush.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucPishForoush.Size = new System.Drawing.Size(294, 44);
            this.ucPishForoush.TabIndex = 1;
            this.ucPishForoush.Title = "پیش فروش";
            this.ucPishForoush.OnClick += new System.Func<WindowsSerivces.UcButton, System.Threading.Tasks.Task>(this.ucPishForoush_OnClick);
            // 
            // ucFullRahn
            // 
            this.ucFullRahn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFullRahn.BackColor = System.Drawing.Color.Transparent;
            this.ucFullRahn.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFullRahn.IsSelect = false;
            this.ucFullRahn.Location = new System.Drawing.Point(4, 114);
            this.ucFullRahn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFullRahn.Name = "ucFullRahn";
            this.ucFullRahn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFullRahn.Size = new System.Drawing.Size(294, 44);
            this.ucFullRahn.TabIndex = 1;
            this.ucFullRahn.Title = "رهن کامل";
            this.ucFullRahn.OnClick += new System.Func<WindowsSerivces.UcButton, System.Threading.Tasks.Task>(this.ucFullRahn_OnClick);
            // 
            // ucRahnEjare
            // 
            this.ucRahnEjare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRahnEjare.BackColor = System.Drawing.Color.Transparent;
            this.ucRahnEjare.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucRahnEjare.IsSelect = false;
            this.ucRahnEjare.Location = new System.Drawing.Point(4, 60);
            this.ucRahnEjare.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucRahnEjare.Name = "ucRahnEjare";
            this.ucRahnEjare.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucRahnEjare.Size = new System.Drawing.Size(294, 44);
            this.ucRahnEjare.TabIndex = 1;
            this.ucRahnEjare.Title = "رهن و اجاره";
            this.ucRahnEjare.OnClick += new System.Func<WindowsSerivces.UcButton, System.Threading.Tasks.Task>(this.ucRahnEjare_OnClick);
            // 
            // ucForoush
            // 
            this.ucForoush.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucForoush.BackColor = System.Drawing.Color.Transparent;
            this.ucForoush.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucForoush.IsSelect = false;
            this.ucForoush.Location = new System.Drawing.Point(4, 5);
            this.ucForoush.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucForoush.Name = "ucForoush";
            this.ucForoush.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucForoush.Size = new System.Drawing.Size(294, 44);
            this.ucForoush.TabIndex = 1;
            this.ucForoush.Title = "فروش";
            this.ucForoush.OnClick += new System.Func<WindowsSerivces.UcButton, System.Threading.Tasks.Task>(this.ucForoush_OnClick_1);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmSelectBuildingType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 371);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(318, 371);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(318, 371);
            this.Name = "frmSelectBuildingType";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private UcButton ucForoush;
        private UcButton ucMosharekat;
        private UcButton ucMoaveze;
        private UcButton ucPishForoush;
        private UcButton ucFullRahn;
        private UcButton ucRahnEjare;
        private System.Windows.Forms.Timer timer1;
    }
}