
namespace Building.UserControls.Objects
{
    partial class UcBuildingView
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
            this.cmbBView = new System.Windows.Forms.ComboBox();
            this.BuildingViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label43 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBView
            // 
            this.cmbBView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBView.DataSource = this.BuildingViewBindingSource;
            this.cmbBView.DisplayMember = "Name";
            this.cmbBView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBView.FormattingEnabled = true;
            this.cmbBView.Location = new System.Drawing.Point(3, 4);
            this.cmbBView.Name = "cmbBView";
            this.cmbBView.Size = new System.Drawing.Size(119, 28);
            this.cmbBView.TabIndex = 63;
            this.cmbBView.ValueMember = "Guid";
            // 
            // BuildingViewBindingSource
            // 
            this.BuildingViewBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingViewBussines);
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Location = new System.Drawing.Point(128, 7);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(22, 20);
            this.label43.TabIndex = 64;
            this.label43.Text = "نما";
            // 
            // UcBuildingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbBView);
            this.Controls.Add(this.label43);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingView";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(156, 36);
            ((System.ComponentModel.ISupportInitialize)(this.BuildingViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBView;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.BindingSource BuildingViewBindingSource;
    }
}
