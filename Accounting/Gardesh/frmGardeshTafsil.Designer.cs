
namespace Accounting.Gardesh
{
    partial class frmGardeshTafsil
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGardeshTafsil));
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDebit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCredit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rem_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remDiagnosisDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moeinGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moeinCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moeinNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tafsilGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tafsilCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tafsilNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GardeshBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrint = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GardeshBindingSource)).BeginInit();
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
            this.dgRadif,
            this.DateSh,
            this.descriptionDataGridViewTextBoxColumn,
            this.dgDebit,
            this.dgCredit,
            this.Rem_,
            this.remDiagnosisDataGridViewTextBoxColumn,
            this.guidDataGridViewTextBoxColumn,
            this.remDataGridViewTextBoxColumn,
            this.moeinGuidDataGridViewTextBoxColumn,
            this.moeinCodeDataGridViewTextBoxColumn,
            this.moeinNameDataGridViewTextBoxColumn,
            this.tafsilGuidDataGridViewTextBoxColumn,
            this.tafsilCodeDataGridViewTextBoxColumn,
            this.tafsilNameDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.GardeshBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(3, 24);
            this.DGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGrid.MultiSelect = false;
            this.DGrid.Name = "DGrid";
            this.DGrid.ReadOnly = true;
            this.DGrid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.DGrid.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGrid.Size = new System.Drawing.Size(794, 535);
            this.DGrid.TabIndex = 1;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // dgRadif
            // 
            this.dgRadif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 60;
            // 
            // DateSh
            // 
            this.DateSh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateSh.DataPropertyName = "DateSh";
            this.DateSh.HeaderText = "تاریخ";
            this.DateSh.Name = "DateSh";
            this.DateSh.ReadOnly = true;
            this.DateSh.Width = 58;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "شرح";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgDebit
            // 
            this.dgDebit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDebit.DataPropertyName = "Debit";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dgDebit.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgDebit.HeaderText = "بدهکار";
            this.dgDebit.Name = "dgDebit";
            this.dgDebit.ReadOnly = true;
            this.dgDebit.Width = 67;
            // 
            // dgCredit
            // 
            this.dgCredit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCredit.DataPropertyName = "Credit";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.dgCredit.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgCredit.HeaderText = "بستانکار";
            this.dgCredit.Name = "dgCredit";
            this.dgCredit.ReadOnly = true;
            this.dgCredit.Width = 75;
            // 
            // Rem_
            // 
            this.Rem_.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rem_.DataPropertyName = "Rem_";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.Rem_.DefaultCellStyle = dataGridViewCellStyle5;
            this.Rem_.HeaderText = "مانده";
            this.Rem_.Name = "Rem_";
            this.Rem_.ReadOnly = true;
            this.Rem_.Width = 58;
            // 
            // remDiagnosisDataGridViewTextBoxColumn
            // 
            this.remDiagnosisDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.remDiagnosisDataGridViewTextBoxColumn.DataPropertyName = "RemDiagnosis";
            this.remDiagnosisDataGridViewTextBoxColumn.HeaderText = "تشخیص";
            this.remDiagnosisDataGridViewTextBoxColumn.Name = "remDiagnosisDataGridViewTextBoxColumn";
            this.remDiagnosisDataGridViewTextBoxColumn.ReadOnly = true;
            this.remDiagnosisDataGridViewTextBoxColumn.Width = 74;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            this.guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            this.guidDataGridViewTextBoxColumn.HeaderText = "Guid";
            this.guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            this.guidDataGridViewTextBoxColumn.ReadOnly = true;
            this.guidDataGridViewTextBoxColumn.Visible = false;
            // 
            // remDataGridViewTextBoxColumn
            // 
            this.remDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.remDataGridViewTextBoxColumn.DataPropertyName = "Rem";
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.remDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.remDataGridViewTextBoxColumn.HeaderText = "مانده";
            this.remDataGridViewTextBoxColumn.Name = "remDataGridViewTextBoxColumn";
            this.remDataGridViewTextBoxColumn.ReadOnly = true;
            this.remDataGridViewTextBoxColumn.Visible = false;
            // 
            // moeinGuidDataGridViewTextBoxColumn
            // 
            this.moeinGuidDataGridViewTextBoxColumn.DataPropertyName = "MoeinGuid";
            this.moeinGuidDataGridViewTextBoxColumn.HeaderText = "MoeinGuid";
            this.moeinGuidDataGridViewTextBoxColumn.Name = "moeinGuidDataGridViewTextBoxColumn";
            this.moeinGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.moeinGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // moeinCodeDataGridViewTextBoxColumn
            // 
            this.moeinCodeDataGridViewTextBoxColumn.DataPropertyName = "MoeinCode";
            this.moeinCodeDataGridViewTextBoxColumn.HeaderText = "MoeinCode";
            this.moeinCodeDataGridViewTextBoxColumn.Name = "moeinCodeDataGridViewTextBoxColumn";
            this.moeinCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.moeinCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // moeinNameDataGridViewTextBoxColumn
            // 
            this.moeinNameDataGridViewTextBoxColumn.DataPropertyName = "MoeinName";
            this.moeinNameDataGridViewTextBoxColumn.HeaderText = "MoeinName";
            this.moeinNameDataGridViewTextBoxColumn.Name = "moeinNameDataGridViewTextBoxColumn";
            this.moeinNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.moeinNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // tafsilGuidDataGridViewTextBoxColumn
            // 
            this.tafsilGuidDataGridViewTextBoxColumn.DataPropertyName = "TafsilGuid";
            this.tafsilGuidDataGridViewTextBoxColumn.HeaderText = "TafsilGuid";
            this.tafsilGuidDataGridViewTextBoxColumn.Name = "tafsilGuidDataGridViewTextBoxColumn";
            this.tafsilGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.tafsilGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // tafsilCodeDataGridViewTextBoxColumn
            // 
            this.tafsilCodeDataGridViewTextBoxColumn.DataPropertyName = "TafsilCode";
            this.tafsilCodeDataGridViewTextBoxColumn.HeaderText = "TafsilCode";
            this.tafsilCodeDataGridViewTextBoxColumn.Name = "tafsilCodeDataGridViewTextBoxColumn";
            this.tafsilCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tafsilCodeDataGridViewTextBoxColumn.Visible = false;
            // 
            // tafsilNameDataGridViewTextBoxColumn
            // 
            this.tafsilNameDataGridViewTextBoxColumn.DataPropertyName = "TafsilName";
            this.tafsilNameDataGridViewTextBoxColumn.HeaderText = "TafsilName";
            this.tafsilNameDataGridViewTextBoxColumn.Name = "tafsilNameDataGridViewTextBoxColumn";
            this.tafsilNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tafsilNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // GardeshBindingSource
            // 
            this.GardeshBindingSource.DataSource = typeof(EntityCache.Bussines.GardeshBussines);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrint.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Location = new System.Drawing.Point(215, 566);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnPrint.Size = new System.Drawing.Size(356, 27);
            this.btnPrint.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.TextColor = System.Drawing.Color.White;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmGardeshTafsil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmGardeshTafsil";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGardeshTafsil_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGardeshTafsil_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GardeshBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource GardeshBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private DevComponents.DotNetBar.ButtonX btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSh;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDebit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rem_;
        private System.Windows.Forms.DataGridViewTextBoxColumn remDiagnosisDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moeinGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moeinCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moeinNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tafsilGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tafsilCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tafsilNameDataGridViewTextBoxColumn;
    }
}