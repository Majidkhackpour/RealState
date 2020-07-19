using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISettingsRepository : IRepository<SettingsBussines>
    {
        Task<SettingsBussines> GetAsync(string memberName);
    }
}
