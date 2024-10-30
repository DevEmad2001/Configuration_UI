using System.Threading.Tasks;
using GUI_Adtech.Models;

namespace GUI_Adtech.Repositories
{
    public interface IAuthConfigRepository
    {
        Task<AdtechConfig> GetConfigAsync(string parameterName, string componentName);
        Task UpdateConfigAsync(AdtechConfig config);
        Task AddConfigAsync(AdtechConfig config);

        // دوال خاصة بأنواع المصادقة المختلفة
        Task<AdtechConfig> GetBasicAuthConfig(string componentName);
        Task<AdtechConfig> GetTokenAuthConfig(string componentName);
        Task<AdtechConfig> GetCertificateAuthConfig(string componentName);
    }
}
