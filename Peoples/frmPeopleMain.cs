using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;

namespace Peoples
{
    public partial class frmPeopleMain : MetroForm
    {
        private PeoplesBussines cls;
        public Guid SelectedGuid { get; private set; }

        private async Task SetDataAsync()
        {
            try
            {
                await ucPablic.SetCodeAsync(cls?.Code);
                ucPablic.NationalCode = cls?.NationalCode;
                ucPablic.ObjectName = cls?.Name;
                ucPablic.IdCode = cls?.IdCode;
                ucPablic.FatherName = cls?.FatherName;
                ucPablic.BirthPlace = cls?.PlaceBirth;
                ucPablic.IssuedFrom = cls?.IssuedFrom;
                ucPablic.PostalCode = cls?.PostalCode;
                ucPablic.Address = cls?.Address;
                ucPablic.BirthDate = cls?.DateBirth;
                ucPablic.AccountFirst = cls?.AccountFirst ?? 0;
                await ucPablic.SetGroupGuidAsync(cls?.GroupGuid ?? Guid.Empty);
                ucTell.SetPhoneBookList(cls?.TellList);
                ucBank.SetBankList(cls?.BankList);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPeopleMain(PeoplesBussines obj, bool isShowMode)
        {
            try
            {
                InitializeComponent();
                cls = obj;
                if (!cls.IsModified)
                    ucHeader.Text = "افزودن شخص جدید";
                else
                    ucHeader.Text = !isShowMode ? $"ویرایش {cls.Name}" : $"مشاهده {cls.Name}";
                ucHeader.IsModified = cls.IsModified;
                ucPablic.Enabled = !isShowMode;
                ucTell.Enabled = !isShowMode;
                ucBank.Enabled = !isShowMode;
                ucAccept.Enabled = !isShowMode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task ucAccept_OnClick(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                    cls.Guid = Guid.NewGuid();

                cls.Name = ucPablic.ObjectName.Trim();
                cls.Modified = DateTime.Now;
                cls.Code = ucPablic.Code.Trim();
                cls.NationalCode = ucPablic.NationalCode.Trim();
                cls.IdCode = ucPablic.IdCode.Trim();
                cls.FatherName = ucPablic.FatherName;
                cls.GroupGuid = ucPablic.GroupGuid;
                cls.PlaceBirth = ucPablic.BirthPlace;
                cls.DateBirth = ucPablic.BirthDate;
                cls.IssuedFrom = ucPablic.IssuedFrom;
                cls.PostalCode = ucPablic.PostalCode;
                cls.Address = ucPablic.Address;
                cls.AccountFirst = ucPablic.AccountFirst;
                cls.ServerStatus = ServerStatus.None;
                cls.TellList = ucTell.GetPhoneBookList();
                cls.BankList = ucBank.GetBankList();
                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                res.AddReturnedValue(exception);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ثبت شخص");
                else
                {
                    SelectedGuid = cls.Guid;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private async Task ucCancel_OnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private async void frmPeopleMain_Load(object sender, EventArgs e)
        {
            try
            {
                ucPablic.SetAccess(VersionAccess.Accounting);
                await ucTell.InitAsync();
                await ucBank.InitAsync();
                await SetDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmPeopleMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!ucAccept.Focused && !ucCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        ucAccept.PerformClick();
                        break;
                    case Keys.Escape:
                        ucCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
