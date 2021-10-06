
namespace Building.UserControls.Objects
{
    partial class UcDocumentType
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
            this.cmbSellSanadType = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.sanadTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sanadTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSellSanadType
            // 
            this.cmbSellSanadType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSellSanadType.DataSource = this.sanadTypeBindingSource;
            this.cmbSellSanadType.DisplayMember = "Name";
            this.cmbSellSanadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSellSanadType.FormattingEnabled = true;
            this.cmbSellSanadType.Location = new System.Drawing.Point(6, 4);
            this.cmbSellSanadType.Name = "cmbSellSanadType";
            this.cmbSellSanadType.Size = new System.Drawing.Size(119, 28);
            this.cmbSellSanadType.TabIndex = 31;
            this.cmbSellSanadType.ValueMember = "Guid";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(131, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 20);
            this.label24.TabIndex = 32;
            this.label24.Text = "نوع سند";
            // 
            // sanadTypeBindingSource
            // 
            this.sanadTypeBindingSource.DataSource = typeof(EntityCache.Bussines.DocumentTypeBussines);
            // 
            // UcDocumentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbSellSanadType);
            this.Controls.Add(this.label24);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcDocumentType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(185, 36);
            ((System.ComponentModel.ISupportInitialize)(this.sanadTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSellSanadType;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.BindingSource sanadTypeBindingSource;
    }
}
