﻿
namespace Building.UserControls.Other
{
    partial class UcBuildingOther_Office
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
            this.ucPricePerMasahat = new Building.UserControls.Objects.UcPrice();
            this.ucTotalPrice = new Building.UserControls.Objects.UcPrice();
            this.ucVam = new Building.UserControls.Objects.UcPrice();
            this.ucQest = new Building.UserControls.Objects.UcPrice();
            this.UcSuitableFor = new Building.UserControls.Objects.UcTitleValue();
            this.ucCommericallLicense1 = new Building.UserControls.Objects.UcCommericallLicense();
            this.ucVahedPertabaqe = new Building.UserControls.Objects.UcNumericTitleValue();
            this.ucTabaqeNo1 = new Building.UserControls.Objects.UcTabaqeNo();
            this.ucTabaqeCount = new Building.UserControls.Objects.UcNumericTitleValue();
            this.ucKitchenService1 = new Building.UserControls.Objects.UcKitchenService();
            this.ucFloorCover1 = new Building.UserControls.Objects.UcFloorCover();
            this.ucBuildingView1 = new Building.UserControls.Objects.UcBuildingView();
            this.ucSide1 = new Building.UserControls.Objects.UcSide();
            this.ucDocumentType1 = new Building.UserControls.Objects.UcDocumentType();
            this.UcDong = new Building.UserControls.Objects.UcNumericTitleValue();
            this.ucRoomCount1 = new Building.UserControls.Objects.UcRoomCount();
            this.ucZirBana1 = new Building.UserControls.Objects.UcZirBana();
            this.txtDeliveryDate = new BPersianCalender.BPersianCalenderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucConstructionStage1 = new Building.UserControls.Objects.UcConstructionStage();
            this.SuspendLayout();
            // 
            // ucPricePerMasahat
            // 
            this.ucPricePerMasahat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPricePerMasahat.BackColor = System.Drawing.Color.Transparent;
            this.ucPricePerMasahat.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucPricePerMasahat.Location = new System.Drawing.Point(390, 184);
            this.ucPricePerMasahat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPricePerMasahat.Name = "ucPricePerMasahat";
            this.ucPricePerMasahat.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucPricePerMasahat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucPricePerMasahat.Size = new System.Drawing.Size(359, 36);
            this.ucPricePerMasahat.TabIndex = 45;
            this.ucPricePerMasahat.Title = "قیمت هر متر بنا";
            this.ucPricePerMasahat.OnTextChanged += new System.Action(this.ucPricePerMasahat_OnTextChanged);
            // 
            // ucTotalPrice
            // 
            this.ucTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.ucTotalPrice.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTotalPrice.Location = new System.Drawing.Point(20, 184);
            this.ucTotalPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTotalPrice.Name = "ucTotalPrice";
            this.ucTotalPrice.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTotalPrice.Size = new System.Drawing.Size(343, 36);
            this.ucTotalPrice.TabIndex = 46;
            this.ucTotalPrice.Title = "قیمت کل";
            this.ucTotalPrice.OnTextChanged += new System.Action(this.ucTotalPrice_OnTextChanged);
            // 
            // ucVam
            // 
            this.ucVam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVam.BackColor = System.Drawing.Color.Transparent;
            this.ucVam.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucVam.Location = new System.Drawing.Point(390, 218);
            this.ucVam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucVam.Name = "ucVam";
            this.ucVam.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucVam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucVam.Size = new System.Drawing.Size(359, 36);
            this.ucVam.TabIndex = 47;
            this.ucVam.Title = "مبلغ وام";
            // 
            // ucQest
            // 
            this.ucQest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucQest.BackColor = System.Drawing.Color.Transparent;
            this.ucQest.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucQest.Location = new System.Drawing.Point(20, 218);
            this.ucQest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucQest.Name = "ucQest";
            this.ucQest.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucQest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucQest.Size = new System.Drawing.Size(343, 36);
            this.ucQest.TabIndex = 48;
            this.ucQest.Title = "مبلغ قسط";
            // 
            // UcSuitableFor
            // 
            this.UcSuitableFor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcSuitableFor.BackColor = System.Drawing.Color.Transparent;
            this.UcSuitableFor.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcSuitableFor.Location = new System.Drawing.Point(20, 40);
            this.UcSuitableFor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcSuitableFor.Name = "UcSuitableFor";
            this.UcSuitableFor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcSuitableFor.Size = new System.Drawing.Size(246, 36);
            this.UcSuitableFor.TabIndex = 44;
            this.UcSuitableFor.Title = "مناسب برای";
            this.UcSuitableFor.Value = "";
            // 
            // ucCommericallLicense1
            // 
            this.ucCommericallLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCommericallLicense1.BackColor = System.Drawing.Color.Transparent;
            this.ucCommericallLicense1.CommericallLicense = null;
            this.ucCommericallLicense1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucCommericallLicense1.Location = new System.Drawing.Point(496, 112);
            this.ucCommericallLicense1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCommericallLicense1.Name = "ucCommericallLicense1";
            this.ucCommericallLicense1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucCommericallLicense1.Size = new System.Drawing.Size(251, 36);
            this.ucCommericallLicense1.TabIndex = 43;
            // 
            // ucVahedPertabaqe
            // 
            this.ucVahedPertabaqe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVahedPertabaqe.BackColor = System.Drawing.Color.Transparent;
            this.ucVahedPertabaqe.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucVahedPertabaqe.Location = new System.Drawing.Point(22, 147);
            this.ucVahedPertabaqe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucVahedPertabaqe.Name = "ucVahedPertabaqe";
            this.ucVahedPertabaqe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucVahedPertabaqe.Size = new System.Drawing.Size(215, 36);
            this.ucVahedPertabaqe.TabIndex = 42;
            this.ucVahedPertabaqe.Title = "واحد در هر طبقه";
            this.ucVahedPertabaqe.Value = 0;
            // 
            // ucTabaqeNo1
            // 
            this.ucTabaqeNo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTabaqeNo1.BackColor = System.Drawing.Color.Transparent;
            this.ucTabaqeNo1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTabaqeNo1.Location = new System.Drawing.Point(293, 147);
            this.ucTabaqeNo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTabaqeNo1.Name = "ucTabaqeNo1";
            this.ucTabaqeNo1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTabaqeNo1.Size = new System.Drawing.Size(193, 36);
            this.ucTabaqeNo1.TabaqeNo = 0;
            this.ucTabaqeNo1.TabIndex = 41;
            // 
            // ucTabaqeCount
            // 
            this.ucTabaqeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTabaqeCount.BackColor = System.Drawing.Color.Transparent;
            this.ucTabaqeCount.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTabaqeCount.Location = new System.Drawing.Point(561, 147);
            this.ucTabaqeCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTabaqeCount.Name = "ucTabaqeCount";
            this.ucTabaqeCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTabaqeCount.Size = new System.Drawing.Size(197, 36);
            this.ucTabaqeCount.TabIndex = 40;
            this.ucTabaqeCount.Title = "تعداد طبقات";
            this.ucTabaqeCount.Value = 0;
            // 
            // ucKitchenService1
            // 
            this.ucKitchenService1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucKitchenService1.BackColor = System.Drawing.Color.Transparent;
            this.ucKitchenService1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucKitchenService1.Location = new System.Drawing.Point(22, 75);
            this.ucKitchenService1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucKitchenService1.Name = "ucKitchenService1";
            this.ucKitchenService1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucKitchenService1.Size = new System.Drawing.Size(174, 36);
            this.ucKitchenService1.TabIndex = 39;
            // 
            // ucFloorCover1
            // 
            this.ucFloorCover1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFloorCover1.BackColor = System.Drawing.Color.Transparent;
            this.ucFloorCover1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFloorCover1.Location = new System.Drawing.Point(293, 75);
            this.ucFloorCover1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFloorCover1.Name = "ucFloorCover1";
            this.ucFloorCover1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFloorCover1.Size = new System.Drawing.Size(177, 36);
            this.ucFloorCover1.TabIndex = 38;
            // 
            // ucBuildingView1
            // 
            this.ucBuildingView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBuildingView1.BackColor = System.Drawing.Color.Transparent;
            this.ucBuildingView1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucBuildingView1.Location = new System.Drawing.Point(560, 76);
            this.ucBuildingView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucBuildingView1.Name = "ucBuildingView1";
            this.ucBuildingView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucBuildingView1.Size = new System.Drawing.Size(156, 36);
            this.ucBuildingView1.TabIndex = 37;
            // 
            // ucSide1
            // 
            this.ucSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSide1.BackColor = System.Drawing.Color.Transparent;
            this.ucSide1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucSide1.Location = new System.Drawing.Point(293, 40);
            this.ucSide1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSide1.Name = "ucSide1";
            this.ucSide1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucSide1.Side = null;
            this.ucSide1.Size = new System.Drawing.Size(192, 36);
            this.ucSide1.TabIndex = 36;
            // 
            // ucDocumentType1
            // 
            this.ucDocumentType1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDocumentType1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocumentType1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucDocumentType1.Location = new System.Drawing.Point(557, 40);
            this.ucDocumentType1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDocumentType1.Name = "ucDocumentType1";
            this.ucDocumentType1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucDocumentType1.Size = new System.Drawing.Size(192, 36);
            this.ucDocumentType1.TabIndex = 35;
            // 
            // UcDong
            // 
            this.UcDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcDong.BackColor = System.Drawing.Color.Transparent;
            this.UcDong.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcDong.Location = new System.Drawing.Point(22, 3);
            this.UcDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcDong.Name = "UcDong";
            this.UcDong.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcDong.Size = new System.Drawing.Size(163, 36);
            this.UcDong.TabIndex = 34;
            this.UcDong.Title = "دانگ";
            this.UcDong.Value = 0;
            // 
            // ucRoomCount1
            // 
            this.ucRoomCount1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRoomCount1.BackColor = System.Drawing.Color.Transparent;
            this.ucRoomCount1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucRoomCount1.Location = new System.Drawing.Point(208, 3);
            this.ucRoomCount1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucRoomCount1.Name = "ucRoomCount1";
            this.ucRoomCount1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucRoomCount1.RoomCount = -1;
            this.ucRoomCount1.Size = new System.Drawing.Size(259, 36);
            this.ucRoomCount1.TabIndex = 33;
            // 
            // ucZirBana1
            // 
            this.ucZirBana1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZirBana1.BackColor = System.Drawing.Color.Transparent;
            this.ucZirBana1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucZirBana1.Location = new System.Drawing.Point(475, 3);
            this.ucZirBana1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucZirBana1.Name = "ucZirBana1";
            this.ucZirBana1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucZirBana1.Size = new System.Drawing.Size(260, 36);
            this.ucZirBana1.TabIndex = 32;
            this.ucZirBana1.Title = "زیربنا";
            this.ucZirBana1.Value = 0;
            this.ucZirBana1.OnValueChanged += new System.Action(this.ucZirBana1_OnValueChanged);
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryDate.Location = new System.Drawing.Point(22, 117);
            this.txtDeliveryDate.Miladi = new System.DateTime(2021, 10, 8, 17, 21, 19, 0);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.NowDateSelected = false;
            this.txtDeliveryDate.ReadOnly = true;
            this.txtDeliveryDate.SelectedDate = null;
            this.txtDeliveryDate.Shamsi = null;
            this.txtDeliveryDate.Size = new System.Drawing.Size(154, 27);
            this.txtDeliveryDate.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "تاریخ تحویل";
            // 
            // ucConstructionStage1
            // 
            this.ucConstructionStage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucConstructionStage1.BackColor = System.Drawing.Color.Transparent;
            this.ucConstructionStage1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucConstructionStage1.Location = new System.Drawing.Point(296, 112);
            this.ucConstructionStage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucConstructionStage1.Name = "ucConstructionStage1";
            this.ucConstructionStage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucConstructionStage1.Size = new System.Drawing.Size(202, 36);
            this.ucConstructionStage1.TabIndex = 49;
            // 
            // UcBuildingOther_Office
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDeliveryDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucConstructionStage1);
            this.Controls.Add(this.ucPricePerMasahat);
            this.Controls.Add(this.ucTotalPrice);
            this.Controls.Add(this.ucVam);
            this.Controls.Add(this.ucQest);
            this.Controls.Add(this.UcSuitableFor);
            this.Controls.Add(this.ucCommericallLicense1);
            this.Controls.Add(this.ucVahedPertabaqe);
            this.Controls.Add(this.ucTabaqeNo1);
            this.Controls.Add(this.ucTabaqeCount);
            this.Controls.Add(this.ucKitchenService1);
            this.Controls.Add(this.ucFloorCover1);
            this.Controls.Add(this.ucBuildingView1);
            this.Controls.Add(this.ucSide1);
            this.Controls.Add(this.ucDocumentType1);
            this.Controls.Add(this.UcDong);
            this.Controls.Add(this.ucRoomCount1);
            this.Controls.Add(this.ucZirBana1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingOther_Office";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(751, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Objects.UcPrice ucPricePerMasahat;
        private Objects.UcPrice ucTotalPrice;
        private Objects.UcPrice ucVam;
        private Objects.UcPrice ucQest;
        private Objects.UcTitleValue UcSuitableFor;
        private Objects.UcCommericallLicense ucCommericallLicense1;
        private Objects.UcNumericTitleValue ucVahedPertabaqe;
        private Objects.UcTabaqeNo ucTabaqeNo1;
        private Objects.UcNumericTitleValue ucTabaqeCount;
        private Objects.UcKitchenService ucKitchenService1;
        private Objects.UcFloorCover ucFloorCover1;
        private Objects.UcBuildingView ucBuildingView1;
        private Objects.UcSide ucSide1;
        private Objects.UcDocumentType ucDocumentType1;
        private Objects.UcNumericTitleValue UcDong;
        private Objects.UcRoomCount ucRoomCount1;
        private Objects.UcZirBana ucZirBana1;
        private BPersianCalender.BPersianCalenderTextBox txtDeliveryDate;
        private System.Windows.Forms.Label label1;
        private Objects.UcConstructionStage ucConstructionStage1;
    }
}
