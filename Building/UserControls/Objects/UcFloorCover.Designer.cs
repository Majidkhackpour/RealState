
namespace Building.UserControls.Objects
{
    partial class UcFloorCover
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
            this.components = new System.ComponentModel.Container();
            this.FloorCoverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbBFloorCover = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FloorCoverBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FloorCoverBindingSource
            // 
            this.FloorCoverBindingSource.DataSource = typeof(EntityCache.Bussines.FloorCoverBussines);
            // 
            // cmbBFloorCover
            // 
            this.cmbBFloorCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBFloorCover.DataSource = this.FloorCoverBindingSource;
            this.cmbBFloorCover.DisplayMember = "Name";
            this.cmbBFloorCover.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBFloorCover.FormattingEnabled = true;
            this.cmbBFloorCover.Location = new System.Drawing.Point(6, 4);
            this.cmbBFloorCover.Name = "cmbBFloorCover";
            this.cmbBFloorCover.Size = new System.Drawing.Size(119, 28);
            this.cmbBFloorCover.TabIndex = 62;
            this.cmbBFloorCover.ValueMember = "Guid";
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.Transparent;
            this.label44.Location = new System.Drawing.Point(131, 7);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(44, 20);
            this.label44.TabIndex = 63;
            this.label44.Text = "کفپوش";
            // 
            // UcFloorCover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbBFloorCover);
            this.Controls.Add(this.label44);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcFloorCover";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(177, 36);
            ((System.ComponentModel.ISupportInitialize)(this.FloorCoverBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource FloorCoverBindingSource;
        private System.Windows.Forms.ComboBox cmbBFloorCover;
        private System.Windows.Forms.Label label44;
    }
}
