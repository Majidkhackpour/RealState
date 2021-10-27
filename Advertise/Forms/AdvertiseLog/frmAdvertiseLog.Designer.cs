
namespace Advertise.Forms.AdvertiseLog
{
    partial class frmAdvertiseLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvertiseLog));
            this.LogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dateShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uRLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategory1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategory2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.LogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LogBindingSource
            // 
            this.LogBindingSource.DataSource = typeof(EntityCache.Bussines.AdvertiseLogBussines);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.Location = new System.Drawing.Point(48, 12);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(701, 27);
            this.txtSearch.TabIndex = 55747;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            this.dateShDataGridViewTextBoxColumn,
            this.dgNumber,
            this.fullCategoryDataGridViewTextBoxColumn,
            this.regionDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.contentDataGridViewTextBoxColumn,
            this.uRLDataGridViewTextBoxColumn,
            this.guidDataGridViewTextBoxColumn,
            this.dateMDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.subCategory1DataGridViewTextBoxColumn,
            this.subCategory2DataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.price1DataGridViewTextBoxColumn,
            this.price2DataGridViewTextBoxColumn,
            this.updateDescDataGridViewTextBoxColumn,
            this.statusCodeDataGridViewTextBoxColumn,
            this.iPDataGridViewTextBoxColumn,
            this.lastUpdateDataGridViewTextBoxColumn,
            this.visitCountDataGridViewTextBoxColumn,
            this.advTypeDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.imageListDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.LogBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(6, 47);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(786, 549);
            this.DGrid.TabIndex = 55746;
            // 
            // dateShDataGridViewTextBoxColumn
            // 
            this.dateShDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateShDataGridViewTextBoxColumn.DataPropertyName = "DateSh";
            this.dateShDataGridViewTextBoxColumn.HeaderText = "تاریخ";
            this.dateShDataGridViewTextBoxColumn.Name = "dateShDataGridViewTextBoxColumn";
            this.dateShDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateShDataGridViewTextBoxColumn.Width = 58;
            // 
            // dgNumber
            // 
            this.dgNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgNumber.DataPropertyName = "SimcardNumber";
            this.dgNumber.HeaderText = "شماره";
            this.dgNumber.Name = "dgNumber";
            this.dgNumber.ReadOnly = true;
            this.dgNumber.Width = 63;
            // 
            // fullCategoryDataGridViewTextBoxColumn
            // 
            this.fullCategoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fullCategoryDataGridViewTextBoxColumn.DataPropertyName = "FullCategory";
            this.fullCategoryDataGridViewTextBoxColumn.HeaderText = "دسته بندی";
            this.fullCategoryDataGridViewTextBoxColumn.Name = "fullCategoryDataGridViewTextBoxColumn";
            this.fullCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullCategoryDataGridViewTextBoxColumn.Width = 87;
            // 
            // regionDataGridViewTextBoxColumn
            // 
            this.regionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.regionDataGridViewTextBoxColumn.DataPropertyName = "Region";
            this.regionDataGridViewTextBoxColumn.HeaderText = "محدوده";
            this.regionDataGridViewTextBoxColumn.Name = "regionDataGridViewTextBoxColumn";
            this.regionDataGridViewTextBoxColumn.ReadOnly = true;
            this.regionDataGridViewTextBoxColumn.Width = 70;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "عنوان آگهی";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 87;
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            this.contentDataGridViewTextBoxColumn.HeaderText = "شرح";
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uRLDataGridViewTextBoxColumn
            // 
            this.uRLDataGridViewTextBoxColumn.DataPropertyName = "URL";
            this.uRLDataGridViewTextBoxColumn.HeaderText = "آدرس";
            this.uRLDataGridViewTextBoxColumn.Name = "uRLDataGridViewTextBoxColumn";
            this.uRLDataGridViewTextBoxColumn.ReadOnly = true;
            this.uRLDataGridViewTextBoxColumn.Visible = false;
            this.uRLDataGridViewTextBoxColumn.Width = 64;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            this.guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            this.guidDataGridViewTextBoxColumn.HeaderText = "Guid";
            this.guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            this.guidDataGridViewTextBoxColumn.ReadOnly = true;
            this.guidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateMDataGridViewTextBoxColumn
            // 
            this.dateMDataGridViewTextBoxColumn.DataPropertyName = "DateM";
            this.dateMDataGridViewTextBoxColumn.HeaderText = "DateM";
            this.dateMDataGridViewTextBoxColumn.Name = "dateMDataGridViewTextBoxColumn";
            this.dateMDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateMDataGridViewTextBoxColumn.Visible = false;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Visible = false;
            // 
            // subCategory1DataGridViewTextBoxColumn
            // 
            this.subCategory1DataGridViewTextBoxColumn.DataPropertyName = "SubCategory1";
            this.subCategory1DataGridViewTextBoxColumn.HeaderText = "SubCategory1";
            this.subCategory1DataGridViewTextBoxColumn.Name = "subCategory1DataGridViewTextBoxColumn";
            this.subCategory1DataGridViewTextBoxColumn.ReadOnly = true;
            this.subCategory1DataGridViewTextBoxColumn.Visible = false;
            // 
            // subCategory2DataGridViewTextBoxColumn
            // 
            this.subCategory2DataGridViewTextBoxColumn.DataPropertyName = "SubCategory2";
            this.subCategory2DataGridViewTextBoxColumn.HeaderText = "SubCategory2";
            this.subCategory2DataGridViewTextBoxColumn.Name = "subCategory2DataGridViewTextBoxColumn";
            this.subCategory2DataGridViewTextBoxColumn.ReadOnly = true;
            this.subCategory2DataGridViewTextBoxColumn.Visible = false;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            this.cityDataGridViewTextBoxColumn.Visible = false;
            // 
            // price1DataGridViewTextBoxColumn
            // 
            this.price1DataGridViewTextBoxColumn.DataPropertyName = "Price1";
            this.price1DataGridViewTextBoxColumn.HeaderText = "Price1";
            this.price1DataGridViewTextBoxColumn.Name = "price1DataGridViewTextBoxColumn";
            this.price1DataGridViewTextBoxColumn.ReadOnly = true;
            this.price1DataGridViewTextBoxColumn.Visible = false;
            // 
            // price2DataGridViewTextBoxColumn
            // 
            this.price2DataGridViewTextBoxColumn.DataPropertyName = "Price2";
            this.price2DataGridViewTextBoxColumn.HeaderText = "Price2";
            this.price2DataGridViewTextBoxColumn.Name = "price2DataGridViewTextBoxColumn";
            this.price2DataGridViewTextBoxColumn.ReadOnly = true;
            this.price2DataGridViewTextBoxColumn.Visible = false;
            // 
            // updateDescDataGridViewTextBoxColumn
            // 
            this.updateDescDataGridViewTextBoxColumn.DataPropertyName = "UpdateDesc";
            this.updateDescDataGridViewTextBoxColumn.HeaderText = "UpdateDesc";
            this.updateDescDataGridViewTextBoxColumn.Name = "updateDescDataGridViewTextBoxColumn";
            this.updateDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateDescDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusCodeDataGridViewTextBoxColumn
            // 
            this.statusCodeDataGridViewTextBoxColumn.DataPropertyName = "StatusCode";
            this.statusCodeDataGridViewTextBoxColumn.HeaderText = "StatusCode";
            this.statusCodeDataGridViewTextBoxColumn.Name = "statusCodeDataGridViewTextBoxColumn";
            this.statusCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // iPDataGridViewTextBoxColumn
            // 
            this.iPDataGridViewTextBoxColumn.DataPropertyName = "IP";
            this.iPDataGridViewTextBoxColumn.HeaderText = "IP";
            this.iPDataGridViewTextBoxColumn.Name = "iPDataGridViewTextBoxColumn";
            this.iPDataGridViewTextBoxColumn.ReadOnly = true;
            this.iPDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastUpdateDataGridViewTextBoxColumn
            // 
            this.lastUpdateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn.HeaderText = "LastUpdate";
            this.lastUpdateDataGridViewTextBoxColumn.Name = "lastUpdateDataGridViewTextBoxColumn";
            this.lastUpdateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdateDataGridViewTextBoxColumn.Visible = false;
            // 
            // visitCountDataGridViewTextBoxColumn
            // 
            this.visitCountDataGridViewTextBoxColumn.DataPropertyName = "VisitCount";
            this.visitCountDataGridViewTextBoxColumn.HeaderText = "VisitCount";
            this.visitCountDataGridViewTextBoxColumn.Name = "visitCountDataGridViewTextBoxColumn";
            this.visitCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.visitCountDataGridViewTextBoxColumn.Visible = false;
            // 
            // advTypeDataGridViewTextBoxColumn
            // 
            this.advTypeDataGridViewTextBoxColumn.DataPropertyName = "AdvType";
            this.advTypeDataGridViewTextBoxColumn.HeaderText = "AdvType";
            this.advTypeDataGridViewTextBoxColumn.Name = "advTypeDataGridViewTextBoxColumn";
            this.advTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.advTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateDataGridViewTextBoxColumn.Visible = false;
            // 
            // imageListDataGridViewTextBoxColumn
            // 
            this.imageListDataGridViewTextBoxColumn.DataPropertyName = "ImageList";
            this.imageListDataGridViewTextBoxColumn.HeaderText = "ImageList";
            this.imageListDataGridViewTextBoxColumn.Name = "imageListDataGridViewTextBoxColumn";
            this.imageListDataGridViewTextBoxColumn.ReadOnly = true;
            this.imageListDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmAdvertiseLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmAdvertiseLog";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAdvertiseLog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAdvertiseLog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.LogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource LogBindingSource;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uRLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategory1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategory2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn advTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageListDataGridViewTextBoxColumn;
    }
}