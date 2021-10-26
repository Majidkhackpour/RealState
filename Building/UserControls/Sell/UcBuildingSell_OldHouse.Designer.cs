
namespace Building.UserControls.Sell
{
    partial class UcBuildingSell_OldHouse
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
            this.ucPricePerMasahat = new Building.UserControls.Objects.UcPrice();
            this.ucTotalPrice = new Building.UserControls.Objects.UcPrice();
            this.ucVam = new Building.UserControls.Objects.UcPrice();
            this.ucQest = new Building.UserControls.Objects.UcPrice();
            this.ucSide1 = new Building.UserControls.Objects.UcSide();
            this.ucTarakom1 = new Building.UserControls.Objects.UcTarakom();
            this.chbBuildingPermits = new System.Windows.Forms.CheckBox();
            this.ucDocumentType1 = new Building.UserControls.Objects.UcDocumentType();
            this.UcWitdhOfPassage = new Building.UserControls.Objects.UcNumericTitleValue();
            this.UcReformArea = new Building.UserControls.Objects.UcNumericTitleValue();
            this.UcHeight = new Building.UserControls.Objects.UcNumericTitleValue();
            this.UcWidth = new Building.UserControls.Objects.UcNumericTitleValue();
            this.UcDong = new Building.UserControls.Objects.UcNumericTitleValue();
            this.ucMasahat = new Building.UserControls.Objects.UcZirBana();
            this.ucNumericTitleValue2 = new Building.UserControls.Objects.UcNumericTitleValue();
            this.SuspendLayout();
            // 
            // ucPricePerMasahat
            // 
            this.ucPricePerMasahat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPricePerMasahat.BackColor = System.Drawing.Color.Transparent;
            this.ucPricePerMasahat.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucPricePerMasahat.Location = new System.Drawing.Point(388, 141);
            this.ucPricePerMasahat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPricePerMasahat.Name = "ucPricePerMasahat";
            this.ucPricePerMasahat.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucPricePerMasahat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucPricePerMasahat.Size = new System.Drawing.Size(359, 36);
            this.ucPricePerMasahat.TabIndex = 42;
            this.ucPricePerMasahat.Title = "قیمت هر متر زمین";
            this.ucPricePerMasahat.OnTextChanged += new System.Action(this.ucPricePerMasahat_OnTextChanged);
            // 
            // ucTotalPrice
            // 
            this.ucTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.ucTotalPrice.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTotalPrice.Location = new System.Drawing.Point(18, 141);
            this.ucTotalPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTotalPrice.Name = "ucTotalPrice";
            this.ucTotalPrice.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTotalPrice.Size = new System.Drawing.Size(343, 36);
            this.ucTotalPrice.TabIndex = 43;
            this.ucTotalPrice.Title = "قیمت کل";
            this.ucTotalPrice.OnTextChanged += new System.Action(this.ucTotalPrice_OnTextChanged);
            // 
            // ucVam
            // 
            this.ucVam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucVam.BackColor = System.Drawing.Color.Transparent;
            this.ucVam.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucVam.Location = new System.Drawing.Point(388, 175);
            this.ucVam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucVam.Name = "ucVam";
            this.ucVam.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucVam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucVam.Size = new System.Drawing.Size(359, 36);
            this.ucVam.TabIndex = 44;
            this.ucVam.Title = "مبلغ وام";
            // 
            // ucQest
            // 
            this.ucQest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucQest.BackColor = System.Drawing.Color.Transparent;
            this.ucQest.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucQest.Location = new System.Drawing.Point(18, 175);
            this.ucQest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucQest.Name = "ucQest";
            this.ucQest.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucQest.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucQest.Size = new System.Drawing.Size(343, 36);
            this.ucQest.TabIndex = 45;
            this.ucQest.Title = "مبلغ قسط";
            // 
            // ucSide1
            // 
            this.ucSide1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSide1.BackColor = System.Drawing.Color.Transparent;
            this.ucSide1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucSide1.Location = new System.Drawing.Point(555, 105);
            this.ucSide1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucSide1.Name = "ucSide1";
            this.ucSide1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucSide1.Side = null;
            this.ucSide1.Size = new System.Drawing.Size(192, 36);
            this.ucSide1.TabIndex = 41;
            // 
            // ucTarakom1
            // 
            this.ucTarakom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTarakom1.BackColor = System.Drawing.Color.Transparent;
            this.ucTarakom1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTarakom1.Location = new System.Drawing.Point(230, 72);
            this.ucTarakom1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTarakom1.Name = "ucTarakom1";
            this.ucTarakom1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTarakom1.Size = new System.Drawing.Size(210, 36);
            this.ucTarakom1.TabIndex = 40;
            this.ucTarakom1.Tarakom = null;
            // 
            // chbBuildingPermits
            // 
            this.chbBuildingPermits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbBuildingPermits.AutoSize = true;
            this.chbBuildingPermits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbBuildingPermits.Location = new System.Drawing.Point(565, 76);
            this.chbBuildingPermits.Name = "chbBuildingPermits";
            this.chbBuildingPermits.Size = new System.Drawing.Size(110, 24);
            this.chbBuildingPermits.TabIndex = 38;
            this.chbBuildingPermits.Text = "مجوز ساخت دارد";
            this.chbBuildingPermits.UseVisualStyleBackColor = true;
            // 
            // ucDocumentType1
            // 
            this.ucDocumentType1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDocumentType1.BackColor = System.Drawing.Color.Transparent;
            this.ucDocumentType1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucDocumentType1.Location = new System.Drawing.Point(251, 4);
            this.ucDocumentType1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucDocumentType1.Name = "ucDocumentType1";
            this.ucDocumentType1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucDocumentType1.SanadTypeGuid = new System.Guid("f2c7220f-d56a-46a3-92e4-03709400ac9e");
            this.ucDocumentType1.Size = new System.Drawing.Size(192, 36);
            this.ucDocumentType1.TabIndex = 31;
            // 
            // UcWitdhOfPassage
            // 
            this.UcWitdhOfPassage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcWitdhOfPassage.BackColor = System.Drawing.Color.Transparent;
            this.UcWitdhOfPassage.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcWitdhOfPassage.Location = new System.Drawing.Point(40, 72);
            this.UcWitdhOfPassage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcWitdhOfPassage.Name = "UcWitdhOfPassage";
            this.UcWitdhOfPassage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcWitdhOfPassage.Size = new System.Drawing.Size(160, 36);
            this.UcWitdhOfPassage.TabIndex = 32;
            this.UcWitdhOfPassage.Title = "عرض گذر";
            this.UcWitdhOfPassage.Value = 0;
            // 
            // UcReformArea
            // 
            this.UcReformArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcReformArea.BackColor = System.Drawing.Color.Transparent;
            this.UcReformArea.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcReformArea.Location = new System.Drawing.Point(40, 37);
            this.UcReformArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcReformArea.Name = "UcReformArea";
            this.UcReformArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcReformArea.Size = new System.Drawing.Size(170, 36);
            this.UcReformArea.TabIndex = 33;
            this.UcReformArea.Title = "متراژ اصلاحی";
            this.UcReformArea.Value = 0;
            // 
            // UcHeight
            // 
            this.UcHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcHeight.BackColor = System.Drawing.Color.Transparent;
            this.UcHeight.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcHeight.Location = new System.Drawing.Point(286, 37);
            this.UcHeight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcHeight.Name = "UcHeight";
            this.UcHeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcHeight.Size = new System.Drawing.Size(154, 36);
            this.UcHeight.TabIndex = 34;
            this.UcHeight.Title = "عرض زمین";
            this.UcHeight.Value = 0;
            // 
            // UcWidth
            // 
            this.UcWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcWidth.BackColor = System.Drawing.Color.Transparent;
            this.UcWidth.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcWidth.Location = new System.Drawing.Point(588, 37);
            this.UcWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcWidth.Name = "UcWidth";
            this.UcWidth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcWidth.Size = new System.Drawing.Size(145, 36);
            this.UcWidth.TabIndex = 35;
            this.UcWidth.Title = "طول بر";
            this.UcWidth.Value = 0;
            // 
            // UcDong
            // 
            this.UcDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UcDong.BackColor = System.Drawing.Color.Transparent;
            this.UcDong.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcDong.Location = new System.Drawing.Point(40, 4);
            this.UcDong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcDong.Name = "UcDong";
            this.UcDong.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcDong.Size = new System.Drawing.Size(131, 36);
            this.UcDong.TabIndex = 36;
            this.UcDong.Title = "دانگ";
            this.UcDong.Value = 0;
            // 
            // ucMasahat
            // 
            this.ucMasahat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucMasahat.BackColor = System.Drawing.Color.Transparent;
            this.ucMasahat.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucMasahat.Location = new System.Drawing.Point(474, 4);
            this.ucMasahat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucMasahat.Name = "ucMasahat";
            this.ucMasahat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucMasahat.Size = new System.Drawing.Size(256, 36);
            this.ucMasahat.TabIndex = 30;
            this.ucMasahat.Title = "زمین";
            this.ucMasahat.Value = 0;
            this.ucMasahat.OnValueChanged += new System.Action(this.ucMasahat_OnValueChanged);
            // 
            // ucNumericTitleValue2
            // 
            this.ucNumericTitleValue2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucNumericTitleValue2.BackColor = System.Drawing.Color.Transparent;
            this.ucNumericTitleValue2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucNumericTitleValue2.Location = new System.Drawing.Point(286, 37);
            this.ucNumericTitleValue2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucNumericTitleValue2.Name = "ucNumericTitleValue2";
            this.ucNumericTitleValue2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucNumericTitleValue2.Size = new System.Drawing.Size(154, 36);
            this.ucNumericTitleValue2.TabIndex = 37;
            this.ucNumericTitleValue2.Title = "عرض زمین";
            this.ucNumericTitleValue2.Value = 0;
            // 
            // UcBuildingSell_OldHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPricePerMasahat);
            this.Controls.Add(this.ucTotalPrice);
            this.Controls.Add(this.ucVam);
            this.Controls.Add(this.ucQest);
            this.Controls.Add(this.ucSide1);
            this.Controls.Add(this.ucTarakom1);
            this.Controls.Add(this.chbBuildingPermits);
            this.Controls.Add(this.ucDocumentType1);
            this.Controls.Add(this.UcWitdhOfPassage);
            this.Controls.Add(this.UcReformArea);
            this.Controls.Add(this.UcHeight);
            this.Controls.Add(this.UcWidth);
            this.Controls.Add(this.UcDong);
            this.Controls.Add(this.ucMasahat);
            this.Controls.Add(this.ucNumericTitleValue2);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UcBuildingSell_OldHouse";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(751, 217);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Objects.UcPrice ucPricePerMasahat;
        private Objects.UcPrice ucTotalPrice;
        private Objects.UcPrice ucVam;
        private Objects.UcPrice ucQest;
        private Objects.UcSide ucSide1;
        private Objects.UcTarakom ucTarakom1;
        private System.Windows.Forms.CheckBox chbBuildingPermits;
        private Objects.UcDocumentType ucDocumentType1;
        private Objects.UcNumericTitleValue UcWitdhOfPassage;
        private Objects.UcNumericTitleValue UcReformArea;
        private Objects.UcNumericTitleValue UcHeight;
        private Objects.UcNumericTitleValue UcWidth;
        private Objects.UcNumericTitleValue UcDong;
        private Objects.UcZirBana ucMasahat;
        private Objects.UcNumericTitleValue ucNumericTitleValue2;
    }
}
