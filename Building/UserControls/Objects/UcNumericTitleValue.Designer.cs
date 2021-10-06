
namespace Building.UserControls.Objects
{
    partial class UcNumericTitleValue
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
            this.txtValue = new System.Windows.Forms.NumericUpDown();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtValue.Location = new System.Drawing.Point(3, 4);
            this.txtValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(86, 27);
            this.txtValue.TabIndex = 55744;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(95, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 20);
            this.lblTitle.TabIndex = 55745;
            this.lblTitle.Text = "زیربنا";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UcNumericTitleValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcNumericTitleValue";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(184, 36);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtValue;
        private System.Windows.Forms.Label lblTitle;
    }
}
