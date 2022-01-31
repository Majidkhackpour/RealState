
namespace Building.Buildings
{
    partial class frmBuildingLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuildingLog));
            this.UserLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dateShDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildingGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.UserLogBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // UserLogBindingSource
            // 
            this.UserLogBindingSource.DataSource = typeof(EntityCache.Bussines.UserLogBussines);
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
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
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
            this.timeDataGridViewTextBoxColumn,
            this.actionNameDataGridViewTextBoxColumn,
            this.partNameDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.guidDataGridViewTextBoxColumn,
            this.userGuidDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.actionDataGridViewTextBoxColumn,
            this.partDataGridViewTextBoxColumn,
            this.buildingGuidDataGridViewTextBoxColumn});
            this.DGrid.DataSource = this.UserLogBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.DGrid.Location = new System.Drawing.Point(1, 29);
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
            this.DGrid.Size = new System.Drawing.Size(797, 567);
            this.DGrid.TabIndex = 55745;
            // 
            // dateShDataGridViewTextBoxColumn
            // 
            this.dateShDataGridViewTextBoxColumn.DataPropertyName = "DateSh";
            this.dateShDataGridViewTextBoxColumn.HeaderText = "تاریخ";
            this.dateShDataGridViewTextBoxColumn.Name = "dateShDataGridViewTextBoxColumn";
            this.dateShDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateShDataGridViewTextBoxColumn.Width = 90;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "زمان";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeDataGridViewTextBoxColumn.Width = 80;
            // 
            // actionNameDataGridViewTextBoxColumn
            // 
            this.actionNameDataGridViewTextBoxColumn.DataPropertyName = "ActionName";
            this.actionNameDataGridViewTextBoxColumn.HeaderText = "عملیات";
            this.actionNameDataGridViewTextBoxColumn.Name = "actionNameDataGridViewTextBoxColumn";
            this.actionNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.actionNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // partNameDataGridViewTextBoxColumn
            // 
            this.partNameDataGridViewTextBoxColumn.DataPropertyName = "PartName";
            this.partNameDataGridViewTextBoxColumn.HeaderText = "بخش";
            this.partNameDataGridViewTextBoxColumn.Name = "partNameDataGridViewTextBoxColumn";
            this.partNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "کاربر";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "شرح";
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
            // userGuidDataGridViewTextBoxColumn
            // 
            this.userGuidDataGridViewTextBoxColumn.DataPropertyName = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.HeaderText = "UserGuid";
            this.userGuidDataGridViewTextBoxColumn.Name = "userGuidDataGridViewTextBoxColumn";
            this.userGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.userGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Visible = false;
            // 
            // actionDataGridViewTextBoxColumn
            // 
            this.actionDataGridViewTextBoxColumn.DataPropertyName = "Action";
            this.actionDataGridViewTextBoxColumn.HeaderText = "Action";
            this.actionDataGridViewTextBoxColumn.Name = "actionDataGridViewTextBoxColumn";
            this.actionDataGridViewTextBoxColumn.ReadOnly = true;
            this.actionDataGridViewTextBoxColumn.Visible = false;
            // 
            // partDataGridViewTextBoxColumn
            // 
            this.partDataGridViewTextBoxColumn.DataPropertyName = "Part";
            this.partDataGridViewTextBoxColumn.HeaderText = "Part";
            this.partDataGridViewTextBoxColumn.Name = "partDataGridViewTextBoxColumn";
            this.partDataGridViewTextBoxColumn.ReadOnly = true;
            this.partDataGridViewTextBoxColumn.Visible = false;
            // 
            // buildingGuidDataGridViewTextBoxColumn
            // 
            this.buildingGuidDataGridViewTextBoxColumn.DataPropertyName = "BuildingGuid";
            this.buildingGuidDataGridViewTextBoxColumn.HeaderText = "BuildingGuid";
            this.buildingGuidDataGridViewTextBoxColumn.Name = "buildingGuidDataGridViewTextBoxColumn";
            this.buildingGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildingGuidDataGridViewTextBoxColumn.Visible = false;
            // 
            // frmBuildingLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.DGrid);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmBuildingLog";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBuildingLog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuildingLog_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UserLogBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource UserLogBindingSource;
        private DevComponents.DotNetBar.Controls.DataGridViewX DGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateShDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn partDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildingGuidDataGridViewTextBoxColumn;
    }
}