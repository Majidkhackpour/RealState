using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;

namespace Building
{
    public abstract class clsBuildingColtrols : UserControl
    {
        public virtual BuildingBussines Building { get;}
        public abstract Task SetBuildingAsync(BuildingBussines value);
    }
}
