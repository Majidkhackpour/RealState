
namespace Building.Contract
{
    partial class frmContractMain_Rahn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContractMain_Rahn));
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucFSide = new Peoples.UcPeopleContract();
            this.ucSecondSide = new Peoples.UcPeopleContract();
            this.btnCommition = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucContractRahn_41 = new Building.UserControls.Contract.Rahn.UcContractRahn_4();
            this.ucContractRahn_31 = new Building.UserControls.Contract.Rahn.UcContractRahn_3();
            this.ucContractRahn_21 = new Building.UserControls.Contract.Rahn.UcContractRahn_2();
            this.ucContractHeader1 = new Building.UserControls.Contract.Public.UcContractHeader();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonX1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX1.Location = new System.Drawing.Point(550, 562);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.buttonX1.Size = new System.Drawing.Size(125, 31);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.buttonX1.TabIndex = 55806;
            this.buttonX1.Text = "کمیسیون و مالی (F8)";
            this.buttonX1.TextColor = System.Drawing.Color.Black;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::Building.Properties.Resources.tab_close_;
            this.btnCancel.Location = new System.Drawing.Point(33, 562);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55809;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFinish.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFinish.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinish.Image = global::Building.Properties.Resources.tab_checkbox__;
            this.btnFinish.Location = new System.Drawing.Point(681, 562);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55807;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(4, 226);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucFSide);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucSecondSide);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(791, 260);
            this.splitContainer1.SplitterDistance = 397;
            this.splitContainer1.TabIndex = 1;
            // 
            // ucFSide
            // 
            this.ucFSide.BackColor = System.Drawing.Color.Transparent;
            this.ucFSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFSide.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFSide.Guid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucFSide.Location = new System.Drawing.Point(0, 0);
            this.ucFSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFSide.Name = "ucFSide";
            this.ucFSide.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFSide.Size = new System.Drawing.Size(397, 260);
            this.ucFSide.TabIndex = 0;
            this.ucFSide.Title = "مشخصات فروشنده";
            // 
            // ucSecondSide
            // 
            this.ucSecondSide.BackColor = System.Drawing.Color.Transparent;
            this.ucSecondSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucSecondSide.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucSecondSide.Guid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucSecondSide.Location = new System.Drawing.Point(0, 0);
            this.ucSecondSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSecondSide.Name = "ucSecondSide";
            this.ucSecondSide.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucSecondSide.Size = new System.Drawing.Size(390, 260);
            this.ucSecondSide.TabIndex = 1;
            this.ucSecondSide.Title = "مشخصات خریدار";
            // 
            // btnCommition
            // 
            this.btnCommition.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCommition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommition.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCommition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCommition.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCommition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCommition.Location = new System.Drawing.Point(550, 562);
            this.btnCommition.Name = "btnCommition";
            this.btnCommition.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCommition.Size = new System.Drawing.Size(125, 31);
            this.btnCommition.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCommition.TabIndex = 55808;
            this.btnCommition.Text = "کمیسیون و مالی (F8)";
            this.btnCommition.TextColor = System.Drawing.Color.Black;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ucContractRahn_41);
            this.panel1.Controls.Add(this.ucContractRahn_31);
            this.panel1.Controls.Add(this.ucContractRahn_21);
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.ucContractHeader1);
            this.panel1.Location = new System.Drawing.Point(5, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 529);
            this.panel1.TabIndex = 55805;
            // 
            // ucContractRahn_41
            // 
            this.ucContractRahn_41.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractRahn_41.BackColor = System.Drawing.Color.Transparent;
            this.ucContractRahn_41.BankName = "";
            this.ucContractRahn_41.CheckNoFrom = "";
            this.ucContractRahn_41.CheckNoTo = "";
            this.ucContractRahn_41.Ejare = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractRahn_41.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractRahn_41.Location = new System.Drawing.Point(4, 842);
            this.ucContractRahn_41.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractRahn_41.Name = "ucContractRahn_41";
            this.ucContractRahn_41.Rahn = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractRahn_41.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractRahn_41.SarresidFrom = null;
            this.ucContractRahn_41.SarresidTo = null;
            this.ucContractRahn_41.Shobe = "";
            this.ucContractRahn_41.Size = new System.Drawing.Size(791, 168);
            this.ucContractRahn_41.TabIndex = 4;
            this.ucContractRahn_41.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucContractRahn_31
            // 
            this.ucContractRahn_31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractRahn_31.BackColor = System.Drawing.Color.Transparent;
            this.ucContractRahn_31.ContractDateSh = "1400/12/29";
            this.ucContractRahn_31.DischargeDate = new System.DateTime(2021, 12, 14, 0, 0, 0, 0);
            this.ucContractRahn_31.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractRahn_31.FromDate = new System.DateTime(2021, 12, 14, 0, 0, 0, 0);
            this.ucContractRahn_31.Location = new System.Drawing.Point(4, 728);
            this.ucContractRahn_31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractRahn_31.Name = "ucContractRahn_31";
            this.ucContractRahn_31.Size = new System.Drawing.Size(791, 108);
            this.ucContractRahn_31.TabIndex = 3;
            this.ucContractRahn_31.Term = 0;
            // 
            // ucContractRahn_21
            // 
            this.ucContractRahn_21.Address = "";
            this.ucContractRahn_21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractRahn_21.BackColor = System.Drawing.Color.Transparent;
            this.ucContractRahn_21.BuildingNumber = "";
            this.ucContractRahn_21.BuildingPlack = "";
            this.ucContractRahn_21.BuildingType = "";
            this.ucContractRahn_21.Dong = 1F;
            this.ucContractRahn_21.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractRahn_21.Location = new System.Drawing.Point(4, 489);
            this.ucContractRahn_21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractRahn_21.Masahat = 0F;
            this.ucContractRahn_21.Name = "ucContractRahn_21";
            this.ucContractRahn_21.Office = "";
            this.ucContractRahn_21.OwnerGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucContractRahn_21.Page = 0;
            this.ucContractRahn_21.ParkingNo = 0;
            this.ucContractRahn_21.PhoneCount = 0;
            this.ucContractRahn_21.PhoneNumber = "";
            this.ucContractRahn_21.RegistryNo = "";
            this.ucContractRahn_21.RegistryNoOrigin = "";
            this.ucContractRahn_21.RegistryNoSub = "";
            this.ucContractRahn_21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractRahn_21.RoomCount = 0;
            this.ucContractRahn_21.SanadSerial = "";
            this.ucContractRahn_21.Size = new System.Drawing.Size(791, 233);
            this.ucContractRahn_21.StoreMasahat = 0F;
            this.ucContractRahn_21.StoreNo = 0;
            this.ucContractRahn_21.TabaqeNo = 0;
            this.ucContractRahn_21.TabIndex = 2;
            this.ucContractRahn_21.VahedNo = 0;
            this.ucContractRahn_21.Zip = "";
            // 
            // ucContractHeader1
            // 
            this.ucContractHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractHeader1.CodeInArchive = "";
            this.ucContractHeader1.ContractCode = ((long)(4));
            this.ucContractHeader1.ContractDate = new System.DateTime(2021, 11, 23, 0, 0, 0, 0);
            this.ucContractHeader1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractHeader1.HologramCode = "";
            this.ucContractHeader1.Location = new System.Drawing.Point(4, 5);
            this.ucContractHeader1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractHeader1.Name = "ucContractHeader1";
            this.ucContractHeader1.RealStateCode = "";
            this.ucContractHeader1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractHeader1.Size = new System.Drawing.Size(791, 213);
            this.ucContractHeader1.TabIndex = 0;
            this.ucContractHeader1.Title = "مبایعه نامه";
            // 
            // frmContractMain_Rahn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 600);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCommition);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(821, 600);
            this.Name = "frmContractMain_Rahn";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmContractMain_Rahn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContractMain_Rahn_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Peoples.UcPeopleContract ucFSide;
        private Peoples.UcPeopleContract ucSecondSide;
        private DevComponents.DotNetBar.ButtonX btnCommition;
        private UserControls.Contract.Public.UcContractHeader ucContractHeader1;
        private System.Windows.Forms.Panel panel1;
        private UserControls.Contract.Rahn.UcContractRahn_2 ucContractRahn_21;
        private UserControls.Contract.Rahn.UcContractRahn_3 ucContractRahn_31;
        private UserControls.Contract.Rahn.UcContractRahn_4 ucContractRahn_41;
    }
}