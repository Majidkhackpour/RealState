using RealState.LoginPanel.FormsInPanel;
using Services;
using System;
using System.Windows.Forms;

namespace RealState.LoginPanel
{
    public partial class frmLoginMain : Form
    {
        private Form _current;
        private static frmLoginMain _instance = null;

        public Form CurrentForm
        {
            get => _current;
            set
            {
                _current = value;
                LoadNewForm(value);
            }
        }

        private void SetBackGround()
        {
            try
            {
                var rand = new Random().Next(1, 31);
                switch (rand)
                {
                    case 1:
                        picBackGroud.Image = Properties.Resources.Win11_1;
                        break;
                    case 2:
                        picBackGroud.Image = Properties.Resources.Win11_2;
                        break;
                    case 3:
                        picBackGroud.Image = Properties.Resources.Win11_3;
                        break;
                    case 4:
                        picBackGroud.Image = Properties.Resources.Win11_4;
                        break;
                    case 5:
                        picBackGroud.Image = Properties.Resources.Win11_5;
                        break;
                    case 6:
                        picBackGroud.Image = Properties.Resources.Win11_6;
                        break;
                    case 7:
                        picBackGroud.Image = Properties.Resources.Win11_7;
                        break;
                    case 8:
                        picBackGroud.Image = Properties.Resources.Win11_8;
                        break;
                    case 9:
                        picBackGroud.Image = Properties.Resources.Win11_9;
                        break;
                    case 10:
                        picBackGroud.Image = Properties.Resources.Win11_10;
                        break;
                    case 11:
                        picBackGroud.Image = Properties.Resources.Win11_11;
                        break;
                    case 12:
                        picBackGroud.Image = Properties.Resources.Win11_12;
                        break;
                    case 13:
                        picBackGroud.Image = Properties.Resources.Win11_13;
                        break;
                    case 14:
                        picBackGroud.Image = Properties.Resources.Win11_14;
                        break;
                    case 15:
                        picBackGroud.Image = Properties.Resources.Win11_15;
                        break;
                    case 16:
                        picBackGroud.Image = Properties.Resources.Win11_16;
                        break;
                    case 17:
                        picBackGroud.Image = Properties.Resources.Win11_17;
                        break;
                    case 18:
                        picBackGroud.Image = Properties.Resources.Win11_18;
                        break;
                    case 19:
                        picBackGroud.Image = Properties.Resources.Win11_19;
                        break;
                    case 20:
                        picBackGroud.Image = Properties.Resources.Win11_20;
                        break;
                    case 21:
                        picBackGroud.Image = Properties.Resources.Win11_21;
                        break;
                    case 22:
                        picBackGroud.Image = Properties.Resources.Win11_22;
                        break;
                    case 23:
                        picBackGroud.Image = Properties.Resources.Win11_23;
                        break;
                    case 24:
                        picBackGroud.Image = Properties.Resources.Win11_24;
                        break;
                    case 25:
                        picBackGroud.Image = Properties.Resources.Win11_25;
                        break;
                    case 26:
                        picBackGroud.Image = Properties.Resources.Win11_26;
                        break;
                    case 27:
                        picBackGroud.Image = Properties.Resources.Win11_27;
                        break;
                    case 28:
                        picBackGroud.Image = Properties.Resources.Win11_28;
                        break;
                    case 29:
                        picBackGroud.Image = Properties.Resources.Win11_29;
                        break;
                    case 30:
                        picBackGroud.Image = Properties.Resources.Win11_30;
                        break;
                    case 31:
                        picBackGroud.Image = Properties.Resources.Win11_31;
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadNewForm(Form frm)
        {
            try
            {
                frm.TopLevel = false;
                frm.AutoScroll = true;
                frm.ControlBox = false;
                frm.Dock = DockStyle.Fill;
                frm.BringToFront();
                pnlContent.Controls.Clear();
                pnlContent.Controls.Add(frm);
                pnlContent.AutoScroll = true;
                frm.Show();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public DialogResult Load_() => ShowDialog();

        public frmLoginMain() => InitializeComponent();
        public static frmLoginMain Instance => _instance ?? (_instance = new frmLoginMain());

        private void frmLoginMain_Load(object sender, EventArgs e)
        {
            try
            {
                SetBackGround();
                CurrentForm = new frmWorkingYear_Login();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmLoginMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Escape) return;
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
