﻿
namespace Building.Contract
{
    partial class frmContractMain_Sell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContractMain_Sell));
            this.panel1 = new System.Windows.Forms.Panel();
            this.uc2 = new Building.UserControls.Contract.Sell.UcContractSell_2();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucFSide = new Peoples.UcPeopleContract();
            this.ucSecondSide = new Peoples.UcPeopleContract();
            this.ucContractHeader1 = new Building.UserControls.Contract.Public.UcContractHeader();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.uc2);
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.ucContractHeader1);
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 529);
            this.panel1.TabIndex = 3;
            // 
            // uc2
            // 
            this.uc2.Address = "";
            this.uc2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc2.BackColor = System.Drawing.Color.Transparent;
            this.uc2.BuildingNumber = "";
            this.uc2.BuildingType = "";
            this.uc2.Dong = 1F;
            this.uc2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.uc2.Location = new System.Drawing.Point(20, 492);
            this.uc2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uc2.Masahat = 0F;
            this.uc2.Name = "uc2";
            this.uc2.Office = "";
            this.uc2.Page = 0;
            this.uc2.ParkingNo = 0;
            this.uc2.PartNo = 0;
            this.uc2.PhoneCount = 0;
            this.uc2.PhoneNumber = "";
            this.uc2.RegistryNo = "";
            this.uc2.RegistryNoOrigin = "";
            this.uc2.RegistryNoSub = "";
            this.uc2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.uc2.SanadSerial = "";
            this.uc2.Size = new System.Drawing.Size(762, 195);
            this.uc2.StoreMasahat = 0F;
            this.uc2.StoreNo = 0;
            this.uc2.TabIndex = 2;
            this.uc2.Zip = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(20, 226);
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
            this.splitContainer1.Size = new System.Drawing.Size(762, 260);
            this.splitContainer1.SplitterDistance = 385;
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
            this.ucFSide.Size = new System.Drawing.Size(385, 260);
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
            this.ucSecondSide.Size = new System.Drawing.Size(373, 260);
            this.ucSecondSide.TabIndex = 1;
            this.ucSecondSide.Title = "مشخصات خریدار";
            // 
            // ucContractHeader1
            // 
            this.ucContractHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucContractHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractHeader1.CodeInArchive = "";
            this.ucContractHeader1.ContractCode = ((long)(0));
            this.ucContractHeader1.ContractDate = new System.DateTime(2021, 11, 23, 0, 0, 0, 0);
            this.ucContractHeader1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractHeader1.HologramCode = "";
            this.ucContractHeader1.Location = new System.Drawing.Point(20, 5);
            this.ucContractHeader1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractHeader1.Name = "ucContractHeader1";
            this.ucContractHeader1.RealStateCode = "";
            this.ucContractHeader1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractHeader1.Size = new System.Drawing.Size(762, 213);
            this.ucContractHeader1.TabIndex = 0;
            this.ucContractHeader1.Title = "مبایعه نامه";
            // 
            // frmContractMain_Sell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 600);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmContractMain_Sell";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmContractMain_Sell_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContractMain_Sell_KeyDown);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UserControls.Contract.Public.UcContractHeader ucContractHeader1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Peoples.UcPeopleContract ucFSide;
        private Peoples.UcPeopleContract ucSecondSide;
        private UserControls.Contract.Sell.UcContractSell_2 uc2;
    }
}