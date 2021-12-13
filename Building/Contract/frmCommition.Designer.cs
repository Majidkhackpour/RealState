
namespace Building.Contract
{
    partial class frmCommition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCommition));
            this.btnFinish = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.UcV1 = new Building.UserControls.Contract.Public.UcContractVisitor();
            this.ucTotalCommition1 = new Building.UserControls.Contract.Public.UcTotalCommition();
            this.ucContractVisitor1 = new Building.UserControls.Contract.Public.UcContractVisitor();
            this.UcV2 = new Building.UserControls.Contract.Public.UcContractVisitor();
            this.SuspendLayout();
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
            this.btnFinish.Location = new System.Drawing.Point(764, 471);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnFinish.Size = new System.Drawing.Size(125, 31);
            this.btnFinish.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnFinish.TabIndex = 55803;
            this.btnFinish.Text = "تایید (F5)";
            this.btnFinish.TextColor = System.Drawing.Color.Black;
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
            this.btnCancel.Location = new System.Drawing.Point(21, 471);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnCancel.Size = new System.Drawing.Size(125, 31);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCancel.TabIndex = 55804;
            this.btnCancel.Text = "انصراف (Esc)";
            this.btnCancel.TextColor = System.Drawing.Color.Black;
            // 
            // UcV1
            // 
            this.UcV1.BackColor = System.Drawing.Color.Transparent;
            this.UcV1.BazatyabGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.UcV1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcV1.Location = new System.Drawing.Point(461, 357);
            this.UcV1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcV1.Name = "UcV1";
            this.UcV1.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcV1.Size = new System.Drawing.Size(420, 106);
            this.UcV1.TabIndex = 55805;
            this.UcV1.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // ucTotalCommition1
            // 
            this.ucTotalCommition1.BackColor = System.Drawing.Color.Transparent;
            this.ucTotalCommition1.FirstAvarez = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.FirstDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.FirstTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.FirstTotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTotalCommition1.Location = new System.Drawing.Point(4, 11);
            this.ucTotalCommition1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTotalCommition1.Name = "ucTotalCommition1";
            this.ucTotalCommition1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTotalCommition1.SecondAvarez = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.SecondDiscount = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.SecondTax = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.SecondTotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucTotalCommition1.Size = new System.Drawing.Size(885, 350);
            this.ucTotalCommition1.TabIndex = 0;
            // 
            // ucContractVisitor1
            // 
            this.ucContractVisitor1.BackColor = System.Drawing.Color.Transparent;
            this.ucContractVisitor1.BazatyabGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.ucContractVisitor1.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucContractVisitor1.Location = new System.Drawing.Point(461, 357);
            this.ucContractVisitor1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucContractVisitor1.Name = "ucContractVisitor1";
            this.ucContractVisitor1.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucContractVisitor1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucContractVisitor1.Size = new System.Drawing.Size(420, 106);
            this.ucContractVisitor1.TabIndex = 55805;
            this.ucContractVisitor1.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // UcV2
            // 
            this.UcV2.BackColor = System.Drawing.Color.Transparent;
            this.UcV2.BazatyabGuid = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.UcV2.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UcV2.Location = new System.Drawing.Point(21, 357);
            this.UcV2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UcV2.Name = "UcV2";
            this.UcV2.Price = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.UcV2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UcV2.Size = new System.Drawing.Size(420, 106);
            this.UcV2.TabIndex = 55805;
            this.UcV2.TotalPrice = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // frmCommition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 508);
            this.ControlBox = false;
            this.Controls.Add(this.UcV2);
            this.Controls.Add(this.UcV1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.ucTotalCommition1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommition";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Load += new System.EventHandler(this.frmCommition_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCommition_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Contract.Public.UcTotalCommition ucTotalCommition1;
        private DevComponents.DotNetBar.ButtonX btnFinish;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private UserControls.Contract.Public.UcContractVisitor UcV1;
        private UserControls.Contract.Public.UcContractVisitor ucContractVisitor1;
        private UserControls.Contract.Public.UcContractVisitor UcV2;
    }
}