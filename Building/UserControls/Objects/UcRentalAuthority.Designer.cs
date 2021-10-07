
namespace Building.UserControls.Objects
{
    partial class UcRentalAuthority
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
            this.rentalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbRentalAuthority = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rentalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rentalBindingSource
            // 
            this.rentalBindingSource.DataSource = typeof(EntityCache.Bussines.RentalAuthorityBussines);
            // 
            // cmbRentalAuthority
            // 
            this.cmbRentalAuthority.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbRentalAuthority.DataSource = this.rentalBindingSource;
            this.cmbRentalAuthority.DisplayMember = "Name";
            this.cmbRentalAuthority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRentalAuthority.FormattingEnabled = true;
            this.cmbRentalAuthority.Location = new System.Drawing.Point(3, 3);
            this.cmbRentalAuthority.Name = "cmbRentalAuthority";
            this.cmbRentalAuthority.Size = new System.Drawing.Size(119, 28);
            this.cmbRentalAuthority.TabIndex = 15;
            this.cmbRentalAuthority.ValueMember = "Guid";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(130, 7);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 20);
            this.label19.TabIndex = 16;
            this.label19.Text = "ارجحیت اجاره";
            // 
            // UcRentalAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbRentalAuthority);
            this.Controls.Add(this.label19);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcRentalAuthority";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(214, 36);
            ((System.ComponentModel.ISupportInitialize)(this.rentalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource rentalBindingSource;
        private System.Windows.Forms.ComboBox cmbRentalAuthority;
        private System.Windows.Forms.Label label19;
    }
}
