
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
            this.ucCancel = new WindowsSerivces.UcActionButton();
            this.ucHelp = new WindowsSerivces.UcActionButton();
            this.ucAccept = new WindowsSerivces.UcActionButton();
            this.UcV2 = new Building.UserControls.Contract.Public.UcContractVisitor();
            this.UcV1 = new Building.UserControls.Contract.Public.UcContractVisitor();
            this.ucTotalCommition1 = new Building.UserControls.Contract.Public.UcTotalCommition();
            this.ucContractVisitor1 = new Building.UserControls.Contract.Public.UcContractVisitor();
            this.SuspendLayout();
            // 
            // ucCancel
            // 
            this.ucCancel.BackColor = System.Drawing.Color.Transparent;
            this.ucCancel.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucCancel.Location = new System.Drawing.Point(21, 471);
            this.ucCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCancel.Name = "ucCancel";
            this.ucCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucCancel.Size = new System.Drawing.Size(125, 31);
            this.ucCancel.TabIndex = 55807;
            this.ucCancel.Title = "انصراف (Esc)";
            this.ucCancel.Type = Services.ButtonType.CancelButton;
            this.ucCancel.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucCancel_OnClick);
            // 
            // ucHelp
            // 
            this.ucHelp.BackColor = System.Drawing.Color.Transparent;
            this.ucHelp.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucHelp.Location = new System.Drawing.Point(592, 471);
            this.ucHelp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHelp.Name = "ucHelp";
            this.ucHelp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHelp.Size = new System.Drawing.Size(156, 31);
            this.ucHelp.TabIndex = 55806;
            this.ucHelp.Title = "راهنمای محاسبه کمیسیون";
            this.ucHelp.Type = Services.ButtonType.None;
            this.ucHelp.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucHelp_OnClick);
            // 
            // ucAccept
            // 
            this.ucAccept.BackColor = System.Drawing.Color.Transparent;
            this.ucAccept.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucAccept.Location = new System.Drawing.Point(756, 471);
            this.ucAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAccept.Name = "ucAccept";
            this.ucAccept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucAccept.Size = new System.Drawing.Size(125, 31);
            this.ucAccept.TabIndex = 55806;
            this.ucAccept.Title = "تایید (F5)";
            this.ucAccept.Type = Services.ButtonType.AcceptButton;
            this.ucAccept.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucAccept_OnClick);
            // 
            // UcV2
            // 
            this.UcV2.BackColor = System.Drawing.Color.Transparent;
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
            // UcV1
            // 
            this.UcV1.BackColor = System.Drawing.Color.Transparent;
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
            // frmCommition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 508);
            this.ControlBox = false;
            this.Controls.Add(this.ucCancel);
            this.Controls.Add(this.ucHelp);
            this.Controls.Add(this.ucAccept);
            this.Controls.Add(this.UcV2);
            this.Controls.Add(this.UcV1);
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
        private UserControls.Contract.Public.UcContractVisitor UcV1;
        private UserControls.Contract.Public.UcContractVisitor ucContractVisitor1;
        private UserControls.Contract.Public.UcContractVisitor UcV2;
        private WindowsSerivces.UcActionButton ucCancel;
        private WindowsSerivces.UcActionButton ucAccept;
        private WindowsSerivces.UcActionButton ucHelp;
    }
}