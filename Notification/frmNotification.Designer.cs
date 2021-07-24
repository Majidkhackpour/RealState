namespace Notification
{
    partial class frmNotification
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
            this.Styler = new System.Windows.Forms.Timer(this.components);
            this.ClosingTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.grpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Styler
            // 
            this.Styler.Interval = 1;
            this.Styler.Tick += new System.EventHandler(this.Styler_Tick);
            // 
            // ClosingTimer
            // 
            this.ClosingTimer.Interval = 5000;
            this.ClosingTimer.Tick += new System.EventHandler(this.ClosingTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 52);
            this.panel1.TabIndex = 0;
            // 
            // grpPanel
            // 
            this.grpPanel.BackColor = System.Drawing.Color.Transparent;
            this.grpPanel.CanvasColor = System.Drawing.Color.Empty;
            this.grpPanel.Controls.Add(this.lblText);
            this.grpPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Location = new System.Drawing.Point(0, 0);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Size = new System.Drawing.Size(430, 52);
            // 
            // 
            // 
            this.grpPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.grpPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.grpPanel.Style.BackgroundImageAlpha = ((byte)(90));
            this.grpPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.grpPanel.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(81)))), ((int)(((byte)(219)))));
            this.grpPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.CornerDiameter = 10;
            this.grpPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            // 
            // 
            // 
            this.grpPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpPanel.TabIndex = 3;
            // 
            // lblText
            // 
            this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText.ForeColor = System.Drawing.Color.White;
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(430, 52);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "label1";
            this.lblText.Click += new System.EventHandler(this.lblText_Click_1);
            // 
            // frmNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(430, 52);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotification";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.frmNotification_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNotification_KeyDown);
            this.panel1.ResumeLayout(false);
            this.grpPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Styler;
        private System.Windows.Forms.Timer ClosingTimer;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel grpPanel;
        private System.Windows.Forms.Label lblText;
    }
}