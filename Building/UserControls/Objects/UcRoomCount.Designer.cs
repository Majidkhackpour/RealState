
namespace Building.UserControls.Objects
{
    partial class UcRoomCount
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
            this.label52 = new System.Windows.Forms.Label();
            this.cmbRoomCount = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Location = new System.Drawing.Point(168, 7);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(87, 20);
            this.label52.TabIndex = 55756;
            this.label52.Text = "تعداد اتاق خواب";
            // 
            // cmbRoomCount
            // 
            this.cmbRoomCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbRoomCount.DisplayMember = "Name";
            this.cmbRoomCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoomCount.FormattingEnabled = true;
            this.cmbRoomCount.Items.AddRange(new object[] {
            "بدون خواب",
            "یک خوابه",
            "دو خوابه",
            "سه خوابه",
            "چهار خوابه",
            "پنج خوابه",
            "شش خوابه",
            "هفت خوابه",
            "هشت خوابه",
            "نه خوابه",
            "ده خوابه"});
            this.cmbRoomCount.Location = new System.Drawing.Point(5, 4);
            this.cmbRoomCount.Name = "cmbRoomCount";
            this.cmbRoomCount.Size = new System.Drawing.Size(157, 28);
            this.cmbRoomCount.TabIndex = 55757;
            this.cmbRoomCount.ValueMember = "Guid";
            // 
            // UcRoomCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbRoomCount);
            this.Controls.Add(this.label52);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcRoomCount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(259, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox cmbRoomCount;
    }
}
