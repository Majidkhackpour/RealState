
namespace Building.UserControls.Objects
{
    partial class UcCommericallLicense
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
            this.rbtnDaemi = new System.Windows.Forms.RadioButton();
            this.rbtnTemporary = new System.Windows.Forms.RadioButton();
            this.rbtnNone = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbtnDaemi
            // 
            this.rbtnDaemi.AutoSize = true;
            this.rbtnDaemi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnDaemi.Location = new System.Drawing.Point(3, 6);
            this.rbtnDaemi.Name = "rbtnDaemi";
            this.rbtnDaemi.Size = new System.Drawing.Size(49, 24);
            this.rbtnDaemi.TabIndex = 15;
            this.rbtnDaemi.TabStop = true;
            this.rbtnDaemi.Text = "دائم";
            this.rbtnDaemi.UseVisualStyleBackColor = true;
            // 
            // rbtnTemporary
            // 
            this.rbtnTemporary.AutoSize = true;
            this.rbtnTemporary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnTemporary.Location = new System.Drawing.Point(58, 6);
            this.rbtnTemporary.Name = "rbtnTemporary";
            this.rbtnTemporary.Size = new System.Drawing.Size(55, 24);
            this.rbtnTemporary.TabIndex = 16;
            this.rbtnTemporary.TabStop = true;
            this.rbtnTemporary.Text = "موقت";
            this.rbtnTemporary.UseVisualStyleBackColor = true;
            // 
            // rbtnNone
            // 
            this.rbtnNone.AutoSize = true;
            this.rbtnNone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnNone.Location = new System.Drawing.Point(119, 6);
            this.rbtnNone.Name = "rbtnNone";
            this.rbtnNone.Size = new System.Drawing.Size(54, 24);
            this.rbtnNone.TabIndex = 14;
            this.rbtnNone.TabStop = true;
            this.rbtnNone.Text = "ندارد";
            this.rbtnNone.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(179, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "مجوز تجاری";
            // 
            // UcCommericallLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.rbtnDaemi);
            this.Controls.Add(this.rbtnTemporary);
            this.Controls.Add(this.rbtnNone);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcCommericallLicense";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(251, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnDaemi;
        private System.Windows.Forms.RadioButton rbtnTemporary;
        private System.Windows.Forms.RadioButton rbtnNone;
        private System.Windows.Forms.Label label9;
    }
}
