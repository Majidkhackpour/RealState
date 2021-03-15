
namespace Accounting.Pardakht
{
    partial class frmPardakhtMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPardakhtMain));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnTafsilSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtTafsilName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.NumericUpDown();
            this.txtSanadNo = new System.Windows.Forms.NumericUpDown();
            this.txtDate = new BPersianCalender.BPersianCalenderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSumHavale = new System.Windows.Forms.Label();
            this.lblSumCheckSh = new System.Windows.Forms.Label();
            this.lblSum = new System.Windows.Forms.Label();
            this.lblSumNaqdi = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.lblSumCheckM = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.grp = new DevComponents.DotNetBar.PanelEx();
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dgRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGTafsilGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_TempDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGHavale_Peygiri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCheckBankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGCheckStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGPoshtNomre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGDateSarresid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCheckGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddNaqd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddHavale = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCheckSh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCheckM = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSanadNo)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Accounting.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(56, 562);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55779;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTafsilSearch
            // 
            this.btnTafsilSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTafsilSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTafsilSearch.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnTafsilSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTafsilSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTafsilSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTafsilSearch.Location = new System.Drawing.Point(272, 11);
            this.btnTafsilSearch.Name = "btnTafsilSearch";
            this.btnTafsilSearch.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnTafsilSearch.Size = new System.Drawing.Size(30, 27);
            this.btnTafsilSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnTafsilSearch.TabIndex = 14;
            this.btnTafsilSearch.Text = "...";
            this.btnTafsilSearch.TextColor = System.Drawing.Color.White;
            this.btnTafsilSearch.Click += new System.EventHandler(this.btnTafsilSearch_Click);
            // 
            // txtTafsilName
            // 
            this.txtTafsilName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTafsilName.Enabled = false;
            this.txtTafsilName.Location = new System.Drawing.Point(308, 10);
            this.txtTafsilName.Name = "txtTafsilName";
            this.txtTafsilName.ReadOnly = true;
            this.txtTafsilName.Size = new System.Drawing.Size(344, 27);
            this.txtTafsilName.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(658, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "شناسایی طرف حساب";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(17, 11);
            this.txtNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(145, 27);
            this.txtNumber.TabIndex = 0;
            // 
            // txtSanadNo
            // 
            this.txtSanadNo.Location = new System.Drawing.Point(17, 77);
            this.txtSanadNo.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSanadNo.Name = "txtSanadNo";
            this.txtSanadNo.Size = new System.Drawing.Size(145, 27);
            this.txtSanadNo.TabIndex = 0;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(17, 44);
            this.txtDate.Miladi = new System.DateTime(2020, 10, 25, 17, 11, 28, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.NowDateSelected = false;
            this.txtDate.ReadOnly = true;
            this.txtDate.SelectedDate = null;
            this.txtDate.Shamsi = null;
            this.txtDate.Size = new System.Drawing.Size(145, 27);
            this.txtDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(195, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "تاریخ";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDesc.Location = new System.Drawing.Point(272, 44);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(446, 55);
            this.txtDesc.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(165, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "شماره برگه";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(734, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "شرح";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(167, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "شماره سند";
            // 
            // lblSumHavale
            // 
            this.lblSumHavale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumHavale.BackColor = System.Drawing.Color.Transparent;
            this.lblSumHavale.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumHavale.ForeColor = System.Drawing.Color.Black;
            this.lblSumHavale.Location = new System.Drawing.Point(29, 57);
            this.lblSumHavale.Name = "lblSumHavale";
            this.lblSumHavale.Size = new System.Drawing.Size(610, 24);
            this.lblSumHavale.TabIndex = 5;
            this.lblSumHavale.Text = "00 ریال";
            // 
            // lblSumCheckSh
            // 
            this.lblSumCheckSh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumCheckSh.BackColor = System.Drawing.Color.Transparent;
            this.lblSumCheckSh.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumCheckSh.ForeColor = System.Drawing.Color.Black;
            this.lblSumCheckSh.Location = new System.Drawing.Point(25, 81);
            this.lblSumCheckSh.Name = "lblSumCheckSh";
            this.lblSumCheckSh.Size = new System.Drawing.Size(614, 24);
            this.lblSumCheckSh.TabIndex = 5;
            this.lblSumCheckSh.Text = "00 ریال";
            // 
            // lblSum
            // 
            this.lblSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSum.BackColor = System.Drawing.Color.Transparent;
            this.lblSum.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSum.ForeColor = System.Drawing.Color.Black;
            this.lblSum.Location = new System.Drawing.Point(12, 9);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(627, 24);
            this.lblSum.TabIndex = 5;
            this.lblSum.Text = "00 ریال";
            // 
            // lblSumNaqdi
            // 
            this.lblSumNaqdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumNaqdi.BackColor = System.Drawing.Color.Transparent;
            this.lblSumNaqdi.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumNaqdi.ForeColor = System.Drawing.Color.Black;
            this.lblSumNaqdi.Location = new System.Drawing.Point(29, 33);
            this.lblSumNaqdi.Name = "lblSumNaqdi";
            this.lblSumNaqdi.Size = new System.Drawing.Size(610, 24);
            this.lblSumNaqdi.TabIndex = 5;
            this.lblSumNaqdi.Text = "00 ریال";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(681, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "پرداخت حواله:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(645, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "پرداخت چک شخصی:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(666, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "جمع کل پرداخت:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(681, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "پرداخت نقدی:";
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Accounting.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(623, 562);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55778;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            // 
            // panelEx2
            // 
            this.panelEx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.lblSumHavale);
            this.panelEx2.Controls.Add(this.lblSumCheckM);
            this.panelEx2.Controls.Add(this.lblSumCheckSh);
            this.panelEx2.Controls.Add(this.lblSum);
            this.panelEx2.Controls.Add(this.lblSumNaqdi);
            this.panelEx2.Controls.Add(this.label9);
            this.panelEx2.Controls.Add(this.label10);
            this.panelEx2.Controls.Add(this.label5);
            this.panelEx2.Controls.Add(this.label6);
            this.panelEx2.Controls.Add(this.label4);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Location = new System.Drawing.Point(8, 410);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(786, 143);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.White;
            this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.White;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.panelEx2.Style.BorderWidth = 2;
            this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 55777;
            // 
            // lblSumCheckM
            // 
            this.lblSumCheckM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumCheckM.BackColor = System.Drawing.Color.Transparent;
            this.lblSumCheckM.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSumCheckM.ForeColor = System.Drawing.Color.Black;
            this.lblSumCheckM.Location = new System.Drawing.Point(25, 108);
            this.lblSumCheckM.Name = "lblSumCheckM";
            this.lblSumCheckM.Size = new System.Drawing.Size(614, 24);
            this.lblSumCheckM.TabIndex = 5;
            this.lblSumCheckM.Text = "00 ریال";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(660, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 24);
            this.label10.TabIndex = 5;
            this.label10.Text = "خرج چک دریافتی:";
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.CanvasColor = System.Drawing.SystemColors.Control;
            this.grp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.grp.Controls.Add(this.btnTafsilSearch);
            this.grp.Controls.Add(this.txtTafsilName);
            this.grp.Controls.Add(this.label8);
            this.grp.Controls.Add(this.txtNumber);
            this.grp.Controls.Add(this.txtSanadNo);
            this.grp.Controls.Add(this.txtDate);
            this.grp.Controls.Add(this.label1);
            this.grp.Controls.Add(this.txtDesc);
            this.grp.Controls.Add(this.label2);
            this.grp.Controls.Add(this.label3);
            this.grp.Controls.Add(this.label7);
            this.grp.DisabledBackColor = System.Drawing.Color.Empty;
            this.grp.Location = new System.Drawing.Point(8, 24);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(786, 117);
            this.grp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.grp.Style.BackColor1.Color = System.Drawing.Color.White;
            this.grp.Style.BackColor2.Color = System.Drawing.Color.White;
            this.grp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.grp.Style.BorderColor.Color = System.Drawing.Color.Silver;
            this.grp.Style.BorderWidth = 2;
            this.grp.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grp.Style.GradientAngle = 90;
            this.grp.TabIndex = 55776;
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
            this.DGType,
            this.DGDescription,
            this.DGPrice,
            this.DgGuid,
            this.DGTafsilGuid,
            this.DG_TempDescription,
            this.DGNumber,
            this.DGDate,
            this.DGHavale_Peygiri,
            this.DGCheckBankName,
            this.DGCheckStatus,
            this.DGPoshtNomre,
            this.DGDateSarresid,
            this.dgCheckGuid});
            this.DGrid.ContextMenuStrip = this.contextMenu;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(5, 148);
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
            this.DGrid.Size = new System.Drawing.Size(793, 255);
            this.DGrid.TabIndex = 55775;
            this.DGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGrid_CellFormatting);
            // 
            // dgRadif
            // 
            this.dgRadif.HeaderText = "ردیف";
            this.dgRadif.Name = "dgRadif";
            this.dgRadif.ReadOnly = true;
            this.dgRadif.Width = 50;
            // 
            // DGType
            // 
            this.DGType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGType.HeaderText = "نوع";
            this.DGType.Name = "DGType";
            this.DGType.ReadOnly = true;
            this.DGType.Width = 51;
            // 
            // DGDescription
            // 
            this.DGDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGDescription.HeaderText = "شرح";
            this.DGDescription.Name = "DGDescription";
            this.DGDescription.ReadOnly = true;
            // 
            // DGPrice
            // 
            this.DGPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.DGPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGPrice.HeaderText = "مبلغ";
            this.DGPrice.Name = "DGPrice";
            this.DGPrice.ReadOnly = true;
            this.DGPrice.Width = 54;
            // 
            // DgGuid
            // 
            this.DgGuid.HeaderText = "Guid";
            this.DgGuid.Name = "DgGuid";
            this.DgGuid.ReadOnly = true;
            this.DgGuid.Visible = false;
            // 
            // DGTafsilGuid
            // 
            this.DGTafsilGuid.HeaderText = "SandouqGuid";
            this.DGTafsilGuid.Name = "DGTafsilGuid";
            this.DGTafsilGuid.ReadOnly = true;
            this.DGTafsilGuid.Visible = false;
            // 
            // DG_TempDescription
            // 
            this.DG_TempDescription.HeaderText = "TempDesc";
            this.DG_TempDescription.Name = "DG_TempDescription";
            this.DG_TempDescription.ReadOnly = true;
            this.DG_TempDescription.Visible = false;
            // 
            // DGNumber
            // 
            this.DGNumber.HeaderText = "Number";
            this.DGNumber.Name = "DGNumber";
            this.DGNumber.ReadOnly = true;
            this.DGNumber.Visible = false;
            // 
            // DGDate
            // 
            this.DGDate.HeaderText = "Date";
            this.DGDate.Name = "DGDate";
            this.DGDate.ReadOnly = true;
            this.DGDate.Visible = false;
            // 
            // DGHavale_Peygiri
            // 
            this.DGHavale_Peygiri.HeaderText = "HavalePeygiri";
            this.DGHavale_Peygiri.Name = "DGHavale_Peygiri";
            this.DGHavale_Peygiri.ReadOnly = true;
            this.DGHavale_Peygiri.Visible = false;
            // 
            // DGCheckBankName
            // 
            this.DGCheckBankName.HeaderText = "ChackBankName";
            this.DGCheckBankName.Name = "DGCheckBankName";
            this.DGCheckBankName.ReadOnly = true;
            this.DGCheckBankName.Visible = false;
            // 
            // DGCheckStatus
            // 
            this.DGCheckStatus.HeaderText = "CheckStatus";
            this.DGCheckStatus.Name = "DGCheckStatus";
            this.DGCheckStatus.ReadOnly = true;
            this.DGCheckStatus.Visible = false;
            // 
            // DGPoshtNomre
            // 
            this.DGPoshtNomre.HeaderText = "PoshtNomre";
            this.DGPoshtNomre.Name = "DGPoshtNomre";
            this.DGPoshtNomre.ReadOnly = true;
            this.DGPoshtNomre.Visible = false;
            // 
            // DGDateSarresid
            // 
            this.DGDateSarresid.HeaderText = "DateSarresid";
            this.DGDateSarresid.Name = "DGDateSarresid";
            this.DGDateSarresid.ReadOnly = true;
            this.DGDateSarresid.Visible = false;
            // 
            // dgCheckGuid
            // 
            this.dgCheckGuid.HeaderText = "dgCheckGuid";
            this.dgCheckGuid.Name = "dgCheckGuid";
            this.dgCheckGuid.ReadOnly = true;
            this.dgCheckGuid.Visible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddNaqd,
            this.mnuAddHavale,
            this.mnuAddCheckSh,
            this.mnuAddCheckM,
            this.toolStripMenuItem1,
            this.mnuEdit,
            this.mnuDelete});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenu.Size = new System.Drawing.Size(243, 176);
            // 
            // mnuAddNaqd
            // 
            this.mnuAddNaqd.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuAddNaqd.Name = "mnuAddNaqd";
            this.mnuAddNaqd.Size = new System.Drawing.Size(242, 24);
            this.mnuAddNaqd.Text = "افزودن پرداخت نقدی (F1)";
            this.mnuAddNaqd.Click += new System.EventHandler(this.mnuAddNaqd_Click);
            // 
            // mnuAddHavale
            // 
            this.mnuAddHavale.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuAddHavale.Name = "mnuAddHavale";
            this.mnuAddHavale.Size = new System.Drawing.Size(242, 24);
            this.mnuAddHavale.Text = "افزودن پرداخت حواله (F2)";
            this.mnuAddHavale.Click += new System.EventHandler(this.mnuAddHavale_Click);
            // 
            // mnuAddCheckSh
            // 
            this.mnuAddCheckSh.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuAddCheckSh.Name = "mnuAddCheckSh";
            this.mnuAddCheckSh.Size = new System.Drawing.Size(242, 24);
            this.mnuAddCheckSh.Text = "افزودن پرداخت چک شخصی (F3)";
            this.mnuAddCheckSh.Click += new System.EventHandler(this.mnuAddCheckSh_Click);
            // 
            // mnuAddCheckM
            // 
            this.mnuAddCheckM.Image = global::Accounting.Properties.Resources.add_2_;
            this.mnuAddCheckM.Name = "mnuAddCheckM";
            this.mnuAddCheckM.Size = new System.Drawing.Size(242, 24);
            this.mnuAddCheckM.Text = "خرج چک دریافتی (F4)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(239, 6);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Image = global::Accounting.Properties.Resources.edit_1_;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(242, 24);
            this.mnuEdit.Text = "ویرایش سطر جاری (F7)";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::Accounting.Properties.Resources.delete_1_;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(242, 24);
            this.mnuDelete.Text = "حذف سطر جاری (Del)";
            // 
            // frmPardakhtMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.grp);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmPardakhtMain";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPardakhtMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPardakhtMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSanadNo)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            this.grp.ResumeLayout(false);
            this.grp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnTafsilSearch;
        private System.Windows.Forms.TextBox txtTafsilName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtNumber;
        private System.Windows.Forms.NumericUpDown txtSanadNo;
        private BPersianCalender.BPersianCalenderTextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSumHavale;
        private System.Windows.Forms.Label lblSumCheckSh;
        private System.Windows.Forms.Label lblSum;
        private System.Windows.Forms.Label lblSumNaqdi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.PanelEx grp;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAddNaqd;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCheckSh;
        private System.Windows.Forms.ToolStripMenuItem mnuAddHavale;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.Label lblSumCheckM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCheckM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGTafsilGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_TempDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGHavale_Peygiri;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCheckBankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGCheckStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGPoshtNomre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGDateSarresid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCheckGuid;
    }
}