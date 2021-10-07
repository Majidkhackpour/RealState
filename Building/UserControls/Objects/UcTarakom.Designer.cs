
namespace Building.UserControls.Objects
{
    partial class UcTarakom
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
            this.rbtnMedium = new System.Windows.Forms.RadioButton();
            this.rbtnLow = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.rbtnHigh = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rbtnMedium
            // 
            this.rbtnMedium.AutoSize = true;
            this.rbtnMedium.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnMedium.Location = new System.Drawing.Point(55, 6);
            this.rbtnMedium.Name = "rbtnMedium";
            this.rbtnMedium.Size = new System.Drawing.Size(59, 24);
            this.rbtnMedium.TabIndex = 12;
            this.rbtnMedium.TabStop = true;
            this.rbtnMedium.Text = "متوسط";
            this.rbtnMedium.UseVisualStyleBackColor = true;
            // 
            // rbtnLow
            // 
            this.rbtnLow.AutoSize = true;
            this.rbtnLow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnLow.Location = new System.Drawing.Point(120, 6);
            this.rbtnLow.Name = "rbtnLow";
            this.rbtnLow.Size = new System.Drawing.Size(40, 24);
            this.rbtnLow.TabIndex = 11;
            this.rbtnLow.TabStop = true;
            this.rbtnLow.Text = "کم";
            this.rbtnLow.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(166, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 20);
            this.label9.TabIndex = 10;
            this.label9.Text = "تراکم";
            // 
            // rbtnHigh
            // 
            this.rbtnHigh.AutoSize = true;
            this.rbtnHigh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnHigh.Location = new System.Drawing.Point(3, 6);
            this.rbtnHigh.Name = "rbtnHigh";
            this.rbtnHigh.Size = new System.Drawing.Size(46, 24);
            this.rbtnHigh.TabIndex = 12;
            this.rbtnHigh.TabStop = true;
            this.rbtnHigh.Text = "زیاد";
            this.rbtnHigh.UseVisualStyleBackColor = true;
            // 
            // UcTarakom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.rbtnHigh);
            this.Controls.Add(this.rbtnMedium);
            this.Controls.Add(this.rbtnLow);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcTarakom";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(210, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnMedium;
        private System.Windows.Forms.RadioButton rbtnLow;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbtnHigh;
    }
}
