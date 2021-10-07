
namespace Building.UserControls.Objects
{
    partial class UcVillaType
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
            this.rbtnCity = new System.Windows.Forms.RadioButton();
            this.rbtnForest = new System.Windows.Forms.RadioButton();
            this.rbtnBeatch = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbtnCity
            // 
            this.rbtnCity.AutoSize = true;
            this.rbtnCity.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnCity.Location = new System.Drawing.Point(6, 6);
            this.rbtnCity.Name = "rbtnCity";
            this.rbtnCity.Size = new System.Drawing.Size(60, 24);
            this.rbtnCity.TabIndex = 15;
            this.rbtnCity.TabStop = true;
            this.rbtnCity.Text = "شهرکی";
            this.rbtnCity.UseVisualStyleBackColor = true;
            // 
            // rbtnForest
            // 
            this.rbtnForest.AutoSize = true;
            this.rbtnForest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnForest.Location = new System.Drawing.Point(72, 6);
            this.rbtnForest.Name = "rbtnForest";
            this.rbtnForest.Size = new System.Drawing.Size(57, 24);
            this.rbtnForest.TabIndex = 16;
            this.rbtnForest.TabStop = true;
            this.rbtnForest.Text = "جنگلی";
            this.rbtnForest.UseVisualStyleBackColor = true;
            // 
            // rbtnBeatch
            // 
            this.rbtnBeatch.AutoSize = true;
            this.rbtnBeatch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnBeatch.Location = new System.Drawing.Point(135, 6);
            this.rbtnBeatch.Name = "rbtnBeatch";
            this.rbtnBeatch.Size = new System.Drawing.Size(58, 24);
            this.rbtnBeatch.TabIndex = 14;
            this.rbtnBeatch.TabStop = true;
            this.rbtnBeatch.Text = "ساحلی";
            this.rbtnBeatch.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(212, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "نوع ویلا";
            // 
            // UcVillaType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.rbtnCity);
            this.Controls.Add(this.rbtnForest);
            this.Controls.Add(this.rbtnBeatch);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcVillaType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(265, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnCity;
        private System.Windows.Forms.RadioButton rbtnForest;
        private System.Windows.Forms.RadioButton rbtnBeatch;
        private System.Windows.Forms.Label label9;
    }
}
