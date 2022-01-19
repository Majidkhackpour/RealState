using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using ExcelDataReader;
using MetroFramework.Forms;
using Notification;
using Payamak.PhoneBook;
using Services;
using User;

namespace Payamak
{
    public partial class frmSendSms : MetroForm
    {
        private Guid peGuid = Guid.Empty;
        private DataTableCollection dt;


        private async Task LoadPanelsAsync()
        {
            try
            {
                var list = await SmsPanelsBussines.GetAllAsync();
                panelBindingSource.DataSource = list.Where(q => q.Status).ToList();



                var def = SettingsBussines.Setting.Sms.DefaultPanelGuid;
                if (def != Guid.Empty) cmbPanel.SelectedValue = def;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void AddItems(string item)
        {
            try
            {
                var list = new List<string>() { item };
                foreach (var lbxNumbersItem in lbxNumbers.Items)
                    list.Add(lbxNumbersItem.ToString());
                AddItems(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void AddItems(List<string> list)
        {
            try
            {
                lbxNumbers.Items.Clear();

                list = list.GroupBy(q => q).Where(q => q.Count() >= 0).Select(q => q.Key).ToList();

                foreach (var number in list)
                    lbxNumbers.Items.Add(number);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmSendSms()
        {
            InitializeComponent();
            ucHeader.Text = "ارسال پیامک";
        }
        public frmSendSms(List<string> lstNumbers, Guid guid)
        {
            InitializeComponent();
            ucHeader.Text = "ارسال پیامک";
            peGuid = guid;
            AddItems(lstNumbers);
        }
        public frmSendSms(List<Guid> lstGuid, string text)
        {
            InitializeComponent();
            ucHeader.Text = "ارسال پیامک";
            txtMessage.Text = text;
            Task.Run(()=>FillListAsync(lstGuid));
        }

        private async Task FillListAsync(List<Guid> lstGuid)
        {
            try
            {
                while (!IsHandleCreated)
                {
                    await Task.Delay(100);
                }

                Invoke(new MethodInvoker(async () =>
                {
                    var lstNumbers = new List<string>();
                    foreach (var guid in lstGuid)
                    {
                        var numbers = await PhoneBookBussines.GetAllAsync(guid, true);
                        if (numbers.Count <= 0) continue;
                        lstNumbers = numbers.Where(q => q.Tell.StartsWith("09") && q.Tell.Length > 10)
                            .Select(q => q.Tell)
                            .ToList();
                    }

                    AddItems(lstNumbers);
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmSendSms_Load(object sender, EventArgs e)
        {
            await LoadPanelsAsync();
            lblCounter.Text = "";
        }
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblCounter.Text = txtMessage.TextLength.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNumber.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("شماره نمی تواند خالی باشد");
                    txtNumber.Focus();
                    return;
                }
                if (!CheckPerssonValidation.CheckMobile(txtNumber.Text.Trim()))
                {
                    frmNotification.PublicInfo.ShowMessage("شماره موبایل وارد شده صحیح نمی باشد");
                    txtNumber.Focus();
                    txtNumber.SelectAll();
                    return;
                }

                AddItems(txtNumber.Text);
                txtNumber.Text = "";
                txtNumber.Focus();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmSendSms_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        if (txtNumber.Focused) btnAdd.PerformClick();
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbxNumbers.Items.Count <= 0) return;
                if (lbxNumbers.SelectedItem == null) return;

                if (MessageBox.Show(this, $"آیا از حذف شماره {lbxNumbers.SelectedItem} از لیست ارسال اطمینان دارید؟",
                        "حذف شماره از لیست ارسال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) !=
                    DialogResult.Yes) return;

                lbxNumbers.Items.Remove(lbxNumbers.SelectedItem);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                var ret = await Utilities.PingHostAsync();
                if (ret.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(ret.ErrorMessage);
                    return;
                }


                if (lbxNumbers.Items.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("هیچ شماره ای جهت ارسال، وارد نشده است");
                    txtNumber.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtMessage.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("متن پیام ارسالی نمی تواند خالی باشد");
                    txtMessage.Focus();
                    return;
                }

                var list = new List<string>();
                foreach (var item in lbxNumbers.Items)
                    list.Add(item.ToString());

                var panel = await SmsPanelsBussines.GetAsync((Guid)cmbPanel.SelectedValue);
                if (panel == null) return;
                var sApi = new Sms.Api(panel.API.Trim());

                var index = 0;
                var frm = new frmSplash(list.Count);
                frm.Show(this);

                var res = sApi.Send(panel.Sender, list, txtMessage.Text);

                if (res.Count <= 0) return;
                foreach (var result in res)
                {
                    frm.Level = index;
                    var smsLog = new SmsLogBussines()
                    {
                        Guid = Guid.NewGuid(),
                        UserGuid = UserBussines.CurrentUser.Guid,
                        Cost = result.Cost,
                        Message = result.Message,
                        MessageId = result.Messageid,
                        Reciver = result.Receptor,
                        Sender = result.Sender,
                        StatusText = result.StatusText
                    };

                    await smsLog.SaveAsync();
                    index++;
                }

                frmNotification.PublicInfo.ShowMessage("ارسال پیامک با موفقیت انجام شد");

                Close();

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnAddExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new OpenFileDialog { Multiselect = false };
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var stream = File.Open(frm.FileName, FileMode.Open, FileAccess.Read);
                var reader = ExcelReaderFactory.CreateReader(stream);
                var res = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                });
                dt = res.Tables;





                var table = dt["Sheet1"];
                var list = new List<string>();
                foreach (DataRow row in table.Rows)
                    list.Add(row.ItemArray[0].ToString());
                AddItems(list);


            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPhoneBookSearch(peGuid);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var list = new List<string>();
                foreach (var item in frm.SelectedNumber)
                    list.Add(item);
                AddItems(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
