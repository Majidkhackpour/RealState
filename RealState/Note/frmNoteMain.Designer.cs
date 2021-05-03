namespace RealState.Note
{
    partial class frmNoteMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNoteMain));
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblUsers = new System.Windows.Forms.Label();
            this.txtSarresid = new BPersianCalender.BPersianCalenderTextBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbSarresid = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSarresid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.cmbUsers);
            this.grp.Controls.Add(this.lblUsers);
            this.grp.Controls.Add(this.txtSarresid);
            this.grp.Controls.Add(this.cmbPriority);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.chbSarresid);
            this.grp.Controls.Add(this.txtDescription);
            this.grp.Controls.Add(this.txtTitle);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.lblSarresid);
            this.grp.Controls.Add(this.label2);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(5, 18);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(790, 418);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grp.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 0;
            // 
            // cmbUsers
            // 
            this.cmbUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbUsers.DataSource = this.userBindingSource;
            this.cmbUsers.DisplayMember = "Name";
            this.cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(25, 60);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(205, 28);
            this.cmbUsers.TabIndex = 3;
            this.cmbUsers.ValueMember = "Guid";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(EntityCache.Bussines.UserBussines);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.BackColor = System.Drawing.Color.Transparent;
            this.lblUsers.Location = new System.Drawing.Point(236, 63);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(116, 20);
            this.lblUsers.TabIndex = 55718;
            this.lblUsers.Text = "افزودن یادداشت برای";
            // 
            // txtSarresid
            // 
            this.txtSarresid.Location = new System.Drawing.Point(25, 16);
            this.txtSarresid.Miladi = new System.DateTime(((long)(0)));
            this.txtSarresid.Name = "txtSarresid";
            this.txtSarresid.NowDateSelected = false;
            this.txtSarresid.ReadOnly = true;
            this.txtSarresid.SelectedDate = null;
            this.txtSarresid.Shamsi = null;
            this.txtSarresid.Size = new System.Drawing.Size(205, 27);
            this.txtSarresid.TabIndex = 1;
            // 
            // cmbPriority
            // 
            this.cmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriority.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(509, 60);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(200, 28);
            this.cmbPriority.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(726, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.TabIndex = 55716;
            this.label5.Text = "اولویت";
            // 
            // chbSarresid
            // 
            this.chbSarresid.AutoSize = true;
            this.chbSarresid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbSarresid.Location = new System.Drawing.Point(509, 18);
            this.chbSarresid.Name = "chbSarresid";
            this.chbSarresid.Size = new System.Drawing.Size(200, 24);
            this.chbSarresid.TabIndex = 0;
            this.chbSarresid.Text = "این یادداشت، سررسید دار می باشد";
            this.chbSarresid.UseVisualStyleBackColor = true;
            this.chbSarresid.CheckedChanged += new System.EventHandler(this.chbSarresid_CheckedChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(25, 152);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(684, 249);
            this.txtDescription.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(25, 107);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(684, 27);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.txtTitle_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(732, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "عنوان";
            // 
            // lblSarresid
            // 
            this.lblSarresid.AutoSize = true;
            this.lblSarresid.BackColor = System.Drawing.Color.Transparent;
            this.lblSarresid.Location = new System.Drawing.Point(236, 19);
            this.lblSarresid.Name = "lblSarresid";
            this.lblSarresid.Size = new System.Drawing.Size(78, 20);
            this.lblSarresid.TabIndex = 5;
            this.lblSarresid.Text = "تاریخ سررسید";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(715, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "توضیحات";
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::RealState.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(645, 455);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 1;
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
            this.btnCancel.Image = global::RealState.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(30, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmNoteMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.ControlBox = false;
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 498);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 498);
            this.Name = "frmNoteMain";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmNoteMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNoteMain_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label lblUsers;
        private BPersianCalender.BPersianCalenderTextBox txtSarresid;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbSarresid;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSarresid;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.BindingSource userBindingSource;
    }
}