
namespace Building.UserControls
{
    partial class UcBuildingMedia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MediaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DgridMedia = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.mediaNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnRemoveMedia = new DevComponents.DotNetBar.ButtonX();
            this.btnAddMedia = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.MediaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgridMedia)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MediaBindingSource
            // 
            this.MediaBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingMediaBussines);
            // 
            // DgridMedia
            // 
            this.DgridMedia.AllowUserToAddRows = false;
            this.DgridMedia.AllowUserToDeleteRows = false;
            this.DgridMedia.AllowUserToResizeColumns = false;
            this.DgridMedia.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgridMedia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgridMedia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DgridMedia.AutoGenerateColumns = false;
            this.DgridMedia.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridMedia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgridMedia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgridMedia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mediaNameDataGridViewTextBoxColumn,
            this.guidDataGridViewTextBoxColumn,
            this.buildingGuidDataGridViewTextBoxColumn});
            this.DgridMedia.DataSource = this.MediaBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgridMedia.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgridMedia.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DgridMedia.Location = new System.Drawing.Point(3, 4);
            this.DgridMedia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DgridMedia.Name = "DgridMedia";
            this.DgridMedia.ReadOnly = true;
            this.DgridMedia.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DgridMedia.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgridMedia.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgridMedia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DgridMedia.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgridMedia.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DgridMedia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgridMedia.Size = new System.Drawing.Size(317, 254);
            this.DgridMedia.TabIndex = 55746;
            // 
            // mediaNameDataGridViewTextBoxColumn
            // 
            this.mediaNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mediaNameDataGridViewTextBoxColumn.DataPropertyName = "MediaName";
            this.mediaNameDataGridViewTextBoxColumn.HeaderText = "نام فایل";
            this.mediaNameDataGridViewTextBoxColumn.Name = "mediaNameDataGridViewTextBoxColumn";
            this.mediaNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            this.guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            this.guidDataGridViewTextBoxColumn.HeaderText = "Guid";
            this.guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            this.guidDataGridViewTextBoxColumn.ReadOnly = true;
            this.guidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buildingGuidDataGridViewTextBoxColumn
            // 
            this.buildingGuidDataGridViewTextBoxColumn.DataPropertyName = "BuildingGuid";
            this.buildingGuidDataGridViewTextBoxColumn.HeaderText = "BuildingGuid";
            this.buildingGuidDataGridViewTextBoxColumn.Name = "buildingGuidDataGridViewTextBoxColumn";
            this.buildingGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnRemoveMedia);
            this.groupPanel1.Controls.Add(this.btnAddMedia);
            this.groupPanel1.Controls.Add(this.DgridMedia);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(329, 350);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 2;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 2;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 2;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 2;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 55747;
            this.groupPanel1.Text = "ویدئو";
            // 
            // btnRemoveMedia
            // 
            this.btnRemoveMedia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemoveMedia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveMedia.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRemoveMedia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRemoveMedia.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnRemoveMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveMedia.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRemoveMedia.Location = new System.Drawing.Point(81, 294);
            this.btnRemoveMedia.Name = "btnRemoveMedia";
            this.btnRemoveMedia.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnRemoveMedia.Size = new System.Drawing.Size(150, 27);
            this.btnRemoveMedia.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnRemoveMedia.TabIndex = 55747;
            this.btnRemoveMedia.Text = "حذف ویدئوی انتخاب شده";
            this.btnRemoveMedia.TextColor = System.Drawing.Color.White;
            this.btnRemoveMedia.Click += new System.EventHandler(this.btnRemoveMedia_Click);
            // 
            // btnAddMedia
            // 
            this.btnAddMedia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddMedia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMedia.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAddMedia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddMedia.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnAddMedia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMedia.Font = new System.Drawing.Font("B Yekan", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAddMedia.Location = new System.Drawing.Point(81, 265);
            this.btnAddMedia.Name = "btnAddMedia";
            this.btnAddMedia.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnAddMedia.Size = new System.Drawing.Size(150, 27);
            this.btnAddMedia.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnAddMedia.TabIndex = 55748;
            this.btnAddMedia.Text = "افزودن ویدئو(های) جدید";
            this.btnAddMedia.TextColor = System.Drawing.Color.White;
            this.btnAddMedia.Click += new System.EventHandler(this.btnAddMedia_Click);
            // 
            // UcBuildingMedia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingMedia";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(329, 350);
            ((System.ComponentModel.ISupportInitialize)(this.MediaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgridMedia)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource MediaBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DgridMedia;
        private System.Windows.Forms.DataGridViewTextBoxColumn mediaNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingGuidDataGridViewTextBoxColumn;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnRemoveMedia;
        private DevComponents.DotNetBar.ButtonX btnAddMedia;
    }
}
