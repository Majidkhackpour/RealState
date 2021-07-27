
using DevComponents.DotNetBar.Controls;

namespace Notification
{
    partial class frmDivarNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDivarNotification));
            this.Styler = new System.Windows.Forms.Timer(this.components);
            this.ClosingTimer = new System.Windows.Forms.Timer(this.components);
            this.grpPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button1 = new DevComponents.DotNetBar.Controls.Line();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRentAppartment = new System.Windows.Forms.Label();
            this.lblRentVilla = new System.Windows.Forms.Label();
            this.lblRentOffice = new System.Windows.Forms.Label();
            this.lblRentStore = new System.Windows.Forms.Label();
            this.lblRentGraund = new System.Windows.Forms.Label();
            this.lblBuyVilla = new System.Windows.Forms.Label();
            this.lblBuyAppartment = new System.Windows.Forms.Label();
            this.lblBuyOldHouse = new System.Windows.Forms.Label();
            this.lblBuyOffice = new System.Windows.Forms.Label();
            this.lblBuyGraund = new System.Windows.Forms.Label();
            this.lblBuyStore = new System.Windows.Forms.Label();
            this.lblMosharekat = new System.Windows.Forms.Label();
            this.lblPreBuy = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.grpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Styler
            // 
            this.Styler.Interval = 30;
            this.Styler.Tick += new System.EventHandler(this.Styler_Tick);
            // 
            // ClosingTimer
            // 
            this.ClosingTimer.Interval = 20000;
            this.ClosingTimer.Tick += new System.EventHandler(this.ClosingTimer_Tick);
            // 
            // grpPanel
            // 
            this.grpPanel.BackColor = System.Drawing.Color.Transparent;
            this.grpPanel.CanvasColor = System.Drawing.Color.Empty;
            this.grpPanel.Controls.Add(this.lblTotal);
            this.grpPanel.Controls.Add(this.lblMosharekat);
            this.grpPanel.Controls.Add(this.lblBuyOldHouse);
            this.grpPanel.Controls.Add(this.lblRentStore);
            this.grpPanel.Controls.Add(this.lblBuyStore);
            this.grpPanel.Controls.Add(this.lblBuyAppartment);
            this.grpPanel.Controls.Add(this.lblRentVilla);
            this.grpPanel.Controls.Add(this.lblPreBuy);
            this.grpPanel.Controls.Add(this.lblBuyGraund);
            this.grpPanel.Controls.Add(this.lblBuyVilla);
            this.grpPanel.Controls.Add(this.lblRentOffice);
            this.grpPanel.Controls.Add(this.lblBuyOffice);
            this.grpPanel.Controls.Add(this.lblRentGraund);
            this.grpPanel.Controls.Add(this.lblRentAppartment);
            this.grpPanel.Controls.Add(this.line1);
            this.grpPanel.Controls.Add(this.button1);
            this.grpPanel.Controls.Add(this.label1);
            this.grpPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Location = new System.Drawing.Point(0, 0);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Size = new System.Drawing.Size(310, 408);
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
            this.grpPanel.TabIndex = 55731;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 10);
            this.button1.TabIndex = 55730;
            this.button1.Text = "button1";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Yekan", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 44);
            this.label1.TabIndex = 55729;
            this.label1.Text = "فایل های دریافت شده از دیوار";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 408);
            this.panel1.TabIndex = 55732;
            // 
            // lblRentAppartment
            // 
            this.lblRentAppartment.ForeColor = System.Drawing.Color.White;
            this.lblRentAppartment.Location = new System.Drawing.Point(0, 52);
            this.lblRentAppartment.Name = "lblRentAppartment";
            this.lblRentAppartment.Size = new System.Drawing.Size(310, 21);
            this.lblRentAppartment.TabIndex = 55731;
            this.lblRentAppartment.Text = "label2";
            this.lblRentAppartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRentVilla
            // 
            this.lblRentVilla.ForeColor = System.Drawing.Color.White;
            this.lblRentVilla.Location = new System.Drawing.Point(0, 73);
            this.lblRentVilla.Name = "lblRentVilla";
            this.lblRentVilla.Size = new System.Drawing.Size(310, 21);
            this.lblRentVilla.TabIndex = 55731;
            this.lblRentVilla.Text = "label2";
            this.lblRentVilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRentOffice
            // 
            this.lblRentOffice.ForeColor = System.Drawing.Color.White;
            this.lblRentOffice.Location = new System.Drawing.Point(0, 94);
            this.lblRentOffice.Name = "lblRentOffice";
            this.lblRentOffice.Size = new System.Drawing.Size(310, 21);
            this.lblRentOffice.TabIndex = 55731;
            this.lblRentOffice.Text = "label2";
            this.lblRentOffice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRentStore
            // 
            this.lblRentStore.ForeColor = System.Drawing.Color.White;
            this.lblRentStore.Location = new System.Drawing.Point(0, 115);
            this.lblRentStore.Name = "lblRentStore";
            this.lblRentStore.Size = new System.Drawing.Size(310, 21);
            this.lblRentStore.TabIndex = 55731;
            this.lblRentStore.Text = "label2";
            this.lblRentStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRentGraund
            // 
            this.lblRentGraund.ForeColor = System.Drawing.Color.White;
            this.lblRentGraund.Location = new System.Drawing.Point(0, 136);
            this.lblRentGraund.Name = "lblRentGraund";
            this.lblRentGraund.Size = new System.Drawing.Size(310, 21);
            this.lblRentGraund.TabIndex = 55731;
            this.lblRentGraund.Text = "label2";
            this.lblRentGraund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyVilla
            // 
            this.lblBuyVilla.ForeColor = System.Drawing.Color.White;
            this.lblBuyVilla.Location = new System.Drawing.Point(0, 178);
            this.lblBuyVilla.Name = "lblBuyVilla";
            this.lblBuyVilla.Size = new System.Drawing.Size(310, 21);
            this.lblBuyVilla.TabIndex = 55731;
            this.lblBuyVilla.Text = "label2";
            this.lblBuyVilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyAppartment
            // 
            this.lblBuyAppartment.ForeColor = System.Drawing.Color.White;
            this.lblBuyAppartment.Location = new System.Drawing.Point(0, 157);
            this.lblBuyAppartment.Name = "lblBuyAppartment";
            this.lblBuyAppartment.Size = new System.Drawing.Size(310, 21);
            this.lblBuyAppartment.TabIndex = 55731;
            this.lblBuyAppartment.Text = "label2";
            this.lblBuyAppartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyOldHouse
            // 
            this.lblBuyOldHouse.ForeColor = System.Drawing.Color.White;
            this.lblBuyOldHouse.Location = new System.Drawing.Point(0, 199);
            this.lblBuyOldHouse.Name = "lblBuyOldHouse";
            this.lblBuyOldHouse.Size = new System.Drawing.Size(310, 21);
            this.lblBuyOldHouse.TabIndex = 55731;
            this.lblBuyOldHouse.Text = "label2";
            this.lblBuyOldHouse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyOffice
            // 
            this.lblBuyOffice.ForeColor = System.Drawing.Color.White;
            this.lblBuyOffice.Location = new System.Drawing.Point(0, 220);
            this.lblBuyOffice.Name = "lblBuyOffice";
            this.lblBuyOffice.Size = new System.Drawing.Size(310, 21);
            this.lblBuyOffice.TabIndex = 55731;
            this.lblBuyOffice.Text = "label2";
            this.lblBuyOffice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyGraund
            // 
            this.lblBuyGraund.ForeColor = System.Drawing.Color.White;
            this.lblBuyGraund.Location = new System.Drawing.Point(0, 262);
            this.lblBuyGraund.Name = "lblBuyGraund";
            this.lblBuyGraund.Size = new System.Drawing.Size(310, 21);
            this.lblBuyGraund.TabIndex = 55731;
            this.lblBuyGraund.Text = "label2";
            this.lblBuyGraund.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBuyStore
            // 
            this.lblBuyStore.ForeColor = System.Drawing.Color.White;
            this.lblBuyStore.Location = new System.Drawing.Point(0, 241);
            this.lblBuyStore.Name = "lblBuyStore";
            this.lblBuyStore.Size = new System.Drawing.Size(310, 21);
            this.lblBuyStore.TabIndex = 55731;
            this.lblBuyStore.Text = "label2";
            this.lblBuyStore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMosharekat
            // 
            this.lblMosharekat.ForeColor = System.Drawing.Color.White;
            this.lblMosharekat.Location = new System.Drawing.Point(0, 283);
            this.lblMosharekat.Name = "lblMosharekat";
            this.lblMosharekat.Size = new System.Drawing.Size(310, 21);
            this.lblMosharekat.TabIndex = 55731;
            this.lblMosharekat.Text = "label2";
            this.lblMosharekat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPreBuy
            // 
            this.lblPreBuy.ForeColor = System.Drawing.Color.White;
            this.lblPreBuy.Location = new System.Drawing.Point(0, 304);
            this.lblPreBuy.Name = "lblPreBuy";
            this.lblPreBuy.Size = new System.Drawing.Size(310, 21);
            this.lblPreBuy.TabIndex = 55731;
            this.lblPreBuy.Text = "label2";
            this.lblPreBuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(0, 342);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(310, 36);
            this.lblTotal.TabIndex = 55731;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // line1
            // 
            this.line1.ForeColor = System.Drawing.Color.White;
            this.line1.Location = new System.Drawing.Point(2, 326);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(310, 10);
            this.line1.TabIndex = 55730;
            this.line1.Text = "button1";
            // 
            // frmDivarNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 408);
            this.ControlBox = false;
            this.Controls.Add(this.grpPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDivarNotification";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
            this.Load += new System.EventHandler(this.frmDivarNotification_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDivarNotification_KeyDown);
            this.grpPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Styler;
        private System.Windows.Forms.Timer ClosingTimer;
        private DevComponents.DotNetBar.Controls.GroupPanel grpPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Line button1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblMosharekat;
        private System.Windows.Forms.Label lblBuyOldHouse;
        private System.Windows.Forms.Label lblRentStore;
        private System.Windows.Forms.Label lblBuyStore;
        private System.Windows.Forms.Label lblBuyAppartment;
        private System.Windows.Forms.Label lblRentVilla;
        private System.Windows.Forms.Label lblPreBuy;
        private System.Windows.Forms.Label lblBuyGraund;
        private System.Windows.Forms.Label lblBuyVilla;
        private System.Windows.Forms.Label lblRentOffice;
        private System.Windows.Forms.Label lblBuyOffice;
        private System.Windows.Forms.Label lblRentGraund;
        private System.Windows.Forms.Label lblRentAppartment;
        private Line line1;
    }
}