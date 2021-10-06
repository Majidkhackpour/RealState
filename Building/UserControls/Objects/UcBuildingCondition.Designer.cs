
namespace Building.UserControls.Objects
{
    partial class UcBuildingCondition
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
            this.cmbBuildingCondition = new System.Windows.Forms.ComboBox();
            this.bConditionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label38 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bConditionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBuildingCondition
            // 
            this.cmbBuildingCondition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbBuildingCondition.DataSource = this.bConditionBindingSource;
            this.cmbBuildingCondition.DisplayMember = "Name";
            this.cmbBuildingCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuildingCondition.FormattingEnabled = true;
            this.cmbBuildingCondition.Location = new System.Drawing.Point(6, 4);
            this.cmbBuildingCondition.Name = "cmbBuildingCondition";
            this.cmbBuildingCondition.Size = new System.Drawing.Size(119, 28);
            this.cmbBuildingCondition.TabIndex = 55750;
            this.cmbBuildingCondition.ValueMember = "Guid";
            // 
            // bConditionBindingSource
            // 
            this.bConditionBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingConditionBussines);
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Location = new System.Drawing.Point(131, 7);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(60, 20);
            this.label38.TabIndex = 55751;
            this.label38.Text = "وضعیت بنا";
            // 
            // UcBuildingCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbBuildingCondition);
            this.Controls.Add(this.label38);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingCondition";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(192, 36);
            ((System.ComponentModel.ISupportInitialize)(this.bConditionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBuildingCondition;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.BindingSource bConditionBindingSource;
    }
}
