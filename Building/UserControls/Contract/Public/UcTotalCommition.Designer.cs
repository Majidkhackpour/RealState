
namespace Building.UserControls.Contract.Public
{
    partial class UcTotalCommition
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.UcCom1 = new Building.UserControls.Contract.Public.UcCommition();
            this.UcCom2 = new Building.UserControls.Contract.Public.UcCommition();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.UcCom1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.UcCom2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(878, 342);
            this.splitContainer1.SplitterDistance = 428;
            this.splitContainer1.TabIndex = 0;
            // 
            // UcCom1
            // 
            this.UcCom1.Avarez = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcCom1.Discount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcCom1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcCom1.Location = new System.Drawing.Point(4, 5);
            this.UcCom1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcCom1.Name = "UcCom1";
            this.UcCom1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcCom1.Size = new System.Drawing.Size(419, 331);
            this.UcCom1.TabIndex = 0;
            this.UcCom1.Tax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcCom1.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // UcCom2
            // 
            this.UcCom2.Avarez = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcCom2.Discount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcCom2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcCom2.Location = new System.Drawing.Point(14, 6);
            this.UcCom2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcCom2.Name = "UcCom2";
            this.UcCom2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcCom2.Size = new System.Drawing.Size(419, 331);
            this.UcCom2.TabIndex = 1;
            this.UcCom2.Tax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcCom2.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // UcTotalCommition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcTotalCommition";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(885, 350);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private UcCommition UcCom1;
        private UcCommition UcCom2;
    }
}
