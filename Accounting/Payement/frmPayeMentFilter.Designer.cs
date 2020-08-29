namespace Accounting.Payement
{
    partial class frmPayeMentFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayeMentFilter));
            this.lblHazine = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblPeoples = new System.Windows.Forms.Label();
            this.picHazine = new System.Windows.Forms.PictureBox();
            this.picUsers = new System.Windows.Forms.PictureBox();
            this.picPeoples = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHazine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPeoples)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHazine
            // 
            this.lblHazine.AutoSize = true;
            this.lblHazine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHazine.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblHazine.Location = new System.Drawing.Point(42, 164);
            this.lblHazine.Name = "lblHazine";
            this.lblHazine.Size = new System.Drawing.Size(74, 29);
            this.lblHazine.TabIndex = 5;
            this.lblHazine.Text = "هزینه ها";
            this.lblHazine.Click += new System.EventHandler(this.lblHazine_Click);
            this.lblHazine.MouseEnter += new System.EventHandler(this.lblHazine_MouseEnter);
            this.lblHazine.MouseLeave += new System.EventHandler(this.lblHazine_MouseLeave);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUsers.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblUsers.Location = new System.Drawing.Point(240, 164);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(63, 29);
            this.lblUsers.TabIndex = 6;
            this.lblUsers.Text = "کاربران";
            this.lblUsers.Click += new System.EventHandler(this.lblUsers_Click);
            this.lblUsers.MouseEnter += new System.EventHandler(this.lblUsers_MouseEnter);
            this.lblUsers.MouseLeave += new System.EventHandler(this.lblUsers_MouseLeave);
            // 
            // lblPeoples
            // 
            this.lblPeoples.AutoSize = true;
            this.lblPeoples.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPeoples.Font = new System.Drawing.Font("B Yekan", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPeoples.Location = new System.Drawing.Point(423, 164);
            this.lblPeoples.Name = "lblPeoples";
            this.lblPeoples.Size = new System.Drawing.Size(66, 29);
            this.lblPeoples.TabIndex = 7;
            this.lblPeoples.Text = "اشخاص";
            this.lblPeoples.Click += new System.EventHandler(this.lblPeoples_Click);
            this.lblPeoples.MouseEnter += new System.EventHandler(this.lblPeoples_MouseEnter);
            this.lblPeoples.MouseLeave += new System.EventHandler(this.lblPeoples_MouseLeave);
            // 
            // picHazine
            // 
            this.picHazine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHazine.Image = global::Accounting.Properties.Resources.P_1_99;
            this.picHazine.Location = new System.Drawing.Point(16, 33);
            this.picHazine.Name = "picHazine";
            this.picHazine.Size = new System.Drawing.Size(120, 110);
            this.picHazine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHazine.TabIndex = 2;
            this.picHazine.TabStop = false;
            this.picHazine.Click += new System.EventHandler(this.picHazine_Click);
            // 
            // picUsers
            // 
            this.picUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUsers.Image = global::Accounting.Properties.Resources._70;
            this.picUsers.Location = new System.Drawing.Point(208, 33);
            this.picUsers.Name = "picUsers";
            this.picUsers.Size = new System.Drawing.Size(120, 110);
            this.picUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUsers.TabIndex = 3;
            this.picUsers.TabStop = false;
            this.picUsers.Click += new System.EventHandler(this.picUsers_Click);
            // 
            // picPeoples
            // 
            this.picPeoples.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPeoples.Image = global::Accounting.Properties.Resources._03;
            this.picPeoples.Location = new System.Drawing.Point(396, 33);
            this.picPeoples.Name = "picPeoples";
            this.picPeoples.Size = new System.Drawing.Size(120, 110);
            this.picPeoples.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPeoples.TabIndex = 4;
            this.picPeoples.TabStop = false;
            this.picPeoples.Click += new System.EventHandler(this.picPeoples_Click);
            // 
            // frmPayeMentFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 200);
            this.Controls.Add(this.lblHazine);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lblPeoples);
            this.Controls.Add(this.picHazine);
            this.Controls.Add(this.picUsers);
            this.Controls.Add(this.picPeoples);
            this.Font = new System.Drawing.Font("B Yekan", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(534, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(534, 200);
            this.Name = "frmPayeMentFilter";
            this.Padding = new System.Windows.Forms.Padding(27, 92, 27, 31);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPayeMentFilter_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picHazine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPeoples)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHazine;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblPeoples;
        private System.Windows.Forms.PictureBox picHazine;
        private System.Windows.Forms.PictureBox picUsers;
        private System.Windows.Forms.PictureBox picPeoples;
    }
}