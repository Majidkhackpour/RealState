namespace Peoples
{
    partial class frmPropleGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPropleGroup));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.GroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Peoples.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(30, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Peoples.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(330, 177);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 7;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // grp
            // 
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.cmbGroup);
            this.grp.Controls.Add(this.txtName);
            this.grp.Controls.Add(this.label5);
            this.grp.Controls.Add(this.label7);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(8, 69);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(463, 94);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grp.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 6;
            // 
            // cmbGroup
            // 
            this.cmbGroup.DataSource = this.GroupBindingSource;
            this.cmbGroup.DisplayMember = "Name";
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(22, 16);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(330, 28);
            this.cmbGroup.TabIndex = 0;
            this.cmbGroup.ValueMember = "Guid";
            // 
            // GroupBindingSource
            // 
            this.GroupBindingSource.DataSource = typeof(EntityCache.Bussines.PeopleGroupBussines);
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Location = new System.Drawing.Point(22, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(330, 27);
            this.txtName.TabIndex = 1;
            this.txtName.Enter += new System.EventHandler(this.txtCity_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtCity_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(397, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "گروه والد";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(389, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "عنوان گروه";
            // 
            // ucHeader
            // 
            this.ucHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ucHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucHeader.BackColor = System.Drawing.Color.White;
            this.ucHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ucHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucHeader.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucHeader.IsModified = false;
            this.ucHeader.Location = new System.Drawing.Point(-2, 27);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(482, 34);
            this.ucHeader.TabIndex = 12;
            // 
            // frmPropleGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 226);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.grp);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(479, 226);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(479, 226);
            this.Name = "frmPropleGroup";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmPropleGroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPropleGroup_KeyDown);
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.PanelEx grp;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.BindingSource GroupBindingSource;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private WindowsSerivces.UC_Header ucHeader;
    }
}