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
using Services;

namespace Peoples
{
    public partial class frmImportExcel : MetroForm
    {
        #region Properties
        public short ColCode => txtCode.Text.ParseToShort();
        public short ColName => txtName.Text.ParseToShort();
        public short ColNationalCode => txtNationalCode.Text.ParseToShort();
        public short ColIdCode => txtIdCode.Text.ParseToShort();
        public short ColFatherName => txtFatherName.Text.ParseToShort();
        public short ColPlaceB => txtPlaceBirth.Text.ParseToShort();
        public short ColDateB => txtDateBirth.Text.ParseToShort();
        public short ColAddress => txtAddress.Text.ParseToShort();
        public short ColIssued => txtIssuedFrom.Text.ParseToShort();
        public short ColPostalCode => txtPostalCode.Text.ParseToShort();
        public short ColGroup => txtGroup.Text.ParseToShort();
        public short ColAccount => txtAccount.Text.ParseToShort();
        public short ColTell1 => txtTell1.Text.ParseToShort();
        public short ColTell2 => txtTell2.Text.ParseToShort();
        public short ColTell3 => txtTell3.Text.ParseToShort();
        public short ColTell4 => txtTell4.Text.ParseToShort();
        #endregion

        private async Task LoadGroupsAsync()
        {
            try
            {
                var list = await PeopleGroupBussines.GetAllAsync();
                groupBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);

                cmbDuplicateName.SelectedIndex = 0;
                cmbDuplicateCode.SelectedIndex = 0;
                cmbDuplicateCode.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmImportExcel()
        {
            InitializeComponent();
        }
        private DataTableCollection dt;
        private void LoadSheets()
        {
            try
            {
                var stream = File.Open(txtPath.Text, FileMode.Open, FileAccess.Read);
                var reader = ExcelReaderFactory.CreateReader(stream);
                var res = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                });
                dt = res.Tables;
                cmbSheet.Items.Clear();
                foreach (DataTable table in dt)
                    cmbSheet.Items.Add(table.TableName);
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
                var frm = new OpenFileDialog { Multiselect = false };
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                txtPath.Text = frm.FileName;
                LoadSheets();
                if (cmbSheet.Items.Count > 0)
                    cmbSheet.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var table = dt[cmbSheet.SelectedItem.ToString()];
                DGrid.DataSource = table;

                for (var i = 0; i < DGrid.ColumnCount; i++)
                    DGrid.Columns[i].HeaderText = DGrid.Columns[i].HeaderText + "(" + (i + 1) + ")";
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmImportExcel_Load(object sender, EventArgs e) => await LoadGroupsAsync();
        private string GetValue(short clIndex, int rowIndex)
        {
            var str = "";
            try
            {
                if (clIndex == 0) return str;
                str = DGrid.Rows[rowIndex].Cells[clIndex - 1].Value.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return str;
        }
        private async Task<PeoplesBussines> GetItemsAsync(int index)
        {
            var pe = new PeoplesBussines();
            try
            {
                if (ColName == 0) return null;
                var name = GetValue(ColName, index);

                //بدون نام درج نشود
                if (cmbDuplicateName.SelectedIndex == 0)
                    if (string.IsNullOrEmpty(name))
                        return null;


                //نام تکراری درج نشه
                if (cmbDuplicateName.SelectedIndex == 1)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        var checkName = await PeoplesBussines.CheckNameAsync(name);
                        if (!checkName) return null;
                        pe.Name = name;
                    }
                }



                pe.Guid = Guid.NewGuid();
                if (string.IsNullOrEmpty(pe.Name))
                    pe.Name = GetValue(ColName, index);

                var code = GetValue(ColCode, index);

                //بدون کد درج نشه
                if (cmbDuplicateCode.SelectedIndex == 0)
                    if (string.IsNullOrEmpty(code)) return null;

                //کد تکراری درج نشه
                if (cmbDuplicateCode.SelectedIndex == 1)
                {
                    if (!string.IsNullOrEmpty(code))
                    {
                        var checkCode = await PeoplesBussines.CheckCodeAsync(code, pe.Guid);
                        if (!checkCode) return null;
                        pe.Code = code;
                    }
                }

                //پیشنهاد کد جدید در صورت خالی بودن یا تکراری بودن
                if (cmbDuplicateCode.SelectedIndex == 2)
                {
                    var newCode = await PeoplesBussines.NextCodeAsync();
                    if (string.IsNullOrEmpty(code) || ! await PeoplesBussines.CheckCodeAsync(code, pe.Guid))
                        pe.Code = newCode;
                    else pe.Code = code;
                }


                var grp = GetValue(ColGroup, index);
                if (string.IsNullOrEmpty(grp))
                    pe.GroupGuid = (Guid)cmbWithoutGroup.SelectedValue;
                else
                {
                    var group = PeopleGroupBussines.Get(grp);
                    if (group == null) pe.GroupGuid = (Guid)cmbWithoutGroup.SelectedValue;
                    else pe.GroupGuid = group.Guid;
                }

                var acc = (decimal)0;
                var x = GetValue(ColAccount, index);
                acc = x.RemoveNoNumbers("").ParseToDecimal();
                if (x.Contains("??") | x.Contains("-"))
                    acc = -acc;
                pe.Account = acc;
                pe.AccountFirst = acc;

                pe.NationalCode = GetValue(ColNationalCode, index);
                pe.IdCode = GetValue(ColIdCode, index);
                pe.FatherName = GetValue(ColFatherName, index);
                pe.PlaceBirth = GetValue(ColPlaceB, index);
                pe.DateBirth = GetValue(ColDateB, index);
                pe.IssuedFrom = GetValue(ColIssued, index);
                pe.Address = GetValue(ColAddress, index);
                pe.PostalCode = GetValue(ColPostalCode, index);

                pe.TellList = new List<PhoneBookBussines>();
                if (!string.IsNullOrEmpty(GetValue(ColTell1, index))) pe.TellList.Add(new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = pe.Name,
                    ParentGuid = pe.Guid,
                    Group = EnPhoneBookGroup.Peoples,
                    Tell = GetValue(ColTell1, index)
                });
                if (!string.IsNullOrEmpty(GetValue(ColTell3, index))) pe.TellList.Add(new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = pe.Name,
                    ParentGuid = pe.Guid,
                    Group = EnPhoneBookGroup.Peoples,
                    Tell = GetValue(ColTell3, index)
                });
                if (!string.IsNullOrEmpty(GetValue(ColTell4, index))) pe.TellList.Add(new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = pe.Name,
                    ParentGuid = pe.Guid,
                    Group = EnPhoneBookGroup.Peoples,
                    Tell = GetValue(ColTell4, index)
                });
                if (!string.IsNullOrEmpty(GetValue(ColTell2, index))) pe.TellList.Add(new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Name = pe.Name,
                    ParentGuid = pe.Guid,
                    Group = EnPhoneBookGroup.Peoples,
                    Tell = GetValue(ColTell2, index)
                });
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return pe;
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupBindingSource.Count <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("لطفا ابتدا نسبت به تعریف گر.ه اشخاص اقدام نمایید");
                    cmbWithoutGroup.Focus();
                    return;
                }

                if (DGrid.RowCount <= 0)
                {
                    frmNotification.PublicInfo.ShowMessage("هیچ داده ای وجود ندارد");
                    cmbWithoutGroup.Focus();
                    return;
                }


                var frm = new frmSplash(DGrid.RowCount);
                frm.Show(this);
                for (var i = 0; i < DGrid.RowCount; i++)
                {
                    var x = await GetItemsAsync(i);
                    frm.Level = i;
                    if (x == null) continue;
                    await x.SaveAsync();
                }

                DialogResult = DialogResult.OK;
                frm.Close();
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmImportExcel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
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
    }
}
