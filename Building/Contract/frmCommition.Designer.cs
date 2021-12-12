
namespace Building.Contract
{
    partial class frmCommition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommition));
            this.ucTotalCommition1 = new Building.UserControls.Contract.Public.UcTotalCommition();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // ucTotalCommition1
            // 
            this.ucTotalCommition1.FirstAvarez = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.FirstDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.FirstTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.FirstTotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTotalCommition1.Location = new System.Drawing.Point(4, 11);
            this.ucTotalCommition1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTotalCommition1.Name = "ucTotalCommition1";
            this.ucTotalCommition1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTotalCommition1.SecondAvarez = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.SecondDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.SecondTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.SecondTotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.Size = new System.Drawing.Size(885, 350);
            this.ucTotalCommition1.TabIndex = 0;
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Building.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(764, 503);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55803;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
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
            this.btnCancel.Image = global::Building.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(21, 503);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55804;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            // 
            // frmCommition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 540);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.ucTotalCommition1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommition";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmCommition_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommition_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Contract.Public.UcTotalCommition ucTotalCommition1;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}