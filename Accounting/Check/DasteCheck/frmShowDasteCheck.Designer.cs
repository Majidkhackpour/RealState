
namespace Accounting.Check.DasteCheck
{
    partial class frmShowDasteCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowDasteCheck));
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.mnuShowPages = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.DasteCheckBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bankGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DasteCheckBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.txtSearch.Location = new System.Drawing.Point(149, 25);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PreventEnterBeep = true;
            this.txtSearch.Size = new System.Drawing.Size(476, 27);
            this.txtSearch.TabIndex = 55754;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkText = "مورد جستجو را وارد نمایید ...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // mnuShowPages
            // 
            this.mnuShowPages.Image = global::Accounting.Properties.Resources.article_1_;
            this.mnuShowPages.Name = "mnuShowPages";
            this.mnuShowPages.Size = new System.Drawing.Size(224, 24);
            this.mnuShowPages.Text = "مشاهده برگه ها";
            this.mnuShowPages.Click += new System.EventHandler(this.mnuShowPages_Click);
            // 
            // mnuStatus
            // 
            this.mnuStatus.Image = global::Accounting.Properties.Resources.refresh_round_symbol;
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.Size = new System.Drawing.Size(224, 24);
            this.mnuStatus.Text = "غیرفعال (Ctrl+S)";
            this.mnuStatus.Click += new System.EventHandler(this.mnuStatus_Click);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Accounting.Properties.Resources.article_1_;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(224, 24);
            this.mnuView.Text = "مشاهده (F12)";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Accounting.Properties.Resources.delete_1_;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(224, 24);
            this.mnuDelete.Text = "حذف دسته چک جاری (Del)";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Accounting.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(224, 24);
            this.mnuEdit.Text = "ویرایش دسته چک جاری (F7)";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(224, 24);
            this.mnuAdd.Text = "افزودن دسته چک جدید (Ins)";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuEdit,
            this.mnuDelete,
            this.toolStripMenuItem1,
            this.mnuView,
            this.mnuStatus,
            this.toolStripMenuItem2,
            this.mnuShowPages});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(225, 182);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(221, 6);
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
            this.dgRadif,
            this.dgName,
            this.serialNumberDataGridViewTextBoxColumn,
            this.fromNumberDataGridViewTextBoxColumn,
            this.toNumberDataGridViewTextBoxColumn,
            this.pageCountDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.dgGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.bankGuidDataGridViewTextBoxColumn});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            this.DGrid.DataSource = this.DasteCheckBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(3, 65);
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
            this.DGrid.Size = new System.Drawing.Size(793, 528);
            this.DGrid.TabIndex = 55755;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // DasteCheckBindingSource
            // 
            this.DasteCheckBindingSource.DataSource = typeof(EntityCache.Bussines.DasteCheckBussines);
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 40;
            // 
            // dgName
            // 
            this.dgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgName.DataPropertyName = "BankName";
            this.dgName.HeaderText = "بانک";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            this.dgName.Width = 56;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            this.serialNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.serialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber";
            this.serialNumberDataGridViewTextBoxColumn.HeaderText = "سریال دسته چک";
            this.serialNumberDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            this.serialNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.serialNumberDataGridViewTextBoxColumn.Width = 120;
            // 
            // fromNumberDataGridViewTextBoxColumn
            // 
            this.fromNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fromNumberDataGridViewTextBoxColumn.DataPropertyName = "FromNumber";
            this.fromNumberDataGridViewTextBoxColumn.HeaderText = "از شماره";
            this.fromNumberDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.fromNumberDataGridViewTextBoxColumn.Name = "fromNumberDataGridViewTextBoxColumn";
            this.fromNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.fromNumberDataGridViewTextBoxColumn.Width = 76;
            // 
            // toNumberDataGridViewTextBoxColumn
            // 
            this.toNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.toNumberDataGridViewTextBoxColumn.DataPropertyName = "ToNumber";
            this.toNumberDataGridViewTextBoxColumn.HeaderText = "تا شماره";
            this.toNumberDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.toNumberDataGridViewTextBoxColumn.Name = "toNumberDataGridViewTextBoxColumn";
            this.toNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.toNumberDataGridViewTextBoxColumn.Width = 73;
            // 
            // pageCountDataGridViewTextBoxColumn
            // 
            this.pageCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pageCountDataGridViewTextBoxColumn.DataPropertyName = "PageCount";
            this.pageCountDataGridViewTextBoxColumn.HeaderText = "تعداد برگه";
            this.pageCountDataGridViewTextBoxColumn.MinimumWidth = 60;
            this.pageCountDataGridViewTextBoxColumn.Name = "pageCountDataGridViewTextBoxColumn";
            this.pageCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.pageCountDataGridViewTextBoxColumn.Width = 85;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "شرح";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgGuid
            // 
            this.dgGuid.DataPropertyName = "Guid";
            this.dgGuid.HeaderText = "Guid";
            this.dgGuid.Name = "dgGuid";
            this.dgGuid.ReadOnly = true;
            this.dgGuid.Visible = false;
            // 
            // modifiedDataGridViewTextBoxColumn
            // 
            this.modifiedDataGridViewTextBoxColumn.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn.Name = "modifiedDataGridViewTextBoxColumn";
            this.modifiedDataGridViewTextBoxColumn.ReadOnly = true;
            this.modifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            this.statusDataGridViewCheckBoxColumn.ReadOnly = true;
            this.statusDataGridViewCheckBoxColumn.Visible = false;
            // 
            // bankGuidDataGridViewTextBoxColumn
            // 
            this.bankGuidDataGridViewTextBoxColumn.DataPropertyName = "BankGuid";
            this.bankGuidDataGridViewTextBoxColumn.HeaderText = "BankGuid";
            this.bankGuidDataGridViewTextBoxColumn.Name = "bankGuidDataGridViewTextBoxColumn";
            this.bankGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.bankGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmShowDasteCheck
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
            this.Name = "frmShowDasteCheck";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowDasteCheck_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowDasteCheck_KeyDown);
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DasteCheckBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource DasteCheckBindingSource;
        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuShowPages;
        private System.Windows.Forms.ToolStripMenuItem mnuStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pageCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankGuidDataGridViewTextBoxColumn;
    }
}