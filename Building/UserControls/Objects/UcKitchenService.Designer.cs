
namespace Building.UserControls.Objects
{
    partial class UcKitchenService
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
            this.KitchenServiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbKitchenService = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KitchenServiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // KitchenServiceBindingSource
            // 
            this.KitchenServiceBindingSource.DataSource = typeof(EntityCache.Bussines.KitchenServiceBussines);
            // 
            // cmbKitchenService
            // 
            this.cmbKitchenService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbKitchenService.DataSource = this.KitchenServiceBindingSource;
            this.cmbKitchenService.DisplayMember = "Name";
            this.cmbKitchenService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKitchenService.FormattingEnabled = true;
            this.cmbKitchenService.Location = new System.Drawing.Point(3, 5);
            this.cmbKitchenService.Name = "cmbKitchenService";
            this.cmbKitchenService.Size = new System.Drawing.Size(119, 28);
            this.cmbKitchenService.TabIndex = 61;
            this.cmbKitchenService.ValueMember = "Guid";
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Location = new System.Drawing.Point(128, 8);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(41, 20);
            this.label45.TabIndex = 62;
            this.label45.Text = "کابینت";
            // 
            // UcKitchenService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbKitchenService);
            this.Controls.Add(this.label45);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcKitchenService";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(174, 36);
            ((System.ComponentModel.ISupportInitialize)(this.KitchenServiceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource KitchenServiceBindingSource;
        private System.Windows.Forms.ComboBox cmbKitchenService;
        private System.Windows.Forms.Label label45;
    }
}
