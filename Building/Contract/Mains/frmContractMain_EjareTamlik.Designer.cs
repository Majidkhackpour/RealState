
namespace Building.Contract
{
    partial class frmContractMain_EjareTamlik
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContractMain_EjareTamlik));
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucFSide = new Peoples.UcPeopleContract();
            this.ucSecondSide = new Peoples.UcPeopleContract();
            this.btnCommition = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucContractDescription1 = new Building.UserControls.Contract.Public.UcContractDescription();
            this.ucContractEjareTamlik_Notice1 = new Building.UserControls.Contract.EjareTamlik.UcContractEjareTamlik_Notice();
            this.ucContractEjareTamlik_71 = new Building.UserControls.Contract.EjareTamlik.UcContractEjareTamlik_7();
            this.ucContractEjareTamlik_61 = new Building.UserControls.Contract.EjareTamlik.UcContractEjareTamlik_6();
            this.ucContractEjareTamlik_51 = new Building.UserControls.Contract.EjareTamlik.UcContractEjareTamlik_5();
            this.ucContractEjareTamlik_41 = new Building.UserControls.Contract.EjareTamlik.UcContractEjareTamlik_4();
            this.ucContractRahn_31 = new Building.UserControls.Contract.Rahn.UcContractRahn_3();
            this.ucContractEjareTamlik_21 = new Building.UserControls.Contract.EjareTamlik.UcContractEjareTamlik_2();
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
            this.buttonX1.Location = new System.Drawing.Point(548, 554);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.buttonX1.Size = new System.Drawing.Size(125, 31);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.buttonX1.TabIndex = 55811;
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
            this.btnCancel.Location = new System.Drawing.Point(31, 554);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55814;
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
            this.btnFinish.Location = new System.Drawing.Point(679, 554);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55812;
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
            this.splitContainer1.Size = new System.Drawing.Size(792, 260);
            this.splitContainer1.SplitterDistance = 396;
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
            this.ucFSide.Size = new System.Drawing.Size(396, 260);
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
            this.ucSecondSide.Size = new System.Drawing.Size(392, 260);
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
            this.btnCommition.Location = new System.Drawing.Point(548, 554);
            this.btnCommition.Name = "btnCommition";
            this.btnCommition.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCommition.Size = new System.Drawing.Size(125, 31);
            this.btnCommition.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCommition.TabIndex = 55813;
            this.btnCommition.Text = "کمیسیون و مالی (F8)";
            this.btnCommition.TextColor = System.Drawing.Color.Black;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ucContractDescription1);
            this.panel1.Controls.Add(this.ucContractEjareTamlik_Notice1);
            this.panel1.Controls.Add(this.ucContractEjareTamlik_71);
            this.panel1.Controls.Add(this.ucContractEjareTamlik_61);
            this.panel1.Controls.Add(this.ucContractEjareTamlik_51);
            this.panel1.Controls.Add(this.ucContractEjareTamlik_41);
            this.panel1.Controls.Add(this.ucContractRahn_31);
            this.panel1.Controls.Add(this.ucContractEjareTamlik_21);
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.ucContractHeader1);
            this.panel1.Location = new System.Drawing.Point(3, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 529);
            this.panel1.TabIndex = 55810;
            // 
            // ucContractDescription1
            // 
            this.ucContractDescription1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractDescription1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractDescription1.Description = "";
            this.ucContractDescription1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractDescription1.Location = new System.Drawing.Point(11, 2098);
            this.ucContractDescription1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractDescription1.Name = "ucContractDescription1";
            this.ucContractDescription1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractDescription1.Size = new System.Drawing.Size(788, 199);
            this.ucContractDescription1.TabIndex = 9;
            this.ucContractDescription1.Witness1 = "";
            this.ucContractDescription1.Witness2 = "";
            // 
            // ucContractEjareTamlik_Notice1
            // 
            this.ucContractEjareTamlik_Notice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractEjareTamlik_Notice1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractEjareTamlik_Notice1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractEjareTamlik_Notice1.Location = new System.Drawing.Point(11, 1714);
            this.ucContractEjareTamlik_Notice1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractEjareTamlik_Notice1.Name = "ucContractEjareTamlik_Notice1";
            this.ucContractEjareTamlik_Notice1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractEjareTamlik_Notice1.Size = new System.Drawing.Size(788, 374);
            this.ucContractEjareTamlik_Notice1.TabIndex = 8;
            // 
            // ucContractEjareTamlik_71
            // 
            this.ucContractEjareTamlik_71.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractEjareTamlik_71.BackColor = System.Drawing.Color.Transparent;
            this.ucContractEjareTamlik_71.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractEjareTamlik_71.Location = new System.Drawing.Point(11, 1540);
            this.ucContractEjareTamlik_71.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractEjareTamlik_71.Name = "ucContractEjareTamlik_71";
            this.ucContractEjareTamlik_71.Size = new System.Drawing.Size(788, 167);
            this.ucContractEjareTamlik_71.TabIndex = 7;
            this.ucContractEjareTamlik_71.TaxPercent = 0F;
            // 
            // ucContractEjareTamlik_61
            // 
            this.ucContractEjareTamlik_61.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractEjareTamlik_61.BackColor = System.Drawing.Color.Transparent;
            this.ucContractEjareTamlik_61.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractEjareTamlik_61.Location = new System.Drawing.Point(11, 1444);
            this.ucContractEjareTamlik_61.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractEjareTamlik_61.Name = "ucContractEjareTamlik_61";
            this.ucContractEjareTamlik_61.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractEjareTamlik_61.Size = new System.Drawing.Size(789, 86);
            this.ucContractEjareTamlik_61.TabIndex = 6;
            // 
            // ucContractEjareTamlik_51
            // 
            this.ucContractEjareTamlik_51.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractEjareTamlik_51.BackColor = System.Drawing.Color.Transparent;
            this.ucContractEjareTamlik_51.Delay = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractEjareTamlik_51.DocumentAsjust = "0";
            this.ucContractEjareTamlik_51.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractEjareTamlik_51.Location = new System.Drawing.Point(11, 965);
            this.ucContractEjareTamlik_51.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractEjareTamlik_51.Name = "ucContractEjareTamlik_51";
            this.ucContractEjareTamlik_51.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractEjareTamlik_51.SetDocDate = new System.DateTime(2021, 12, 25, 0, 0, 0, 0);
            this.ucContractEjareTamlik_51.SetDocNo = 0;
            this.ucContractEjareTamlik_51.SetDocPlace = "";
            this.ucContractEjareTamlik_51.Size = new System.Drawing.Size(785, 477);
            this.ucContractEjareTamlik_51.TabIndex = 5;
            // 
            // ucContractEjareTamlik_41
            // 
            this.ucContractEjareTamlik_41.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractEjareTamlik_41.BackColor = System.Drawing.Color.Transparent;
            this.ucContractEjareTamlik_41.BankName = "";
            this.ucContractEjareTamlik_41.CheckNo = "";
            this.ucContractEjareTamlik_41.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractEjareTamlik_41.Location = new System.Drawing.Point(11, 838);
            this.ucContractEjareTamlik_41.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractEjareTamlik_41.Name = "ucContractEjareTamlik_41";
            this.ucContractEjareTamlik_41.PishPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractEjareTamlik_41.Shobe = "";
            this.ucContractEjareTamlik_41.Size = new System.Drawing.Size(785, 122);
            this.ucContractEjareTamlik_41.TabIndex = 4;
            this.ucContractEjareTamlik_41.TotalEjare = new decimal(new int[] {
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
            this.ucContractRahn_31.DischargeDate = new System.DateTime(2021, 12, 25, 0, 0, 0, 0);
            this.ucContractRahn_31.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractRahn_31.FromDate = new System.DateTime(2021, 12, 25, 0, 0, 0, 0);
            this.ucContractRahn_31.Location = new System.Drawing.Point(11, 725);
            this.ucContractRahn_31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractRahn_31.Name = "ucContractRahn_31";
            this.ucContractRahn_31.Size = new System.Drawing.Size(789, 108);
            this.ucContractRahn_31.TabIndex = 3;
            this.ucContractRahn_31.Term = 0;
            // 
            // ucContractEjareTamlik_21
            // 
            this.ucContractEjareTamlik_21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractEjareTamlik_21.BackColor = System.Drawing.Color.Transparent;
            this.ucContractEjareTamlik_21.BuildingType = "";
            this.ucContractEjareTamlik_21.Dong = 1F;
            this.ucContractEjareTamlik_21.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractEjareTamlik_21.Location = new System.Drawing.Point(11, 489);
            this.ucContractEjareTamlik_21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractEjareTamlik_21.Masahat = 0F;
            this.ucContractEjareTamlik_21.Name = "ucContractEjareTamlik_21";
            this.ucContractEjareTamlik_21.Office = "";
            this.ucContractEjareTamlik_21.OwnerGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucContractEjareTamlik_21.Page = 0;
            this.ucContractEjareTamlik_21.ParkingMasahat = 0F;
            this.ucContractEjareTamlik_21.ParkingNo = 0;
            this.ucContractEjareTamlik_21.PartNo = 0;
            this.ucContractEjareTamlik_21.PayankarDate = new System.DateTime(2021, 12, 25, 0, 0, 0, 0);
            this.ucContractEjareTamlik_21.PayankarNo = "";
            this.ucContractEjareTamlik_21.PhoneCount = 0;
            this.ucContractEjareTamlik_21.PhoneNumber = "";
            this.ucContractEjareTamlik_21.RegistryNo = "";
            this.ucContractEjareTamlik_21.RegistryNoOrigin = "";
            this.ucContractEjareTamlik_21.RegistryNoSub = "";
            this.ucContractEjareTamlik_21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractEjareTamlik_21.SanadSerial = "";
            this.ucContractEjareTamlik_21.Size = new System.Drawing.Size(789, 231);
            this.ucContractEjareTamlik_21.StoreMasahat = 0F;
            this.ucContractEjareTamlik_21.StoreNo = 0;
            this.ucContractEjareTamlik_21.TabIndex = 2;
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
            this.ucContractHeader1.Size = new System.Drawing.Size(792, 213);
            this.ucContractHeader1.TabIndex = 0;
            this.ucContractHeader1.Title = "مبایعه نامه";
            // 
            // frmContractMain_EjareTamlik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCommition);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(821, 600);
            this.Name = "frmContractMain_EjareTamlik";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmContractMain_EjareTamlik_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContractMain_EjareTamlik_KeyDown);
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
        private System.Windows.Forms.Panel panel1;
        private UserControls.Contract.Public.UcContractHeader ucContractHeader1;
        private UserControls.Contract.EjareTamlik.UcContractEjareTamlik_2 ucContractEjareTamlik_21;
        private UserControls.Contract.Rahn.UcContractRahn_3 ucContractRahn_31;
        private UserControls.Contract.EjareTamlik.UcContractEjareTamlik_4 ucContractEjareTamlik_41;
        private UserControls.Contract.EjareTamlik.UcContractEjareTamlik_5 ucContractEjareTamlik_51;
        private UserControls.Contract.EjareTamlik.UcContractEjareTamlik_7 ucContractEjareTamlik_71;
        private UserControls.Contract.EjareTamlik.UcContractEjareTamlik_6 ucContractEjareTamlik_61;
        private UserControls.Contract.Public.UcContractDescription ucContractDescription1;
        private UserControls.Contract.EjareTamlik.UcContractEjareTamlik_Notice ucContractEjareTamlik_Notice1;
    }
}