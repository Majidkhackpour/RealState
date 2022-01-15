
namespace Building.Contract
{
    partial class frmContractMain_PishForoush
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
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucFSide = new Peoples.UcPeopleContract();
            this.ucSecondSide = new Peoples.UcPeopleContract();
            this.btnCommition = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucContractHeader1 = new Building.UserControls.Contract.Public.UcContractHeader();
            this.ucContractPishForoush_21 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_2();
            this.ucContractPishForoush_41 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_4();
            this.ucContractPishForoush_51 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_5();
            this.ucContractPishForoush_61 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_6();
            this.ucContractPishForoush_71 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_7();
            this.ucContractPishForoush_81 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_8();
            this.ucContractPishForoush_91 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_9();
            this.ucContractPishForoush_101 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_10();
            this.ucContractPishForoush_111 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_11();
            this.ucContractPishForoush_Notice1 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_Notice();
            this.ucContractDescription1 = new Building.UserControls.Contract.Public.UcContractDescription();
            this.ucContractPishForoush_31 = new Building.UserControls.Contract.PishForoush.UcContractPishForoush_3();
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
            this.buttonX1.Location = new System.Drawing.Point(547, 554);
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
            this.btnCancel.Location = new System.Drawing.Point(30, 554);
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
            this.btnFinish.Location = new System.Drawing.Point(678, 554);
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
            this.ucSecondSide.Size = new System.Drawing.Size(391, 260);
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
            this.btnCommition.Location = new System.Drawing.Point(547, 554);
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
            this.panel1.Controls.Add(this.ucContractPishForoush_Notice1);
            this.panel1.Controls.Add(this.ucContractPishForoush_111);
            this.panel1.Controls.Add(this.ucContractPishForoush_101);
            this.panel1.Controls.Add(this.ucContractPishForoush_91);
            this.panel1.Controls.Add(this.ucContractPishForoush_81);
            this.panel1.Controls.Add(this.ucContractPishForoush_71);
            this.panel1.Controls.Add(this.ucContractPishForoush_61);
            this.panel1.Controls.Add(this.ucContractPishForoush_51);
            this.panel1.Controls.Add(this.ucContractPishForoush_41);
            this.panel1.Controls.Add(this.ucContractPishForoush_31);
            this.panel1.Controls.Add(this.ucContractPishForoush_21);
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.ucContractHeader1);
            this.panel1.Location = new System.Drawing.Point(2, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 529);
            this.panel1.TabIndex = 55810;
            // 
            // ucContractHeader1
            // 
            this.ucContractHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractHeader1.CodeInArchive = "";
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
            // ucContractPishForoush_21
            // 
            this.ucContractPishForoush_21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_21.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_21.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_21.Location = new System.Drawing.Point(4, 491);
            this.ucContractPishForoush_21.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_21.Name = "ucContractPishForoush_21";
            this.ucContractPishForoush_21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_21.Size = new System.Drawing.Size(792, 71);
            this.ucContractPishForoush_21.TabIndex = 2;
            // 
            // ucContractPishForoush_31
            // 
            this.ucContractPishForoush_31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_31.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_31.Consumable = "";
            this.ucContractPishForoush_31.Dong = 1F;
            this.ucContractPishForoush_31.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_31.Location = new System.Drawing.Point(4, 566);
            this.ucContractPishForoush_31.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_31.Masahat = 0F;
            this.ucContractPishForoush_31.Name = "ucContractPishForoush_31";
            this.ucContractPishForoush_31.OwnerGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucContractPishForoush_31.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_31.RoomCount = 0;
            this.ucContractPishForoush_31.Side = null;
            this.ucContractPishForoush_31.Size = new System.Drawing.Size(792, 227);
            this.ucContractPishForoush_31.TabaqeCount = 0;
            this.ucContractPishForoush_31.TabaqeNo = 0;
            this.ucContractPishForoush_31.TabIndex = 3;
            this.ucContractPishForoush_31.VahedCount = 0;
            this.ucContractPishForoush_31.VahedNo = 0;
            // 
            // ucContractPishForoush_41
            // 
            this.ucContractPishForoush_41.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_41.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_41.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_41.Location = new System.Drawing.Point(4, 798);
            this.ucContractPishForoush_41.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_41.Name = "ucContractPishForoush_41";
            this.ucContractPishForoush_41.NaqdPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractPishForoush_41.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_41.Size = new System.Drawing.Size(792, 98);
            this.ucContractPishForoush_41.TabIndex = 4;
            this.ucContractPishForoush_41.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucContractPishForoush_51
            // 
            this.ucContractPishForoush_51.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_51.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_51.DischargeDate = new System.DateTime(2022, 1, 5, 0, 0, 0, 0);
            this.ucContractPishForoush_51.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_51.Location = new System.Drawing.Point(4, 899);
            this.ucContractPishForoush_51.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_51.Name = "ucContractPishForoush_51";
            this.ucContractPishForoush_51.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_51.SetDocDate = new System.DateTime(2022, 1, 5, 0, 0, 0, 0);
            this.ucContractPishForoush_51.SetDocNo = 0;
            this.ucContractPishForoush_51.SetDocPlace = "";
            this.ucContractPishForoush_51.Size = new System.Drawing.Size(792, 222);
            this.ucContractPishForoush_51.TabIndex = 5;
            // 
            // ucContractPishForoush_61
            // 
            this.ucContractPishForoush_61.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_61.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_61.FirstDelay = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractPishForoush_61.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_61.Location = new System.Drawing.Point(4, 1124);
            this.ucContractPishForoush_61.ManufacturingLicenseDate = new System.DateTime(2022, 1, 5, 0, 0, 0, 0);
            this.ucContractPishForoush_61.ManufacturingLicensePlace = "";
            this.ucContractPishForoush_61.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_61.Name = "ucContractPishForoush_61";
            this.ucContractPishForoush_61.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_61.SecondDelay = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractPishForoush_61.Size = new System.Drawing.Size(792, 564);
            this.ucContractPishForoush_61.TabIndex = 6;
            // 
            // ucContractPishForoush_71
            // 
            this.ucContractPishForoush_71.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_71.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_71.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_71.Location = new System.Drawing.Point(4, 1693);
            this.ucContractPishForoush_71.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_71.Name = "ucContractPishForoush_71";
            this.ucContractPishForoush_71.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_71.Size = new System.Drawing.Size(792, 67);
            this.ucContractPishForoush_71.TabIndex = 7;
            // 
            // ucContractPishForoush_81
            // 
            this.ucContractPishForoush_81.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_81.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_81.DocumentAdjustment = "";
            this.ucContractPishForoush_81.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_81.Location = new System.Drawing.Point(4, 1762);
            this.ucContractPishForoush_81.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_81.Name = "ucContractPishForoush_81";
            this.ucContractPishForoush_81.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_81.Size = new System.Drawing.Size(792, 67);
            this.ucContractPishForoush_81.TabIndex = 8;
            // 
            // ucContractPishForoush_91
            // 
            this.ucContractPishForoush_91.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_91.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_91.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_91.Location = new System.Drawing.Point(4, 1834);
            this.ucContractPishForoush_91.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_91.Name = "ucContractPishForoush_91";
            this.ucContractPishForoush_91.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_91.Size = new System.Drawing.Size(792, 67);
            this.ucContractPishForoush_91.TabIndex = 9;
            // 
            // ucContractPishForoush_101
            // 
            this.ucContractPishForoush_101.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_101.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_101.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_101.Location = new System.Drawing.Point(4, 1906);
            this.ucContractPishForoush_101.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_101.Name = "ucContractPishForoush_101";
            this.ucContractPishForoush_101.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_101.Size = new System.Drawing.Size(792, 127);
            this.ucContractPishForoush_101.TabIndex = 10;
            // 
            // ucContractPishForoush_111
            // 
            this.ucContractPishForoush_111.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_111.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_111.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_111.Location = new System.Drawing.Point(4, 2038);
            this.ucContractPishForoush_111.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_111.Name = "ucContractPishForoush_111";
            this.ucContractPishForoush_111.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_111.Size = new System.Drawing.Size(792, 67);
            this.ucContractPishForoush_111.TabIndex = 11;
            // 
            // ucContractPishForoush_Notice1
            // 
            this.ucContractPishForoush_Notice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractPishForoush_Notice1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractPishForoush_Notice1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractPishForoush_Notice1.Location = new System.Drawing.Point(4, 2110);
            this.ucContractPishForoush_Notice1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractPishForoush_Notice1.Name = "ucContractPishForoush_Notice1";
            this.ucContractPishForoush_Notice1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractPishForoush_Notice1.Size = new System.Drawing.Size(792, 397);
            this.ucContractPishForoush_Notice1.TabIndex = 12;
            // 
            // ucContractDescription1
            // 
            this.ucContractDescription1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractDescription1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractDescription1.Description = "";
            this.ucContractDescription1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractDescription1.Location = new System.Drawing.Point(4, 2512);
            this.ucContractDescription1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractDescription1.Name = "ucContractDescription1";
            this.ucContractDescription1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractDescription1.Size = new System.Drawing.Size(792, 199);
            this.ucContractDescription1.TabIndex = 13;
            this.ucContractDescription1.Witness1 = "";
            this.ucContractDescription1.Witness2 = "";
            // 
            // frmContractMain_PishForoush
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
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(821, 600);
            this.Name = "frmContractMain_PishForoush";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmContractMain_PishForoush_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContractMain_PishForoush_KeyDown);
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
        private UserControls.Contract.PishForoush.UcContractPishForoush_2 ucContractPishForoush_21;
        private UserControls.Contract.PishForoush.UcContractPishForoush_3 ucContractPishForoush_31;
        private UserControls.Contract.PishForoush.UcContractPishForoush_4 ucContractPishForoush_41;
        private UserControls.Contract.PishForoush.UcContractPishForoush_5 ucContractPishForoush_51;
        private UserControls.Contract.PishForoush.UcContractPishForoush_6 ucContractPishForoush_61;
        private UserControls.Contract.PishForoush.UcContractPishForoush_7 ucContractPishForoush_71;
        private UserControls.Contract.PishForoush.UcContractPishForoush_8 ucContractPishForoush_81;
        private UserControls.Contract.PishForoush.UcContractPishForoush_9 ucContractPishForoush_91;
        private UserControls.Contract.PishForoush.UcContractPishForoush_10 ucContractPishForoush_101;
        private UserControls.Contract.PishForoush.UcContractPishForoush_11 ucContractPishForoush_111;
        private UserControls.Contract.PishForoush.UcContractPishForoush_Notice ucContractPishForoush_Notice1;
        private UserControls.Contract.Public.UcContractDescription ucContractDescription1;
    }
}