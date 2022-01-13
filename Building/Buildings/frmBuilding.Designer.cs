﻿
using Building.UserControls;
using Cities;
using Peoples;

namespace Building.Buildings
{
    partial class frmBuilding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuilding));
            this.UcPeople = new Peoples.UcPeopleSelect();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UcNotes = new Building.UserControls.UcBuildingNote();
            this.groupPanel3 = new Building.UserControls.UcBuildingMedia();
            this.ucBuildingHitting1 = new Building.UserControls.UcBuildingImages();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.UcOptions = new Building.UserControls.UcBuildingOptions();
            this.UcHitting_Colling = new Building.UserControls.UcBuildingHitting();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.UcCode = new Building.UserControls.UcBuildingCode();
            this.UcCity = new Cities.UcCitySelect();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnSavePersonal = new DevComponents.DotNetBar.ButtonX();
            this.ucType=new UcBuildingType();
            this.panel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UcPeople
            // 
            this.UcPeople.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UcPeople.BackColor = System.Drawing.Color.Transparent;
            this.UcPeople.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcPeople.Guid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.UcPeople.Location = new System.Drawing.Point(12, 7);
            this.UcPeople.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcPeople.Name = "UcPeople";
            this.UcPeople.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcPeople.Size = new System.Drawing.Size(758, 138);
            this.UcPeople.TabIndex = 0;
            this.UcPeople.OnShowNumbers += new System.Action(this.UcPeople_OnShowNumbers);
            this.UcPeople.OnShowFiles += new System.Action(this.UcPeople_OnShowFiles);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.UcNotes);
            this.panel1.Controls.Add(this.groupPanel3);
            this.panel1.Controls.Add(this.ucBuildingHitting1);
            this.panel1.Controls.Add(this.groupPanel2);
            this.panel1.Controls.Add(this.UcOptions);
            this.panel1.Controls.Add(this.ucType);
            this.panel1.Controls.Add(this.UcHitting_Colling);
            this.panel1.Controls.Add(this.groupPanel1);
            this.panel1.Controls.Add(this.UcCode);
            this.panel1.Controls.Add(this.UcCity);
            this.panel1.Controls.Add(this.UcPeople);
            this.panel1.Location = new System.Drawing.Point(4, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 485);
            this.panel1.TabIndex = 2;
            // 
            // UcNotes
            // 
            this.UcNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UcNotes.BackColor = System.Drawing.Color.Transparent;
            this.UcNotes.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcNotes.Location = new System.Drawing.Point(8, 1359);
            this.UcNotes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcNotes.Name = "UcNotes";
            this.UcNotes.Notes = null;
            this.UcNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcNotes.Size = new System.Drawing.Size(761, 237);
            this.UcNotes.TabIndex = 55804;
            // 
            // groupPanel3
            // 
            this.groupPanel3.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupPanel3.Location = new System.Drawing.Point(8, 1051);
            this.groupPanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupPanel3.Size = new System.Drawing.Size(354, 300);
            this.groupPanel3.TabIndex = 55803;
            // 
            // ucBuildingHitting1
            // 
            this.ucBuildingHitting1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBuildingHitting1.BackColor = System.Drawing.Color.Transparent;
            this.ucBuildingHitting1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucBuildingHitting1.Location = new System.Drawing.Point(369, 1049);
            this.ucBuildingHitting1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucBuildingHitting1.Name = "ucBuildingHitting1";
            this.ucBuildingHitting1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucBuildingHitting1.Size = new System.Drawing.Size(397, 300);
            this.ucBuildingHitting1.TabIndex = 55802;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtShortDesc);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(8, 745);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(354, 300);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 2;
            this.groupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel2.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 2;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 2;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 2;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 5;
            this.groupPanel2.Text = "توضیحات تکمیلی";
            // 
            // txtShortDesc
            // 
            this.txtShortDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShortDesc.Location = new System.Drawing.Point(0, 0);
            this.txtShortDesc.Multiline = true;
            this.txtShortDesc.Name = "txtShortDesc";
            this.txtShortDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShortDesc.Size = new System.Drawing.Size(348, 272);
            this.txtShortDesc.TabIndex = 5;
            // 
            // UcOptions
            // 
            this.UcOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UcOptions.BackColor = System.Drawing.Color.Transparent;
            this.UcOptions.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcOptions.Location = new System.Drawing.Point(369, 745);
            this.UcOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcOptions.Name = "UcOptions";
            this.UcOptions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcOptions.Size = new System.Drawing.Size(397, 300);
            this.UcOptions.TabIndex = 4;
            // 
            // ucType
            // 
            this.ucType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucType.BackColor = System.Drawing.Color.Transparent;
            this.ucType.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucType.Location = new System.Drawing.Point(8, 692);
            this.ucType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucType.Name = "ucType";
            this.ucType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucType.Size = new System.Drawing.Size(758, 47);
            this.ucType.TabIndex = 3;
            // 
            // UcHitting_Colling
            // 
            this.UcHitting_Colling.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UcHitting_Colling.BackColor = System.Drawing.Color.Transparent;
            this.UcHitting_Colling.Colling = "";
            this.UcHitting_Colling.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcHitting_Colling.Hitting = "";
            this.UcHitting_Colling.Location = new System.Drawing.Point(8, 638);
            this.UcHitting_Colling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcHitting_Colling.Name = "UcHitting_Colling";
            this.UcHitting_Colling.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcHitting_Colling.Size = new System.Drawing.Size(758, 47);
            this.UcHitting_Colling.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.pnlContent);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(8, 319);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(758, 311);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(175)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 2;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(195)))), ((int)(((byte)(198)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 2;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 2;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 2;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(752, 305);
            this.pnlContent.TabIndex = 0;
            // 
            // UcCode
            // 
            this.UcCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UcCode.BackColor = System.Drawing.Color.Transparent;
            this.UcCode.Code = "3648";
            this.UcCode.CreateDate = new System.DateTime(2021, 10, 6, 0, 0, 0, 0);
            this.UcCode.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcCode.Location = new System.Drawing.Point(8, 253);
            this.UcCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcCode.Name = "UcCode";
            this.UcCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcCode.Size = new System.Drawing.Size(758, 61);
            this.UcCode.TabIndex = 1;
            this.UcCode.UserGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            // 
            // UcCity
            // 
            this.UcCity.Address = "";
            this.UcCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UcCity.BackColor = System.Drawing.Color.Transparent;
            this.UcCity.CityGuid = new System.Guid("3d2f0a4c-a542-4863-9f1e-6c150ec1475f");
            this.UcCity.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcCity.Location = new System.Drawing.Point(8, 146);
            this.UcCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcCity.Name = "UcCity";
            this.UcCity.RegionGuid = new System.Guid("e223ead0-b5cb-4763-a192-4a11bf087c86");
            this.UcCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcCity.Size = new System.Drawing.Size(758, 103);
            this.UcCity.StateGuid = new System.Guid("c22580f8-619c-4eca-a4f2-09b662caf6bb");
            this.UcCity.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTitle.Location = new System.Drawing.Point(4, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(791, 30);
            this.lblTitle.TabIndex = 55799;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnCancel.Location = new System.Drawing.Point(17, 561);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55801;
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
            this.btnFinish.Location = new System.Drawing.Point(665, 561);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55800;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnSavePersonal
            // 
            this.btnSavePersonal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSavePersonal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePersonal.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSavePersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSavePersonal.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSavePersonal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePersonal.Image = global::Building.Properties.Resources.tab_checkbox__;
            this.btnSavePersonal.Location = new System.Drawing.Point(499, 561);
            this.btnSavePersonal.Name = "btnSavePersonal";
            this.btnSavePersonal.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnSavePersonal.Size = new System.Drawing.Size(160, 31);
            this.btnSavePersonal.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSavePersonal.TabIndex = 55802;
            this.btnSavePersonal.Text = "ثبت به عنوان فایل شخصی";
            this.btnSavePersonal.TextColor = System.Drawing.Color.Black;
            this.btnSavePersonal.Click += new System.EventHandler(this.btnSavePersonal_Click);
            // 
            // frmBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnSavePersonal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBuilding";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmBuilding_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBuilding_KeyDown);
            this.panel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private UcPeopleSelect UcPeople;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private UcCitySelect UcCity;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private UcBuildingCode UcCode;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private UcBuildingHitting UcHitting_Colling;
        private UcBuildingOptions UcOptions;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.TextBox txtShortDesc;
        private System.Windows.Forms.Panel pnlContent;
        private UcBuildingImages ucBuildingHitting1;
        private UcBuildingMedia groupPanel3;
        private UcBuildingType ucType;
        private DevComponents.DotNetBar.ButtonX btnSavePersonal;
        private UcBuildingNote UcNotes;
    }
}