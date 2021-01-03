using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advertise.Classes;
using Advertise.Forms.Simcard;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Print;
using Services;
using User;

namespace Building.Building
{
    public partial class frmShowBuildings : MetroForm
    {
        private bool _st = true;
        public Guid SelectedGuid { get; set; }
        private bool isShowMode = false;
        private IEnumerable<BuildingBussines> list;
        private List<string> ColumnList;
        private Guid ownerGuid = Guid.Empty;


        private async Task FillCmbAsync()
        {
            try
            {
                cmbStatus.Items.Add(EnBuildingStatus.All.GetDisplay());
                cmbStatus.Items.Add(EnBuildingStatus.Mojod.GetDisplay());
                cmbStatus.Items.Add(EnBuildingStatus.Vagozar.GetDisplay());

                var list = await BuildingTypeBussines.GetAllAsync();
                list.Add(new BuildingTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                btBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();


                var list2 = await UserBussines.GetAllAsync();
                list2.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                userBindingSource.DataSource = list2.OrderBy(q => q.Name).ToList();

                var list3 = await DocumentTypeBussines.GetAllAsync();
                list3.Add(new DocumentTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                docTypeBindingSource.DataSource = list3.OrderBy(q => q.Name).ToList();

                var list4 = await BuildingAccountTypeBussines.GetAllAsync();
                list4.Add(new BuildingAccountTypeBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[همه]"
                });
                AccTypeBindingSource.DataSource = list4.OrderBy(q => q.Name).ToList();

                cmbStatus.SelectedIndex = 0;
                cmbBuildingType.SelectedIndex = 0;
                cmbUser.SelectedValue = clsUser.CurrentUser.Guid;
                cmbDocType.SelectedIndex = 0;
                cmbAccType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadData(bool status, string search = "")
        {
            try
            {
                list = BuildingBussines
                    .GetAll(search, (EnBuildingStatus)cmbStatus.SelectedIndex - 1,
                        (Guid)cmbBuildingType.SelectedValue,
                        (Guid)cmbUser.SelectedValue,
                        (Guid)cmbDocType.SelectedValue,
                        (Guid)cmbAccType.SelectedValue);
                if (ownerGuid == Guid.Empty)
                {
                    Task.Run(() => ucPagger.PagingAsync(new CancellationToken(),
                        list.Where(q => q.Status == status).OrderByDescending(q => q.CreateDate), 100,
                        PagingPosition.GotoStartPage));
                }
                else
                {
                    Task.Run(() => ucPagger.PagingAsync(new CancellationToken(),
                        list.Where(q => q.Status == status && q.OwnerGuid == ownerGuid)
                            .OrderByDescending(q => q.CreateDate), 100,
                        PagingPosition.GotoStartPage));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetAccess()
        {
            try
            {
                var access = clsUser.CurrentUser.UserAccess;
                mnuAdd.Enabled = access?.Building.Building_Insert ?? false;
                mnuEdit.Enabled = access?.Building.Building_Update ?? false;
                mnuDelete.Enabled = access?.Building.Building_Delete ?? false;
                mnuStatus.Enabled = access?.Building.Building_Disable ?? false;
                mnuView.Enabled = access?.Building.Building_View ?? false;
                mnuMatchRequest.Enabled = access?.Building.Building_Show_request ?? false;
                mnuMojod.Enabled = access?.Building.Building_Mojod ?? false;
                mnuVagozar.Enabled = access?.Building.Building_Vagozar ?? false;
                mnuSendSms.Enabled = access?.Building.Building_Send_Sms ?? false;
                mnuSendToDivar.Enabled = access?.Building.Building_Send_Divar ?? false;
                mnuSendToSheypoor.Enabled = access?.Building.Building_Send_Sheypoor ?? false;
                mnuSendToTelegram.Enabled = access?.Building.Building_Send_Telegram ?? false;
                mnuPrint.Enabled = access?.Building.Building_Print ?? false;

                mnuSendSms.Visible = Settings.VersionAccess.Sms;
                mnuSendToDivar.Visible = Settings.VersionAccess.Advertise;
                mnuSendToSheypoor.Visible = Settings.VersionAccess.Advertise;
                mnuSendToTelegram.Visible = Settings.VersionAccess.Telegram;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetColumns()
        {
            try
            {
                ColumnList = Settings.Classes.clsBuilding.ColumnsList;
                if (ColumnList == null || ColumnList.Count <= 0)
                {
                    ColumnList = new List<string> { "کد", "تاریخ ثبت", "مالک", "اتاق", "آدرس", "محدوده" };

                    SaveColumns(ColumnList);

                    DGrid.Columns[dgCode.Index].Visible = true;
                    DGrid.Columns[dgDateSh.Index].Visible = true;
                    DGrid.Columns[dgOwnerName.Index].Visible = true;
                    DGrid.Columns[dgRoomCount.Index].Visible = true;
                    DGrid.Columns[dgAddress.Index].Visible = true;
                    DGrid.Columns[dgRegionName.Index].Visible = true;

                    mnuCode.Checked = true;
                    mnuDate.Checked = true;
                    mnuOwner.Checked = true;
                    mnuRoom.Checked = true;
                    mnuAddress.Checked = true;
                    mnuRegion.Checked = true;
                }
                else
                {
                    foreach (var item in ColumnList.ToList())
                    {
                        switch (item)
                        {
                            case "کد":
                                DGrid.Columns[dgCode.Index].Visible = true;
                                mnuCode.Checked = true;
                                break;
                            case "تاریخ":
                                DGrid.Columns[dgDateSh.Index].Visible = true;
                                mnuDate.Checked = true;
                                break;
                            case "مالک":
                                DGrid.Columns[dgOwnerName.Index].Visible = true;
                                mnuOwner.Checked = true;
                                break;
                            case "نوع ملک":
                                DGrid.Columns[dgType.Index].Visible = true;
                                mnuType.Checked = true;
                                break;
                            case "اتاق":
                                DGrid.Columns[dgRoomCount.Index].Visible = true;
                                mnuRoom.Checked = true;
                                break;
                            case "مساحت":
                                DGrid.Columns[dgMasahat.Index].Visible = true;
                                mnuMasahat.Checked = true;
                                break;
                            case "زیربنا":
                                DGrid.Columns[dgZirBana.Index].Visible = true;
                                mnuZirBana.Checked = true;
                                break;
                            case "رهن":
                                DGrid.Columns[dgRahn.Index].Visible = true;
                                mnuRahn.Checked = true;
                                break;
                            case "اجاره":
                                DGrid.Columns[dgEjare.Index].Visible = true;
                                mnuEjare.Checked = true;
                                break;
                            case "فروش":
                                DGrid.Columns[dgSellPrice.Index].Visible = true;
                                mnuSell.Checked = true;
                                break;
                            case "محدوده":
                                DGrid.Columns[dgRegionName.Index].Visible = true;
                                mnuRegion.Checked = true;
                                break;
                            case "وضعیت":
                                DGrid.Columns[dgBuildingStatus.Index].Visible = true;
                                mnuBStatus.Checked = true;
                                break;
                            case "آدرس":
                                DGrid.Columns[dgAddress.Index].Visible = true;
                                mnuAddress.Checked = true;
                                break;
                            case "مشاور":
                                DGrid.Columns[dgUserName.Index].Visible = true;
                                mnuUserName.Checked = true;
                                break;
                            case "وام":
                                DGrid.Columns[dgVam.Index].Visible = true;
                                mnuVam.Checked = true;
                                break;
                            case "قسط":
                                DGrid.Columns[dgQest.Index].Visible = true;
                                mnuQest.Checked = true;
                                break;
                            case "تجاری":
                                DGrid.Columns[dgTejari.Index].Visible = true;
                                mnuTejari.Checked = true;
                                break;
                            case "سال":
                                DGrid.Columns[dgSaleSakht.Index].Visible = true;
                                mnuSaleSakht.Checked = true;
                                break;
                            case "جهت":
                                DGrid.Columns[dgSide.Index].Visible = true;
                                mnuSide.Checked = true;
                                break;
                            case "سند":
                                DGrid.Columns[dgDocType.Index].Visible = true;
                                mnuDocType.Checked = true;
                                break;
                            case "ارجحیت":
                                DGrid.Columns[dgRentalAuthorityName.Index].Visible = true;
                                mnuRental.Checked = true;
                                break;
                            case "کاربری":
                                DGrid.Columns[dgAccountType.Index].Visible = true;
                                mnuAccountType.Checked = true;
                                break;
                            case "وضعیت ملک":
                                DGrid.Columns[dgCondition.Index].Visible = true;
                                mnuCondition.Checked = true;
                                break;
                            case "نما":
                                DGrid.Columns[dgView.Index].Visible = true;
                                mnuBView.Checked = true;
                                break;
                            case "کفپوش":
                                DGrid.Columns[dgFloorCover.Index].Visible = true;
                                mnuFloor.Checked = true;
                                break;
                            case "آشپزخانه":
                                DGrid.Columns[dgKitchenService.Index].Visible = true;
                                mnuKitchen.Checked = true;
                                break;
                            case "آب":
                                DGrid.Columns[dgWater.Index].Visible = true;
                                mnuWater.Checked = true;
                                break;
                            case "برق":
                                DGrid.Columns[dgBarq.Index].Visible = true;
                                mnuBarq.Checked = true;
                                break;
                            case "گاز":
                                DGrid.Columns[dgGas.Index].Visible = true;
                                mnuGas.Checked = true;
                                break;
                            case "تلفن":
                                DGrid.Columns[dgTell.Index].Visible = true;
                                mnuTell.Checked = true;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveColumns(List<string> listcl)
        {
            try
            {
                listcl = listcl.GroupBy(x => x)
                    .Select(x => x.First()).ToList();
                Settings.Classes.clsBuilding.ColumnsList = listcl;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Select()
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private bool ST
        {
            get => _st;
            set
            {
                _st = value;
                if (_st)
                {
                    mnuStatus.Text = "غیرفعال (Ctrl+S)";
                    LoadData(ST, txtSearch.Text);
                    mnuDelete.Text = "حذف (Del)";
                }
                else
                {
                    mnuStatus.Text = "فعال (Ctrl+S)";
                    LoadData(ST, txtSearch.Text);
                    mnuDelete.Text = "فعال کردن";
                }
            }
        }

        public frmShowBuildings(bool _isShowMode, Guid ownerGuid = default)
        {
            InitializeComponent();
            isShowMode = _isShowMode;
            this.ownerGuid = ownerGuid;
            ucPagger.OnBindDataReady += UcPagger_OnBindDataReady;
            SetAccess();
            SetColumns();
        }

        private void UcPagger_OnBindDataReady(object sender, WindowsSerivces.Pagging.FooterBindingDataReadyEventArg e)
        {
            try
            {
                var count = e?.ListData?.Count ?? 0;
                if (count <= 0) count = 50;
                Invoke(new MethodInvoker(() =>
                    BuildingBindingSource.DataSource = e?.ListData?.Take(count)?.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void frmShowBuildings_Load(object sender, EventArgs e)
        {
            await FillCmbAsync();
            LoadData(ST);
        }
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmShowBuildings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        mnuAdd.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.F12:
                        mnuView.PerformClick();
                        break;
                    case Keys.S:
                        if (e.Control) ST = !ST;
                        break;
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        if (!isShowMode) mnuEdit.PerformClick();
                        else Select();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbBuildingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!isShowMode) return;
                Select();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuStatus_Click(object sender, EventArgs e) => ST = !ST;
        private async void mnuSendToSheypoor_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var simList = new List<SimcardBussines>();
                var buList = new List<BuildingBussines>();

                var bu = await BuildingBussines.GetAsync((Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                if (bu == null) return;
                buList.Add(bu);

                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    simList.Add(await SimcardBussines.GetAsync(frm.SelectedGuid));

                res.AddReturnedValue(await Utility.ManageAdvSend(buList, simList, AdvertiseType.Sheypoor));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ارسال ملک به شیپور");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
            }
        }
        private async void mnuSendToDivar_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var simList = new List<SimcardBussines>();
                var buList = new List<BuildingBussines>();

                var bu = await BuildingBussines.GetAsync((Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value);
                if (bu == null) return;
                buList.Add(bu);

                var frm = new frmShowSimcard(true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    simList.Add(await SimcardBussines.GetAsync(frm.SelectedGuid));

                res.AddReturnedValue(await Utility.ManageAdvSend(buList, simList, AdvertiseType.Divar));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در ارسال ملک به دیوار");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
            }
        }
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.Building_List, frm._PrintType) { Lst = new List<object>(list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.ExportBuilding(list, this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuVagozar_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                if (bu.BuildingStatus == EnBuildingStatus.Vagozar)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "وضعیت ملک هم اکنون واگذارشده می باشد");
                    return;
                }

                if (MessageBox.Show(this,
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "تغییر وضعیت ملک",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                bu.BuildingStatus = EnBuildingStatus.Vagozar;
                res.AddReturnedValue(await bu.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در تغییر وضعیت ملک به واگذار شده");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else LoadData(ST, txtSearch.Text);
            }
        }
        private async void mnuMojod_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                if (bu.BuildingStatus == EnBuildingStatus.Mojod)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "وضعیت ملک هم اکنون موجود می باشد");
                    return;
                }

                if (MessageBox.Show(this,
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "تغییر وضعیت ملک",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;

                bu.BuildingStatus = EnBuildingStatus.Mojod;
                res.AddReturnedValue(await bu.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در تغییر وضعیت ملک به موجود");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else LoadData(ST, txtSearch.Text);
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmBuildingMain(guid, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmBuildingMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmBuildingMain();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
                {
                    if (MessageBox.Show(this,
                            $@" آیا از حذف ملک{DGrid[dgCode.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                    if (res.HasError) return;
                    UserLog.Save(EnLogAction.Delete, EnLogPart.Building);
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن ملک{DGrid[dgCode.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await BuildingBussines.GetAsync(guid);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(true));
                    if (res.HasError) return;
                    UserLog.Save(EnLogAction.Enable, EnLogPart.Building);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                {
                    var frm = new FrmShowErrorMessage(res, "خطا در تغییر وضعیت ملک");
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
                else LoadData(ST, txtSearch.Text);
            }
        }
        private void mnuCode_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuCode.Checked)
                {
                    ColumnList.Add("کد");
                    DGrid.Columns[dgCode.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("کد");
                    DGrid.Columns[dgCode.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuDate.Checked)
                {
                    ColumnList.Add("تاریخ");
                    DGrid.Columns[dgDateSh.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("تاریخ");
                    DGrid.Columns[dgDateSh.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuOwner_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuOwner.Checked)
                {
                    ColumnList.Add("مالک");
                    DGrid.Columns[dgOwnerName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("مالک");
                    DGrid.Columns[dgOwnerName.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuType.Checked)
                {
                    ColumnList.Add("نوع ملک");
                    DGrid.Columns[dgType.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("نوع ملک");
                    DGrid.Columns[dgType.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRoom_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRoom.Checked)
                {
                    ColumnList.Add("اتاق");
                    DGrid.Columns[dgRoomCount.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("اتاق");
                    DGrid.Columns[dgRoomCount.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuMasahat_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuMasahat.Checked)
                {
                    ColumnList.Add("مساحت");
                    DGrid.Columns[dgMasahat.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("مساحت");
                    DGrid.Columns[dgMasahat.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuZirBana_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuZirBana.Checked)
                {
                    ColumnList.Add("زیربنا");
                    DGrid.Columns[dgZirBana.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("زیربنا");
                    DGrid.Columns[dgZirBana.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRahn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRahn.Checked)
                {
                    ColumnList.Add("رهن");
                    DGrid.Columns[dgRahn.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("رهن");
                    DGrid.Columns[dgRahn.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuEjare_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuEjare.Checked)
                {
                    ColumnList.Add("اجاره");
                    DGrid.Columns[dgEjare.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("اجاره");
                    DGrid.Columns[dgEjare.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuSell_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuSell.Checked)
                {
                    ColumnList.Add("فروش");
                    DGrid.Columns[dgSellPrice.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("فروش");
                    DGrid.Columns[dgSellPrice.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRegion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRegion.Checked)
                {
                    ColumnList.Add("محدوده");
                    DGrid.Columns[dgRegionName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("محدوده");
                    DGrid.Columns[dgRegionName.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuBStatus_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuBStatus.Checked)
                {
                    ColumnList.Add("وضعیت");
                    DGrid.Columns[dgBuildingStatus.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("وضعیت");
                    DGrid.Columns[dgBuildingStatus.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAddress_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuAddress.Checked)
                {
                    ColumnList.Add("آدرس");
                    DGrid.Columns[dgAddress.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("آدرس");
                    DGrid.Columns[dgAddress.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuUserName_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuUserName.Checked)
                {
                    ColumnList.Add("مشاور");
                    DGrid.Columns[dgUserName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("مشاور");
                    DGrid.Columns[dgUserName.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuVam_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuVam.Checked)
                {
                    ColumnList.Add("وام");
                    DGrid.Columns[dgVam.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("وام");
                    DGrid.Columns[dgVam.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuQest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuQest.Checked)
                {
                    ColumnList.Add("قسط");
                    DGrid.Columns[dgQest.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("قسط");
                    DGrid.Columns[dgQest.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuTejari_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuTejari.Checked)
                {
                    ColumnList.Add("تجاری");
                    DGrid.Columns[dgTejari.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("تجاری");
                    DGrid.Columns[dgTejari.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuSaleSakht_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuSaleSakht.Checked)
                {
                    ColumnList.Add("سال");
                    DGrid.Columns[dgSaleSakht.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("سال");
                    DGrid.Columns[dgSaleSakht.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuSide_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuSide.Checked)
                {
                    ColumnList.Add("جهت");
                    DGrid.Columns[dgSide.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("جهت");
                    DGrid.Columns[dgSide.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuDocType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuDocType.Checked)
                {
                    ColumnList.Add("سند");
                    DGrid.Columns[dgDocType.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("سند");
                    DGrid.Columns[dgDocType.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuRental_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuRental.Checked)
                {
                    ColumnList.Add("ارجحیت");
                    DGrid.Columns[dgRentalAuthorityName.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("ارجحیت");
                    DGrid.Columns[dgRentalAuthorityName.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuAccountType_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuAccountType.Checked)
                {
                    ColumnList.Add("کاربری");
                    DGrid.Columns[dgAccountType.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("کاربری");
                    DGrid.Columns[dgAccountType.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuCondition_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuCondition.Checked)
                {
                    ColumnList.Add("وضعیت ملک");
                    DGrid.Columns[dgCondition.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("وضعیت ملک");
                    DGrid.Columns[dgCondition.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuBView_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuBView.Checked)
                {
                    ColumnList.Add("نما");
                    DGrid.Columns[dgView.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("نما");
                    DGrid.Columns[dgView.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuFloor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuFloor.Checked)
                {
                    ColumnList.Add("کفپوش");
                    DGrid.Columns[dgFloorCover.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("کفپوش");
                    DGrid.Columns[dgFloorCover.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuKitchen_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuKitchen.Checked)
                {
                    ColumnList.Add("آشپزخانه");
                    DGrid.Columns[dgKitchenService.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("آشپزخانه");
                    DGrid.Columns[dgKitchenService.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuWater_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuWater.Checked)
                {
                    ColumnList.Add("آب");
                    DGrid.Columns[dgWater.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("آب");
                    DGrid.Columns[dgWater.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuBarq_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuBarq.Checked)
                {
                    ColumnList.Add("برق");
                    DGrid.Columns[dgBarq.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("برق");
                    DGrid.Columns[dgBarq.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuGas_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuGas.Checked)
                {
                    ColumnList.Add("گاز");
                    DGrid.Columns[dgGas.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("گاز");
                    DGrid.Columns[dgGas.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuTell_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (mnuTell.Checked)
                {
                    ColumnList.Add("تلفن");
                    DGrid.Columns[dgTell.Index].Visible = true;
                    SaveColumns(ColumnList);
                }
                else
                {
                    ColumnList = ColumnList.GroupBy(x => x).Select(x => x.First()).ToList();
                    ColumnList.Remove("تلفن");
                    DGrid.Columns[dgTell.Index].Visible = false;
                    SaveColumns(ColumnList);
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadData(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (BuildingBindingSource.Count <= 0 || BuildingBindingSource.Count == ucPagger.list.Count)
                    return;
                var addedItem = 0;
                var percent = 100 * (double)e.NewValue / BuildingBindingSource.Count;
                if (percent <= 70) return;
                foreach (var item in ucPagger.NextItemsInPage(BuildingBindingSource.Count, 50))
                {
                    BuildingBindingSource.Add(item);
                    addedItem++;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void DGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PicBox.Image = null;
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (guid == Guid.Empty) return;
                var bu = await BuildingBussines.GetAsync(guid);
                if (bu == null) return;
                if (string.IsNullOrEmpty(bu.Image)) return;
                var path = Path.Combine(Application.StartupPath + "\\Images", bu.Image);
                PicBox.ImageLocation = path;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
