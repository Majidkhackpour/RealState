namespace Accounting.Reception
{
    partial class frmReceptionFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceptionFilter));
            this.lblPeoples = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.picUsers = new System.Windows.Forms.PictureBox();
            this.picPeoples = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPeoples)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPeoples
            // 
            this.lblPeoples.AutoSize = true;
            this.lblPeoples.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPeoples.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPeoples.Location = new System.Drawing.Point(240, 159);
            this.lblPeoples.Name = "lblPeoples";
            this.lblPeoples.Size = new System.Drawing.Size(66, 29);
            this.lblPeoples.TabIndex = 1;
            this.lblPeoples.Text = "اشخاص";
            this.lblPeoples.Click += new System.EventHandler(this.lblPeoples_Click);
            this.lblPeoples.MouseEnter += new System.EventHandler(this.lblPeoples_MouseEnter);
            this.lblPeoples.MouseLeave += new System.EventHandler(this.lblPeoples_MouseLeave);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUser.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUser.Location = new System.Drawing.Point(50, 159);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(63, 29);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "کاربران";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            this.lblUser.MouseEnter += new System.EventHandler(this.lblUser_MouseEnter);
            this.lblUser.MouseLeave += new System.EventHandler(this.lblUser_MouseLeave);
            // 
            // picUsers
            // 
            this.picUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUsers.Image = global::Accounting.Properties.Resources._70;
            this.picUsers.Location = new System.Drawing.Point(23, 33);
            this.picUsers.Name = "picUsers";
            this.picUsers.Size = new System.Drawing.Size(120, 110);
            this.picUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUsers.TabIndex = 0;
            this.picUsers.TabStop = false;
            this.picUsers.Click += new System.EventHandler(this.picUsers_Click);
            // 
            // picPeoples
            // 
            this.picPeoples.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPeoples.Image = global::Accounting.Properties.Resources._03;
            this.picPeoples.Location = new System.Drawing.Point(211, 33);
            this.picPeoples.Name = "picPeoples";
            this.picPeoples.Size = new System.Drawing.Size(120, 110);
            this.picPeoples.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPeoples.TabIndex = 0;
            this.picPeoples.TabStop = false;
            this.picPeoples.Click += new System.EventHandler(this.picPeoples_Click);
            // 
            // frmReceptionFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 200);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPeoples);
            this.Controls.Add(this.picUsers);
            this.Controls.Add(this.picPeoples);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReceptionFilter";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            ((System.ComponentModel.ISupportInitialize)(this.picUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPeoples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPeoples;
        private System.Windows.Forms.Label lblPeoples;
        private System.Windows.Forms.PictureBox picUsers;
        private System.Windows.Forms.Label lblUser;
    }
}