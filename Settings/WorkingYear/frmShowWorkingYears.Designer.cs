namespace Settings.WorkingYear
{
    partial class frmShowWorkingYears
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowWorkingYears));
            this.label1 = new System.Windows.Forms.Label();
            this.workingYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnCreate = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnRestore = new DevComponents.DotNetBar.ButtonX();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.cmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.workingYearBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Yekan", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(169, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "انتخاب واحد اقتصادی";
            // 
            // workingYearBindingSource
            // 
            this.workingYearBindingSource.DataSource = typeof(Settings.WorkingYear.WorkingYear);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSelect.Location = new System.Drawing.Point(97, 111);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSelect.Size = new System.Drawing.Size(330, 31);
            this.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.TextColor = System.Drawing.Color.White;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreate.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCreate.Location = new System.Drawing.Point(97, 148);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCreate.Size = new System.Drawing.Size(330, 31);
            this.btnCreate.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "ایجاد واحد اقتصادی جدید";
            this.btnCreate.TextColor = System.Drawing.Color.White;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEdit.Location = new System.Drawing.Point(97, 185);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnEdit.Size = new System.Drawing.Size(330, 31);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "ویرایش واحد اقتصادی جاری";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.Location = new System.Drawing.Point(97, 222);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelete.Size = new System.Drawing.Size(330, 31);
            this.btnDelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "حذف واحد اقتصادی جاری";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRestore.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRestore.Location = new System.Drawing.Point(97, 259);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRestore.Size = new System.Drawing.Size(330, 31);
            this.btnRestore.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "بازگردانی اطلاعات";
            this.btnRestore.TextColor = System.Drawing.Color.White;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Enabled = false;
            this.txtConnectionString.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtConnectionString.Location = new System.Drawing.Point(4, 316);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.ReadOnly = true;
            this.txtConnectionString.Size = new System.Drawing.Size(533, 24);
            this.txtConnectionString.TabIndex = 55720;
            // 
            // cmb
            // 
            this.cmb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb.DataSource = this.workingYearBindingSource;
            this.cmb.DisplayMember = "DbName";
            this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb.FormattingEnabled = true;
            this.cmb.Location = new System.Drawing.Point(97, 77);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(330, 28);
            this.cmb.TabIndex = 55721;
            this.cmb.ValueMember = "Guid";
            this.cmb.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
            // 
            // frmShowWorkingYears
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 352);
            this.ControlBox = false;
            this.Controls.Add(this.cmb);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 352);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 352);
            this.Name = "frmShowWorkingYears";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmShowWorkingYears_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowWorkingYears_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.workingYearBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnCreate;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private System.Windows.Forms.BindingSource workingYearBindingSource;
        private DevComponents.DotNetBar.ButtonX btnRestore;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.ComboBox cmb;
    }
}