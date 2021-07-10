using System.Windows.Forms;
using EntityCache.Bussines;

namespace RealState.UserControls
{
    public partial class ucCustomerBirthday : UserControl
    {
        private PeoplesBussines _peoples;
        public PeoplesBussines People
        {
            get => _peoples;
            set
            {
                _peoples = value;
                if (_peoples == null) return;
                lblName.Text = _peoples.Name;
            }
        }
        public ucCustomerBirthday() => InitializeComponent();
    }
}
