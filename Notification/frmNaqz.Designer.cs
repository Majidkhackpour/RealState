namespace Notification
{
    partial class frmNaqz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNaqz));
            this.lblNaqz = new System.Windows.Forms.Label();
            this.Styler = new System.Windows.Forms.Timer(this.components);
            this.ClosingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblNaqz
            // 
            this.lblNaqz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNaqz.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNaqz.Location = new System.Drawing.Point(1, 30);
            this.lblNaqz.Name = "lblNaqz";
            this.lblNaqz.Size = new System.Drawing.Size(316, 324);
            this.lblNaqz.TabIndex = 2;
            this.lblNaqz.Text = "جمله قصار";
            this.lblNaqz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNaqz.Click += new System.EventHandler(this.lblNaqz_Click);
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
            // frmNaqz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 379);
            this.ControlBox = false;
            this.Controls.Add(this.lblNaqz);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmNaqz";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Load += new System.EventHandler(this.frmNaqz_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNaqz_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNaqz;
        private System.Windows.Forms.Timer Styler;
        private System.Windows.Forms.Timer ClosingTimer;
    }
}