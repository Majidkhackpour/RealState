
namespace Building.BuildingMatchesItem
{
    partial class frmShowMatchesRequester
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowMatchesRequester));
            this.reqBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSendSms = new System.Windows.Forms.ToolStripMenuItem();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.dgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askerGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.reqBindingSource)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // reqBindingSource
            // 
            this.reqBindingSource.DataSource = typeof(EntityCache.Bussines.BuildingRequestBussines);
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendSms});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(194, 28);
            // 
            // mnuSendSms
            // 
            this.mnuSendSms.Image = global::Building.Properties.Resources.profile;
            this.mnuSendSms.Name = "mnuSendSms";
            this.mnuSendSms.Size = new System.Drawing.Size(193, 24);
            this.mnuSendSms.Text = "ارسال پیامک به متقاضی";
            this.mnuSendSms.Click += new System.EventHandler(this.mnuSendSms_Click);
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
            this.dgName,
            this.dgUserName,
            this.DateSh,
            this.dgDesc,
            this.dgGuid,
            this.askerGuidDataGridViewTextBoxColumn});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            this.DGrid.DataSource = this.reqBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(3, 75);
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
            this.DGrid.Size = new System.Drawing.Size(795, 521);
            this.DGrid.TabIndex = 55761;
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
            this.ucHeader.Location = new System.Drawing.Point(-5, 31);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55762;
            // 
            // dgName
            // 
            this.dgName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgName.DataPropertyName = "AskerName";
            this.dgName.HeaderText = "متقاضی";
            this.dgName.Name = "dgName";
            this.dgName.ReadOnly = true;
            this.dgName.Width = 70;
            // 
            // dgUserName
            // 
            this.dgUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgUserName.DataPropertyName = "UserName";
            this.dgUserName.HeaderText = "مشاور";
            this.dgUserName.Name = "dgUserName";
            this.dgUserName.ReadOnly = true;
            this.dgUserName.Width = 64;
            // 
            // DateSh
            // 
            this.DateSh.DataPropertyName = "DateSh";
            this.DateSh.HeaderText = "تاریخ ثبت تقاضا";
            this.DateSh.Name = "DateSh";
            this.DateSh.ReadOnly = true;
            this.DateSh.Width = 110;
            // 
            // dgDesc
            // 
            this.dgDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgDesc.DataPropertyName = "ShortDesc";
            this.dgDesc.HeaderText = "توضیحات";
            this.dgDesc.Name = "dgDesc";
            this.dgDesc.ReadOnly = true;
            // 
            // dgGuid
            // 
            this.dgGuid.DataPropertyName = "Guid";
            this.dgGuid.HeaderText = "Guid";
            this.dgGuid.Name = "dgGuid";
            this.dgGuid.ReadOnly = true;
            this.dgGuid.Visible = false;
            // 
            // askerGuidDataGridViewTextBoxColumn
            // 
            this.askerGuidDataGridViewTextBoxColumn.DataPropertyName = "AskerGuid";
            this.askerGuidDataGridViewTextBoxColumn.HeaderText = "AskerGuid";
            this.askerGuidDataGridViewTextBoxColumn.Name = "askerGuidDataGridViewTextBoxColumn";
            this.askerGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.askerGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmShowMatchesRequester
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
            this.Name = "frmShowMatchesRequester";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowMatchesRequester_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.reqBindingSource)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource reqBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSendSms;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private WindowsSerivces.UC_Header ucHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn askerGuidDataGridViewTextBoxColumn;
    }
}