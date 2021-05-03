
namespace Accounting.Sood_Zian
{
    partial class frmFilterSood_Zian
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterSood_Zian));
            this.txtDate1 = new BPersianCalender.BPersianCalenderTextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.txtDate2 = new BPersianCalender.BPersianCalenderTextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // txtDate1
            // 
            this.txtDate1.Location = new System.Drawing.Point(285, 35);
            this.txtDate1.Miladi = new System.DateTime(2020, 10, 23, 15, 57, 17, 0);
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.NowDateSelected = false;
            this.txtDate1.ReadOnly = true;
            this.txtDate1.SelectedDate = null;
            this.txtDate1.Shamsi = null;
            this.txtDate1.Size = new System.Drawing.Size(211, 27);
            this.txtDate1.TabIndex = 61;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.BackColor = System.Drawing.Color.Transparent;
            this.label86.Location = new System.Drawing.Point(502, 38);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(128, 20);
            this.label86.TabIndex = 62;
            this.label86.Text = "مشاهده ترازنامه از تاریخ";
            // 
            // txtDate2
            // 
            this.txtDate2.Location = new System.Drawing.Point(8, 35);
            this.txtDate2.Miladi = new System.DateTime(2020, 10, 1, 0, 0, 0, 0);
            this.txtDate2.Name = "txtDate2";
            this.txtDate2.NowDateSelected = false;
            this.txtDate2.ReadOnly = true;
            this.txtDate2.SelectedDate = null;
            this.txtDate2.Shamsi = null;
            this.txtDate2.Size = new System.Drawing.Size(211, 27);
            this.txtDate2.TabIndex = 65;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.BackColor = System.Drawing.Color.Transparent;
            this.label84.Location = new System.Drawing.Point(247, 38);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(24, 20);
            this.label84.TabIndex = 66;
            this.label84.Text = "الی";
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Accounting.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(285, 68);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(211, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 67;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Accounting.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(8, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(211, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmFilterSood_Zian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 111);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtDate2);
            this.Controls.Add(this.label84);
            this.Controls.Add(this.txtDate1);
            this.Controls.Add(this.label86);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFilterSood_Zian";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmFilterSood_Zian_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFilterSood_Zian_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BPersianCalender.BPersianCalenderTextBox txtDate1;
        private System.Windows.Forms.Label label86;
        private BPersianCalender.BPersianCalenderTextBox txtDate2;
        private System.Windows.Forms.Label label84;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}