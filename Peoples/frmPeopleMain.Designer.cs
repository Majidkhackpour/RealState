
namespace Peoples
{
    partial class frmPeopleMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeopleMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucBank = new Peoples.UcPeople_BankHesab();
            this.ucTell = new Peoples.UcPeople_PhoneBook();
            this.ucPablic = new Peoples.UcPeople_PublicInfo();
            this.ucAccept = new WindowsSerivces.UcActionButton();
            this.ucHeader = new WindowsSerivces.UC_Header();
            this.ucCancel = new WindowsSerivces.UcActionButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ucBank);
            this.panel1.Controls.Add(this.ucTell);
            this.panel1.Controls.Add(this.ucPablic);
            this.panel1.Location = new System.Drawing.Point(3, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 493);
            this.panel1.TabIndex = 55750;
            // 
            // ucBank
            // 
            this.ucBank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucBank.BackColor = System.Drawing.Color.Transparent;
            this.ucBank.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucBank.Location = new System.Drawing.Point(11, 656);
            this.ucBank.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucBank.Name = "ucBank";
            this.ucBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucBank.Size = new System.Drawing.Size(762, 342);
            this.ucBank.TabIndex = 2;
            // 
            // ucTell
            // 
            this.ucTell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTell.BackColor = System.Drawing.Color.Transparent;
            this.ucTell.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucTell.Location = new System.Drawing.Point(11, 307);
            this.ucTell.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTell.Name = "ucTell";
            this.ucTell.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucTell.Size = new System.Drawing.Size(762, 342);
            this.ucTell.TabIndex = 1;
            // 
            // ucPablic
            // 
            this.ucPablic.AccountFirst = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucPablic.Address = "";
            this.ucPablic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPablic.BackColor = System.Drawing.Color.Transparent;
            this.ucPablic.BirthDate = "";
            this.ucPablic.BirthPlace = "";
            this.ucPablic.FatherName = "";
            this.ucPablic.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucPablic.IdCode = "";
            this.ucPablic.IssuedFrom = "";
            this.ucPablic.Location = new System.Drawing.Point(11, 5);
            this.ucPablic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPablic.Name = "ucPablic";
            this.ucPablic.NationalCode = "";
            this.ucPablic.ObjectName = "";
            this.ucPablic.PostalCode = "";
            this.ucPablic.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucPablic.Size = new System.Drawing.Size(762, 295);
            this.ucPablic.TabIndex = 0;
            // 
            // ucAccept
            // 
            this.ucAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ucAccept.BackColor = System.Drawing.Color.Transparent;
            this.ucAccept.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucAccept.Location = new System.Drawing.Point(614, 564);
            this.ucAccept.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucAccept.Name = "ucAccept";
            this.ucAccept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucAccept.Size = new System.Drawing.Size(125, 31);
            this.ucAccept.TabIndex = 55752;
            this.ucAccept.Title = "تایید (F5)";
            this.ucAccept.Type = Services.ButtonType.AcceptButton;
            this.ucAccept.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucAccept_OnClick);
            // 
            // ucHeader
            // 
            this.ucHeader.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ucHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucHeader.BackColor = System.Drawing.Color.White;
            this.ucHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ucHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.ucHeader.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucHeader.IsModified = false;
            this.ucHeader.Location = new System.Drawing.Point(-8, 26);
            this.ucHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucHeader.MinimumSize = new System.Drawing.Size(297, 34);
            this.ucHeader.Name = "ucHeader";
            this.ucHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucHeader.Size = new System.Drawing.Size(815, 34);
            this.ucHeader.TabIndex = 55751;
            // 
            // ucCancel
            // 
            this.ucCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucCancel.BackColor = System.Drawing.Color.Transparent;
            this.ucCancel.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucCancel.Location = new System.Drawing.Point(50, 564);
            this.ucCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucCancel.Name = "ucCancel";
            this.ucCancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ucCancel.Size = new System.Drawing.Size(125, 31);
            this.ucCancel.TabIndex = 55752;
            this.ucCancel.Title = "انصراف (Esc)";
            this.ucCancel.Type = Services.ButtonType.CancelButton;
            this.ucCancel.OnClick += new System.Func<object, System.EventArgs, System.Threading.Tasks.Task>(this.ucCancel_OnClick);
            // 
            // frmPeopleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ucCancel);
            this.Controls.Add(this.ucAccept);
            this.Controls.Add(this.ucHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmPeopleMain";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPeopleMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPeopleMain_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsSerivces.UC_Header ucHeader;
        private System.Windows.Forms.Panel panel1;
        private WindowsSerivces.UcActionButton ucAccept;
        private WindowsSerivces.UcActionButton ucCancel;
        private UcPeople_PublicInfo ucPablic;
        private UcPeople_PhoneBook ucTell;
        private UcPeople_BankHesab ucBank;
    }
}