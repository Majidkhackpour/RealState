using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Notification.AdjectiveDescription
{
    public partial class frmShowDesc : MetroForm
    {
        public string Description { get; set; }
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                var list = await AdjectiveDescriptionBussines.GetAllAsync(search);
                Invoke(new MethodInvoker(() => DescBindingSource.DataSource = list.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowDesc()
        {
            InitializeComponent();
            DGrid.Focus();
        }

        private async void frmShowDesc_Load(object sender, EventArgs e) => await LoadDataAsync();
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadDataAsync(txtSearch.Text);
        private void frmShowDesc_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                        Description = DGrid[dgDesc.Index, DGrid.CurrentRow.Index].Value.ToString();
                        DialogResult = DialogResult.OK;
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmDescMain(new AdjectiveDescriptionBussines());
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var tafsil = await AdjectiveDescriptionBussines.GetAsync(guid);
                if (tafsil == null)
                {
                    frmNotification.PublicInfo.ShowMessage("شرح انتخاب شده معتبر نمی باشد");
                    return;
                }

                var obj = await AdjectiveDescriptionBussines.GetAsync(guid);
                if (obj == null) return;
                var frm = new frmDescMain(obj);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
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
                if (DGrid.RowCount <= 0 || DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var hazine = await AdjectiveDescriptionBussines.GetAsync(guid);
                if (hazine == null) return;
                
                if (MessageBox.Show(this,
                        $@"آیا از حذف  شرح آماده اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                res.AddReturnedValue(await hazine.RemoveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (!res.HasError) await LoadDataAsync(txtSearch.Text);
            }
        }
    }
}
