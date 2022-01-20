
namespace Peoples
{
    partial class UcPeople_PhoneBook
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
            this.grpPanel = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.DGridTell = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.tRadif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgTellGuid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbTitles = new System.Windows.Forms.ComboBox();
            this.btnDelTell = new DevComponents.DotNetBar.ButtonX();
            this.btnInsTell = new DevComponents.DotNetBar.ButtonX();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTell = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridTell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBookBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPanel
            // 
            this.grpPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.grpPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grpPanel.Controls.Add(this.DGridTell);
            this.grpPanel.Controls.Add(this.cmbTitles);
            this.grpPanel.Controls.Add(this.btnDelTell);
            this.grpPanel.Controls.Add(this.btnInsTell);
            this.grpPanel.Controls.Add(this.label17);
            this.grpPanel.Controls.Add(this.txtTell);
            this.grpPanel.Controls.Add(this.label12);
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
            this.grpPanel.TabIndex = 8;
            this.grpPanel.Text = "اطلاعات تماس";
            // 
            // DGridTell
            // 
            this.DGridTell.AllowUserToAddRows = false;
            this.DGridTell.AllowUserToDeleteRows = false;
            this.DGridTell.AllowUserToResizeColumns = false;
            this.DGridTell.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DGridTell.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGridTell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGridTell.AutoGenerateColumns = false;
            this.DGridTell.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGridTell.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGridTell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridTell.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tRadif,
            this.tellDataGridViewTextBoxColumn,
            this.Title,
            this.dgTellGuid,
            this.modifiedDataGridViewTextBoxColumn,
            this.statusDataGridViewCheckBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.groupDataGridViewTextBoxColumn});
            this.DGridTell.DataSource = this.phoneBookBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGridTell.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGridTell.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGridTell.Location = new System.Drawing.Point(3, 37);
            this.DGridTell.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGridTell.Name = "DGridTell";
            this.DGridTell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGridTell.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGridTell.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGridTell.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.DGridTell.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGridTell.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.DGridTell.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGridTell.Size = new System.Drawing.Size(704, 192);
            this.DGridTell.TabIndex = 55720;
            this.DGridTell.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGridTell_CellFormatting);
            // 
            // tRadif
            // 
            this.tRadif.HeaderText = "ردیف";
            this.tRadif.Name = "tRadif";
            this.tRadif.ReadOnly = true;
            this.tRadif.Width = 50;
            // 
            // tellDataGridViewTextBoxColumn
            // 
            this.tellDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tellDataGridViewTextBoxColumn.DataPropertyName = "Tell";
            this.tellDataGridViewTextBoxColumn.HeaderText = "شماره تماس";
            this.tellDataGridViewTextBoxColumn.Name = "tellDataGridViewTextBoxColumn";
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.DataPropertyName = "Title";
            this.Title.HeaderText = "عنوان";
            this.Title.Name = "Title";
            // 
            // dgTellGuid
            // 
            this.dgTellGuid.DataPropertyName = "Guid";
            this.dgTellGuid.HeaderText = "Guid";
            this.dgTellGuid.Name = "dgTellGuid";
            this.dgTellGuid.Visible = false;
            // 
            // modifiedDataGridViewTextBoxColumn
            // 
            this.modifiedDataGridViewTextBoxColumn.DataPropertyName = "Modified";
            this.modifiedDataGridViewTextBoxColumn.HeaderText = "Modified";
            this.modifiedDataGridViewTextBoxColumn.Name = "modifiedDataGridViewTextBoxColumn";
            this.modifiedDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewCheckBoxColumn
            // 
            this.statusDataGridViewCheckBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewCheckBoxColumn.HeaderText = "Status";
            this.statusDataGridViewCheckBoxColumn.Name = "statusDataGridViewCheckBoxColumn";
            this.statusDataGridViewCheckBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Visible = false;
            // 
            // groupDataGridViewTextBoxColumn
            // 
            this.groupDataGridViewTextBoxColumn.DataPropertyName = "Group";
            this.groupDataGridViewTextBoxColumn.HeaderText = "Group";
            this.groupDataGridViewTextBoxColumn.Name = "groupDataGridViewTextBoxColumn";
            this.groupDataGridViewTextBoxColumn.Visible = false;
            // 
            // phoneBookBindingSource
            // 
            this.phoneBookBindingSource.DataSource = typeof(EntityCache.Bussines.PhoneBookBussines);
            // 
            // cmbTitles
            // 
            this.cmbTitles.FormattingEnabled = true;
            this.cmbTitles.Location = new System.Drawing.Point(65, 3);
            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.Size = new System.Drawing.Size(222, 28);
            this.cmbTitles.TabIndex = 55719;
            // 
            // btnDelTell
            // 
            this.btnDelTell.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelTell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelTell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDelTell.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnDelTell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelTell.Image = global::Peoples.Properties.Resources.tab_close_;
            this.btnDelTell.Location = new System.Drawing.Point(3, 3);
            this.btnDelTell.Name = "btnDelTell";
            this.btnDelTell.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnDelTell.Size = new System.Drawing.Size(25, 27);
            this.btnDelTell.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnDelTell.TabIndex = 55718;
            this.btnDelTell.TextColor = System.Drawing.Color.Black;
            this.btnDelTell.Click += new System.EventHandler(this.btnDelTell_Click);
            // 
            // btnInsTell
            // 
            this.btnInsTell.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnInsTell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInsTell.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInsTell.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnInsTell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsTell.Image = global::Peoples.Properties.Resources.tab_checkbox__;
            this.btnInsTell.Location = new System.Drawing.Point(34, 3);
            this.btnInsTell.Name = "btnInsTell";
            this.btnInsTell.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnInsTell.Size = new System.Drawing.Size(25, 27);
            this.btnInsTell.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnInsTell.TabIndex = 55715;
            this.btnInsTell.TextColor = System.Drawing.Color.Black;
            this.btnInsTell.Click += new System.EventHandler(this.btnInsTell_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(293, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 20);
            this.label17.TabIndex = 55716;
            this.label17.Text = "عنوان";
            // 
            // txtTell
            // 
            this.txtTell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTell.Location = new System.Drawing.Point(336, 3);
            this.txtTell.Name = "txtTell";
            this.txtTell.Size = new System.Drawing.Size(301, 27);
            this.txtTell.TabIndex = 55714;
            this.txtTell.Enter += new System.EventHandler(this.txtTell_Enter);
            this.txtTell.Leave += new System.EventHandler(this.txtTell_Leave);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(643, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 20);
            this.label12.TabIndex = 55717;
            this.label12.Text = "شماره تماس";
            // 
            // UcPeople_PhoneBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grpPanel);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcPeople_PhoneBook";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(721, 261);
            this.grpPanel.ResumeLayout(false);
            this.grpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridTell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phoneBookBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel grpPanel;
        private System.Windows.Forms.ComboBox cmbTitles;
        private DevComponents.DotNetBar.ButtonX btnDelTell;
        private DevComponents.DotNetBar.ButtonX btnInsTell;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTell;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource phoneBookBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGridTell;
        private System.Windows.Forms.DataGridViewTextBoxColumn tRadif;
        private System.Windows.Forms.DataGridViewTextBoxColumn tellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgTellGuid;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn statusDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupDataGridViewTextBoxColumn;
    }
}
