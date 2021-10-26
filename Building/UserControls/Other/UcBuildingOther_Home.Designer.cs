
namespace Building.UserControls.Other
{
    partial class UcBuildingOther_Home
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
            this.ucKitchenService1 = new Building.UserControls.Objects.UcKitchenService();
            this.ucFloorCover1 = new Building.UserControls.Objects.UcFloorCover();
            this.ucBuildingView1 = new Building.UserControls.Objects.UcBuildingView();
            this.ucSide1 = new Building.UserControls.Objects.UcSide();
            this.ucTabaqeCount = new Building.UserControls.Objects.UcNumericTitleValue();
            this.ucDocumentType1 = new Building.UserControls.Objects.UcDocumentType();
            this.UcDong = new Building.UserControls.Objects.UcNumericTitleValue();
            this.ucRoomCount1 = new Building.UserControls.Objects.UcRoomCount();
            this.ucZirBana1 = new Building.UserControls.Objects.UcZirBana();
            this.ucMasahat = new Building.UserControls.Objects.UcZirBana();
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
            this.ucPricePerMasahat.Location = new System.Drawing.Point(384, 153);
            this.ucPricePerMasahat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPricePerMasahat.Name = "ucPricePerMasahat";
            this.ucPricePerMasahat.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucPricePerMasahat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucPricePerMasahat.Size = new System.Drawing.Size(359, 36);
            this.ucPricePerMasahat.TabIndex = 36;
            this.ucPricePerMasahat.Title = "قیمت هر متر بنا";
            this.ucPricePerMasahat.OnTextChanged += new System.Action(this.ucPricePerMasahat_OnTextChanged);
            // 
            // ucTotalPrice
            // 
            this.ucTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.ucTotalPrice.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTotalPrice.Location = new System.Drawing.Point(14, 153);
            this.ucTotalPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTotalPrice.Name = "ucTotalPrice";
            this.ucTotalPrice.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTotalPrice.Size = new System.Drawing.Size(343, 36);
            this.ucTotalPrice.TabIndex = 37;
            this.ucTotalPrice.Title = "قیمت کل";
            this.ucTotalPrice.OnTextChanged += new System.Action(this.ucTotalPrice_OnTextChanged);
            // 
            // ucVam
            // 
            this.ucVam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVam.BackColor = System.Drawing.Color.Transparent;
            this.ucVam.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucVam.Location = new System.Drawing.Point(384, 187);
            this.ucVam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucVam.Name = "ucVam";
            this.ucVam.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucVam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucVam.Size = new System.Drawing.Size(359, 36);
            this.ucVam.TabIndex = 38;
            this.ucVam.Title = "مبلغ وام";
            // 
            // ucQest
            // 
            this.ucQest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucQest.BackColor = System.Drawing.Color.Transparent;
            this.ucQest.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucQest.Location = new System.Drawing.Point(14, 187);
            this.ucQest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucQest.Name = "ucQest";
            this.ucQest.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucQest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucQest.Size = new System.Drawing.Size(343, 36);
            this.ucQest.TabIndex = 39;
            this.ucQest.Title = "مبلغ قسط";
            // 
            // ucKitchenService1
            // 
            this.ucKitchenService1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucKitchenService1.BackColor = System.Drawing.Color.Transparent;
            this.ucKitchenService1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucKitchenService1.KitchenServiceGuid = new System.Guid("5a3cc594-ce61-4334-a14f-3cb3a1d74769");
            this.ucKitchenService1.Location = new System.Drawing.Point(63, 114);
            this.ucKitchenService1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucKitchenService1.Name = "ucKitchenService1";
            this.ucKitchenService1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucKitchenService1.Size = new System.Drawing.Size(174, 36);
            this.ucKitchenService1.TabIndex = 35;
            // 
            // ucFloorCover1
            // 
            this.ucFloorCover1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFloorCover1.BackColor = System.Drawing.Color.Transparent;
            this.ucFloorCover1.FloorCoverGuid = new System.Guid("0d9bd742-a1fd-4e31-b3a2-87d77f8e315e");
            this.ucFloorCover1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFloorCover1.Location = new System.Drawing.Point(296, 114);
            this.ucFloorCover1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFloorCover1.Name = "ucFloorCover1";
            this.ucFloorCover1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFloorCover1.Size = new System.Drawing.Size(177, 36);
            this.ucFloorCover1.TabIndex = 34;
            // 
            // ucBuildingView1
            // 
            this.ucBuildingView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBuildingView1.BackColor = System.Drawing.Color.Transparent;
            this.ucBuildingView1.BuildingViewGuid = new System.Guid("23f29860-3d3d-4837-a463-8dcdee19993c");
            this.ucBuildingView1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucBuildingView1.Location = new System.Drawing.Point(549, 114);
            this.ucBuildingView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucBuildingView1.Name = "ucBuildingView1";
            this.ucBuildingView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucBuildingView1.Size = new System.Drawing.Size(156, 36);
            this.ucBuildingView1.TabIndex = 33;
            // 
            // ucSide1
            // 
            this.ucSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSide1.BackColor = System.Drawing.Color.Transparent;
            this.ucSide1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucSide1.Location = new System.Drawing.Point(545, 78);
            this.ucSide1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSide1.Name = "ucSide1";
            this.ucSide1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucSide1.Side = null;
            this.ucSide1.Size = new System.Drawing.Size(192, 36);
            this.ucSide1.TabIndex = 32;
            // 
            // ucTabaqeCount
            // 
            this.ucTabaqeCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTabaqeCount.BackColor = System.Drawing.Color.Transparent;
            this.ucTabaqeCount.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTabaqeCount.Location = new System.Drawing.Point(356, 41);
            this.ucTabaqeCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTabaqeCount.Name = "ucTabaqeCount";
            this.ucTabaqeCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTabaqeCount.Size = new System.Drawing.Size(164, 36);
            this.ucTabaqeCount.TabIndex = 31;
            this.ucTabaqeCount.Title = "تعداد طبقات";
            this.ucTabaqeCount.Value = 0;
            // 
            // ucDocumentType1
            // 
            this.ucDocumentType1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDocumentType1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocumentType1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucDocumentType1.Location = new System.Drawing.Point(544, 41);
            this.ucDocumentType1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDocumentType1.Name = "ucDocumentType1";
            this.ucDocumentType1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucDocumentType1.SanadTypeGuid = new System.Guid("f2c7220f-d56a-46a3-92e4-03709400ac9e");
            this.ucDocumentType1.Size = new System.Drawing.Size(192, 36);
            this.ucDocumentType1.TabIndex = 29;
            // 
            // UcDong
            // 
            this.UcDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcDong.BackColor = System.Drawing.Color.Transparent;
            this.UcDong.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcDong.Location = new System.Drawing.Point(329, 4);
            this.UcDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcDong.Name = "UcDong";
            this.UcDong.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcDong.Size = new System.Drawing.Size(131, 36);
            this.UcDong.TabIndex = 30;
            this.UcDong.Title = "دانگ";
            this.UcDong.Value = 0;
            // 
            // ucRoomCount1
            // 
            this.ucRoomCount1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRoomCount1.BackColor = System.Drawing.Color.Transparent;
            this.ucRoomCount1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucRoomCount1.Location = new System.Drawing.Point(62, 41);
            this.ucRoomCount1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucRoomCount1.Name = "ucRoomCount1";
            this.ucRoomCount1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucRoomCount1.RoomCount = -1;
            this.ucRoomCount1.Size = new System.Drawing.Size(259, 36);
            this.ucRoomCount1.TabIndex = 28;
            // 
            // ucZirBana1
            // 
            this.ucZirBana1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZirBana1.BackColor = System.Drawing.Color.Transparent;
            this.ucZirBana1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucZirBana1.Location = new System.Drawing.Point(476, 4);
            this.ucZirBana1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucZirBana1.Name = "ucZirBana1";
            this.ucZirBana1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucZirBana1.Size = new System.Drawing.Size(260, 36);
            this.ucZirBana1.TabIndex = 26;
            this.ucZirBana1.Title = "زیربنا";
            this.ucZirBana1.Value = 0;
            // 
            // ucMasahat
            // 
            this.ucMasahat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMasahat.BackColor = System.Drawing.Color.Transparent;
            this.ucMasahat.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucMasahat.Location = new System.Drawing.Point(65, 4);
            this.ucMasahat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucMasahat.Name = "ucMasahat";
            this.ucMasahat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucMasahat.Size = new System.Drawing.Size(256, 36);
            this.ucMasahat.TabIndex = 27;
            this.ucMasahat.Title = "زمین";
            this.ucMasahat.Value = 0;
            this.ucMasahat.OnValueChanged += new System.Action(this.ucMasahat_OnValueChanged);
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryDate.Location = new System.Drawing.Point(68, 81);
            this.txtDeliveryDate.Miladi = new System.DateTime(2021, 10, 8, 17, 21, 19, 0);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.NowDateSelected = false;
            this.txtDeliveryDate.ReadOnly = true;
            this.txtDeliveryDate.SelectedDate = null;
            this.txtDeliveryDate.Shamsi = null;
            this.txtDeliveryDate.Size = new System.Drawing.Size(154, 27);
            this.txtDeliveryDate.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "تاریخ تحویل";
            // 
            // ucConstructionStage1
            // 
            this.ucConstructionStage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucConstructionStage1.BackColor = System.Drawing.Color.Transparent;
            this.ucConstructionStage1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucConstructionStage1.Location = new System.Drawing.Point(318, 78);
            this.ucConstructionStage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucConstructionStage1.Name = "ucConstructionStage1";
            this.ucConstructionStage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucConstructionStage1.Size = new System.Drawing.Size(202, 36);
            this.ucConstructionStage1.TabIndex = 41;
            // 
            // UcBuildingOther_Home
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
            this.Controls.Add(this.ucKitchenService1);
            this.Controls.Add(this.ucFloorCover1);
            this.Controls.Add(this.ucBuildingView1);
            this.Controls.Add(this.ucSide1);
            this.Controls.Add(this.ucTabaqeCount);
            this.Controls.Add(this.ucDocumentType1);
            this.Controls.Add(this.UcDong);
            this.Controls.Add(this.ucRoomCount1);
            this.Controls.Add(this.ucZirBana1);
            this.Controls.Add(this.ucMasahat);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingOther_Home";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(751, 226);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Objects.UcPrice ucPricePerMasahat;
        private Objects.UcPrice ucTotalPrice;
        private Objects.UcPrice ucVam;
        private Objects.UcPrice ucQest;
        private Objects.UcKitchenService ucKitchenService1;
        private Objects.UcFloorCover ucFloorCover1;
        private Objects.UcBuildingView ucBuildingView1;
        private Objects.UcSide ucSide1;
        private Objects.UcNumericTitleValue ucTabaqeCount;
        private Objects.UcDocumentType ucDocumentType1;
        private Objects.UcNumericTitleValue UcDong;
        private Objects.UcRoomCount ucRoomCount1;
        private Objects.UcZirBana ucZirBana1;
        private Objects.UcZirBana ucMasahat;
        private BPersianCalender.BPersianCalenderTextBox txtDeliveryDate;
        private System.Windows.Forms.Label label1;
        private Objects.UcConstructionStage ucConstructionStage1;
    }
}
