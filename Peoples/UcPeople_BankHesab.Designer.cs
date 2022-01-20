
namespace Peoples
{
    partial class UcPeople_BankHesab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.bankAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtShobe = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDelBank = new DevComponents.DotNetBar.ButtonX();
            this.btnInsBank = new DevComponents.DotNetBar.ButtonX();
            this.dgBankAccount = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shobeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBankGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPanel
            // 
            this.grpPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpPanel.Controls.Add(this.dgBankAccount);
            this.grpPanel.Controls.Add(this.txtShobe);
            this.grpPanel.Controls.Add(this.label15);
            this.grpPanel.Controls.Add(this.txtAccountNumber);
            this.grpPanel.Controls.Add(this.label14);
            this.grpPanel.Controls.Add(this.txtBank);
            this.grpPanel.Controls.Add(this.label13);
            this.grpPanel.Controls.Add(this.btnDelBank);
            this.grpPanel.Controls.Add(this.btnInsBank);
            this.grpPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.grpPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPanel.Location = new System.Drawing.Point(0, 0);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Size = new System.Drawing.Size(721, 261);
            // 
            // 
            // 
            this.grpPanel.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.grpPanel.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.grpPanel.Style.BackColorGradientAngle = 90;
            this.grpPanel.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderBottomWidth = 2;
            this.grpPanel.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.grpPanel.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.grpPanel.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderLeftWidth = 2;
            this.grpPanel.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderRightWidth = 2;
            this.grpPanel.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grpPanel.Style.BorderTopWidth = 2;
            this.grpPanel.Style.CornerDiameter = 4;
            this.grpPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grpPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grpPanel.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grpPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grpPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grpPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grpPanel.TabIndex = 9;
            this.grpPanel.Text = "اطلاعات حساب های بانکی";
            // 
            // bankAccountBindingSource
            // 
            this.bankAccountBindingSource.DataSource = typeof(EntityCache.Bussines.PeoplesBankAccountBussines);
            // 
            // txtShobe
            // 
            this.txtShobe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShobe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtShobe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShobe.Location = new System.Drawing.Point(62, 3);
            this.txtShobe.Name = "txtShobe";
            this.txtShobe.Size = new System.Drawing.Size(104, 27);
            this.txtShobe.TabIndex = 55725;
            this.txtShobe.Enter += new System.EventHandler(this.txtShobe_Enter);
            this.txtShobe.Leave += new System.EventHandler(this.txtShobe_Enter);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(172, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 20);
            this.label15.TabIndex = 55721;
            this.label15.Text = "شعبه";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccountNumber.Location = new System.Drawing.Point(210, 3);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(184, 27);
            this.txtAccountNumber.TabIndex = 55722;
            this.txtAccountNumber.Enter += new System.EventHandler(this.txtAccountNumber_Enter);
            this.txtAccountNumber.Leave += new System.EventHandler(this.txtAccountNumber_Leave);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(400, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 20);
            this.label14.TabIndex = 55723;
            this.label14.Text = "شماره حساب";
            // 
            // txtBank
            // 
            this.txtBank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtBank.Location = new System.Drawing.Point(477, 3);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(195, 27);
            this.txtBank.TabIndex = 55720;
            this.txtBank.Enter += new System.EventHandler(this.txtBank_Enter);
            this.txtBank.Leave += new System.EventHandler(this.txtBank_Leave);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(678, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 20);
            this.label13.TabIndex = 55724;
            this.label13.Text = "بانک";
            // 
            // btnDelBank
            // 
            this.btnDelBank.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelBank.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDelBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelBank.Image = global::Peoples.Properties.Resources.tab_close_;
            this.btnDelBank.Location = new System.Drawing.Point(3, 3);
            this.btnDelBank.Name = "btnDelBank";
            this.btnDelBank.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelBank.Size = new System.Drawing.Size(25, 27);
            this.btnDelBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelBank.TabIndex = 55719;
            this.btnDelBank.TextColor = System.Drawing.Color.Black;
            this.btnDelBank.Click += new System.EventHandler(this.btnDelBank_Click);
            // 
            // btnInsBank
            // 
            this.btnInsBank.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInsBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInsBank.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnInsBank.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsBank.Image = global::Peoples.Properties.Resources.tab_checkbox__;
            this.btnInsBank.Location = new System.Drawing.Point(34, 3);
            this.btnInsBank.Name = "btnInsBank";
            this.btnInsBank.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnInsBank.Size = new System.Drawing.Size(25, 27);
            this.btnInsBank.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnInsBank.TabIndex = 55726;
            this.btnInsBank.TextColor = System.Drawing.Color.Black;
            this.btnInsBank.Click += new System.EventHandler(this.btnInsBank_Click);
            // 
            // dgBankAccount
            // 
            this.dgBankAccount.AllowUserToAddRows = false;
            this.dgBankAccount.AllowUserToDeleteRows = false;
            this.dgBankAccount.AllowUserToResizeColumns = false;
            this.dgBankAccount.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.dgBankAccount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgBankAccount.AutoGenerateColumns = false;
            this.dgBankAccount.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBankAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgBankAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBankAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bRadif,
            this.bankNameDataGridViewTextBoxColumn,
            this.accountNumberDataGridViewTextBoxColumn,
            this.shobeDataGridViewTextBoxColumn,
            this.dgBankGuid});
            this.dgBankAccount.DataSource = this.bankAccountBindingSource;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgBankAccount.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgBankAccount.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgBankAccount.Location = new System.Drawing.Point(3, 37);
            this.dgBankAccount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgBankAccount.Name = "dgBankAccount";
            this.dgBankAccount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgBankAccount.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgBankAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgBankAccount.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.dgBankAccount.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgBankAccount.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgBankAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgBankAccount.Size = new System.Drawing.Size(702, 192);
            this.dgBankAccount.TabIndex = 55727;
            this.dgBankAccount.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgBankAccount_CellFormatting);
            // 
            // bRadif
            // 
            this.bRadif.HeaderText = "ردیف";
            this.bRadif.Name = "bRadif";
            this.bRadif.ReadOnly = true;
            this.bRadif.Width = 50;
            // 
            // bankNameDataGridViewTextBoxColumn
            // 
            this.bankNameDataGridViewTextBoxColumn.DataPropertyName = "BankName";
            this.bankNameDataGridViewTextBoxColumn.HeaderText = "بانک";
            this.bankNameDataGridViewTextBoxColumn.Name = "bankNameDataGridViewTextBoxColumn";
            this.bankNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // accountNumberDataGridViewTextBoxColumn
            // 
            this.accountNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountNumberDataGridViewTextBoxColumn.DataPropertyName = "AccountNumber";
            this.accountNumberDataGridViewTextBoxColumn.HeaderText = "شماره حساب";
            this.accountNumberDataGridViewTextBoxColumn.Name = "accountNumberDataGridViewTextBoxColumn";
            // 
            // shobeDataGridViewTextBoxColumn
            // 
            this.shobeDataGridViewTextBoxColumn.DataPropertyName = "Shobe";
            this.shobeDataGridViewTextBoxColumn.HeaderText = "شعبه";
            this.shobeDataGridViewTextBoxColumn.Name = "shobeDataGridViewTextBoxColumn";
            // 
            // dgBankGuid
            // 
            this.dgBankGuid.DataPropertyName = "Guid";
            this.dgBankGuid.HeaderText = "Guid";
            this.dgBankGuid.Name = "dgBankGuid";
            this.dgBankGuid.Visible = false;
            // 
            // UcPeople_BankHesab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPanel);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcPeople_BankHesab";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(721, 261);
            this.grpPanel.ResumeLayout(false);
            this.grpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgBankAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel grpPanel;
        private System.Windows.Forms.BindingSource bankAccountBindingSource;
        private System.Windows.Forms.TextBox txtShobe;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.ButtonX btnDelBank;
        private DevComponents.DotNetBar.ButtonX btnInsBank;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgBankAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn bRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shobeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBankGuid;
    }
}
