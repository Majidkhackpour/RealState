
namespace Building.BuildingMatchesItem
{
    partial class frmShowRequestMatches
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowRequestMatches));
            this.MatchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.buildingCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingAccountTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rahnPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ejarePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBuildingGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucHeader = new WindowsSerivces.UC_Header();
            ((System.ComponentModel.ISupportInitialize)(this.MatchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MatchesBindingSource
            // 
            this.MatchesBindingSource.DataSource = typeof(EntityCache.ViewModels.BuildingRequestViewModel);
            // 
            // DGrid
            // 
            this.DGrid.AllowUserToAddRows = false;
            this.DGrid.AllowUserToDeleteRows = false;
            this.DGrid.AllowUserToResizeColumns = false;
            this.DGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGrid.AutoGenerateColumns = false;
            this.DGrid.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buildingCodeDataGridViewTextBoxColumn,
            this.ownerNameDataGridViewTextBoxColumn,
            this.buildingTypeNameDataGridViewTextBoxColumn,
            this.buildingAccountTypeNameDataGridViewTextBoxColumn,
            this.rahnPriceDataGridViewTextBoxColumn,
            this.ejarePriceDataGridViewTextBoxColumn,
            this.sellPriceDataGridViewTextBoxColumn,
            this.requestCountDataGridViewTextBoxColumn,
            this.dgBuildingGuid});
            this.DGrid.DataSource = this.MatchesBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(3, 64);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(795, 527);
            this.DGrid.TabIndex = 55745;
            // 
            // buildingCodeDataGridViewTextBoxColumn
            // 
            this.buildingCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.buildingCodeDataGridViewTextBoxColumn.DataPropertyName = "BuildingCode";
            this.buildingCodeDataGridViewTextBoxColumn.HeaderText = "کد ملک";
            this.buildingCodeDataGridViewTextBoxColumn.Name = "buildingCodeDataGridViewTextBoxColumn";
            this.buildingCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingCodeDataGridViewTextBoxColumn.Width = 69;
            // 
            // ownerNameDataGridViewTextBoxColumn
            // 
            this.ownerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ownerNameDataGridViewTextBoxColumn.DataPropertyName = "OwnerName";
            this.ownerNameDataGridViewTextBoxColumn.HeaderText = "مالک";
            this.ownerNameDataGridViewTextBoxColumn.Name = "ownerNameDataGridViewTextBoxColumn";
            this.ownerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // buildingTypeNameDataGridViewTextBoxColumn
            // 
            this.buildingTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.buildingTypeNameDataGridViewTextBoxColumn.DataPropertyName = "BuildingTypeName";
            this.buildingTypeNameDataGridViewTextBoxColumn.HeaderText = "نوع ملک";
            this.buildingTypeNameDataGridViewTextBoxColumn.Name = "buildingTypeNameDataGridViewTextBoxColumn";
            this.buildingTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingTypeNameDataGridViewTextBoxColumn.Width = 74;
            // 
            // buildingAccountTypeNameDataGridViewTextBoxColumn
            // 
            this.buildingAccountTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.buildingAccountTypeNameDataGridViewTextBoxColumn.DataPropertyName = "BuildingAccountTypeName";
            this.buildingAccountTypeNameDataGridViewTextBoxColumn.HeaderText = "کاربری";
            this.buildingAccountTypeNameDataGridViewTextBoxColumn.Name = "buildingAccountTypeNameDataGridViewTextBoxColumn";
            this.buildingAccountTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingAccountTypeNameDataGridViewTextBoxColumn.Width = 66;
            // 
            // rahnPriceDataGridViewTextBoxColumn
            // 
            this.rahnPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rahnPriceDataGridViewTextBoxColumn.DataPropertyName = "RahnPrice";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.rahnPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.rahnPriceDataGridViewTextBoxColumn.HeaderText = "رهن";
            this.rahnPriceDataGridViewTextBoxColumn.Name = "rahnPriceDataGridViewTextBoxColumn";
            this.rahnPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.rahnPriceDataGridViewTextBoxColumn.Width = 56;
            // 
            // ejarePriceDataGridViewTextBoxColumn
            // 
            this.ejarePriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ejarePriceDataGridViewTextBoxColumn.DataPropertyName = "EjarePrice";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ejarePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.ejarePriceDataGridViewTextBoxColumn.HeaderText = "اجاره";
            this.ejarePriceDataGridViewTextBoxColumn.Name = "ejarePriceDataGridViewTextBoxColumn";
            this.ejarePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.ejarePriceDataGridViewTextBoxColumn.Width = 59;
            // 
            // sellPriceDataGridViewTextBoxColumn
            // 
            this.sellPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sellPriceDataGridViewTextBoxColumn.DataPropertyName = "SellPrice";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.sellPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.sellPriceDataGridViewTextBoxColumn.HeaderText = "فروش";
            this.sellPriceDataGridViewTextBoxColumn.Name = "sellPriceDataGridViewTextBoxColumn";
            this.sellPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.sellPriceDataGridViewTextBoxColumn.Width = 66;
            // 
            // requestCountDataGridViewTextBoxColumn
            // 
            this.requestCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.requestCountDataGridViewTextBoxColumn.DataPropertyName = "RequestCount";
            this.requestCountDataGridViewTextBoxColumn.HeaderText = "تعداد درخواست";
            this.requestCountDataGridViewTextBoxColumn.Name = "requestCountDataGridViewTextBoxColumn";
            this.requestCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.requestCountDataGridViewTextBoxColumn.Width = 112;
            // 
            // dgBuildingGuid
            // 
            this.dgBuildingGuid.DataPropertyName = "BuildingGuid";
            this.dgBuildingGuid.HeaderText = "BuildingGuid";
            this.dgBuildingGuid.Name = "dgBuildingGuid";
            this.dgBuildingGuid.ReadOnly = true;
            this.dgBuildingGuid.Visible = false;
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
            this.ucHeader.Location = new System.Drawing.Point(-7, 24);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55763;
            // 
            // frmShowRequestMatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowRequestMatches";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowRequestMatches_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowRequestMatches_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MatchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource MatchesBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingAccountTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rahnPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ejarePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBuildingGuid;
        private WindowsSerivces.UC_Header ucHeader;
    }
}