
namespace Building.UserControls.Objects
{
    partial class UcZirBana
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
            this.cmbZirBana = new System.Windows.Forms.ComboBox();
            this.txtZirBana = new System.Windows.Forms.NumericUpDown();
            this.label33 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtZirBana)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbZirBana
            // 
            this.cmbZirBana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbZirBana.DisplayMember = "Name";
            this.cmbZirBana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZirBana.FormattingEnabled = true;
            this.cmbZirBana.Location = new System.Drawing.Point(3, 4);
            this.cmbZirBana.Name = "cmbZirBana";
            this.cmbZirBana.Size = new System.Drawing.Size(119, 28);
            this.cmbZirBana.TabIndex = 55745;
            this.cmbZirBana.ValueMember = "Guid";
            // 
            // txtZirBana
            // 
            this.txtZirBana.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtZirBana.Location = new System.Drawing.Point(129, 5);
            this.txtZirBana.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtZirBana.Name = "txtZirBana";
            this.txtZirBana.Size = new System.Drawing.Size(73, 27);
            this.txtZirBana.TabIndex = 55744;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Location = new System.Drawing.Point(210, 10);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(36, 20);
            this.label33.TabIndex = 55746;
            this.label33.Text = "زیربنا";
            // 
            // UcZirBana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbZirBana);
            this.Controls.Add(this.txtZirBana);
            this.Controls.Add(this.label33);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcZirBana";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(256, 36);
            ((System.ComponentModel.ISupportInitialize)(this.txtZirBana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbZirBana;
        private System.Windows.Forms.NumericUpDown txtZirBana;
        private System.Windows.Forms.Label label33;
    }
}
