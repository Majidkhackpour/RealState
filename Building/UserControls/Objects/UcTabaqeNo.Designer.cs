
namespace Building.UserControls.Objects
{
    partial class UcTabaqeNo
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
            this.label58 = new System.Windows.Forms.Label();
            this.cmbTabaqeNo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label58
            // 
            this.label58.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label58.AutoSize = true;
            this.label58.BackColor = System.Drawing.Color.Transparent;
            this.label58.Location = new System.Drawing.Point(128, 8);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(63, 20);
            this.label58.TabIndex = 55758;
            this.label58.Text = "شماره طبقه";
            // 
            // cmbTabaqeNo
            // 
            this.cmbTabaqeNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbTabaqeNo.DisplayMember = "Name";
            this.cmbTabaqeNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTabaqeNo.FormattingEnabled = true;
            this.cmbTabaqeNo.Items.AddRange(new object[] {
            "-3",
            "-2",
            "-1",
            "همکف",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.cmbTabaqeNo.Location = new System.Drawing.Point(5, 5);
            this.cmbTabaqeNo.Name = "cmbTabaqeNo";
            this.cmbTabaqeNo.Size = new System.Drawing.Size(119, 28);
            this.cmbTabaqeNo.TabIndex = 55759;
            this.cmbTabaqeNo.ValueMember = "Guid";
            // 
            // UcTabaqeNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmbTabaqeNo);
            this.Controls.Add(this.label58);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcTabaqeNo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(193, 36);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.ComboBox cmbTabaqeNo;
    }
}
