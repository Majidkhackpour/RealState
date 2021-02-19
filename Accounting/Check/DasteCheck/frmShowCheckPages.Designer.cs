
namespace Accounting.Check.DasteCheck
{
    partial class frmShowCheckPages
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowCheckPages));
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.datePardakhtShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receptorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSarresidShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datePardakhtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receptorGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSarresidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckPagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.lblBankName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPagesBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.datePardakhtShDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.StatusName,
            this.receptorNameDataGridViewTextBoxColumn,
            this.dateSarresidShDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.guidDataGridViewTextBoxColumn,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.checkGuidDataGridViewTextBoxColumn,
            this.datePardakhtDataGridViewTextBoxColumn,
            this.receptorGuidDataGridViewTextBoxColumn,
            this.dateSarresidDataGridViewTextBoxColumn,
            this.checkStatusDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.CheckPagesBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(3, 65);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(793, 528);
            this.DGrid.TabIndex = 55757;
            // 
            // datePardakhtShDataGridViewTextBoxColumn
            // 
            this.datePardakhtShDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datePardakhtShDataGridViewTextBoxColumn.DataPropertyName = "DatePardakhtSh";
            this.datePardakhtShDataGridViewTextBoxColumn.HeaderText = "تاریخ صدور";
            this.datePardakhtShDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.datePardakhtShDataGridViewTextBoxColumn.Name = "datePardakhtShDataGridViewTextBoxColumn";
            this.datePardakhtShDataGridViewTextBoxColumn.ReadOnly = true;
            this.datePardakhtShDataGridViewTextBoxColumn.Width = 90;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "شماره چک";
            this.numberDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.Width = 84;
            // 
            // StatusName
            // 
            this.StatusName.DataPropertyName = "StatusName";
            this.StatusName.HeaderText = "وضعیت";
            this.StatusName.MinimumWidth = 50;
            this.StatusName.Name = "StatusName";
            this.StatusName.ReadOnly = true;
            // 
            // receptorNameDataGridViewTextBoxColumn
            // 
            this.receptorNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.receptorNameDataGridViewTextBoxColumn.DataPropertyName = "ReceptorName";
            this.receptorNameDataGridViewTextBoxColumn.HeaderText = "دریافت کننده";
            this.receptorNameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.receptorNameDataGridViewTextBoxColumn.Name = "receptorNameDataGridViewTextBoxColumn";
            this.receptorNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateSarresidShDataGridViewTextBoxColumn
            // 
            this.dateSarresidShDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateSarresidShDataGridViewTextBoxColumn.DataPropertyName = "DateSarresidSh";
            this.dateSarresidShDataGridViewTextBoxColumn.HeaderText = "سررسید";
            this.dateSarresidShDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.dateSarresidShDataGridViewTextBoxColumn.Name = "dateSarresidShDataGridViewTextBoxColumn";
            this.dateSarresidShDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateSarresidShDataGridViewTextBoxColumn.Width = 76;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.priceDataGridViewTextBoxColumn.HeaderText = "مبلغ";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 54;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "شرح چک";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            this.guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            this.guidDataGridViewTextBoxColumn.HeaderText = "Guid";
            this.guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            this.guidDataGridViewTextBoxColumn.ReadOnly = true;
            this.guidDataGridViewTextBoxColumn.Visible = false;
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
            // checkGuidDataGridViewTextBoxColumn
            // 
            this.checkGuidDataGridViewTextBoxColumn.DataPropertyName = "CheckGuid";
            this.checkGuidDataGridViewTextBoxColumn.HeaderText = "CheckGuid";
            this.checkGuidDataGridViewTextBoxColumn.Name = "checkGuidDataGridViewTextBoxColumn";
            this.checkGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // datePardakhtDataGridViewTextBoxColumn
            // 
            this.datePardakhtDataGridViewTextBoxColumn.DataPropertyName = "DatePardakht";
            this.datePardakhtDataGridViewTextBoxColumn.HeaderText = "DatePardakht";
            this.datePardakhtDataGridViewTextBoxColumn.Name = "datePardakhtDataGridViewTextBoxColumn";
            this.datePardakhtDataGridViewTextBoxColumn.ReadOnly = true;
            this.datePardakhtDataGridViewTextBoxColumn.Visible = false;
            // 
            // receptorGuidDataGridViewTextBoxColumn
            // 
            this.receptorGuidDataGridViewTextBoxColumn.DataPropertyName = "ReceptorGuid";
            this.receptorGuidDataGridViewTextBoxColumn.HeaderText = "ReceptorGuid";
            this.receptorGuidDataGridViewTextBoxColumn.Name = "receptorGuidDataGridViewTextBoxColumn";
            this.receptorGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.receptorGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateSarresidDataGridViewTextBoxColumn
            // 
            this.dateSarresidDataGridViewTextBoxColumn.DataPropertyName = "DateSarresid";
            this.dateSarresidDataGridViewTextBoxColumn.HeaderText = "DateSarresid";
            this.dateSarresidDataGridViewTextBoxColumn.Name = "dateSarresidDataGridViewTextBoxColumn";
            this.dateSarresidDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateSarresidDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkStatusDataGridViewTextBoxColumn
            // 
            this.checkStatusDataGridViewTextBoxColumn.DataPropertyName = "CheckStatus";
            this.checkStatusDataGridViewTextBoxColumn.HeaderText = "CheckStatus";
            this.checkStatusDataGridViewTextBoxColumn.Name = "checkStatusDataGridViewTextBoxColumn";
            this.checkStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // CheckPagesBindingSource
            // 
            this.CheckPagesBindingSource.DataSource = typeof(EntityCache.Bussines.CheckPageBussines);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(681, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 55758;
            this.label3.Text = "نام بانک صادر کننده:";
            // 
            // lblBankName
            // 
            this.lblBankName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankName.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBankName.Location = new System.Drawing.Point(3, 23);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(672, 35);
            this.lblBankName.TabIndex = 55758;
            this.lblBankName.Text = "00";
            this.lblBankName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmShowCheckPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblBankName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmShowCheckPages";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowCheckPages_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPagesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource CheckPagesBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn datePardakhtShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn receptorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSarresidShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datePardakhtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receptorGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSarresidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBankName;
    }
}