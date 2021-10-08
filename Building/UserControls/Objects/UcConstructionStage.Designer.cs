
namespace Building.UserControls.Objects
{
    partial class UcConstructionStage
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
            this.cmbStage = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbStage
            // 
            this.cmbStage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStage.DisplayMember = "Name";
            this.cmbStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStage.FormattingEnabled = true;
            this.cmbStage.Location = new System.Drawing.Point(3, 3);
            this.cmbStage.Name = "cmbStage";
            this.cmbStage.Size = new System.Drawing.Size(119, 28);
            this.cmbStage.TabIndex = 57;
            this.cmbStage.ValueMember = "Guid";
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Location = new System.Drawing.Point(128, 6);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(71, 20);
            this.label39.TabIndex = 56;
            this.label39.Text = "مرحله ساخت";
            // 
            // UcConstructionStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbStage);
            this.Controls.Add(this.label39);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcConstructionStage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(202, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStage;
        private System.Windows.Forms.Label label39;
    }
}
