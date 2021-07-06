
using DevComponents.DotNetBar.Controls;

namespace RealState.LoginPanel
{
    partial class frmLoginMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginMain));
            this.grpPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.picBackGroud = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackGroud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPanel
            // 
            this.grpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.grpPanel.BackColor = System.Drawing.Color.Transparent;
            this.grpPanel.CanvasColor = System.Drawing.Color.Empty;
            this.grpPanel.Controls.Add(this.pictureBox1);
            this.grpPanel.Controls.Add(this.pnlContent);
            this.grpPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPanel.Location = new System.Drawing.Point(211, 68);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Size = new System.Drawing.Size(383, 456);
            // 
            // 
            // 
            this.grpPanel.Style.BackColor = System.Drawing.Color.White;
            this.grpPanel.Style.BackColor2 = System.Drawing.Color.White;
            this.grpPanel.Style.BackgroundImageAlpha = ((byte)(90));
            this.grpPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderColor = System.Drawing.Color.White;
            this.grpPanel.Style.BorderColor2 = System.Drawing.Color.White;
            this.grpPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.CornerDiameter = 20;
            this.grpPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            // 
            // 
            // 
            this.grpPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpPanel.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Location = new System.Drawing.Point(0, 107);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(383, 349);
            this.pnlContent.TabIndex = 0;
            // 
            // picBackGroud
            // 
            this.picBackGroud.BackColor = System.Drawing.Color.Transparent;
            this.picBackGroud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackGroud.Location = new System.Drawing.Point(0, 0);
            this.picBackGroud.Name = "picBackGroud";
            this.picBackGroud.Size = new System.Drawing.Size(800, 600);
            this.picBackGroud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackGroud.TabIndex = 0;
            this.picBackGroud.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::RealState.Properties.Resources.Arad_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(149, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmLoginMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.grpPanel);
            this.Controls.Add(this.picBackGroud);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmLoginMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoginMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLoginMain_KeyDown);
            this.grpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackGroud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackGroud;
        private GroupPanel grpPanel;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}