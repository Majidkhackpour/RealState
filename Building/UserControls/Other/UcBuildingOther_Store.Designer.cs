
namespace Building.UserControls.Other
{
    partial class UcBuildingOther_Store
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
            this.ucBuildingView1 = new Building.UserControls.Objects.UcBuildingView();
            this.ucFloorCover1 = new Building.UserControls.Objects.UcFloorCover();
            this.UcErtefa = new Building.UserControls.Objects.UcNumericTitleValue();
            this.UcWidth = new Building.UserControls.Objects.UcNumericTitleValue();
            this.UcWallCovering = new Building.UserControls.Objects.UcTitleValue();
            this.ucCommericallLicense1 = new Building.UserControls.Objects.UcCommericallLicense();
            this.ucDocumentType1 = new Building.UserControls.Objects.UcDocumentType();
            this.UcDong = new Building.UserControls.Objects.UcNumericTitleValue();
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
            this.ucPricePerMasahat.Location = new System.Drawing.Point(391, 158);
            this.ucPricePerMasahat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPricePerMasahat.Name = "ucPricePerMasahat";
            this.ucPricePerMasahat.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucPricePerMasahat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucPricePerMasahat.Size = new System.Drawing.Size(359, 36);
            this.ucPricePerMasahat.TabIndex = 35;
            this.ucPricePerMasahat.Title = "قیمت هر متر بنا";
            this.ucPricePerMasahat.OnTextChanged += new System.Action(this.ucPricePerMasahat_OnTextChanged);
            // 
            // ucTotalPrice
            // 
            this.ucTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.ucTotalPrice.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTotalPrice.Location = new System.Drawing.Point(21, 158);
            this.ucTotalPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTotalPrice.Name = "ucTotalPrice";
            this.ucTotalPrice.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTotalPrice.Size = new System.Drawing.Size(343, 36);
            this.ucTotalPrice.TabIndex = 36;
            this.ucTotalPrice.Title = "قیمت کل";
            this.ucTotalPrice.OnTextChanged += new System.Action(this.ucTotalPrice_OnTextChanged);
            // 
            // ucVam
            // 
            this.ucVam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVam.BackColor = System.Drawing.Color.Transparent;
            this.ucVam.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucVam.Location = new System.Drawing.Point(391, 192);
            this.ucVam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucVam.Name = "ucVam";
            this.ucVam.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucVam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucVam.Size = new System.Drawing.Size(359, 36);
            this.ucVam.TabIndex = 37;
            this.ucVam.Title = "مبلغ وام";
            // 
            // ucQest
            // 
            this.ucQest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucQest.BackColor = System.Drawing.Color.Transparent;
            this.ucQest.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucQest.Location = new System.Drawing.Point(21, 192);
            this.ucQest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucQest.Name = "ucQest";
            this.ucQest.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucQest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucQest.Size = new System.Drawing.Size(343, 36);
            this.ucQest.TabIndex = 38;
            this.ucQest.Title = "مبلغ قسط";
            // 
            // ucBuildingView1
            // 
            this.ucBuildingView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBuildingView1.BackColor = System.Drawing.Color.Transparent;
            this.ucBuildingView1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucBuildingView1.Location = new System.Drawing.Point(247, 86);
            this.ucBuildingView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucBuildingView1.Name = "ucBuildingView1";
            this.ucBuildingView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucBuildingView1.Size = new System.Drawing.Size(156, 36);
            this.ucBuildingView1.TabIndex = 34;
            // 
            // ucFloorCover1
            // 
            this.ucFloorCover1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFloorCover1.BackColor = System.Drawing.Color.Transparent;
            this.ucFloorCover1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucFloorCover1.Location = new System.Drawing.Point(57, 86);
            this.ucFloorCover1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucFloorCover1.Name = "ucFloorCover1";
            this.ucFloorCover1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucFloorCover1.Size = new System.Drawing.Size(177, 36);
            this.ucFloorCover1.TabIndex = 33;
            // 
            // UcErtefa
            // 
            this.UcErtefa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcErtefa.BackColor = System.Drawing.Color.Transparent;
            this.UcErtefa.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcErtefa.Location = new System.Drawing.Point(247, 45);
            this.UcErtefa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcErtefa.Name = "UcErtefa";
            this.UcErtefa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcErtefa.Size = new System.Drawing.Size(174, 36);
            this.UcErtefa.TabIndex = 31;
            this.UcErtefa.Title = "ارتفاع سقف";
            this.UcErtefa.Value = 0;
            // 
            // UcWidth
            // 
            this.UcWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcWidth.BackColor = System.Drawing.Color.Transparent;
            this.UcWidth.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcWidth.Location = new System.Drawing.Point(57, 45);
            this.UcWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcWidth.Name = "UcWidth";
            this.UcWidth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcWidth.Size = new System.Drawing.Size(145, 36);
            this.UcWidth.TabIndex = 32;
            this.UcWidth.Title = "طول بر";
            this.UcWidth.Value = 0;
            // 
            // UcWallCovering
            // 
            this.UcWallCovering.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcWallCovering.BackColor = System.Drawing.Color.Transparent;
            this.UcWallCovering.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcWallCovering.Location = new System.Drawing.Point(476, 86);
            this.UcWallCovering.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcWallCovering.Name = "UcWallCovering";
            this.UcWallCovering.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcWallCovering.Size = new System.Drawing.Size(257, 36);
            this.UcWallCovering.TabIndex = 30;
            this.UcWallCovering.Title = "پوشش دیوار";
            this.UcWallCovering.Value = "";
            // 
            // ucCommericallLicense1
            // 
            this.ucCommericallLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCommericallLicense1.BackColor = System.Drawing.Color.Transparent;
            this.ucCommericallLicense1.CommericallLicense = null;
            this.ucCommericallLicense1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucCommericallLicense1.Location = new System.Drawing.Point(485, 45);
            this.ucCommericallLicense1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCommericallLicense1.Name = "ucCommericallLicense1";
            this.ucCommericallLicense1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucCommericallLicense1.Size = new System.Drawing.Size(251, 36);
            this.ucCommericallLicense1.TabIndex = 29;
            // 
            // ucDocumentType1
            // 
            this.ucDocumentType1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDocumentType1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocumentType1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucDocumentType1.Location = new System.Drawing.Point(245, 7);
            this.ucDocumentType1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDocumentType1.Name = "ucDocumentType1";
            this.ucDocumentType1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucDocumentType1.Size = new System.Drawing.Size(192, 36);
            this.ucDocumentType1.TabIndex = 27;
            // 
            // UcDong
            // 
            this.UcDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcDong.BackColor = System.Drawing.Color.Transparent;
            this.UcDong.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcDong.Location = new System.Drawing.Point(57, 7);
            this.UcDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcDong.Name = "UcDong";
            this.UcDong.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcDong.Size = new System.Drawing.Size(131, 36);
            this.UcDong.TabIndex = 28;
            this.UcDong.Title = "دانگ";
            this.UcDong.Value = 0;
            // 
            // ucZirBana1
            // 
            this.ucZirBana1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucZirBana1.BackColor = System.Drawing.Color.Transparent;
            this.ucZirBana1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucZirBana1.Location = new System.Drawing.Point(476, 7);
            this.ucZirBana1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucZirBana1.Name = "ucZirBana1";
            this.ucZirBana1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucZirBana1.Size = new System.Drawing.Size(260, 36);
            this.ucZirBana1.TabIndex = 26;
            this.ucZirBana1.Title = "زیربنا";
            this.ucZirBana1.Value = 0;
            this.ucZirBana1.OnValueChanged += new System.Action(this.ucZirBana1_OnValueChanged);
            // 
            // txtDeliveryDate
            // 
            this.txtDeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliveryDate.Location = new System.Drawing.Point(249, 126);
            this.txtDeliveryDate.Miladi = new System.DateTime(2021, 10, 8, 17, 21, 19, 0);
            this.txtDeliveryDate.Name = "txtDeliveryDate";
            this.txtDeliveryDate.NowDateSelected = false;
            this.txtDeliveryDate.ReadOnly = true;
            this.txtDeliveryDate.SelectedDate = null;
            this.txtDeliveryDate.Shamsi = null;
            this.txtDeliveryDate.Size = new System.Drawing.Size(154, 27);
            this.txtDeliveryDate.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "تاریخ تحویل";
            // 
            // ucConstructionStage1
            // 
            this.ucConstructionStage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucConstructionStage1.BackColor = System.Drawing.Color.Transparent;
            this.ucConstructionStage1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucConstructionStage1.Location = new System.Drawing.Point(527, 122);
            this.ucConstructionStage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucConstructionStage1.Name = "ucConstructionStage1";
            this.ucConstructionStage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucConstructionStage1.Size = new System.Drawing.Size(202, 36);
            this.ucConstructionStage1.TabIndex = 44;
            // 
            // UcBuildingOther_Store
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
            this.Controls.Add(this.ucBuildingView1);
            this.Controls.Add(this.ucFloorCover1);
            this.Controls.Add(this.UcErtefa);
            this.Controls.Add(this.UcWidth);
            this.Controls.Add(this.UcWallCovering);
            this.Controls.Add(this.ucCommericallLicense1);
            this.Controls.Add(this.ucDocumentType1);
            this.Controls.Add(this.UcDong);
            this.Controls.Add(this.ucZirBana1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingOther_Store";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(751, 230);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Objects.UcPrice ucPricePerMasahat;
        private Objects.UcPrice ucTotalPrice;
        private Objects.UcPrice ucVam;
        private Objects.UcPrice ucQest;
        private Objects.UcBuildingView ucBuildingView1;
        private Objects.UcFloorCover ucFloorCover1;
        private Objects.UcNumericTitleValue UcErtefa;
        private Objects.UcNumericTitleValue UcWidth;
        private Objects.UcTitleValue UcWallCovering;
        private Objects.UcCommericallLicense ucCommericallLicense1;
        private Objects.UcDocumentType ucDocumentType1;
        private Objects.UcNumericTitleValue UcDong;
        private Objects.UcZirBana ucZirBana1;
        private BPersianCalender.BPersianCalenderTextBox txtDeliveryDate;
        private System.Windows.Forms.Label label1;
        private Objects.UcConstructionStage ucConstructionStage1;
    }
}
