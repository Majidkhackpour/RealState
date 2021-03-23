
namespace Accounting.Check.CheckMoshtari
{
    partial class frmShowCheckM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowCheckM));
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pardazandeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgSarresid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCheckNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sandouqTafsilNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAvalDore = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poshtNomreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateSarResidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgPardazandeGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgSandouqTafsilGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsAvalDore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSanad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewPardazande = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKharj = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVagozarSandouq = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVagozarBank = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBargasht = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNaqd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatel = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CheckBindingSource)).BeginInit();
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
            this.txtSearch.TabIndex = 55756;
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
            this.dgRadif,
            this.dateShDataGridViewTextBoxColumn,
            this.dgBankName,
            this.pardazandeDataGridViewTextBoxColumn,
            this.dgSarresid,
            this.dgCheckNumber,
            this.dgPrice,
            this.sandouqTafsilNameDataGridViewTextBoxColumn,
            this.StatusName,
            this.descriptionDataGridViewTextBoxColumn,
            this.dgAvalDore,
            this.dgGuid,
            this.poshtNomreDataGridViewTextBoxColumn,
            this.dateMDataGridViewTextBoxColumn,
            this.dateSarResidDataGridViewTextBoxColumn,
            this.checkStatusDataGridViewTextBoxColumn,
            this.DgPardazandeGuid,
            this.DgSandouqTafsilGuid});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            this.DGrid.DataSource = this.CheckBindingSource;
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
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            this.DGrid.DoubleClick += new System.EventHandler(this.DGrid_DoubleClick);
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 40;
            // 
            // dateShDataGridViewTextBoxColumn
            // 
            this.dateShDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateShDataGridViewTextBoxColumn.DataPropertyName = "DateSh";
            this.dateShDataGridViewTextBoxColumn.HeaderText = "تاریخ دریافت";
            this.dateShDataGridViewTextBoxColumn.Name = "dateShDataGridViewTextBoxColumn";
            this.dateShDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateShDataGridViewTextBoxColumn.Width = 97;
            // 
            // dgBankName
            // 
            this.dgBankName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBankName.DataPropertyName = "BankName";
            this.dgBankName.HeaderText = "بانک صادرکننده";
            this.dgBankName.Name = "dgBankName";
            this.dgBankName.ReadOnly = true;
            this.dgBankName.Width = 109;
            // 
            // pardazandeDataGridViewTextBoxColumn
            // 
            this.pardazandeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pardazandeDataGridViewTextBoxColumn.DataPropertyName = "Pardazande";
            this.pardazandeDataGridViewTextBoxColumn.HeaderText = "پردازنده";
            this.pardazandeDataGridViewTextBoxColumn.Name = "pardazandeDataGridViewTextBoxColumn";
            this.pardazandeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgSarresid
            // 
            this.dgSarresid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgSarresid.DataPropertyName = "DateSarresidSh";
            this.dgSarresid.HeaderText = "سررسید";
            this.dgSarresid.Name = "dgSarresid";
            this.dgSarresid.ReadOnly = true;
            this.dgSarresid.Width = 76;
            // 
            // dgCheckNumber
            // 
            this.dgCheckNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCheckNumber.DataPropertyName = "CheckNumber";
            this.dgCheckNumber.HeaderText = "شماره چک";
            this.dgCheckNumber.Name = "dgCheckNumber";
            this.dgCheckNumber.ReadOnly = true;
            this.dgCheckNumber.Width = 84;
            // 
            // dgPrice
            // 
            this.dgPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPrice.DataPropertyName = "Price";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.dgPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPrice.HeaderText = "مبلغ";
            this.dgPrice.Name = "dgPrice";
            this.dgPrice.ReadOnly = true;
            this.dgPrice.Width = 54;
            // 
            // sandouqTafsilNameDataGridViewTextBoxColumn
            // 
            this.sandouqTafsilNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sandouqTafsilNameDataGridViewTextBoxColumn.DataPropertyName = "SandouqTafsilName";
            this.sandouqTafsilNameDataGridViewTextBoxColumn.HeaderText = "محل";
            this.sandouqTafsilNameDataGridViewTextBoxColumn.Name = "sandouqTafsilNameDataGridViewTextBoxColumn";
            this.sandouqTafsilNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sandouqTafsilNameDataGridViewTextBoxColumn.Width = 55;
            // 
            // StatusName
            // 
            this.StatusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StatusName.DataPropertyName = "StatusName";
            this.StatusName.HeaderText = "وضعیت";
            this.StatusName.Name = "StatusName";
            this.StatusName.ReadOnly = true;
            this.StatusName.Width = 71;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "شرح";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dgAvalDore
            // 
            this.dgAvalDore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAvalDore.DataPropertyName = "IsAvalDore";
            this.dgAvalDore.HeaderText = "اول دوره";
            this.dgAvalDore.Name = "dgAvalDore";
            this.dgAvalDore.ReadOnly = true;
            this.dgAvalDore.Width = 60;
            // 
            // dgGuid
            // 
            this.dgGuid.DataPropertyName = "Guid";
            this.dgGuid.HeaderText = "Guid";
            this.dgGuid.Name = "dgGuid";
            this.dgGuid.ReadOnly = true;
            this.dgGuid.Visible = false;
            // 
            // poshtNomreDataGridViewTextBoxColumn
            // 
            this.poshtNomreDataGridViewTextBoxColumn.DataPropertyName = "PoshtNomre";
            this.poshtNomreDataGridViewTextBoxColumn.HeaderText = "PoshtNomre";
            this.poshtNomreDataGridViewTextBoxColumn.Name = "poshtNomreDataGridViewTextBoxColumn";
            this.poshtNomreDataGridViewTextBoxColumn.ReadOnly = true;
            this.poshtNomreDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateMDataGridViewTextBoxColumn
            // 
            this.dateMDataGridViewTextBoxColumn.DataPropertyName = "DateM";
            this.dateMDataGridViewTextBoxColumn.HeaderText = "DateM";
            this.dateMDataGridViewTextBoxColumn.Name = "dateMDataGridViewTextBoxColumn";
            this.dateMDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateMDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateSarResidDataGridViewTextBoxColumn
            // 
            this.dateSarResidDataGridViewTextBoxColumn.DataPropertyName = "DateSarResid";
            this.dateSarResidDataGridViewTextBoxColumn.HeaderText = "DateSarResid";
            this.dateSarResidDataGridViewTextBoxColumn.Name = "dateSarResidDataGridViewTextBoxColumn";
            this.dateSarResidDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateSarResidDataGridViewTextBoxColumn.Visible = false;
            // 
            // checkStatusDataGridViewTextBoxColumn
            // 
            this.checkStatusDataGridViewTextBoxColumn.DataPropertyName = "CheckStatus";
            this.checkStatusDataGridViewTextBoxColumn.HeaderText = "CheckStatus";
            this.checkStatusDataGridViewTextBoxColumn.Name = "checkStatusDataGridViewTextBoxColumn";
            this.checkStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // DgPardazandeGuid
            // 
            this.DgPardazandeGuid.DataPropertyName = "PardazandeGuid";
            this.DgPardazandeGuid.HeaderText = "PardazandeGuid";
            this.DgPardazandeGuid.Name = "DgPardazandeGuid";
            this.DgPardazandeGuid.ReadOnly = true;
            this.DgPardazandeGuid.Visible = false;
            // 
            // DgSandouqTafsilGuid
            // 
            this.DgSandouqTafsilGuid.DataPropertyName = "SandouqTafsilGuid";
            this.DgSandouqTafsilGuid.HeaderText = "DgSandouqTafsilGuid";
            this.DgSandouqTafsilGuid.Name = "DgSandouqTafsilGuid";
            this.DgSandouqTafsilGuid.ReadOnly = true;
            this.DgSandouqTafsilGuid.Visible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAdd,
            this.mnuInsAvalDore,
            this.mnuEdit,
            this.toolStripMenuItem1,
            this.mnuView,
            this.mnuViewSanad,
            this.mnuViewPardazande,
            this.toolStripMenuItem2,
            this.mnuKharj,
            this.mnuVagozarSandouq,
            this.mnuVagozarBank,
            this.mnuBargasht,
            this.mnuNaqd,
            this.mnuBatel});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(236, 326);
            // 
            // mnuAdd
            // 
            this.mnuAdd.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuAdd.Name = "mnuAdd";
            this.mnuAdd.Size = new System.Drawing.Size(235, 24);
            this.mnuAdd.Text = "افزودن چک دریافتی جدید (Ins)";
            this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
            // 
            // mnuInsAvalDore
            // 
            this.mnuInsAvalDore.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuInsAvalDore.Name = "mnuInsAvalDore";
            this.mnuInsAvalDore.Size = new System.Drawing.Size(235, 24);
            this.mnuInsAvalDore.Text = "افزودن چک دریافتی اول دوره";
            this.mnuInsAvalDore.Click += new System.EventHandler(this.mnuInsAvalDore_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Accounting.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(235, 24);
            this.mnuEdit.Text = "ویرایش چک دریافتی جاری (F7)";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(232, 6);
            // 
            // mnuView
            // 
            this.mnuView.Image = global::Accounting.Properties.Resources.article_1_;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(235, 24);
            this.mnuView.Text = "مشاهده (F12)";
            this.mnuView.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuViewSanad
            // 
            this.mnuViewSanad.Image = global::Accounting.Properties.Resources.article_1_;
            this.mnuViewSanad.Name = "mnuViewSanad";
            this.mnuViewSanad.Size = new System.Drawing.Size(235, 24);
            this.mnuViewSanad.Text = "مشاهده سند دریافت";
            this.mnuViewSanad.Click += new System.EventHandler(this.mnuViewSanad_Click);
            // 
            // mnuViewPardazande
            // 
            this.mnuViewPardazande.Image = global::Accounting.Properties.Resources.article_1_;
            this.mnuViewPardazande.Name = "mnuViewPardazande";
            this.mnuViewPardazande.Size = new System.Drawing.Size(235, 24);
            this.mnuViewPardazande.Text = "مشاهده مشخصات پردازنده";
            this.mnuViewPardazande.Click += new System.EventHandler(this.mnuViewPardazande_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
            // 
            // mnuKharj
            // 
            this.mnuKharj.Name = "mnuKharj";
            this.mnuKharj.Size = new System.Drawing.Size(235, 24);
            this.mnuKharj.Text = "خرج کردن";
            this.mnuKharj.Click += new System.EventHandler(this.mnuKharj_Click);
            // 
            // mnuVagozarSandouq
            // 
            this.mnuVagozarSandouq.Name = "mnuVagozarSandouq";
            this.mnuVagozarSandouq.Size = new System.Drawing.Size(235, 24);
            this.mnuVagozarSandouq.Text = "واگذار کردن به صندوق";
            this.mnuVagozarSandouq.Click += new System.EventHandler(this.mnuVagozarSandouq_Click);
            // 
            // mnuVagozarBank
            // 
            this.mnuVagozarBank.Name = "mnuVagozarBank";
            this.mnuVagozarBank.Size = new System.Drawing.Size(235, 24);
            this.mnuVagozarBank.Text = "واگذار کردن به بانک";
            this.mnuVagozarBank.Click += new System.EventHandler(this.mnuVagozarBank_Click);
            // 
            // mnuBargasht
            // 
            this.mnuBargasht.Name = "mnuBargasht";
            this.mnuBargasht.Size = new System.Drawing.Size(235, 24);
            this.mnuBargasht.Text = "برگشت زدن";
            this.mnuBargasht.Click += new System.EventHandler(this.mnuBargasht_Click);
            // 
            // mnuNaqd
            // 
            this.mnuNaqd.Name = "mnuNaqd";
            this.mnuNaqd.Size = new System.Drawing.Size(235, 24);
            this.mnuNaqd.Text = "نقد کردن";
            this.mnuNaqd.Click += new System.EventHandler(this.mnuNaqd_Click);
            // 
            // mnuBatel
            // 
            this.mnuBatel.Name = "mnuBatel";
            this.mnuBatel.Size = new System.Drawing.Size(235, 24);
            this.mnuBatel.Text = "باطل کردن";
            this.mnuBatel.Click += new System.EventHandler(this.mnuBatel_Click);
            // 
            // CheckBindingSource
            // 
            this.CheckBindingSource.DataSource = typeof(EntityCache.ViewModels.ReceptionCheckViewModel);
            // 
            // frmShowCheckM
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
            this.Name = "frmShowCheckM";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowCheckM_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowCheckM_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CheckBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtSearch;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.BindingSource CheckBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn masterGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuInsAvalDore;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSanad;
        private System.Windows.Forms.ToolStripMenuItem mnuViewPardazande;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuKharj;
        private System.Windows.Forms.ToolStripMenuItem mnuVagozarSandouq;
        private System.Windows.Forms.ToolStripMenuItem mnuVagozarBank;
        private System.Windows.Forms.ToolStripMenuItem mnuBargasht;
        private System.Windows.Forms.ToolStripMenuItem mnuNaqd;
        private System.Windows.Forms.ToolStripMenuItem mnuBatel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pardazandeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgSarresid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCheckNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn sandouqTafsilNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgAvalDore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn poshtNomreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateSarResidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgPardazandeGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgSandouqTafsilGuid;
    }
}